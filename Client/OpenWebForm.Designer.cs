namespace Client
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class OpenWebForm
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
            this.webBrowserEx1 = new WebBrowserEx();
            base.SuspendLayout();
            this.webBrowserEx1.Dock = DockStyle.Fill;
            this.webBrowserEx1.Location = new Point(0, 0);
            this.webBrowserEx1.Name = "webBrowserEx1";
            this.webBrowserEx1.Size = new Size(663, 502);
            this.webBrowserEx1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(663, 502);
            base.Controls.Add(this.webBrowserEx1);
            base.Name = "OpenWebForm";
            this.Text = "OpenWebForm";
            base.ResumeLayout(false);
        }
    
        private IContainer components;
        private WinFormsUI.Controls.WebBrowserEx webBrowserEx1;
    }
}