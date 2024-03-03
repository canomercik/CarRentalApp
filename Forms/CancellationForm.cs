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
    public partial class CancellationForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        private int? customerID;
        public CancellationForm(int customerId)
        {
            InitializeComponent();
            this.customerID = customerId;
            PopulateLog();
        }
        private void PopulateLog()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Modify the query to include a WHERE clause for the specific customer ID
                string query = "SELECT * FROM Reservation WHERE (CustomerID = @CustomerID) AND (ReservationStatus = 'Approved' OR ReservationStatus = 'Pending')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add a parameter for the customer ID
                    command.Parameters.AddWithValue("@CustomerID", customerID);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                int reservationID = int.Parse(selectedRow.Text); // Assuming ReservationID is stored as text in the first column

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update the ReservationStatus to 'Cancelled' for the selected ReservationID
                    string updateQuery = "UPDATE Reservation SET ReservationStatus = 'Cancelled' WHERE ReservationID = @ReservationID";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@ReservationID", reservationID);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Refresh the list view after the update
                    listView1.Items.Clear();
                    PopulateLog();
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to cancel.", "No Reservation Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                int reservationID = int.Parse(selectedRow.Text); // Assuming ReservationID is stored as text in the first column

                DateTime newPickupDate = dateTimePicker1.Value;
                DateTime newDropoffDate = dateTimePicker2.Value;

                // Check for overlapping reservations for the same vehicle
                if (!IsOverlap(reservationID, newPickupDate, newDropoffDate))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Update the PickupDate and DropoffDate for the selected ReservationID
                        string updateQuery = "UPDATE Reservation SET PickupDate = @PickupDate, DropoffDate = @DropoffDate WHERE ReservationID = @ReservationID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@ReservationID", reservationID);
                            updateCommand.Parameters.AddWithValue("@PickupDate", newPickupDate);
                            updateCommand.Parameters.AddWithValue("@DropoffDate", newDropoffDate);
                            updateCommand.ExecuteNonQuery();
                        }

                        // Refresh the list view after the update
                        listView1.Items.Clear();
                        PopulateLog();
                    }
                }
                else
                {
                    MessageBox.Show("The selected dates overlap with an existing reservation for the same vehicle.", "Date Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to update.", "No Reservation Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsOverlap(int reservationID, DateTime newPickupDate, DateTime newDropoffDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check for overlapping reservations with 'Approved' or 'CarInCustomer' status for the same vehicle and different ReservationID
                string overlapQuery = "SELECT COUNT(*) FROM Reservation " +
                                      "WHERE VehicleID = (SELECT VehicleID FROM Reservation WHERE ReservationID = @ReservationID) " +
                                      "AND ReservationID <> @ReservationID " +
                                      "AND ReservationStatus IN ('Approved', 'CarInCustomer') " +
                                      "AND ((PickupDate BETWEEN @NewPickupDate AND @NewDropoffDate) OR (DropoffDate BETWEEN @NewPickupDate AND @NewDropoffDate))";

                using (SqlCommand overlapCommand = new SqlCommand(overlapQuery, connection))
                {
                    overlapCommand.Parameters.AddWithValue("@ReservationID", reservationID);
                    overlapCommand.Parameters.AddWithValue("@NewPickupDate", newPickupDate);
                    overlapCommand.Parameters.AddWithValue("@NewDropoffDate", newDropoffDate);

                    int overlappingReservationsCount = (int)overlapCommand.ExecuteScalar();

                    return overlappingReservationsCount > 0;
                }
            }
        }
    }
}
