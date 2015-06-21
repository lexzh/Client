namespace WinFormsUI.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Windows.Forms;

    public class ExtendedWebBrowser : WebBrowser
    {
        private WinFormsUI.Controls.UnsafeNativeMethods.IWebBrowser2 axIWebBrowser2;
        private AxHost.ConnectionPointCookie cookie;
        private WebBrowserExtendedEvents events;

        public event EventHandler DownloadComplete;

        public event EventHandler Downloading;

        public event EventHandler Quit;

        public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNavigate;

        public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNewWindow;

        [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void AttachInterfaces(object nativeActiveXObject)
        {
            this.axIWebBrowser2 = (WinFormsUI.Controls.UnsafeNativeMethods.IWebBrowser2) nativeActiveXObject;
            base.AttachInterfaces(nativeActiveXObject);
        }

        [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void CreateSink()
        {
            base.CreateSink();
            this.events = new WebBrowserExtendedEvents(this);
            this.cookie = new AxHost.ConnectionPointCookie(base.ActiveXInstance, this.events, typeof(WinFormsUI.Controls.UnsafeNativeMethods.DWebBrowserEvents2));
        }

        [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void DetachInterfaces()
        {
            this.axIWebBrowser2 = null;
            base.DetachInterfaces();
        }

        [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void DetachSink()
        {
            if (this.cookie != null)
            {
                this.cookie.Disconnect();
                this.cookie = null;
            }
        }

        protected virtual void OnDownloadComplete(EventArgs e)
        {
            if (this.DownloadComplete != null)
            {
                this.DownloadComplete(this, e);
            }
        }

        protected void OnDownloading(EventArgs e)
        {
            if (this.Downloading != null)
            {
                this.Downloading(this, e);
            }
        }

        protected void OnQuit()
        {
            EventHandler quit = this.Quit;
            if (quit != null)
            {
                quit(this, EventArgs.Empty);
            }
        }

        protected void OnStartNavigate(BrowserExtendedNavigatingEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            if (this.StartNavigate != null)
            {
                this.StartNavigate(this, e);
            }
        }

        protected void OnStartNewWindow(BrowserExtendedNavigatingEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            if (this.StartNewWindow != null)
            {
                this.StartNewWindow(this, e);
            }
        }

        [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 528)
            {
                int num2 = m.WParam.ToInt32() & 65535;
                if (num2 == 2)
                {
                    this.OnQuit();
                }
            }
            base.WndProc(ref m);
        }

        public object Application
        {
            get
            {
                return this.axIWebBrowser2.Application;
            }
        }

        private class WebBrowserExtendedEvents : WinFormsUI.Controls.UnsafeNativeMethods.DWebBrowserEvents2
        {
            private ExtendedWebBrowser _Browser;

            public WebBrowserExtendedEvents()
            {
            }

            public WebBrowserExtendedEvents(ExtendedWebBrowser browser)
            {
                this._Browser = browser;
            }

            public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
            {
                Uri url = new Uri(URL.ToString());
                string frame = null;
                if (targetFrameName != null)
                {
                    frame = targetFrameName.ToString();
                }
                BrowserExtendedNavigatingEventArgs e = new BrowserExtendedNavigatingEventArgs(pDisp, url, frame, UrlContext.None);
                this._Browser.OnStartNavigate(e);
                cancel = e.Cancel;
                pDisp = e.AutomationObject;
            }

            public void ClientToHostWindow(ref int CX, ref int CY)
            {
            }

            public void CommandStateChange(int Command, bool Enable)
            {
            }

            public void DocumentComplete(object pDisp, ref object URL)
            {
            }

            public void DownloadBegin()
            {
                this._Browser.OnDownloading(EventArgs.Empty);
            }

            public void DownloadComplete()
            {
                this._Browser.OnDownloadComplete(EventArgs.Empty);
            }

            public void FileDownload(ref bool cancel)
            {
            }

            public void NavigateComplete2(object pDisp, ref object URL)
            {
            }

            public void NavigateError(object pDisp, ref object URL, ref object frame, ref object statusCode, ref bool cancel)
            {
            }

            public void NewWindow2(ref object pDisp, ref bool cancel)
            {
                BrowserExtendedNavigatingEventArgs e = new BrowserExtendedNavigatingEventArgs(pDisp, null, null, UrlContext.None);
                this._Browser.OnStartNewWindow(e);
                cancel = e.Cancel;
                pDisp = e.AutomationObject;
            }

            public void NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
            {
                BrowserExtendedNavigatingEventArgs e = new BrowserExtendedNavigatingEventArgs(ppDisp, new Uri(bstrUrl), null, (UrlContext) dwFlags);
                this._Browser.OnStartNewWindow(e);
                Cancel = e.Cancel;
                ppDisp = e.AutomationObject;
            }

            public void OnFullScreen(bool fullScreen)
            {
            }

            public void OnMenuBar(bool menuBar)
            {
            }

            public void OnQuit()
            {
            }

            public void OnStatusBar(bool statusBar)
            {
            }

            public void OnTheaterMode(bool theaterMode)
            {
            }

            public void OnToolBar(bool toolBar)
            {
            }

            public void OnVisible(bool visible)
            {
            }

            public void PrintTemplateInstantiation(object pDisp)
            {
            }

            public void PrintTemplateTeardown(object pDisp)
            {
            }

            public void PrivacyImpactedStateChange(bool bImpacted)
            {
            }

            public void ProgressChange(int progress, int progressMax)
            {
            }

            public void PropertyChange(string szProperty)
            {
            }

            public void SetSecureLockIcon(int secureLockIcon)
            {
            }

            public void StatusTextChange(string text)
            {
            }

            public void TitleChange(string text)
            {
            }

            public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
            {
            }

            [DispId(263)]
            public void WindowClosing(bool isChildWindow, ref bool cancel)
            {
            }

            public void WindowSetHeight(int height)
            {
            }

            public void WindowSetLeft(int left)
            {
            }

            public void WindowSetResizable(bool resizable)
            {
            }

            public void WindowSetTop(int top)
            {
            }

            public void WindowSetWidth(int width)
            {
            }
        }

        private enum WindowsMessages
        {
            WM_ACTIVATE = 6,
            WM_ACTIVATEAPP = 28,
            WM_AFXFIRST = 864,
            WM_AFXLAST = 895,
            WM_APP = 32768,
            WM_ASKCBFORMATNAME = 780,
            WM_CANCELJOURNAL = 75,
            WM_CANCELMODE = 31,
            WM_CAPTURECHANGED = 533,
            WM_CHANGECBCHAIN = 781,
            WM_CHAR = 258,
            WM_CHARTOITEM = 47,
            WM_CHILDACTIVATE = 34,
            WM_CLEAR = 771,
            WM_CLOSE = 16,
            WM_COMMAND = 273,
            WM_COMPACTING = 65,
            WM_COMPAREITEM = 57,
            WM_CONTEXTMENU = 123,
            WM_COPY = 769,
            WM_COPYDATA = 74,
            WM_CREATE = 1,
            WM_CTLCOLORBTN = 309,
            WM_CTLCOLORDLG = 310,
            WM_CTLCOLOREDIT = 307,
            WM_CTLCOLORLISTBOX = 308,
            WM_CTLCOLORMSGBOX = 306,
            WM_CTLCOLORSCROLLBAR = 311,
            WM_CTLCOLORSTATIC = 312,
            WM_CUT = 768,
            WM_DEADCHAR = 259,
            WM_DELETEITEM = 45,
            WM_DESTROY = 2,
            WM_DESTROYCLIPBOARD = 775,
            WM_DEVICECHANGE = 537,
            WM_DEVMODECHANGE = 27,
            WM_DISPLAYCHANGE = 126,
            WM_DRAWCLIPBOARD = 776,
            WM_DRAWITEM = 43,
            WM_DROPFILES = 563,
            WM_ENABLE = 10,
            WM_ENDSESSION = 22,
            WM_ENTERIDLE = 289,
            WM_ENTERMENULOOP = 529,
            WM_ENTERSIZEMOVE = 561,
            WM_ERASEBKGND = 20,
            WM_EXITMENULOOP = 530,
            WM_EXITSIZEMOVE = 562,
            WM_FONTCHANGE = 29,
            WM_GETDLGCODE = 135,
            WM_GETFONT = 49,
            WM_GETHOTKEY = 51,
            WM_GETICON = 127,
            WM_GETMINMAXINFO = 36,
            WM_GETOBJECT = 61,
            WM_GETTEXT = 13,
            WM_GETTEXTLENGTH = 14,
            WM_HANDHELDFIRST = 856,
            WM_HANDHELDLAST = 863,
            WM_HELP = 83,
            WM_HOTKEY = 786,
            WM_HSCROLL = 276,
            WM_HSCROLLCLIPBOARD = 782,
            WM_ICONERASEBKGND = 39,
            WM_IME_CHAR = 646,
            WM_IME_COMPOSITION = 271,
            WM_IME_COMPOSITIONFULL = 644,
            WM_IME_CONTROL = 643,
            WM_IME_ENDCOMPOSITION = 270,
            WM_IME_KEYDOWN = 656,
            WM_IME_KEYLAST = 271,
            WM_IME_KEYUP = 657,
            WM_IME_NOTIFY = 642,
            WM_IME_REQUEST = 648,
            WM_IME_SELECT = 645,
            WM_IME_SETCONTEXT = 641,
            WM_IME_STARTCOMPOSITION = 269,
            WM_INITDIALOG = 272,
            WM_INITMENU = 278,
            WM_INITMENUPOPUP = 279,
            WM_INPUTLANGCHANGE = 81,
            WM_INPUTLANGCHANGEREQUEST = 80,
            WM_KEYDOWN = 256,
            WM_KEYFIRST = 256,
            WM_KEYLAST = 264,
            WM_KEYUP = 257,
            WM_KILLFOCUS = 8,
            WM_LBUTTONDBLCLK = 515,
            WM_LBUTTONDOWN = 513,
            WM_LBUTTONUP = 514,
            WM_MBUTTONDBLCLK = 521,
            WM_MBUTTONDOWN = 519,
            WM_MBUTTONUP = 520,
            WM_MDIACTIVATE = 546,
            WM_MDICASCADE = 551,
            WM_MDICREATE = 544,
            WM_MDIDESTROY = 545,
            WM_MDIGETACTIVE = 553,
            WM_MDIICONARRANGE = 552,
            WM_MDIMAXIMIZE = 549,
            WM_MDINEXT = 548,
            WM_MDIREFRESHMENU = 564,
            WM_MDIRESTORE = 547,
            WM_MDISETMENU = 560,
            WM_MDITILE = 550,
            WM_MEASUREITEM = 44,
            WM_MENUCHAR = 288,
            WM_MENUCOMMAND = 294,
            WM_MENUDRAG = 291,
            WM_MENUGETOBJECT = 292,
            WM_MENURBUTTONUP = 290,
            WM_MENUSELECT = 287,
            WM_MOUSEACTIVATE = 33,
            WM_MOUSEFIRST = 512,
            WM_MOUSEHOVER = 673,
            WM_MOUSELAST = 522,
            WM_MOUSELEAVE = 675,
            WM_MOUSEMOVE = 512,
            WM_MOUSEWHEEL = 522,
            WM_MOVE = 3,
            WM_MOVING = 534,
            WM_NCACTIVATE = 134,
            WM_NCCALCSIZE = 131,
            WM_NCCREATE = 129,
            WM_NCDESTROY = 130,
            WM_NCHITTEST = 132,
            WM_NCLBUTTONDBLCLK = 163,
            WM_NCLBUTTONDOWN = 161,
            WM_NCLBUTTONUP = 162,
            WM_NCMBUTTONDBLCLK = 169,
            WM_NCMBUTTONDOWN = 167,
            WM_NCMBUTTONUP = 168,
            WM_NCMOUSEHOVER = 672,
            WM_NCMOUSELEAVE = 674,
            WM_NCMOUSEMOVE = 160,
            WM_NCPAINT = 133,
            WM_NCRBUTTONDBLCLK = 166,
            WM_NCRBUTTONDOWN = 164,
            WM_NCRBUTTONUP = 165,
            WM_NEXTDLGCTL = 40,
            WM_NEXTMENU = 531,
            WM_NOTIFY = 78,
            WM_NOTIFYFORMAT = 85,
            WM_NULL = 0,
            WM_PAINT = 15,
            WM_PAINTCLIPBOARD = 777,
            WM_PAINTICON = 38,
            WM_PALETTECHANGED = 785,
            WM_PALETTEISCHANGING = 784,
            WM_PARENTNOTIFY = 528,
            WM_PASTE = 770,
            WM_PENWINFIRST = 896,
            WM_PENWINLAST = 911,
            WM_POWER = 72,
            WM_PRINT = 791,
            WM_PRINTCLIENT = 792,
            WM_QUERYDRAGICON = 55,
            WM_QUERYENDSESSION = 17,
            WM_QUERYNEWPALETTE = 783,
            WM_QUERYOPEN = 19,
            WM_QUEUESYNC = 35,
            WM_QUIT = 18,
            WM_RBUTTONDBLCLK = 518,
            WM_RBUTTONDOWN = 516,
            WM_RBUTTONUP = 517,
            WM_RENDERALLFORMATS = 774,
            WM_RENDERFORMAT = 773,
            WM_SETCURSOR = 32,
            WM_SETFOCUS = 7,
            WM_SETFONT = 48,
            WM_SETHOTKEY = 50,
            WM_SETICON = 128,
            WM_SETREDRAW = 11,
            WM_SETTEXT = 12,
            WM_SETTINGCHANGE = 26,
            WM_SHOWWINDOW = 24,
            WM_SIZE = 5,
            WM_SIZECLIPBOARD = 779,
            WM_SIZING = 532,
            WM_SPOOLERSTATUS = 42,
            WM_STYLECHANGED = 125,
            WM_STYLECHANGING = 124,
            WM_SYNCPAINT = 136,
            WM_SYSCHAR = 262,
            WM_SYSCOLORCHANGE = 21,
            WM_SYSCOMMAND = 274,
            WM_SYSDEADCHAR = 263,
            WM_SYSKEYDOWN = 260,
            WM_SYSKEYUP = 261,
            WM_TCARD = 82,
            WM_TIMECHANGE = 30,
            WM_TIMER = 275,
            WM_UNDO = 772,
            WM_UNINITMENUPOPUP = 293,
            WM_USER = 1024,
            WM_USERCHANGED = 84,
            WM_VKEYTOITEM = 46,
            WM_VSCROLL = 277,
            WM_VSCROLLCLIPBOARD = 778,
            WM_WINDOWPOSCHANGED = 71,
            WM_WINDOWPOSCHANGING = 70,
            WM_WININICHANGE = 26
        }
    }
}

