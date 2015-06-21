namespace Client
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class StarNetDateTimePicker : DateTimePicker, ISimpleCommonArgs
    {
        private string _valueFormat = "yyyy-MM-dd HH:mm:ss";

        public bool Check
        {
            get
            {
                try
                {
                    object obj2 = base.Value.ToString(this._valueFormat);
                    this.DestinationMarshalByRefObject.GetType().GetProperty(this.PropertyName).SetValue(this.DestinationMarshalByRefObject, obj2, null);
                    return true;
                }
                catch (Exception exception)
                {
                    this.ErrorInfo = exception.Message;
                    return false;
                }
            }
        }

        public object DestinationMarshalByRefObject { get; set; }

        public string ErrorInfo { get; set; }

        public string InfoName { get; set; }

        public bool IsNeed { get; set; }

        public string PropertyName { get; set; }

        public System.Type PropertyType { get; set; }

        public string ValueFormat
        {
            get
            {
                return this._valueFormat;
            }
            set
            {
                this._valueFormat = value;
            }
        }
    }
}

