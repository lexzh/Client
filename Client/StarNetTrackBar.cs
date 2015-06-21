namespace Client
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class StarNetTrackBar : TrackBar, ISimpleCommonArgs
    {
        public bool Check
        {
            get
            {
                try
                {
                    object obj2 = base.Value;
                    if (this.PropertyType.FullName == System.Type.GetType("System.Int32").FullName)
                    {
                        obj2 = Convert.ToInt32(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Int64").FullName)
                    {
                        obj2 = Convert.ToInt64(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Double").FullName)
                    {
                        obj2 = Convert.ToDouble(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Decimal").FullName)
                    {
                        obj2 = Convert.ToDecimal(this.Text);
                    }
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
    }
}

