namespace WinFormsUI.Controls
{
    using System;

    public class SettingsHelper
    {
        private static SettingsHelper _instance;
        private static object _lockObject = new object();
        private bool _showScriptErrors;

        private SettingsHelper()
        {
        }

        public static SettingsHelper Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new SettingsHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        public bool ShowScriptErrors
        {
            get
            {
                return this._showScriptErrors;
            }
            set
            {
                this._showScriptErrors = value;
            }
        }
    }
}

