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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }
        string connectionString = @"Data Source=DESKTOP-4OO9V2A;Initial Catalog=userSignupDB;Integrated Security=True";
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (selectRole.Text == "Select role")
            {
                MessageBox.Show("please select a role");
            }
            else
            {
                if (selectRole.SelectedItem.ToString() == "Manager")
                {
                    if (bunifuMetroTextbox2.Text == "Admin" && bunifuMetroTextbox1.Text == "Admin")
                    {
                        productForm1 ss = new productForm1();
                        ss.Owner = this;
                        ss.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("if you arent an admin please signup first");
                        clear();
                    }
                }
                else if (selectRole.SelectedItem.ToString() == "Customer")
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from TPLuser where UserName='" + bunifuMetroTextbox2.Text + "' and password = '" + bunifuMetroTextbox1.Text + "'", sqlCon);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            CustomerForm ss = new CustomerForm();
                         
                            ss.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Please cheeck your USERNAME and PASSWORD");
                            clear();
                        }
                    }
                }
                else if (selectRole.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("please choose a role");
                }

            }
        }
        void clear()
        {
            bunifuMetroTextbox2.Text = bunifuMetroTextbox1.Text = "";
        }
        private void label4_Click(object sender, EventArgs e)
        {
           
            signup_form ss = new signup_form();
            ss.Owner = this;
            ss.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
