using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PublicClass;
using System.Timers;
using System.Drawing.Printing;
using WinFormsUI.Controls;
using Remoting;
using System.IO;

namespace Client
{
    /// <summary>
    /// 轨迹回放界面
    /// </summary>
    public partial class itmCarPlayTrack : Client.SizableForm
    {
        private int AlarmCount;
        private BackgroundWorker excelWorker;
        private int iMapCnt;
        private bool m_bPlay;
        private bool m_bShowTrack = true;
        private bool m_bTimeChanged;
        private DataRow m_dr;
        private DataSet m_dsReplayData;
        private DataTable m_dtPlayData = new DataTable();
        private DataTable m_dtPlayDataCopy = new DataTable();
        private DataView m_dvPlayData;
        private int m_iPagCount = 1000;
        private int m_iPlayCurrent;
        private int m_iPlayLastTime;
        private int m_iSelectedMapIndex;
        private string m_sQueryCurrentGpsTime;
        private int m_sQueryTimeDiff = 120;
        private Bitmap memoryImage;
        private dGetTrackQueryInfo myGetTrackQueryInfo;
        private dPlay myPlay;
        private dPlayCnt myPlayCnt;
        private dEnable mySetEnable;
        private dShowMessage myShowMessage;
        private string sCarNum = "";
        private string sCarText = "";
        private string sDownLoadErrMsg = "下载播放信息失败！";
        private string sLastAddress = "";
        private double sLastLat = -1.0;
        private double sLastLon = -1.0;
        private string sLastTime = "";
        private string sMileageCnt = "";
        private string sPlayCnt = "";
        private string sQueryTypeValue = "carplaytrack";
        private string[] sSplit = new string[] { "::" };
        private System.Timers.Timer tGetQueryTrackInfo;
        private Thread tGetReplayData;
        private System.Timers.Timer tPlay = new System.Timers.Timer();
        private string stopIconType = "111";

        //停留时间显示 根据站点
        private GpsStationDAL dal = new GpsStationDAL();
        private DataTable dt, dat;
        private DateTime startTime, endTime;
        //private int iStationID = -1;
        private int iStopIndex = 1;

        //停留时间显示 根据停车
        private string strStopLng, strStopLat;
        private DateTime startTimeAcc, endTimeAcc;

