namespace Library
{
    using System;
    using System.Text;

    public class NumHelper
    {
        public static int Convert16To10(string strHex)
        {
            return Convert.ToInt32(strHex, 16);
        }

        public static string Convert16To10ToString(string strHex)
        {
            return ((long) Convert16To10(strHex)).ToString();
        }

        public static string ConvertStringToDatetime(string string_0)
        {
            long num = Convert16To10(string_0);
            return ConvertToDatetime(num);
        }

        public static string ConvertToDatetime(long long_0)
        {
            DateTime time = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0);
            DateTime time2 = time.AddSeconds((double) long_0).AddHours(8.0);
            return (time2.ToShortDateString() + " " + time2.ToLongTimeString());
        }

        public static int ConvertToInt(object object_0)
        {
            int num = 0;
            if ((object_0 != null) && !string.IsNullOrEmpty(object_0.ToString()))
            {
                num = Convert.ToInt32(object_0);
            }
            return num;
        }

        public static string GetBCDDataTime(string string_0)
        {
            string str = "20";
            str = ((((str + string_0.Substring(0, 2)) + "-" + string_0.Substring(2, 2)) + "-" + string_0.Substring(4, 2)) + " " + string_0.Substring(6, 2)) + ":" + string_0.Substring(8, 2);
            if (string_0.Length > 10)
            {
                str = str + ":" + string_0.Substring(10, 2);
            }
            return str;
        }

        public static string GetBCDDate(string string_0)
        {
            string str = "";
            return (((str + string_0.Substring(0, 2) + string_0.Substring(2, 2)) + "-" + string_0.Substring(4, 2)) + "-" + string_0.Substring(6, 2));
        }

        public static string GetIPFrom16to10(string string_0)
        {
            string str = string.Empty;
            for (int i = 0; i < string_0.Length; i += 2)
            {
                str = str + "." + Convert.ToString(Convert16To10(string_0.Substring(i, 2)));
            }
            return str.Substring(1);
        }

        public static string GetStringFromBase16(string str)
        {
            string str2 = string.Empty;
            for (int i = 0; i < str.Length; i += 2)
            {
                str2 = str2 + Convert.ToString(Convert16To10(str.Substring(i, 2)));
            }
            return str2;
        }

        public static string GetStringFromBase16ASCII(string str)
        {
            string str2 = string.Empty;
            for (int i = 0; i < str.Length; i += 2)
            {
                str2 = str2 + Convert.ToChar(Convert16To10(str.Substring(i, 2)));
            }
            return str2;
        }
    }
}

