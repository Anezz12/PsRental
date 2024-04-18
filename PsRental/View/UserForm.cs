using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PsRental.Model.Entityy;
using PsRental.Controller;

namespace PsRental
{
    public partial class UserForm : Form
    {
        UserFormManager _userFormManager;
        private User user;

        public UserForm()
        {
            InitializeComponent();
            _userFormManager = new UserFormManager();
            user = new User();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ListView.DataSource = ds.Tables[0];
            Con.Close();
            
        }
      

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                User user = new User
                {
                    Id = Uid.Text,
                    Username = Uname.Text,
                    Password = Upass.Text // Remember to hash the password before storing it
                };

                int result = _userFormManager.AddUser(user);

                if (result > 0)
                {
                    MessageBox.Show("User added successfully");
                    populate();
                }
                else
                {
                    MessageBox.Show("Failed to add user. Please check the provided information and try again.");
                }
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            User userToDelete = new User
            {
                Id = Uid.Text, // Replace with the actual ID of the user you want to delete
                Username = Uname.Text,
                Password = Upass.Text
            };

            int result = _userFormManager.DeleteUser(userToDelete);

            if (result > 0)
            {
                MessageBox.Show("User deleted successfully");
                populate();
            }
            else
            {
                MessageBox.Show("Failed to delete user");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            User userToUpdate = new User
            {

                Id = Uid.Text, 
                Username = Uname.Text,
                Password = Upass.Text
            };
            int result = _userFormManager.UpdateUser(userToUpdate);
            if (result > 0)
            {
                MessageBox.Show("User Update successfully");
                populate();
            }
            else
            {
                MessageBox.Show("Failed to Update user");
            }
        }
        

        private void ListView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text = ListView.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = ListView.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = ListView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}