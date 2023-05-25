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
    public partial class room_config : Form
    {
        public room_config()
        {
            InitializeComponent();
            showing_rooms();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
        private void showing_rooms()
        {
            con.Open();
            string quary = "select * from room";
            SqlDataAdapter d = new SqlDataAdapter(quary, con);
            SqlCommandBuilder b = new SqlCommandBuilder(d);
            var d_s = new DataSet();
            d.Fill(d_s);
            dataGridView1.DataSource = d_s.Tables[0];
            con.Close();

        }
        private void edit_room()
        {

            if (textBox1.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show(" enter info..");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update room set room_id=@r_id,room_tyb=@r_tyb,room_price=@r_pr,room_av=av where room_id=@r_id ", con);
                    cmd.Parameters.AddWithValue("@r_id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@r_tyb", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@r_pr", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@av", comboBox3.SelectedItem);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("room Edit correctly");

                    con.Close();
                    showing_rooms();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }


        private void add_room()
        {
            if (textBox1.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show(" enter info..");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into room (room_id,room_tyb,room_price,room_av) values (@r_id,@r_tyb,@r_pr,@a)", con);
                    cmd.Parameters.AddWithValue("@r_id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@r_tyb", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@r_pr", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@a ", comboBox3.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("room added");

                    con.Close();
                    showing_rooms();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private Panel CreatePanel()
        {
            // Create a new panel
            Panel newPanel = new Panel();

            // Set panel properties
            // newPanel.Location = new System.Drawing.Point(10, 10);
            newPanel.Size = new System.Drawing.Size(119, 92);
            newPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));

            // Add controls to the panel (optional)
            Button button = new Button();
            newPanel.Controls.Add(button);
            button.BackgroundImage = global::Havana.Properties.Resources.home;
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button.Location = new System.Drawing.Point(0, 17);
            button.Size = new System.Drawing.Size(102, 75);
            button.TabIndex = 9;
            button.Text = "206";
            button.UseVisualStyleBackColor = true;

            // Return the created panel
            return newPanel;
        }

        private void delet_room()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            add_room();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit_room();
        }

        private void room_config_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            reserve r = new reserve();
            r.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            c.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            serv s = new serv();
            s.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            report r = new report();
            r.Show();
            this.Hide();
        }
    }
}
