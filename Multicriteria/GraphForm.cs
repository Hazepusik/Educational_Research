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
                    double[] cset = MathLib.Superiority.GetSet(Superiority.C);

                    foreach (double c in cset)
                    {
                        ybox.Items.Add(c.ToString());
                    }
                    ybox.SelectedIndex = 0;
                    qbox.Visible = false;
                    lblQ.Visible = false;
                    break;
                }
                case 2:
                {
                    double[] cset = MathLib.Electre.GetSet(Electre.C);
                    double[] dset = MathLib.Electre.GetSet(Electre.D);
                    foreach (double c in cset)
                    {
                        ybox.Items.Add(c.ToString());
                    }
                    foreach (double d in dset)
                    {
                        qbox.Items.Add(d.ToString());
                    }
                    ybox.SelectedIndex = 0;
                    qbox.SelectedIndex = dset.Length - 1;
                    break;
                }

        }
        }

      private class Item
      {
        public string Name;
        public double Value;
        public Item(string name, double value)
        {
            Name = name; Value = value;
        }
      }

        private void btnYQ_Click(object sender, EventArgs e)
        {
            switch (method)
            {
                case 1:
                    {
                        Visualization.ShowGraph(Data.models.Where(m => m.dominatedStatus == 0).ToArray(), MathLib.Superiority.GetGraphByIndexes(Superiority.C, Convert.ToDouble(ybox.SelectedItem)));
                        break;
                    }
                case 2:
                    {
                        Visualization.ShowGraph(Data.models.Where(m => m.dominatedStatus == 0).ToArray(), MathLib.Electre.GetGraphByIndexes(Electre.C, Electre.D, Convert.ToDouble(ybox.SelectedItem), Convert.ToDouble(qbox.SelectedItem)));
                        break;
                    }
            }
        }
    }
}
