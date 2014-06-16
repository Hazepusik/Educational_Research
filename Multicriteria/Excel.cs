using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace Multicriteria
{
    class Excel
    {


        private static bool FileIsLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public static DataTable DataGridViewToDataTable(DataGridView dgv, int minRow = 0)
        {
            DataTable dt = new DataTable("tbl");
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }

            dt.Rows.Add(dr);
            }


            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = " ";
                }
                dt.Rows.Add(dr);
            }
            return dt;

        }

        /// <summary>
        /// Read data from Excel File
        /// </summary>
        public static bool ReadXls(string filePath)
        {
            Data.models = new List<Model>();
            Data.criteria = new List<Criterion>();
            Model.ResetModel();
            Criterion.ResetCriterion();
            
            var existingFile = new FileInfo(filePath);
            if (FileIsLocked(existingFile))
            {
                MessageBox.Show("Произошла ошибка при открытии файла.\nУбедитесь, что файл существует и закрыт.");
                return false;
            }
         
            using (var package = new ExcelPackage(existingFile))
            {
                List<int> ids = new List<int>();
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count < 2)
                    {
                        MessageBox.Show("Произошла ошибка при чтении файла.\nУбедитесь, что файл заполнен верно.");
                        return false;
                    }
                    ExcelWorksheet dataWorksheet = workBook.Worksheets[1];
                    ExcelWorksheet sysWorksheet = workBook.Worksheets[2];
                    int modelsCount;
                    if (!int.TryParse(sysWorksheet.Cells[1, 2].Value.ToString(), out modelsCount))
                    {
                        MessageBox.Show("Произошла ошибка при чтении файла.\nУбедитесь, что файл заполнен верно.");
                        return false;
                    }
                    int criteriaCount;
                    if (!int.TryParse(sysWorksheet.Cells[1, 4].Value.ToString(), out criteriaCount))
                    {
                        MessageBox.Show("Произошла ошибка при чтении файла.\nУбедитесь, что файл заполнен верно.");
                        return false;
                    }
                    Data.table = new double[modelsCount][];
                    for (int x = 0; x < modelsCount; x++) 
                    {
                        Data.table[x] = new double[criteriaCount];
                    }
                    for (int row = 0; row < modelsCount; row++)
                    {
                        for (int col = 0; col < criteriaCount; col++)
                        {
                            Data.table[row][col] = CellToFloat(dataWorksheet.Cells[row + 2, col + 2]);
                        }
                    }
                    for (int col = 1; col <= criteriaCount; col++)
                    {
                        Data.criteria.Add(new Criterion(dataWorksheet.Cells[1, col + 1].Value.ToString(), CellToInt(sysWorksheet.Cells[3, col]), Convert.ToBoolean(sysWorksheet.Cells[4, col].Value)));
                        if (Convert.ToBoolean(sysWorksheet.Cells[4, col].Value))
                            ids.Add(col);
                    }
                    for (int row = 1; row <= modelsCount; row++)
                    {
                        Data.models.Add(new Model(dataWorksheet.Cells[row + 1, 1].Value.ToString()));
                    }
                    if (Data.criteria.Exists(c => c.value == 0))
                    {
                        MessageBox.Show("Произошла ошибка при чтении файла.\nУбедитесь, что файл заполнен верно.");
                        return false;
                    }
                    
                }

                Data.table = MathLib.Common.MakeReverse(Data.table, ids);
                return true;
            }
        }

        public static double CellToFloat(ExcelRange cell)
        {
            try
            {
                //string q = cell.Value.ToString().Replace(",", ".");
                return Convert.ToDouble(cell.Value.ToString().Replace(".",","));
            }
            catch
            {
                return 0;
            }
        }

        private static int CellToInt(ExcelRange cell)
        {
            try
            {
                return int.Parse(cell.Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Generates the report.
        /// </summary>
        public static bool GenerateReport(List<Criterion> criteria, List<Model> models, DataTable data)
        {
            //DataTable data = DataGridViewToDataTable(dgv);
            using (ExcelPackage package = new ExcelPackage())
            {
                SetWorkbookProperties(package);
                ExcelWorksheet dataWorksheet = CreateSheet(package, "Сравнительные характеристики");
                ExcelWorksheet sysWorksheet = CreateSheet(package, "System");

                int rowIndex = 2;
                int colIndex = 1;

                FillModels(dataWorksheet, models, rowIndex, colIndex);

                rowIndex--;
                colIndex++;

                FillCriteria(dataWorksheet, criteria, rowIndex, colIndex);

                FillSysData(sysWorksheet, models, criteria);

                dataWorksheet.Cells[1, 1].LoadFromDataTable(data, false); 

                Byte[] bin = package.GetAsByteArray();
                SaveFileDialog saveFD = new SaveFileDialog();

                saveFD.InitialDirectory = Directory.GetCurrentDirectory();
                saveFD.Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
                saveFD.FilterIndex = 1;
                saveFD.RestoreDirectory = true;
                if (saveFD.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFD.FileName;
                    var existingFile = new FileInfo(fileName);
                    if (FileIsLocked(existingFile) && File.Exists(fileName))
                    {
                        MessageBox.Show("Произошла ошибка при записи файла.\nУбедитесь, что файл закрыт.");
                        return false;
                    }
                    else
                    {
                        File.WriteAllBytes(fileName, bin);
                        Data.filePath = fileName;
                        //ProcessStartInfo pi = new ProcessStartInfo(fileName);
                        //Process.Start(pi);
                    }
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при генерации файла");
                    return false;
                }
            }
            return true;
        }

        private static void FillCriteria(ExcelWorksheet ws, List<Criterion> criteria, int row, int col)
        {
            foreach (Criterion criterion in criteria)
            {
                var cellName = ws.Cells[row, col];
                //var cellValue = ws.Cells[row + 1, col];

                //Setting Value in cell
                cellName.Value = criterion.name;
                //cellValue.Value = criterion.value;
                col++;
            }
        }

        private static void FillModels(ExcelWorksheet ws, List<Model> models, int row, int col)
        {
            foreach (Model model in models)
            {
                var cell = ws.Cells[row, col];
                cell.Value = model.name;
                row++;
            }
        }

        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[p.Workbook.Worksheets.Count];
            ws.Name = sheetName; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet

            return ws;
        }

        /// <summary>
        /// Sets the workbook properties and adds a default sheet.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static void SetWorkbookProperties(ExcelPackage p)
        {
            //Here setting some document properties
            p.Workbook.Properties.Author = "Khazov Andrey";
            p.Workbook.Properties.Title = "Comparation table";


        }


        private static void FillSysData(ExcelWorksheet ws, List<Model> models, List<Criterion> criteria)
        {
            ws.Cells[1, 1].Value = "Models count";
            ws.Cells[1, 2].Value = models.Count;
            ws.Cells[1, 3].Value = "Criteria count";
            ws.Cells[1, 4].Value = criteria.Count;
            int col = 1;
            foreach (Criterion criterion in criteria)
            {
                ws.Cells[2, col].Value = criterion.name;
                ws.Cells[3, col].Value = criterion.value;
                ws.Cells[4, col].Value = criterion.reverse;
                col++;
            }
        }

        public static void WriteElectre()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                List<Model> models = Data.notDominated;
                double[][] C = Electre.C;
                double[][] D = Electre.D;
                SetWorkbookProperties(package);

                ExcelWorksheet score = CreateSheet(package, "Таблица смежности");
                ExcelWorksheet agree = CreateSheet(package, "Согласие");
                ExcelWorksheet disagree = CreateSheet(package, "Несогласие");


                int current = 2;
                score.Cells[1, 1].Value = "Модел(и)";
                score.Cells[1, 2].Value = "Штрафной балл";
                foreach (System.Tuple<string, double> modSc in Electre.scores)
                {
                    string m = modSc.Item1;
                    double s = modSc.Item2;
                    score.Cells[current, 1].Value = m;
                    score.Cells[current, 2].Value = s.ToString();
                    current++;
                }


                current = 2;
                foreach (Model model in models)
                {
                    agree.Cells[1, current].Value = model.name;
                    agree.Cells[current, 1].Value = model.name;
                    disagree.Cells[1, current].Value = model.name;
                    disagree.Cells[current, 1].Value = model.name;
                    current++;
                }
                int modelsCount = models.Count;
                for (int r = 2; r <= modelsCount + 1; ++r)
                    for (int c = 2; c <= modelsCount + 1; ++c)
                    {
                        if (r == c)
                        {
                            agree.Cells[r, c].Value = "*";
                            disagree.Cells[r, c].Value = "*";
                        }
                        else
                        {
                            agree.Cells[r, c].Value = C[r - 2][c - 2];
                            disagree.Cells[r, c].Value = D[r - 2][c - 2];
                        }
                    }

                Byte[] bin = package.GetAsByteArray();
                string fileName = Data.GetFileName() + "_electre_result.xlsx";
                //TODO: file is busy + fname change
                File.WriteAllBytes(fileName, bin);
                ProcessStartInfo pi = new ProcessStartInfo(fileName);
                Process.Start(pi);
            }
        }

        public static void WriteSuperiority()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                List<Model> models = Data.notDominated;
                double[][] C = Superiority.C;
                SetWorkbookProperties(package);

                ExcelWorksheet score = CreateSheet(package, "Таблица смежности");
                ExcelWorksheet agree = CreateSheet(package, "Согласие");

                int current = 2;
                score.Cells[1, 1].Value = "Модел(и)";
                score.Cells[1, 2].Value = "Штрафной балл";
                foreach (System.Tuple<string, double> modSc in Superiority.scores)
                {
                    string m = modSc.Item1;
                    double s = modSc.Item2;
                    score.Cells[current, 1].Value = m;
                    score.Cells[current, 2].Value = s.ToString();
                    current++;
                }


                current = 2;
                foreach (Model model in models)
                {
                    agree.Cells[1, current].Value = model.name;
                    agree.Cells[current, 1].Value = model.name;
                    current++;
                }
                int modelsCount = models.Count;
                for (int r = 2; r <= modelsCount + 1; ++r)
                    for (int c = 2; c <= modelsCount + 1; ++c)
                    {
                        if (r == c)
                        {
                            agree.Cells[r, c].Value = "*";
                        }
                        else
                        {
                            agree.Cells[r, c].Value = C[r - 2][c - 2];
                        }
                    }

                Byte[] bin = package.GetAsByteArray();
                string fileName = Data.GetFileName() + "_superiority_result.xlsx";
                //TODO: file is busy + fname change
                File.WriteAllBytes(fileName, bin);
                ProcessStartInfo pi = new ProcessStartInfo(fileName);
                Process.Start(pi);
            }
        }


        public static void WriteAvg()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                List<Model> models = Data.notDominated;
                SetWorkbookProperties(package);

                ExcelWorksheet score = CreateSheet(package, "Результат");

                int current = 2;
                score.Cells[1, 1].Value = "Модел(и)";
                score.Cells[1, 2].Value = "Штрафной балл";
                foreach (System.Tuple<string, double> avgSc in Data.avgScores)
                {
                    string m = avgSc.Item1;
                    double s = avgSc.Item2;
                    score.Cells[current, 1].Value = m;
                    score.Cells[current, 2].Value = s.ToString();
                    current++;
                }

                Byte[] bin = package.GetAsByteArray();
                string fileName = Data.GetFileName()+"_avg_result.xlsx";
                //TODO: file is busy
                File.WriteAllBytes(fileName, bin);
                ProcessStartInfo pi = new ProcessStartInfo(fileName);
                Process.Start(pi);
            }
        }

    }
}
