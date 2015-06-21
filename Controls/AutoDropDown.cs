namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public partial class AutoDropDown : UserControl
    {

        public event VisibleChanged VisibilityChange;

        public AutoDropDown()
        {
            this.InitializeComponent();
        }

        public AutoDropDown(Control con) : this()
        {
            this.treeViewHost = new ToolStripControlHost(con);
            this._con = con;
            this.dropDown = new ToolStripDropDown();
            this.dropDown.VisibleChanged += new EventHandler(this.dropDown_VisibleChanged);
            this.dropDown.Padding = con.Padding = new Padding(0);
            base.Visible = false;
            this.treeViewHost.AutoSize = false;
            this.dropDown.DefaultDropDownDirection = ToolStripDropDownDirection.Default;
            this.dropDown.Items.Add(this.treeViewHost);
            base.Controls.AddRange(new Control[] { con });
        }

 private void dropDown_VisibleChanged(object sender, EventArgs e)
        {
            this.OnVisibilityChange(this.dropDown.Visible);
        }

        public void HideDropDown()
        {
            this.dropDown.Hide();
        }

 private void OnVisibilityChange(bool isvisible)
        {
            if (this.VisibilityChange != null)
            {
                this.VisibilityChange(isvisible);
            }
        }

        public void ShowDropDown(Point location)
        {
            if (this.dropDown != null)
            {
                this.dropDown.Show(this, location.X, location.Y);
            }
        }

        public Control InnerControl
        {
            get
            {
                return this._con;
            }
        }
    }
}

