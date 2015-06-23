namespace Library
{
    using System;
    using System.IO;

    public class LogHelper : FileHelper
    {
        private const bool IsWriteFlag = true;

        public void DeleteOldRecord(int iLogSaveDate)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(FileHelper.FilePath);
                if (!info.Exists)
                {
                    return;
                }
                foreach (FileInfo info2 in info.GetFiles())
                {
                    if (info2.CreationTime.AddDays((double) iLogSaveDate).Date < DateTime.Now.Date)
                    {
                        File.Delete(info2.FullName);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorMsg pErrorMsg = new ErrorMsg("LogHelper", "清除旧日志文件", exception.Message);
                new LogHelper().WriteError(pErrorMsg);
                return;
            }
            LogMsg pLogMsg = new LogMsg("LogHelper", "清除旧日志文件", "成功");
            new LogHelper().WriteLog(pLogMsg);
        }

        public void WriteAlarm(AlarmMsg pErrorMsg)
        {
            base.WriteText(pErrorMsg.GetMsg() + "\n");
        }

        public void WriteAlarm(AlarmMsg pErrorMsg, string funName)
        {
            pErrorMsg.FunctionName = funName;
            base.WriteText(pErrorMsg.GetMsg() + "\n");
        }

        public void WriteError(ErrorMsg pErrorMsg)
        {
            base.WriteText(pErrorMsg.GetMsg() + "\n");
        }

        public void WriteError(ErrorMsg pErrorMsg, Exception ex)
        {
            base.WriteText(pErrorMsg.GetMsg() + "\n" + ex.Message + "\n" + ex.StackTrace + "\n");
        }

        public void WriteError(ErrorMsg pErrorMsg, Exception ex, string funName)
        {
            pErrorMsg.FunctionName = funName;
            base.WriteText(pErrorMsg.GetMsg() + "\n" + ex.Message + "\n" + ex.StackTrace + "\n");
        }

        public void WriteLog(LogMsg pLogMsg)
        {
            base.WriteText(pLogMsg.GetMsg() + "\n");
        }

        public void WriteLog(LogMsg pLogMsg, string pMsg)
        {
            pLogMsg.Msg = pMsg;
            base.WriteText(pLogMsg.GetMsg() + "\n");
        }

        public void WriteLog(LogMsg pLogMsg, string funName, string pMsg)
        {
            pLogMsg.FunctionName = funName;
            pLogMsg.Msg = pMsg;
            base.WriteText(pLogMsg.GetMsg() + "\n");
        }
    }
}

