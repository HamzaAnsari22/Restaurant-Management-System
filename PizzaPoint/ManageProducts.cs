using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace PizzaPoint
{
    public partial class ManageProducts : Form
    {
        string imgLocation = "";

        public ManageProducts()
        {
            InitializeComponent();
            dgv_CashierRegister();
        }

        private void ManageProducts_Load(object sender, EventArgs e)
        {
            this.productsTableAdapter.Fill(this.products._Products);

        }

        public void dgv_CashierRegister()
        {
            dgv1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            this.dgv1.GridColor = Color.Maroon;

            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            dgv1.EnableHeadersVisualStyles = false;

            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;


            this.dgv1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgv1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);
            dgv1.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.RowsDefaultCellStyle.BackColor = Color.Black;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv1.Columns[2].DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);

            dgv1.RowTemplate.Height = 200;
            dgv1.AllowUserToAddRows = false;


      
        }

        private void ManageProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            CashierRegisters cr = new CashierRegisters();
            cr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
           
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgv1.Rows[e.RowIndex].ErrorText = "Concisely describe the error and how to fix it";
            e.Cancel = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                byte[] images = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                images = brs.ReadBytes((int)Stream.Length);

                SqlConnection con = new SqlConnection(@"Data Source=LORD-VEGETA;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(ProductID.Text);
                int b = Convert.ToInt32(ProductPrice.Text);
                string sqlQuery = "update Products set ProductName = @ProductName , ProductPrice =  @b , ProductImage = @images where ProductId = '" + a1 + "'  ";
                cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@ProductName", ProductName.Text));
                cmd.Parameters.Add(new SqlParameter("@b", ProductPrice.Text));
                cmd.Parameters.Add(new SqlParameter("@images", images));
                var N = cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                ProductID.Text = string.Empty;
                ProductName.Text = string.Empty;
                ProductPrice.Text = string.Empty;
                MessageBox.Show("Product updated Successfully");
                this.productsTableAdapter.Fill(this.products._Products);
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Byte[] img = (Byte[])dgv1.CurrentRow.Cells[3].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

            ProductID.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            ProductName.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            ProductPrice.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LORD-VEGETA;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(ProductID.Text);
                cmd.CommandText = "delete from Products where ProductId ='" + a1 + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                ProductID.Text = string.Empty;
                ProductName.Text = string.Empty;
                ProductPrice.Text = string.Empty;
                MessageBox.Show("Product Deleted Successfully");
                this.productsTableAdapter.Fill(this.products._Products);
            }
            catch (Exception)
            {
                MessageBox.Show("ProductID can't be empty");
            }
           
        }
    }
}