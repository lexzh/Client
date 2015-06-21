using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class About : Client.FixedForm
    {
        public About()
        {
            InitializeComponent();
            lblVersion.Text = "V" + Application.ProductVersion;
        }

        private void About1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001b')
            {
                base.Close();
            }
        }

        private void About1_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
