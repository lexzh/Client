namespace Client
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class OpenWebForm : FixedForm
    {

        private OpenWebForm()
        {
            this.InitializeComponent();
        }

        public OpenWebForm(string Url) : this()
        {
            this.webBrowserEx1.Open(Url);
        }


    }
}