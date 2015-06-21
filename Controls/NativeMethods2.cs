namespace WinFormsUI.Controls
{
    using System;

    internal static class NativeMethods2
    {
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
    }
}

