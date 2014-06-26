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
    public partial class frmGraph : Form
    {
        private int method;
        public frmGraph(int meth)
        {
            InitializeComponent();
            method = meth;
            switch (method)
            {
                case 1:
                {
                    double[] cset = MathLib.Common.GetSet(Superiority.C);
                    lblCD.Text = "Задайте уровень согласия";
                    foreach (double c in cset)
                    {
                        //ybox.Items.Add(Math.Round(c, 4).ToString());
                        ybox.Items.Add (new Item(Math.Round(c, 4).ToString(), c));
                    }
                    ybox.SelectedIndex = 0;
                    qbox.Visible = false;
                    lblQ.Visible = false;
                    break;
                }
                case 2:
                {
                    double[] cset = MathLib.Common.GetSet(Electre.C);
                    double[] dset = MathLib.Common.GetSet(Electre.D);
                    foreach (double c in cset)
                    {
                        ybox.Items.Add(new Item(Math.Round(c, 4).ToString(), c));
                    }
                    foreach (double d in dset)
                    {
                        qbox.Items.Add(new Item(Math.Round(d, 4).ToString(), d));
                    }
                    ybox.SelectedIndex = 0;
                    qbox.SelectedIndex = dset.Length - 1;
                    break;
                }

        }
        }

      private class Item
      {
        public string Text;
        public double Value;
        public Item(string text, double value)
        {
            Text = text; Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
      }

        private void btnYQ_Click(object sender, EventArgs e)
        {
            switch (method)
            {
                case 1:
                    {
                        double curC = Convert.ToDouble((ybox.SelectedItem as Item).Value);
                        Visualization.ShowGraph(Data.models.Where(m => m.dominatedStatus == 0).ToArray(), MathLib.Superiority.GetGraphByIndexes(Superiority.C, curC));
                        Logger.AddGraphAction(new double[1] {curC});
                        break;
                    }
                case 2:
                    {
                        double curC = Convert.ToDouble((ybox.SelectedItem as Item).Value);
                        double curD = Convert.ToDouble((qbox.SelectedItem as Item).Value);
                        Visualization.ShowGraph(Data.models.Where(m => m.dominatedStatus == 0).ToArray(), MathLib.Electre.GetGraphByIndexes(Electre.C, Electre.D, curC, curD));
                        Logger.AddGraphAction(new double[2] { curC, curD });
                        break;
                    }
            }
        }
    }
}
