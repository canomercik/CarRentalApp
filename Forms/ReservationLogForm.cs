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
    public partial class ReservationLogForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public ReservationLogForm()
        {
            InitializeComponent();
            PopulateLog();
        }
        private void PopulateLog()
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Reservation";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set and add items to the ListView
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["ReservationID"].ToString());
                            item.SubItems.Add(reader["CustomerID"].ToString());
                            item.SubItems.Add(reader["VehicleID"].ToString());
                            item.SubItems.Add(reader["PickupDate"].ToString());
                            item.SubItems.Add(reader["DropoffDate"].ToString());
                            item.SubItems.Add(reader["ReservationStatus"].ToString());

                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }
    }
}
