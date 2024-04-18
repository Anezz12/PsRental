using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public class CustomerRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public CustomerRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(connectionString);
        }


        private bool IsIdCustomerExists(string customer, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM CustomerTbl WHERE CustId = @CustId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CustId", customer);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public int AddCustomer(Customer customer)
        {
            int count = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "INSERT INTO CustomerTbl(CustId, CustName, CustAdd, Phone) VALUES (@CustId, @CustName, @CustAdd, @Phone)";
                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        if (IsIdCustomerExists(customer.CustId, sqlConnection))
                        {
                            Console.WriteLine($"User with CustId {customer.CustId} already exists. Cannot add duplicate user.");
                            return count;  // Return without attempting to insert
                        }

                        sqlCommand.Parameters.AddWithValue("@CustId", customer.CustId);
                        sqlCommand.Parameters.AddWithValue("@CustName", customer.CustName);
                        sqlCommand.Parameters.AddWithValue("@CustAdd", customer.CustAdd);
                        sqlCommand.Parameters.AddWithValue("@Phone", customer.Phone);

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
        
        public int DeleteCustomer(Customer customer)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "DELETE FROM CustomerTbl WHERE CustId = @CustId AND CustName = @CustName AND CustAdd = @CustAdd AND Phone = @Phone";

                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@CustId", customer.CustId);
                    sqlCommand.Parameters.AddWithValue("@CustName", customer.CustName);
                    sqlCommand.Parameters.AddWithValue("@CustAdd", customer.CustAdd);
                    sqlCommand.Parameters.AddWithValue("@Phone", customer.Phone);

                    sqlConnection.Open();
                    count = sqlCommand.ExecuteNonQuery();
                }
            }

            return count;
        }

        public int UpdateCustomer(Customer customer)
        {
            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandString = "UPDATE CustomerTbl SET CustId = @CustId , CustName = @CustName , CustAdd = @CustAdd , Phone = @Phone";

                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@CustId", customer.CustId);
                    sqlCommand.Parameters.AddWithValue("@CustName", customer.CustName);
                    sqlCommand.Parameters.AddWithValue("@CustAdd", customer.CustAdd);
                    sqlCommand.Parameters.AddWithValue("@Phone", customer.Phone);

                    sqlConnection.Open();
                    count = sqlCommand.ExecuteNonQuery();
                }

            }
            return count;
        }

    }
}
