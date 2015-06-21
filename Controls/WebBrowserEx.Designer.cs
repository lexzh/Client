namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class WebBrowserEx
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

       
 private void InitializeComponent()
        {
            base.SuspendLayout();
            this.tabControl1 = new TabControl();
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(621, 442);
            this.tabControl1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tabControl1);
            base.Name = "WebBrowserEx";
            base.Size = new Size(621, 442);
            base.Load += new EventHandler(this.WebBrowserEx_Load);
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private WinFormsUI.Controls.WindowManager _windowManager;
        private TabControl tabControl1;
    }
}