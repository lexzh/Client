namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal partial class BrowserControl : UserControl
    {

        public BrowserControl()
        {
            this.InitializeComponent();
            this._browser = new ExtendedWebBrowser();
            this._browser.Dock = DockStyle.Fill;
            this._browser.DownloadComplete += new EventHandler(this._browser_DownloadComplete);
            this._browser.Navigated += new WebBrowserNavigatedEventHandler(this._browser_Navigated);
            this._browser.StartNewWindow += new EventHandler<BrowserExtendedNavigatingEventArgs>(this._browser_StartNewWindow);
            this._browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this._browser_DocumentCompleted);
            this.containerPanel.Controls.Add(this._browser);
            ((Bitmap) this.goButton.Image).MakeTransparent(Color.Magenta);
        }

        private void _browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.UpdateAddressBox();
        }

        private void _browser_DownloadComplete(object sender, EventArgs e)
        {
            if (this.WebBrowser.Document != null)
            {
                this.WebBrowser.Document.Window.Error += new HtmlElementErrorEventHandler(this.Window_Error);
                this.UpdateAddressBox();
            }
        }

        private void _browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.UpdateAddressBox();
        }

        private void _browser_StartNewWindow(object sender, BrowserExtendedNavigatingEventArgs e)
        {
            WebBrowserEx mainFormFromControl = GetMainFormFromControl(sender as Control);
            if (mainFormFromControl != null)
            {
                bool flag = (e.NavigationContext == UrlContext.None) || ((e.NavigationContext & UrlContext.OverrideKey) == UrlContext.OverrideKey);
                if (!flag)
                {
                    flag = true;
                }
                if (flag)
                {
                    if ((e.NavigationContext & UrlContext.HtmlDialog) != UrlContext.HtmlDialog)
                    {
                        ExtendedWebBrowser browser = mainFormFromControl.WindowManager.New(false);
                        e.AutomationObject = browser.Application;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void addressTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.Navigate();
            }
        }

 private static WebBrowserEx GetMainFormFromControl(Control control)
        {
            while (control != null)
            {
                if (control is WebBrowserEx)
                {
                    break;
                }
                control = control.Parent;
            }
            return (control as WebBrowserEx);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.Navigate();
        }

 private void Navigate()
        {
            this.WebBrowser.Navigate(this.addressTextBox.Text);
        }

        private void UpdateAddressBox()
        {
            string str = this.WebBrowser.Document.Url.ToString();
            if (!str.Equals(this.addressTextBox.Text, StringComparison.InvariantCultureIgnoreCase))
            {
                this.addressTextBox.Text = str;
            }
        }

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            ScriptErrorManager.Instance.RegisterScriptError(e.Url, e.Description, e.LineNumber);
            e.Handled = true;
        }

        public ExtendedWebBrowser WebBrowser
        {
            get
            {
                return this._browser;
            }
        }
    }
}

