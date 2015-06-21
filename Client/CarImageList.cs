namespace Client
{
    using Other;
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class CarImageList : SizableForm
    {
        private bool _isPlayerAudio = true;
        private DataTable dtText = new DataTable();
        private int pageNum = 9;
        private BindingSource source = new BindingSource();

        public CarImageList()
        {
            this.InitializeComponent();
            this.cmbType.SelectedIndex = 0;
            this.flpnl.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.flpnl, true, null);
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
                        this.mediaPlayer1.VideoPlayer.URL = e.Result.ToString();
                    }
                }
                else if (!this._isPlayerAudio && File.Exists(e.Result.ToString()))
                {
                    this.mediaPlayer1.VideoPlayer.URL = e.Result.ToString();
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("多媒体信息查询", exception.Message);
            }
            finally
            {
                base.Enabled = true;
            }
        }

        public void BindCarTextList()
        {
            try
            {
                this.dtText.Rows.Clear();
                foreach (ThreeStateTreeNode node in MainForm.myCarList.tvList.Nodes)
                {
                    if (node != null)
                    {
                        if ((node.Tag != null) && node.Tag.Equals("CAR"))
                        {
                            if (node.Checked)
                            {
                                this.dtText.Rows.Add(new object[] { node.CarNum, node.SimNum });
                            }
                        }
                        else
                        {
                            this.getTreeNodeIsChecked(node, ref this.dtText);
                        }
                    }
                }
                this.source.DataSource = this.dtText;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("多路图像查询->加载数据", exception.Message);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            this.showPic(this.carnum, this.carphone, this.currentPage + 1);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.mediaPlayer1.VideoPlayer.URL = "";
            if (this.dtpEndTime.Value < this.dtpStartTime.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (this.cmbCar.SelectedItem == null)
            {
                MessageBox.Show("请选择要查询的车辆!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DataRowView selectedItem = this.cmbCar.SelectedItem as DataRowView;
                this.carnum = selectedItem["carname"].ToString();
                this.carphone = selectedItem["cartel"].ToString();
                if (this.cmbType.SelectedIndex == 0)
                {
                    try
                    {
                        this.flpnl.BringToFront();
                        string format = "SELECT [carphone],[gpstime],[recetime],[Deltime],[cameraID] FROM [GpsPhotoBuffer] Where [carphone]='{0}' And [picDataType]=1 And [gpstime] between '{1}' And '{2}' Order By gpstime desc ";
                        format = string.Format(format, this.carphone, this.dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        this.data = RemotingClient.ExecSql(format);
                        this.lblPageInfo.Text = "";
                        this.lblInfo.Text = "当前查询车辆：" + selectedItem["carname"].ToString();
                        this.showPic(this.carnum, this.carphone, 0);
                    }
                    catch (Exception exception)
                    {
                        Record.execFileRecord("多媒体信息查询", exception.Message);
                    }
                }
                else
                {
                    try
                    {
                        this.pnlVideoAndSound.BringToFront();
                        string str2 = "SELECT [carphone],[gpstime],[recetime],[cameraID] FROM [GpsPhotoBuffer] Where [carphone]='{0}' And [picDataType]='{3}' And [gpstime] between '{1}' And '{2}' Order By gpstime desc ";
                        DataTable table = RemotingClient.ExecSql(string.Format(str2, new object[] { this.carphone, this.dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.cmbType.SelectedIndex + 1 }));
                        this.lblPageInfo.Text = "";
                        this.lblInfo.Text = "当前查询车辆：" + selectedItem["carname"].ToString();
                        if (this.cmbType.SelectedIndex == 1)
                        {
                            this._isPlayerAudio = true;
                            this.dgvMedia.Columns["cameraID"].Visible = false;
                        }
                        else
                        {
                            this._isPlayerAudio = false;
                            this.dgvMedia.Columns["cameraID"].Visible = true;
                        }
                        if ((table != null) && (table.Rows.Count > 0))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                row["cameraID"] = this.cameralId(row["cameraID"].ToString()).ToString();
                            }
                            this.showNoDataInfo(false, 1);
                            this.dgvMedia.DataSource = table;
                        }
                        else
                        {
                            if (table != null)
                            {
                                this.dgvMedia.DataSource = table.Clone();
                            }
                            this.showNoDataInfo(true, this.cmbType.SelectedIndex);
                        }
                    }
                    catch (Exception exception2)
                    {
                        Record.execFileRecord("多媒体信息查询", exception2.Message);
                    }
                }
            }
        }

        private void btnSearchCar_Click(object sender, EventArgs e)
        {
            try
            {
                base.Enabled = false;
                this.source.Filter = "CarName like '%" + this.txtSearchCar.Text + "%'";
            }
            catch
            {
            }
            finally
            {
                base.Enabled = true;
            }
        }

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            this.showPic(this.carnum, this.carphone, this.currentPage - 1);
        }

        private int cameralId(string id)
        {
            switch (id)
            {
                case "128":
                    return 8;

                case "64":
                    return 7;

                case "32":
                    return 6;

                case "16":
                    return 5;

                case "8":
                    return 4;

                case "4":
                    return 3;

                case "2":
                    return 2;

                case "1":
                    return 1;
            }
            return 1;
        }

        private void CarImageList_Load(object sender, EventArgs e)
        {
            this.dtpStartTime.Value = DateTime.Now.AddMinutes(-10.0);
            this.dtpEndTime.Value = DateTime.Now;
            this.cmbCar.DisplayMember = "CarName";
            this.cmbCar.ValueMember = "CarTel";
            this.cmbCar.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbCar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.initDataTable();
            this.doWorker();
        }

        private void dgvMedia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.playMedia(this._isPlayerAudio ? DataType.Audio : DataType.Video);
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
                base.Enabled = true;
            }
            else
            {
                try
                {
                    this._mediaDownLoadThread.RunWorkerAsync(sCarPhone + "," + sGpsTime + "," + sCameraId);
                }
                catch
                {
                    base.Enabled = true;
                }
            }
        }

        private string downLoadPic(string sCarPhone, string sCarNum, string sGpsTime, string sReceTime, string sCameraId)
        {
            string path = Variable.sPicFolderPath + DateTime.Parse(sReceTime).ToString("yyyy-MM-dd") + @"\";
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                info.Create();
            }
            string str2 = DateTime.Parse(sReceTime).ToString("yyyyMMddHHmmssffff") + sCarNum + sCameraId + ".jpg";
            FileInfo info2 = new FileInfo(path + str2);
            if (!info2.Exists)
            {
                try
                {
                    DataTable table = RemotingClient.Car_GetCarImgInfo(sCarPhone, sGpsTime, this.cameralId(sCameraId).ToString(), "");
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        object obj2 = null;
                        Stream stream = null;
                        try
                        {
                            obj2 = table.Rows[0]["pic"];
                            if (obj2 == DBNull.Value)
                            {
                                return (path + str2);
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
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("下载图像-->", exception.Message);
                }
            }
            return (path + str2);
        }

        private void doWorker()
        {
            WaitForm.Show("正在加载车辆信息...", this);
            if (this.worker == null)
            {
                try
                {
                    this.worker = new BackgroundWorker();
                    this.worker.DoWork += new DoWorkEventHandler(this.worder_DoWork);
                    this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worder_RunWorkerCompleted);
                    this.worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
                    this.worker.WorkerReportsProgress = true;
                    this.worker.RunWorkerAsync();
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("多路图像查询->异步加载", exception.Message);
                }
            }
        }

        private void getTreeNodeIsChecked(ThreeStateTreeNode tn, ref DataTable dt)
        {
            foreach (ThreeStateTreeNode node in tn.Nodes)
            {
                if ((node.Tag != null) && node.Tag.Equals("CAR"))
                {
                    if (node.Checked)
                    {
                        dt.Rows.Add(new object[] { node.CarNum, node.SimNum });
                    }
                }
                else
                {
                    this.getTreeNodeIsChecked(node, ref dt);
                }
            }
        }

        private void initDataTable()
        {
            if (this.dtText.Columns.Count <= 0)
            {
                this.dtText.Columns.Add("CarName", typeof(string));
                this.dtText.Columns.Add("CarTel", typeof(string));
                this.dtText.PrimaryKey = new DataColumn[] { this.dtText.Columns["CarTel"] };
            }
        }

 protected override void OnFormClosing(FormClosingEventArgs e)
        {
            for (int i = 0; i < this.flpnl.Controls.Count; i++)
            {
                if (this.flpnl.Controls[i].Controls[0].BackgroundImage != null)
                {
                    this.flpnl.Controls[i].Controls[0].BackgroundImage.Dispose();
                    this.flpnl.Controls[i].Controls[0].BackgroundImage = null;
                }
            }
            base.OnFormClosing(e);
        }

        private void playMedia(DataType typ)
        {
            if (this.dgvMedia.CurrentRow != null)
            {
                string sGpsTime = this.dgvMedia.CurrentRow.Cells["GpsTime"].Value.ToString();
                string sCarPhone = this.dgvMedia.CurrentRow.Cells["phonecar"].Value.ToString();
                string sCameraId = this.dgvMedia.CurrentRow.Cells["cameraID"].Value.ToString();
                base.Enabled = false;
                this._isPlayerAudio = typ == DataType.Audio;
                this.downLoadMediaFile(sCarPhone, sGpsTime, sCameraId);
            }
        }

        private void showNoDataInfo(bool isShow, int type)
        {
            if (isShow)
            {
                if (type == 0)
                {
                    this.lblNoPicInfo.Text = "该时间段内没有图像信息！";
                }
                else if (type == 1)
                {
                    this.lblNoPicInfo.Text = "该时间段内没有音频信息！";
                }
                else if (type == 2)
                {
                    this.lblNoPicInfo.Text = "该时间段内没有视频信息！";
                }
                this.lblNoPicInfo.BringToFront();
            }
            else
            {
                this.lblNoPicInfo.SendToBack();
            }
        }

        private void showPic(string carnum, string carphone)
        {
            if (this.showPicWorker == null)
            {
                this.showPicWorker = new BackgroundWorker();
                this.showPicWorker.WorkerSupportsCancellation = true;
                this.showPicWorker.WorkerReportsProgress = true;
                this.showPicWorker.DoWork += new DoWorkEventHandler(this.showPicWorker_DoWork);
                this.showPicWorker.ProgressChanged += new ProgressChangedEventHandler(this.showPicWorker_ProgressChanged);
                this.showPicWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.showPicWorker_RunWorkerCompleted);
            }
            if (this.pageCount > 1)
            {
                this.btnUpPage.Visible = this.btnNextPage.Visible = true;
                if (this.currentPage > 0)
                {
                    this.btnUpPage.Enabled = true;
                }
                else
                {
                    this.btnUpPage.Enabled = false;
                }
                if (this.currentPage == (this.pageCount - 1))
                {
                    this.btnNextPage.Enabled = false;
                }
                else
                {
                    this.btnNextPage.Enabled = true;
                }
            }
            if (!this.showPicWorker.IsBusy)
            {
                this.showPicWorker.RunWorkerAsync(new string[] { carnum, carphone });
            }
            else
            {
                base.Enabled = true;
            }
        }

        private void showPic(string carnum, string carphone, int pageindex)
        {
            for (int i = 0; i < this.flpnl.Controls.Count; i++)
            {
                if (this.flpnl.Controls[i].Controls[0].BackgroundImage != null)
                {
                    this.flpnl.Controls[i].Controls[0].BackgroundImage.Dispose();
                    this.flpnl.Controls[i].Controls[0].BackgroundImage = null;
                }
                this.flpnl.Controls[i].Visible = false;
            }
            if ((this.data != null) && (this.data.Rows.Count > 0))
            {
                this.showNoDataInfo(false, 0);
                this.currentPage = pageindex;
                base.Enabled = false;
                this.btnNextPage.Visible = this.btnUpPage.Visible = false;
                this.pageCount = (int) Math.Ceiling((double) (((double) this.data.Rows.Count) / ((double) this.pageNum)));
                if (this.pageCount == 1)
                {
                    this.lblPageInfo.Text = "";
                }
                else
                {
                    string[] strArray = new string[] { "图片共", this.pageCount.ToString(), "页  当前第", (this.currentPage + 1).ToString(), "页" };
                    this.lblPageInfo.Text = string.Concat(strArray);
                }
                try
                {
                    this.showPic(carnum, carphone);
                }
                catch
                {
                }
                finally
                {
                    if (!this.showPicWorker.IsBusy)
                    {
                        base.Enabled = true;
                    }
                }
            }
            else
            {
                this.showNoDataInfo(true, 0);
            }
        }

        private void showPicWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string sCarNum = (e.Argument as string[])[0];
                string sCarPhone = (e.Argument as string[])[1];
                int num = this.currentPage * this.pageNum;
                int percentProgress = 0;
                int num3 = (this.currentPage + 1) * this.pageNum;
                for (int i = num; (i < this.data.Rows.Count) && (i < num3); i++)
                {
                    string path = this.downLoadPic(sCarPhone, sCarNum, this.data.Rows[i]["gpstime"].ToString(), this.data.Rows[i]["recetime"].ToString(), this.data.Rows[i]["cameraid"].ToString());
                    if (!File.Exists(path))
                    {
                        num3++;
                    }
                    else
                    {
                        int num5 = 1;
                        try
                        {
                            num5 = this.cameralId(this.data.Rows[i]["cameraid"].ToString());
                        }
                        catch
                        {
                        }
                        string[] userState = new string[] { path, num5.ToString(), this.data.Rows[i]["gpstime"].ToString() };
                        this.showPicWorker.ReportProgress(percentProgress, userState);
                        percentProgress++;
                    }
                }
            }
            catch
            {
            }
        }

        private void showPicWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                string[] userState = e.UserState as string[];
                string path = userState[0];
                if (File.Exists(path))
                {
                    this.flpnl.Controls[e.ProgressPercentage].Visible = true;
                    this.flpnl.Controls[e.ProgressPercentage].Text = "摄像头" + userState[1] + "  " + userState[2];
                    this.flpnl.Controls[e.ProgressPercentage].Controls[0].BackgroundImage = Image.FromFile(path);
                }
                else
                {
                    this.flpnl.Controls[e.ProgressPercentage].Visible = true;
                    this.flpnl.Controls[e.ProgressPercentage].Text = "摄像头" + userState[1] + "  " + userState[2];
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("多路图像(显示图片时)-->", exception.Message);
            }
        }

        private void showPicWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            base.Enabled = true;
        }

        private void txtSearchCar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.btnSearchCar_Click(null, null);
        }

        private void worder_DoWork(object sender, DoWorkEventArgs e)
        {
            this.BindCarTextList();
        }

        private void worder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.cmbCar.DataSource = this.source;
                this.worker.DoWork -= new DoWorkEventHandler(this.worder_DoWork);
                this.worker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.worder_RunWorkerCompleted);
                this.worker = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("文本位置->异步处理完成事件", exception.Message);
            }
            finally
            {
                WaitForm.Hide();
                if (this.cmbCar.Items.Count > 0)
                {
                    this.btnQuery_Click(null, null);
                }
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                try
                {
                    e.UserState.ToString().Split(new char[] { '|' })[1].Split(new char[] { ',' });
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("文本位置->异步加载完成", exception.Message);
                }
            }
        }
    }
}

