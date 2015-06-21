namespace Client
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class StarNetComboBox : ComboBox, ISimpleCommonArgs
    {
        public bool Check
        {
            get
            {
                try
                {
                    object selectedValue = base.SelectedValue;
                    if (this.PropertyType.FullName == System.Type.GetType("System.Int32").FullName)
                    {
                        selectedValue = Convert.ToInt32(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Int64").FullName)
                    {
                        selectedValue = Convert.ToInt64(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Double").FullName)
                    {
                        selectedValue = Convert.ToDouble(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Decimal").FullName)
                    {
                        selectedValue = Convert.ToDecimal(this.Text);
                    }
                    this.DestinationMarshalByRefObject.GetType().GetProperty(this.PropertyName).SetValue(this.DestinationMarshalByRefObject, selectedValue, null);
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

