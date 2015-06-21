namespace Client
{
    using JTB;
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public partial class ImageList : LogForm
    {
        private bool _isPlayerAudio = true;

        public ImageList()
        {
            this.InitializeComponent();
        }

        private void _mediaDownLoadThread_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] strArray = e.Argument.ToString().Split(new char[] { ',' });
            string str = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media\" + strArray[0] + strArray[1].Replace(":", ""));
            if (this._isPlayerAudio && File.Exists(str + ".wav"))
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media\" + strArray[0] + strArray[1].Replace(":", "") + ".wav");
                if (File.Exists(path))
                {
                    e.Result = path;
                }
            }
            else if (!this._isPlayerAudio && File.Exists(str + ".wmv"))
            {
                string str3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media\" + strArray[0] + strArray[1].Replace(":", "") + ".wmv");
                if (File.Exists(str3))
                {
                    e.Result = str3;
                }
            }
            else
            {
                DataTable table = RemotingClient.Car_GetCarMutilVideoInfo(strArray[0], strArray[1], strArray[2], this._isPlayerAudio ? "2" : "3", "");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    object obj2 = null;
                    if (this._isPlayerAudio)
                    {
                        if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pic")))
                        {
                            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pic"));
                        }
                        if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media")))
                        {
                            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media"));
                        }
                        string str4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media\" + strArray[0] + strArray[1].Replace(":", "") + ".wav");
                        Stream stream = null;
                        try
                        {
                            try
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    if (row["PicDataType"].ToString().Equals("2"))
                                    {
                                        obj2 = table.Rows[0]["pic"];
                                        break;
                                    }
                                }
                                if (obj2 != DBNull.Value)
                                {
                                    byte[] buffer = (byte[]) obj2;
                                    stream = File.Open(str4, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    stream.Write(buffer, 0, buffer.Length);
                                    stream.Close();
                                }
                            }
                            catch (Exception exception)
                            {
                                Record.execFileRecord("异常下载音频", exception.Message);
                            }
                            return;
                        }
                        finally
                        {
                            if (stream != null)
                            {
                                stream.Close();
                                stream = null;
                            }
                            e.Result = str4;
                        }
                    }
                    if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pic")))
                    {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pic"));
                    }
                    if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media")))
                    {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media"));
                    }
                    Stream stream2 = null;
                    string str5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pic\Media\" + strArray[0] + strArray[1].Replace(":", "") + ".wmv");
                    try
                    {
                        foreach (DataRow row2 in table.Rows)
                        {
                            if (row2["PicDataType"].ToString().Equals("3"))
                            {
                                obj2 = table.Rows[0]["pic"];
                                break;
                            }
                        }
                        if ((obj2 != DBNull.Value) && !File.Exists(str5))
                        {
                            byte[] buffer2 = (byte[]) obj2;
                            stream2 = File.Open(str5, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            stream2.Write(buffer2, 0, buffer2.Length);
                            stream2.Close();
                            stream2 = null;
                        }
                    }
                    catch (Exception exception2)
                    {
                        Record.execFileRecord("异常下载视频", exception2.Message);
                    }
                    finally
                    {
                        if (stream2 != null)
                        {
                            stream2.Close();
                            stream2 = null;
                        }
                        e.Result = str5;
                    }
                }
            }
        }

        private void _mediaDownLoadThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (this._isPlayerAudio && (e.Result != null))
                {
                    if (File.Exists(e.Result.ToString()))
                    {
                        VideoBroadcast broadcast = new VideoBroadcast(e.Result.ToString());
                        broadcast.ShowDialog();
                        broadcast.Dispose();
                        broadcast = null;
                    }
                }
                else if (!this._isPlayerAudio && File.Exists(e.Result.ToString()))
                {
                    VideoBroadcast broadcast2 = new VideoBroadcast(e.Result.ToString());
                    broadcast2.ShowDialog();
                    broadcast2.Dispose();
                    broadcast2 = null;
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("异常播放获取的音视频", exception.Message);
            }
            finally
            {
                this.pnlMedia.Enabled = true;
            }
        }

        public override void addLogMsg(DataTable dtLogResult)
        {
            if ((dtLogResult != null) && (dtLogResult.Rows.Count != 0))
            {
                DataView view = null;
                this.bIsCompleted = false;
                try
                {
                    DataRow row;
                    view = new DataView(dtLogResult) {
                        RowFilter = base.m_dvLogData.RowFilter
                    };
                    int firstDisplayedScrollingRowIndex = base.dgvLogData.FirstDisplayedScrollingRowIndex;
                    dtLogResult.Columns.Add(new DataColumn("ColLog"));
                    dtLogResult.Columns.Add(new DataColumn("showImage"));
                    int count = view.Count;
                    if (base.m_dvLogData.Sort.Length == 0)
                    {
                        base.m_dtLogData = dtLogResult.Clone();
                        base.m_dvLogData = new DataView(base.m_dtLogData, "", "ReceTime DESC", DataViewRowState.CurrentRows);
                        base.dgvLogData.DataSource = base.m_dvLogData;
                    }
                    int iRowCnt = base.dgvLogData.Rows.Count + count;
                    int num4 = base.m_dvLogData.Count;
                    int num5 = 0;
                    if (count >= base.iMaxLogCnt)
                    {
                        base.m_dtLogData.Rows.Clear();
                        num5 = count - base.iMaxLogCnt;
                    }
                    else if (iRowCnt > base.iMaxLogCnt)
                    {
                        for (int i = 1; i <= (iRowCnt - base.iMaxLogCnt); i++)
                        {
                            base.m_dvLogData.Delete((int) (num4 - i));
                        }
                    }
                    base.m_dvLogData.Sort = "";
                    int num7 = 0;
                    while (num5 < count)
                    {
                        row = view[num5].Row;
                        row["gpsTime"].ToString();
                        row["carNum"].ToString();
                        row["simNum"].ToString();
                        row["cameraid"].ToString();
                        num7 = base.dgvLogData.SelectedRows.Count;
                        base.m_dtLogData.ImportRow(row);
                        num5++;
                    }
                    base.SetCurrentRow(base.dgvLogData, iRowCnt, base.iMaxLogCnt, count);
                    num7 = base.dgvLogData.SelectedRows.Count;
                    row = null;
                    base.m_dvLogData.Sort = "ReceTime DESC";
                    if (num7 == 0)
                    {
                        base.dgvLogData.ClearSelection();
                    }
                    if (firstDisplayedScrollingRowIndex >= 0)
                    {
                        base.dgvLogData.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                    }
                    base.dgvLogData.Refresh();
                    view.Dispose();
                    view = null;
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("图像日志添加操作", exception.Message);
                    }
                }
                finally
                {
                    if (dtLogResult != null)
                    {
                        dtLogResult = null;
                    }
                    this.bIsCompleted = true;
                }
            }
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            this.playMedia(DataType.Audio);
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            this.playMedia(DataType.Video);
        }

        private void dgvLogData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.Button == MouseButtons.Left))
            {
                try
                {
                    string sPicFolderPath = Variable.sPicFolderPath;
                    string str2 = base.dgvLogData["ReadPicTime", e.RowIndex].Value.ToString();
                    string str3 = base.dgvLogData["carNum", e.RowIndex].Value.ToString();
                    string str4 = base.dgvLogData["simNum", e.RowIndex].Value.ToString();
                    string str5 = base.dgvLogData["cameraid", e.RowIndex].Value.ToString();
                    string s = base.dgvLogData["ReceTime", e.RowIndex].Value.ToString();
                    string str7 = base.m_dtLogData.Columns.Contains("PicDataType") ? base.dgvLogData["PicDataType", e.RowIndex].Value.ToString() : string.Empty;
                    if (str7.Equals(string.Empty) || str7.Equals("1"))
                    {
                        this.pnlMedia.Visible = false;
                        sPicFolderPath = sPicFolderPath + DateTime.Parse(s).ToString("yyyy-MM-dd") + @"\";
                        string str8 = DateTime.Parse(s).ToString("yyyyMMddHHmmssffff") + str3 + str5 + ".jpg";
                        FileInfo info = new FileInfo(sPicFolderPath + str8);
                        if (!info.Exists)
                        {
                            for (int i = 0; i < base.m_dtLogData.Rows.Count; i++)
                            {
                                base.m_dtLogData.Rows[i]["showImage"] = "";
                            }
                            base.dgvLogData.Rows[e.RowIndex].Cells["showImage"].Value = "正在下载";
                            string[] sArgLst = new string[] { str2, str3, str4, str5, s };
                            this.linkLblDownImg.Text = "正在下载车辆[" + str3 + "]图片,请稍候...";
                            this.linkLblDownImg.Visible = true;
                            this.pbImage.Visible = false;
                            this.GetCarImgInfo(sArgLst);
                        }
                        else
                        {
                            this.ShowImage(sPicFolderPath + str8);
                        }
                    }
                    else if (str7.Equals("2"))
                    {
                        this.pbImage.Image = null;
                        this.btnVideo.Visible = false;
                        this.btnSound.Visible = true;
                        this.pnlMedia.Visible = true;
                    }
                    else if (str7.Equals("3"))
                    {
                        this.pbImage.Image = null;
                        this.btnVideo.Visible = true;
                        this.btnSound.Visible = false;
                        this.pnlMedia.Visible = true;
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("显示图像", exception.Message);
                }
            }
        }

        private void dgvLogData_SelectionChanged(object sender, EventArgs e)
        {
            if (this.bIsCompleted)
            {
                try
                {
                    if (base.dgvLogData.CurrentRow == null)
                    {
                        this.linkLblDownImg.Visible = false;
                    }
                    else
                    {
                        int num = (base.dgvLogData.SelectedRows.Count > 0) ? base.dgvLogData.SelectedRows[0].Index : -1;
                        if (num >= 0)
                        {
                            string sPicFolderPath = Variable.sPicFolderPath;
                            string str2 = base.dgvLogData["carNum", num].Value.ToString();
                            string str3 = base.dgvLogData["cameraid", num].Value.ToString();
                            string s = base.dgvLogData["ReceTime", num].Value.ToString();
                            sPicFolderPath = sPicFolderPath + DateTime.Parse(s).ToString("yyyy-MM-dd") + @"\";
                            string str5 = DateTime.Parse(s).ToString("yyyyMMddHHmmssffff") + str2 + str3 + ".jpg";
                            FileInfo info = new FileInfo(sPicFolderPath + str5);
                            if (!info.Exists)
                            {
                                this.getPic();
                            }
                            else
                            {
                                this.ShowImage(sPicFolderPath + str5);
                            }
                            info = null;
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.linkLblDownImg.Visible = true;
                    this.linkLblDownImg.Text = "下载失败";
                    Record.execFileRecord("图片报文选择行变更", exception.Message);
                }
            }
        }

 private void downLoadMediaFile(string sCarPhone, string sGpsTime, string sCameraId)
        {
            if (this._mediaDownLoadThread == null)
            {
                this._mediaDownLoadThread = new BackgroundWorker();
                this._mediaDownLoadThread.WorkerSupportsCancellation = true;
                this._mediaDownLoadThread.DoWork += new DoWorkEventHandler(this._mediaDownLoadThread_DoWork);
                this._mediaDownLoadThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._mediaDownLoadThread_RunWorkerCompleted);
            }
            if (this._mediaDownLoadThread.IsBusy)
            {
                this._mediaDownLoadThread.CancelAsync();
                this.pnlMedia.Enabled = true;
            }
            else
            {
                try
                {
                    this._mediaDownLoadThread.RunWorkerAsync(sCarPhone + "," + sGpsTime + "," + sCameraId);
                }
                catch
                {
                    this.pnlMedia.Enabled = true;
                }
            }
        }

        private void GetCarImgInfo(string[] sArgLst)
        {
            if (this.worker == null)
            {
                this.worker = new BackgroundWorker();
            }
            try
            {
                this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
                this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
                this.worker.WorkerReportsProgress = true;
                this.worker.RunWorkerAsync(sArgLst);
            }
            catch (Exception)
            {
            }
        }

        private void getPic()
        {
            int num = (base.dgvLogData.SelectedRows.Count > 0) ? base.dgvLogData.SelectedRows[0].Index : -1;
            if (num >= 0)
            {
                try
                {
                    string str = base.dgvLogData["ReadPicTime", num].Value.ToString();
                    string str2 = base.dgvLogData["carNum", num].Value.ToString();
                    string str3 = base.dgvLogData["simNum", num].Value.ToString();
                    string str4 = base.dgvLogData["cameraid", num].Value.ToString();
                    string str5 = base.dgvLogData["ReceTime", num].Value.ToString();
                    string str6 = base.m_dtLogData.Columns.Contains("PicDataType") ? base.dgvLogData["PicDataType", num].Value.ToString() : string.Empty;
                    if (str6.Equals(string.Empty) || str6.Equals("1"))
                    {
                        string[] sArgLst = new string[] { str, str2, str3, str4, str5 };
                        this.linkLblDownImg.Text = "正在下载车辆[" + str2 + "]图片,请稍候...";
                        this.linkLblDownImg.Visible = true;
                        this.pbImage.Visible = false;
                        this.GetCarImgInfo(sArgLst);
                    }
                }
                catch
                {
                }
            }
        }

 public void InitImageList()
        {
            this.linkLblDownImg.Visible = false;
            base.dgvLogData.Columns["ReceTime"].Visible = true;
            base.dgvLogData.Columns["CarName"].Visible = true;
            base.dgvLogData.Columns["CameraId"].Visible = true;
            base.dgvLogData.Columns["describe"].Visible = true;
            base.dgvLogData.Columns["orderid"].Visible = false;
            base.dgvLogData.Columns["carNum"].Visible = false;
            base.dgvLogData.Columns["OrderType"].Visible = false;
            base.dgvLogData.Columns["OrderName"].Visible = false;
            base.dgvLogData.Columns["msgtype"].Visible = false;
            base.dgvLogData.Columns["OrderResult"].Visible = false;
            base.dgvLogData.Columns["commFlag"].Visible = false;
            base.dgvLogData.Columns["showImage"].Visible = false;
            base.dgvLogData.Columns["GpsTime"].Visible = false;
            base.dgvLogData.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dgvLogData_CellMouseClick);
            base.dgvLogData.SelectionChanged += new EventHandler(this.dgvLogData_SelectionChanged);
        }

        private void linkLblDownImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.getPic();
        }

        private void playMedia(DataType typ)
        {
            string sGpsTime = base.dgvLogData["ReadPicTime", base.dgvLogData.CurrentRow.Index].Value.ToString();
            base.dgvLogData["carNum", base.dgvLogData.CurrentRow.Index].Value.ToString();
            string sCarPhone = base.dgvLogData["simNum", base.dgvLogData.CurrentRow.Index].Value.ToString();
            string sCameraId = base.dgvLogData["cameraid", base.dgvLogData.CurrentRow.Index].Value.ToString();
            base.dgvLogData["ReceTime", base.dgvLogData.CurrentRow.Index].Value.ToString();
            this.pnlMedia.Enabled = false;
            this._isPlayerAudio = typ == DataType.Audio;
            this.downLoadMediaFile(sCarPhone, sGpsTime, sCameraId);
        }

        private void ShowImage(string sFilePath)
        {
            this.linkLblDownImg.Visible = false;
            this.pbImage.Visible = true;
            Image image = null;
            try
            {
                if (base.dgvLogData.SelectedRows.Count != 0)
                {
                    image = Image.FromFile(sFilePath);
                    this.pbImage.Image = image;
                    this.pbImage.Size = image.Size;
                }
            }
            catch (OutOfMemoryException exception)
            {
                Record.execFileRecord("显示图片", exception.Message);
                GC.Collect();
            }
            catch (Exception exception2)
            {
                Record.execFileRecord("显示图片", exception2.Message);
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
            }
        }

        protected override void tbRemove_Click(object sender, EventArgs e)
        {
            base.tbRemove_Click(sender, e);
            this.pbImage.Image = null;
            this.pnlMedia.Visible = false;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                e.Cancel = true;
            }
            else
            {
                string[] argument = e.Argument as string[];
                if ((argument != null) && (argument.Length > 0))
                {
                    string sPicFolderPath = Variable.sPicFolderPath;
                    string strGpsTime = argument[0];
                    string str3 = argument[1];
                    string strPhone = argument[2];
                    string strCaremaId = argument[3];
                    string s = argument[4];
                    sPicFolderPath = sPicFolderPath + DateTime.Parse(s).ToString("yyyy-MM-dd") + @"\";
                    DirectoryInfo info = new DirectoryInfo(sPicFolderPath);
                    if (!info.Exists)
                    {
                        info.Create();
                    }
                    string str7 = DateTime.Parse(s).ToString("yyyyMMddHHmmssffff") + str3 + strCaremaId + ".jpg";
                    FileInfo info2 = new FileInfo(sPicFolderPath + str7);
                    if (!info2.Exists)
                    {
                        DataTable table = RemotingClient.Car_GetCarImgInfo(strPhone, strGpsTime, strCaremaId, "");
                        if ((table != null) && (table.Rows.Count > 0))
                        {
                            object obj2 = null;
                            Stream stream = null;
                            try
                            {
                                obj2 = table.Rows[0]["pic"];
                                if (obj2 == DBNull.Value)
                                {
                                    e.Result = null;
                                    return;
                                }
                                byte[] buffer = (byte[]) obj2;
                                stream = info2.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                                stream.Write(buffer, 0, buffer.Length);
                                stream.Close();
                                stream = null;
                            }
                            finally
                            {
                                if (stream != null)
                                {
                                    stream.Close();
                                    stream = null;
                                }
                            }
                            e.Result = e.Argument;
                        }
                        else
                        {
                            Record.execFileRecord("图像日志", "数据库没有该图像记录！");
                            e.Result = null;
                        }
                    }
                }
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.linkLblDownImg.Text = "下载图片";
            if (((e.Error == null) && !e.Cancelled) && (e.Result != null))
            {
                this.linkLblDownImg.Visible = false;
                this.pbImage.Visible = true;
                string[] result = e.Result as string[];
                string sPicFolderPath = Variable.sPicFolderPath;
                try
                {
                    string str2 = result[0];
                    string str3 = result[1];
                    string text1 = result[2];
                    string str4 = result[3];
                    string s = result[4];
                    sPicFolderPath = sPicFolderPath + DateTime.Parse(s).ToString("yyyy-MM-dd") + @"\";
                    string str6 = DateTime.Parse(s).ToString("yyyyMMddHHmmssffff") + str3 + str4 + ".jpg";
                    FileInfo info = new FileInfo(sPicFolderPath + str6);
                    int num = (base.dgvLogData.SelectedRows.Count > 0) ? base.dgvLogData.SelectedRows[0].Index : -1;
                    if ((info.Exists && (num >= 0)) && base.dgvLogData["ReadPicTime", num].Value.ToString().Equals(str2, StringComparison.OrdinalIgnoreCase))
                    {
                        this.ShowImage(sPicFolderPath + str6);
                    }
                    else
                    {
                        this.linkLblDownImg.Visible = true;
                        this.pbImage.Visible = false;
                    }
                    info = null;
                }
                catch (Exception exception)
                {
                    this.linkLblDownImg.Text = "下载失败";
                    Record.execFileRecord("下载图片完成事件", exception.Message);
                }
            }
            else
            {
                this.pbImage.Image = null;
                this.linkLblDownImg.Text = "下载失败";
                if (e.Error != null)
                {
                    Record.execFileRecord("下载图片完成事件 下载失败", e.Error.ToString());
                }
            }
        }
    }
}

