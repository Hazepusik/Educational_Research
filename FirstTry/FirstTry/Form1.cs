using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml.Table;




/// <summary>
/// Creates the data table.
/// </summary>
/// <returns>DataTable</returns>
private static DataTable CreateDataTable()
{
    DataTable dt = new DataTable();
    for (int i = 0; i < 10; i++)
    {
        dt.Columns.Add(i.ToString());
    }
 
    for (int i = 0; i < 10; i++)
    {
        DataRow dr = dt.NewRow();
        foreach (DataColumn dc in dt.Columns)
        {
            dr[dc.ToString()] = i;
        }
 
        dt.Rows.Add(dr);
    }
    return dt;
}

namespace FirstTry
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateXls_Click(object sender, EventArgs e)
        {

        }

    }
}
