using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace studentfeemanagmentsystem
{
    public partial class delete : Form
    {
        SqlConnection conn;
        public delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True");
                string query = ("DELETE FROM  students where id= " + Convert.ToInt32(textBox1.Text) + "");
                SqlCommand cmd= new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();                
                conn.Close();
                MessageBox.Show("Account has been Deleted");
            }

            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
                MessageBox.Show("Please Enter Student Id or Student Id doesn't Exist");
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
            using (conn = new SqlConnection(connString))
            {
                string sqlQuery = @"SELECT * from students";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable students = new DataTable();
                da.Fill(students);
                dataGridView1.DataSource = new BindingSource(students, null);
            }
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }

    }
}
