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
        public frmGraph()
        {
            InitializeComponent();
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
            Visualization.ShowGraph(Data.models.Where(m => m.dominatedStatus == 0).ToArray(), MathLib.Electre.GetGraphByIndexes(Electre.C, Electre.D, Convert.ToDouble(ybox.SelectedItem), Convert.ToDouble(qbox.SelectedItem)));
        }
    }
}
