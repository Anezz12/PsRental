using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public  class ReturnRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;


        public ReturnRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(connectionString);
        }

        public int AddReturn(Return Return)
        {
            int count = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "INSERT INTO ReturnTbl(ReturnId, psId, CustName, ReturnDate, Fine, Delay) VALUES (@ReturnId, @psId, @CustName, @ReturnDate, @Fine, @Delay)";
                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        sqlCommand.Parameters.Add(new SqlParameter("@ReturnId", SqlDbType.Int) { Value = Return.ReturnId });
                        sqlCommand.Parameters.Add(new SqlParameter("@psId", SqlDbType.Int) { Value = Return.PsId });
                        sqlCommand.Parameters.Add(new SqlParameter("@CustName", SqlDbType.VarChar) { Value = Return.CustName });
                        sqlCommand.Parameters.Add(new SqlParameter("@ReturnDate", SqlDbType.DateTime) { Value = Return.ReturnDate });
                        sqlCommand.Parameters.Add(new SqlParameter("@Fine", SqlDbType.VarChar) { Value = Return.Fine });
                        sqlCommand.Parameters.Add(new SqlParameter("@Delay", SqlDbType.VarChar) { Value = Return.Delay });

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

        public int DeleteReturn(Return Return)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "DELETE FROM ReturnTbl WHERE ReturnId = @ReturnId AND psId = @psId AND CustName = @CustName AND ReturnDate = @ReturnDate AND Fine = @Fine AND Delay = @Delay";

                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlConnection.Open();

                    sqlCommand.Parameters.Add(new SqlParameter("@ReturnId", SqlDbType.Int) { Value = Return.ReturnId });
                    sqlCommand.Parameters.Add(new SqlParameter("@psId", SqlDbType.Int) { Value = Return.PsId });
                    sqlCommand.Parameters.Add(new SqlParameter("@CustName", SqlDbType.VarChar) { Value = Return.CustName });
                    sqlCommand.Parameters.Add(new SqlParameter("@ReturnDate", SqlDbType.DateTime) { Value = Return.ReturnDate });
                    sqlCommand.Parameters.Add(new SqlParameter("@Fine", SqlDbType.VarChar) { Value = Return.Fine });
                    sqlCommand.Parameters.Add(new SqlParameter("@Delay", SqlDbType.VarChar) { Value = Return.Delay });

                    count = sqlCommand.ExecuteNonQuery();
                }
            }

            return count;
        }
    }
}
