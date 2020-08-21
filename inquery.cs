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
    public partial class Search : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        public Search()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = 0;
                string program=srchProgram.Text.ToString();
                string constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
                using (conn = new SqlConnection(constring))
                {
                    string sqlQuery = "SELECT id,name,Program FROM students WHERE Program LIKE '"+program+ "%'" ;
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@program",program);
                    da = new SqlDataAdapter(cmd);
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
                MessageBox.Show("There are no students of this program !");
            }
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            welcome obj12 = new welcome();
            obj12.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsrchname_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = 0;
                string name = srchName.Text.ToString();
                string constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
                using (conn = new SqlConnection(constring))
                {
                    string sqlQuery = "SELECT id,name,Program FROM students WHERE name LIKE '"+name+"%'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@name",name);
                    da = new SqlDataAdapter(cmd);
                    DataTable students = new DataTable();                   
                    da.Fill(students);
                    counter = students.Rows.Count;
                    if (counter == 0)
                    {
                        MessageBox.Show("No Record is found");
                    }
                    else
                    {
                        dataGridView1.DataSource = new BindingSource(students, null);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no students !");
            }
        }
        
    }

   
}
