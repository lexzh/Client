namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    partial class AutoDropDown
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.dropDown != null))
            {
                this.dropDown.Dispose();
                this.dropDown = null;
            }
            base.Dispose(disposing);
        }

       
        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.Name = "AutoDropDown";
            base.Size = new Size(22, 15);
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private Control _con;
        private ToolStripDropDown dropDown;
        private ToolStripControlHost treeViewHost;
    }
}