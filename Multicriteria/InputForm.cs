using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathLib;

namespace Multicriteria
{
    public partial class frmInput : Form
    {
        private int critCount; 
        private int modCount;
        private List<Criterion> criteria = new List<Criterion>();
        private List<Model> models = new List<Model>();
        private List<TextBox> critName = new List<TextBox>();
        private List<TextBox> modName = new List<TextBox>();
        private List<CheckBox> isRev = new List<CheckBox>();
        //private List<TextBox> maxDiff = new List<TextBox>();
        private List<NumericUpDown> critValue = new List<NumericUpDown>();
        private DataGridView data = new DataGridView();
        private bool critFilled;
        private bool isNew;
        private int prevMod;
        private int prevCrit;
        public frmInput(bool New)
        {
            isNew = New;
            InitializeComponent();
        }


        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void SwitchObjects()
        {
            btnCount.Visible = !btnCount.Visible;
            txtCount.ReadOnly = !txtCount.ReadOnly;
            btnSave.Visible = !btnSave.Visible;
            lblName.Visible = !lblName.Visible;
            lblValue.Visible = !lblValue.Visible;
            //lblDiff.Visible = !lblDiff.Visible;
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            if (!critFilled)
            {
                critName.Clear();
                critValue.Clear();
                isRev.Clear();
                if (!int.TryParse(txtCount.Text, out critCount) || critCount < 2)
                {
                    MessageBox.Show("Введите число больше единицы.");
                }
                else
                {
                    for (int i = 0; i < critCount; ++i)
                    {
                        TextBox tbName = new TextBox(); 
                        tbName.Size = new Size(200, 30);
                        tbName.Parent = this;
                        tbName.Font = new Font(tbName.Font.Name, 14, tbName.Font.Style);
                        tbName.Location = new Point(lblName.Left, lblName.Top + (i + 1) * 40);
                        if (!isNew && Data.criteria.Count > i)
                        {
                            tbName.Text = Data.criteria[i].name;
                        }
                        critName.Add(tbName);

                        NumericUpDown nudValue = new NumericUpDown();
                        nudValue.Size = new Size(60, 30);
                        nudValue.Parent = this;
                        nudValue.Font = new Font(nudValue.Font.Name, 14, nudValue.Font.Style);
                        nudValue.Minimum = 1;
                        nudValue.Maximum = 100;
                        nudValue.Value = 100;
                        if (!isNew && Data.criteria.Count > i)
                        {
                            nudValue.Value = Data.criteria[i].value;
                        }
                        nudValue.Location = new Point(lblValue.Left, lblValue.Top + (i + 1) * 40);
                        critValue.Add(nudValue);

                        CheckBox cbRev = new CheckBox();
                        cbRev.Parent = this;
                        cbRev.Location = new Point(lblDiff.Left, nudValue.Top);
                        cbRev.Size = new Size(250, 30);
                        cbRev.Font = new Font(cbRev.Font.Name, 14, cbRev.Font.Style);
                        cbRev.Text = "Оценивать реверсивно";
                        if (!isNew && Data.criteria.Count > i)
                        {
                            cbRev.Checked = Data.criteria[i].reverse;
                        }
                        isRev.Add(cbRev);
                    }
                    SwitchObjects();
                    lblTitle.Text = "Число критериев";
                    int height = Math.Min(critCount * 40 + lblValue.Top + 140, 600);
                    btnSave.Size = new Size(200, 40);
                    btnSave.Location = new Point(lblName.Left, lblName.Top + (critCount + 1) * 40);
                    this.Size = new Size(680, height);
                }
            }
            else
            {
                modName.Clear();
                if (!int.TryParse(txtCount.Text, out modCount) || modCount < 2)
                {
                    MessageBox.Show("Введите число больше единицы.");
                }
                else
                {
                    for (int i = 0; i < modCount; ++i)
                    {
                        TextBox tbName = new TextBox();
                        tbName.Size = new Size(200, 30);
                        tbName.Parent = this;
                        tbName.Font = new Font(tbName.Font.Name, 14, tbName.Font.Style);
                        tbName.Location = new Point(lblName.Left, lblName.Top + (i + 1) * 40);
                        if (!isNew && Data.models.Count > i)
                        {
                            tbName.Text = Data.models[i].name;
                        }
                        modName.Add(tbName);
                    }
                    SwitchObjects();
                    lblTitle.Text = "Число моделей";
                    lblValue.Visible = false;
                    lblDiff.Visible = false;
                    int height = Math.Min(modCount * 40 + lblValue.Top + 140, 600);
                    btnSave.Size = new Size(200, 40);
                    btnSave.Location = new Point(lblName.Left, lblName.Top + (modCount + 1) * 40);
                    this.Size = new Size(280, height);
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!critFilled)
            {
                bool failed = false;
                for (int i = 0; i < critCount; ++i)
                {
                    if (critName[i].Text == "")
                        failed = true;
                }
                if (!failed)
                {
                    Criterion.ResetCriterion();
                    for (int i = 0; i < critCount; ++i)
                    {
                        criteria.Add(new Criterion(critName[i].Text, int.Parse(critValue[i].Value.ToString()), isRev[i].Checked));
                        critName[i].Dispose();
                        critValue[i].Dispose();
                        isRev[i].Dispose();
                    }
                    SwitchObjects();
                    txtCount.Text = "";
                    lblTitle.Text = "Введите число моделей";
                    critFilled = true;
                    this.Size = new Size(320, 135);
                    if (!isNew)
                    {
                        txtCount.Text = Data.models.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при записи данных.\nУбедитесь, что все названия критериев заполнены.");
                }
            }
            else
            {
                bool failed = false;
                for (int i = 0; i < modCount; ++i)
                {
                    if (modName[i].Text == "")
                        failed = true;
                }
                if (!failed)
                {
                    Model.ResetModel();
                    for (int i = 0; i < modCount; ++i)
                    {
                        models.Add(new Model(modName[i].Text));
                        modName[i].Dispose();
                    }

                    data.Parent = this;
                    data.ColumnHeadersVisible = false;
                    data.RowHeadersVisible = false;
                    data.Columns.Add("first", "first");
                    data.Rows.Add(models.Count + 1);
                    data.AllowUserToAddRows = false;
                    data.AllowUserToOrderColumns = false;
                    data.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
                    data.Rows[0].Cells[0].ReadOnly = true;
                    data.Font = new Font(data.Font.Name, 12, data.Font.Style);
                    data.Columns[0].Width = 140;
                    foreach (Criterion c in criteria)
                    {
                        int col = data.Columns.Add(c.name, c.name);
                        data.Rows[0].Cells[col].Value = c.name;
                        data.Rows[0].Cells[col].ReadOnly = true;
                        data.Rows[0].Cells[col].Style.Font = new Font(data.Font, FontStyle.Bold);
                        data.Rows[0].Cells[col].Style.BackColor = Color.LightGray;
                        data.Columns[col].Width = 120;

                    }
                    foreach (Model m in models)
                    {
                        data.Rows[m.id].Cells[0].Value = m.name;
                        data.Rows[m.id].Cells[0].ReadOnly = true;
                        data.Rows[m.id].Cells[0].Style.Font = new Font(data.Font, FontStyle.Bold);
                        data.Rows[m.id].Cells[0].Style.BackColor = Color.LightGray;
                    }
                    data.Left = 5;
                    data.Top = 5;
                    int w = Math.Min(data.Columns[0].Width + (data.Columns.Count - 1) * data.Columns[1].Width, 800);
                    int h = Math.Min(data.Rows.Count * data.Rows[0].Height, 600);
                    w += 3;
                    h += 3;
                    data.Size = new Size(w, h);
                    if (!isNew)
                    {
                        for (int i = 0; i < Math.Min(prevMod, modCount); ++i)
                            for (int j = 0; j < Math.Min(prevCrit, critCount); ++j)
                                data.Rows[i+1].Cells[j+1].Value = Data.table[i][j];
                    }
                    data.Visible = true;
                    btnFinish.Left = data.Left;
                    btnFinish.Top = h + 10;
                    btnFinish.Width = w;
                    btnFinish.Height = 50;
                    btnFinish.Visible = true;
                    this.Width = w + 26;
                    this.Height = h + 102;
                    this.btnSave.Visible = false;
                    this.txtCount.Visible = false;
                    this.lblName.Visible = false;
                    this.lblTitle.Visible = false;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при записи данных.\nУбедитесь, что все названия моделей заполнены.");
                }
            }
        }

        private void frmFill_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            critFilled = false;
            data.Visible = false;
            this.Size = new Size(320, 135);
            if (!isNew)
            {
                txtCount.Text = Data.criteria.Count.ToString();
                prevCrit = Data.criteria.Count;
                prevMod = Data.models.Count;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DataTable dataT = Excel.DataGridViewToDataTable(data);
            double[][] t = new double[data.RowCount-1][];
            for (int x = 1; x < data.RowCount; x++)
                t[x-1] = new double[data.ColumnCount-1];

            bool ok = true;
            for (int i = 1; i < data.RowCount; ++i)
                for (int j = 1; j < data.ColumnCount; ++j)
                {
                    try
                    {
                        t[i-1][j-1] = Convert.ToDouble(dataT.Rows[i].ItemArray[j].ToString().Replace(".", ","));
                    }
                    catch
                    {
                        if (dataT.Rows[i].ItemArray[j].ToString() == "")
                            t[i-1][j-1] = 0;
                        else
                            ok = false;
                    }
                }


            if (ok)
            {
                if (Excel.GenerateReport(criteria, models, dataT))
                {
                    this.Close();
                    if (isNew) Logger.AddFileAction("создан");
                    else Logger.AddFileAction("изменен");

                    if (Excel.ReadXls(Data.filePath))
                    {
                        Data.ShowPareto();
                        frmChoose chooseForm = new frmChoose();
                        chooseForm.ShowDialog();
                    }

                }
            }
            else
                MessageBox.Show("Произошла ошибка при записи данных.\nУбедитесь, что в таблице присутствуют только числа.");
        }
    }
}
