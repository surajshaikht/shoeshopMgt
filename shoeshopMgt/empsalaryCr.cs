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
    public partial class empsalaryCr : Form
    {
        function fn = new function();
        public empsalaryCr()
        {
            InitializeComponent();
        }

        private void empsalaryCr_Load(object sender, EventArgs e)
        {
            salary("Select * from Tbl_EmpSalary", fn.cn);
        }
        public void salary(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "Tbl_EmpSalary");
            CrystalReportes cm = new CrystalReportes();
            cm.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cm;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
