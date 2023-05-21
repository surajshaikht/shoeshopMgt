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
    public partial class Stock_ItemCr : Form
    {
        function fn = new function();
        public Stock_ItemCr()
        {
            InitializeComponent();
        }

        private void Stock_ItemCr_Load(object sender, EventArgs e)
        {
            stock("Select * from Tbl_StockInfo", fn.cn);
        }
        public void stock(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "Tbl_StockInfo");
            CrystalReportst cm = new CrystalReportst();
            cm.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cm;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
