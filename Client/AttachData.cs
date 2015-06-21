using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class AttachData
    {
        private string attachSourceData;

        public string AttachSourceData
        {
            get
            {
                return this.attachSourceData;
            }
            set
            {
                this.attachSourceData = value;
            }
        }

        public AttachData()
        {
        }

        public AttachData(string souceData)
        {
            this.attachSourceData = souceData;
        }

        private string Parse(string dataType, string dataText, string otherinfo)
        {
            string empty = string.Empty;
            string str = dataType;
            string str1 = str;
            if (str != null)
            {
                if (str1 == "1")
                {
                    long num = Convert.ToInt64(dataText) >> 32;
                    decimal num1 = Math.Round(num / new decimal(100), 2);
                    empty = num1.ToString();
                }
                else if (str1 == "01")
                {
                    double num2 = (double)NumHelper.Convert16To10(dataText.Substring(0, 8)) * 0.01;
                    empty = num2.ToString();
                }
                else if (str1 != "D1")
                {
                    if (str1 != "22")
                    {
                    }
                }
                else if (otherinfo != "0")
                {
                    DoorState doorState = new DoorState(1)
                    {
                        MessageAlarmText = dataText
                    };
                    empty = doorState.Parse();
                }
                else
                {
                    DoorState doorState1 = new DoorState(0)
                    {
                        MessageAlarmText = dataText
                    };
                    empty = doorState1.Parse();
                }
            }
            return empty;
        }

        public string ParseAttachData(string attachType, string otherinfo)
        {
            string[] strArrays = this.AttachSourceData.Split(new char[] { '/' });
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            for (int i = 0; i <= (int)strArrays.Length - 1; i++)
            {
                try
                {
                    int num = 1;
                    empty = strArrays[i].Substring(0, 1);
                    if (empty.ToUpper().Equals("M"))
                    {
                        empty = strArrays[i].Substring(1, 2);
                        num = 3;
                    }
                    if (empty.Equals(attachType, StringComparison.OrdinalIgnoreCase))
                    {
                        str = strArrays[i].Substring(num);
                        empty1 = string.Concat(empty1, this.Parse(empty, str, otherinfo));
                    }
                }
                catch
                {
                }
            }
            return empty1;
        }
    }
}
