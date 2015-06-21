namespace WinFormsUI.Controls
{
    using System;

    public class TextChangedEventArgs : EventArgs
    {
        private string _text;

        public TextChangedEventArgs(string text)
        {
            this._text = text;
        }

        public string Text
        {
            get
            {
                return this._text;
            }
        }
    }
}

