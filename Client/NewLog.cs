namespace Client
{
    using PublicClass;
    using ParamLibrary.Application;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Timers;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class NewLog : LogForm
    {
        private string sBatchNameOrder = "BatchNameOrder";
        private System.Timers.Timer tBatchName = new System.Timers.Timer(1000.0);

        public NewLog()
        {
            this.InitializeComponent();
        }

        public override void addLogMsg(DataTable dtLogResult)
        {
            if ((dtLogResult != null) && (dtLogResult.Rows.Count != 0))
            {
                try
                {
                    bool flag = true;
                    string str = null;
                    DataView view = null;
                    dtLogResult.Columns.Add(new DataColumn("ColLog"));
                    dtLogResult.Columns.Add(new DataColumn("LocalCurTime"));
                    view = new DataView(dtLogResult) {
                        RowFilter = base.m_dvLogData.RowFilter
                    };
                    int firstDisplayedScrollingRowIndex = base.dgvLogData.FirstDisplayedScrollingRowIndex;
                    int count = view.Count;
                    if (base.m_dvLogData.RowFilter.Length > 0)
                    {
                        int length = dtLogResult.Select(base.m_dvLogData.RowFilter).Length;
                    }
                    this.execSetLaPlace(dtLogResult);
                    if (base.m_dvLogData.Sort.Length == 0)
                    {
                        base.m_dtLogData = dtLogResult.Clone();
                        base.m_dvLogData = new DataView(base.m_dtLogData, "", "LocalCurTime DESC,ReceTime DESC,OrderId DESC", DataViewRowState.CurrentRows);
                        base.dgvLogData.DataSource = base.m_dvLogData;
                    }
                    foreach (DataRow row in dtLogResult.Select(base.m_dvLogData.RowFilter))
                    {
                        flag = true;
                        str = row["OrderId"].ToString();
                        if (dtLogResult.Columns.IndexOf("RespCode") >= 0)
                        {
                            this.CancelAlarmResponse(row);
                        }
                        if (base.m_dtLogData.Rows.Count > 0)
                        {
                            if (((Convert.ToInt32(row["msgType"]) == CmdParam.OrderType.Command) || (Convert.ToInt32(row["msgType"]) == CmdParam.OrderType.SendMsg)) && ((row["OrderName"].ToString() != "末次位置查询") && (row["OrderName"].ToString() != "提示信息")))
                            {
                                string filterExpression = string.Format("OrderId='{0}'", str);
                                string str3 = "";
                                foreach (DataRow row2 in base.m_dtLogData.Select(filterExpression))
                                {
                                    row2["OrderResult"] = row["OrderResult"];
                                    row2["CommFlag"] = row["CommFlag"];
                                    str3 = row["Describe"].ToString().Trim();
                                    if (str3.Length > 0)
                                    {
                                        row2["Describe"] = str3;
                                    }
                                    flag = false;
                                }
                            }
                            else if ((Convert.ToInt32(row["msgType"]) == CmdParam.OrderType.Terminal) && ((row["OrderName"].ToString().Equals("设置多功能区域报警应答", StringComparison.OrdinalIgnoreCase) || row["OrderName"].ToString().Equals("设置车台分路段超速报警应答", StringComparison.OrdinalIgnoreCase)) || row["OrderName"].ToString().Equals("设置取消区域报警应答", StringComparison.OrdinalIgnoreCase)))
                            {
                                string str4 = string.Format("OrderId='{0}' and OrderName='{1}'", str, row["OrderName"].ToString());
                                string str5 = "";
                                foreach (DataRow row3 in base.m_dtLogData.Select(str4))
                                {
                                    row3["OrderResult"] = row["OrderResult"];
                                    row3["CommFlag"] = row["CommFlag"];
                                    str5 = row["Describe"].ToString().Trim();
                                    if (str5.Length > 0)
                                    {
                                        row3["Describe"] = str5;
                                    }
                                    flag = false;
                                }
                            }
                            this.BatchName(row, str);
                        }
                        if (flag)
                        {
                            int num2 = base.dgvLogData.SelectedRows.Count;
                            row["LocalCurTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            base.m_dtLogData.ImportRow(row);
                            if (num2 == 0)
                            {
                                base.dgvLogData.ClearSelection();
                            }
                            if (base.m_dtLogData.Rows.Count > base.iMaxLogCnt)
                            {
                                base.m_dvLogData.Delete(base.iMaxLogCnt);
                            }
                        }
                    }
                    str = null;
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
                        Record.execFileRecord("最新日志添加操作", exception.Message);
                    }
                }
                finally
                {
                    if (dtLogResult != null)
                    {
                        dtLogResult = null;
                    }
                }
            }
        }

        public void AddUserMessageToNewLog(string sMsg)
        {
            string str = "";
            if (string.IsNullOrEmpty(str))
            {
                str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.AddUserMessageToNewLog(str, "", "0", "信息", "提示信息", "", sMsg);
        }

        public void AddUserMessageToNewLog(string sMsg, string sOrderType)
        {
            string str = "";
            if (string.IsNullOrEmpty(str))
            {
                str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.AddUserMessageToNewLog(str, "", "0", sOrderType, "提示信息", "", sMsg);
        }

        public void AddUserMessageToNewLog(string sReceTime, string sCarNum, string sOrderId, string sOrderType, string sOrderName, string sOrderResult, string sMsg)
        {
            if (base.m_dtLogData != null)
            {
                try
                {
                    if (base.m_dtLogData.Columns.Count <= 0)
                    {
                        foreach (DataGridViewColumn column in base.dgvLogData.Columns)
                        {
                            if (!(column.Name == "CarName") && !(column.Name == "workid"))
                            {
                                base.m_dtLogData.Columns.Add(column.Name, typeof(string));
                            }
                        }
                    }
                    if (!base.m_dtLogData.Columns.Contains("ColLog"))
                    {
                        base.m_dtLogData.Columns.Add(new DataColumn("ColLog"));
                    }
                    if (!base.m_dtLogData.Columns.Contains("LocalCurTime"))
                    {
                        base.m_dtLogData.Columns.Add(new DataColumn("LocalCurTime"));
                    }
                    DataRow row = base.m_dtLogData.NewRow();
                    row["ReceTime"] = sReceTime;
                    row["CarNum"] = sCarNum;
                    row["OrderId"] = sOrderId;
                    row["OrderType"] = sOrderType;
                    row["OrderName"] = sOrderName;
                    row["OrderResult"] = sOrderResult;
                    row["Describe"] = sMsg;
                    row["LocalCurTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    base.m_dtLogData.Rows.Add(row);
                    if (base.m_dvLogData.Sort.Length == 0)
                    {
                        base.m_dvLogData = new DataView(base.m_dtLogData, "", "LocalCurTime DESC, ReceTime DESC", DataViewRowState.CurrentRows);
                        base.dgvLogData.DataSource = base.m_dvLogData;
                    }
                    int firstDisplayedScrollingRowIndex = base.dgvLogData.FirstDisplayedScrollingRowIndex;
                    if (base.dgvLogData.SelectedRows.Count == 0)
                    {
                        base.dgvLogData.ClearSelection();
                    }
                    if (base.m_dtLogData.Rows.Count > base.iMaxLogCnt)
                    {
                        base.m_dvLogData.Delete(base.iMaxLogCnt);
                    }
                    if (firstDisplayedScrollingRowIndex >= 0)
                    {
                        base.dgvLogData.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                    }
                    base.dgvLogData.Refresh();
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("最新日志添加操作->增加提示信息", exception.Message);
                }
            }
        }

        private void BatchName(DataRow myRow, string sOrderId)
        {
            if ((MainForm.htBatchName != null) && ((myRow["OrderName"].ToString() == "实时定位信息报文") || myRow["OrderName"].ToString().Equals("压缩定位信息报文")))
            {
                string sRequesId = myRow["CarId"].ToString();
                bool flag = false;
                if ((MainForm.htBatchName != null) && (MainForm.htBatchName.Count > 0))
                {
                    foreach (string str2 in MainForm.htBatchName.Keys)
                    {
                        if (sRequesId == str2)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    MainForm.htBatchName[sRequesId] = sOrderId + "|" + myRow["ReceTime"].ToString();
                    this.execExcuteTrackPointQuerty(sRequesId, myRow["Longitude"].ToString(), myRow["Latitude"].ToString());
                    if (this.myBatchName == null)
                    {
                        this.myBatchName = new dBatchName(this.getTrackPointQueryInfo);
                    }
                    if (!this.tBatchName.Enabled)
                    {
                        this.tBatchNameAddEventHandler();
                    }
                }
            }
        }

        private void CancelAlarmResponse(DataRow myRow)
        {
            int num;
            string s = myRow["RespCode"].ToString();
            string sCarId = myRow["CarId"].ToString();
            if (int.TryParse(s, out num))
            {
                switch (num)
                {
                    case 8:
                    case 9:
                    case 10:
                    case 466:
                    case 467:
                    case 1157:
                        this.NewLogStopAlarm(myRow, sCarId);
                        break;

                    default:
                        return;
                }
            }
        }

 public void execExcuteTrackPointQuerty(string sRequesId, string sLon, string sLat)
        {
            try
            {
                MainForm.myMap.execExcuteTrackPointQuerty(this.sBatchNameOrder, sRequesId, sLon, sLat);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("批量点名->发送位置信息查询", exception.Message);
            }
        }

        private void execSetLaPlace(DataTable dtLogData)
        {
            try
            {
                foreach (DataRow row in dtLogData.Select("msgType=65 or msgType=66 or OrderName='实时定位信息报文' or OrderName='末次位置查询'"))
                {
                    if (("1".Equals(row["isImportWatch"].ToString()) && (MainForm.myImportReport != null)) && MainForm.myImportReport.IsHandleCreated)
                    {
                        MainForm.myImportReport.ShowCar(row);
                    }
                    string str = "";
                    str = MainForm.myCarList.setMapTipDetail(row);
                    bool isZoom = false;
                    bool bIsFill = false;
                    bool bAccOn = false;
                    bool bGpsValid = false;
                    object iDirection = null;
                    if ("1".Equals(row["IsFill"].ToString()))
                    {
                        bIsFill = true;
                    }
                    if ("1".Equals(row["AccOn"].ToString()))
                    {
                        bAccOn = true;
                    }
                    if ("1".Equals(row["GpsValid"].ToString()) || !bAccOn)
                    {
                        //修改为当ACC关闭时定位状态为有效
                        bGpsValid = true;
                    }
                    if ("-1".Equals(row["isImportWatch"].ToString()) || "末次位置查询".Equals(row["OrderName"].ToString()))
                    {
                        isZoom = true;
                    }
                    if (row.Table.Columns.Contains("Direct"))
                    {
                        iDirection = row["Direct"];
                    }
                    string iCarStatus;
                    if ("末次位置查询".Equals(row["OrderName"].ToString()))
                    {
                        iCarStatus = "4";
                        //修改末次位置查询地图显示图标 hzh 2014.2.20
                    }
                    else
                    {
                        iCarStatus = "2";
                    }
                    string key = row["CarId"].ToString();
                    if ((MainForm.myCarList.m_dtCarAlermList != null) && (MainForm.myCarList.m_dtCarAlermList.Rows.Find(key) != null))
                    {
                        iCarStatus = "1";
                    }
                    MainForm.myMap.execShowCar(row["CarNum"].ToString(), row["Longitude"].ToString(), row["Latitude"].ToString(), iDirection, 1, isZoom, str.Replace("；", "\r\n"), iCarStatus, null, bIsFill, bAccOn, bGpsValid, row["CarId"].ToString());
                    //MainForm.myCarList.setOnline(row);
                    MainForm.myCarList.setOffLine2(row["CarId"].ToString());
                    //修改末次位置查询车辆列表显示图标 huzh 2014.2.20
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("最新日志位置报文处理", exception.Message);
            }
        }

        public void execStopPlayTrackLine()
        {
            try
            {
                MainForm.myMap.execStopPlayTrackLine(this.sBatchNameOrder);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("批量点名->清除结果", exception.Message);
            }
        }

        public void getTrackPointQueryInfo()
        {
            string[] separator = new string[] { "::" };
            object obj2 = null;
            try
            {
                obj2 = MainForm.myMap.getTrackPointQueryInfo(this.sBatchNameOrder);
                if ((obj2 != null) && !string.IsNullOrEmpty(obj2.ToString()))
                {
                    string[] strArray2 = obj2.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    string str2 = "";
                    string str3 = "";
                    foreach (string str4 in strArray2)
                    {
                        int index = str4.IndexOf('|');
                        if (index != -1)
                        {
                            str2 = str4.Substring(index + 1);
                            str3 = str4.Substring(0, index);
                            if (MainForm.htBatchName[str3] != null)
                            {
                                string[] strArray3 = MainForm.htBatchName[str3].ToString().Split(new char[] { '|' });
                                string filterExpression = string.Format("OrderId='{0}' and CarId='{1}' and ReceTime='{2}'", strArray3[0], str3, strArray3[1]);
                                DataRow[] rowArray = base.m_dtLogData.Select(filterExpression);
                                if (rowArray.Length > 0)
                                {
                                    //DataRow row;
                                    ///
                                    DataTable table = new DataTable();
                                    DataRow row = table.NewRow();
                                    ///

                                    object obj3 = row["Describe"];
                                    (row = rowArray[0])["Describe"] = string.Concat(new object[] { obj3, ";位置信息[", str2, "];" });
                                    MainForm.htBatchName.Remove(str3);
                                    ThreeStateTreeNode node = MainForm.myCarList.tvList.getNodeById(str3);
                                    if (node != null)
                                    {
                                        node.Address = str2;
                                    }
                                }
                            }
                        }
                    }
                    if (MainForm.htBatchName.Count == 0)
                    {
                        this.execStopPlayTrackLine();
                        this.tBatchNameRemoveEventHandler();
                        MainForm.htBatchName = null;
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("批量点名->获取地理位置信息", exception.Message);
            }
        }

 private void NewLog_Load(object sender, EventArgs e)
        {
            base.dgvLogData.ClearSelection();
        }

        private void NewLogStopAlarm(DataRow myRow, string sCarId)
        {
            bool bAccOn = false;
            if ("1".Equals(myRow["AccOn"].ToString()))
            {
                bAccOn = true;
            }
            ThreeStateTreeNode node = MainForm.myCarList.tvList.getNodeById(sCarId);
            if (node != null)
            {
                string strB = myRow["ReceTime"].ToString();
                if (node.LastAlarmSetTime.CompareTo(strB) <= 0)
                {
                    this.stopAlarm(sCarId, bAccOn);
                    node.LastAlarmStopTime = strB;
                }
            }
        }

        private void stopAlarm(string sCarId, bool bAccOn)
        {
            MainForm.myCarList.setCancelAlarm(sCarId, bAccOn);
            MainForm.myMap.setCarAlarm(sCarId, false);
            MainForm.myCarList.StopAlerm(sCarId);
        }

        private void tBatchName_Elapsed(object sender, ElapsedEventArgs e)
        {
            if ((MainForm.htBatchName != null) && (MainForm.htBatchName.Count != 0))
            {
                try
                {
                    base.Invoke(this.myBatchName);
                }
                catch
                {
                }
            }
        }

        public void tBatchNameAddEventHandler()
        {
            if (this.tBatchName != null)
            {
                this.tBatchName.Elapsed += new ElapsedEventHandler(this.tBatchName_Elapsed);
                this.tBatchName.Start();
                this.tBatchName.Enabled = true;
            }
        }

        public void tBatchNameRemoveEventHandler()
        {
            if (this.tBatchName != null)
            {
                this.tBatchName.Enabled = false;
                this.tBatchName.Elapsed -= new ElapsedEventHandler(this.tBatchName_Elapsed);
            }
            if (this.myBatchName != null)
            {
                this.myBatchName = null;
            }
        }

        private delegate void dBatchName();

        private enum ResponseValue
        {
            RESP_CANCEL_DRIVER_PATH = 1157,
            RESP_CANCEL_IN_REGION_ALARM = 9,
            RESP_CANCEL_OUT_REGION_ALARM = 8,
            RESP_CANCEL_TEMP_ALARM = 467,
            RESP_SET_AUTO_PATH_ALARM = 466,
            RESP_STOP_ALARM = 10
        }
    }
}

