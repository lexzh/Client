namespace WinFormsUI.Controls
{
    using System;

    [Flags]
    public enum BrowserCommands
    {
        Back = 4,
        Forward = 8,
        Home = 1,
        None = 0,
        Print = 64,
        PrintPreview = 128,
        Reload = 32,
        Search = 2,
        Stop = 16
    }
}

