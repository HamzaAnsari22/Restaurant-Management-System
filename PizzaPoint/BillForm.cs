using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;


namespace PizzaPoint
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
            btnPrint.Hide();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnPrint.Show();
            string orderID; ;

            SqlConnection con = new SqlConnection(@"Data Source = LORD-VEGETA; Initial Catalog = PizzaPoint; Integrated Security = SSPI; MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd = new SqlCommand("select top 1 OrderID from Orders order by OrderID DESC", con, tran);
            cmd.ExecuteNonQuery();

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    orderID = dr["OrderID"].ToString();

                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (db.State == ConnectionState.Closed)
                            db.Open();
                        string query = "select CustID,CustName,OrderDate,OrderID,OrderTime,ProductName,ProductPrice,ProductQuantity,TotalAmount,Totalqty from Bill where OrderID  = '" + orderID +"' ";
                        ordersDetailsBindingSource.DataSource = db.Query<OrdersDetails>(query, commandType: CommandType.Text);
                    }
                }
            }
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            dgv_CashierRegister();
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
            dgv1.DefaultCellStyle.Padding = new Padding(8, 1, 0, 1);
            dgv1.RowTemplate.Height = 30;

            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;


            this.dgv1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgv1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv1.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.RowsDefaultCellStyle.BackColor = Color.Black;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                total += Convert.ToInt32(row.Cells[5].Value.ToString());
            }
                MessageBox.Show("Your Total Bill is: "+ total,"Total Bill");
            this.Hide();
        }
    }
}