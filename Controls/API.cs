namespace WinFormsUI.Controls
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class API
    {
        private const int GMEM_FIXED = 0;
        private const int TVGN_CARET = 9;
        private const int TVGN_CHILD = 4;
        private const int TVGN_NEXT = 1;
        private const int TVGN_ROOT = 0;
        private const int TVIF_TEXT = 1;
        private const int TVM_GETITEM = 4364;
        private const int TVM_GETNEXTITEM = 4362;
        private const int TVM_SELECTITEM = 4363;

        [DllImport("kernel32 ", CharSet=CharSet.Auto)]
        public static extern int CopyMemory(StringBuilder Destination, IntPtr Source, int Length);
        [DllImport("user32.dll ")]
        public static extern int GetClassNameA(int hwnd, StringBuilder lpClassName, int nMaxCount);
        public static IntPtr GetFirstChildItem(IntPtr TreeViewHwnd, IntPtr ParentHwnd)
        {
            return new IntPtr(SendMessage(TreeViewHwnd, 4362, new IntPtr(4), ParentHwnd));
        }

        public static string GetItemText(IntPtr TreeViewHwnd, IntPtr ItemHwnd)
        {
            StringBuilder destination = new StringBuilder(1024);
            int num = GlobalAlloc(0, 1024);
            if (num > 0)
            {
                WinFormsUI.Controls.TVITEM lparam = new WinFormsUI.Controls.TVITEM {
                    mask = 1,
                    HTreeItem = ItemHwnd.ToInt32(),
                    pszText = new IntPtr(num),
                    cchTextMax = 1023
                };
                SendMessage(TreeViewHwnd, 4364, IntPtr.Zero, lparam);
                CopyMemory(destination, new IntPtr(num), 1024);
                GlobalFree(new IntPtr(num));
                Marshal.PtrToStringAnsi(lparam.pszText);
            }
            return destination.ToString();
        }

        public static IntPtr GetNextItem(IntPtr TreeViewHwnd, IntPtr PrevHwnd)
        {
            return new IntPtr(SendMessage(TreeViewHwnd, 4362, new IntPtr(1), PrevHwnd));
        }

        public static IntPtr GetRoot(IntPtr TreeViewHwnd)
        {
            WinFormsUI.Controls.TVITEM lparam = new WinFormsUI.Controls.TVITEM();
            IntPtr hglobal = Marshal.AllocHGlobal(1024);
            lparam.hItem = TreeViewHwnd;
            lparam.mask = 1;
            lparam.pszText = hglobal;
            lparam.cchTextMax = 1024;
            int num = SendMessage(TreeViewHwnd, 4362, new IntPtr(0), lparam);
            Marshal.FreeHGlobal(hglobal);
            return new IntPtr(num);
        }

        [DllImport("user32.dll ")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("kernel32 ", CharSet=CharSet.Auto)]
        public static extern int GlobalAlloc(int wFlags, int dwBytes);
        [DllImport("kernel32 ", CharSet=CharSet.Auto)]
        public static extern int GlobalFree(IntPtr hMem);
        public static bool SelectNode(IntPtr TreeViewHwnd, IntPtr ItemHwnd)
        {
            if (SendMessage(TreeViewHwnd, 4363, new IntPtr(9), ItemHwnd) == 0)
            {
                return false;
            }
            return true;
        }

        [DllImport("user32.dll ", CharSet=CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lparam);
        [DllImport("user32.dll ", CharSet=CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, WinFormsUI.Controls.TVITEM lparam);
    }
}

