using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Multicriteria
{
    public partial class frmImportance : Form
    {
        public frmImportance()
        {
            InitializeComponent();
        }

        private void btnSaveImportance_Click(object sender, EventArgs e)
        {
            bool parsed = true;
            int sp = Superiority.importance;
            int el = Electre.importance;
            int cv = Convolution.importance;
            int ip = IdealPoint.importance;
            try
            {               
                sp = int.Parse(cbSP.SelectedItem.ToString());
                el = int.Parse(cbEL.SelectedItem.ToString());
                cv = int.Parse(cbCV.SelectedItem.ToString());
                ip = int.Parse(cbIP.SelectedItem.ToString());
            }
            catch
            {
                parsed = false;
            }
            if (parsed)
            {
            parsed &= Configuration.WriteConfiguration(
                        cbSP.SelectedItem.ToString(),
                        cbEL.SelectedItem.ToString(),
                        cbCV.SelectedItem.ToString(),
                        cbIP.SelectedItem.ToString());
            }
            if (parsed)
            {

                Superiority.importance = sp;
                Electre.importance = el;
                Convolution.importance = cv;
                IdealPoint.importance = ip;
                MessageBox.Show("Файл конфигурации успешно записан");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка в записи файла конфигурации");
            }

        }

        private void frmImportance_Load(object sender, EventArgs e)
        {
            cbSP.SelectedItem = Superiority.importance.ToString();
            cbEL.SelectedItem = Electre.importance.ToString();
            cbCV.SelectedItem = Convolution.importance.ToString();
            cbIP.SelectedItem = IdealPoint.importance.ToString();   
        }
    }
}
