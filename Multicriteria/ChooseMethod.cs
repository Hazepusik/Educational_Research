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
    public partial class frmChoose : Form
    {
        public frmChoose()
        {
            InitializeComponent();
        }

        private void btnElectra_Click(object sender, EventArgs e)
        {
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> dominated = new List<int>();
            List<int> equal = new List<int>();
            List<int>[] output = new List<int>[2];
            output = MathLib.Domin.CalcDominated(Excel.table);
            dominated = output[0];
            equal = output[1];
            dominated.Reverse();
        }
    }
}
