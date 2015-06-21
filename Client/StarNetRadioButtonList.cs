namespace Client
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class StarNetRadioButtonList : FlowLayoutPanel, ISimpleCommonArgs
    {
        private string _datalist = "";

        public bool Check
        {
            get
            {
                try
                {
                    object tag = "";
                    bool flag = false;
                    foreach (Control control in base.Controls)
                    {
                        if ((control as RadioButton).Checked)
                        {
                            tag = control.Tag;
                            flag = true;
                            break;
                        }
                    }
                    if (this.IsNeed && !flag)
                    {
                        this.ErrorInfo = "请选择" + this.InfoName + " 列表项!";
                        return false;
                    }
                    if (this.PropertyType.FullName == System.Type.GetType("System.Int32").FullName)
                    {
                        tag = Convert.ToInt32(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Int64").FullName)
                    {
                        tag = Convert.ToInt64(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Double").FullName)
                    {
                        tag = Convert.ToDouble(this.Text);
                    }
                    else if (this.PropertyType.FullName == System.Type.GetType("System.Decimal").FullName)
                    {
                        tag = Convert.ToDecimal(this.Text);
                    }
                    this.DestinationMarshalByRefObject.GetType().GetProperty(this.PropertyName).SetValue(this.DestinationMarshalByRefObject, tag, null);
                    return true;
                }
                catch (Exception exception)
                {
                    this.ErrorInfo = exception.Message;
                    return false;
                }
            }
        }

        public string DataList
        {
            get
            {
                return this._datalist;
            }
            set
            {
                this._datalist = value;
                if (this._datalist.Length > 0)
                {
                    string[] strArray = this._datalist.Split(new char[] { ';' });
                    int num = 0;
                    foreach (string str in strArray)
                    {
                        RadioButton button;
                        string[] strArray2 = str.Split(new char[] { '|' });
                        button = new RadioButton {
                            Name = num.ToString(),  ///  Name = button + num.ToString(),
                            Text = strArray2[0],
                            Tag = strArray2[1]
                        };
                        if (num == 0)
                        {
                            button.Checked = true;
                        }
                        num++;
                        base.Controls.Add(button);
                    }
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

