using PsRental.Controller;
using PsRental.Model.Entityy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PsRental
{
    public partial class Login : Form
    {

        UserManager _userManager;
        private User user;

        public string Message = "";
        public Login()
        {
            InitializeComponent();

            _userManager = new UserManager();
            user = new User();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            loginMessageLabel.Text = "";

            // Validation check
            if (String.IsNullOrEmpty(userNameTextBox.Text))
            {
                loginMessageLabel.Text = "Please enter username";
                return;
            }

            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                loginMessageLabel.Text = "Please enter password";
                return;
            }

            // Pass value in User Class
            user.Username = userNameTextBox.Text;
            user.Password = passwordTextBox.Text;

            try
            {
                if (_userManager.Login(user) != 0)
                {
                    // Redirect form
                    this.Hide();
                    MainForm home = new MainForm();
                    home.Show();
                }
                else
                {
                    // Login error message
                    loginMessageLabel.Text = "Username or password doesn't match";
                    passwordTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }
