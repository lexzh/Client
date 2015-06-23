namespace Library
{
    using System;
    using System.Text;

    public class AlarmMsg
    {
        public string AlarmText;
        public string ClassName;
        public string Code;
        public string FunctionName;

        public AlarmMsg()
        {
            this.ClassName = string.Empty;
            this.FunctionName = string.Empty;
            this.AlarmText = string.Empty;
            this.Code = string.Empty;
        }

        public AlarmMsg(string clsName, string funName, string msg)
        {
            this.ClassName = string.Empty;
            this.FunctionName = string.Empty;
            this.AlarmText = string.Empty;
            this.Code = string.Empty;
            this.ClassName = clsName;
            this.FunctionName = funName;
            this.AlarmText = msg;
        }

        public string GetMsg()
        {
            string str = " ";
            StringBuilder builder = new StringBuilder();
            builder.Append("Alarm:" + str + DateTime.Now.ToString() + str + this.Code);
            builder.Append(str + this.ClassName);
            builder.Append(str + this.FunctionName);
            builder.Append(str + this.AlarmText);
            return builder.ToString();
        }
    }
}

