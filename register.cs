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
    public partial class register : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MOHIT\Downloads\SMS-master\studentfeemanagmentsystem\Students.mdf;Integrated Security=True");
            string username;
            string password;           

            username = usertxt.Text;
            password = passtxt.Text;

            try
            {
                conn.Open();
                string query = "INSERT INTO login VALUES(@username,@pass)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Account Has been Registered.");
                this.Close();
            }

            catch (Exception ex)
            {
            //    MessageBox.Show(ex.ToString());
                MessageBox.Show("Please Enter Values");
            }
            
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            usertxt.Clear();
            passtxt.Clear();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
