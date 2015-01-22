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
    public partial class frmNewVote : Form
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
        private int prevMod;
        private int prevCrit;

        public frmNewVote()
        {
            InitializeComponent();
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
                        critName.Add(tbName);

                    }

                    btnCount.Visible = !btnCount.Visible;
                    txtCount.ReadOnly = !txtCount.ReadOnly;
                    btnSave.Visible = !btnSave.Visible;
                    int height = Math.Min(critCount * 40 + lblValue.Top + 140, 600);
                    btnSave.Size = new Size(200, 40);
                    btnSave.Location = new Point(lblName.Left, lblName.Top + (critCount + 1) * 40);
                    this.Size = new Size(this.Width, height);
                }

            }
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> alts = new List<string>();
            foreach (TextBox tb in critName)
            {
                alts.Add(tb.Text);
            }
            Excel.GenerateExpertTemplate(alts);
            this.Close();
        }

    }
}
