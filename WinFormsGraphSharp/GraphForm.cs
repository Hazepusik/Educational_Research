using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphSharp.Sample;

namespace WinFormsGraphSharp
{
    public partial class GraphForm : Form
    {

        public GraphSharpControl GraphControl { get; set; }

        public GraphForm()
        {
            InitializeComponent();

            GraphControl = new GraphSharpControl();

            elementHost1.Child = GraphControl;
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void OpenFile(string fileName)
        {
            GraphControl.OpenFile(fileName);
        }

        private void OpenFile()
        {
            using (var dialog = new OpenFileDialog {Title = "Open GML file", Filter = "GML files|*.gml|All files|*.*"})
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OpenFile(dialog.FileName);
                }
            }
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void NewGraph()
        {
            GraphControl = new GraphSharpControl();

            elementHost1.Child = GraphControl;
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewGraph();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
