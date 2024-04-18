using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public class RentalRepository
    {

        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public RentalRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(connectionString);
        }


  


        public int AddRental(Rental rental)
        {
            int count = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "INSERT INTO RentalTbl(RentId, PsId, CustName, ReturnDate, RentDate, RentFee) VALUES (@RentId, @PsId, @CustName, @ReturnDate, @RentDate, @RentFee)";
                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                     
                        sqlCommand.Parameters.Add(new SqlParameter("@RentId", SqlDbType.Int) { Value = rental.RentId });
                        sqlCommand.Parameters.Add(new SqlParameter("@PsId", SqlDbType.Int) { Value = rental.PsId });
                        sqlCommand.Parameters.Add(new SqlParameter("@CustName", SqlDbType.VarChar) { Value = rental.CustName });
                        sqlCommand.Parameters.Add(new SqlParameter("@ReturnDate", SqlDbType.DateTime) { Value = rental.ReturnDate });
                        sqlCommand.Parameters.Add(new SqlParameter("@RentDate", SqlDbType.DateTime) { Value = rental.RentDate });
                        sqlCommand.Parameters.Add(new SqlParameter("@RentFee", SqlDbType.VarChar) { Value = rental.RentFee });

                      
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

        public int DeleteRental(Rental rental)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "DELETE FROM RentalTbl WHERE RentId = @RentId AND PsId = @PsId AND CustName = @CustName AND ReturnDate = @ReturnDate AND RentDate = @RentDate AND RentFee = @RentFee";

                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@RentId", SqlDbType.Int) { Value = rental.RentId });
                    sqlCommand.Parameters.Add(new SqlParameter("@PsId", SqlDbType.Int) { Value = rental.PsId });
                    sqlCommand.Parameters.Add(new SqlParameter("@CustName", SqlDbType.VarChar) { Value = rental.CustName });
                    sqlCommand.Parameters.Add(new SqlParameter("@ReturnDate", SqlDbType.DateTime) { Value = rental.ReturnDate });
                    sqlCommand.Parameters.Add(new SqlParameter("@RentDate", SqlDbType.DateTime) { Value = rental.RentDate });
                    sqlCommand.Parameters.Add(new SqlParameter("@RentFee", SqlDbType.VarChar) { Value = rental.RentFee });

                    sqlConnection.Open();
                    count = sqlCommand.ExecuteNonQuery();
                }
            }

            return count;
        }

        public int UpdateRental(Rental rental)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "UPDATE RentalTbl SET PsId = @PsId, CustName = @CustName, ReturnDate = @ReturnDate, RentDate = @RentDate, RentFee = @RentFee WHERE RentId = @RentId";


                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@RentId", SqlDbType.Int) { Value = rental.RentId });
                    sqlCommand.Parameters.Add(new SqlParameter("@PsId", SqlDbType.Int) { Value = rental.PsId });
                    sqlCommand.Parameters.Add(new SqlParameter("@CustName", SqlDbType.VarChar) { Value = rental.CustName });
                    sqlCommand.Parameters.Add(new SqlParameter("@ReturnDate", SqlDbType.DateTime) { Value = rental.ReturnDate });
                    sqlCommand.Parameters.Add(new SqlParameter("@RentDate", SqlDbType.DateTime) { Value = rental.RentDate });
                    sqlCommand.Parameters.Add(new SqlParameter("@RentFee", SqlDbType.VarChar) { Value = rental.RentFee });

                    sqlConnection.Open();
                    count = sqlCommand.ExecuteNonQuery();
                }

            }
            return count;
        }
    }

}
