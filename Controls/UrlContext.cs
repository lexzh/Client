namespace WinFormsUI.Controls
{
    using System;

    [Flags]
    public enum UrlContext
    {
        FromProxy = 64,
        HtmlDialog = 32,
        None = 0,
        OverrideKey = 8,
        ShowHelp = 16,
        Unloading = 1,
        UserFirstInited = 4,
        UserInited = 2
    }
}

