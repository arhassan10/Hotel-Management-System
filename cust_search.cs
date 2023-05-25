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
    public partial class cust_search : Form
    {
        public cust_search()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GBK15J4;Initial Catalog=HAVANA_HOTEL;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int searchQuery = Convert.ToInt32(textBox1.Text);

            using (con)
            {
                con.Open();

                string queryString = "SELECT * FROM customers WHERE ctm_ssd LIKE @searchTerm";

                using (SqlCommand command = new SqlCommand(queryString, con))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchQuery + "%");

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Set the DataTable as the DataSource for the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
              
                // Extract the desired data from the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Open the other form and pass the selected data
                select_room otherForm = new select_room();
                  otherForm.UseSelectedRow(selectedRow);
                   otherForm.Show();
                   this.Close();
            
        }
    }
}
