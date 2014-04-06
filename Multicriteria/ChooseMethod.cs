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
            btnElectra.Text = MathLib.Domin.fib(4).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> dominated = new List<int>();
            dominated = MathLib.Domin.ret(Excel.table);
        }
    }
}
