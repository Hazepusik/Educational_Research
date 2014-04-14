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
    public partial class frmValuesYQ : Form
    {
        public frmValuesYQ()
        {
            InitializeComponent();
        }

        private void btnYQ_Click(object sender, EventArgs e)
        {
            Electre.Y = (double)Yval.Value;
            Electre.Q = (double)Qval.Value;
            this.Dispose();
        }
    }
}
