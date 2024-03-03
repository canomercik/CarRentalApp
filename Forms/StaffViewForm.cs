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

    public partial class StaffViewForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


        public StaffViewForm()
        {
            InitializeComponent();

            PopulateCarList();
            PopulateReservation();

            dataGridView1.RowValidated += dataGridView1_RowValidated;

            dataGridView1.Columns["VehicleID"].ReadOnly = true;
            dataGridView1.Columns["Make"].ReadOnly = true;
            dataGridView1.Columns["Model"].ReadOnly = true;
            dataGridView1.Columns["Year"].ReadOnly = true;
            dataGridView1.Columns["RentalRate"].ReadOnly = true;

        }
        private void PopulateCarList()
        {
            string query = "SELECT * FROM Vehicle";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Create a DataTable to hold the retrieved data
                        System.Data.DataTable dataTable = new System.Data.DataTable();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable with the data from the SQL Server database
                            adapter.Fill(dataTable);
                        }

                        // Set the DataSource of the DataGridView to the DataTable
                        dataGridView1.DataSource = dataTable;

                        if (dataGridView1.Columns.Contains("AvailabilityStatus"))
                        {
                            dataGridView1.Columns.Remove("AvailabilityStatus");
                        }

                        // Add DataGridViewComboBoxColumn
                        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                        comboBoxColumn.DataPropertyName = "AvailabilityStatus";
                        comboBoxColumn.HeaderText = "AvailabilityStatus";
                        comboBoxColumn.DataSource = GetAvailabilityStatusList();
                        comboBoxColumn.Name = "AvailabilityStatus";

                        // Add the ComboBox column to the DataGridView
                        dataGridView1.Columns.Add(comboBoxColumn);

                        // Set the DataSource of the DataGridView to the DataTable
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void PopulateReservation()
        {
            listView1.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Reservation WHERE ReservationStatus = 'Pending'";

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
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the modified column is "Name"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "AvailabilityStatus")
            {
                int recordID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VehicleID"].Value);
                string modifiedStatus = dataGridView1.Rows[e.RowIndex].Cells["AvailabilityStatus"].Value.ToString();

                // Update the database
                SaveModifiedStatusToDatabase(recordID, modifiedStatus);
            }
        }

        private void SaveModifiedStatusToDatabase(int recordID, string modifiedStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE Vehicle SET AvailabilityStatus = @ModifiedStatus WHERE VehicleID = @RecordID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ModifiedStatus", modifiedStatus);
                        command.Parameters.AddWithValue("@RecordID", recordID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating 'AvailabilityStatus' in the database: {ex.Message}");
                }
            }
        }
        private List<string> GetAvailabilityStatusList()
        {
            return new List<string> {"Available", "Unavailable", "Under Maintenance"};
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Show();
        } // Log Out Button

        private void button2_Click(object sender, EventArgs e) // Refresh Button
        {
            PopulateCarList();
            PopulateReservation();
        }

        private void button3_Click(object sender, EventArgs e)  //Approve
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int reservationID = int.Parse(selectedItem.SubItems[0].Text);

                // Update the ReservationStatus to "Approved" in the database
                UpdateReservationStatus(reservationID, "Approved");

                // Update the local ListView item
                selectedItem.SubItems[5].Text = "Approved";

                // Refresh the reservation list
                PopulateReservation();
            }
        }

        private void button4_Click(object sender, EventArgs e)  //Decline
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int reservationID = int.Parse(selectedItem.SubItems[0].Text);

                // Update the ReservationStatus to "Declined" in the database
                UpdateReservationStatus(reservationID, "Declined");

                // Update the local ListView item
                selectedItem.SubItems[5].Text = "Declined";

                // Refresh the reservation list
                PopulateReservation();
            }
        }


        private void UpdateReservationStatus(int reservationID, string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE Reservation SET ReservationStatus = @NewStatus WHERE ReservationID = @ReservationID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewStatus", newStatus);
                        command.Parameters.AddWithValue("@ReservationID", reservationID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating 'ReservationStatus' in the database: {ex.Message}");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckInOutForm checkInOutForm = new CheckInOutForm();
            checkInOutForm.ShowDialog();
            this.Show();
        }
    }
}
