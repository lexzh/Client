namespace Library
{
    using System;

    public class DateHelper : Base
    {
        public DateTime DateTimeFormat(string str)
        {
            DateTime time;
            try
            {
                time = DateTime.ParseExact(str, "yyyyMMddHHmmss", null);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return time;
        }

        public string GetCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:ss:ff");
        }
    }
}

