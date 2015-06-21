using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunisoft.IrisSkin;
using PublicClass;

namespace Client
{
    public partial class FixedForm : Form
    {
        public SkinEngine seSkin;
        public FixedForm()
        {
            InitializeComponent();
        }

        private void setFormHeight(Control control)
        {
            foreach (Control control1 in control.Controls)
            {
                if (control1.GetType() != typeof(GroupBox) && control1.GetType() != typeof(Panel))
                {
                    continue;
                }
                if (control1.Visible || "999".Equals(control1.Tag))
                {
                    this.setFormHeight(control1);
                }
                else
                {
                    //this.WindowState = FormWindowState.Normal;
                    if (!this.Equals(control))
                    {
                        control.Height -= control1.Height;
                    }
                    this.Height -= control1.Height;
                }
            }
        }

        private void FixedForm_Load(object sender, EventArgs e)
        {
            this.seSkin.SkinFile = Variable.sSkinFiles[int.Parse(Variable.sSkinDataIndex)];
            this.setFormHeight(this);
        }
    }
}
