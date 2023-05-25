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
    public partial class add_customers : Form
    {
        public add_customers()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
        private void add_customer()
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show(" enter info..");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into customers (ctm_name,ctm_ssd,ctm_phone,e_mail,ctm_gender) values (@name,@ssd,@phone,@email,@gender)", con);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ssd", textBox1.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox5.Text);
                    cmd.Parameters.AddWithValue("@email",textBox3.Text );
                    cmd.Parameters.AddWithValue("@gender", comboBox1.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("customer added");
                    con.Close();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_customer();
        }
    }
}
