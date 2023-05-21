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
    public partial class OrderInfo : Form
    {
        function fn = new function();
        public OrderInfo()
        {
           
            InitializeComponent();
        }

        private void OrderInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet8.Tbl_Orderinfo' table. You can move, or remove it, as needed.
            this.tbl_OrderinfoTableAdapter.Fill(this.shopDBDataSet8.Tbl_Orderinfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_OrderInfo");
        }
        void cleardata()
        {
            txtorderid.Clear();
            txtname.Clear();
            txttype.Clear();
            txtquantity.Clear();
            txtprice.Clear();
            txttotal.Clear();

        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtorderid.Text = fn.GetAutoID("Select MAX(id) from Tbl_OrderInfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabaledFalse();
            cleardata();
            txtname.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtorderid.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                txtname.Text = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();
                txttype.Text = dataGridView1.SelectedRows[0].Cells["type"].Value.ToString();
                txtquantity.Text = dataGridView1.SelectedRows[0].Cells["qty"].Value.ToString();
                txtprice.Text = dataGridView1.SelectedRows[0].Cells["price"].Value.ToString();
                txttotal.Text = dataGridView1.SelectedRows[0].Cells["total"].Value.ToString();




                EnabaledFalse();
                btnupdate.Enabled = true;

                txtname.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void OrderInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtorderid.Text == "" || txtname.Text == "" || txttype.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_OrderInfo(id,name,type,qty,price,total) values(" + txtorderid.Text + ",'" + txtname.Text + "','" + txttype.Text + "', '" + txtquantity.Text + "', " + txtprice.Text + "," + txttotal.Text + ")");

            fn.FillGridData(dataGridView1, "Select * from Tbl_OrderInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtorderid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_OrderInfo set name='" + txtname.Text + "',type='" + txttype.Text + "',qty= '" + txtquantity.Text + "',price=" + txtprice.Text + ",total=" + txttotal.Text + " where id=" + txtorderid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_OrderInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Update Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btndalete_Click(object sender, EventArgs e)
        {
            if (txtorderid.Text == "" || txtname.Text == "" || txttype.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_OrderInfo Where id=" + txtorderid.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_OrderInfo");
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
            txtname.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttotal.Text = (double.Parse(txtquantity.Text) * double.Parse(txtprice.Text)).ToString();

            }
            catch { }
        }
    }
}
