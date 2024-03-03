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
    public partial class CheckInOutForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public CheckInOutForm()
        {
            InitializeComponent();
            ReservationLog();
            CheckInOutLog();
        }
        private void ReservationLog()
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Reservation WHERE (ReservationStatus = 'Approved' OR ReservationStatus = 'CarInCustomer' OR ReservationStatus = 'IsUsed') ";

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
        private void CheckInOutLog()
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM CheckInOut";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set and add items to the ListView
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["CheckInOutID"].ToString());
                            item.SubItems.Add(reader["ReservationID"].ToString());
                            item.SubItems.Add(reader["StaffID"].ToString());
                            item.SubItems.Add(reader["CheckInTimestamp"].ToString());
                            item.SubItems.Add(reader["CheckOutTimestamp"].ToString());

                            listView2.Items.Add(item);
                        }
                    }
                }
            }
        }
        private DateTime GetDropoffDate(string reservationID)
        {
            // Retrieve the DropoffDate from the Reservation table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DropoffDate FROM Reservation WHERE ReservationID = @ReservationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReservationID", reservationID);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDateTime(result);
                    }
                }
            }

            return DateTime.MinValue; // Return a default value if DropoffDate is not found
        }
        private decimal CalculatePenaltyAmount(TimeSpan lateDuration)
        {
            // Replace this with your own logic to calculate penalty amount
            // For example, you might charge a fixed amount per hour of delay
            decimal penaltyPerHour = 10; // Change this value according to your business rules

            decimal penaltyAmount = (decimal)lateDuration.TotalHours * penaltyPerHour;

            return penaltyAmount;
        }
        private int GetCustomerID(string reservationID)
        {
            // Retrieve the CustomerID from the Reservation table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT CustomerID FROM Reservation WHERE ReservationID = @ReservationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReservationID", reservationID);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return 0; // Return a default value if CustomerID is not found
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in listView1
            if (listView1.SelectedItems.Count > 0)
            {
                string reservationID = listView1.SelectedItems[0].SubItems[0].Text;
                string reservationStatus = listView1.SelectedItems[0].SubItems[5].Text; // Assuming ReservationStatus is in the sixth column (index 5)

                if (reservationStatus == "CarInCustomer")
                {
                    MessageBox.Show("This reservation is already checked in.");
                    return;
                }
                if (reservationStatus == "IsUsed")
                {
                    MessageBox.Show("This reservation is already used.");
                    return;
                }

                DateTime currentDateTime = DateTime.Now;
                string currentTimestamp = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Insert a record into CheckInOut table
                    string insertCheckInOutQuery = "INSERT INTO CheckInOut (ReservationID, CheckInTimestamp) VALUES (@ReservationID, @CheckInTimestamp)";
                    using (SqlCommand insertCommand = new SqlCommand(insertCheckInOutQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@ReservationID", reservationID);
                        insertCommand.Parameters.AddWithValue("@CheckInTimestamp", currentTimestamp);

                        int rowsAffectedInsert = insertCommand.ExecuteNonQuery();

                        if (rowsAffectedInsert <= 0)
                        {
                            MessageBox.Show("Failed to record check-in.");
                            return;
                        }
                    }

                    // Step 2: Update ReservationStatus in Reservation table
                    string updateReservationQuery = "UPDATE Reservation SET ReservationStatus = 'CarInCustomer' WHERE ReservationID = @ReservationID";
                    using (SqlCommand updateCommand = new SqlCommand(updateReservationQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@ReservationID", reservationID);

                        int rowsAffectedUpdate = updateCommand.ExecuteNonQuery();

                        if (rowsAffectedUpdate > 0)
                        {
                            MessageBox.Show("Check-in recorded successfully.");
                            listView1.Items.Clear();
                            listView2.Items.Clear();
                            ReservationLog();
                            CheckInOutLog();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update ReservationStatus.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation from the list.");
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string checkInOutID = listView2.SelectedItems[0].SubItems[0].Text;
                string reservationID = listView2.SelectedItems[0].SubItems[1].Text; // Assuming ReservationID is in the second column (index 1)
                string checkoutTimestamp = listView2.SelectedItems[0].SubItems[4].Text; // Assuming CheckOutTimestamp is in the fifth column (index 4)

                // Check if checkoutTimestamp is already set
                if (!string.IsNullOrEmpty(checkoutTimestamp))
                {
                    MessageBox.Show("Checkout is already made for this entry.");
                    return;
                }

                DateTime currentDateTime = DateTime.Now;
                string currentTimestamp = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Update CheckoutTimestamp in CheckInOut table
                    string updateCheckInOutQuery = "UPDATE CheckInOut SET CheckOutTimestamp = @CheckOutTimestamp WHERE CheckInOutID = @CheckInOutID AND CheckOutTimestamp IS NULL";
                    using (SqlCommand updateCommand = new SqlCommand(updateCheckInOutQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@CheckInOutID", checkInOutID);
                        updateCommand.Parameters.AddWithValue("@CheckOutTimestamp", currentTimestamp);

                        int rowsAffectedUpdate = updateCommand.ExecuteNonQuery();

                        if (rowsAffectedUpdate > 0)
                        {
                            // Step 2: Update ReservationStatus in Reservation table
                            string updateReservationQuery = "UPDATE Reservation SET ReservationStatus = 'IsUsed' WHERE ReservationID = @ReservationID";
                            using (SqlCommand updateReservationCommand = new SqlCommand(updateReservationQuery, connection))
                            {
                                updateReservationCommand.Parameters.AddWithValue("@ReservationID", reservationID);

                                int rowsAffectedUpdateReservation = updateReservationCommand.ExecuteNonQuery();

                                if (rowsAffectedUpdateReservation > 0)
                                {
                                    // Step 3: Check for late return and insert penalty if applicable
                                    DateTime dropoffDate = GetDropoffDate(reservationID);

                                    if (dropoffDate < currentDateTime)
                                    {
                                        TimeSpan lateDuration = currentDateTime - dropoffDate;
                                        decimal penaltyAmount = CalculatePenaltyAmount(lateDuration);

                                        // Step 4: Get CustomerID from Reservation table
                                        int customerID = GetCustomerID(reservationID);

                                        // Step 5: Insert penalty into LateReturnPenalty table
                                        string insertPenaltyQuery = "INSERT INTO LateReturnPenalty (CustomerID, ReservationID, LateReturnTimestamp, PenaltyAmount) VALUES (@CustomerID, @ReservationID, @LateReturnTimestamp, @PenaltyAmount)";
                                        using (SqlCommand insertPenaltyCommand = new SqlCommand(insertPenaltyQuery, connection))
                                        {
                                            insertPenaltyCommand.Parameters.AddWithValue("@CustomerID", customerID);
                                            insertPenaltyCommand.Parameters.AddWithValue("@ReservationID", reservationID);
                                            insertPenaltyCommand.Parameters.AddWithValue("@LateReturnTimestamp", currentTimestamp);
                                            insertPenaltyCommand.Parameters.AddWithValue("@PenaltyAmount", penaltyAmount);

                                            int rowsAffectedInsertPenalty = insertPenaltyCommand.ExecuteNonQuery();

                                            if (rowsAffectedInsertPenalty > 0)
                                            {
                                                MessageBox.Show($"Checkout recorded successfully. Reservation status updated to 'IsUsed'. Penalty of {penaltyAmount:C} applied for late return.");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Failed to insert LateReturnPenalty.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Checkout recorded successfully. Reservation status updated to 'IsUsed'.");
                                    }

                                    listView1.Items.Clear();
                                    listView2.Items.Clear();
                                    ReservationLog();
                                    CheckInOutLog();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update ReservationStatus.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to update CheckoutTimestamp. Make sure checkout time is not already recorded or check-in time is missing.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an entry from the list.");
            }
        }
    }
}
