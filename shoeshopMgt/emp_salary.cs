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
    public partial class emp_salary : Form
    {

        function fn = new function();
        public emp_salary()
        {
            InitializeComponent();
        }

        private void emp_salary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDBDataSet10.Tbl_EmpSalary' table. You can move, or remove it, as needed.
            this.tbl_EmpSalaryTableAdapter.Fill(this.shopDBDataSet10.Tbl_EmpSalary);
            cleardata();
            btnnew.Focus();
            EnabaledFalse();
            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpSalary");
        }
        void cleardata()
        {
            txtsalaryid.Clear();
            txtemployeename.Clear();
            txtsalaryamount.Clear();
            


        }
        void EnabaledFalse()
        {
            btnsave.Enabled = false;
            btnupdate.Enabled = false;


        }
        void GetmaxID()
        {
            txtsalaryid.Text = fn.GetAutoID("Select MAX(Salary_Id) from Tbl_EmpSalary").ToString();
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
                txtsalaryid.Text = dataGridView1.SelectedRows[0].Cells["Salary_Id"].Value.ToString();
                txtemployeename.Text = dataGridView1.SelectedRows[0].Cells["Employee_Name"].Value.ToString();
                txtdate.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["Date"].Value.ToString());
                txtsalaryamount.Text = dataGridView1.SelectedRows[0].Cells["Salary_Amount"].Value.ToString();
                




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

        private void emp_salary_Activated(object sender, EventArgs e)
        {

            btnnew.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsalaryid.Text == "" || txtemployeename.Text == "" || txtsalaryamount.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }


            fn.ExecuteSqlQuery("Insert into Tbl_EmpSalary(Salary_Id,Employee_Name,Date,Salary_Amount) values(" + txtsalaryid.Text + ",'" + txtemployeename.Text + "','" + txtdate.Value.ToString("MM/dd/yyyy") + "', '" + txtsalaryamount.Text + "')");

            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpSalary");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Save Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtsalaryid.Text == "" || txtemployeename.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            fn.ExecuteSqlQuery("update Tbl_EmpSalary set Employee_Name='" + txtemployeename.Text + "',Date='" + txtdate.Value.ToString("MM/dd/yyyy") + "',Salary_Amount= " + txtsalaryamount.Text + " where Salary_Id=" + txtsalaryid.Text);
            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpSalary");
            EnabaledFalse();

            btnnew.Focus();
            MessageBox.Show("Update Data sucessfully..");
            btnsave.Enabled = true;
            cleardata();
            GetmaxID();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtsalaryid.Text == "" || txtemployeename.Text == "" || txtsalaryamount.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fn.ExecuteSqlQuery("Delete from Tbl_EmpSalary Where Salary_Id=" + txtsalaryid.Text);
            }



            fn.FillGridData(dataGridView1, "Select * from Tbl_EmpSalary");
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
            txtsalaryid.Focus();
            btnsave.Enabled = true;
            GetmaxID();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
