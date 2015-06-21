namespace Client
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class StarNetTextBox : TextBox, ISimpleCommonArgs
    {
        public bool Check
        {
            get
            {
                try
                {
                    if (this.IsNeed && (this.Text.Trim().Length == 0))
                    {
                        this.ErrorInfo = this.InfoName + " 不能为空!";
                        return false;
                    }
                    object text = this.Text;
                    if (this.PropertyType.FullName == System.Type.GetType("System.Int32").FullName)
                    {
                        text = Convert.ToInt32(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Int64").FullName)
                    {
                        text = Convert.ToInt64(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Double").FullName)
                    {
                        text = Convert.ToDouble(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Decimal").FullName)
                    {
                        text = Convert.ToDecimal(this.Text);
                    }
                    this.DestinationMarshalByRefObject.GetType().GetProperty(this.PropertyName).SetValue(this.DestinationMarshalByRefObject, text, null);
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

