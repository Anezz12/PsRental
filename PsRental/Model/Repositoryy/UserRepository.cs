using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public class UserRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public UserRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30";
            sqlConnection  = new SqlConnection(connectionString);
        }

        public int LogIn(User user)
        {
            int count = 0;

            // Gunakan parameterized query
            commandString = "SELECT * FROM UserTbl WHERE Uname = @Username AND Upass = @Password";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            // Tambahkan parameter
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);

            sqlConnection.Open();

            // Gunakan ExecuteReader untuk membaca hasil SELECT
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    count++;
                }
            }

            sqlConnection.Close();

            return count;
        }
    }
}
