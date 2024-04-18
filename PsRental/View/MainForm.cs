using PsRental.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsRental
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserMenu_Click(object sender, EventArgs e)
        {
            UserForm categorySetup = new UserForm();
            categorySetup.Show();
        }

        private void PsMenu_Click(object sender, EventArgs e)
        {
            PsForm categorySetup = new PsForm();
            categorySetup.Show();
        }

        private void CustumerMenu_Click(object sender, EventArgs e)
        {
            CustomerForm categorySetup = new CustomerForm();
            categorySetup.Show();
        }

        private void RentalMenu_Click(object sender, EventArgs e)
        {
            RentalForm categorySetup = new RentalForm();
            categorySetup.Show();
        }

        private void ReturnMenu_Click(object sender, EventArgs e)
        {
            ReturnForm categorySetup = new ReturnForm();
            categorySetup.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard categorySetup = new Dashboard();
            categorySetup.Show();
        }
    }
}
