using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class NumHelper
    {
        public NumHelper()
        {
        }

        public static int Convert16To10(string str)
        {
            return Convert.ToInt32(str, 16);
        }

        public static string Convert16To10ToString(string str)
        {
            return ((long)NumHelper.Convert16To10(str)).ToString();
        }

        public static string ConvertStringToDatetime(string sDateTime)
        {
            return NumHelper.ConvertToDatetime((long)NumHelper.Convert16To10(sDateTime));
        }

        public static string ConvertToDatetime(long lDateTime)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime dateTime1 = dateTime.AddSeconds((double)lDateTime);
            DateTime dateTime2 = dateTime1.AddHours(8);
            return string.Concat(dateTime2.ToShortDateString(), " ", dateTime2.ToLongTimeString());
        }

        public static int ConvertToInt(object val)
        {
            int num = 0;
            if (val != null && !string.IsNullOrEmpty(val.ToString()))
            {
                num = Convert.ToInt32(val);
            }
            return num;
        }

        public static string GetBCDDataTime(string sourceDateTime)
        {
            string str = "20";
            str = string.Concat(str, sourceDateTime.Substring(0, 2));
            str = string.Concat(str, "-", sourceDateTime.Substring(2, 2));
            str = string.Concat(str, "-", sourceDateTime.Substring(4, 2));
            str = string.Concat(str, " ", sourceDateTime.Substring(6, 2));
            str = string.Concat(str, ":", sourceDateTime.Substring(8, 2));
            if (sourceDateTime.Length > 10)
            {
                str = string.Concat(str, ":", sourceDateTime.Substring(10, 2));
            }
            return str;
        }

        public static string GetBCDDate(string sourceDate)
        {
            string str = "";
            str = string.Concat(str, sourceDate.Substring(0, 2));
            str = string.Concat(str, sourceDate.Substring(2, 2));
            str = string.Concat(str, "-", sourceDate.Substring(4, 2));
            str = string.Concat(str, "-", sourceDate.Substring(6, 2));
            return str;
        }

        public static string GetIPFrom16to10(string str)
        {
            string empty = string.Empty;
            for (int i = 0; i < str.Length; i = i + 2)
            {
                empty = string.Concat(empty, ".", Convert.ToString(NumHelper.Convert16To10(str.Substring(i, 2))));
            }
            return empty.Substring(1);
        }

        public static string GetPosInfo(string subTxt)
        {
            int num = NumHelper.Convert16To10(subTxt.Substring(0, 8));
            int num1 = NumHelper.Convert16To10(subTxt.Substring(8, 8));
            int num2 = Convert.ToInt16(subTxt.Substring(16, 4), 16);
            object[] str = new object[5];
            double num3 = (double)num * 0.0001 / 60;
            str[0] = num3.ToString("F6");
            str[1] = ",";
            double num4 = (double)num1 * 0.0001 / 60;
            str[2] = num4.ToString("F6");
            str[3] = ",";
            str[4] = num2;
            return string.Concat(str);
        }

        public static string GetStringFromBase16ASCII(string str)
        {
            string empty = string.Empty;
            int num = 0;
            int num1 = 0;
            byte[] numArray = new byte[str.Length / 2];
            for (int i = 0; i < str.Length; i = i + 2)
            {
                num1 = Convert.ToInt32(str.Substring(i, 2), 16);
                numArray[num] = (byte)num1;
                num++;
            }
            return Encoding.Default.GetString(numArray);
        }
    }
}
