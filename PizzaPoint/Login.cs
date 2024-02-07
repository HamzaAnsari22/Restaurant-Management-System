using System;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PizzaPoint
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LORD-VEGETA;Initial Catalog=PizzaPoint;Integrated Security=True");
            con.Open();
            try
            {
                if (txtLoginID.Text == "user" && txtPass.Text == "pass")
                {
                    Console.WriteLine("hhhh");
                    CashierRegisters cr = new CashierRegisters();
                    this.Hide();
                    cr.Show();
                }
                else if (txtLoginID.Text =="" || txtPass.Text == "")
                {
                    MessageBox.Show("Please Enter Username and Password");
                }
                else
                {
                    int a = Convert.ToInt16(txtLoginID.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT UserLoginID,UserPass from Users where UserLoginID = '" + a + "' and UserPass = '" + txtPass.Text + "'", con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        CashierRegisters cr = new CashierRegisters();
                        this.Hide();
                        cr.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
            }
            catch (Exception)
            {
            }
            con.Close();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
