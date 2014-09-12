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
    public partial class ResultForm : Form
    {
        private int method;
        public ResultForm(System.Tuple<string, double>[] scores, int meth)
        {
            InitializeComponent();
            string prev = "";
            int place = 1;
            int cnt = 1;
            method = meth;
            foreach (System.Tuple<string, double> score in scores)
            {
                Label no = new Label();
                no.Parent = this;
                no.Font = lblPls.Font;
                no.Location = new Point(lblPls.Location.X + 20, lblPls.Location.Y + 15 + cnt * 30);
                no.Text = place.ToString();

                Label mod = new Label();
                mod.Parent = this;
                mod.Font = lblMod.Font;
                mod.Location = new Point(lblMod.Location.X + 1, lblMod.Location.Y + 15 + cnt * 30);
                mod.Text = score.Item1;
                mod.Size = new Size(200, 25);

                Label sc = new Label();
                sc.Parent = this;
                sc.Font = lblSc.Font;
                sc.Location = new Point(lblSc.Location.X + 20, lblSc.Location.Y + 15 + cnt * 30);
                sc.Text = score.Item2.ToString();

                if (prev != score.Item2.ToString())
                {
                    place++;
                }
                cnt++;
            }

        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            //TODO: resizable
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
                case 3:
                    {
                        Excel.WriteIdealPoint();
                        break;
                    }
                case 4:
                    {
                        Excel.WriteConvolution();
                        break;
                    }
            }
            this.Close();
        }
    }
}
