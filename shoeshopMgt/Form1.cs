using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace shoeshopMgt
{
    public partial class Form1 : Form
    {
        function fn = new function();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            fn.FillCombo(cmbusername, "Select * from Tbl_Login", "usename", "usertype");
            cledata();
            cmbusername.Focus();
        }
        void cledata()
        {
            txtpassword.Clear();
            cmbusername.Focus();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                MessageBox.Show("Please enter password !...");
                txtpassword.Focus();
                return;
            }

            DataTable dt = fn.GettableData("Select * from Tbl_Login where usename='" + cmbusername.Text + "' AND password='" + txtpassword.Text + "'");

            if (dt.Rows.Count >= 1)
            {
                if (dt.Rows[0]["usertype"].ToString().Equals("admin"))
                {

                    WelCome wc = new WelCome();
                    wc.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid username and password !...");
                cledata();
            }


        }
    }
}
