namespace WinFormsUI.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class WindowManager
    {
        private TabControl _tabControl;

        public event EventHandler<CommandStateEventArgs> CommandStateChanged;

        public event EventHandler<TextChangedEventArgs> StatusTextChanged;

        public WindowManager(TabControl tabControl)
        {
            this._tabControl = tabControl;
            this._tabControl.SelectedIndexChanged += new EventHandler(this.tabControl_SelectedIndexChanged);
        }

        private static BrowserControl BrowserControlFromBrowser(ExtendedWebBrowser browser)
        {
            if (browser == null)
            {
                return null;
            }
            if (browser.Parent == null)
            {
                return null;
            }
            return (browser.Parent.Parent as BrowserControl);
        }

        private void CheckCommandState()
        {
            BrowserCommands none = BrowserCommands.None;
            if (this.ActiveBrowser != null)
            {
                if (this.ActiveBrowser.CanGoBack)
                {
                    none |= BrowserCommands.Back;
                }
                if (this.ActiveBrowser.CanGoForward)
                {
                    none |= BrowserCommands.Forward;
                }
                if (this.ActiveBrowser.IsBusy)
                {
                    none |= BrowserCommands.Stop;
                }
                none |= BrowserCommands.Home;
                none |= BrowserCommands.Search;
                none |= BrowserCommands.Print;
                none |= BrowserCommands.PrintPreview;
                none |= BrowserCommands.Reload;
            }
            this.OnCommandStateChanged(new CommandStateEventArgs(none));
        }

        public void Close()
        {
            TabPage selectedTab = this._tabControl.SelectedTab;
            if (selectedTab != null)
            {
                this._tabControl.TabPages.Remove(selectedTab);
                selectedTab.Dispose();
            }
            if (this._tabControl.TabPages.Count == 0)
            {
                this._tabControl.Visible = false;
            }
        }

        public ExtendedWebBrowser New()
        {
            return this.New(true);
        }

        public ExtendedWebBrowser New(bool navigateHome)
        {
            TabPage page = new TabPage();
            BrowserControl control = new BrowserControl {
                Tag = page
            };
            page.Tag = control;
            page.Text = "正在加载中...";
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
            if (navigateHome)
            {
                control.WebBrowser.GoHome();
            }
            control.WebBrowser.StatusTextChanged += new EventHandler(this.WebBrowser_StatusTextChanged);
            control.WebBrowser.DocumentTitleChanged += new EventHandler(this.WebBrowser_DocumentTitleChanged);
            control.WebBrowser.CanGoBackChanged += new EventHandler(this.WebBrowser_CanGoBackChanged);
            control.WebBrowser.CanGoForwardChanged += new EventHandler(this.WebBrowser_CanGoForwardChanged);
            control.WebBrowser.Navigated += new WebBrowserNavigatedEventHandler(this.WebBrowser_Navigated);
            control.WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
            control.WebBrowser.Quit += new EventHandler(this.WebBrowser_Quit);
            this._tabControl.TabPages.Add(page);
            this._tabControl.SelectedTab = page;
            this._tabControl.Visible = true;
            return control.WebBrowser;
        }

        protected virtual void OnCommandStateChanged(CommandStateEventArgs e)
        {
            if (this.CommandStateChanged != null)
            {
                this.CommandStateChanged(this, e);
            }
        }

        protected virtual void OnStatusTextChanged(TextChangedEventArgs e)
        {
            if (this.StatusTextChanged != null)
            {
                this.StatusTextChanged(this, e);
            }
        }

        public void Open(Uri url)
        {
            this.New(false).Navigate(url);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckCommandState();
        }

        private void WebBrowser_CanGoBackChanged(object sender, EventArgs e)
        {
            this.CheckCommandState();
        }

        private void WebBrowser_CanGoForwardChanged(object sender, EventArgs e)
        {
            this.CheckCommandState();
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.CheckCommandState();
        }

        private void WebBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            ExtendedWebBrowser browser = sender as ExtendedWebBrowser;
            if (browser != null)
            {
                BrowserControl control = BrowserControlFromBrowser(browser);
                if (control != null)
                {
                    TabPage tag = control.Tag as TabPage;
                    if (tag != null)
                    {
                        string documentTitle = browser.DocumentTitle;
                        if (string.IsNullOrEmpty(documentTitle))
                        {
                            documentTitle = "about:blank";
                        }
                        else if (documentTitle.Length > 30)
                        {
                            documentTitle = documentTitle.Substring(0, 30) + "...";
                        }
                        tag.Text = documentTitle;
                        tag.ToolTipText = browser.DocumentTitle;
                    }
                }
            }
        }

        private void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.CheckCommandState();
        }

        private void WebBrowser_Quit(object sender, EventArgs e)
        {
            ExtendedWebBrowser browser = sender as ExtendedWebBrowser;
            if (browser != null)
            {
                BrowserControl control = BrowserControlFromBrowser(browser);
                if (control != null)
                {
                    TabPage tag = control.Tag as TabPage;
                    if (tag != null)
                    {
                        this._tabControl.TabPages.Remove(tag);
                        tag.Dispose();
                        if (this._tabControl.TabPages.Count == 0)
                        {
                            this._tabControl.Visible = false;
                        }
                    }
                }
            }
        }

        private void WebBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            ExtendedWebBrowser browser = sender as ExtendedWebBrowser;
            if (browser != null)
            {
                TabPage tag = BrowserControlFromBrowser(browser).Tag as TabPage;
                if ((tag != null) && (this._tabControl.SelectedTab == tag))
                {
                    this.OnStatusTextChanged(new TextChangedEventArgs(browser.StatusText));
                }
            }
        }

        public ExtendedWebBrowser ActiveBrowser
        {
            get
            {
                TabPage selectedTab = this._tabControl.SelectedTab;
                if (selectedTab != null)
                {
                    BrowserControl tag = selectedTab.Tag as BrowserControl;
                    if (tag != null)
                    {
                        return tag.WebBrowser;
                    }
                }
                return null;
            }
        }
    }
}

