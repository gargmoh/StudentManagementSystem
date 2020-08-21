using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace studentfeemanagmentsystem
{
    public partial class Login : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        } 
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnlogin_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True");
            try
            {
                           
                string query = "Select * From login WHERE username=@user AND password=@pass";
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", loginusr.Text.ToString());
                cmd.Parameters.AddWithValue("@pass", loginpass.Text.ToString());
                 da = new SqlDataAdapter(cmd);
                DataSet ds=new DataSet();
                 da.Fill(ds);
                 SqlDataReader sdr = cmd.ExecuteReader();
                 //  If the record can be queried, it means passing verification, then open another form.  
                 if ((sdr.Read() == true))                
                     {
                         MessageBox.Show("The user is valid!");
                         this.Hide();
                         welcome obj10  = new welcome();
                         obj10.ShowDialog();
                         
                     }
                     else
                     {
                         MessageBox.Show("Username or Password is not correct !");
                     }
                 
                
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Username not found");
            }
        }

       
       
    }
}
