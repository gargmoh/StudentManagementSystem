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
    public partial class UpdateForm : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
       
        public UpdateForm()
        {
            InitializeComponent();
        }
       
       
        public static string sendid = "";

        private void btnsrchupdate_Click(object sender, EventArgs e)
        {
            
            try
            {
                sendid = srchId.Text;
                int id = Int32.Parse(srchId.Text.ToString());

                string constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MY COURSES-4\PROG37721\Final-Project\studentfeemanagmentsystem\Students.mdf;Integrated Security=True";
                using (conn = new SqlConnection(constring))
                {
                    string sqlQuery = "SELECT id FROM students WHERE id=@id";
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@id", Int32.Parse(srchId.Text.ToString()));
                    da = new SqlDataAdapter(cmd);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //  If the record can be queried, it means passing verification, then open another form.  
                    if ((sdr.Read() == true))
                    {
                        update form = new update();
                        form.Show();
                        srchId.Text = string.Empty;
                      // this.Hide();
                    }
                    else
                    {

                        MessageBox.Show("No Record is Found !");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter Id !");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
                  
        
    }
  
       
    
}
