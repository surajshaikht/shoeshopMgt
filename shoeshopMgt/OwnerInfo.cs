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
    public partial class OwnerInfo : Form
    {
        function fn = new function();
        public OwnerInfo()
        {
            InitializeComponent();
        }

        private void OwnerInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet3.Tbl_Ownerinfo' table. You can move, or remove it, as needed.
            this.tbl_OwnerinfoTableAdapter.Fill(this.shopDBDataSet3.Tbl_Ownerinfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_Ownerinfo");
        }
        void cleardata()
        {
            txtownerid.Clear();
            txtownername.Clear();
            txtowneremailid.Clear();
            txtownercontno.Clear();
          

        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtownerid.Text = fn.GetAutoID("Select MAX(Owner_Id) from Tbl_Ownerinfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabaledFalse();
            cleardata();
            txtownername.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtownerid.Text = dataGridView1.SelectedRows[0].Cells["Owner_Id"].Value.ToString();
                txtdob.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["Owner_DOB"].Value.ToString());
                txtownername.Text = dataGridView1.SelectedRows[0].Cells["Owner_Name"].Value.ToString();
                txtowneremailid.Text = dataGridView1.SelectedRows[0].Cells["Owner_Email_Id"].Value.ToString();
                txtownercontno.Text = dataGridView1.SelectedRows[0].Cells["Owner_Cont_no"].Value.ToString();




                EnabaledFalse();
                btnupdate.Enabled = true;

                txtownername.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void OwnerInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtownerid.Text == "" || txtownername.Text == "" || txtownercontno.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_Ownerinfo(  Owner_Id, Owner_Name,Owner_DOB,Owner_Email_Id,Owner_Cont_no) values(" + txtownerid.Text + ",'" + txtownername.Text + "','" + txtdob.Value.ToString("MM/dd/yyyy") + "', '"+ txtowneremailid.Text +"','" + txtownercontno.Text + "')");

            fn.FillGridData(dataGridView1, "Select * from Tbl_Ownerinfo");
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
            txtownername.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtownerid.Text == "" || txtownername.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_Ownerinfo set Owner_Name='" + txtownername.Text + "',Owner_DOB='" + txtdob.Value.ToString("MM/dd/yyyy") + "',Owner_Email_Id='" + txtowneremailid.Text + "',Owner_Cont_no= '" + txtownercontno.Text + "' where Owner_Id=" + txtownerid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_Ownerinfo");
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

          