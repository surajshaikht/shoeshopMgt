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
    public partial class SupplierInfo : Form
    {
        function fn = new function();
        public SupplierInfo()
        {
           
            InitializeComponent();
        }

        private void SupplierInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet7.Tbl_SuppInfo' table. You can move, or remove it, as needed.
            this.tbl_SuppInfoTableAdapter.Fill(this.shopDBDataSet7.Tbl_SuppInfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_SuppInfo");
        }
        void cleardata()
        {
            txtsupplierid.Clear();
            txtsuppliername.Clear();
            txtsupplieraddress.Clear();
            txtsupplierconno.Clear();
            txtsupplieremailid.Clear();

        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtsupplierid.Text = fn.GetAutoID("Select MAX(id) from Tbl_SuppInfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabaledFalse();
            cleardata();
            txtsuppliername.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtsupplierid.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                txtsuppliername.Text = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();
                txtdob.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["dob"].Value.ToString());
                txtsupplieraddress.Text = dataGridView1.SelectedRows[0].Cells["address"].Value.ToString();
                txtsupplierconno.Text = dataGridView1.SelectedRows[0].Cells["contno"].Value.ToString();
                txtsupplieremailid.Text = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();




                EnabaledFalse();
                btnupdate.Enabled = true;

                txtsuppliername.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void SupplierInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsupplierid.Text == "" || txtsuppliername.Text == "" || txtsupplieraddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_SuppInfo(  id, name,dob,address,contno,email) values(" + txtsupplierid.Text + ",'" + txtsuppliername.Text + "','" + txtdob.Value.ToString("MM/dd/yyyy") + "', '" + txtsupplieraddress.Text + "', " + txtsupplierconno.Text + ",'" + txtsupplieremailid.Text + "')");

            fn.FillGridData(dataGridView1, "Select * from Tbl_SuppInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtsupplierid.Text == "" || txtsuppliername.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_SuppInfo set name='" + txtsuppliername.Text + "',dob='" + txtdob.Value.ToString("MM/dd/yyyy") + "',address= '" + txtsupplieraddress.Text + "',contno=" + txtsupplierconno.Text + ",email='" + txtsupplieremailid.Text + "'  where id=" + txtsupplierid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_SuppInfo");
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
            txtsuppliername.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtsupplierid.Text == "" || txtsuppliername.Text == "" || txtsupplieraddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_SuppInfo Where id=" + txtsupplierid.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_SuppInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Delete Data sucessfully..");
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
