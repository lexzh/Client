namespace PublicClass
{
    using System;

    public class ValueObject
    {
        private object _name;
        private object _value;

        public ValueObject(object oName, object oValue)
        {
            this.Name = oName;
            this.Value = oValue;
        }

        public object Name
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

        public object Value
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

