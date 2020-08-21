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
    public partial class update : Form
    {
        SqlConnection conn;    
        public update()
        {
            InitializeComponent();
        }
               
        private void button1_Click(object sender, EventArgs e)
        {
            welcome obj7 = new welcome();
            obj7.ShowDialog();
        }
        private void update_Load(object sender, EventArgs e)
        {
            int counter = 1;
            updateidtxt.Text = UpdateForm.sendid;
            updateidtxt.Enabled = false;
            if (counter == 1)
            {
                populateFields();
                counter++;
            }
            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
                   
             int id = Int32.Parse(updateidtxt.Text);
             conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True");
            try
            {
               
                conn.Open();              
                string query = "UPDATE STUDENTS SET program=@program,address=@address,phoneno=@phone,email=@email,Fees=@Fees,feestatus=@status where id="+id+"";

                SqlCommand cmd = new SqlCommand(query, conn);
             
                cmd.Parameters.AddWithValue("@program", updateprogrm.Text.ToString());
                cmd.Parameters.AddWithValue("@address", updateaddress.Text.ToString());              
                cmd.Parameters.AddWithValue("@email", updateemail.Text.ToString());
                cmd.Parameters.AddWithValue("@phone", updatephone.Text.ToString());
                cmd.Parameters.AddWithValue("@Fees", Convert.ToDouble(updatefees.Text.ToString()));
                cmd.Parameters.AddWithValue("@status",comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Account has been Updated");
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                MessageBox.Show("Please Fill All Field Values !");
            }

         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
                using (conn = new SqlConnection(connString))
                {
                    string sqlQuery = @"SELECT * FROM students";
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable studentdatabase = new DataTable();
                    da.Fill(studentdatabase);
                    dataGridView1.DataSource = new BindingSource(studentdatabase, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no students in  the system!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {                       
            updateprogrm.Clear();
            updateaddress.Clear();
            updateemail.Clear();
            updatephone.Clear();
            updatefees.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void populateFields()
        {
            int id = Int32.Parse(updateidtxt.Text);  
            string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                string sqlQuery = "SELECT program,address,phoneno,email,fees FROM students WHERE id="+id+"";
                SqlDataReader myReader = null;
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    updateprogrm.Text = (myReader["program"].ToString());
                    updateaddress.Text = (myReader["address"].ToString());
                    updateemail.Text = (myReader["email"].ToString());
                    updatephone.Text = (myReader["phoneno"].ToString());
                    updatefees.Text = (myReader["fees"].ToString());
                   
                }
                conn.Close();
            }

        }
        private void txtemail_Validating(object sender, CancelEventArgs e)
        {

            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (updateemail.Text.Length > 0)
            {

                if (!rEMail.IsMatch(updateemail.Text))
                {

                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    updateemail.SelectAll();

                    e.Cancel = true;

                }

            }

        }
        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? true : false; // find keyChar from aschii table
        }
       
        //private void updatefees_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(updatefees.Text, "[^0-9]"))
        //    {
        //        MessageBox.Show("Please enter only numbers.");
        //        updatefees.Text = updatefees.Text.Remove(updatefees.Text.Length - 1);
        //    }
        
        //}       
       
    }
}