        public itmCarPlayTrack()
        {
            InitializeComponent();
            setCarList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdLocal.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (tGetReplayData.ThreadState != ThreadState.Stopped)
                        {
                            tGetReplayData.Abort();
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        Thread.Sleep(500);
                        Thread.ResetAbort();
                    }
                    catch (Exception)
                    {
                    }
                    WaitForm.Show("正在读取数据，请稍候...", this);
                    Record.execFileRecord("读取本地轨迹回放文件", ofdLocal.FileName);
                    m_dsReplayData = new DataSet();
                    m_bTimeChanged = false;
                    string fileName = ofdLocal.FileName;
                    m_dsReplayData.ReadXml(fileName);
                    WaitForm.Hide2();
                    if (setPlayInfo())
                    {
                        Record.execFileRecord("轨迹回放总记录数", tbPlay.Maximum.ToString());
                        FileInfo info = new FileInfo(fileName);
                        lblFileValue.Text = info.Name;
                        sCarNum = m_dsReplayData.Tables[0].Rows[0]["CarNum"].ToString();
                        sPlayCnt = m_dsReplayData.Tables[0].Rows[0]["countData"].ToString();
                        sMileageCnt = m_dsReplayData.Tables[0].Rows[0]["DifDis"].ToString();
                        wbMap.delAllCar();
                        tPlay.Enabled = true;
                        m_bPlay = true;
                        onSetBtnEnable("Local");
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("读取文件失败", exception.Message);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            m_bPlay = false;
            onSetBtnEnable("Pause");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            m_bShowTrack = chkUnShowTrack.Checked;
            if (!chkPlay())
            {
                setQueryInit();
                try
                {
                    if (tGetReplayData.ThreadState != ThreadState.Stopped)
                    {
                        tGetReplayData.Abort();
                    }
                }
                catch (ThreadAbortException)
                {
                    Thread.Sleep(500);
                    Thread.ResetAbort();
                }
                catch (Exception)
                {
                }
                wbMap.delAllCar();
                wbMap.clearAllCompany();
                if (m_dsReplayData != null)
                {
                    m_dsReplayData.Clear();
                    m_dsReplayData = null;
                }
                string s = dtpStartDate.Value.ToString("yyyy-MM-dd") + " " + dtpStartTime.Value.ToString("HH:mm:ss");
                string str2 = dtpEndDate.Value.ToString("yyyy-MM-dd") + " " + dtpEndTime.Value.ToString("HH:mm:ss");
                if (DateTime.Parse(s) > DateTime.Parse(str2))
                {
                    MessageBox.Show("开始时间大于结束时间");
                }
                else
                {
                    string sErrMsg = string.Format("{0}～{1}", s, str2);
                    Record.execFileRecord("下载轨迹回放基本信息", sErrMsg);
                    WaitForm.Show("正在下载数据，请稍候...", this);
                    onSetBtnEnable("NewPlay");
                    string[] parameter = new string[] { s, str2, cmbCarNum.SelectedValue.ToString() };
                    new Thread(new ParameterizedThreadStart(getPlayCnt)).Start(parameter);
                }
            }
            else
            {
                if (tbPlay.Value == tbPlay.Maximum)
                {
                    tbPlay.Value = 0;
                    wbMap.delAllCar();
                    m_dtPlayData.Clear();
                    m_iPlayCurrent = tbPlay.Value;
                    setQueryInit();
                }
                tPlay.Enabled = true;
                m_bPlay = true;
                onSetBtnEnable("Play");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_dsReplayData == null)
            {
                MessageBox.Show("保存数据为空，请重新下载");
            }
            else
            {
                sfdLocal.FileName = cmbCarNum.Text + "-" + dtpStartDate.Value.ToString("yyMMdd") + dtpStartTime.Value.ToString("HHmmss") + "-" + dtpEndDate.Value.ToString("yyMMdd") + dtpEndTime.Value.ToString("HHmmss") + ".cds";
                if (sfdLocal.ShowDialog() == DialogResult.OK)
                {
                    WaitForm.Show("正在保存数据，请稍候...", this);
                    m_dsReplayData.WriteXml(sfdLocal.FileName, XmlWriteMode.WriteSchema);
                    Record.execFileRecord("保存轨迹回放文件", ofdLocal.FileName);
                    WaitForm.Hide();
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m_bPlay = false;
            try
            {
                if (tGetReplayData.ThreadState != ThreadState.Stopped)
                {
                    tGetReplayData.Abort();
                }
            }
            catch (ThreadAbortException)
            {
                Thread.Sleep(500);
                Thread.ResetAbort();
            }
            catch (Exception)
            {
            }
            if ((sender == null) && base.IsHandleCreated)
            {
                base.Invoke(mySetEnable, new object[] { "Stop1" });
            }
            else
            {
                WaitForm.Hide();
                onSetBtnEnable("Stop");
                m_dsReplayData = null;
                tbPlay.Value = 0;
                m_iPlayCurrent = tbPlay.Value;
                m_bTimeChanged = false;
            }
            setQueryInit();
        }

        private void CaptureScreen()
        {
            Graphics g = base.CreateGraphics();
            Size blockRegionSize = wbMap.Size;
            memoryImage = new Bitmap(blockRegionSize.Width, blockRegionSize.Height, g);
            Graphics.FromImage(memoryImage).CopyFromScreen(wbMap.Left, wbMap.Top, 0, 0, blockRegionSize);
        }

        private bool chkPlay()
        {
            try
            {
                if ((m_bTimeChanged || (m_dsReplayData == null)) || ((m_dsReplayData.Tables.Count < 1) || "0".Equals(m_dsReplayData.Tables[0].Rows[0]["countData"].ToString())))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void clearData()
        {
            try
            {
                if (m_dtPlayData != null)
                {
                    m_dtPlayData.Clear();
                }
                if (m_dsReplayData != null)
                {
                    m_dsReplayData.Tables[1].Clear();
                    m_dsReplayData.Clear();
                }
                if (m_dtPlayDataCopy != null)
                {
                    m_dtPlayDataCopy.Clear();
                    m_dr = null;
                }
            }
            catch
            {
            }
            lblGpsTimeValue.Text = string.Empty;
            lblLongitudeValue.Text = string.Empty;
            lblLatitudeValue.Text = string.Empty;
            lblSpeedValue.Text = string.Empty;
            lblStateValue.Text = string.Empty;
            lblRecordValue.Text = string.Empty;
            lblMileageValue.Text = string.Empty;
            lblIsBlackBoxValue.Text = string.Empty;
            pbPicture.Image = null;
        }

        private void cmbCarNum_SelectedValueChanged(object sender, EventArgs e)
        {
            m_dsReplayData = null;
            m_bTimeChanged = false;
        }

        private void cmbSelectMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_iSelectedMapIndex != cmbSelectMap.SelectedIndex)
            {
                string itemText = cmbSelectMap.ComboBox.GetItemText(cmbSelectMap.SelectedItem);
                string sValue = cmbSelectMap.ComboBox.SelectedValue.ToString();
                execMapChangeBaseLayer(itemText, sValue);
                m_iSelectedMapIndex = cmbSelectMap.SelectedIndex;
            }
        }

        private void dgvCarPlay_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if ((rowIndex >= 0) && !m_bPlay)
            {
                execGotoPlay(int.Parse(dgvCarPlay.Rows[rowIndex].Cells["messId"].Value.ToString()) + 1);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            m_bTimeChanged = true;
        }

        private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string str = dtpStartDate.Value.ToShortDateString() + " " + dtpStartTime.Value.ToLongTimeString();
            string str2 = dtpEndDate.Value.ToShortDateString() + " " + dtpEndTime.Value.ToLongTimeString();
            ReportExcel.OutputExcel(dgvCarPlay, sCarText + " " + str + "~" + str2 + " 轨迹回放报表 ", e.Argument.ToString(), sCarText + "轨迹回放报表", true);
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WaitForm.Hide();
        }

        private void execGotoPlay(int iCurrent)
        {
            if (((m_dsReplayData == null) || (m_dsReplayData.Tables.Count < 2)) || (m_dsReplayData.Tables[1].Rows.Count <= 0))
            {
                tbPlay.Value = 0;
                m_iPlayCurrent = tbPlay.Value;
            }
            else if ((iCurrent >= 0) && (iCurrent <= tbPlay.Maximum))
            {
                if (tbPlay.Value != iCurrent)
                {
                    tbPlay.Value = iCurrent;
                }
                if ((m_dsReplayData.Tables[1].Rows.Count < tbPlay.Value) && (m_dsReplayData.Tables[1].Rows.Count >= m_iPagCount))
                {
                    tbPlay.Value = m_dsReplayData.Tables[1].Rows.Count - m_iPagCount;
                }
                else if (m_iPlayCurrent != tbPlay.Value)
                {
                    if (m_iPlayCurrent > tbPlay.Value)
                    {
                        btnPause.PerformClick();
                        m_dsReplayData.Tables[0].Rows[0]["CarNum"].ToString();
                        string sCarId = m_dsReplayData.Tables[1].Rows[0]["CarId"].ToString();
                        m_iPlayCurrent = tbPlay.Value;
                        if (m_iPlayCurrent < 1)
                        {
                            wbMap.execDeleteCar(sCarId);
                            wbMap.clearAllCompany();
                            setQueryInit();
                            if ((m_dtPlayData != null) && (m_dtPlayData.Rows.Count > 0))
                            {
                                m_dtPlayData.Rows.Clear();
                            }
                            if ((m_dtPlayData != null) && (m_dtPlayDataCopy.Rows.Count > 0))
                            {
                                m_dtPlayData.Rows.Clear();
                            }
                            if (m_iPlayCurrent == 0)
                            {
                                setPlayInfo();
                                return;
                            }
                        }
                        else if (dgvCarPlay.Visible)
                        {
                            setGridData();
                        }
                        wbMap.clearTrackTo(sCarId, m_iPlayCurrent - 1);
                        ShowCar(m_iPlayCurrent - 1);
                    }
                    else
                    {
                        btnPause.PerformClick();
                        try
                        {
                            WaitForm.Show("正在生成车辆轨迹，请稍候...", this);
                            while (m_iPlayCurrent < tbPlay.Value)
                            {
                                ShowCar(m_iPlayCurrent);
                                m_iPlayCurrent++;
                            }
                            if (dgvCarPlay.Visible)
                            {
                                setGridData();
                            }
                            WaitForm.Hide2();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void execMapChangeBaseLayer(string sText, string sValue)
        {
            wbMap.execMapChangeBaseLayer(sText, sValue);
        }

        private void execShowMess(string sMess)
        {
            MessageBox.Show(sMess);
        }

        private void exePlayCnt(DataTable dt)
        {
            try
            {
                string str = dtpStartDate.Value.ToString("yyyy-MM-dd") + " " + dtpStartTime.Value.ToString("HH:mm:ss");
                string str2 = dtpEndDate.Value.ToString("yyyy-MM-dd") + " " + dtpEndTime.Value.ToString("HH:mm:ss");
                string sErrMsg = string.Format("{0}～{1}", str, str2);
                if ((dt == null) || (dt.Rows.Count == 0))
                {
                    WaitForm.Hide();
                    MessageBox.Show(sDownLoadErrMsg);
                    Record.execFileRecord("下载轨迹回放数据失败", sErrMsg);
                    onSetBtnEnable("Stop1");
                }
                else
                {
                    dt.Columns.Add(new DataColumn("CarNum"));
                    dt.Columns.Add(new DataColumn("SimNum"));
                    dt.Columns.Add(new DataColumn("DifDis"));
                    if (!setPlayInfo(dt))
                    {
                        WaitForm.Hide();
                        MessageBox.Show(sDownLoadErrMsg);
                        Record.execFileRecord("解析轨迹基本信息失败", sErrMsg);
                        onSetBtnEnable("Stop1");
                    }
                    else
                    {
                        m_dsReplayData = new DataSet();
                        m_bTimeChanged = false;
                        dt.TableName = "ReplayDataInfo";
                        m_dsReplayData.Tables.Add(dt);
                        if (!setPlayInfo())
                        {
                            WaitForm.Hide();
                            MessageBox.Show("无记录显示！");
                            Record.execFileRecord("无记录显示", sErrMsg);
                            onSetBtnEnable("Stop1");
                        }
                        else
                        {
                            Record.execFileRecord(string.Format("{0},轨迹回放总记录数：{1}", cmbCarNum.Text, tbPlay.Maximum.ToString()));
                            lblFileValue.Text = "远程下载";
                            sCarNum = m_dsReplayData.Tables[0].Rows[0]["CarNum"].ToString();
                            sPlayCnt = m_dsReplayData.Tables[0].Rows[0]["countData"].ToString();
                            sMileageCnt = m_dsReplayData.Tables[0].Rows[0]["DifDis"].ToString();
                            tGetReplayData = new Thread(new ThreadStart(onGetReplayData));
                            tGetReplayData.Start();
                        }
                    }
                }
            }
            catch
            {
                onSetBtnEnable("Stop1");
            }
        }

        /// <summary>
        /// 设置位置信息
        /// </summary>
        private void getAddress()
        {
            object trackPointQueryInfo = wbMap.getTrackPointQueryInfo(sQueryTypeValue);
            if (trackPointQueryInfo == null || string.IsNullOrEmpty(trackPointQueryInfo.ToString()))
            {
                return;
            }
            double num = -1;
            double num1 = -1;
            string[] strArrays = trackPointQueryInfo.ToString().Split(sSplit, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                string[] strArrays1 = str.Split(new char[] { '|' });
                string str1 = strArrays1[0];
                string str2 = strArrays1[1];
                num = -1;
                num1 = -1;
                try
                {
                    int num2 = int.Parse(str1);
                    int count = dgvCarPlay.Rows.Count;
                    sLastTime = num2.ToString();
                    sLastAddress = str2;
                    while (num2 < count)
                    {
                        double num3 = double.Parse(dgvCarPlay.Rows[count - 1 - num2].Cells["Longitude"].Value.ToString());
                        double num4 = double.Parse(dgvCarPlay.Rows[count - 1 - num2].Cells["Latitude"].Value.ToString());
                        if (num == -1)
                        {
                            num = num4;
                            num1 = num3;
                        }
                        if (Math.Abs(num3 - num1) > Variable.dLonLatDis || Math.Abs(num4 - num) > Variable.dLonLatDis)
                        {
                            break;
                        }
                        if (string.IsNullOrEmpty(dgvCarPlay.Rows[count - 1 - num2].Cells["CarAddress"].Value.ToString()))
                        {
                            dgvCarPlay.Rows[count - 1 - num2].Cells["CarAddress"].Value = str2;
                        }
                        num2++;
                    }
                }
                catch
                {
                    Record.execFileRecord("轨迹回放->设置详细地址", iMapCnt.ToString());
                }
            }
        }

        private void getPlayCnt(object obj)
        {
            DataTable table = new DataTable();
            try
            {
                string[] strArray = obj as string[];
                string beginTime = strArray[0];
                string endTime = strArray[1];
                string tele = strArray[2];
                table = RemotingClient.TrackReplay_GetReplayDataCount(beginTime, endTime, tele);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("getPlayCnt", exception.Message);
            }
            if (base.IsHandleCreated)
            {
                base.Invoke(myPlayCnt, new object[] { table });
            }
        }

        public double getPlaySpeed()
        {
            return Math.Pow(2.0, (double)tbPlaySpeed.Value);
        }

        public string GetTransportStatus(int pTransportStatu)
        {
            switch (pTransportStatu)
            {
                case 0:
                    return "空车";

                case 1:
                    return "停运";

                case 2:
                    return "预约";

                case 3:
                    return "重车";

                case 4:
                    return "运营";
            }
            return "营运";
        }

        private void initDataTable()
        {
            m_dtPlayData.Columns.Add(new DataColumn("gpsTime"));
            m_dtPlayData.Columns.Add(new DataColumn("receTime"));
            m_dtPlayData.Columns.Add(new DataColumn("Longitude"));
            m_dtPlayData.Columns.Add(new DataColumn("Latitude"));
            m_dtPlayData.Columns.Add(new DataColumn("Speed"));
            m_dtPlayData.Columns.Add(new DataColumn("CarStatus"));
            m_dtPlayData.Columns.Add(new DataColumn("CarAddress"));
            m_dtPlayData.Columns.Add(new DataColumn("messId", typeof(int)));
            m_dvPlayData = new DataView(m_dtPlayData, "", "messId desc", DataViewRowState.CurrentRows);
            dgvCarPlay.DataSource = m_dvPlayData;
        }

        private void InsertPlayData(int iCurrent)
        {
            try
            {
                if (((m_dsReplayData == null) || (m_dsReplayData.Tables.Count < 2)) || (m_dsReplayData.Tables[1].Rows.Count <= iCurrent))
                {
                    btnPause.PerformClick();
                }
                else
                {
                    string sgpsTime = m_dsReplayData.Tables[1].Rows[iCurrent]["gpsTime"].ToString();
                    string sLongitude = m_dsReplayData.Tables[1].Rows[iCurrent]["Longitude"].ToString();
                    string sLatitude = m_dsReplayData.Tables[1].Rows[iCurrent]["Latitude"].ToString();
                    string str4 = m_dsReplayData.Tables[1].Rows[iCurrent]["Speed"].ToString();
                    string str5 = m_dsReplayData.Tables[1].Rows[iCurrent]["StatuList"].ToString();
                    string str6 = m_dsReplayData.Tables[1].Rows[iCurrent]["receTime"].ToString();
                    if (m_dr == null)
                    {
                        m_dr = m_dtPlayDataCopy.NewRow();
                        m_dr["gpsTime"] = sgpsTime;
                        m_dr["receTime"] = str6;
                        m_dr["Longitude"] = sLongitude;
                        m_dr["Latitude"] = sLatitude;
                        m_dr["Speed"] = string.Format("{0}km/h", str4);
                        m_dr["CarStatus"] = str5;
                        m_dr["messId"] = iCurrent;
                        m_dtPlayDataCopy.Rows.Add(m_dr);
                    }
                    else
                    {
                        m_dr["gpsTime"] = sgpsTime;
                        m_dr["receTime"] = str6;
                        m_dr["Longitude"] = sLongitude;
                        m_dr["Latitude"] = sLatitude;
                        m_dr["Speed"] = string.Format("{0}km/h", str4);
                        m_dr["CarStatus"] = str5;
                        m_dr["messId"] = iCurrent;
                    }
                    if (dgvCarPlay.Rows.Count <= iCurrent)
                    {
                        m_dtPlayData.Rows.Add(m_dr.ItemArray);
                        if (((m_sQueryCurrentGpsTime == null) || (Math.Abs((double)(double.Parse(sLongitude) - sLastLon)) > Variable.dLonLatDis)) || (Math.Abs((double)(double.Parse(sLatitude) - sLastLat)) > Variable.dLonLatDis))
                        {
                            m_sQueryCurrentGpsTime = sgpsTime;
                            wbMap.execExcuteTrackPointQuerty(sQueryTypeValue, iCurrent.ToString(), sLongitude, sLatitude);
                            sLastLon = double.Parse(sLongitude);
                            sLastLat = double.Parse(sLatitude);
                        }
                        if (!string.IsNullOrEmpty(sLastAddress))
                        {
                            int num = int.Parse(sLastTime);
                            DataRow row = m_dtPlayData.Rows[num];
                            double num2 = double.Parse(row["Latitude"].ToString());
                            double num3 = double.Parse(row["Longitude"].ToString());
                            if ((Math.Abs((double)(double.Parse(sLongitude) - num3)) <= Variable.dLonLatDis) && (Math.Abs((double)(double.Parse(sLatitude) - num2)) <= Variable.dLonLatDis))
                            {
                                m_dtPlayData.Rows[iCurrent]["CarAddress"] = sLastAddress;
                            }
                        }
                    }
                    if ((iCurrent + 1) == tbPlay.Maximum)
                    {
                        wbMap.execExcuteTrackPointQuerty(sQueryTypeValue, iCurrent.ToString(), sLongitude, sLatitude);
                    }
                }
            }
            catch
            {
            }
        }

        private void itmCarPlayTrack_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                if (m_bPlay)
                {
                    MessageBox.Show("请先结束播放！");
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        if (IsFlagChanged)
                        {
                            MainForm.myMap.execClearAllFlag();
                            MainForm.myMap.showFlagMap(MainForm.myMap.wbMap);
                        }
                        WaitForm.Hide2();
                        wbMap.Stop();
                        wbMap = null;
                        m_bPlay = false;
                        tPlay.Stop();
                        tPlay.Dispose();
                        if (m_dsReplayData != null)
                        {
                            m_dsReplayData.Clear();
                            m_dsReplayData = null;
                        }
                        if (m_dtPlayData != null)
                        {
                            m_dtPlayData.Clear();
                            m_dtPlayData = null;
                        }
                        if (m_dtPlayDataCopy != null)
                        {
                            m_dtPlayDataCopy.Clear();
                            m_dtPlayDataCopy = null;
                        }
                        if (m_dvPlayData != null)
                        {
                            m_dvPlayData.Dispose();
                            m_dvPlayData = null;
                        }
                        if (myPlay != null)
                        {
                            myPlay = null;
                        }
                        if (mySetEnable != null)
                        {
                            mySetEnable = null;
                        }
                        if (tGetReplayData.ThreadState != ThreadState.Stopped)
                        {
                            tGetReplayData.Abort();
                        }
                        if (wbMap != null)
                        {
                            wbMap.execStopPlayTrackLine(sQueryTypeValue);
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        Thread.Sleep(500);
                        Thread.ResetAbort();
                    }
                    catch (Exception exception)
                    {
                        Record.execFileRecord("轨迹回放窗口关闭", exception.Message);
                    }
                    finally
                    {
                        GC.SuppressFinalize(this);
                    }
                }
            }
        }

        private void itmCarPlayTrack_Load(object sender, EventArgs e)
        {
            try
            {
                m_sQueryTimeDiff = int.Parse(Variable.sQueryPointTimeDiff);
            }
            catch
            {
                m_sQueryTimeDiff = 120;
            }
            Point point = new Point((wbMap.Width / 2) - 85, (wbMap.Height / 2) - 17);
            picLoadMap.Location = point;
            pnlHandle.Enabled = false;
            pnlTool.Enabled = false;
            picLoadMap.Visible = true;
            wbMap.Url = new Uri(Variable.MapUrl);
            tPlay.Interval = getPlaySpeed();
            tPlay.Elapsed += new ElapsedEventHandler(onPlayMain);
            wbMap.execStopPlayTrackLine(sQueryTypeValue);
            tGetQueryTrackInfo = new System.Timers.Timer(2000.0);
            tGetQueryTrackInfo.Elapsed += new ElapsedEventHandler(tGetQueryTrackInfo_Elapsed);
            myGetTrackQueryInfo = new dGetTrackQueryInfo(getAddress);
            myPlay = new dPlay(onPlay);
            mySetEnable = new dEnable(onSetBtnEnable);
            myShowMessage = new dShowMessage(execShowMess);
            myPlayCnt = new dPlayCnt(exePlayCnt);
            initDataTable();
            m_dtPlayDataCopy = m_dtPlayData.Clone();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;

            //2015.5.23
            dt = dal.GetList("", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                string[] str = new string[3];
                dat = new DataTable("GpsStation");
                dat.Columns.Add("ID", System.Type.GetType("System.String"));
                dat.Columns.Add("lng", System.Type.GetType("System.String"));
                dat.Columns.Add("lat", System.Type.GetType("System.String"));
                dat.Columns.Add("dis", System.Type.GetType("System.String"));
                int index = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    str = dr["RegionDot"].ToString().Split(new char[] { '\\' });
                    DataRow dRow = dat.NewRow();
                    dRow["ID"] = index;
                    dRow["lng"] = str[0];
                    dRow["lat"] = str[1];
                    dRow["dis"] = str[2].TrimEnd(new char[] { '*' });
                    dat.Rows.Add(dRow);
                    index++;
                }
            }
        }

        public void onGetReplayData()
        {
            try
            {
                DateTime time = DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd") + " " + dtpStartTime.Value.ToString("HH:mm:ss"));
                DateTime time2 = DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd") + " " + dtpEndTime.Value.ToString("HH:mm:ss"));
                string tele = m_dsReplayData.Tables[0].Rows[0]["SimNum"].ToString();
                int maximum = tbPlay.Maximum;
                int pageNum = 0;
                DataTable table = null;
            Label_00C2:
                pageNum++;
                table = RemotingClient.TrackReplay_GetReplayData(time.ToString(), time2.ToString(), tele, maximum, pageNum, m_iPagCount, 1, 0);
                if (table == null)
                {
                    btnStop_Click(null, null);
                    base.Invoke(myShowMessage, new object[] { sDownLoadErrMsg });
                    Record.execFileRecord(sDownLoadErrMsg);
                }
                else if ((m_dsReplayData != null) && (m_dsReplayData.Tables.Count != 0))
                {
                    if ((pageNum * m_iPagCount) < maximum)
                    {
                        Record.execFileRecord("已下载轨迹回放数据", string.Format("第 {0}～{1} 条记录", ((pageNum - 1) * m_iPagCount) + 1, pageNum * m_iPagCount));
                    }
                    else
                    {
                        Record.execFileRecord("已下载轨迹回放数据", string.Format("第 {0}～{1} 条记录", ((pageNum - 1) * m_iPagCount) + 1, maximum));
                    }
                    if (m_dsReplayData.Tables.Count < 2)
                    {
                        table.TableName = "ReplayData";
                        m_dsReplayData.Tables.Add(table);
                        tPlay.Enabled = true;
                        m_bPlay = true;
                        base.Invoke(mySetEnable, new object[] { "Play" });
                    }
                    else
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            lock (m_dsReplayData.Tables[1])
                            {
                                m_dsReplayData.Tables[1].Rows.Add(row.ItemArray);
                            }
                        }
                    }
                    base.Invoke(mySetEnable, new object[] { "TrackDataDown" });
                    if ((pageNum * m_iPagCount) < maximum)
                    {
                        goto Label_00C2;
                    }

                    table = null;
                    Record.execFileRecord("轨迹回放数据下载", "完成下载");
                    base.Invoke(mySetEnable, new object[] { "Loaded" });
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("轨迹回放数据下载ex", exception.Message);
                btnStop_Click(null, null);
                if (btnStop.Enabled)
                {
                    base.Invoke(myShowMessage, new object[] { sDownLoadErrMsg });
                }
            }
        }

        private void onPlay()
        {
            if (tbPlay.Value == tbPlay.Maximum)
            {
                tPlay.Enabled = false;
                m_bPlay = false;
                base.Invoke(mySetEnable, new object[] { "End" });
            }
            else
            {
                int iCurrent = tbPlay.Value;
                if (((m_dsReplayData == null) || (m_dsReplayData.Tables.Count < 2)) || (m_dsReplayData.Tables[1].Rows.Count <= iCurrent))
                {
                    btnPause.PerformClick();
                }
                else
                {
                    m_iPlayCurrent = iCurrent + 1;
                    tbPlay.Value = iCurrent + 1;
                    ShowCar(iCurrent);
                    if (dgvCarPlay.Visible)
                    {
                        InsertPlayData(iCurrent);
                        if (dgvCarPlay.Rows.Count > 0)
                        {
                            dgvCarPlay.CurrentCell = dgvCarPlay.Rows[0].Cells[0];
                        }
                        pbCarPlay.Value = m_iPlayCurrent;
                    }
                    tPlay.Enabled = true;
                }
            }
        }

        private void onPlayMain(object sender, ElapsedEventArgs e)
        {
            if ((tPlay != null) && tbPlay.Enabled)
            {
                tPlay.Enabled = false;
            }
            if (m_bPlay)
            {
                base.Invoke(myPlay);
            }
        }

        private void onSetBtnEnable(string sType)
        {
            switch (sType)
            {
                case "Local":
                    btnPause.Enabled = true;
                    tbPlay.Enabled = true;
                    btnStop.Enabled = true;
                    btnExit.Enabled = false;
                    btnPlay.Enabled = false;
                    cmbCarNum.Enabled = false;
                    return;

                case "Play":
                    btnPause.Enabled = true;
                    tbPlay.Enabled = true;
                    btnLocal.Enabled = false;
                    btnExit.Enabled = false;
                    btnPlay.Enabled = false;
                    btnStop.Enabled = true;
                    cmbCarNum.Enabled = false;
                    WaitForm.Hide2();
                    return;

                case "NewPlay":
                    btnSave.Enabled = false;
                    btnPause.Enabled = false;
                    tbPlay.Enabled = false;
                    btnLocal.Enabled = false;
                    btnExit.Enabled = false;
                    btnPlay.Enabled = false;
                    btnStop.Enabled = false;
                    cmbCarNum.Enabled = false;
                    return;

                case "Pause":
                    btnPlay.Enabled = true;
                    btnStop.Enabled = true;
                    btnExit.Enabled = false;
                    btnPause.Enabled = false;
                    return;

                case "Stop":
                    btnLocal.Enabled = true;
                    btnPlay.Enabled = true;
                    cmbCarNum.Enabled = true;
                    btnExit.Enabled = true;
                    btnPause.Enabled = false;
                    tbPlay.Enabled = false;
                    btnStop.Enabled = false;
                    btnSave.Enabled = false;
                    return;

                case "Stop1":
                    btnLocal.Enabled = true;
                    btnPlay.Enabled = true;
                    cmbCarNum.Enabled = true;
                    btnExit.Enabled = true;
                    btnPause.Enabled = false;
                    tbPlay.Enabled = false;
                    btnStop.Enabled = false;
                    btnSave.Enabled = false;
                    m_dsReplayData = null;
                    tbPlay.Value = 0;
                    m_iPlayCurrent = tbPlay.Value;
                    m_bTimeChanged = false;
                    WaitForm.Hide();
                    clearData();
                    return;

                case "Loaded":
                    btnStop.Enabled = true;
                    btnSave.Enabled = true;
                    return;

                case "End":
                    btnLocal.Enabled = true;
                    btnExit.Enabled = true;
                    btnPlay.Enabled = true;
                    cmbCarNum.Enabled = true;
                    btnSave.Enabled = true;
                    btnPause.Enabled = false;
                    btnStop.Enabled = false;
                    return;

                case "TrackDataDown":
                    try
                    {
                        if (tbPlay.Maximum <= m_dsReplayData.Tables[1].Rows.Count)
                        {
                            lblFileValue.Text = "远程下载";
                        }
                        else
                        {
                            int maximum = 0;
                            if (m_dsReplayData.Tables[1].Rows.Count > tbPlay.Maximum)
                            {
                                maximum = tbPlay.Maximum;
                            }
                            else
                            {
                                maximum = m_dsReplayData.Tables[1].Rows.Count;
                            }
                            lblFileValue.Text = "远程下载  [已下载" + maximum + "]";
                        }
                    }
                    catch
                    {
                    }
                    return;
            }
        }

        private void pdMap_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public void setCarList()
        {
            DataTable allCar = MainForm.myCarList.AllCar;
            allCar.Columns["CarNum"].ColumnName = "Display";
            allCar.Columns["SimNum"].ColumnName = "Value";
            cmbCarNum.DataSource = new DataView(allCar, "", "Display", DataViewRowState.CurrentRows);
            cmbCarNum.SelectedValue = MainForm.myCarList.SelectedSimNum;
        }

        private void setGridData()
        {
            if ((m_dsReplayData == null) || (m_dsReplayData.Tables.Count < 2))
            {
                btnPause.PerformClick();
            }
            else
            {
                bool bPlay = m_bPlay;
                tPlay.Enabled = false;
                m_bPlay = bPlay;
                m_dvPlayData.RowFilter = string.Format("messId<{0}", m_dtPlayData.Rows.Count.ToString());
                if (m_dtPlayData.Rows.Count > m_iPlayCurrent)
                {
                    int num = m_iPlayCurrent - 1;
                    while (num < (m_dtPlayData.Rows.Count - 1))
                    {
                        m_dtPlayData.Rows.RemoveAt(m_dtPlayData.Rows.Count - 1);
                    }
                    pbCarPlay.Value = m_iPlayCurrent;
                }
                else
                {
                    int count = m_dtPlayData.Rows.Count;
                    WaitForm.Show("正在生成数据，请稍候...", this);
                    for (int i = count; i < m_iPlayCurrent; i++)
                    {
                        InsertPlayData(i);
                    }
                    if (dgvCarPlay.Rows.Count > 0)
                    {
                        dgvCarPlay.CurrentCell = dgvCarPlay.Rows[0].Cells[0];
                    }
                    pbCarPlay.Value = m_iPlayCurrent;
                    WaitForm.Hide2();
                }
                m_dvPlayData.RowFilter = "";
                tPlay.Enabled = bPlay;
            }
        }

        public void setMap(string sMapsStr)
        {
            if (cmbSelectMap.Items.Count <= 0)
            {
                try
                {
                    cmbSelectMap.ComboBox.Items.Clear();
                    DataTable table = new DataTable();
                    table.Columns.Add("values", typeof(string));
                    table.Columns.Add("Text", typeof(string));
                    string[] strArray = sMapsStr.Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new char[] { ';' });
                        if (strArray2.Length == 2)
                        {
                            table.Rows.Add(new object[] { strArray2[0], strArray2[1] });
                        }
                    }
                    cmbSelectMap.ComboBox.DisplayMember = "Text";
                    cmbSelectMap.ComboBox.ValueMember = "values";
                    cmbSelectMap.ComboBox.DataSource = table;
                    cmbSelectMap.ComboBox.SelectedValue = MainForm.m_sSelectedMap;
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("设置地图", exception.Message);
                }
            }
        }

        private bool setPlayInfo()
        {
            try
            {
                if (!chkPlay())
                {
                    return false;
                }
                tbPlay.Value = 0;
                m_iPlayCurrent = tbPlay.Value;
                tbPlay.Maximum = int.Parse(m_dsReplayData.Tables[0].Rows[0]["countData"].ToString());
                if (tbPlay.Maximum > 20)
                {
                    tbPlay.TickFrequency = tbPlay.Maximum / 20;
                }
                else
                {
                    tbPlay.TickFrequency = 1;
                }
                lblRecordValue.Text = string.Format("0/{0}", tbPlay.Maximum);
                lblMileageValue.Text = string.Format("0/{0}", m_dsReplayData.Tables[0].Rows[0]["DifDis"].ToString());
                if (m_dtPlayData != null)
                {
                    m_dtPlayData.Clear();
                }
                pbCarPlay.Value = 0;
                pbCarPlay.Maximum = tbPlay.Maximum;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool setPlayInfo(DataTable dt)
        {
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                try
                {
                    double num = double.Parse(dt.Rows[0]["minDis"].ToString());
                    double num2 = double.Parse(dt.Rows[0]["maxDis"].ToString());
                    dt.Rows[0]["CarNum"] = cmbCarNum.Text;
                    dt.Rows[0]["SimNum"] = cmbCarNum.SelectedValue.ToString();
                    dt.Rows[0]["DifDis"] = string.Format("{0:F2}", (num2 - num) / 1000.0);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 查询初始化
        /// </summary>
        private void setQueryInit()
        {
            if (wbMap != null)
            {
                wbMap.execStopPlayTrackLine(sQueryTypeValue);
            }
            m_sQueryCurrentGpsTime = null;
            sLastTime = "0";
            sLastAddress = "";
            sLastLon = -1.0;
            sLastLat = -1.0;
            iStopIndex = 1;
        }

        /// <summary>
        /// 在地图上绘制轨迹
        /// </summary>
        /// <param name="iCurrent"></param>
        private void ShowCar(int iCurrent)
        {
            try
            {
                if (((m_dsReplayData == null) || (m_dsReplayData.Tables.Count < 2)) || (m_dsReplayData.Tables[1].Rows.Count <= iCurrent))
                {
                    btnPause.PerformClick();
                }
                else
                {
                    string sCarId = m_dsReplayData.Tables[1].Rows[iCurrent]["CarId"].ToString();
                    string sgpsTime = m_dsReplayData.Tables[1].Rows[iCurrent]["gpsTime"].ToString();
                    string x = m_dsReplayData.Tables[1].Rows[iCurrent]["Longitude"].ToString();
                    string y = m_dsReplayData.Tables[1].Rows[iCurrent]["Latitude"].ToString();
                    string strSpeed = m_dsReplayData.Tables[1].Rows[iCurrent]["Speed"].ToString();
                    string iCarStatus = m_dsReplayData.Tables[1].Rows[iCurrent]["carStatu"].ToString();
                    string StatuList = m_dsReplayData.Tables[1].Rows[iCurrent]["StatuList"].ToString();
                    string strdistanceDiff = m_dsReplayData.Tables[1].Rows[iCurrent]["distanceDiff"].ToString();
                    //m_dsReplayData.Tables[1].Rows[iCurrent]["receTime"].ToString();
                    string strReserved = m_dsReplayData.Tables[1].Rows[iCurrent]["Reserved"].ToString();
                    string strIsPic = m_dsReplayData.Tables[1].Rows[iCurrent]["IsPic"].ToString();
                    string strDistanceCount = m_dsReplayData.Tables[1].Rows[0]["distanceDiff"].ToString();
                    string strAccOn = m_dsReplayData.Tables[1].Rows[iCurrent]["AccOn"].ToString();
                    string strtransportStatus = m_dsReplayData.Tables[1].Rows[iCurrent]["transportStatus"].ToString();
                    string iAlarmType = m_dsReplayData.Tables[1].Rows[iCurrent]["AlarmType"].ToString();
                    string strIsFill = m_dsReplayData.Tables[1].Rows[iCurrent]["IsFill"].ToString();
                    string bGpsValid = m_dsReplayData.Tables[1].Rows[iCurrent]["GpsValid"].ToString(); ;
                    bool bAccOn = false;
                    bool bIsFill = false;
                    m_dsReplayData.Tables[1].Rows[iCurrent]["Speed"] = strSpeed.Substring(0, strSpeed.IndexOf('.') + 3);
                    m_dsReplayData.Tables[1].Rows[iCurrent]["Longitude"] = x.Substring(0, x.IndexOf('.') + 7);
                    m_dsReplayData.Tables[1].Rows[iCurrent]["Latitude"] = y.Substring(0, y.IndexOf('.') + 7);

                    if ("1".Equals(strAccOn))
                    {
                        bAccOn = true;
                    }
                    if (strIsFill.Equals("1"))
                    {
                        bIsFill = true;
                    }
                    ThreeStateTreeNode node = MainForm.myCarList.tvList.getNodeById(sCarId);
                    string strPlateColor = (node == null) ? "未知" : node.PlateColor;
                    string strSimNum = (node == null) ? m_dsReplayData.Tables[1].Rows[iCurrent]["Simnum"].ToString() : node.SimNum;
                    string strDriverName = (node == null) ? "未知" : node.DriverName;
                    string strCompany = (node == null) ? "未知" : node.Company;
                    string strTermSerial = (node == null) ? "未知" : node.TermSerial;
                    object[] args = new object[] { sCarNum, sgpsTime, x, y, strSpeed, bAccOn ? "开" : "关", GetTransportStatus(Convert.ToInt32(strtransportStatus)), (Convert.ToDouble(strdistanceDiff) / 1000.0).ToString("F2"), StatuList, strPlateColor, strSimNum, strDriverName, strCompany, strTermSerial };
                    string sHintText = string.Format("车牌[{0}] 车牌颜色[{9}] 终端ID[{13}] Sim卡号[{10}] 驾驶员 [{11}] 所属公司[{12}] ACC[{5}] 车速[{4}km/h] 运营状态[{6}] GPS时间[{1}] 总里程[{7}公里] 经纬度[{2};{3}]\r\n车辆状态[{8}]", args);
                    wbMap.execShowCar(sCarNum, x, y, null, "1", true, sHintText, iCarStatus, iAlarmType, bIsFill, bAccOn, bGpsValid, sCarId, !chkUnShowTrack.Checked);
                    #region 插入报警点 已注释
                    /*//去掉报警点显示
                    //if ((iCurrent < m_iPlayLastTime) && (m_iPlayLastTime >= 0))
                    //{
                    //    AlarmCount = 0;
                    //    wbMap.clearAllCompany();
                    //    for (int i = 0; i < iCurrent; i++)
                    //    {
                    //        if (m_dsReplayData.Tables[1].Rows[i]["carStatu"].ToString().Equals("1"))
                    //        {
                    //            m_dsReplayData.Tables[1].Rows[i]["CarId"].ToString();
                    //            string str24 = m_dsReplayData.Tables[1].Rows[i]["gpsTime"].ToString();
                    //            string str25 = m_dsReplayData.Tables[1].Rows[i]["Speed"].ToString();
                    //            string str26 = m_dsReplayData.Tables[1].Rows[i]["AccOn"].ToString();
                    //            string str27 = m_dsReplayData.Tables[1].Rows[i]["transportStatus"].ToString();
                    //            string str28 = m_dsReplayData.Tables[1].Rows[i]["distanceDiff"].ToString();
                    //            string str29 = m_dsReplayData.Tables[1].Rows[i]["StatuList"].ToString();
                    //            string lon = m_dsReplayData.Tables[1].Rows[i]["Longitude"].ToString();
                    //            string lat = m_dsReplayData.Tables[1].Rows[i]["Latitude"].ToString();
                    //            bool flag3 = false;
                    //            if ("1".Equals(str26))
                    //            {
                    //                flag3 = true;
                    //            }
                    //            object[] objArray2 = new object[] { sCarNum, str24, lon, lat, str25, flag3 ? "开" : "关", GetTransportStatus(Convert.ToInt32(str27)), (Convert.ToDouble(str28) / 1000.0).ToString("F2"), str29, strPlateColor, strSimNum, strDriverName, strCompany, strTermSerial };
                    //            string hintText = string.Format("车牌[{0}] 终端ID[{13}] 车牌颜色[{9}] Sim卡号[{10}] 驾驶员[{11}] 所属公司[{12}] ACC[{5}] 车速[{4}km/h] 运营状态[{6}] GPS时间[{1}] 总里程[{7}公里] 经纬度[{2};{3}]\r\n车辆状态[{8}]", objArray2);
                    //            AlarmCount++;
                    //            wbMap.showCompany("报警点" + AlarmCount, hintText, lon, lat);
                    //        }
                    //    }
                    //}
                    //if (iCarStatus.Equals("1"))
                    //{
                    //    AlarmCount++;
                    //    wbMap.showCompany("报警点" + AlarmCount, sHintText, x, y);
                    //}
                    */
                    #endregion
                    
                    m_iPlayLastTime = iCurrent;
                    if ((iCurrent > 6) && (m_bShowTrack != chkUnShowTrack.Checked))
                    {
                        wbMap.setIsShowTrack(sCarId, !chkUnShowTrack.Checked);
                        m_bShowTrack = chkUnShowTrack.Checked;
                    }
                    lblGpsTimeValue.Text = sgpsTime;
                    lblLongitudeValue.Text = x;
                    lblLatitudeValue.Text = y;
                    lblSpeedValue.Text = string.Format("{0}km/h", strSpeed);
                    lblStateValue.Text = StatuList;
                    lblRecordValue.Text = string.Format("{0}/{1}", (iCurrent + 1).ToString(), sPlayCnt);
                    double result = 0.0;
                    double num3 = 0.0;
                    if (double.TryParse(strdistanceDiff, out result) && double.TryParse(strDistanceCount, out num3))
                    {
                        double num4 = (result - num3) / 1000.0;
                        if (num4 < 0.0)
                        {
                            num4 = 0.0;
                        }
                        lblMileageValue.Text = string.Format("{0:F2}/{1}", num4, sMileageCnt);
                    }
                    if ("651".Equals(strReserved))
                    {
                        strReserved = "是";
                    }
                    else
                    {
                        strReserved = "否";
                    }
                    lblIsBlackBoxValue.Text = strReserved;
                    if (strIsPic.ToUpper().Equals("TRUE"))
                    {
                        MemoryStream stream = null;
                        try
                        {
                            try
                            {
                                pbPicture.Image = null;
                                byte[] buffer = (byte[])m_dsReplayData.Tables[1].Rows[iCurrent]["Pic"];
                                stream = new MemoryStream(buffer, 0, buffer.Length);
                                Image.FromStream(stream);
                                pbPicture.Image = Image.FromStream(stream);
                                if ((pbPicture.Width < pbPicture.Image.Width) || (pbPicture.Height < pbPicture.Image.Height))
                                {
                                    pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                                else
                                {
                                    pbPicture.SizeMode = PictureBoxSizeMode.Normal;
                                }
                            }
                            catch
                            {
                            }
                            return;
                        }
                        finally
                        {
                            stream = null;
                        }
                    }
                    pbPicture.Image = null;

                    if (strAccOn.Equals("1") && chkWaitTime.Checked)
                    {
                        #region 根据站点插入停留点 已注释
                        //检查插入停留点
                        //if (iStationID < 0)
                        //{
                        //    foreach (DataRow dr in dat.Rows)
                        //    {
                        //        if (Check.GetDistance(Double.Parse(dr["lat"].ToString()), Double.Parse(dr["lng"].ToString()), Double.Parse(y), Double.Parse(x)) <= Double.Parse(dr["dis"].ToString()))
                        //        {
                        //            iStationID = int.Parse(dr["ID"].ToString());
                        //            startTime = DateTime.Parse(sgpsTime);
                        //            break;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    if (Check.GetDistance(Double.Parse(dat.Rows[iStationID]["lat"].ToString()), Double.Parse(dat.Rows[iStationID]["lng"].ToString()), Double.Parse(y), Double.Parse(x)) >= Double.Parse(dat.Rows[iStationID]["dis"].ToString()))
                        //    {
                        //        endTime = DateTime.Parse(sgpsTime);
                        //        Double waitMin = (endTime - startTime).TotalMinutes;
                        //        if (waitMin >= int.Parse(txtWaitTime.Text))
                        //        {
                        //            wbMap.showCompany("停留" + waitMin.ToString("0.0") + "分(" + iStopIndex + ")",
                        //                "开始停留时间：" + startTime.ToLongTimeString() + "<br>结束停留时间：" + endTime.ToLongTimeString() + "<br>共停留" + waitMin.ToString("0.0") + "分<br>本次回放中第" + iStopIndex + "次停留<br>",
                        //                (Double.Parse(dat.Rows[iStationID]["lng"].ToString()) - iStopIndex * 0.00002).ToString(),
                        //                (Double.Parse(dat.Rows[iStationID]["lat"].ToString()) - iStopIndex * 0.00002).ToString()
                        //                );

                        //            iStopIndex++;
                        //        }
                        //        iStationID = -1;
                        //    }
                        //}
                        #endregion

                        #region 根据停车插入停留点
                        if (string.IsNullOrEmpty(strStopLat) || string.IsNullOrEmpty(strStopLng))
                        {
                            strStopLat = y;
                            strStopLng = x;
                            startTime = DateTime.Parse(sgpsTime);
                        }
                        else if (Check.GetDistance(Double.Parse(strStopLat), Double.Parse(strStopLng), Double.Parse(y), Double.Parse(x)) >= 25.0)
                        {
                            endTime = DateTime.Parse(sgpsTime);
                            Double waitMin = (endTime - startTime).TotalMinutes;
                            if (waitMin >= int.Parse(txtWaitTime.Text))
                            {
                                wbMap.showCompany("停留" + waitMin.ToString("0.0") + "分(" + iStopIndex + ")",
                                    "开始停留时间：" + startTime + "<br>结束停留时间：" + endTime + "<br>共停留" + waitMin.ToString("0.0") + "分<br>本次回放中第" + iStopIndex + "次停留<br>",
                                    strStopLng,
                                    strStopLat
                                    );
                                iStopIndex++;
                            }
                            strStopLat = string.Empty;
                            strStopLng = string.Empty;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void tbPlay_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Down))
            {
                execGotoPlay(tbPlay.Value - 1);
            }
            else if ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Up))
            {
                execGotoPlay(tbPlay.Value + 1);
            }
        }

        private void tbPlay_MouseUp(object sender, MouseEventArgs e)
        {
            execGotoPlay(tbPlay.Value);
        }

        private void tbPlay_ValueChanged(object sender, EventArgs e)
        {
            wbMap.deleteCarByIconType(stopIconType);
            if (m_iPlayCurrent != tbPlay.Value)
            {
                btnPause.PerformClick();
            }
        }

        private void tbPlaySpeed_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tPlay.Interval = getPlaySpeed();
            }
            catch
            {
            }
        }

        private void tGetQueryTrackInfo_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (iMapCnt == pbCarPlay.Maximum)
            {
                tGetQueryTrackInfo.Enabled = false;
            }
            else
            {
                tGetQueryTrackInfo.Enabled = false;
                try
                {
                    base.Invoke(myGetTrackQueryInfo);
                }
                catch
                {
                }
                tGetQueryTrackInfo.Enabled = true;
            }
        }

        private void tsbAddPoint_Click(object sender, EventArgs e)
        {
            wbMap.setPointTool();
        }

        private void tsbArrowhead_Click(object sender, EventArgs e)
        {
            wbMap.setArrowheadTool();
        }

        private void tsbCenter_Click(object sender, EventArgs e)
        {
            wbMap.setZoomToCenter();
        }

        private void tsbChange_Click(object sender, EventArgs e)
        {
            tPlay.Enabled = false;
            int millisecondsTimeout = (int)getPlaySpeed();
            Thread.Sleep(millisecondsTimeout);
            dgvCarPlay.Visible = !dgvCarPlay.Visible;
            pbCarPlay.Visible = !pbCarPlay.Visible;
            wbMap.Visible = !wbMap.Visible;
            tsbToMap.Visible = !tsbToMap.Available;
            tsbToGrid.Visible = !tsbToGrid.Available;
            if (dgvCarPlay.Visible)
            {
                try
                {
                    setGridData();
                    tsbExport.Visible = true;
                    tsbExport.Enabled = true;
                    tGetQueryTrackInfo.Enabled = true;
                }
                catch
                {
                    WaitForm.Hide2();
                }
            }
            else
            {
                tsbExport.Visible = false;
                tsbExport.Enabled = false;
            }
            tPlay.Enabled = true;
        }

        private void tsbDelPoint_Click(object sender, EventArgs e)
        {
            wbMap.setDelPoint();
        }

        private void tsbDistance_Click(object sender, EventArgs e)
        {
            wbMap.setMeasureTool();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            if (m_bPlay)
            {
                MessageBox.Show("请先结束播放！");
            }
            else if ((m_dtPlayData == null) || (m_dtPlayData.Rows.Count == 0))
            {
                MessageBox.Show("无数据可导出！");
            }
            else
            {
                sCarText = cmbCarNum.Text;
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Execl files (*.xls)|*.xls",
                    FilterIndex = 0,
                    RestoreDirectory = true,
                    CreatePrompt = true,
                    FileName = sCarText + "-轨迹回放报表-" + DateTime.Now.ToString("yyyy-MM-dd"),
                    Title = "导出文件保存路径"
                };
                string fileName = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        WaitForm.Show("正在导出数据...", this);
                        try
                        {
                            excelWorker = new BackgroundWorker();
                            excelWorker.DoWork += new DoWorkEventHandler(excelWorker_DoWork);
                            excelWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(excelWorker_RunWorkerCompleted);
                            excelWorker.RunWorkerAsync(fileName);
                        }
                        catch (Exception exception)
                        {
                            WaitForm.Hide();
                            MessageBox.Show(exception.Message + "\r\n原因：文件可能已打开！");
                            Record.execFileRecord("轨迹回放->导出到Excel", exception.Message);
                        }
                    }
                }
            }
        }

