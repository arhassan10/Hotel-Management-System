using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Havana
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
          
            string username = textBox1.Text;
            string password =  textBox2.Text;
  
             if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password.ToString()))
          
            {
                MessageBox.Show("Username or password cannot be empty. Please try again.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
             else
             {
                //reserve re = new reserve();
                //Application.Run(re);
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
               

                using (con)
                {
                    string query = "SELECT * FROM login WHERE id = @username AND pass = @password";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        try
                        {
                            con.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reserve r = new reserve();
                                    r.Show();
                                    this.Hide();
                                }
                                else
                                {
                                   MessageBox.Show("Invalid username or password.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            
        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

       
    }
}
