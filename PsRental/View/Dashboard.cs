using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PsRental.Controller;
using PsRental.Model.Entityy;
using System.Data.SqlClient;

namespace PsRental.View
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenov\OneDrive\Documents\RentalPsdb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string querrycar = "select Count(*) from PsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querrycar, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Pslb.Text = dt.Rows[0][0].ToString();

            string querycust = "select Count(*) from CustomerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycust, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1); // Use sda1 here, not sda
            Customerlb.Text = dt1.Rows[0][0].ToString();

            string queruser = "select Count(*) from UserTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queruser, Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2); // Use sda2 here, not sda
            userlb.Text = dt2.Rows[0][0].ToString();


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Customerlb_Click(object sender, EventArgs e)
        {

        }
    }
}
