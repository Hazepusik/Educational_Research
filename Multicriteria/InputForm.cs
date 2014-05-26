using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public frmInput()
        {
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
                if (!int.TryParse(txtCount.Text, out critCount) || critCount == 0)
                {
                    MessageBox.Show("Введите число больше нуля.");
                }
                else
                {
                    for (int i = 0; i < critCount; ++i)
                    {
                        TextBox tbName = new TextBox(); 
                        tbName.Size = new Size(200, 30);
                        tbName.Parent = this;
                        tbName.Location = new Point(lblName.Left, lblName.Top + (i + 1) * 40);
                        critName.Add(tbName);

                        NumericUpDown nudValue = new NumericUpDown();
                        nudValue.Size = new Size(60, 30);
                        nudValue.Parent = this;
                        nudValue.Minimum = 1;
                        nudValue.Maximum = 100;
                        nudValue.Value = 100;
                        nudValue.Location = new Point(lblValue.Left, lblValue.Top + (i + 1) * 40);
                        critValue.Add(nudValue);

                        CheckBox cbRev = new CheckBox();
                        cbRev.Parent = this;
                        cbRev.Location = new Point(lblDiff.Left, lblDiff.Top + (i + 1) * 40-5);
                        cbRev.Size = new Size(150, 30);
                        cbRev.Text = "Оценивать реверсивно";
                        isRev.Add(cbRev);
                    }
                    SwitchObjects();
                    lblTitle.Text = "Число критериев";
                    int height = Math.Min(critCount * 40 + lblValue.Top + 100, 600);                    
                    this.Size = new Size(this.Width, height);
                }
            }
            else
            {
                modName.Clear();
                if (!int.TryParse(txtCount.Text, out modCount) || modCount==0)
                {
                    MessageBox.Show("Введите число больше нуля.");
                }
                else
                {
                    for (int i = 0; i < modCount; ++i)
                    {
                        TextBox tbName = new TextBox();
                        tbName.Size = new Size(200, 30);
                        tbName.Parent = this;
                        tbName.Location = new Point(lblName.Left, lblName.Top + (i + 1) * 40);
                        modName.Add(tbName);
                    }
                    SwitchObjects();
                    lblTitle.Text = "Число моделей";
                    lblValue.Visible = false;
                    lblDiff.Visible = false;
                    int height = Math.Min(modCount * 40 + lblValue.Top + 100, 600);
                    this.Size = new Size(this.Width, height);
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!critFilled)
            {
                //TODO: not empty names
                for (int i = 0; i < critCount; ++i)
                {
                    criteria.Add(new Criterion(critName[i].Text, int.Parse(critValue[i].Value.ToString()),isRev[i].Checked));
                    critName[i].Dispose();
                    critValue[i].Dispose();
                    isRev[i].Dispose();
                }
                SwitchObjects();
                txtCount.Text = "";
                lblTitle.Text = "Введите число моделей";
                critFilled = true;
                this.Size = new Size(this.Width, 100);
            }
            else
            {
                //TODO: not empty names
                for (int i = 0; i < modCount; ++i)
                {
                    models.Add(new Model(modName[i].Text));
                    modName[i].Dispose();
                }
                //this.Dispose();
                //Excel.GenerateReport(criteria, models);
                //MessageBox.Show("Теперь заполните таблицу");
                
                data.Parent = this;
                data.ColumnHeadersVisible = false;
                data.RowHeadersVisible = false;
                data.Columns.Add("first", "first");
                data.Rows.Add(models.Count+1);
                data.AllowUserToAddRows = false;
                data.AllowUserToOrderColumns = false;
                data.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
                data.Rows[0].Cells[0].ReadOnly = true;
                foreach (Criterion c in criteria)
                {
                    int col = data.Columns.Add(c.name, c.name);
                    data.Rows[0].Cells[col].Value = c.name;
                    data.Rows[0].Cells[col].ReadOnly = true;
                    data.Rows[0].Cells[col].Style.Font = new Font(data.Font, FontStyle.Bold);
                    data.Rows[0].Cells[col].Style.BackColor = Color.LightGray;
                    data.Columns[col].Width = 80;

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
            }
        }

        private void frmFill_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            critFilled = false;
            data.Visible = false;
            this.Size = new Size(this.Width, 100);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DataTable d = (DataTable)data.DataSource;
            DataTable dtFromGrid = new DataTable();
            dtFromGrid = data.DataSource as DataTable;
            Excel.GenerateReport(criteria, models, data);
        }
    }
}
