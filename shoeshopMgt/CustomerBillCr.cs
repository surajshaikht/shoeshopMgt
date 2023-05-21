using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace shoeshopMgt
{
    public partial class CustomerBillCr : Form
    {
        function fn = new function();
        public CustomerBillCr()
        {
            InitializeComponent();
        }

        private void CustomerBillCr_Load(object sender, EventArgs e)
        {
            bill("Select * from Tbl_BillInfo", fn.cn);
        }
        public void bill(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "Tbl_BillInfo");
            CrystalReportcb cm = new CrystalReportcb();
            cm.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cm;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
