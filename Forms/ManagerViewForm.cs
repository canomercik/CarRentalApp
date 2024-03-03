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
    public partial class ManagerViewForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public ManagerViewForm()
        {
            InitializeComponent();

            PopulateCarList();
            PopulateStaffList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddCarForm addcarForm = new AddCarForm();
            addcarForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            AddStaffForm addstaffForm = new AddStaffForm();
            addstaffForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Show();
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void PopulateStaffList()
        {
            string query = "SELECT * FROM Staff";

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
                        dataGridView2.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e) // Refresh button
        {
            PopulateCarList();
            PopulateStaffList();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            CheckInOutLogForm checkInOutLogForm = new CheckInOutLogForm();
            checkInOutLogForm.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PenaltiesLogForm penaltiesLogForm = new PenaltiesLogForm();
            penaltiesLogForm.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MaintenanceLogForm maintenanceLogForm = new MaintenanceLogForm();
            maintenanceLogForm.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReservationLogForm reservationLogForm = new ReservationLogForm();
            reservationLogForm.ShowDialog();
            this.Show();
        }
    }
}
