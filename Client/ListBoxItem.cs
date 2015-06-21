namespace Client
{
    using System;

    public class ListBoxItem
    {
        private string _name;
        private object _tag;
        private string _value;

        public ListBoxItem(string name, string value)
        {
            this._name = name;
            this._value = value;
        }

        public override string ToString()
        {
            return this._name;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public object Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
            }
        }

        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}

