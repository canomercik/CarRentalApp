using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_Project.Forms
{
    public partial class RegistrationForm : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        //private string firstName;
        //private string lastName;
        //private string email;
        //private string phone;
        //private string dateofbirth;
        //private string preference;
        //private string username;
        //private string password;


        public RegistrationForm()
        {
            InitializeComponent();
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CreateNextButton_Click(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }

            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            string email = textBox4.Text;
            string phone = textBox5.Text;
            string preference = textBox7.Text;
            string dateofbirth = textBox1.Text;
            string username = textBox9.Text;
            string password = textBox10.Text;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                        cmdAuthenticationInfo.Parameters.AddWithValue("@Role", "Customer");

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

                    string sqlInsert = "INSERT INTO Customer (FirstName, LastName, Email, Phone, DateOfBirth, Preference) " +
                                       "VALUES (@FirstName, @LastName, @Email, @Phone, @DateOfBirth, @Preference)";
                    using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateofbirth);
                        cmd.Parameters.AddWithValue("@Preference", preference);

                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Show();
        }
    }
}
