﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PizzaPoint
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill1(this.usersDataSet.Users);
            dgv_CashierRegister();
            dgv1.AllowUserToAddRows = false;
        }

        public void dgv_CashierRegister()
        {
            dgv1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            this.dgv1.GridColor = Color.Maroon;

            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10.5F, FontStyle.Regular);

            dgv1.EnableHeadersVisualStyles = false;
            dgv1.DefaultCellStyle.Padding = new Padding(8, 1, 0, 1);
            dgv1.RowTemplate.Height = 30;

            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;


            this.dgv1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgv1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 10.2F, FontStyle.Regular);
            dgv1.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.RowsDefaultCellStyle.BackColor = Color.Black;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int a1;

                SqlConnection con = new SqlConnection(@"Data Source=LORD-VEGETA;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                a1 = Convert.ToInt16(UserLoginID.Text);
                cmd.CommandText = "insert into Users (UserName,UserPost,UserEducation,UserLoginID,UserPass) values ('" + Username.Text + "','" + UserPost.Text + "','" + UserEducation.Text + "','" + a1 + "','" + UserPass.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Created Successfully");
                con.Close();
                UserLoginID.Text = string.Empty;
                Username.Text = string.Empty;
                UserEducation.Text = string.Empty;
                UserPass.Text = string.Empty;
                UserPost.Text = string.Empty;
                this.usersTableAdapter.Fill1(this.usersDataSet.Users);
            }
            catch (Exception)
            {
                MessageBox.Show("\tPlease fill all required fields"+"\nUser Post and Education Fields can be blank");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LORD-VEGETA;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(UserLoginID.Text);
                cmd.CommandText = "update Users set UserName = '" + Username.Text + "' , UserPost = '" + UserPost.Text + "', UserEducation = '" + UserEducation.Text + "', UserPass = '" + UserPass.Text + "' where UserLoginID = '" + a1 + "'  ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User Record updated Successfully");
                UserLoginID.Text = string.Empty;
                Username.Text = string.Empty;
                UserEducation.Text = string.Empty;
                UserPass.Text = string.Empty;
                UserPost.Text = string.Empty;
                this.usersTableAdapter.Fill1(this.usersDataSet.Users);
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LORD-VEGETA;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(UserLoginID.Text);
                cmd.CommandText = "delete from Users where UserLoginID ='" + a1 + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User Deleted Successfully");
                UserLoginID.Text = string.Empty;
                Username.Text = string.Empty;
                UserEducation.Text = string.Empty;
                UserPass.Text = string.Empty;
                UserPost.Text = string.Empty;
                this.usersTableAdapter.Fill1(this.usersDataSet.Users);
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            CashierRegisters cr = new CashierRegisters();
            this.Hide();
            cr.Show();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                Username.Text = row.Cells[1].Value.ToString();
                UserLoginID.Text = row.Cells[4].Value.ToString();
                UserPass.Text = row.Cells[5].Value.ToString();
                UserPost.Text = row.Cells[2].Value.ToString();
                UserEducation.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}