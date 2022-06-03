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
    public partial class signup_form : Form
    {
        string connectionString = @"Data Source=DESKTOP-4OO9V2A;Initial Catalog=userSignupDB;Integrated Security=True";
        public signup_form()
        {
            InitializeComponent();
        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void LOGIN_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

            this.Owner.Show();
            this.Close();
        }


       
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                if (userName.Text == "" || e_mail.Text == "" || password.Text == "" || phoneNumber.Text == "")
                {
                    MessageBox.Show("Please Enter all values");
                    clear();
                }
                else if (password.Text != confiromPassword.Text)
                {
                    MessageBox.Show("Please cheeck your password agian");
                    clear();
                }
                else if (gunaLabel1.Text == "Must more than 8 digits")
                {
                    MessageBox.Show("Please correct your Password");
                        confiromPassword.Text = password.Text = "";
                }
                else if (gunaLabel2.Text == "Must less than or equal 10 digits")
                {
                    MessageBox.Show("Please correct your Phone Number");
                    phoneNumber.Text = "";
                }
                else
                {
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Useradd", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserName", userName.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@password", password.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@E_mail", e_mail.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@phoneNumber", phoneNumber.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Thank you for signing up");
                    clear();
                    this.Hide();
            Form1 ss = new Form1();
            ss.Show();
                }
            }
        }
        void clear()
        {
            userName.Text = password.Text =  e_mail.Text = phoneNumber.Text = confiromPassword.Text = "";
        }

        private void password_OnValueChanged(object sender, EventArgs e)
        {
            if (password.Text.Length < 8)
            {
                gunaLabel1.ForeColor = Color.Red;
                gunaLabel1.Text = "Must more than 8 digits";

            } else if (password.Text.Length >= 8)
            {
                gunaLabel1.ForeColor = Color.Green;
                gunaLabel1.Text = "Ok";
            } 
            if (password.Text == "")
            {
                gunaLabel1.Text = "";
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void confiromPassword_OnValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void phoneNumber_OnValueChanged(object sender, EventArgs e)
        {
            if (phoneNumber.Text.Length > 10)
            {
                gunaLabel2.ForeColor = Color.Red;
                gunaLabel2.Text = "Must equal 10 digits";

            }
            else if (phoneNumber.Text.Length < 10)
            {
                gunaLabel2.ForeColor = Color.Red;
                gunaLabel2.Text = "Must equal 10 digits";

            }
            else if (phoneNumber.Text.Length == 10)
            {
                gunaLabel2.ForeColor = Color.Green;
                gunaLabel2.Text = "Ok";
            }
            if (phoneNumber.Text == "")
            {
                gunaLabel2.Text = "";
            }
                        
        }
    }
}
