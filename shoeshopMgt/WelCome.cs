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
    public partial class WelCome : Form
    {
        public WelCome()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            MDI md = new MDI();
            md.Show();
        }
    }
}
