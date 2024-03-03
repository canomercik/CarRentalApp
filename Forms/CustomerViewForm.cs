using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace SQL_Project.Forms
{
    public partial class CustomerViewForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private int? customerID;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public CustomerViewForm(int? customerID)
        {
            InitializeComponent();
            this.customerID = customerID;

            this.MouseDown += (s, e) => { dragging = true; startPoint = new Point(e.X, e.Y); };
            this.MouseUp += (s, e) => { dragging = false; };
            this.MouseMove += (s, e) =>
            {
                if (dragging)
                {
                    Point p = new Point(this.Location.X + e.X - startPoint.X, this.Location.Y + e.Y - startPoint.Y);
                    this.Location = p;
                }
            };
            PopulateCarList();
            WireUpEvents();
        }
        private void WireUpEvents()
        {
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker_ValueChanged;
        }
        private void PopulateCarList()
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Make, Model, Year, RentalRate FROM Vehicle " +
                       "WHERE AvailabilityStatus = 'Available';";  //HERE

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set and add items to the ListView
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Make"].ToString());
                            item.SubItems.Add(reader["Model"].ToString());
                            item.SubItems.Add(reader["Year"].ToString());
                            item.SubItems.Add(reader["RentalRate"].ToString());

                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)  // Make Reservation button
        {
            try
            {
                // Get selected car information from the ListView
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a car.");
                    return;
                }

                string make = listView1.SelectedItems[0].SubItems[0].Text;
                string model = listView1.SelectedItems[0].SubItems[1].Text;
                string year = listView1.SelectedItems[0].SubItems[2].Text;
                string rentalRate = listView1.SelectedItems[0].SubItems[3].Text;

                // Check if customerID is available
                if (!customerID.HasValue)
                {
                    MessageBox.Show("CustomerID is not available.");
                    return;
                }

                // Get selected dates from DateTimePickers
                string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                // Insert reservation into the Reservation table
                string insertQuery = "INSERT INTO Reservation (VehicleID, CustomerID, PickupDate, DropoffDate, ReservationStatus) " +
                                     "VALUES ((SELECT VehicleID FROM Vehicle WHERE Make = @Make AND Model = @Model AND Year = @Year AND RentalRate = @RentalRate), @CustomerID, @PickupDate, @DropoffDate, @ReservationStatus);";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Make", make);
                        command.Parameters.AddWithValue("@Model", model);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@RentalRate", decimal.Parse(rentalRate));
                        command.Parameters.AddWithValue("@CustomerID", customerID.Value);
                        command.Parameters.AddWithValue("@PickupDate", startDate);
                        command.Parameters.AddWithValue("@DropoffDate", endDate);
                        command.Parameters.AddWithValue("@ReservationStatus", "Pending");

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation made successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Reservation could not be made. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred: {ex.Message}");
            }
        }


        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterVehicleList();
        }

        private void FilterVehicleList()
        {
            try
            {
                string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                string query = "SELECT Make, Model, Year, RentalRate, AvailabilityStatus FROM Vehicle " +
                               "WHERE VehicleID NOT IN (" +
                               "   SELECT VehicleID FROM Reservation " +
                               "   WHERE ((PickupDate BETWEEN @PickupDate AND @DropoffDate) OR " +
                               "         (DropoffDate BETWEEN @PickupDate AND @DropoffDate)) AND" +
                               "         (ReservationStatus = 'Approved' OR " +
                               "         ReservationStatus = 'Pending' OR " +  //HERE
                               "         ReservationStatus = 'CarInCustomer') " +  //HERE
                               ");";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PickupDate", startDate);
                        command.Parameters.AddWithValue("@DropoffDate", endDate);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            listView1.Items.Clear(); // Clear existing items before adding new ones

                            // Loop through the result set and add items to the ListView
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["Make"].ToString());
                                item.SubItems.Add(reader["Model"].ToString());
                                item.SubItems.Add(reader["Year"].ToString());
                                item.SubItems.Add(reader["RentalRate"].ToString());

                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CancellationForm cancellationForm = new CancellationForm(customerID.Value);
            cancellationForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PenaltiesForm penaltiesForm = new PenaltiesForm(customerID.Value);
            penaltiesForm.ShowDialog();
            this.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            RentalHistoryForm rentalHistoryForm = new RentalHistoryForm(customerID.Value);
            rentalHistoryForm.ShowDialog();
            this.Show();
        }
    }
}
