using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPath.Text = " ";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse";
            ofd.Filter = "Excel Files|*.xlsx";
            ofd.InitialDirectory = @"C:\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = "" + ofd.FileName + "";
            }

            String name = "Items";
            String constr = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""", txtPath.Text);
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);
            gc1.DataSource = data;

        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
