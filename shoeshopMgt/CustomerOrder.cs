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
    public partial class CustomerOrder : Form
    {
        function fn = new function();
        public CustomerOrder()
        {
           
            InitializeComponent();
        }

        private void CustomerOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet2.Tbl_CustOrder' table. You can move, or remove it, as needed.
            this.tbl_CustOrderTableAdapter.Fill(this.shopDBDataSet2.Tbl_CustOrder);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_CustOrder");
        }
        void cleardata()
        {
            txtid.Clear();
            txtcustomername.Clear();
            txtcustomeraddress.Clear();
            txtcontactno.Clear();
            txtproductname.Clear();
            txtproductquantity.Clear();
            txtprice.Clear();
          

        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtid.Text = fn.GetAutoID("Select MAX(id) from Tbl_CustOrder").ToString();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtcustomername.Text == "" || txtcustomeraddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_CustOrder(id,name,address,cont_no,prod_name,prod_qty,price) values(" + txtid.Text + ",'" + txtcustomername.Text + "','" + txtcustomeraddress.Text + "', " + txtcontactno.Text + ", '" + txtproductname.Text + "','" + txtproductquantity.Text + "'," + txtprice.Text + ")");

            fn.FillGridData(dataGridView1, "Select * from Tbl_CustOrder");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                txtid.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                txtcustomername.Text = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();
                txtcustomeraddress.Text = dataGridView1.SelectedRows[0].Cells["address"].Value.ToString();
                txtcontactno.Text = dataGridView1.SelectedRows[0].Cells["cont_no"].Value.ToString();
                txtproductname.Text = dataGridView1.SelectedRows[0].Cells["prod_name"].Value.ToString();
                txtproductquantity.Text = dataGridView1.SelectedRows[0].Cells["prod_qty"].Value.ToString();
                txtprice.Text = dataGridView1.SelectedRows[0].Cells["price"].Value.ToString();



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

        private void CustomerOrder_Activated(object sender, EventArgs e)
        {

            btnnew.Focus();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtcustomername.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_CustOrder set name='" + txtcustomername.Text + "',address='" + txtcustomeraddress.Text + "',cont_no= " + txtcontactno.Text + ",prod_name='" + txtproductname.Text + "',prod_qty=" + txtproductquantity.Text + ",price= " + txtprice.Text + " where id=" + txtid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_CustOrder");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Update Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtcustomername.Text == "" || txtcustomeraddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_CustOrder Where id=" + txtid.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_CustOrder");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Delete Data sucessfully..");
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
