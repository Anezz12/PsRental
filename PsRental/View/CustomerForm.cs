using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PsRental.Model.Entityy;
using PsRental.Controller;


namespace PsRental
{
    public partial class CustomerForm : Form
    {
        CustomerManager _CustomerManager;
        private Customer customer;

        public CustomerForm()
        {
            InitializeComponent();
            _CustomerManager = new CustomerManager();
            customer = new Customer();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30");


        private void populate()
        {
            Con.Open();
            string query = "Select * from CustomerTbl";

            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ListView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddresTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing informatian");
            }
            else
            {
                Customer customer = new Customer
                {
                    CustId = IdTb.Text,
                    CustName = NameTb.Text,
                    CustAdd = AddresTb.Text,
                    Phone = PhoneTb.Text

                };

                int result = _CustomerManager.AddCustomer(customer);


                if (result > 0)
                {
                    MessageBox.Show("Customer added successfully");
                    populate();

                }
                else
                {
                    MessageBox.Show("Failed to add Customer. Please check the provided information and try again.");
                }
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Customer CustomerToDelete = new Customer
            {
                CustId = IdTb.Text,
                CustName = NameTb.Text,
                CustAdd = AddresTb.Text,
                Phone = PhoneTb.Text
            };

            int result = _CustomerManager.DeleteCustomer(CustomerToDelete);

            if (result > 0)
            {
                MessageBox.Show("Customer deleted successfully");
                populate();
            }
            else
            {
                MessageBox.Show("Failed to delete Customer");
            }
        }

        private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            IdTb.Text = ListView.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = ListView.SelectedRows[0].Cells[1].Value.ToString();
            AddresTb.Text = ListView.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = ListView.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Customer CustomerToUpdate = new Customer
            {

                CustId = IdTb.Text,
                CustName = NameTb.Text,
                CustAdd = AddresTb.Text,
                Phone = PhoneTb.Text
            };
            int result = _CustomerManager.UpdateCustomer(CustomerToUpdate);
            if (result > 0)
            {
                MessageBox.Show("Customer Update successfully");
                populate();
            }
            else
            {
                MessageBox.Show("Failed to Update Customer");
            }
        }

        
    }
    }

