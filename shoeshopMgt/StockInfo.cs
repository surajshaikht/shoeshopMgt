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
    public partial class StockInfo : Form
    {
        function fn = new function();
        public StockInfo()
        {
            InitializeComponent();
        }

        private void StockInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet5.Tbl_StockInfo' table. You can move, or remove it, as needed.
            this.tbl_StockInfoTableAdapter.Fill(this.shopDBDataSet5.Tbl_StockInfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_StockInfo");
        }
        void cleardata()
        {
            txtstockid.Clear();
            txttype.Clear();
            txtstockname.Clear();
            txtquantity.Clear();


        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtstockid.Text = fn.GetAutoID("Select MAX(Stock_Id) from Tbl_StockInfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {

            EnabaledFalse();
            cleardata();
            txtstockname.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtstockid.Text = dataGridView1.SelectedRows[0].Cells["Stock_Id"].Value.ToString();

                txttype.Text = dataGridView1.SelectedRows[0].Cells["Stock_Name"].Value.ToString();
                txtstockname.Text = dataGridView1.SelectedRows[0].Cells["Stock_Type"].Value.ToString();
                txtquantity.Text = dataGridView1.SelectedRows[0].Cells["Stock_Qty"].Value.ToString();




                EnabaledFalse();
                btnupdate.Enabled = true;

                txtstockname.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void StockInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtstockid.Text == "" || txttype.Text == "" || txtstockname.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_StockInfo(  Stock_Id, Stock_Name,Stock_Type,Stock_Qty) values(" + txtstockid.Text + ",'" + txtstockname.Text + "', '" + txttype.Text + "','" + txtquantity.Text + "')");

            fn.FillGridData(dataGridView1, "Select * from Tbl_StockInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtstockid.Text == "" || txtstockname.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_StockInfo set Stock_Name='" + txtstockname.Text + "',Stock_Type='" + txttype.Text + "',Stock_Qty= '" + txtquantity.Text + "' where Stock_Id=" + txtstockid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_StockInfo");
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
            txtstockname.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtstockid.Text == "" || txtstockname.Text == "" || txttype.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_StockInfo Where Stock_Id=" + txtstockid.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_StockInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Delete Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }
    }
}
