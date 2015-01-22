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
    public partial class frmMainExpert : Form
    {
        public frmMainExpert()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNewVote frm = new frmNewVote();
            frm.ShowDialog();
        }

        private void btnExisting_Click(object sender, EventArgs e)
        {
            frmManual frm = new frmManual();
            frm.ShowDialog();
        }
    }
}
