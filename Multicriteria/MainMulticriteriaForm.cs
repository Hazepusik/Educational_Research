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
    public partial class frmMainMulticriteria : Form
    {
        public frmMainMulticriteria()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();

            openFD.InitialDirectory = Directory.GetCurrentDirectory();
            openFD.Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
            openFD.FilterIndex = 1;
            openFD.RestoreDirectory = true;
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                if (Excel.ReadXls(openFD.FileName))
                {
                    //TODO: show filename
                    Data.filePath = openFD.FileName;

                    string messageBoxText = "Произвести изменения в загруженном файле?";
                    string caption = "Загрузка файла";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    Logger.AddFileAction("загружен");
                    switch (result)
                    {
                        case DialogResult.Yes:
                            frmInput inputForm = new frmInput(false);
                            inputForm.ShowDialog();
                            break;
                        case DialogResult.No:
                            Data.ShowPareto();
                            frmChoose chooseForm = new frmChoose();
                            chooseForm.ShowDialog();
                            break;
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            frmInput inputForm = new frmInput(true);
            inputForm.ShowDialog();
        }
    }
}