        private void tsbMove_Click(object sender, EventArgs e)
        {
            wbMap.setPanTool();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            pdMap.DefaultPageSettings.Landscape = true;
            CaptureScreen();
            ppdMap.Document = pdMap;
            ppdMap.ShowDialog();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            wbMap.Refresh();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
        }

        private void tsbSaveLine_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if (m_iPlayCurrent <= 1)
                {
                    MessageBox.Show("请先播放出两个以上的轨迹点！");
                }
                else
                {
                    if (btnPause.Enabled)
                    {
                        btnPause.PerformClick();
                    }
                    for (int i = 0; i < m_iPlayCurrent; i++)
                    {
                        if ((double.Parse(m_dsReplayData.Tables[1].Rows[i]["Longitude"].ToString()) >= 0.001) && (double.Parse(m_dsReplayData.Tables[1].Rows[i]["Latitude"].ToString()) >= 0.001))
                        {
                            object obj2 = str;
                            str = string.Concat(new object[] { obj2, m_dsReplayData.Tables[1].Rows[i]["Longitude"], ",", m_dsReplayData.Tables[1].Rows[i]["Latitude"], ";" });
                        }
                    }
                    new MapPath(itmPreSetPath.PreType.预设报警路线) { PathDot = str.Trim(new char[] { ';' }) }.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void tsbShowAll_Click(object sender, EventArgs e)
        {
            wbMap.zoomToMaxExtent();
        }

        private void tsbShowHint_Click(object sender, EventArgs e)
        {
            wbMap.setShowHintTool();
        }

        private void tsbZoomDown_Click(object sender, EventArgs e)
        {
            wbMap.setZoomDownTool();
        }

        private void tsbZoomUp_Click(object sender, EventArgs e)
        {
            wbMap.setZoomUpTool();
        }

        private void wbMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wbMap.Url.ToString().Equals("about:blank"))
            {
                picLoadMap.Visible = false;
            }
            else if (wbMap.Document.GetElementById("map") == null)
            {
                picLoadMap.Visible = false;
                wbMap.Url = new Uri("about:blank");
                MessageBox.Show("地图初始化失败！");
                Record.execFileRecord("加载地图", "地图初始化失败！");
            }
            else
            {
                pnlHandle.Enabled = true;
                pnlTool.Enabled = true;
                object obj2 = wbMap.getMapList();
                if (obj2 == null)
                {
                    picLoadMap.Visible = false;
                }
                else
                {
                    setMap(obj2.ToString());
                    wbMap.setMap(MainForm.myMap.getMapView());
                    MainForm.myMap.showFlagMap(wbMap);
                    picLoadMap.Visible = false;
                }
            }
        }

        private void wbMap_MapMouseUp(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                object obj2 = wbMap.getMapClicked();
                if ((obj2 != null) && bool.Parse(obj2.ToString()))
                {
                    switch (wbMap.m_sTool)
                    {
                        case GisMap.MapTool.标注地图:
                            MainForm.myMap.setMapToolAddPoints(wbMap);
                            IsFlagChanged = true;
                            return;

                        case GisMap.MapTool.删除标注:
                            MainForm.myMap.setMapToolDelPoints(wbMap);
                            IsFlagChanged = true;
                            return;
                    }
                }
            }
        }

        public bool IsFlagChanged { get; set; }

        private delegate void dEnable(string sType);

        private delegate void dGetTrackQueryInfo();

        private delegate void dPlay();

        private delegate void dPlayCnt(DataTable dt);

        private delegate void dShowMessage(string sMess);

        public class TransportStatu
        {
            public const int IsEmpty = 0;
            public const int IsNotEmpty = 3;
            public const int IsStop = 1;
            public const int IsWorking = 4;
            public const int Reserver = 2;
        }

        public class TransportStatuMsg
        {
            public const string IsEmpty = "空车";
            public const string IsNotEmpty = "重车";
            public const string IsStop = "停运";
            public const string IsWorking = "运营";
            public const string Reserver = "预约";
        }

        /// <summary>
        /// 显示停车点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbStop_Click(object sender, EventArgs e)
        {
            if (m_iPlayCurrent > 0)
            {
                //暂停播放
                btnPause.PerformClick();
                bool flag = false;
                int totalMinutes = 0;
                string str = "";
                string s = "";
                string str3 = "";
                object obj2 = null;
                bool flag2 = true;
                string format = "从{0}开始，在此地停车{1}分钟";
                string str5 = "";
                object obj3 = null;
                object obj4 = null;
                bool flag3 = false;
                bool flag4 = false;
                string str6 = "";
                string str7 = "";
                bool flag5 = false;
                DateTime minValue = DateTime.MinValue;
                wbMap.deleteCarByIconType(stopIconType);
                DataTable table = m_dsReplayData.Tables[1].Clone();
                table.Columns.Add("sHintText");
                for (int i = 0; i < m_iPlayCurrent; i++)
                {
                    bool flag6 = false;
                    int num3 = 0;
                    DataRow row = m_dsReplayData.Tables[1].Rows[i];
                    if (flag && ((Convert.ToInt32(row["Speed"]) == 0) || (i == (m_iPlayCurrent - 1))))
                    {
                        TimeSpan span = (TimeSpan)(Convert.ToDateTime(row["gpsTime"]) - minValue);
                        totalMinutes = (int)span.TotalMinutes;
                        str5 = string.Format(format, minValue, totalMinutes);
                        if (((totalMinutes > 0) && (table != null)) && (table.Rows.Count != 0))
                        {
                            for (int k = 0; k < table.Rows.Count; k++)
                            {
                                if ((table.Rows[k]["Longitude"].ToString() == s) && (table.Rows[k]["Latitude"].ToString() == str3))
                                {
                                    flag6 = true;
                                    num3 = k;
                                }
                            }
                        }
                        if (!flag6)
                        {
                            DataRow row2 = table.NewRow();
                            row2["CarNum"] = str;
                            row2["CarStatu"] = obj3;
                            row2["AlarmType"] = obj4;
                            if (flag3)
                            {
                                row["IsFill"] = 1;
                            }
                            else
                            {
                                row["IsFill"] = 0;
                            }
                            row2["Accon"] = false;
                            row2["GpsValid"] = str6;
                            row2["CarId"] = str7;
                            row2["Longitude"] = s;
                            row2["Latitude"] = str3;
                            row2["sHintText"] = str5;
                            table.Rows.Add(row2);
                        }
                        else
                        {
                            table.Rows[num3]["sHintText"] = table.Rows[num3]["sHintText"].ToString() + "</br> " + str5;
                        }
                        flag = false;
                    }
                    else if ((Convert.ToInt32(row["Speed"]) != 0) && !flag)
                    {
                        str = row["CarNum"].ToString();
                        obj3 = row["carStatu"].ToString();
                        obj4 = row["AlarmType"].ToString();
                        if (row["IsFill"].ToString().Equals("1"))
                        {
                            flag3 = true;
                        }
                        flag4 = false;
                        str6 = row["GpsValid"].ToString();
                        str7 = row["CarId"].ToString();
                        s = row["Longitude"].ToString();
                        str3 = row["Latitude"].ToString();
                        minValue = Convert.ToDateTime(row["gpsTime"]);
                        if ((double.Parse(s) >= 0.001) && (double.Parse(str3) >= 0.001))
                        {
                            flag = true;
                        }
                    }
                }
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    DataRow row3 = table.Rows[j];
                    wbMap.execShowCar("停车点" + (j + 1), row3["Longitude"], row3["Latitude"], obj2, stopIconType, flag2, row3["sHintText"], row3["CarStatu"], row3["AlarmType"], row3["IsFill"], flag4, row3["GpsValid"], row3["CarId"].ToString() + (j + 1), flag5);
                }
                MessageBox.Show("已播放轨迹中有" + table.Rows.Count + "个停车点。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chkWaitTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWaitTime.Checked)
            {
                txtWaitTime.Enabled = true;
            }
            else
            {
                txtWaitTime.Enabled = false;
            }
        }

        private void txtWaitTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("请输入数字!");
            }
        }

        private void tsbSaveImage_Click(object sender, EventArgs e)
        {
            PrintOption option = new PrintOption(wbMap);
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "图片(*.bmp;*.png;*.gif;*.jpg)|*.bmp;*.png;*.gif;*.jpg"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                option.PrintImage.Save(dialog.FileName);
            }
        }
    
    
    }
}
