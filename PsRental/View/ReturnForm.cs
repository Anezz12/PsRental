using PsRental.Controller;
using PsRental.Model.Entityy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PsRental.View
{
    public partial class ReturnForm : Form
    {
        ReturnManager _ReturnManager;
        private Return Return;

        public ReturnForm()
        {
            InitializeComponent();
            _ReturnManager = new ReturnManager();
            Return = new Return();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "Select * from RentalTbl";

            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ListView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populateRet()
        {
            Con.Open();
            string query = "Select * from ReturnTbl";

            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ListView2.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            populate();
            populateRet();
        }

        private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Assuming myListView is the name of your ListView
                if (ListView.SelectedRows.Count > 0)
                {
                    ReturnId.Text = ListView.SelectedRows[0].Cells[0].Value?.ToString();
                    PsId.Text = ListView.SelectedRows[0].Cells[1].Value?.ToString();
                    custName.Text = ListView.SelectedRows[0].Cells[2].Value?.ToString();

                    if (DateTime.TryParse(ListView.SelectedRows[0].Cells[4].Value?.ToString(), out DateTime returnDate))
                    {
                        ReturnDate.Text = returnDate.ToString();

                        TimeSpan delay = DateTime.Now - returnDate;
                        int nrOfDays = Convert.ToInt32(delay.TotalDays);

                        if (nrOfDays <= 0)
                        {
                            Delay.Text = "No Delay";
                            fine.Text = "0";
                        }
                        else
                        {
                            Delay.Text = nrOfDays.ToString();
                            fine.Text = (nrOfDays * 3000).ToString();
                        }
                    }
                    else
                    {
                        // Handle parsing error for return date
                        MessageBox.Show("Error parsing return date.");
                    }
                }
                else
                {
                    // Handle case where no row is selected
                    MessageBox.Show("No row selected.");
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                // Log or display the exception message
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void Deleteonreturn()
        {
            int RentId;
            RentId = Convert.ToInt32 (ListView.SelectedRows[0].Cells[0].Value.ToString());
            Con.Open();
            string query = "delete from RentalTbl where RentId=" + RentId + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();

            Con.Close();
            populate();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ReturnId.Text == "" || PsId.Text == "" || custName.Text == "" || ReturnDate.Text == "" || fine.Text == "" || Delay.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                Return Return = new Return
                {
                    ReturnId = ReturnId.Text,
                    PsId = PsId.Text,
                    CustName = custName.Text,
                    ReturnDate = ReturnDate.Text,
                    Fine = fine.Text,
                    Delay = Delay.Text
                };

                int result = _ReturnManager.AddReturn(Return);

                if (result > 0)
                {
                    MessageBox.Show("Retund added successfully");
                    populate();
                    populateRet();
                    Deleteonreturn();


            }
                else
                {
                    MessageBox.Show("Failed to add Retund. Please check the provided information and try again.");
                }
            }
        }

   
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Return Return = new Return
            {
                ReturnId = ReturnId.Text,
                PsId = PsId.Text,
                CustName = custName.Text,
                ReturnDate = ReturnDate.Text,
                Fine = fine.Text,
                Delay = Delay.Text

            };

            int result = _ReturnManager.DeleteReturn(Return);

            if (result > 0)
            {
                MessageBox.Show("RentId Delete successfully");
                populate();

            }
            else
            {
                MessageBox.Show("Failed to Delete Retund. Please check the provided information and try again.");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
