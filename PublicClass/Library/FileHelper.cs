namespace Library
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;
    using System.Xml;

    public class FileHelper : Base
    {
        private static int _Day = DateTime.Today.Day;
        private static ArrayList _list = new ArrayList(200);
        private static bool bWrite = false;
        private static int fielNum = 0;
        protected static string FilePath = ReadParamFromXml("logPath");
        private const int fileSiza = 0x493e0;
        private static DataSet m_ParamData = LoadParamData();
        private const string prxFilename = "-timerLog.txt";

        static FileHelper()
        {
            try
            {
                if (string.IsNullOrEmpty(FilePath))
                {
                    FilePath = @"c:\LogPic";
                }
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
            }
            catch
            {
                FilePath = @"c:\LogPic";
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
            }
            new Thread(new ThreadStart(FileHelper.StartWrite)) { Priority = ThreadPriority.AboveNormal }.Start();
        }

        private static string GetAssemblyPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string[] strArray = codeBase.Substring(8, codeBase.Length - 8).Split(new char[] { '/' });
            string str2 = "";
            for (int i = 0; i < (strArray.Length - 1); i++)
            {
                str2 = str2 + strArray[i] + "/";
            }
            return str2;
        }

        private static string GetFileName()
        {
            if ((FileName == null) || (FileName.Length <= 0))
            {
                InitFileName();
            }
            if (_Day != DateTime.Today.Day)
            {
                fielNum = 0;
                _Day = DateTime.Today.Day;
                InitFileName();
            }
            FileInfo info = new FileInfo(FileName);
            if (info.Exists && (info.Length >= 0x493e0L))
            {
                int num = 0;
                while (true)
                {
                    FileName = FilePath + @"\" + DateTime.Today.ToString("yyyyMMdd") + "-" + num.ToString() + "-timerLog.txt";
                    info = new FileInfo(FileName);
                    if (!info.Exists || (info.Exists && (info.Length < 0x493e0L)))
                    {
                        fielNum = num;
                        break;
                    }
                    num++;
                }
            }
            return FileName;
        }

        private static void InitFileName()
        {
            FileName = FilePath + @"\" + DateTime.Today.ToString("yyyyMMdd") + "-" + fielNum.ToString() + "-timerLog.txt";
        }

        private static DataSet LoadParamData()
        {
            DataSet set = new DataSet();
            set.ReadXml(GetAssemblyPath() + @"\param.xml");
            return set;
        }

        public static DataSet ReadDataXml(string string_0)
        {
            DataSet set = new DataSet();
            set.ReadXml(GetAssemblyPath() + @"\" + string_0);
            return set;
        }

        public static string ReadParamFromXml(string pName)
        {
            string str = string.Empty;
            try
            {
                if (m_ParamData == null)
                {
                    m_ParamData = LoadParamData();
                }
                str = Convert.ToString(m_ParamData.Tables[0].Rows[0][pName]);
            }
            catch (Exception exception)
            {
                LogHelper helper = new LogHelper();
                ErrorMsg pErrorMsg = new ErrorMsg("filehelper", "方法ReadParamFromXml", "读取配置参数错误" + exception.Message);
                helper.WriteError(pErrorMsg);
            }
            return str;
        }

        public string ReadText()
        {
            return this.ReadText(FilePath + FileName);
        }

        public string ReadText(string pFileName)
        {
            StreamReader reader = null;
            StringBuilder builder = new StringBuilder();
            try
            {
                reader = new StreamReader(pFileName, true);
                while (reader.Peek() >= 0)
                {
                    builder.Append(reader.ReadLine());
                }
                reader.Close();
            }
            catch
            {
            }
            finally
            {
                reader.Close();
            }
            return builder.ToString();
        }

        public string ReadWebConfigFile(string pName)
        {
            string pStr = ConfigurationSettings.AppSettings[pName];
            return base.ConvertNullToEmpty(pStr);
        }

        public static string ReadXmlEveryOne(string pName)
        {
            string str = string.Empty;
            try
            {
                str = Convert.ToString(LoadParamData().Tables[0].Rows[0][pName]);
            }
            catch (Exception exception)
            {
                LogHelper helper = new LogHelper();
                ErrorMsg pErrorMsg = new ErrorMsg("filehelper", "方法ReadXmlEveryOne", "读取配置参数错误" + exception.Message);
                helper.WriteError(pErrorMsg);
            }
            return str;
        }

        public static void setConfig(string appKey, string AppValue)
        {
            string filename = GetAssemblyPath() + @"\param.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("//param");
            XmlElement element = (XmlElement) node.SelectSingleNode("//" + appKey);
            if (element != null)
            {
                element.InnerText = AppValue;
            }
            else
            {
                XmlElement newChild = document.CreateElement(appKey);
                newChild.InnerText = AppValue;
                node.AppendChild(newChild);
            }
            document.Save(filename);
        }

        public static void StartWrite()
        {
            bWrite = true;
            while (bWrite)
            {
                try
                {
                    StringBuilder builder = new StringBuilder();
                    while (_list.Count > 0)
                    {
                        builder.Append(_list[0]);
                        _list.RemoveAt(0);
                    }
                    if (builder.Length > 0)
                    {
                        write(builder.ToString());
                    }
                }
                catch
                {
                }
                Thread.Sleep(500);
            }
        }

        public static void StopWrite()
        {
            Thread.Sleep(0x7d0);
            bWrite = false;
        }

        private static void write(string pMsg)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(GetFileName(), true);
                writer.WriteLine(pMsg);
            }
            catch (Exception exception)
            {
                StreamWriter writer2 = null;
                try
                {
                    writer2 = new StreamWriter(FilePath + @"\" + DateTime.Today.ToString("yyyyMMdd") + "-Temp.txt", true);
                    writer2.WriteLine("Error： 写日志发生错误：" + exception.Message);
                    writer2.WriteLine(pMsg);
                }
                catch
                {
                }
                finally
                {
                    if (writer2 != null)
                    {
                        writer2.Close();
                    }
                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void WriteText(string pMsg)
        {
            _list.Add(pMsg);
        }

        protected static string FileName
        {
            get;
            set;
        }
    }
}

