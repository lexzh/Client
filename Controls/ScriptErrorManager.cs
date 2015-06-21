namespace WinFormsUI.Controls
{
    using System;

    internal class ScriptErrorManager
    {
        private ScriptErrorWindow _errorWindow;
        private static ScriptErrorManager _instance;
        private NotifyCollection<ScriptError> _scriptErrors = new NotifyCollection<ScriptError>();
        private static object lockObject = new object();

        private ScriptErrorManager()
        {
        }

        public void RegisterScriptError(Uri url, string description, int lineNumber)
        {
            this._scriptErrors.Add(new ScriptError(url, description, lineNumber));
            if (SettingsHelper.Current.ShowScriptErrors)
            {
                this.ShowWindow();
            }
        }

        public void ShowWindow()
        {
            if ((this._errorWindow == null) || this._errorWindow.IsDisposed)
            {
                this._errorWindow = new ScriptErrorWindow();
            }
            this._errorWindow.Show();
        }

        public static ScriptErrorManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new ScriptErrorManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public NotifyCollection<ScriptError> ScriptErrors
        {
            get
            {
                return this._scriptErrors;
            }
        }
    }
}

