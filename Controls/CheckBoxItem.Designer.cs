namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class CheckBoxItem
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
            this.BackColor = Color.White;
            base.Size = new Size(150, 20);
            base.Tag = "9999";
            base.UseVisualStyleBackColor = false;
            base.ResumeLayout(false);
        }

       
        private IContainer components;
    }
}