using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace shoeshopMgt
{
    class function
    {
        public SqlConnection cn;

        public function()
        {
            cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\CurrentProject\CS\shoeshopMgt\shoeshopMgt\shopDB.mdf;Integrated Security=True;User Instance=True");
            cn.Open();
        }

        public DataTable GettableData(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public int GetAutoID(string sql)
        {
            int i = 1;

            try
            {
                DataTable dt = GettableData(sql);
                if (dt.Rows.Count >= 1)
                {
                    i = (int.Parse(dt.Rows[0][0].ToString()) + 1);
                }
                else
                    i = 1;

            }
            catch
            {
                i = 1;
            }

            return i;
        }

        public void ExecuteSqlQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

        }

        public void FillGridData(DataGridView dv, string sql)
        {
            DataTable dt = GettableData(sql);
            dv.DataSource = dt;

        }

        public bool FillListView(ListView lv, string sql)
        {
            DataTable dt = GettableData(sql);
            if (dt.Rows.Count > 0)
            {
                String[] s = new string[dt.Columns.Count];
                lv.GridLines = true;
                lv.MultiSelect = false;
                lv.FullRowSelect = true;

                lv.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        s[i] = dr[i].ToString();
                    }
                    lv.Items.Add(new ListViewItem(s));

                }
            }
            else
            {
                return false;
            }
            return true;

        }
        public void FillCombo(ComboBox cb, string sql, string dismemb, string val)
        {
            DataTable dt = GettableData(sql);

            cb.ValueMember = val;
            cb.DisplayMember = dismemb;
            cb.DataSource = dt;

        }
    }
}
