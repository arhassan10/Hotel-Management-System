using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Havana
{
    public partial class reserve : Form
    {
        public reserve()
        {
            InitializeComponent();
        }

        private void reserve_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

     
      

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.BackColor = Color.OldLace;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {

            PictureBox p = (PictureBox)sender;
            p.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightCoral;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }


        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            check_out c = new check_out();
            c.Show();
            this.Hide();
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            boocking p = new boocking();
            p.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            room_config R = new room_config();
            R.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            serv s = new serv();
            s.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            c.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            report r = new report();
            r.Show();
            this.Hide();
        }
    }
}
