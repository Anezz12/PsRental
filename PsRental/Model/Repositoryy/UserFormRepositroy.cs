using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public class UserFormRepositroy
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public UserFormRepositroy()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(connectionString);
        }

        private bool IsIdExists(string userId, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM UserTbl WHERE Id = @UserId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }


        public int AddUser(User user)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "INSERT INTO UserTbl(Id, Uname, Upass) VALUES (@Id, @Username, @Password)";
                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        // Check if the Id already exists
                        if (IsIdExists(user.Id, sqlConnection))
                        {
                            Console.WriteLine($"User with Id {user.Id} already exists. Cannot add duplicate user.");
                            return count;  // Return without attempting to insert
                        }

                        sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                        sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                        sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                        count = sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return count;
        }

        public int DeleteUser(User user)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "DELETE FROM UserTbl WHERE Id = @Id AND Uname = @Username AND Upass = @Password";

                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                    sqlConnection.Open();
                    count = sqlCommand.ExecuteNonQuery();
                }
            }

            return count;
        }

        public int UpdateUser(User user)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "UPDATE UserTbl SET Uname = @Username, Upass = @Password WHERE Id = @Id";

                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                    sqlConnection.Open();
                    count = sqlCommand.ExecuteNonQuery();
                }
            }

            return count;
        }

    }
}
