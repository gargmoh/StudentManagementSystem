using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace studentfeemanagmentsystem
{
    public partial class searchstudent : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public searchstudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = 0;
                string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
                using (conn = new SqlConnection(connString))
                {
                    string sqlQuery = "SELECT * FROM Students where id=" + Int32.Parse(textBox1.Text) + "";
                    cmd = new SqlCommand(sqlQuery, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable student = new DataTable();
                    da.Fill(student);
                    counter = student.Rows.Count;
                    if (counter == 0)
                    {
                        MessageBox.Show("No Record is found");
                    }
                    else
                    {
                        dataGridView1.DataSource = new BindingSource(student, null);
                    }
                }
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
                MessageBox.Show("Please Enter ID!");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsrchfields_Click(object sender, EventArgs e)
        {
            Search obj = new Search();
            obj.ShowDialog();
        }







    }
}