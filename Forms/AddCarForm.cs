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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SQL_Project
{
    public partial class AddCarForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public AddCarForm()
        {
            InitializeComponent();
        }

        private void AddCarForm_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Combobox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }

            string make = textBox1.Text;
            string model = textBox2.Text;
            string year = comboBox2.Text;
            string rentalRate = textBox4.Text;
            string availabilityStatus = comboBox1.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlInsert = "INSERT INTO Vehicle (Make, Model, Year, RentalRate, AvailabilityStatus) " +
                                       "VALUES (@Make, @Model, @Year, @RentalRate, @AvailabilityStatus)";
                    using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@Make", make);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@RentalRate", rentalRate);
                        cmd.Parameters.AddWithValue("@AvailabilityStatus", availabilityStatus);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Adding successful!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Adding failed. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }


            }
        }
    }
}
