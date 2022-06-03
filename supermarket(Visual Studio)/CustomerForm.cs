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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductName.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            productCate.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ProductPrice.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        string connectionString = @"Data Source=DESKTOP-4OO9V2A;Initial Catalog=userSignupDB;Integrated Security=True";
        private void populate()
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                Con.Open();
                string query = "select productName,productCat,productPrice from Products";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                gunaDataGridView1.DataSource = ds.Tables[0];

            }
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            populate();
        }
        int gradtotal = 0;
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

                
            if (bunifuMetroTextbox2.Text == "")
            {
                MessageBox.Show("please enter the Quntity");
            }
          



            else
            {

                int n = 0, total = Convert.ToInt32(ProductPrice.Text) * Convert.ToInt32(bunifuMetroTextbox2.Text);

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(cartDCV);
                newRow.Cells[0].Value = ProductName.Text;
                newRow.Cells[1].Value = productCate.Text;
                newRow.Cells[2].Value = ProductPrice.Text;
                newRow.Cells[3].Value = bunifuMetroTextbox2.Text;
                newRow.Cells[4].Value = Convert.ToInt32(ProductPrice.Text) * Convert.ToInt32(bunifuMetroTextbox2.Text);
                cartDCV.Rows.Add(newRow);
                gradtotal += total;
                pay.Text = gradtotal + " pound";

            }
        }

        private void cartDCV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMetroTextbox1.Text = cartDCV.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
        }
        private void label9_Click(object sender, EventArgs e)
        {
       
            Form1 ss = new Form1();
            ss.Show();
            this.Hide();

            
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            if (gradtotal == 0)
            {
                MessageBox.Show("Please select an item");
            } else
            {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Order4", sqlCon);
               

            }
                OrderForm ss = new OrderForm();
                ss.Owner = this;
                ss.Show();
                this.Hide();
            }

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {


            if (cartDCV.Rows.Count == 0)
            {
                MessageBox.Show("there is no item to delete");
            } else if (bunifuMetroTextbox1.Text == "")
                {
                    MessageBox.Show("Choose an item to delete");
                }
           else if (this.cartDCV.SelectedRows.Count > 0)
            {
                cartDCV.Rows.RemoveAt(this.cartDCV.SelectedRows[0].Index);


               

                    gradtotal -= Convert.ToInt32(bunifuMetroTextbox1.Text);
                    bunifuMetroTextbox1.Text = "";
                    pay.Text = gradtotal + " pound";
                
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
