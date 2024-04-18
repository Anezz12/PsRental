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
using PsRental.Model.Entityy;
using PsRental.Controller;
using System.Diagnostics;

namespace PsRental
{
    public partial class PsForm : Form
    {
        PsManager _PsManager;
        private Ps ps;


        public PsForm()
        {
            InitializeComponent();
            _PsManager = new PsManager();
            ps = new Ps();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "Select * from PsTbl";

            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ListView.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void fillAvailable()
        {
            Con.Open();
            string query = "select  Available from PsTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Available", typeof(string));
            dt.Load(rdr);
            Search.ValueMember = "Available";
            Search.DataSource = dt;
            Con.Close();
        }
        private void Ps_Load(object sender, EventArgs e)
        {
            populate();
         //  fillAvailable();
        }

        private void CarListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdPs.Text = ListView.SelectedRows[0].Cells[0].Value.ToString();
            ModelTb.Text = ListView.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = ListView.SelectedRows[0].Cells[3].Value.ToString();
            AvailableCh.SelectedItem = ListView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (IdPs.Text == "" || ModelTb.Text == "" || AvailableCh.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing informatian");
            }
            else
            {
                Ps ps = new Ps
                {
                    IdPs = IdPs.Text,
                    Model = ModelTb.Text,
                    Available = AvailableCh.Text,
                    Price = PriceTb.Text

                };

                int result = _PsManager.AddPs(ps);


                if (result > 0)
                {
                    MessageBox.Show("Ps added successfully");
                    populate();

                }
                else
                {
                    MessageBox.Show("Failed to add Ps. Please check the provided information and try again.");
                }

            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Ps PsToDelete = new Ps
            {
                IdPs = IdPs.Text,
                Model = ModelTb.Text,
                Available = AvailableCh.Text,
                Price = PriceTb.Text
            };

            int result = _PsManager.DeletePs(PsToDelete);

            if (result > 0)
            {
                MessageBox.Show("Ps deleted successfully");
                populate();
            }
            else
            {
                MessageBox.Show("Failed to delete Ps");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Ps PsToUpdate = new Ps
            {

                IdPs = IdPs.Text,
                Model = ModelTb.Text,
                Available = AvailableCh.Text,
                Price = PriceTb.Text
            };
            int result = _PsManager.UpdatePs(PsToUpdate);
            if (result > 0)
            {
                MessageBox.Show("Ps Update successfully");
                populate();
            }
            else
            {
                MessageBox.Show("Failed to Update Ps");
            }
        }

        private void Search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string flag = "";
            if (Search.SelectedItem.ToString() == "Available")
            {
                flag = "Yes";
            }
            else
            {
                flag = "No";
            }

            try
            {
                Con.Open();

                string query = "select * from PsTbl where Available = '" + flag + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ListView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the database operations
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Make sure to close the connection, whether an exception occurred or not
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }
    }
}
