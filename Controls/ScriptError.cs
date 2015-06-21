namespace WinFormsUI.Controls
{
    using System;

    internal class ScriptError
    {
        private string _description;
        private int _lineNumber;
        private Uri _url;

        public ScriptError(Uri url, string description, int lineNumber)
        {
            this._url = url;
            this._description = description;
            this._lineNumber = lineNumber;
        }

        public string Description
        {
            get
            {
                return this._description;
            }
        }

        public int LineNumber
        {
            get
            {
                return this._lineNumber;
            }
        }

        public Uri Url
        {
            get
            {
                return this._url;
            }
        }
    }
}

