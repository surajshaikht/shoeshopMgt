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
    public partial class ShopInfo : Form
    {
        function fn = new function();
        public ShopInfo()
        {
            InitializeComponent();
        }

        private void ShopInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet4.Tbl_ShopInfo' table. You can move, or remove it, as needed.
            this.tbl_ShopInfoTableAdapter.Fill(this.shopDBDataSet4.Tbl_ShopInfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_ShopInfo");
        }
        void cleardata()
        {
           txtshopid.Clear();
            txtshopname.Clear();
            txtaddress.Clear();
            txtcontno.Clear();
           
        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;
          

        }
        void GetmaxID()
        {
            txtshopid.Text = fn.GetAutoID("Select MAX(Shop_Id) from Tbl_ShopInfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabaledFalse();
            cleardata();
            txtshopname.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtshopid.Text = dataGridView1.SelectedRows[0].Cells["Shop_Id"].Value.ToString();
               
                txtshopname.Text = dataGridView1.SelectedRows[0].Cells["Shop_Name"].Value.ToString();
                txtaddress.Text = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
                txtcontno.Text = dataGridView1.SelectedRows[0].Cells["Contact_No"].Value.ToString();
                



                EnabaledFalse();
                btnupdate.Enabled = true;

                txtshopname.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void ShopInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtshopid.Text == "" || txtshopname.Text == "" || txtaddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_ShopInfo(  Shop_Id, Shop_Name,Address,Contact_No) values(" + txtshopid.Text + ",'" + txtshopname.Text  + "','" + txtaddress.Text + "'," + txtcontno.Text + ")");

            fn.FillGridData(dataGridView1, "Select * from Tbl_ShopInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cleardata();
            txtshopname.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtshopid.Text == "" || txtshopname.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_ShopInfo set Shop_Name='" + txtshopname.Text + "',Address='" + txtaddress.Text + "',Contact_No=" + txtcontno.Text + " where Shop_Id=" + txtshopid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_ShopInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Update Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
