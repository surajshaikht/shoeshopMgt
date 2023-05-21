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
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void shopInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopInfo si = new ShopInfo();
            si.Show();
        }

        private void ownerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OwnerInfo oi = new OwnerInfo();
            oi.Show();
        }

        private void stockInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockInfo si = new StockInfo();
            si.Show();

        }

        private void employeeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeInfo ep = new EmployeeInfo();
            ep.Show();
        }

        private void customerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerInfo ci = new CustomerInfo();
            ci.Show();
        }

        private void supplierInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierInfo si = new SupplierInfo();
            si.Show();
        }

        private void materialInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderInfo oi = new OrderInfo();
            oi.Show();
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
           CustomerOrder co = new CustomerOrder();
            co.Show();
        }

        private void billInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillInfo bo = new BillInfo();
            bo.Show();
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emp_salary es = new emp_salary();
            es.Show();
        }

        private void yesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about_us au = new about_us();
            au.Show();
        }

        private void transcationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createdByToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            created_by cb = new created_by();
            cb.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_ItemCr sic = new Stock_ItemCr();
            sic.Show();
        }

        private void supplierOrderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplierorderCr soc = new supplierorderCr();
            soc.Show();
        }

        private void stockDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empsalaryCr esc = new empsalaryCr();
            esc.Show();
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerBillCr abc = new CustomerBillCr();
            abc.Show();
        }
    }
}

