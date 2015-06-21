namespace WinFormsUI.Controls
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public sealed class NativeMethods
    {
        [DllImport("comctl32.dll")]
        public static extern IntPtr ImageList_Create(int cx, int cy, int flags, int cInitial, int cGrow);
        [DllImport("user32.dll", EntryPoint="SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint="SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref TVITEM lParam);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);

        public enum Messages
        {
            EM_GETRECT = 13,
            TVM_SETBKCOLOR = 4381,
            TVM_SETIMAGELIST = 4361,
            TVM_SETITEM = 4365,
            TVM_SETTEXTCOLOR = 4382,
            WM_SETTEXT = 12
        }

        public enum OLECMDEXECOPT
        {
            OLECMDEXECOPT_DODEFAULT,
            OLECMDEXECOPT_PROMPTUSER,
            OLECMDEXECOPT_DONTPROMPTUSER,
            OLECMDEXECOPT_SHOWHELP
        }

        public enum OLECMDF
        {
            OLECMDF_DEFHIDEONCTXTMENU = 32,
            OLECMDF_ENABLED = 2,
            OLECMDF_INVISIBLE = 16,
            OLECMDF_LATCHED = 4,
            OLECMDF_NINCHED = 8,
            OLECMDF_SUPPORTED = 1
        }

        public enum OLECMDID
        {
            OLECMDID_PAGESETUP = 8,
            OLECMDID_PRINT = 6,
            OLECMDID_PRINTPREVIEW = 7,
            OLECMDID_PROPERTIES = 10,
            OLECMDID_SAVEAS = 4
        }

        public enum TreeViewImageListType
        {
            TVSIL_NORMAL = 0,
            TVSIL_STATE = 2
        }

        [Flags]
        public enum TreeViewMask
        {
            TVIF_CHILDREN = 64,
            TVIF_HANDLE = 16,
            TVIF_IMAGE = 2,
            TVIF_INTEGRAL = 128,
            TVIF_PARAM = 4,
            TVIF_SELECTEDIMAGE = 32,
            TVIF_STATE = 8,
            TVIF_TEXT = 1
        }

        [Flags]
        public enum TreeViewStateMask
        {
            TVIS_BOLD = 16,
            TVIS_CUT = 4,
            TVIS_DROPHILITED = 8,
            TVIS_EXPANDED = 32,
            TVIS_EXPANDEDONCE = 64,
            TVIS_EXPANDPARTIAL = 128,
            TVIS_OVERLAYMASK = 3840,
            TVIS_SELECTED = 2,
            TVIS_STATEIMAGEMASK = 61440,
            TVIS_USERMASK = 61440
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }
    }
}

