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
    public partial class AddStudent : Form
    {
         SqlConnection conn;
        SqlDataAdapter da;
        SqlCommand cmd;
        public AddStudent()
        {
            InitializeComponent();
        }


       
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            welcome obj2 = new welcome();
            obj2.ShowDialog();
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtfee.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtfee.Text = txtfee.Text.Remove(txtfee.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (Double.Parse(txtfee.Text) < 0)
            //{
            //    MessageBox.Show("Fee Must Be Greater Than Zero");
            //}
            conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True");
            try
            {
                 conn.Open();
                string query = "INSERT INTO Students VALUES(@StudentId,@Name,@Address,@PhoneNo,@Email,@Program,@Fees,@username,@feestatus)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId",Int32.Parse(txtid.Text.ToString()));
                cmd.Parameters.AddWithValue("@Name",txtname.Text.ToString());
                cmd.Parameters.AddWithValue("@Address",txtaddress.Text.ToString());
                cmd.Parameters.AddWithValue("@PhoneNo",txtcell.Text.ToString());
                cmd.Parameters.AddWithValue("@Email",txtEmail.Text.ToString());
                cmd.Parameters.AddWithValue("@Program",txtprogram.Text.ToString());
                cmd.Parameters.AddWithValue("@Fees",double.Parse(txtfee.Text.ToString()));
                cmd.Parameters.AddWithValue("@username",txtusrname.Text.ToString());
                cmd.Parameters.AddWithValue("@feestatus", comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Account has been Created");
               
            }
            catch (Exception ex)
            { 
              //  MessageBox.Show(ex.ToString());
                MessageBox.Show("Please Enter All Field Values");
            }

        }       

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtid.Clear();
            txtusrname.Clear();
            txtname.Clear();
            txtprogram.Clear();
            txtaddress.Clear();
            txtEmail.Clear();
            txtcell.Clear();
            txtfee.Clear();
            comboBox1.SelectedItem = string.Empty;
        }

       
        private void submissionfee_Load(object sender, EventArgs e)
        {
            
        }

        private void btnshowstudents_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
                using (conn = new SqlConnection(connString))
                {
                    string sqlQuery = "SELECT * from Students";
                    cmd = new SqlCommand(sqlQuery, conn);
                    da = new SqlDataAdapter(cmd);
                    DataTable studentdatabase = new DataTable();
                    da.Fill(studentdatabase);
                    dataGridView1.DataSource = new BindingSource(studentdatabase, null);
                   
                }
            }
            catch (SqlException ex)
            {
             //   MessageBox.Show(ex.ToString());
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void txtid_Leave(object sender, EventArgs e)
        {
           
        }
        private void txtfee_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtid.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtid.Text = txtid.Text.Remove(txtid.Text.Length - 1);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmail.Text.Length > 0)
            {

                if (!rEMail.IsMatch(txtEmail.Text))
                {

                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmail.SelectAll();

                    e.Cancel = true;

                }

            }

        }
        private void txtcell_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? true : false; // find keyChar from aschii table
        }

    }
}
