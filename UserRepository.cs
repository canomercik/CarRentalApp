using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace SQL_Project
{
    internal class UserRepository
    {
        private string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User GetUserByUsernameAndPassword(string username, string password) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = reader["Role"].ToString(),
                                CustomerID = reader["CustomerID"] as int?,
                                StaffID = reader["StaffID"] as int?,
                                ManagerID = reader["ManagerID"] as int?
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
