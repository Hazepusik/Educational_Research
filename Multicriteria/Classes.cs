using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Multicriteria
{
    public class Model
    {
        private static int modelID = 0;
        public int id;
        public string name;
        public int dominatedStatus = 0; // 0 - not domin, -1 - domin, n - eq with
        private static bool isDominated = false;
        private static bool IsDominated
        {
            get { return isDominated; }
            set { isDominated = value; }
        }
        public Model()
        {
            id = ++modelID;
            name = "Unknown " + modelID.ToString();
            dominatedStatus = 0;
        }
        public Model(string nm)
        {
            id = ++modelID;
            dominatedStatus = 0;
            name = nm;
        }
        public static void ResetModel()
        {
            modelID = 0;
            isDominated = false;
        }

        public static void CheckDominated()
        {
            if (!Model.IsDominated)
            {
                List<int> dominated = new List<int>();
                List<int> equal = new List<int>();
                List<int>[] output = new List<int>[2];
                output = MathLib.Domin.CalcDominated(Data.table);
                dominated = output[0];
                equal = output[1];
                dominated.Reverse();
                foreach (int eq in equal)
                {
                    int mainId = MathLib.Domin.EqualIndex(Data.table, eq - 1);
                    Data.models.First(m => m.id == mainId).name += "; " + Data.models[eq - 1].name;
                    Data.models[eq - 1].dominatedStatus = mainId;

                }
                foreach (int dom in dominated)
                {
                    Data.models[dom - 1].dominatedStatus = -1;
                }
                Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
                Data.tablePareto = new double[notDominated.Count()][];
                int criteriaCount = Data.criteria.Count();
                int current = 0;
                foreach (Model m in notDominated)
                {
                    Data.tablePareto[current] = new double[criteriaCount];
                    for (int i = 0; i < criteriaCount; ++i)
                    {
                        Data.tablePareto[current][i] = Data.table[m.id - 1][i];
                    }
                    current++;
                }

            } Model.IsDominated = true;
        }
    }

    public class Criterion
    {
        private static int criterionID = 0;
        
        public int id;
        public string name;
        public int value;
        public bool reverse;

        public Criterion()
        {
            id = ++criterionID;
            name = "Unknown "+criterionID.ToString();
            value = 0;
            reverse = false;
        }

        public Criterion(string nm, double vl, bool rev)
        {
            id = ++criterionID;
            name = nm;
            vl = (vl > 100) ? 100 : vl;
            vl = (vl < 1) ? 1 : vl;
            value = (int)Math.Round(vl);
            reverse = rev;
        }

        public static void ResetCriterion()
        {
            criterionID = 0;
        }

    }

    public static class Logger
    {
        public static StringBuilder log;
        private static string begin;
        public static void Init()
        {
            log = new StringBuilder();
            begin = DateTime.Now.ToString("d MMM yyyy HH:mm");
            log.AppendLine("Начало работы " + begin);
        }

        public static void AddFileAction(string action)
        {
            log.AppendLine();
            log.AppendLine("Файл " + Data.GetFileName() + ".xlsx успешно " + action);
        }

        public static void AddGraphAction(double[] values)
        {
            //log.AppendLine();
            string act = "В методе {0} просмотрен граф со значением критери{1} {2}. В ядро вошли модели: ";
            int[] cores;
            if (values.Count() == 1)
            {
                act = String.Format(act, "Отношения превосходства", "я С = ", Math.Round(values[0], 4).ToString());
                cores = MathLib.Common.GetGraphCore(MathLib.Superiority.GetGraphByIndexes(Superiority.C, values[0]));
            }
            else
            {
                act = String.Format(act, "ELECTRE", "я С = " + Math.Round(values[0], 4).ToString(), "D = " + Math.Round(values[1], 4).ToString());
                cores = MathLib.Common.GetGraphCore(MathLib.Electre.GetGraphByIndexes(Electre.C, Electre.D, values[0], values[1]));
            }
            Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
            for (int i = 0; i < cores.Count(); ++i)
                if (cores[i] == 1)
                {

                    act += notDominated[i].name + "; ";
                }
            if (cores.Sum() == 0)
                act += "НЕТ";
            log.AppendLine(act);
        }

        public static void Finish()
        {
            log.AppendLine();
            string messageBoxText = "Сохранить лог работы с файлом?";
            string caption = "Завершение работы";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            log.AppendLine(caption + " " + DateTime.Now.ToString("d MMM yyyy HH:mm"));
            switch (result)
            {
                case DialogResult.Yes:
                    string fPath = Data.GetFileName() + "_log " + DateTime.Now.ToString("d MMM yyyy HH-mm") + ".txt";
                    StringBuilder sb = new StringBuilder();
                    using (StreamWriter outfile = new StreamWriter(fPath))
                    {
                        //TODO: check if busy
                        outfile.Write(log.ToString());
                    }
                    break;
                case DialogResult.No:

                    break;
            }
        }
    }

    public static class Data
    {
        public static List<Model> models;
        public static List<Criterion> criteria;
        public static double[][] table;
        public static double[][] tablePareto;
        public static System.Tuple<string, double>[] avgScores;
        public static string filePath;
        public static List<Model> notDominated;

        public static string GetFileName()
        {
            return filePath.Substring(0, filePath.Length - 5);
        }
        public static void ShowResults(System.Tuple<string, double>[] scores, int method)
        {
            string messageBoxText = "Результаты: модели и приоритет";
            string s = "Задача решена методом: {0}";
            Logger.log.AppendLine(messageBoxText);
            switch (method)
            {
                case 0:
                    {
                        s = String.Format(s, "Комбинированный.");
                        break;
                    }
                case 1:
                    {
                        s = String.Format(s, "Отношения превосходства.");
                        break;
                    }
                case 2:
                    {
                        s = String.Format(s, "ELECTRE.");
                        break;
                    }
            }
            Logger.log.AppendLine();
            Logger.log.AppendLine(s);
            foreach (System.Tuple<string, double> score in scores)
            {
                messageBoxText += String.Format("\n{0} - {1}", score.Item1, score.Item2.ToString());
                Logger.log.AppendLine(String.Format("{0} - {1}", score.Item1, score.Item2.ToString()));
            }
            messageBoxText += "\n\n\n Сохранить результат в файл?";
            string caption = "Результат";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            

            switch (result)
            {
                case DialogResult.Yes:
                    switch (method)
                    {
                        case 0:
                            {
                                Excel.WriteAvg();
                                break;
                            }
                        case 1:
                            {
                                Excel.WriteSuperiority();
                                break;
                            }
                        case 2:
                            {
                                Excel.WriteElectre();
                                break;
                            }
                    }
                    break;
                case DialogResult.No:
                    
                    break;
            }
        }


        public static void ShowPareto()
        {
            var reverseIds = Data.criteria.Where(c => c.reverse).Select(x => x.id);
            Data.table = MathLib.Common.MakeReverse(Data.table, reverseIds);
            Model.CheckDominated();
            Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
            string txt = "Оптимальные по Парето модели:\n(через ';' обозначены эквивалентные)\n";
            foreach (Model m in notDominated)
            {
                txt += "\n" + m.name;
            }
            MessageBox.Show(txt);
        }
    }

    public static class Superiority
    {
        public static double[][] C;
        public static System.Tuple<string, double>[] scores;
        public static int importance = 1;

        public static DataGridView ShowCMatrix()
        {
            Chart chart = new Chart();
            chart.Titles.Add("Зависимость количества элементов ядра\n от граничного значения индекса согласия");
            chart.Series.Add("n(C)");
            chart.Series.Add(" ");
            double[] cset = MathLib.Common.GetSet(Superiority.C);
            DataGridView data = new DataGridView();
            // data.Parent = this;
            data.ColumnHeadersVisible = false;
            data.RowHeadersVisible = false;
            data.Columns.Add("first", "first");
            data.Rows.Add(2);
            data.AllowUserToAddRows = false;
            data.AllowUserToOrderColumns = false;
            data.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
            data.Rows[0].Cells[0].Value = "C = ";
            data.Rows[1].Cells[0].Value = "N = ";
            data.Rows[0].Cells[0].ReadOnly = true;
            data.Font = new Font(data.Font.Name, 12, data.Font.Style);
            data.Columns[0].Width = 70;
            foreach (double c in cset)
            {
                int col = data.Columns.Add(c.ToString(), c.ToString());
                data.Rows[0].Cells[col].Value = Math.Round(c, 4).ToString();
                data.Rows[0].Cells[col].ReadOnly = true;
                data.Rows[0].Cells[col].Style.Font = new Font(data.Font, FontStyle.Bold);
                data.Rows[0].Cells[col].Style.BackColor = Color.LightGray;
                data.Columns[col].Width = 70;

            }

            int column = 1;
            List<double> sums = new List<double>();
            foreach (double c in cset)
            {

                int[] core = MathLib.Common.GetGraphCore(MathLib.Superiority.GetGraphByIndexes(C, c));
                data.Rows[1].Cells[column].Value = core.Sum();
                sums.Add(core.Sum());
                data.Rows[1].Cells[column].ReadOnly = true;
                column++;
                
            }
            for (int i = 0; i < cset.Count(); ++i)
            {
                chart.Series[0].Points.AddXY(Math.Round(cset[i], 4), sums[i]);
                chart.Series[0].BorderWidth = 5;
                chart.Series[1].Points.AddXY(Math.Round(cset[i], 4), sums[i]);
                chart.Series[1].MarkerSize = 10;
            }
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[1].ChartType = SeriesChartType.Point;
            data.Left = 5;
            data.Top = 25;
            int w = Math.Min(Math.Max(data.Columns[0].Width + (data.Columns.Count - 1) * data.Columns[1].Width, 500), 800);
            int h = Math.Min(data.Rows.Count * data.Rows[0].Height, 600);
            w += 3;
            h += 3;
            data.Size = new Size(Math.Min(data.Columns[0].Width + (data.Columns.Count - 1) * data.Columns[1].Width, 800) + 3, h);
            Form tabel = new Form();
            //data.Parent = tabel;
            tabel.Size = new Size(w + 20, h + 70);
            Label text = new Label();
            //text.Parent = tabel;
            text.Text = "Количество оптимальных решений при различных C";
            text.Font = new Font(data.Font, FontStyle.Bold);
            text.Left = 5;
            text.Top = 5;
            text.Size = new Size(w, 20);
            //tabel.MinimizeBox = false;
            //tabel.FormBorderStyle = FormBorderStyle.FixedDialog;
            chart.Top = 0;
            chart.Left = 0;
            
            //series.XValueMember = "X";
            //series.YValueMembers = "Y";
            chart.DataBind();
            //chart.Series["main"].SetDefault(true);
            //chart.Series["main"].Enabled = true;
            //chart.Visible = true;
            chart.Parent = tabel;
            chart.ChartAreas.Add(new ChartArea());
            chart.Legends.Add(new Legend());
            chart.Size = new Size(600, 300);
            chart.DataBind();
            tabel.Size = new Size(610, 330);
            tabel.ShowDialog();
            return data;
        }
    }

    public static class Electre
    {
        //public static double Y;
        //public static double Q;
        //public static int[][] graph;
        public static double[][] C;
        public static double[][] D;
        public static System.Tuple<string, double>[] scores;
        public static int importance = 3;

        public static DataGridView ShowCDMatrix()
        {
            double[] cset = MathLib.Common.GetSet(Electre.C);
            double[] dset = MathLib.Common.GetSet(Electre.D);
            DataGridView data = new DataGridView();
            // data.Parent = this;
            data.ColumnHeadersVisible = false;
            data.RowHeadersVisible = false;
            data.Columns.Add("first", "first");
            data.Rows.Add(dset.Count()+1);
            data.AllowUserToAddRows = false;
            data.AllowUserToOrderColumns = false;
            data.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
            data.Rows[0].Cells[0].ReadOnly = true;
            data.Font = new Font(data.Font.Name, 12, data.Font.Style);
            data.Columns[0].Width = 70;
            foreach (double c in cset)
            {
                int col = data.Columns.Add(c.ToString(), c.ToString());
                data.Rows[0].Cells[col].Value = Math.Round(c, 4).ToString();
                data.Rows[0].Cells[col].ReadOnly = true;
                data.Rows[0].Cells[col].Style.Font = new Font(data.Font, FontStyle.Bold);
                data.Rows[0].Cells[col].Style.BackColor = Color.LightGray;
                data.Columns[col].Width = 70;

            }
            int i = 1;
            foreach (double d in dset)
            {
                data.Rows[i].Cells[0].Value = Math.Round(d, 4).ToString();
                data.Rows[i].Cells[0].ReadOnly = true;
                data.Rows[i].Cells[0].Style.Font = new Font(data.Font, FontStyle.Bold);
                data.Rows[i].Cells[0].Style.BackColor = Color.LightGray;
                ++i;
            }
            int row = 1;
            foreach (double d in dset)
            {
                int col = 1;
                foreach (double c in cset)
                {

                    int[] core = MathLib.Common.GetGraphCore(MathLib.Electre.GetGraphByIndexes(C,D,c,d));
                    data.Rows[row].Cells[col].Value = core.Sum();
                    data.Rows[row].Cells[col].ReadOnly = true;
                    col++;
                }
                row++;
            }
            
            data.Left = 5;
            data.Top = 45;
            int w = Math.Min(Math.Max(data.Columns[0].Width + (data.Columns.Count - 1) * data.Columns[1].Width, 500), 800);
            int h = Math.Min(data.Rows.Count * data.Rows[0].Height, 600);
            w += 3;
            h += 3;
            data.Size = new Size(Math.Min(data.Columns[0].Width + (data.Columns.Count - 1) * data.Columns[1].Width, 800)+3, h);
            Form tabel = new Form();
            data.Parent = tabel;
            tabel.Size = new Size(w+20, h+90);
            Label text = new Label();
            text.Parent = tabel;
            text.Text = "Количество оптимальных решений при различных C, D\nЗначения C - по горизонтали, D - по вертикали";
            text.Font = new Font(data.Font, FontStyle.Bold);
            text.Left = 5;
            text.Top = 5;
            text.Size = new Size(w, 40);
            tabel.MinimizeBox = false;
            tabel.FormBorderStyle = FormBorderStyle.FixedDialog;
            tabel.ShowDialog();
            return data;
        }
    }
}
