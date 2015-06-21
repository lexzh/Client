namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Security;
    using System.Windows.Forms;

    public class WebSystem
    {
        private MainForm _main;
        private WebBrowser _web;
        private Dictionary<string, string> _webButton;

        private WebSystem()
        {
            this._webButton = new Dictionary<string, string>();
        }

        public WebSystem(MainForm main) : this()
        {
            this._main = main;
        }

        public void GotoWeb(string url)
        {
            if (this._web == null)
            {
                WebBrowser browser = new WebBrowser {
                    Dock = DockStyle.Fill,
                    IsWebBrowserContextMenuEnabled = false,
                    Name = "webSystemWebBrowser"
                };
                this._web = browser;
                this._web.Navigate(url + string.Format("?workid={0}&user={1}&pwd={2}", RemotingClient.m_iWorkId, HttpUtility.UrlEncode(Variable.sUserId), FormsAuthentication.HashPasswordForStoringInConfigFile(Variable.sPassword, "MD5")));
                this._web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
                this._main.Controls.Add(this._web);
            }
            this._main.SetAllControlVisible(false, "webSystemWebBrowser");
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this._web.Url.ToString();
            WebBrowser browser = sender as WebBrowser;
            if (browser.Document.GetElementById("Tracking") != null)
            {
                this._webButton["Tracking"] = "";
                browser.Document.GetElementById("Tracking").Click -= new HtmlElementEventHandler(this.WebSystem_Click1);
                browser.Document.GetElementById("Tracking").Click += new HtmlElementEventHandler(this.WebSystem_Click1);
            }
            if (browser.Document.GetElementById("loadsuccess") != null)
            {
                this._webButton["loadsuccess"] = "";
                browser.Document.GetElementById("loadsuccess").Click -= new HtmlElementEventHandler(this.WebSystem_Click);
                browser.Document.GetElementById("loadsuccess").Click += new HtmlElementEventHandler(this.WebSystem_Click);
            }
        }

        private void WebSystem_Click(object sender, HtmlElementEventArgs e)
        {
            this._main.LoadWebSystem.Set();
            WaitForm.Hide();
        }

        private void WebSystem_Click1(object sender, HtmlElementEventArgs e)
        {
            this._main.SetAllControlVisible(true, "webSystemWebBrowser");
        }

        public WebBrowser Web
        {
            get
            {
                return this._web;
            }
            set
            {
                this._web = value;
            }
        }
    }
}

