using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Project.Forms
{
    public partial class PenaltiesForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        
        private int? customerID;

        public PenaltiesForm(int customerId)
        {
            InitializeComponent();
            this.customerID = customerId;
            PopulateLog();
        }
        private void PopulateLog()
        {
            listView1.Items.Clear();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetLateReturnPenalties", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add a parameter for the customer ID
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set and add items to the ListView
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["PenaltyID"].ToString());
                            item.SubItems.Add(reader["ReservationID"].ToString());
                            item.SubItems.Add(reader["LateReturnTimeStamp"].ToString());
                            item.SubItems.Add(reader["PenaltyAmount"].ToString());

                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }
    }
}
