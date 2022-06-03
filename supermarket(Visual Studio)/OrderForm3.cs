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

namespace supermarket
{
    public partial class OrderForm3 : Form
    {
        string connectionString = @"Data Source=DESKTOP-4OO9V2A;Initial Catalog=userSignupDB;Integrated Security=True";
        public OrderForm3()
        {
            InitializeComponent();
        }

        private void ProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductCat.Text == "MasterCard")
            {
                this.Hide();
                OrderForm2 ss = new OrderForm2();
                ss.Show();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text.Length < 8)
            {
                gunaLabel1.ForeColor = Color.Red;
                gunaLabel1.Text = "Must be 8 digits";

            }
            else if (bunifuMetroTextbox1.Text.Length > 8)
            {
                gunaLabel1.ForeColor = Color.Red;
                gunaLabel1.Text = "Must be 8 digits";
            }
            else if (bunifuMetroTextbox1.Text.Length == 8)
            {
                gunaLabel1.ForeColor = Color.Green;
                gunaLabel1.Text = "Ok";
            }
            if (bunifuMetroTextbox1.Text == "")
            {
                gunaLabel1.Text = "";
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || bunifuMetroTextbox1.Text == "" || bunifuMetroTextbox2.Text == "")
            {
                MessageBox.Show("Please Enter information");
            } else if (gunaLabel1.Text == "Must be 8 digits")
            {
                MessageBox.Show("Please enter correct Phone Number");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Order4", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@OrderName", bunifuMetroTextbox2.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@OrderAddress", textBox1.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@OrderPnumber", bunifuMetroTextbox1.Text.Trim());
                    sqlcmd.ExecuteNonQuery();

                MessageBox.Show("Thank you for buying");
                this.Hide();
                CustomerForm ss = new CustomerForm();
                ss.Show();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                Con.Open();
                string query = "delete Orders  ";
                SqlCommand cmd = new SqlCommand(query, Con);
                MessageBox.Show("order is deleted");
                this.Hide();
                CustomerForm ss = new CustomerForm();
                ss.Show();
            }
        }
    }
}