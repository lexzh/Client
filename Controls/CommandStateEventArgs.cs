namespace WinFormsUI.Controls
{
    using System;

    public class CommandStateEventArgs : EventArgs
    {
        private WinFormsUI.Controls.BrowserCommands _commands;

        public CommandStateEventArgs(WinFormsUI.Controls.BrowserCommands commands)
        {
            this._commands = commands;
        }

        public WinFormsUI.Controls.BrowserCommands BrowserCommands
        {
            get
            {
                return this._commands;
            }
        }
    }
}

