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

namespace PsRental.View
{
    public partial class RentalForm : Form
    {
        RentalFormManager _rentalForm;
        private Rental rental;
        public RentalForm()
        {
            InitializeComponent();
            _rentalForm = new RentalFormManager();
            rental = new Rental();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void fillcombo()
        {
            Con.Open();
            string query = "select  IdPs from PsTbl where Available = '"+"Yes"+"'";
            SqlCommand cmd =  new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("IdPs", typeof(string));
            dt.Load(rdr);
            PsIdcb.ValueMember = "IdPs";
            PsIdcb.DataSource = dt;
            Con.Close();
        }


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


        private void fetchCustName()
        {
            Con.Open();
            string query = "select * from CustomerTbl where CustId= " + CustIdcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                custNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }

        private void fetchFee()
        {
            Con.Open();
            string query = "select * from PsTbl where IdPs= " + CustIdcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                custNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }

        private void custcombo()
        {
            Con.Open();
            string query = "select  CustId from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(string));
            dt.Load(rdr);
            CustIdcb.ValueMember = "CustId";
            CustIdcb.DataSource = dt;
            Con.Close();
        }
        
        private void RentalForm_Load(object sender, EventArgs e)
        {
            fillcombo();
            custcombo();
            populate();


        }

        private void CustId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustIdcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (RentId.Text == "" || PsIdcb.Text == "" || custNameTb.Text == "" || RentalDate.Text == "" || ReturnDate.Text == "" || fee.Text == "")
            {
                MessageBox.Show("Missing informatian");
            }
            else
            {
                Rental rental = new Rental
                {
                    RentId = RentId.Text,
                    PsId = PsIdcb.Text,
                    CustName = custNameTb.Text,
                    RentDate = RentalDate.Text,
                    ReturnDate = ReturnDate.Text,
                    RentFee = fee.Text

                };

                int result = _rentalForm.AddRental(rental);


                if (result > 0)
                {
                    MessageBox.Show("Rental added successfully");
                    populate();

                }
                else
                {
                    MessageBox.Show("Failed to add Rental. Please check the provided information and try again.");
                }

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Rental rental = new Rental
            {
                RentId = RentId.Text,
                PsId = PsIdcb.Text,
                CustName = custNameTb.Text,
                RentDate = RentalDate.Text,
                ReturnDate = ReturnDate.Text,
                RentFee = fee.Text

            };

            int result = _rentalForm.DeleteRental(rental);

            if (result > 0)
            {
                MessageBox.Show("RentId Delete successfully");
                populate();

            }
            else
            {
                MessageBox.Show("Failed to Delete RentId. Please check the provided information and try again.");
            }
        }

        private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RentId.Text = ListView.SelectedRows[0].Cells[0].Value.ToString();
            PsIdcb.Text = ListView.SelectedRows[0].Cells[1].Value.ToString();
            custNameTb.Text = ListView.SelectedRows[0].Cells[2].Value.ToString();
            fee.Text = ListView.SelectedRows[0].Cells[5].Value.ToString();
            
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Rental userToUpdate = new Rental
            {

                RentId = RentId.Text,
                PsId = PsIdcb.Text,
                CustName = custNameTb.Text,
                RentDate = RentalDate.Text,
                ReturnDate = ReturnDate.Text,
                RentFee = fee.Text
            };
            int result = _rentalForm.UpdateRental(userToUpdate);
            if (result > 0)
            {
                MessageBox.Show("Rental Update successfully");
                populate();
            }
            else
            {
                MessageBox.Show("Rental to Update user");
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
