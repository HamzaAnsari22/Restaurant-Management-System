using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PizzaPoint
{
    public partial class CashierRegisters : Form
    {

        private int _lastFormSize;

        public System.Windows.Forms.DataGridViewCellStyle RowHeadersDefaultCellStyle { get; set; }

        public new System.Windows.Forms.Padding Padding { get; set; }

        public int CUSTOM_CONTENT_HEIGHT { get; private set; }

    
        List<double> productquantity = new List<double>();
        List<double> productPrice = new List<double>();
        List<string> productname = new List<string>();

        private void UpdateFont()
        {
            foreach (DataGridViewColumn c in dgv1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 25F, GraphicsUnit.Pixel);
            }
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
            
            dgv1.Columns[2].DefaultCellStyle.Padding = new Padding(2, 2, 2,2);

        }

        public void dgv_CashierRegister2()
        {
            dgv2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            
            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv2.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            this.dgv2.GridColor = Color.Maroon;

            dgv2.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgv2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            dgv2.EnableHeadersVisualStyles = false;

            this.dgv2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv2.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;


            this.dgv2.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgv2.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            dgv2.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);
            dgv2.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv2.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv2.RowsDefaultCellStyle.BackColor = Color.Black;
            dgv2.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

            dgv2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv2.Columns[2].DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);

        }


        public void fillGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LORD-VEGETA;Initial Catalog=PizzaPoint;Integrated Security=True");
            con.Open();
            SqlCommand command;
            SqlDataAdapter da;
            string selectQuery = "Select ProductName , ProductPrice , ProductImage from Products";
            command = new SqlCommand(selectQuery,con);
            da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.RowTemplate.Height = 200;
            dgv1.AllowUserToAddRows = false;
            da.Fill(dt);
            dgv1.DataSource = dt;
            con.Close();
        }

        public CashierRegisters()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1300, 850);
            this.Resize += new EventHandler(Form2_Resize);
            _lastFormSize = GetFormArea(this.Size);
            dgv1.RowTemplate.Height = 200;
            dgv2.RowTemplate.Height = 30;
            dgv1.AllowUserToAddRows = false;
            dgv2.AllowUserToAddRows = false; ;
        }

        private int GetFormArea(Size size)
        {
            return size.Height * size.Width;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            float scaleFactor = (float)GetFormArea(control.Size) / (float)_lastFormSize;

            ResizeFont(this.Controls, scaleFactor);

            _lastFormSize = GetFormArea(control.Size);

        }

        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    if (true)
                    {
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }

        void writeExpression(String value)
        {
       
            txtQuantity.Text = value;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            writeExpression("9");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            writeExpression("8");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            writeExpression("7");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            writeExpression("6");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            writeExpression("5");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            writeExpression("4");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            writeExpression("3");
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            writeExpression("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            writeExpression("2");
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            writeExpression("0");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                String processor;
                processor = txtQuantity.Text;
                processor = processor.Substring(0, processor.Length - 1);
                txtQuantity.Text = processor;
            }
            catch (Exception)
            {
                txtQuantity.Text = "";
            }
        }

        private void HomePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CashierRegister_Load(object sender, EventArgs e)
        {
            this.productsTableAdapter.Fill1(this.products._Products);
            dgv_CashierRegister();
            dgv_CashierRegister2();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                comboBox1.Text = row.Cells[0].Value.ToString();
                txtItemPrice.Text = row.Cells[1].Value.ToString();
                txtQuantity.Text = "1";
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product product = new Product();
            product.Show();
        }

        public void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users users = new Users();
          
            users.Show();
        }

        private void dgv1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = "";
            txtItemPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void btnEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                bool Found = false;
                dgv2.AllowUserToAddRows = true;
                if (dgv2.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgv2.Rows)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == comboBox1.Text)
                        {
                            row.Cells[1].Value = Convert.ToString(Convert.ToInt32(txtQuantity.Text) + Convert.ToInt32(row.Cells[1].Value));
                            row.Cells[2].Value = Convert.ToString(Convert.ToInt32(txtItemPrice.Text) * Convert.ToInt32(row.Cells[1].Value));
                            Found = true;

                            int sum = 0;
                            int sum2 = 0;
                            for (int i = 0; i < dgv2.Rows.Count; ++i)
                            {
                                sum += Convert.ToInt32(dgv2.Rows[i].Cells[1].Value);
                                sum2 += Convert.ToInt32(dgv2.Rows[i].Cells[2].Value);
                            }
                            qtyResult.Text = sum.ToString();
                            MainTotalResult.Text = sum2.ToString();
                        }
                        dgv2.AllowUserToAddRows = false;
                    }
                    if (!Found)
                    {
                        int a = Convert.ToInt32(txtQuantity.Text);
                        int b = Convert.ToInt32(txtItemPrice.Text);
                        int c = a * b;

                        dgv2.Rows.Add(comboBox1.Text, a, c, 1);
            
                        int sum = 0;
                        int sum2 = 0;
                        for (int i = 0; i < dgv2.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dgv2.Rows[i].Cells[1].Value);
                            sum2 += Convert.ToInt32(dgv2.Rows[i].Cells[2].Value);
                        }
                        qtyResult.Text = sum.ToString();
                        MainTotalResult.Text = sum2.ToString();
                    }
                }
            }
            catch (Exception)
            {
                if (txtQuantity.TextLength < 0 || txtItemPrice.TextLength < 0 || string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Fields can't be Empty");
                }

                else if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Choose item name");
                }

                else if (txtQuantity.Text.Length == 0)
                {
                    MessageBox.Show("Quantity cant be Zero");
                }

                else if (txtItemPrice.Text.Length == 0)
                {
                    MessageBox.Show("Enter price for item");
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgv2.SelectedRows)
                {
                    dgv2.Rows.RemoveAt(row.Index);
                }

                int sum = 0;
                int sum2 = 0;
                for (int i = 0; i < dgv2.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgv2.Rows[i].Cells[1].Value);
                    sum2 += Convert.ToInt32(dgv2.Rows[i].Cells[2].Value);
                }
                qtyResult.Text = sum.ToString();
                MainTotalResult.Text = sum2.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot remove unselected or empty row");
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            txtItemPrice.Text = "";
            txtQuantity.Text = "";
            dgv2.Rows.Clear();
            dgv2.Refresh();
            MainTotalResult.Text = "0";
            qtyResult.Text = "0";
            productquantity.Clear();
            productPrice.Clear();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            string Custname = "Valuable Customer";
            string CustContact = "***********";

            string CUSTID,ORDERID,CUSTNAME,ORDERTIME,ORDERDATE,CUSTCONTACT;
            string OrderType = "Food Item";
            string OrderCategory = "Food";

            
            SqlConnection con = new SqlConnection(@"Data Source = LORD-VEGETA; Initial Catalog = PizzaPoint; Integrated Security = SSPI; MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            if (MainTotalResult.Text != "0")
            {
                try
                {

                    SqlCommand cmd1 = new SqlCommand("insert into Customer values ('" + Custname + "','" + CustContact + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.Date + "')", con, tran);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("select top 1 CustID from Customer order by CustID DESC", con, tran);
                    cmd2.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd2.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CUSTID = dr["CustID"].ToString();
                            SqlCommand cmd3 = new SqlCommand("insert into Orders values ('" + CUSTID + "','" + OrderType.ToString() + "','" + OrderCategory.ToString() + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.Date + "')", con, tran);
                            cmd3.ExecuteNonQuery();
                        }
                    }

                    SqlCommand cmd4 = new SqlCommand("select top 1 CustID,CustName,Contact from Customer order by CustID DESC", con, tran);
                    cmd4.ExecuteNonQuery();
                    SqlCommand cmd5 = new SqlCommand("select top 1 OrderID,OrderTime,OrderDate from Orders order by OrderID DESC", con, tran);
                    cmd5.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd4.ExecuteReader())
                    {
                        using (SqlDataReader dr1 = cmd5.ExecuteReader())
                        {
                            string itemname;
                            string itemqty;
                            string itemprice;
                            string billtotal = MainTotalResult.Text;
                            string totalqty = qtyResult.Text;

                            while (dr.Read())
                            {
                                CUSTID = dr["CustID"].ToString();
                                CUSTNAME = dr["CustName"].ToString();
                                CUSTCONTACT = dr["Contact"].ToString();
                                while (dr1.Read())
                                {
                                    ORDERID = dr1["OrderID"].ToString();
                                    ORDERTIME = dr1["OrderTime"].ToString();
                                    ORDERDATE = dr1["OrderDate"].ToString();

                                    SqlCommand cmd7 = new SqlCommand("insert into Sales values ('" + ORDERID + "','" + CUSTID + "','" + CUSTNAME + "','" + CUSTCONTACT + "','" + OrderType + "','" + OrderCategory + "','" + ORDERTIME + "','" + ORDERDATE + "')", con, tran);
                                    cmd7.ExecuteNonQuery();

                                    SqlCommand cmd6;
          
                                    for (int i = 0; i < dgv2.Rows.Count; i++)
                                    {
                                        itemname = Convert.ToString(dgv2.Rows[i].Cells[0].Value);
                                        itemqty = Convert.ToString(dgv2.Rows[i].Cells[1].Value);
                                        itemprice = Convert.ToString(dgv2.Rows[i].Cells[2].Value);

                                        cmd6 = new SqlCommand("insert into Bill values ('" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + itemname.ToString() + "','" + itemqty.ToString() + "','" + itemprice.ToString() + "','" + ORDERTIME + "','" + ORDERDATE + "','" + totalqty.ToString() + "','" + billtotal.ToString() + "')", con, tran);
                                        cmd6.ExecuteNonQuery();

                                    }
                                    comboBox1.Text = "";
                                    txtItemPrice.Text = "";
                                    txtQuantity.Text = "";
                                    dgv2.Rows.Clear();
                                    dgv2.Refresh();
                                    MainTotalResult.Text = "0";
                                    qtyResult.Text = "0";
                                    productquantity.Clear();
                                    productPrice.Clear();
                                    BillForm b = new BillForm();
                                    b.Show();


                                }
                            }
                        }

                        tran.Commit();
                    }
                }
                catch (SqlException)
                {
                    tran.Rollback();
                    MessageBox.Show("Operation Unsuccessfull");
                }
            }
            else
            {
                MessageBox.Show("No Order Found To generate Bill");
            }

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.Show();
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            Prices prices = new Prices();
            this.Hide();
            prices.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            this.Hide();
            sales.Show();
        }

        private void ClockOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ManageProducts mp = new ManageProducts();
            mp.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        public void listviewDesign()
        {
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
               
        }

        private void listView1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void CashierRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgv1.Rows[e.RowIndex].ErrorText = "Concisely describe the error and how to fix it";
            e.Cancel = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}