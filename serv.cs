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
    public partial class serv : Form
    {
        public serv()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
        private void showing_ser()
        {
            con.Open();
            string quary = "select * from ser";
            SqlDataAdapter d = new SqlDataAdapter(quary, con);
            SqlCommandBuilder b = new SqlCommandBuilder(d);
            var d_s = new DataSet();
            d.Fill(d_s);
            dataGridView1.DataSource = d_s.Tables[0];
            con.Close();

        }
        private void serv_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void add_ser()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""||comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show(" enter info..");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ser (id_sr,name_sr,pric_sr,av_ser) values (@i,@n,@p,@a)", con);
                    cmd.Parameters.AddWithValue("@i", Convert.ToInt32( textBox1.Text));
                    cmd.Parameters.AddWithValue("@n", textBox2.Text);
                    cmd.Parameters.AddWithValue("@p",Convert.ToInt32( textBox3.Text));
                    cmd.Parameters.AddWithValue("@a ", comboBox3.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("service added ");

                    con.Close();
                   showing_ser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            add_ser();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            reserve s = new reserve();
            s.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            room_config r = new room_config();
            r.Show();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            report r = new report();
            r.Show();
            this.Hide();
        }
    }
}
