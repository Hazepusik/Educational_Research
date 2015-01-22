using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using MathLib;


namespace Multicriteria
{ 
    public partial class frmMain : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="frmMain"/> class.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            frmMainMulticriteria frm = new frmMainMulticriteria();
            frm.ShowDialog();
        }



        private void Import_Click(object sender, EventArgs e)
        {
            frmMainExpert frm = new frmMainExpert();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Logger.Init();
            Configuration.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMainExpert frm = new frmMainExpert();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
    }
}
