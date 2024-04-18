using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public class PsRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public PsRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(connectionString);
        }

        private bool IsIdPsExists(string IdPs, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM PsTbl WHERE IdPs = @IdPs";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdPs", IdPs);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public int AddPs(Ps ps)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "INSERT INTO PsTbl(IdPs, Model, Available, Price) VALUES (@IdPs, @Model, @Available, @Price)";
                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        // Check if the Id already exists
                        if (IsIdPsExists(ps.IdPs, sqlConnection))
                        {
                            Console.WriteLine($"User with IdPs {ps.IdPs} already exists. Cannot add duplicate user.");
                            return count;  // Return without attempting to insert
                        }

                        sqlCommand.Parameters.AddWithValue("@IdPs", ps.IdPs);
                        sqlCommand.Parameters.AddWithValue("@Model", ps.Model);
                        sqlCommand.Parameters.AddWithValue("@Available", ps.Available);
                        sqlCommand.Parameters.AddWithValue("@Price", ps.Price);

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

        public int DeletePs(Ps ps)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "DELETE FROM PsTbl WHERE IdPs = @IdPs AND Model = @Model AND Available = @Available AND Price = @Price";

                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdPs", ps.IdPs);
                    sqlCommand.Parameters.AddWithValue("@Model", ps.Model);
                    sqlCommand.Parameters.AddWithValue("@Available", ps.Available);
                    sqlCommand.Parameters.AddWithValue("@Price", ps.Price);

                    sqlConnection.Open();
                    count = sqlCommand.ExecuteNonQuery();
                }
            }

            return count;
        }

        private bool CheckIfRecordExists(SqlConnection connection, string idPs)
        {
            string checkCommand = "SELECT COUNT(*) FROM PsTbl WHERE IdPs = @IdPs";

            using (SqlCommand checkSqlCommand = new SqlCommand(checkCommand, connection))
            {
                checkSqlCommand.Parameters.AddWithValue("@IdPs", idPs);

                connection.Open();
                int count = (int)checkSqlCommand.ExecuteScalar();

                return count > 0;
            }
        }

        public int UpdatePs(Ps ps)
        {
            int rowsAffected = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    // Check if the record with the given IdPs already exists
                    bool recordExists = CheckIfRecordExists(sqlConnection, ps.IdPs);

                    if (recordExists)
                    {
                        // The record exists, so perform an update
                        string updateCommand = "UPDATE PsTbl SET Model = @Model, Available = @Available, Price = @Price WHERE IdPs = @IdPs";

                        using (SqlCommand sqlCommand = new SqlCommand(updateCommand, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@IdPs", ps.IdPs);
                            sqlCommand.Parameters.AddWithValue("@Model", ps.Model);
                            sqlCommand.Parameters.AddWithValue("@Available", ps.Available);
                            sqlCommand.Parameters.AddWithValue("@Price", ps.Price);

                            
                            rowsAffected = sqlCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // The record doesn't exist, you might want to handle this case accordingly
                        Console.WriteLine($"Record with IdPs = {ps.IdPs} does not exist.");
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions
                    Console.WriteLine($"Error updating PsTbl record: {ex.Message}");
                }
            }

            return rowsAffected;

        }
    }
}

