namespace Library
{
    using System;
    using System.Text;

    public class ErrorMsg
    {
        public string ClassName;
        public string ErrorText;
        public string FunctionName;

        public ErrorMsg()
        {
            this.ClassName = string.Empty;
            this.FunctionName = string.Empty;
            this.ErrorText = string.Empty;
        }

        public ErrorMsg(string clsName, string funName, string msg)
        {
            this.ClassName = string.Empty;
            this.FunctionName = string.Empty;
            this.ErrorText = string.Empty;
            this.ClassName = clsName;
            this.FunctionName = funName;
            this.ErrorText = msg;
        }

        public string GetMsg()
        {
            string str = " ";
            StringBuilder builder = new StringBuilder();
            builder.Append("Error:" + str + DateTime.Now.ToString());
            builder.Append(str + this.ClassName);
            builder.Append(str + this.FunctionName);
            builder.Append(str + this.ErrorText);
            return builder.ToString();
        }
    }
}

