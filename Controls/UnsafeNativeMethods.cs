namespace WinFormsUI.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows.Forms;

    internal class UnsafeNativeMethods
    {
        private UnsafeNativeMethods()
        {
        }

        [ComImport, TypeLibType((short) 4112), InterfaceType((short) 2), Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
        public interface DWebBrowserEvents2
        {
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(102)]
            void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(108)]
            void ProgressChange([In] int Progress, [In] int ProgressMax);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(105)]
            void CommandStateChange([In] int Command, [In] bool Enable);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(106)]
            void DownloadBegin();
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(104)]
            void DownloadComplete();
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(113)]
            void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(112)]
            void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string szProperty);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(250)]
            void BeforeNavigate2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers, [In, Out] ref bool Cancel);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(251)]
            void NewWindow2([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out] ref bool Cancel);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(252)]
            void NavigateComplete2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(259)]
            void DocumentComplete([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(253)]
            void OnQuit();
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(254)]
            void OnVisible([In] bool Visible);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(255)]
            void OnToolBar([In] bool ToolBar);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(256)]
            void OnMenuBar([In] bool MenuBar);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(257)]
            void OnStatusBar([In] bool StatusBar);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(258)]
            void OnFullScreen([In] bool FullScreen);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(260)]
            void OnTheaterMode([In] bool TheaterMode);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(262)]
            void WindowSetResizable([In] bool Resizable);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(264)]
            void WindowSetLeft([In] int Left);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(265)]
            void WindowSetTop([In] int Top);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(266)]
            void WindowSetWidth([In] int Width);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(267)]
            void WindowSetHeight([In] int Height);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(263)]
            void WindowClosing([In] bool IsChildWindow, [In, Out] ref bool Cancel);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(268)]
            void ClientToHostWindow([In, Out] ref int CX, [In, Out] ref int CY);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(269)]
            void SetSecureLockIcon([In] int SecureLockIcon);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(270)]
            void FileDownload([In, Out] ref bool Cancel);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(271)]
            void NavigateError([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Frame, [In, MarshalAs(UnmanagedType.Struct)] ref object StatusCode, [In, Out] ref bool Cancel);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(225)]
            void PrintTemplateInstantiation([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(226)]
            void PrintTemplateTeardown([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(227)]
            void UpdatePageStatus([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object nPage, [In, MarshalAs(UnmanagedType.Struct)] ref object fDone);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(272)]
            void PrivacyImpactedStateChange([In] bool bImpacted);
            [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(273)]
            void NewWindow3([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out] ref bool Cancel, [In] uint dwFlags, [In, MarshalAs(UnmanagedType.BStr)] string bstrUrlContext, [In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);
        }

        [ComImport, Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E"), TypeLibType(TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDual | TypeLibTypeFlags.FHidden), SuppressUnmanagedCodeSecurity]
        public interface IWebBrowser2
        {
            [DispId(100)]
            void GoBack();
            [DispId(101)]
            void GoForward();
            [DispId(102)]
            void GoHome();
            [DispId(103)]
            void GoSearch();
            [DispId(104)]
            void Navigate([In] string Url, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);
            [DispId(-550)]
            void Refresh();
            [DispId(105)]
            void Refresh2([In] ref object level);
            [DispId(106)]
            void Stop();
            [DispId(200)]
            object Application { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
            [DispId(201)]
            object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
            [DispId(202)]
            object Container { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
            [DispId(203)]
            object Document { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
            [DispId(204)]
            bool TopLevelContainer { get; }
            [DispId(205)]
            string Type { get; }
            [DispId(206)]
            int Left { get; set; }
            [DispId(207)]
            int Top { get; set; }
            [DispId(208)]
            int Width { get; set; }
            [DispId(209)]
            int Height { get; set; }
            [DispId(210)]
            string LocationName { get; }
            [DispId(211)]
            string LocationURL { get; }
            [DispId(212)]
            bool Busy { get; }
            [DispId(300)]
            void Quit();
            [DispId(301)]
            void ClientToWindow(out int pcx, out int pcy);
            [DispId(302)]
            void PutProperty([In] string property, [In] object vtValue);
            [DispId(303)]
            object GetProperty([In] string property);
            [DispId(0)]
            string Name { get; }
            [DispId(-515)]
            int HWND { get; }
            [DispId(400)]
            string FullName { get; }
            [DispId(401)]
            string Path { get; }
            [DispId(402)]
            bool Visible { get; set; }
            [DispId(403)]
            bool StatusBar { get; set; }
            [DispId(404)]
            string StatusText { get; set; }
            [DispId(405)]
            int ToolBar { get; set; }
            [DispId(406)]
            bool MenuBar { get; set; }
            [DispId(407)]
            bool FullScreen { get; set; }
            [DispId(500)]
            void Navigate2([In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);
            [DispId(501)]
            WinFormsUI.Controls.NativeMethods.OLECMDF QueryStatusWB([In] WinFormsUI.Controls.NativeMethods.OLECMDID cmdID);
            [DispId(502)]
            void ExecWB([In] WinFormsUI.Controls.NativeMethods.OLECMDID cmdID, [In] WinFormsUI.Controls.NativeMethods.OLECMDEXECOPT cmdexecopt, ref object pvaIn, IntPtr pvaOut);
            [DispId(503)]
            void ShowBrowserBar([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);
            [DispId(-525)]
            WebBrowserReadyState ReadyState { get; }
            [DispId(550)]
            bool Offline { get; set; }
            [DispId(551)]
            bool Silent { get; set; }
            [DispId(552)]
            bool RegisterAsBrowser { get; set; }
            [DispId(553)]
            bool RegisterAsDropTarget { get; set; }
            [DispId(554)]
            bool TheaterMode { get; set; }
            [DispId(555)]
            bool AddressBar { get; set; }
            [DispId(556)]
            bool Resizable { get; set; }
        }
    }
}

