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
    public partial class frmFill : Form
    {
        private int critCount; 
        private int modCount;
        private List<Criterion> criteria = new List<Criterion>();
        private List<Model> models = new List<Model>();
        private List<TextBox> critName = new List<TextBox>();
        private List<TextBox> modName = new List<TextBox>();
        private List<NumericUpDown> critValue = new List<NumericUpDown>();
        private bool critFilled;

        public frmFill()
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
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            if (!critFilled)
            {
                //TODO: resize form
                critName.Clear();
                critValue.Clear();
                this.Size = new Size(111, 111);
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
                    }
                    SwitchObjects();
                    lblTitle.Text = "Число критериев";
                }
            }
            else
            {
                //TODO: resize form
                modName.Clear();
                if (!int.TryParse(txtCount.Text, out modCount) || modCount==0)
                {
                    MessageBox.Show("Введите число больше нуля.");
                }
                //modCount = int.Parse(txtCount.Text);
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
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!critFilled)
            {
                for (int i = 0; i < critCount; ++i)
                {
                    criteria.Add(new Criterion(critName[i].Text, int.Parse(critValue[i].Value.ToString())));
                    critName[i].Dispose();
                    critValue[i].Dispose();
                }
                SwitchObjects();
                txtCount.Text = "";
                lblTitle.Text = "Введите число моделей";
                critFilled = true;
            }
            else
            {
                for (int i = 0; i < modCount; ++i)
                {
                    models.Add(new Model(modName[i].Text));
                    modName[i].Dispose();
                }
                this.Dispose();
                Excel.GenerateReport(criteria, models);
                MessageBox.Show("Теперь заполните таблицу");
            }
        }

        private void frmFill_Load(object sender, EventArgs e)
        {
            critFilled = false;
        }
    }
}
