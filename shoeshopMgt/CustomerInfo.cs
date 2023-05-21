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
    public partial class CustomerInfo : Form
    {
        function fn = new function();
        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet6.Tbl_CustInfo' table. You can move, or remove it, as needed.
            this.tbl_CustInfoTableAdapter.Fill(this.shopDBDataSet6.Tbl_CustInfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_CustInfo");
        }
        void cleardata()
        {
            txtcustomerid.Clear();
            txtcustomername.Clear();
            txtcustomeraddress.Clear();
            txtcustomercontno.Clear();
            txtcustomeremailid.Clear();

        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtcustomerid.Text = fn.GetAutoID("Select MAX(cust_id) from Tbl_CustInfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabaledFalse();
            cleardata();
            txtcustomername.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtcustomerid.Text = dataGridView1.SelectedRows[0].Cells["cust_id"].Value.ToString();
                txtcustomername.Text = dataGridView1.SelectedRows[0].Cells["cust_name"].Value.ToString();
                txtdob.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["cust_dob"].Value.ToString());
                txtcustomeraddress.Text = dataGridView1.SelectedRows[0].Cells["cust_add"].Value.ToString();
                txtcustomercontno.Text = dataGridView1.SelectedRows[0].Cells["cust_conno"].Value.ToString();
                txtcustomeremailid.Text = dataGridView1.SelectedRows[0].Cells["cust_email"].Value.ToString();
                



                EnabaledFalse();
                btnupdate.Enabled = true;

                txtcustomername.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void CustomerInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtcustomerid.Text == "" || txtcustomername.Text == "" || txtcustomeraddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_CustInfo(  cust_id, cust_name,cust_dob,cust_add,cust_conno,cust_email) values(" + txtcustomerid.Text + ",'" + txtcustomername.Text + "','" + txtdob.Value.ToString("MM/dd/yyyy") + "', '" + txtcustomeraddress.Text + "', " + txtcustomercontno.Text + ",'" + txtcustomeremailid.Text + "')");

            fn.FillGridData(dataGridView1, "Select * from Tbl_CustInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtcustomerid.Text == "" || txtcustomername.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_CustInfo set cust_name='" + txtcustomername.Text + "',cust_dob='" + txtdob.Value.ToString("MM/dd/yyyy") + "',cust_add= '" + txtcustomeraddress.Text + "',cust_conno=" + txtcustomercontno.Text + ",cust_email='" + txtcustomeremailid.Text + "'  where cust_id=" + txtcustomerid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_CustInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Update Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cleardata();
            txtcustomername.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        
        
        }

        private void btndalete_Click(object sender, EventArgs e)
        {
            if (txtcustomerid.Text == "" || txtcustomername.Text == "" || txtcustomeraddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_CustInfo Where cust_id=" + txtcustomerid.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_CustInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Delete Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            cleardata();
            txtcustomername.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
