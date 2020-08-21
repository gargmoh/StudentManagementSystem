using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace studentfeemanagmentsystem
{
    public partial class viewreport : Form
    {
        SqlConnection conn;
        string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
        public viewreport()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            welcome obj11 = new welcome();
            obj11.ShowDialog();

        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            welcome obj11 = new welcome();
            obj11.ShowDialog();
        }

        

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            using (conn = new SqlConnection(connString))
            {
                string sqlQuery = "SELECT * from students";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable students = new DataTable();
                da.Fill(students);
                dataGridView1.DataSource = new BindingSource(students, null);                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MOHIT\Downloads\SMS-master\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
            using (conn = new SqlConnection(connString))
            {
                string query = "SELECT Id,name,Program,FeeStatus from students where FeeStatus='Paid'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable studentdatabase = new DataTable();
                da.Fill(studentdatabase);
                dataGridView1.DataSource = new BindingSource(studentdatabase, null);

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
          //  string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MOHIT\Downloads\SMS-master\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
            using (conn = new SqlConnection(connString))
            {
                string query = "SELECT  Id,name,Program,FeeStatus from students where FeeStatus='UnPaid'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable students = new DataTable();
                da.Fill(students);
                dataGridView1.DataSource = new BindingSource(students, null);

            }
        }

        private void jano_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
