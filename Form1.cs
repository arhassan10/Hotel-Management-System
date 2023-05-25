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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
            con.Open();
            string quary = "select * from customers";
            SqlDataAdapter d = new SqlDataAdapter(quary, con);
            SqlCommandBuilder b = new SqlCommandBuilder(d);
            var d_s = new DataSet();
            d.Fill(d_s);
            dataGridView1.DataSource = d_s.Tables[0];
            con.Close();
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
