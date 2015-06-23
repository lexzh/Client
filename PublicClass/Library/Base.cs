namespace Library
{
    using System;
    using System.Diagnostics;

    public class Base
    {
        protected string ConvertNullToEmpty(string pStr)
        {
            if (pStr == null)
            {
                pStr = string.Empty;
            }
            return pStr;
        }

        public string GetCallFunction()
        {
            string name = string.Empty;
            StackFrame frame = new StackTrace().GetFrame(2);
            if (frame != null)
            {
                name = frame.GetMethod().Name;
            }
            return name;
        }

        public string GetExceptionMsg(Exception ex)
        {
            return (ex.Message + ex.StackTrace);
        }
    }
}

