namespace PublicClass
{
    using System;
    using System.IO;
    using System.Text;

    public class Record
    {
        private FileInfo fAFile;
        private FileInfo fFile;
        private FileStream myAStream;
        private static Record myRecord = new Record();
        private FileStream myStream;

        private Record()
        {
        }

        public static void execDeletePic()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(Variable.sPicFolderPath);
                if (!info.Exists)
                {
                    return;
                }
                foreach (DirectoryInfo info2 in info.GetDirectories())
                {
                    if (info2.CreationTime.AddDays((double) int.Parse(Variable.sSavePicDays)).Date < DateTime.Now.Date)
                    {
                        info2.Delete(true);
                    }
                }
            }
            catch (Exception exception)
            {
                execFileRecord("清除旧图像文件", exception.Message);
            }
            execFileRecord("删除旧图像", "成功");
        }

        public static void execDeleteRecord()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(Variable.sLogFolderPath);
                if (!info.Exists)
                {
                    return;
                }
                foreach (FileInfo info2 in info.GetFiles())
                {
                    if (info2.CreationTime.AddDays((double) int.Parse(Variable.sSaveLogDays)).Date < DateTime.Now.Date)
                    {
                        File.Delete(info2.FullName);
                    }
                }
            }
            catch (Exception exception)
            {
                execFileRecord("清除旧日志文件", exception.Message);
            }
            execFileRecord("删除旧日志", "成功");
        }

        public static void execFileAlarmRecord(string sMsg)
        {
            myRecord.execWriteAlarmRecord(sMsg);
        }

        public static void execFileRecord(string sMsg)
        {
            myRecord.execWriteRecord(sMsg);
        }

        public static void execFileRecord(string sProcess, string sErrMsg)
        {
            myRecord.execWriteRecord(sProcess, sErrMsg);
        }

        private string execStringRecord(string sMsg)
        {
            string str = "";
            try
            {
                str = (str + "[" + DateTime.Now.ToString() + "]    ") + sMsg + "\r\n";
            }
            catch
            {
                return sMsg;
            }
            return str;
        }

        private void execWrite(string sMsg)
        {
            try
            {
                this.getRecordFile();
                byte[] bytes = Encoding.Default.GetBytes(sMsg);
                this.myStream.Write(bytes, 0, bytes.Length);
                this.myStream.Flush();
            }
            finally
            {
                if (this.myStream != null)
                {
                    this.myStream.Close();
                }
            }
        }

        private void execWriteAlarm(string sMsg)
        {
            try
            {
                byte[] bytes = Encoding.Default.GetBytes(sMsg);
                this.getAlarmRecordFile();
                this.myAStream.Write(bytes, 0, bytes.Length);
                this.myAStream.Flush();
            }
            catch
            {
            }
            finally
            {
                if (this.myAStream != null)
                {
                    this.myAStream.Close();
                }
            }
        }

        private void execWriteAlarmRecord(string sMsg)
        {
            try
            {
                this.execWriteAlarm(this.execStringRecord(sMsg));
            }
            catch
            {
            }
        }

        private void execWriteRecord(string sMsg)
        {
            try
            {
                this.execWrite(this.execStringRecord(sMsg));
            }
            catch
            {
            }
        }

        private void execWriteRecord(string sProcess, string sErrMsg)
        {
            try
            {
                string str = DateTime.Now.ToString();
                string sMsg = "";
                sMsg = ((sMsg + "[" + str + "]    ") + sProcess + "：") + sErrMsg + "\r\n";
                this.execWrite(sMsg);
            }
            catch
            {
            }
        }

        private void getAlarmRecordFile()
        {
            int num = 0x19000;
            if ((this.myAStream != null) && this.myAStream.CanWrite)
            {
                this.fAFile = new FileInfo(this.myAStream.Name);
                if (this.fAFile.Length < num)
                {
                    return;
                }
            }
            string sLogFolderPath = Variable.sLogFolderPath;
            DirectoryInfo info = new DirectoryInfo(sLogFolderPath);
            if (!info.Exists)
            {
                info.Create();
            }
            string str2 = DateTime.Now.ToString("yyyyMMdd");
            string str3 = "";
            int num2 = 1;
        Label_007A:
            str3 = str2 + "-" + num2.ToString() + "-aLog.txt";
            this.fAFile = new FileInfo(sLogFolderPath + str3);
            if (!this.fAFile.Exists)
            {
                this.myAStream = this.fAFile.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            }
            else if (this.fAFile.Length < num)
            {
                try
                {
                    this.myAStream = this.fAFile.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                }
                catch
                {
                }
            }
            else
            {
                if (this.myAStream != null)
                {
                    this.myAStream.Close();
                }
                num2++;
                goto Label_007A;
            }
        }

        private void getRecordFile()
        {
            int num = 0x19000;
            if ((this.myStream != null) && this.myStream.CanWrite)
            {
                this.fFile = new FileInfo(this.myStream.Name);
                if (this.fFile.Length < num)
                {
                    return;
                }
            }
            string sLogFolderPath = Variable.sLogFolderPath;
            DirectoryInfo info = new DirectoryInfo(sLogFolderPath);
            if (!info.Exists)
            {
                info.Create();
            }
            string str2 = DateTime.Now.ToString("yyyyMMdd");
            string str3 = "";
            int num2 = 1;
        Label_007A:
            str3 = str2 + "-" + num2.ToString() + "-cLog.txt";
            this.fFile = new FileInfo(sLogFolderPath + str3);
            if (!this.fFile.Exists)
            {
                this.myStream = this.fFile.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            }
            else if (this.fFile.Length < num)
            {
                try
                {
                    this.myStream = this.fFile.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                }
                catch
                {
                }
            }
            else
            {
                if (this.myStream != null)
                {
                    this.myStream.Close();
                }
                num2++;
                goto Label_007A;
            }
        }
    }
}

