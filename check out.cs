﻿using System;
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
    public partial class check_out : Form
    {
        public check_out()
        {
            InitializeComponent();
        }
        private void Panel_DoubleClick(object sender, EventArgs e)
        {
            select_room s = new select_room();
            Panel PANAL = (Panel)sender;

            s.Show();
            s.Text = PANAL.Tag.ToString();
        }
        public int name;
        private void check_out_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
           
            using (con)
            {
                // Open the connection
                con.Open();

                // SQL query to select all data from a table
                string query = "SELECT * FROM room where room_av= @c";


                // Create a SqlCommand object with the query and connection
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@c", "Not Available");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the rows in the result set
                        while (reader.Read())
                        {
                            // Assuming you have a column named 'Name' in your table
                            name = reader.GetInt32(reader.GetOrdinal("room_id"));

                          //  this.pp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            // Create a button for each data row
                            Panel p = new Panel();
                            p.Size = new System.Drawing.Size(119, 92);
                            p.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            Button b1 = new Button();
                            b1.BackgroundImage = global::Havana.Properties.Resources.home;
                            b1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            b1.Location = new System.Drawing.Point(0, 17);
                            b1.Size = new System.Drawing.Size(102, 75);

                            b1.Text = name.ToString();
                            b1.UseVisualStyleBackColor = true;
                            p.Controls.Add(b1);
                            p.Tag = name;
                            p.DoubleClick += Panel_DoubleClick;

                            // Add the button to the panel
                            flowLayoutPanel1.Controls.Add(p);
                            // con.Close();
                        }
                    }
                }
            }
        
    }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            reserve r = new reserve();
            r.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            room_config h = new room_config();
            h.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            serv s = new serv();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            check_out c = new check_out();
            c.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            report r = new report();
            r.Show();
            this.Hide();
        }
    }
}
