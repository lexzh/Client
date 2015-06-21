namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public partial class UpdateClient : FixedForm
    {
        private string m_sUrl = "";
        public string sFileNmae = @"\setup.exe";
        public string sFolder = "";
        private string TempUpdatePath = "";
        private BackgroundWorker workerUpdate = new BackgroundWorker();

        public UpdateClient(string sUrl)
        {
            this.InitializeComponent();
            this.m_sUrl = sUrl;
            this.settext = new SetControlText(this.ShowLabel);
        }

        private void btnCancelDown_Click(object sender, EventArgs e)
        {
            if (this.bCancelDown)
            {
                base.Close();
            }
            else if ((this.UpdateState != 4) && !this.UpdateErr)
            {
                if (MessageBox.Show("正在下载更新，确定要取消吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.bCancelDown = true;
                    this.pbProgress.Value = 100;
                    this.ShowState(1);
                    this.lblProgressText.ForeColor = Color.Red;
                }
            }
            else if ((this.UpdateState != 4) && this.UpdateErr)
            {
                base.Close();
            }
        }

        public void CopyFile(string SourcePath, string ObjPath)
        {
            if (!Directory.Exists(ObjPath))
            {
                Directory.CreateDirectory(ObjPath);
            }
            string[] files = Directory.GetFiles(SourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                System.IO.File.Copy(files[i], ObjPath + @"\" + Path.GetFileName(files[i]), true);
            }
            string[] directories = Directory.GetDirectories(SourcePath);
            for (int j = 0; j < directories.Length; j++)
            {
                string[] strArray3 = directories[j].Replace("back", "..").Split(new char[] { '\\' });
                this.CopyFile(directories[j], ObjPath + @"\" + strArray3[strArray3.Length - 1]);
            }
        }

        public void CreateDirtory(string Path)
        {
            if (!System.IO.File.Exists(Path))
            {
                string[] strArray = Path.Split(new char[] { '\\' });
                string path = string.Empty;
                for (int i = 0; i < (strArray.Length - 1); i++)
                {
                    path = path + strArray[i].Trim() + @"\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
            }
        }

 private void DownUpdateFile()
        {
            this.UpdateDownOk = false;
            string str = "setup.exe";
            Application.DoEvents();
            this.TempUpdatePath = Environment.GetEnvironmentVariable("Temp") + @"\StarGPSAutoUpdate\";
            WebRequest request = null;
            WebResponse response = null;
            try
            {
                request = WebRequest.Create(this.m_sUrl);
                request.Timeout = 1200000;
                response = request.GetResponse();
                long contentLength = response.ContentLength;
                if (contentLength == -1L)
                {
                    this.ShowState(2);
                    return;
                }
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                byte[] buffer = new byte[contentLength];
                int length = buffer.Length;
                int offset = 0;
                while (contentLength > 0L)
                {
                    if (this.bCancelDown)
                    {
                        this.UpdateDownOk = true;
                        return;
                    }
                    int num4 = responseStream.Read(buffer, offset, length);
                    if (num4 == 0)
                    {
                        break;
                    }
                    offset += num4;
                    length -= num4;
                    float num5 = ((float) offset) / 1024f;
                    float num6 = ((float) buffer.Length) / 1024f;
                    int num7 = Convert.ToInt32((float) ((num5 / num6) * 100f));
                    base.Invoke(this.myShowLable, new object[] { num7 });
                }
                string path = this.TempUpdatePath + str.Replace("..", "back");
                this.CreateDirtory(path);
                FileStream stream2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                stream2.Write(buffer, 0, buffer.Length);
                responseStream.Close();
                reader.Close();
                stream2.Close();
                response.Close();
                request.Abort();
            }
            catch (WebException exception)
            {
                Record.execFileRecord("DownUpdateFile", exception.Message);
                this.ShowState(3);
                return;
            }
            catch (Exception exception2)
            {
                Record.execFileRecord("DownUpdateFile", exception2.Message);
                this.ShowState(5);
                return;
            }
            this.UpdateDownOk = true;
        }

        private void execUpdCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Result == null) && this.UpdateDownOk)
            {
                if (this.bCancelDown)
                {
                    this.btnCancelDown.Text = "关闭";
                }
                else
                {
                    this.sFolder = Application.StartupPath;
                    this.ShowLabel("正在复制新文件，请稍候...");
                    this.CopyFile(this.TempUpdatePath, this.sFolder);
                    Directory.Delete(this.TempUpdatePath, true);
                    this.ShowState(4);
                    base.DialogResult = DialogResult.OK;
                    base.Close();
                }
            }
            else
            {
                try
                {
                    this.lblProgressText.ForeColor = Color.Red;
                    this.pbProgress.Value = 100;
                }
                catch
                {
                }
            }
        }

 private void liveUpdate(object sender, DoWorkEventArgs e)
        {
            this.DownUpdateFile();
        }

        private void ShowGroprossBarValue(int iInval)
        {
            if (!this.bCancelDown)
            {
                this.iValue = iInval;
                this.lblProgressText.Text = string.Format("正在下载更新文件，已下载 {0} %", iInval);
                this.pbProgress.Value = this.iValue;
            }
        }

        private void ShowLabel(string Str)
        {
            this.lblProgressText.Text = Str;
        }

        private void ShowState(int Str)
        {
            switch (Str)
            {
                case 0:
                    base.Invoke(this.settext, new object[] { "配置文件错误，无法进行更新！" });
                    break;

                case 1:
                    base.Invoke(this.settext, new object[] { "取消下载成功" });
                    break;

                case 2:
                    base.Invoke(this.settext, new object[] { "无更新文件" });
                    break;

                case 3:
                    base.Invoke(this.settext, new object[] { "更新文件下载失败" });
                    break;

                case 4:
                    base.Invoke(this.settext, new object[] { "文件下载并更新完成" });
                    break;

                case 5:
                    base.Invoke(this.settext, new object[] { "文件下载完成，更新出现错误" });
                    break;
            }
            this.UpdateErr = true;
            this.UpdateState = Str;
        }

        private void StartDown()
        {
            try
            {
                this.workerUpdate = new BackgroundWorker();
                this.workerUpdate.WorkerReportsProgress = true;
                this.workerUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.execUpdCompleted);
                this.workerUpdate.ProgressChanged += new ProgressChangedEventHandler(this.workerUpdate_ProgressChanged);
                this.workerUpdate.DoWork += new DoWorkEventHandler(this.liveUpdate);
                this.workerUpdate.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("下载更新文件", exception.Message);
            }
        }

        private void UpdateClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((!this.bCancelDown && (this.UpdateState != 4)) && !this.UpdateErr)
            {
                if (MessageBox.Show("更新还尚未完成，是否真的要退出？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.bCancelDown = true;
                }
                else
                {
                    this.pbProgress.Value = this.iValue;
                    e.Cancel = true;
                }
            }
        }

        private void UpdateClient_Load(object sender, EventArgs e)
        {
            this.myShowLable = new DShowLable(this.ShowGroprossBarValue);
            this.StartDown();
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.workerUpdate.ReportProgress(e.ProgressPercentage);
        }

        private void workerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lblProgressText.Text = e.UserState.ToString();
            this.pbProgress.Value = e.ProgressPercentage;
        }

        private delegate void DShowLable(int iInv);

        private delegate void SetControlText(string text);
    }
}

