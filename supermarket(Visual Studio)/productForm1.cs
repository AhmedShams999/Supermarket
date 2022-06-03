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
    public partial class productForm1 : Form
    {
        public productForm1()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-4OO9V2A;Initial Catalog=userSignupDB;Integrated Security=True";
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Addtion1", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productID", bunifuMetroTextbox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@productName", ProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@productCat", bunifuMetroTextbox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@productPrice", ProductPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@productCode", ProductCode.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("the item added");
                    clear();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
        void clear()
        {
            bunifuMetroTextbox2.Text = ProductName.Text = ProductCode.Text = ProductPrice.Text = bunifuMetroTextbox4.Text = "";
        }
        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
   
    private void populate()
    {
        using (SqlConnection Con = new SqlConnection(connectionString))
        {
            Con.Open();
                string query = "select * from Products";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
                gunaDataGridView1.DataSource = ds.Tables[0];
            
        }
    }
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
             
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void productForm1_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMetroTextbox2.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ProductName.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox4.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ProductCode.Text = gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            ProductPrice.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                Con.Open();
                string query = "delete Products where productID = @productID ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@productID", bunifuMetroTextbox1.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("the item is removed");
                populate();
                bunifuMetroTextbox1.Text = "";

            }
        }

        private void ProductName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            
        }
        
        private void bunifuThinButton23_Load(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductName.Text == "" || bunifuMetroTextbox4.Text == "" || ProductCode.Text == "" || ProductPrice.Text == "" || bunifuMetroTextbox2.Text == "")
                {
                    MessageBox.Show("Please Fill Missing Info");
                }
                else
                {
                    using (SqlConnection Con = new SqlConnection(connectionString))
                    {
                        Con.Open();
                        string query = "update Products set productName =@productName,productCat = @productCat,productPrice = @productPrice,productCode = @productCode where productID = @productID ";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.Parameters.AddWithValue("@productID", bunifuMetroTextbox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@productName", ProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@productCat", bunifuMetroTextbox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@productPrice", ProductPrice.Text.Trim());
                        cmd.Parameters.AddWithValue("@productCode", ProductCode.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The product is updated");
                        populate();
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

