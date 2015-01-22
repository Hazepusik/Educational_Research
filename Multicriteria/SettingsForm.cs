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
            int pr = Promethee.importance;
            try
            {               
                sp = int.Parse(cbSP.SelectedItem.ToString());
                el = int.Parse(cbEL.SelectedItem.ToString());
                cv = int.Parse(cbCV.SelectedItem.ToString());
                ip = int.Parse(cbIP.SelectedItem.ToString());
                pr = int.Parse(cbPR.SelectedItem.ToString());
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
                        cbIP.SelectedItem.ToString(),
                        cbPR.SelectedItem.ToString());
            }
            if (parsed)
            {

                Superiority.importance = sp;
                Electre.importance = el;
                Convolution.importance = cv;
                IdealPoint.importance = ip;
                Promethee.importance = pr;
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
            cbPR.SelectedItem = Promethee.importance.ToString();
            clbUsing.SetItemChecked(clbUsing.Items.IndexOf(Superiority.name), Superiority.use);
            clbUsing.SetItemChecked(clbUsing.Items.IndexOf(Electre.name), Electre.use);
            clbUsing.SetItemChecked(clbUsing.Items.IndexOf(Convolution.name), Convolution.use);
            clbUsing.SetItemChecked(clbUsing.Items.IndexOf(IdealPoint.name), IdealPoint.use);
            clbUsing.SetItemChecked(clbUsing.Items.IndexOf(Promethee.name), Promethee.use);
            rbF1.Checked = Promethee.func == 1;
            rbF2.Checked = Promethee.func == 2;
            rbF3.Checked = Promethee.func == 3;
            rbF4.Checked = Promethee.func == 4;
            rbF5.Checked = Promethee.func == 5;
            rbF6.Checked = Promethee.func == 6;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void clbUsing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUsing_Click(object sender, EventArgs e)
        {
            List<string> used = new List<string>();
            if (clbUsing.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите по меньшей мере один метод");
                return;
            }
            foreach (object itemChecked in clbUsing.CheckedItems)
            {
                used.Add(itemChecked.ToString());
            }

            if (Configuration.WriteConfiguration())
            {
                Superiority.use = used.Contains(Superiority.name);
                Electre.use = used.Contains(Electre.name);
                Convolution.use = used.Contains(Convolution.name);
                IdealPoint.use = used.Contains(IdealPoint.name);
                Promethee.use = used.Contains(Promethee.name);
                if (Configuration.WriteConfiguration())
                {
                    MessageBox.Show("Файл конфигурации успешно записан");
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Ошибка в записи файла конфигурации");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSavePromethee_Click(object sender, EventArgs e)
        {
            if (rbF1.Checked)
                Promethee.func = 1;
            if (rbF2.Checked)
                Promethee.func = 2;
            if (rbF3.Checked)
                Promethee.func = 3;
            if (rbF4.Checked)
                Promethee.func = 4;
            if (rbF5.Checked)
                Promethee.func = 5;
            if (rbF6.Checked)
                Promethee.func = 6;
            if (Configuration.WriteConfiguration())
            {
                MessageBox.Show("Файл конфигурации успешно записан");
                this.Close();
            }
            else 
            {
                MessageBox.Show("Ошибка в записи файла конфигурации");
            }          
        }
    }
}
