using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    public class Check
    {
        private const double EARTH_RADIUS = 6378.137;

        public Check()
        {
        }

        public static string ChangeDateFormat(string strDate)
        {
            string str;
            try
            {
                string[] strArrays = new string[] { strDate.Substring(0, 2), "-", strDate.Substring(2, 2), "-", strDate.Substring(4, 2), " ", strDate.Substring(6, 2), ":", strDate.Substring(8, 2), ":", strDate.Substring(10, 2) };
                string str1 = string.Concat(strArrays);
                str = (strDate.Substring(0, 4) == "0000" ? string.Concat("00", str1) : string.Concat("20", str1));
            }
            catch
            {
                str = "";
            }
            return str;
        }

        public static bool CheckCompanyCode(string companyCode)
        {
            if (companyCode.Trim().Length > 18)
            {
                return false;
            }
            if (!(new Regex("^.{1,}$")).IsMatch(companyCode.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckEmailAddress(string emailAddress)
        {
            if (!(new Regex("^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$")).IsMatch(emailAddress.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckIdCode(string idCode)
        {
            if (!(new Regex("^\\d{15}(\\d{2}(\\d|x|X))?$")).IsMatch(idCode.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckIpAddress(string strIpAddress)
        {
            if (strIpAddress == null || strIpAddress.Length <= 0)
            {
                return false;
            }
            string[] strArrays = strIpAddress.Split(new char[] { '.' });
            if ((int)strArrays.Length < 4)
            {
                return false;
            }
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (!Check.isNumeric(strArrays[i], Check.NumType.sInt))
                {
                    return false;
                }
                int num = int.Parse(strArrays[i]);
                if (num > 255 || num < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckIsDate(string strDate, out string strResultDate)
        {
            bool flag;
            try
            {
                strResultDate = string.Empty;
                if (!string.IsNullOrEmpty(strDate))
                {
                    string[] strArrays = strDate.Split(new char[] { ' ' });
                    if ((int)strArrays.Length == 2)
                    {
                        if (strArrays[0] != "0000-00-00")
                        {
                            strResultDate = string.Format("{0:yyMMddHHmmss}", DateTime.Parse(strDate));
                        }
                        else
                        {
                            strResultDate = string.Concat("000000", string.Format("{0:HHmmss}", DateTime.Parse(strArrays[1])));
                        }
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                strResultDate = string.Empty;
                flag = false;
            }
            return flag;
        }

        public static bool CheckIsDigit(string strData, int iCount)
        {
            if (!(new Regex(string.Format("^\\d%0,{0}&$", iCount).Replace('%', '{').Replace('&', '}'))).IsMatch(strData.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckMobileNumber(string phoneNumber)
        {
            if (!(new Regex("^(1)\\d{10}$")).IsMatch(phoneNumber.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckPassword(string password)
        {
            if (!(new Regex("^\\w{6,}$")).IsMatch(password.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckPhoneNumber(string phoneNumber)
        {
            if (!(new Regex("^(\\d+-?\\d+)*$")).IsMatch(phoneNumber.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckPostCode(string postCode)
        {
            if (!(new Regex("^\\d{6}$")).IsMatch(postCode.Trim()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckPwd(ref string errMsg, string pwd, string replypwd)
        {
            char[] chrArray = new char[] { '\"', ';', '\\', '\'' };
            if (string.IsNullOrEmpty(pwd))
            {
                errMsg = "新密码不能为空！";
                return false;
            }
            if (pwd != replypwd)
            {
                errMsg = "两次密码不相同，请重新输入密码！";
                return false;
            }
            if (pwd.IndexOfAny(chrArray, 0) <= -1)
            {
                return true;
            }
            errMsg = "新密码中含有非法字符！";
            return false;
        }

        public static bool CheckStrongPwd(ref string errMsg, string pwd, string replypwd, object minLen, object maxLen, int iStrong)
        {
            if (!Check.CheckPwd(ref errMsg, pwd, replypwd))
            {
                return false;
            }
            if (!Check.StringCompare(ref errMsg, pwd, minLen, maxLen))
            {
                errMsg = errMsg.Replace("字符", "密码");
                return false;
            }
            if (iStrong <= 1 || iStrong >= 4)
            {
                return true;
            }
            if (Check.GetPwdStrong(pwd) >= iStrong)
            {
                return true;
            }
            errMsg = "密码强度太弱，请重新输入密码！（建议使用大小写字母、数字和特殊字符组合。）";
            return false;
        }

        public static bool CheckUserName(string userName)
        {
            if (!(new Regex("^[0-9a-zA-Z-]{1,128}$")).IsMatch(userName.Trim()))
            {
                return false;
            }
            return true;
        }

        public static byte[] ConvertLatAndLon(string pLatOrLon)
        {
            byte[] numArray = new byte[4];
            if (!string.IsNullOrEmpty(pLatOrLon))
            {
                double num = Convert.ToDouble(pLatOrLon);
                int num1 = (int)num;
                numArray[0] = (byte)num1;
                double num2 = (num - (double)num1) * 60;
                int num3 = (int)num2;
                if (num3 >= 0 && num3 <= 60)
                {
                    numArray[1] = (byte)num3;
                    num2 = (num2 - (double)num3) * 100;
                    int num4 = (int)num2;
                    if (num4 >= 0 && num4 <= 99)
                    {
                        numArray[2] = (byte)num4;
                        num2 = (num2 - (double)num4) * 100;
                        int num5 = (int)num2;
                        if (num5 >= 0 && num5 <= 99)
                        {
                            numArray[3] = (byte)num5;
                        }
                    }
                }
            }
            return numArray;
        }

        public static string GB2312ASCII(string sourceString)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(sourceString);
            string str = "";
            byte[] numArray = bytes;
            for (int i = 0; i < (int)numArray.Length; i++)
            {
                byte num = numArray[i];
                str = string.Concat(str, num.ToString("X"));
            }
            return str;
        }

        private static int GetCharMode(char cChar)
        {
            int num = cChar;
            if (num >= 48 && num <= 57)
            {
                return 1;
            }
            if (num >= 65 && num <= 90 || num >= 97 && num <= 122)
            {
                return 2;
            }
            return 4;
        }

        public static string getChkText(bool isChecked)
        {
            if (isChecked)
            {
                return "√";
            }
            return "※";
        }

        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double num;
            try
            {
                double num1 = Check.rad(lat1);
                double num2 = Check.rad(lat2);
                double num3 = num1 - num2;
                double num4 = Check.rad(lng1) - Check.rad(lng2);
                double num5 = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(num3 / 2), 2) + Math.Cos(num1) * Math.Cos(num2) * Math.Pow(Math.Sin(num4 / 2), 2)));
                num5 = num5 * 6378.137;
                num = Math.Round(num5 * 10000) / 10;
            }
            catch (Exception exception)
            {
                num = -1;
            }
            return num;
        }

        public static int GetPwdStrong(string pwd)
        {
            int charMode = 0;
            int num = 0;
            string str = pwd;
            for (int i = 0; i < str.Length; i++)
            {
                char chr = str[i];
                charMode = charMode | Check.GetCharMode(chr);
            }
            for (int j = 0; j < 3; j++)
            {
                num = num + (charMode & 1);
                charMode = charMode >> 1;
            }
            return num;
        }

        public static bool isDate(string pStrDate)
        {
            bool flag = true;
            try
            {
                DateTime.Parse(pStrDate);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static bool isDate(string pStrDate, int pDateFormat)
        {
            bool flag = true;
            if (pStrDate == null || pStrDate.Length <= 0)
            {
                flag = false;
            }
            switch (pDateFormat)
            {
                case 1:
                    {
                        if ((new Regex("\\d{4}-\\d{1,2}-\\d{1,2}")).IsMatch(pStrDate.Trim()))
                        {
                            break;
                        }
                        flag = false;
                        break;
                    }
                case 2:
                    {
                        if ((new Regex("\\d{4}.\\d{1,2}.\\d{1,2}")).IsMatch(pStrDate.Trim()))
                        {
                            break;
                        }
                        flag = false;
                        break;
                    }
                case 3:
                    {
                        if ((new Regex("\\d{4}年\\d{1,2}月\\d{1,2}日")).IsMatch(pStrDate.Trim()))
                        {
                            break;
                        }
                        flag = false;
                        break;
                    }
            }
            return flag;
        }

		 public static bool IsInRegion(string Lon, string Lat, string regionDot)
        {
            try
            {
                if (isRectangle(regionDot))
                {
                    string[] strArray = regionDot.Replace("*", @"\").Trim(new char[] { '\\' }).Split(new char[] { '\\' });
                    return (((double.Parse(Lon) > double.Parse(strArray[0])) && (double.Parse(Lon) < double.Parse(strArray[4]))) && ((double.Parse(Lat) < double.Parse(strArray[5])) && (double.Parse(Lat) > double.Parse(strArray[1]))));
                }
                return (isRoundness(regionDot) && false);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool isNumeric(string pStrNum, Check.NumType pType)
        {
            bool flag;
            bool flag1 = true;
            switch (pType)
            {
                case Check.NumType.sInt:
                    {
                        try
                        {
                            int.Parse(pStrNum);
                            break;
                        }
                        catch
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    }
                case Check.NumType.sDecimal:
                    {
                        try
                        {
                            decimal.Parse(pStrNum);
                            break;
                        }
                        catch
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    }
                case Check.NumType.sByte:
                    {
                        try
                        {
                            int num = int.Parse(pStrNum);
                            if (num > 255 || num < 0)
                            {
                                flag = false;
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch
                        {
                            flag1 = false;
                            break;
                        }
                        return flag;
                    }
                default:
                    {
                        flag1 = false;
                        break;
                    }
            }
            return flag1;
        }

        public static bool isRectangle(string sRegionDot)
        {
            bool flag;
            try
            {
                string str = sRegionDot.Replace("*", "\\");
                char[] chrArray = new char[] { '\\' };
                string[] strArrays = str.Trim(chrArray).Split(new char[] { '\\' });
                if ((int)strArrays.Length == 8)
                {
                    flag = ((!(strArrays[0] == strArrays[2]) || !(strArrays[1] == strArrays[7]) || !(strArrays[3] == strArrays[5]) || !(strArrays[4] == strArrays[6])) && (!(strArrays[0] == strArrays[6]) || !(strArrays[1] == strArrays[3]) || !(strArrays[2] == strArrays[4]) || !(strArrays[5] == strArrays[7])) ? false : true);
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static bool isRoundness(string sRegionDot)
        {
            bool flag;
            try
            {
                string str = sRegionDot.Replace("*", "\\").Trim(new char[] { '\\' });
                char[] chrArray = new char[] { '\\' };
                flag = ((int)str.Split(chrArray).Length == 3 ? true : false);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static bool isTriangle(string sRegionDot)
        {
            bool flag;
            try
            {
                string str = sRegionDot.Replace("*", "\\");
                char[] chrArray = new char[] { '\\' };
                string[] strArrays = str.Trim(chrArray).Split(new char[] { '\\' });
                if ((int)strArrays.Length == 8)
                {
                    flag = (!(strArrays[0] == strArrays[6]) || !(strArrays[1] == strArrays[7]) ? false : true);
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private static double rad(double d)
        {
            return d * 3.14159265358979 / 180;
        }

        private static bool StringCompare(ref string errMsg, string val, object minLen, object maxLen)
        {
            int length = val.Length;
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] > 'ÿ')
                {
                    length++;
                }
            }
            if (minLen != null && length.CompareTo(minLen) < 0)
            {
                errMsg = string.Format("字符长度不能小于{0}个字节(一个汉字等于2个字节)!", minLen);
                return false;
            }
            if (maxLen == null || length.CompareTo(maxLen) <= 0)
            {
                return true;
            }
            errMsg = string.Format("字符长度不能大于{0}个字节(一个汉字等于2个字节)!", maxLen);
            return false;
        }

        public static string ValueReplace(string sValue)
        {
            string str = "";
            try
            {
                string[] strArrays = sValue.Split(new char[] { '[' });
                int num = sValue.IndexOf('[');
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    strArrays[i] = strArrays[i].Replace("]", "[]]");
                    strArrays[i] = strArrays[i].Replace("~", "[~]");
                    strArrays[i] = strArrays[i].Replace("@", "[@]");
                    strArrays[i] = strArrays[i].Replace("^", "[^]");
                    strArrays[i] = strArrays[i].Replace("&", "[&]");
                    strArrays[i] = strArrays[i].Replace("*", "[*]");
                    strArrays[i] = strArrays[i].Replace("(", "[(]");
                    strArrays[i] = strArrays[i].Replace(")", "[)]");
                    strArrays[i] = strArrays[i].Replace(">", "[>]");
                    strArrays[i] = strArrays[i].Replace("<", "[<]");
                    strArrays[i] = strArrays[i].Replace("`", "[`]");
                    strArrays[i] = strArrays[i].Replace("-", "[-]");
                    strArrays[i] = strArrays[i].Replace("=", "[=]");
                    strArrays[i] = strArrays[i].Replace("%", "[%]");
                    if (num == -1)
                    {
                        str = string.Concat(str, strArrays[i]);
                    }
                    else if (i == 0 && num == 0)
                    {
                        str = string.Concat(str, "[[]", strArrays[i]);
                    }
                    else if (num != sValue.Length - 1)
                    {
                        str = (i != (int)strArrays.Length - 1 ? string.Concat(str, strArrays[i], "[[]") : string.Concat(str, strArrays[i]));
                    }
                    else if (i == (int)strArrays.Length - 1 && !string.IsNullOrEmpty(strArrays[i]))
                    {
                        str = string.Concat(str, strArrays[i], "[[]");
                    }
                }
            }
            catch
            {
                str = sValue;
            }
            return str;
        }

        public enum ExportFormat
        {
            Excel = 1,
            Word = 2,
            Pdf = 3
        }

        public enum NumType
        {
            sInt = 1,
            sDecimal = 2,
            sByte = 3
        }
    }
}