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
    public partial class EmployeeInfo : Form
    {
        function fn = new function();
        public EmployeeInfo()
        {
           
            InitializeComponent();
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet1.Tbl_EmpInfo' table. You can move, or remove it, as needed.
            this.tbl_EmpInfoTableAdapter.Fill(this.shopDBDataSet1.Tbl_EmpInfo);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpInfo");
        }
        void cleardata()
        {
            txtemployeeid.Clear();
            txtemployeename.Clear();
            txtaddress.Clear();
            txtemployeecontno.Clear();
            txtemployeeemailid.Clear();

        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtemployeeid.Text = fn.GetAutoID("Select MAX(emp_id) from Tbl_EmpInfo").ToString();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabaledFalse();
            cleardata();
            txtemployeename.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }
        void GridDataDisplay()
        {
            try
            {
                txtemployeeid.Text = dataGridView1.SelectedRows[0].Cells["emp_id"].Value.ToString();
                txtemployeename.Text = dataGridView1.SelectedRows[0].Cells["emp_name"].Value.ToString();
                txtdob.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["emp_dob"].Value.ToString());
                txtaddress.Text = dataGridView1.SelectedRows[0].Cells["emp_add"].Value.ToString();
                txtemployeecontno.Text = dataGridView1.SelectedRows[0].Cells["emp_contno"].Value.ToString();
                txtemployeeemailid.Text = dataGridView1.SelectedRows[0].Cells["emp_email"].Value.ToString();




                EnabaledFalse();
                btnupdate.Enabled = true;

                txtemployeename.Focus();
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridDataDisplay();
        }

        private void EmployeeInfo_Activated(object sender, EventArgs e)
        {
            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtemployeeid.Text == "" || txtemployeename.Text == "" || txtaddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_EmpInfo(  emp_id, emp_name,emp_dob,emp_add,emp_contno,emp_email) values(" + txtemployeeid.Text + ",'" + txtemployeename.Text + "','" + txtdob.Value.ToString("MM/dd/yyyy") + "', '" + txtaddress.Text + "', " + txtemployeecontno.Text + ",'" + txtemployeeemailid.Text + "')");

            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpInfo");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtemployeeid.Text == "" || txtemployeename.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_EmpInfo set emp_name='" + txtemployeename.Text + "',emp_dob='" + txtdob.Value.ToString("MM/dd/yyyy") + "',emp_add= '" + txtaddress.Text + "',emp_contno=" + txtemployeecontno.Text + ",emp_email='" + txtemployeeemailid.Text + "'  where emp_id=" + txtemployeeid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpInfo");
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
            txtemployeename.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btndalete_Click(object sender, EventArgs e)
        {
            if (txtemployeeid.Text == "" || txtemployeename.Text == "" || txtaddress.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_EmpInfo Where emp_id=" + txtemployeeid.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpInfo");
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
