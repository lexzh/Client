namespace WinFormsUI.Controls
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using WinFormsUI.Properties;

    partial class ThreeStateTreeView
    {

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.BorderStyle =  System.Windows.Forms.BorderStyle.FixedSingle;
            base.HideSelection = false;
            base.LineColor = Color.Black;
            base.ResumeLayout(false);
        }

       
        private TreeNode currentNode;
        private bool MulSelected;
    }
}