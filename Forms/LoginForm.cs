using SQL_Project.Forms;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_Project
{
    public partial class LoginForm : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private readonly string connectionString = "Data Source=DESKTOP-C6B60EU;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


        //private string Username;

        //private string Password;

        public LoginForm()
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

        private void Username_TextChanged(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Textbox cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, you can stop further processing if the textbox is empty
                return;
            }

            UserRepository userRepository = new UserRepository(connectionString);

            User user = userRepository.GetUserByUsernameAndPassword(txtUsername.Text, txtPassword.Text);

            if (user != null)
            {
                RedirectToAppropriateForm(user.Role, user.CustomerID);
            }
            else
            {
                MessageBox.Show("Invalid Username or Password. Please try again.");
            }
        }


        private void RedirectToAppropriateForm(string userRole, int? customerID)
        {

            switch (userRole.ToLower())
            {
                case "customer":
                    OpenForm(new CustomerViewForm(customerID));
                    break;
                case "staff":
                    OpenForm(new StaffViewForm());
                    break;
                case "manager":
                    OpenForm(new ManagerViewForm());
                    break;
                default:
                    MessageBox.Show("Invalid user role.");
                    break;
            }
        }


        private void OpenForm(Form form)
        {
            this.Hide();

            form.ShowDialog();

            Application.Exit();
        }

        private void Loginform_Load(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
