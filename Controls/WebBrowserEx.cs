namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class WebBrowserEx : UserControl
    {

        public WebBrowserEx()
        {
            this.InitializeComponent();
            this._windowManager = new WinFormsUI.Controls.WindowManager(this.tabControl1);
        }

 public void Open(string Url)
        {
            this._windowManager.Open(new Uri(Url));
        }

        private void WebBrowserEx_Load(object sender, EventArgs e)
        {
        }

        public WinFormsUI.Controls.WindowManager WindowManager
        {
            get
            {
                return this._windowManager;
            }
        }
    }
}

