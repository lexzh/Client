namespace Library
{
    using System;
    using System.Text;

    public class LogMsg
    {
        public string ClassName;
        public string FunctionName;
        public string Msg;

        public LogMsg()
        {
            this.ClassName = string.Empty;
            this.FunctionName = string.Empty;
            this.Msg = string.Empty;
        }

        public LogMsg(string clsName, string funName, string msg)
        {
            this.ClassName = string.Empty;
            this.FunctionName = string.Empty;
            this.Msg = string.Empty;
            this.ClassName = clsName;
            this.FunctionName = funName;
            this.Msg = msg;
        }

        public string GetMsg()
        {
            string str = " ";
            StringBuilder builder = new StringBuilder();
            builder.Append("Log:" + str + DateTime.Now.ToString());
            builder.Append(str + this.ClassName);
            builder.Append(str + this.FunctionName);
            builder.Append(str + this.Msg);
            return builder.ToString();
        }
    }
}

