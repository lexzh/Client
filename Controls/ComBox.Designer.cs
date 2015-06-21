namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Windows.Forms;

    partial class ComBox
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
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.FlatStyle =  System.Windows.Forms.FlatStyle.Flat;
            base.ResumeLayout(false);
        }
    
        private IContainer components;
    }
}