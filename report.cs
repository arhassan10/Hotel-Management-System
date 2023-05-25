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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
        
            con.Open();
            string quary = "select * from contract";
            SqlDataAdapter d = new SqlDataAdapter(quary, con);
            SqlCommandBuilder b = new SqlCommandBuilder(d);
            var d_s = new DataSet();
            d.Fill(d_s);
            dataGridView1.DataSource = d_s.Tables[0];
            con.Close();

        
    }

        private void hAVANAHOTELDataSet1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            report r = new report();
            r.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            reserve r = new reserve();
            r.Show();
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
    }
}
