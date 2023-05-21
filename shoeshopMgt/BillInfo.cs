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
    public partial class BillInfo : Form
    {
        function fn = new function();
        public BillInfo()
        {
            
            InitializeComponent();
        }

        private void BillInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet9.Tbl_BillInfo' table. You can move, or remove it, as needed.
            this.tbl_BillInfoTableAdapter.Fill(this.shopDBDataSet9.Tbl_BillInfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_BillInfo");
        }
        void cleardata()
        {
            txtbillno.Clear();
            txtcustid.Clear();
            txtcustname.Clear();
            txtshoetype.Clear();
            txtamount.Clear();
           

        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtbillno.Text = fn.GetAutoID("Select MAX(bill_no) from Tbl_BillInfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabaledFalse();
            cleardata();
            txtcustid.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtbillno.Text = dataGridView1.SelectedRows[0].Cells["bill_no"].Value.ToString();
                txtcustid.Text = dataGridView1.SelectedRows[0].Cells["cust_id"].Value.ToString();
                txtdate.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["date"].Value.ToString());
                txtcustname.Text = dataGridView1.SelectedRows[0].Cells["cust_name"].Value.ToString();
                txtshoetype.Text = dataGridView1.SelectedRows[0].Cells["shoe_type"].Value.ToString();
                txtamount.Text = dataGridView1.SelectedRows[0].Cells["amt"].Value.ToString();
            




                EnabaledFalse();
                btnupdate.Enabled = true;

                txtcustid.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void BillInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtbillno.Text == "" || txtcustid.Text == "" || txtcustname.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_BillInfo(bill_no,cust_id,date,cust_name,shoe_type,amt) values(" + txtbillno.Text + ",'" + txtcustid.Text + "','" + txtdate.Value.ToString("MM/dd/yyyy") + "', '" + txtcustname.Text + "', '" + txtshoetype.Text + "'," + txtamount.Text + ")");

            fn.FillGridData(dataGridView1, "Select * from Tbl_BillInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtbillno.Text == "" || txtcustid.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_BillInfo set cust_id='" + txtcustid.Text + "',date='" + txtdate.Value.ToString("MM/dd/yyyy") + "',cust_name= '" + txtcustname.Text + "',shoe_type='" + txtshoetype.Text + "',amt=" + txtamount.Text + " where bill_no=" + txtbillno.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_BillInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Update Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtbillno.Text == "" || txtcustid.Text == "" || txtcustname.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_BillInfo Where bill_no=" + txtbillno.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_BillInfo");
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
            txtcustid.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
