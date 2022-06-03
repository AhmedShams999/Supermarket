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
    public partial class OrderForm2 : Form
    {
        string connectionString = @"Data Source=DESKTOP-4OO9V2A;Initial Catalog=userSignupDB;Integrated Security=True";
        public OrderForm2()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (ProductName.Text == "")
            {
                MessageBox.Show("Please Enter information");
            } else if (gunaLabel1.Text == "Must be 16 digits")
            {
                MessageBox.Show("The Criedt Card Id is wrong");
                ProductName.Text = "";
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Order5", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@OrderCID", ProductName.Text.Trim());
                    sqlcmd.ExecuteNonQuery();

                }
                MessageBox.Show("Thank you for buying");
                CustomerForm ss = new CustomerForm();
                
                ss.Show();
                this.Close();
            }
        }

        private void ProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {

           

            if (ProductCat.SelectedItem.ToString() == "Cash")
            {
                this.Hide();
                OrderForm3 ss = new OrderForm3();
                ss.Show();
            }

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void ProductName_OnValueChanged(object sender, EventArgs e)
        {
            if (ProductName.Text.Length < 16)
            {
                gunaLabel1.ForeColor = Color.Red;
                gunaLabel1.Text = "Must be 16 digits";

            }
            else if (ProductName.Text.Length > 16)
            {
                gunaLabel1.ForeColor = Color.Red;
                gunaLabel1.Text = "Must be 16 digits";
            }
            else if (ProductName.Text.Length == 16)
            {
                gunaLabel1.ForeColor = Color.Green;
                gunaLabel1.Text = "Ok";
            }
            if (ProductName.Text == "")
            {
                gunaLabel1.Text = "";
            }
        }
    }
}
