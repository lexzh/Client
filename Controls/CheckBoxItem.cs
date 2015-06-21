namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CheckBoxItem : CheckBox
    {
        public object oArgs = new object();

        public CheckBoxItem()
        {
            this.InitializeComponent();
        }

 public object Args
        {
            get
            {
                return this.oArgs;
            }
            set
            {
                this.oArgs = value;
            }
        }
    }
}

