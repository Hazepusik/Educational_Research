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
            //frmFill fillForm = new frmFill();
            //fillForm.ShowDialog();
            frmInput f = new frmInput();
            f.ShowDialog();
        }



        private void Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();

            openFD.InitialDirectory = Directory.GetCurrentDirectory();
            openFD.Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
            openFD.FilterIndex = 1;
            openFD.RestoreDirectory = true;
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                //TODO: check data
                if (Excel.ReadXls(openFD.FileName))
                {
                    //TODO: show filename
                    frmChoose chooseForm = new frmChoose();
                    chooseForm.ShowDialog();
                }
            }
        }

    }
}
