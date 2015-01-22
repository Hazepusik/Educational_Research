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
    public partial class frmManual : Form
    {
        public frmManual()
        {
            InitializeComponent();
            lbModels.Visible = !true;
            button2.Visible = !true;
            button3.Visible = !true;
            btnSvExp.Visible = !true;

            List<string> votes = Expert.GetVotes();

            if (votes.Count == 0)
            {
                MessageBox.Show("Ни одного голосования не найдено");
                this.Close();
            }

            foreach (string vote in votes)
                cbVote.Items.Add(vote);
            cbVote.SelectedIndex = 0;

            lbModels.MouseDown += new MouseEventHandler(listBox1_MouseDown);
            lbModels.DragDrop += new DragEventHandler(listBox1_DragDrop);
            lbModels.DragOver += new DragEventHandler(listBox1_DragOver);
            lbModels.AllowDrop = true;
            /*foreach (Model m in Data.models)
            {
                this.lbModels.Items.Add(m.name);
            }*/
            //lbModels.Height = votes.Count() * 28;

            lbModels.Visible = !true;
            button2.Visible = !true;
            button3.Visible = !true;
            btnSvExp.Visible = !true;
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lbModels.SelectedItem == null) return;
            this.lbModels.DoDragDrop(this.lbModels.SelectedItem, DragDropEffects.Move);
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lbModels.PointToClient(new Point(e.X, e.Y));
            int index = this.lbModels.IndexFromPoint(point);
            if (index < 0) index = this.lbModels.Items.Count - 1;
            object data = e.Data.GetData(typeof(string));
            this.lbModels.Items.Remove(data);
            this.lbModels.Items.Insert(index, data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 20; i++)
            {
                this.lbModels.Items.Add(DateTime.Now.AddDays(i));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // An item must be selected
            if (lbModels.SelectedItems.Count > 0)
            {
                object selected = lbModels.SelectedItem;
                int indx = lbModels.Items.IndexOf(selected);
                int totl = lbModels.Items.Count;
                // If the item is right at the top, throw it right down to the bottom
                if (indx == 0)
                {
                    lbModels.Items.Remove(selected);
                    lbModels.Items.Insert(totl - 1, selected);
                    lbModels.SetSelected(totl - 1, true);
                }
                // To move the selected item upwards in the listbox
                else
                {
                    lbModels.Items.Remove(selected);
                    lbModels.Items.Insert(indx - 1, selected);
                    lbModels.SetSelected(indx - 1, true);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // An item must be selected
            if (lbModels.SelectedItems.Count > 0)
            {
                object selected = lbModels.SelectedItem;
                int indx = lbModels.Items.IndexOf(selected);
                int totl = lbModels.Items.Count;
                // If the item is last in the listbox, move it all the way to the top
                if (indx == totl - 1)
                {
                    lbModels.Items.Remove(selected);
                    lbModels.Items.Insert(0, selected);
                    lbModels.SetSelected(0, true);
                }
                // To move the selected item downwards in the listbox
                else
                {
                    lbModels.Items.Remove(selected);
                    lbModels.Items.Insert(indx + 1, selected);
                    lbModels.SetSelected(indx + 1, true);
                }
            }
        
        }

        private void btnSvExp_Click(object sender, EventArgs e)
        {
            Expert.choise = new List<string>();
            for (int i = 0; i < lbModels.Items.Count; ++i)
            {
                Expert.choise.Add(lbModels.Items[i].ToString());
            }
            Excel.WriteExpert();
            MessageBox.Show("Ваш результат успешно сохранен");
            this.Close();
        }

        private void btnChose_Click(object sender, EventArgs e)
        {
            lbModels.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            btnSvExp.Visible = true;
            cbVote.Enabled = false;
            btnChose.Visible = false;
            if (!Expert.LoadChoise(cbVote.SelectedItem.ToString()))
            {
                this.Close();
            }
            foreach (string c in Expert.choise)
            {
                this.lbModels.Items.Add(c);
            }
            lbModels.Height = Expert.choise.Count() * 28;
        }
    }
}
