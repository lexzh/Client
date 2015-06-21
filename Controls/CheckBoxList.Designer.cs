namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    partial class CheckBoxList
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
            this.pnlChk = new Panel();
            this.pnlChk.AutoSize = true;
            this.pnlChk.BackColor = Color.White;
            this.pnlChk.Dock = DockStyle.Top;
            this.pnlChk.Location = new Point(1, 1);
            this.pnlChk.Name = "pnlChk";
            this.pnlChk.Padding = new Padding(3, 0, 0, 0);
            this.pnlChk.Size = new Size(205, 0);
            this.pnlChk.TabIndex = 0;
            this.pnlChk.Tag = "9999";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = Color.White;
            base.BorderStyle =  System.Windows.Forms.BorderStyle.Fixed3D;
            base.Controls.Add(this.pnlChk);
            base.Name = "CheckBoxList";
            base.Padding = new Padding(1);
            base.Size = new Size(207, 154);
            base.Tag = "";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private Panel pnlChk;
    }
}