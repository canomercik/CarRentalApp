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

namespace SQL_Project
{
    public partial class AddStaffForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public AddStaffForm()
        {
            InitializeComponent();
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
            if (string.IsNullOrWhiteSpace(textBox3.Text))
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
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }

            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string email = textBox3.Text;
            string phone = textBox4.Text;
            string username = textBox5.Text;
            string password = textBox6.Text;
            string managerID = textBox7.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlInsertAuthenticationInfo = "INSERT INTO [User] (Username, Password, Role) " +
                                     "VALUES (@Username, @Password, @Role)";
                    using (SqlCommand cmdAuthenticationInfo = new SqlCommand(sqlInsertAuthenticationInfo, connection))
                    {
                        cmdAuthenticationInfo.Parameters.AddWithValue("@Username", username);
                        cmdAuthenticationInfo.Parameters.AddWithValue("@Password", password);
                        cmdAuthenticationInfo.Parameters.AddWithValue("@Role", "Staff");

                        int rowsAffectedAuthenticationInfo = cmdAuthenticationInfo.ExecuteNonQuery();

                        if (rowsAffectedAuthenticationInfo > 0)
                        {
                            MessageBox.Show("Registration successful!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Authentication info insertion failed. Please try again.");
                        }
                    }

                    string sqlInsert = "INSERT INTO Staff (ManagerID, FirstName, LastName, Email, Phone) " +
                                       "VALUES (@ManagerID, @FirstName, @LastName, @Email, @Phone)";
                    using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@ManagerID", managerID);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);


                        int rowsAffected = cmd.ExecuteNonQuery();
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
