namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    partial class GisMap
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
            base.WebBrowserShortcutsEnabled = false;
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private bool m_bMouseEnter;
    }
}