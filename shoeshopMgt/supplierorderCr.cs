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
    public partial class supplierorderCr : Form
    {
        function fn = new function();
        public supplierorderCr()
        {
            InitializeComponent();
        }

        private void supplierorderCr_Load(object sender, EventArgs e)
        {
            supp("Select * from Tbl_Orderinfo", fn.cn);
        }
        public void supp(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "Tbl_Orderinfo");
            CrystalReportso cm = new CrystalReportso();
            cm.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cm;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
