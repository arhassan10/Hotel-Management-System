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
    public partial class select_room : Form
    {
        public select_room()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
        public void UseSelectedRow(DataGridViewRow selectedRow)
        {
            // Access the selected row and use its data as needed
            DataGridViewCell cell2 = selectedRow.Cells[0];
            DataGridViewCell cell = selectedRow.Cells[1];


            string cellValue = cell.Value.ToString();

            int cellValue2 = Convert.ToInt32(cell2.Value);

            label16.Text = cellValue;
            label14.Text = cellValue2.ToString();
        }


        private void select_room_Load_1(object sender, EventArgs e)
        {


        }
        private void select_room_Load(object sender, EventArgs e)
        {


        }

        private void s()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
            con.Open();
            using (con)
            {


                string query = "SELECT name_sr FROM ser";
                using (SqlCommand command = new SqlCommand(query, con))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read the data and add it to the ComboBox items
                        while (reader.Read())
                        {
                            string item = reader.GetString(0); // Assuming the column is of string type
                            comboBox4.Items.Add(item);
                        }
                    }
                }


            }
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            add_customers c = new add_customers();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)

        {

            if (textBox4.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show(" enter info..");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into contract (contract_id,dt_from,dt_to,res_period,customer,RM_ID,nots) values (@c,@f,@t,@p,@cs,@r,@no)", con);
                cmd.Parameters.AddWithValue("@c", textBox4.Text);
                cmd.Parameters.AddWithValue("@f", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@t", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@p", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@cs", Convert.ToInt32(label14.Text));
                cmd.Parameters.AddWithValue("@r", Convert.ToInt32(textBox5.Text));
                cmd.Parameters.AddWithValue("@no", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("conformation done....");
                con.Close();

            }
           SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
            con2.Open();
            using (con2)
            {


                string updateQuery = "UPDATE room SET room_av = @Value1 WHERE room_id = @ConditionValue";

                using (SqlCommand command = new SqlCommand(updateQuery, con2))
                {
                    // Replace the parameter values with the actual values you want to update
                    command.Parameters.AddWithValue("@Value1", "Not Available");
                 
                    command.Parameters.AddWithValue("@ConditionValue", Convert.ToInt32(textBox5.Text));

                    // Execute the query
                    command.ExecuteNonQuery();
                   
                }

            }
            con2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cust_search c = new cust_search();
            c.Show();
            this.Hide();


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {




        }

        private void button4_Click(object sender, EventArgs e)
        {

            int searchQuery = Convert.ToInt32(textBox5.Text);

            using (con)
            {
                con.Open();

                string queryString = "SELECT * FROM room WHERE room_id = @searchTerm";

                using (SqlCommand command = new SqlCommand(queryString, con))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchQuery);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read the data from the reader
                        while (reader.Read())
                        {

                            int selectedroom = reader.GetInt32(0); // Assuming the first column is the item ID
                            int roompric = reader.GetInt32(2); // Assuming the second column is the item name
                            label15.Text = roompric.ToString();
                            label20.Text = roompric.ToString();
                            label8.Text = "8.0";

                        }
                    }


                }
                con.Close();
            }
            s();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                label36.Text = textBox2.Text;
                label28.Text = "0.0";
                double r;
                double s;
                double tn;
                if (double.TryParse(textBox2.Text, out r) && double.TryParse(label11.Text, out s) && double.TryParse(label8.Text, out tn))
                 {
                    double total = r + s + (r * tn);
                    label30.Text = total.ToString();
                }
            
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
            

            ComboBox comboBox = (ComboBox)sender;
            string selectedItem = comboBox.SelectedItem.ToString();

            string searchQuery = selectedItem;
          

                using (con)
            {
                con.Open();

                string queryString = "SELECT * FROM ser WHERE name_sr = @searchTerm";

                using (SqlCommand command = new SqlCommand(queryString, con))
                {
                    command.Parameters.AddWithValue("@searchTerm", searchQuery);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read the data from the reader
                        while (reader.Read())
                        {


                            int roompric = reader.GetInt32(2); 
                            label11.Text = roompric.ToString();


                        }
                    }



                }

                con.Close();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
