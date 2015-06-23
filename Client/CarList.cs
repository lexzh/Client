using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PublicClass;
using WinFormsUI.Controls;
using System.IO;
using System.Text.RegularExpressions;
using Remoting;
using Client.Properties;
using Library;

namespace Client
{
    public partial class CarList : Client.ToolWindow
    {
        private string _disableMenuList = "itmDynPathALarmOn,itmDynPathALarmOff,itmShowPath,itmClearPath,itmPreSetPath,itmOilBox,itmTemp,itmCarPlayTrack,itmQuery1,itmClearCarTrack,BatchSetAreaAlarm,itmCancelRegAlarm,itmSetRegionSTAlarm,itmCRegionSTAlarm,itmSetExternalAlarm,itmCExternalAlarm,itmShowOutRegion,itmShowInRegion,itmPreSetRegion,itmUndoMultiRegion,itmShowMultiOutReg,itmShowMultiInReg,itmPreSetMultiReg,itmDistrictAlarm,itmSendQuestion,itmCarVideo";
        private CarAlarmEx _弹出警报窗口;
        private bool bShippingEnd;
        private DataView dvTrackCar = new DataView();
        private int iIndex;
        public bool IsFresh;
        private bool IsPlayAlarmSound;
        public int iTipCount = int.Parse(Variable.sGetNodeTipShowType);
        private bool m_bDownResult = true;
        private bool m_bShippingResult;
        public DataTable m_dtAllAreaList;
        public DataTable m_dtCarAlermList;
        public DataTable m_dtCarList;
        public DataTable m_dtShippingList;
        private DataTable m_dtShippingListTemp;
        private int m_iCarCnt;
        private int m_iPagNum;
        private static string m_sAlarmKey = "Car_r";
        private string m_sCheckedCar = "";
        /// <summary>
        /// 未定位图标
        /// </summary>
        private static string m_sFaultKey = "fault";
        /// <summary>
        /// 重车
        /// </summary>
        private static string m_sFillKey = "Car_f";
        /// <summary>
        /// 离线
        /// </summary>
        private static string m_sOffLineKey = "Car_g";
        /// <summary>
        /// 在线
        /// </summary>
        private static string m_sOnLineKey = "Car_b";
        /// <summary>
        /// 停车，报警状态
        /// </summary>
        private static string m_sStopAlarmKey = "stop_r";
        /// <summary>
        /// 停车，重车状态
        /// </summary>
        private static string m_sStopFillKey = "stop_f";
        /// <summary>
        /// 停止，正常状态
        /// </summary>
        private static string m_sStopOnLineKey = "stop_b";
        /// <summary>
        /// 休眠状态
        /// </summary>
        private static string m_sStopSleepKey = "stop_g";

        private dSetChangeNodeAddress myChangeNodeAddress;
        private dCheckChange myCheckChange;
        private dSetAlarmText mySetAlarmText;
        private dSetAreaText mySetAreaText;
        public dSetCarStatus mySetCarStatus;
        private dSetEnabled mySetEnabled;
        private dSetShowTipText mySetShowTipText;
        private dShowCarDetail myShowCarDetail;
        private dUpdatePlace myUpdatePlace;
        private object objLock = new object();
        private string sDetailCarId = "";
        private System.Timers.Timer tGetShippingTimer;
        private System.Timers.Timer tPlayAlarmSount;
        private static Thread tSetOnline;
        private System.Timers.Timer tUpdateCarPlace;
        private BackgroundWorker worker_SetWatchCar;
        private BackgroundWorker workerRefresh;
        private ContextMenuStrip m_menuList;

        public CarList()
        {
            InitializeComponent();
        }

        private bool AddAlarmNode(DataRow myRow)
        {
            string sCarId = myRow["carID"].ToString();
            ThreeStateTreeNode alarmNode = this.tvList.getNodeById(sCarId);
            if (alarmNode != null)
            {
                ThreeStateTreeNode myNode = this.tvTrackCar.getNodeById(sCarId);
                if (myNode == null)
                {
                    //设置显示
                    string showCarNum = string.Empty;
                    if (!Variable.sJGShowCar.Equals("0"))
                    {
                        string reg = "[\u4e00-\u9fa5][A-Z][A-Z0-9]{5}$";
                        if (Variable.sJGShowCar.Equals("1"))
                        {
                            showCarNum = new Regex(reg).Replace(myRow["CarNum"].ToString(), "").TrimEnd(new char[] { ' ', '-' });
                        }
                        else
                        {
                            showCarNum = new Regex(reg).Match(myRow["CarNum"].ToString()).Value;
                        }
                    }
                    if (string.IsNullOrEmpty(showCarNum))
                    {
                        showCarNum = myRow["CarNum"].ToString();
                    }

                    string str2 = myRow["statuName"].ToString();
                    string str3 = myRow["SimNum"].ToString();
                    ThreeStateTreeNode node = new ThreeStateTreeNode(myRow["CarNum"].ToString())
                    {
                        CarCnt = 1,
                        Name = sCarId,
                        Tag = "CAR",
                        SimNum = str3,
                        ImageKey = m_sAlarmKey,
                        SelectedImageKey = m_sAlarmKey,
                        CarStatusValue = str2,
                        ContextMenuStrip = this.m_menuList,
                        Text = showCarNum
                    };

                    if (!string.IsNullOrEmpty(alarmNode.Place))
                    {
                        node.Text = string.Format("{0}({1})", node.Text, alarmNode.Place);
                    }

                    this.setCarTipShowType(node, alarmNode);
                    this.tvTrackCar.Nodes[0].Nodes.Add(node);
                    this.tvTrackCar.hasCarPath.Add(sCarId, node);
                    this.setNodeFontNewStyle(node);
                    return true;
                }
                this.setNodeFontNewStyle(myNode);
                if (myNode.CarStatusValue != myRow["statuName"].ToString())
                {
                    myNode.CarStatusValue = myRow["statuName"].ToString();
                    this.setCarTipShowType(myNode);
                    return true;
                }
            }
            return false;
        }

        private void AddAlerm()
        {
            try
            {
                if ((this.dgvTrackCar.DataSource == null) && (this.m_dtCarAlermList != null))
                {
                    this.BindDgvTrackCar();
                    this.setDgvTrackCar();
                }
                this.gbAlarmList.Text = "报警车辆(" + this.dgvTrackCar.Rows.Count + ")";
            }
            catch
            {
            }
        }

        public void AddAlerm(DataRow myRow)
        {
            try
            {
                if (this.tvTrackCar.Nodes.Count == 0)
                {
                    ThreeStateTreeNode node = new ThreeStateTreeNode("报警车辆")
                    {
                        Name = "001",
                        Tag = "AREA",
                        ContextMenuStrip = this.m_menuList
                    };
                    this.tvTrackCar.Nodes.Add(node);
                    this.tvTrackCar.setSelectNode(node);
                    this.tvTrackCar.Sort();
                    this.tvTrackCar.ExpandAll();
                }
                if (this.m_dtCarAlermList == null)
                {
                    ((ThreeStateTreeNode)this.tvTrackCar.Nodes[0]).SetNodeText("报警车辆(0)");
                    this.tvTrackCar.Enabled = false;
                }
                else
                {
                    this.tvTrackCar.Enabled = true;
                    bool flag = false;
                    if (myRow != null)
                    {
                        if (this.AddAlarmNode(myRow))
                        {
                            flag = true;
                            ((ThreeStateTreeNode)this.tvTrackCar.Nodes[0]).SetNodeText("报警车辆(" + this.tvTrackCar.Nodes[0].Nodes.Count + ")");
                        }
                    }
                    else
                    {
                        foreach (DataRow row in this.m_dtCarAlermList.Copy().Rows)
                        {
                            if (this.AddAlarmNode(row))
                            {
                                flag = true;
                            }
                        }
                        this.tvTrackCar.Sort();
                        ((ThreeStateTreeNode)this.tvTrackCar.Nodes[0]).SetNodeText("报警车辆(" + this.tvTrackCar.Nodes[0].Nodes.Count + ")");
                        this.tvTrackCar.ExpandAll();
                    }
                    if (flag)
                    {
                        this.tsbAlarmAffirm.Image = Resources.AlarmSound;
                        AlarmSound.GetInstance().IsCustomAlarmSound(this.m_dtCarAlermList);
                        this.IsPlayAlarmSound = true;
                        this.tPlayAlarmSount.Enabled = true;
                    }
                    this.OpenAlarmWindow();
                }
            }
            catch (Exception exception)
            {
                if (Variable.bLogin)
                {
                    Record.execFileRecord("添加到报警车辆树", exception.ToString());
                }
            }
        }

        public void AddAlermList(string carId, DataRow dr)
        {
            try
            {
                if ((this.m_dtCarAlermList == null) || !this.m_dtCarAlermList.Columns.Contains("ColLog"))
                {
                    bool flag = false;
                    this.m_dtCarAlermList = new DataTable();
                    foreach (DataColumn column in dr.Table.Columns)
                    {
                        if (column.ColumnName == "ColLog")
                        {
                            flag = true;
                        }
                        this.m_dtCarAlermList.Columns.Add(column.ColumnName, column.DataType);
                    }
                    if (!flag)
                    {
                        this.m_dtCarAlermList.Columns.Add("ColLog", typeof(string));
                    }
                    this.m_dtCarAlermList.PrimaryKey = new DataColumn[] { this.m_dtCarAlermList.Columns["CarId"] };
                }
                lock (this.m_dtCarAlermList)
                {
                    DataRow row = this.m_dtCarAlermList.Rows.Find(carId);
                    if (row != null)
                    {
                        this.m_dtCarAlermList.Rows.Remove(row);
                    }
                    this.m_dtCarAlermList.Rows.Add(dr.ItemArray);
                }
                base.Invoke(this.mySetAlarmText, new object[] { dr });
            }
            catch (Exception exception)
            {
                Record.execFileRecord("添加到报警车辆列表", exception.ToString());
            }
        }

        public void AlarmConfirm()
        {
            this.tsbAlarmAffirm.Image = Resources.AlarmCancel;
            this.IsPlayAlarmSound = false;
            this.tPlayAlarmSount.Enabled = false;
            foreach (ThreeStateTreeNode node in this.tvTrackCar.Nodes[0].Nodes)
            {
                this.setNodeFontDefault(node);
            }
        }

        public void AutoCheckAllCar()
        {
            if ((Variable.sAutoCheckAllCar == "1") && (this.tvList.Nodes.Count > 0))
            {
                foreach (ThreeStateTreeNode node in this.tvList.Nodes)
                {
                    node.Checked = true;
                }
            }
        }

        private void BindDgvTrackCar()
        {
            lock (this.m_dtCarAlermList)
            {
                this.dvTrackCar = new DataView(this.m_dtCarAlermList, "", "", DataViewRowState.CurrentRows);
            }
            this.dgvTrackCar.DataSource = this.dvTrackCar;
        }

        public void cancelWatchNode(object oNode)
        {
            ThreeStateTreeNode node = (ThreeStateTreeNode)oNode;
            if (node.Tag.Equals("CAR"))
            {
                base.Invoke(this.mySetCarStatus, new object[] { node, m_sOffLineKey });
            }
            else
            {
                foreach (ThreeStateTreeNode node2 in node.Nodes)
                {
                    this.cancelWatchSubNode(node2);
                }
                base.Invoke(this.mySetAreaText, new object[] { node });
            }
            for (ThreeStateTreeNode node3 = node.Parent as ThreeStateTreeNode; node3 != null; node3 = node3.Parent as ThreeStateTreeNode)
            {
                base.Invoke(this.mySetAreaText, new object[] { node3 });
            }
        }

        private void cancelWatchSubNode(ThreeStateTreeNode node)
        {
            if (node.Tag.Equals("CAR"))
            {
                base.Invoke(this.mySetCarStatus, new object[] { node, m_sOffLineKey });
            }
            else
            {
                foreach (ThreeStateTreeNode node2 in node.Nodes)
                {
                    this.cancelWatchSubNode(node2);
                }
                base.Invoke(this.mySetAreaText, new object[] { node });
            }
        }

        private void CarList_DockStateChanged(object sender, EventArgs e)
        {
            if ((base.ParentForm != null) && (base.ParentForm.Name == "MainForm"))
            {
                ((MainForm)base.ParentForm).setMenuViewChecked();
            }
        }

        private void CarList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.tPlayAlarmSount.Enabled = false;
                this.tPlayAlarmSount.Dispose();
                this.tUpdateCarPlace.Enabled = false;
                tSetOnline.Abort();
            }
            catch (ThreadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch
            {
            }
        }

        private void CarList_Load(object sender, EventArgs e)
        {
            this.mySetCarStatus = new dSetCarStatus(this.setCarStatus);
            this.mySetEnabled = new dSetEnabled(this.setEnabled);
            this.mySetAreaText = new dSetAreaText(this.setNodeShow);
            this.mySetAlarmText = new dSetAlarmText(this.AddAlerm);
            this.mySetShowTipText = new dSetShowTipText(this.SetShowTipText);
            this.myUpdatePlace = new dUpdatePlace(this.updCarPlace);
            this.myCheckChange = new dCheckChange(this.tvList.CheckChang);
            this.myShowCarDetail = new dShowCarDetail(this.ShowCarDetail);
            this.myChangeNodeAddress = new dSetChangeNodeAddress(this.setChangeNodeAddress);
            this.pbRichText.Visible = false;
            this.comType.addItems("车牌号码", 0);
            this.comType.addItems("车辆编号", 1);
            this.comType.addItems("车载电话", 2);
            if (Variable.sShippingEnable.Equals("1"))
            {
                this.comType.addItems("运单号码", 3);
                this.tGetShippingTimer = new System.Timers.Timer(300000.0);
                this.tGetShippingTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.tGetShippingTimer_Elapsed);
                this.tGetShippingTimer.Enabled = true;
            }
            this.comType.addItems("驾驶员", 4);
            this.comType.addItems("企业", 5);
            this.comType.addItems("车队", 6);
            this.tPlayAlarmSount = new System.Timers.Timer(1000.0);
            this.tPlayAlarmSount.Elapsed += new System.Timers.ElapsedEventHandler(this.tPlayAlarmSount_Elapsed);
            this.tPlayAlarmSount.Start();
            this.tUpdateCarPlace = new System.Timers.Timer(10000.0);
            this.tUpdateCarPlace.Elapsed += new System.Timers.ElapsedEventHandler(this.tUpdateCarPlace_Elapsed);
            this.tUpdateCarPlace.Start();
            this.setAlarmCarList();
            this.setAreaText();
            this.AddAlerm(null);
            this.AutoCheckAllCar();
        }

        private void CarList_SizeChanged(object sender, EventArgs e)
        {
            if (base.Width < 147)
            {
                this.pnlBtn.Visible = false;
            }
            else
            {
                this.pnlBtn.Location = new Point(base.Width - 24, 0);
                this.pnlBtn.Visible = true;
            }
        }

        private void ChangeNodeAddress()
        {
            try
            {
                base.Invoke(this.myChangeNodeAddress);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("实时更新位置信息", exception.Message);
            }
        }

        private bool chkAllChecked()
        {
            foreach (ThreeStateTreeNode node in this.tvList.SelectedNodes)
            {
                if ((node.CheckState != TriState.Checked) && (node.Tag.Equals("CAR") || ((node.CarCnt != 0) && !this.chkAllSubChecked(node))))
                {
                    return false;
                }
            }
            return true;
        }

        private bool chkAllSubChecked(ThreeStateTreeNode node)
        {
            foreach (ThreeStateTreeNode node2 in node.Nodes)
            {
                if ((node2.CheckState != TriState.Checked) && (node2.Tag.Equals("CAR") || ((node2.CarCnt != 0) && !this.chkAllSubChecked(node2))))
                {
                    return false;
                }
            }
            return true;
        }

        public void CreateCarList(DataTable dtList)
        {
            try
            {
                ThreeStateTreeNode node;
                if (dtList == null)
                {
                    WaitForm.Hide();
                    Record.execFileRecord("CreateCarList", "下载区域信息失败！");
                    return;
                }
                if (this.IsFresh)
                {
                    WaitForm.Show("正在创建车辆列表，请稍候...", this);
                }
                else
                {
                    WaitForm.Show("正在创建车辆列表，请稍候...");
                }
                this.tvList.hasCarPath.Clear();
                this.tvList.hasAreaPath.Clear();
                string key = "";
                string strAreaId = "";
                string str3 = "";
                string str4 = "";
                string sAreaId = "";
                for (int i = 0; i < dtList.Rows.Count; i++)
                {
                    ThreeStateTreeNode node2;
                    key = dtList.Rows[i]["AreaCode"].ToString().Trim();
                    strAreaId = dtList.Rows[i]["AreaId"].ToString().Trim();
                    str3 = dtList.Rows[i]["TotalCount"].ToString().Trim();
                    str4 = dtList.Rows[i]["AreaName"].ToString().Trim();
                    node = new ThreeStateTreeNode(string.Format("{0}(0/{1})", str4, str3))
                    {
                        CarCnt = int.Parse(str3),
                        Name = key,
                        AreaName = str4,
                        Tag = "AREA",
                        NodeIndex = i
                    };
                    if (dtList.Columns.Contains("AreaType"))
                    {
                        node.AreaType = dtList.Rows[i]["AreaType"].ToString().Trim();
                    }
                    node.ContextMenuStrip = this.m_menuList;
                    sAreaId = key;
                    do
                    {
                        sAreaId = sAreaId.Remove(sAreaId.Length - 2);
                        node2 = this.tvList.getAreaById(sAreaId);
                    }
                    while ((node2 == null) && (sAreaId.Length > 1));
                    if (sAreaId.Length == 0)
                    {
                        node.AreaPath = key;
                        this.tvList.hasAreaPath.Add(key, node);
                        this.tvList.Nodes.Add(node);
                    }
                    else
                    {
                        this.tvList.hasAreaPath.Add(key, node);
                        int index = 0;
                        foreach (TreeNode node3 in node2.Nodes)
                        {
                            if (node3.Tag.Equals("AREA"))
                            {
                                index++;
                            }
                        }
                        node2.Nodes.Insert(index, node);
                    }
                    this.setAreaCar(node, strAreaId);
                }
                foreach (TreeNode node4 in this.tvList.Nodes)
                {
                    node4.Expand();
                }
                node = null;
                if (!"1".Equals(Variable.sAllowRefresh))
                {
                    this.tsbRefreshList.Visible = false;
                }
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show("创建车辆列表失败！");
                Record.execFileRecord("CreateCarList", exception.Message);
            }
            WaitForm.Hide();
        }

        public void delCarDetail()
        {
            this.rtxtCarDetail.Text = "";
        }

        private void dgvTrackCar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                string key = this.dgvTrackCar.Rows[e.RowIndex].Cells["CarId"].Value.ToString();
                DataRow row = this.m_dtCarAlermList.Rows.Find(key);
                if (row != null)
                {
                    string alermType = row["statuName"].ToString();
                    string gpsTime = row["ReceTime"].ToString();
                    string longitude = row["Longitude"].ToString();
                    string latitude = row["Latitude"].ToString();
                    new CarAlerm(key, alermType, gpsTime, longitude, latitude).ShowDialog();
                }
            }
        }

        private void dgvTrackCar_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
                {
                    string str = this.dgvTrackCar.Rows[e.RowIndex].Cells["CarNum"].Value.ToString();
                    string str2 = this.dgvTrackCar.Rows[e.RowIndex].Cells["CarId"].Value.ToString();
                    string str3 = this.dgvTrackCar.Rows[e.RowIndex].Cells["SimNum"].Value.ToString();
                    string str4 = this.dgvTrackCar.Rows[e.RowIndex].Cells["statuName"].Value.ToString();
                    string str5 = "车牌:" + str + "\r\n车号:" + str2 + "\r\n电话:" + str3 + "\r\n------------------------------\r\n状态:" + str4;
                    e.ToolTipText = str5;
                }
            }
            catch
            {
            }
        }

        public string execChangeCarValue(int iInType, int iOutType, string sValue)
        {
            try
            {
                DataView view;
                string str = "";
                switch (iInType)
                {
                    case 0:
                        view = new DataView(this.m_dtCarList, string.Format("CarNum='{0}'", sValue), "", DataViewRowState.CurrentRows);
                        break;

                    case 1:
                        view = new DataView(this.m_dtCarList, string.Format("CarID='{0}'", sValue), "", DataViewRowState.CurrentRows);
                        break;

                    case 2:
                        view = new DataView(this.m_dtCarList, string.Format("SimNum='{0}'", sValue), "", DataViewRowState.CurrentRows);
                        break;

                    default:
                        return str;
                }
                switch (iOutType)
                {
                    case 0:
                        return view[0]["CarNum"].ToString();

                    case 1:
                        return view[0]["CarID"].ToString();

                    case 2:
                        return view[0]["SimNum"].ToString();
                }
                return str;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("车辆键值转化", exception.Message);
                return "";
            }
        }

        private void execDownData()
        {
            try
            {
                int count = 0;
                int num3 = int.Parse(Variable.sRecsPerPage);
                while (this.m_bDownResult && ((num3 * this.m_iPagNum) <= this.m_iCarCnt))
                {
                    lock (this.objLock)
                    {
                        this.m_iPagNum++;
                    }
                    int iPagNum = this.m_iPagNum;
                    DataTable table = RemotingClient.Car_GetCarList(iPagNum);
                    if (table == null)
                    {
                        Record.execFileRecord("获取车辆列表失败");
                        this.m_bDownResult = false;
                        return;
                    }
                    count = table.Rows.Count;
                    if (count > 0)
                    {
                        Record.execFileRecord("已下载车辆数据", string.Format("第 {0} 页，车辆数 {1}", iPagNum, count));
                        if (this.m_dtCarList == null)
                        {
                            this.m_dtCarList = table.Clone();
                        }
                        lock (this.m_dtCarList)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                this.m_dtCarList.ImportRow(row);
                            }
                        }
                    }
                    table = null;
                }
            }
            catch (Exception exception)
            {
                this.m_bDownResult = false;
                Record.execFileRecord("下载车辆列表数据", exception.ToString());
            }
        }

        private void execDownShippingData()
        {
            try
            {
                int count = 0;
                int.Parse(Variable.sRecsPerPage);
                string format = "exec WebGpsClient_GetShippingList {0}, {1}, {2}";
                while (this.m_bShippingResult && !this.bShippingEnd)
                {
                    int iPagNum;
                    lock (this.objLock)
                    {
                        this.m_iPagNum++;
                        iPagNum = this.m_iPagNum;
                    }
                    DataTable table = RemotingClient.ExecSql(string.Format(format, Variable.sUserId, iPagNum, Variable.sRecsPerPage));
                    if (table == null)
                    {
                        Record.execFileRecord("获取订单列表失败");
                        this.m_bShippingResult = false;
                        return;
                    }
                    count = table.Rows.Count;
                    if (count > 0)
                    {
                        Record.execFileRecord("已订单车辆数据", string.Format("第 {0} 页，订单数 {1}", iPagNum, count));
                        if (this.m_dtShippingListTemp == null)
                        {
                            this.m_dtShippingListTemp = table.Clone();
                            this.m_dtShippingListTemp.PrimaryKey = new DataColumn[] { this.m_dtShippingListTemp.Columns["WaybillCode"] };
                        }
                        lock (this.m_dtShippingListTemp)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                this.m_dtShippingListTemp.ImportRow(row);
                            }
                            goto Label_015C;
                        }
                    }
                    this.bShippingEnd = true;
                Label_015C:
                    table = null;
                }
            }
            catch (Exception exception)
            {
                this.m_bShippingResult = false;
                Record.execFileRecord("下载订单列表数据", exception.ToString());
            }
        }

        private void execSearchAlarmCar()
        {
            try
            {
                string searchkey = "";
                string str2 = this.txtCarNo.Text.Trim();
                if ((str2.Length == 0) || (this.m_dtCarAlermList == null))
                {
                    this.txtCarNo.Focus();
                }
                else
                {
                    if ("0".Equals(this.comType.SelectedValue.ToString()))
                    {
                        searchkey = "CarNum like '%" + str2 + "%'";
                    }
                    if ("1".Equals(this.comType.SelectedValue.ToString()))
                    {
                        searchkey = "CarId = " + str2;
                    }
                    if ("2".Equals(this.comType.SelectedValue.ToString()))
                    {
                        searchkey = "SimNum like '%" + str2 + "%'";
                    }
                    else if ("4".Equals(this.comType.SelectedValue.ToString()))
                    {
                        searchkey = "DriverName like '%" + str2 + "%'";
                        this.searchTrackCarByDriver(searchkey);
                        return;
                    }
                    DataView view = new DataView(this.m_dtCarAlermList, searchkey, "CarNum", DataViewRowState.CurrentRows);
                    if (view.Count == 0)
                    {
                        this.txtCarNo.Focus();
                    }
                    else
                    {
                        view[0]["CarNum"].ToString();
                        int nodeIndex = -1;
                        if (this.tvTrackCar.CurrentNode != null)
                        {
                            nodeIndex = ((ThreeStateTreeNode)this.tvTrackCar.CurrentNode).NodeIndex;
                        }
                        ThreeStateTreeNode node = new ThreeStateTreeNode();
                        bool flag = false;
                        foreach (DataRowView view2 in view)
                        {
                            string sCarId = view2["CarId"].ToString();
                            ThreeStateTreeNode node2 = this.tvTrackCar.getNodeById(sCarId);
                            if ((node2 != null) && (node2.NodeIndex > nodeIndex))
                            {
                                node = node2;
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            string str4 = view[0]["CarId"].ToString();
                            ThreeStateTreeNode node3 = this.tvTrackCar.getNodeById(str4);
                            if (node3 == null)
                            {
                                this.txtCarNo.Focus();
                                return;
                            }
                            node = node3;
                        }
                        this.tvTrackCar.setSelectNode(node);
                        node.EnsureVisible();
                        this.tvTrackCar.Focus();
                        view = null;
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("查询报警车辆", exception.Message);
            }
        }

        private void execSearchCar()
        {
            try
            {
                string rowFilter = "";
                string sValue = this.txtCarNo.Text.Trim();
                if (sValue.Length == 0)
                {
                    this.txtCarNo.Focus();
                }
                else
                {
                    sValue = Check.ValueReplace(sValue);
                    if ("0".Equals(this.comType.SelectedValue.ToString()))
                    {
                        rowFilter = "CarNum like '%" + sValue + "%'";
                    }
                    else if ("1".Equals(this.comType.SelectedValue.ToString()))
                    {
                        rowFilter = "CarId = " + sValue;
                    }
                    else if ("2".Equals(this.comType.SelectedValue.ToString()))
                    {
                        rowFilter = "SimNum like '%" + sValue + "%'";
                    }
                    else if ("3".Equals(this.comType.SelectedValue.ToString()) && (this.m_dtShippingList != null))
                    {
                        rowFilter = "WaybillCode like '%" + sValue + "%'";
                        DataView view = new DataView(this.m_dtShippingList, rowFilter, "", DataViewRowState.CurrentRows);
                        if (view.Count == 0)
                        {
                            this.txtCarNo.Focus();
                            return;
                        }
                        string str3 = view[0]["CarId"].ToString();
                        rowFilter = "CarId = " + str3;
                    }
                    else if (this.m_dtCarList.Columns.Contains("DriverName") && "4".Equals(this.comType.SelectedValue.ToString()))
                    {
                        rowFilter = "DriverName like '%" + sValue + "%'";
                    }
                    else
                    {
                        if ("5".Equals(this.comType.SelectedValue.ToString()) || "6".Equals(this.comType.SelectedValue.ToString()))
                        {
                            string str4 = "5".Equals(this.comType.SelectedValue.ToString()) ? "2" : "3";
                            rowFilter = "AreaName like '%" + sValue + "%' and AreaType = '" + str4 + "' ";
                            DataView view2 = new DataView(this.m_dtAllAreaList, rowFilter, "AreaCode", DataViewRowState.CurrentRows);
                            if (view2.Count == 0)
                            {
                                this.txtCarNo.Focus();
                                return;
                            }
                            int nodeIndex = -1;
                            if (this.tvList.CurrentNode != null)
                            {
                                nodeIndex = ((ThreeStateTreeNode)this.tvList.CurrentNode).NodeIndex;
                            }
                            ThreeStateTreeNode node = new ThreeStateTreeNode();
                            bool flag = false;
                            foreach (DataRowView view3 in view2)
                            {
                                string sAreaId = view3["AreaCode"].ToString();
                                ThreeStateTreeNode node2 = this.tvList.getAreaById(sAreaId);
                                if ((node2 != null) && (node2.NodeIndex > nodeIndex))
                                {
                                    node = node2;
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                string str6 = view2[0]["AreaCode"].ToString();
                                ThreeStateTreeNode node3 = this.tvList.getAreaById(str6);
                                if (node3 == null)
                                {
                                    this.txtCarNo.Focus();
                                    return;
                                }
                                node = node3;
                            }
                            this.tvList.setSelectNode(node);
                            this.tvList.setMulSelectNodes(node);
                            node.EnsureVisible();
                            this.tvList.Focus();
                        }
                        return;
                    }
                    DataView view4 = new DataView(this.m_dtCarList, rowFilter, "AreaCode,CarNum", DataViewRowState.CurrentRows);
                    if (view4.Count == 0)
                    {
                        this.txtCarNo.Focus();
                    }
                    else
                    {
                        view4[0]["CarNum"].ToString();
                        int num2 = -1;
                        if (this.tvList.CurrentNode != null)
                        {
                            num2 = ((ThreeStateTreeNode)this.tvList.CurrentNode).NodeIndex;
                        }
                        ThreeStateTreeNode node4 = new ThreeStateTreeNode();
                        bool flag2 = false;
                        foreach (DataRowView view5 in view4)
                        {
                            string sCarId = view5["CarId"].ToString();
                            ThreeStateTreeNode node5 = this.tvList.getNodeById(sCarId);
                            if ((node5 != null) && (node5.NodeIndex > num2))
                            {
                                node4 = node5;
                                flag2 = true;
                                break;
                            }
                        }
                        if (!flag2)
                        {
                            string str8 = view4[0]["CarId"].ToString();
                            ThreeStateTreeNode node6 = this.tvList.getNodeById(str8);
                            if (node6 == null)
                            {
                                this.txtCarNo.Focus();
                                return;
                            }
                            node4 = node6;
                        }
                        this.tvList.setSelectNode(node4);
                        if (this.pbRichText.Visible)
                        {
                            MainForm.myMap.excuteSpatialQueryById(node4.CarId, node4.Longitude, node4.Latitude);
                            this.ShowCarDetail(node4);
                        }
                        node4.EnsureVisible();
                        this.tvList.Focus();
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("查询车辆", exception.Message);
            }
        }

        private static int execSetWatchCar(object oParam)
        {
            object[] objArray = (object[])oParam;
            return RemotingClient.Car_WatchCar(objArray[0].ToString(), bool.Parse(objArray[1].ToString()), bool.Parse(objArray[2].ToString()));
        }

        private void execWriteAlarmLog(DataTable dt)
        {
            StringBuilder builder = new StringBuilder("报警日志\r\n");
            try
            {
                string str = DateTime.Now.ToString();
                foreach (DataRow row in dt.Rows)
                {
                    builder.Append(string.Format("[{0}]    {1}\r\n", str, row["statuDesc"].ToString()));
                }
                Record.execFileAlarmRecord(builder.ToString());
            }
            catch (Exception exception)
            {
                Record.execFileRecord("报警处理", exception.Message);
            }
            dt = null;
            builder = null;
        }

        public void getAlermList()
        {
            DataTable dtLogResult = RemotingClient.CarDataInfoBuffer_GetArarmCarList();
            if (dtLogResult == null)
            {
                this.m_dtCarAlermList = dtLogResult;
            }
            else
            {
                foreach (DataRow row in dtLogResult.Rows)
                {
                    row["carStatus"] = "1";
                }
                MainForm.myLogForms.myAlarmLog.addLogMsg(dtLogResult);
                this.m_dtCarAlermList = dtLogResult;
                this.execWriteAlarmLog(this.m_dtCarAlermList);
                this.m_dtCarAlermList.PrimaryKey = new DataColumn[] { this.m_dtCarAlermList.Columns["CarId"] };
            }
        }

        public DataTable GetAllArea()
        {
            DataRow row;
            DataTable dtAllArea = new DataTable();
            dtAllArea.Columns.Add(new DataColumn("AreaName"));
            dtAllArea.Columns.Add(new DataColumn("AreaCode"));
            foreach (ThreeStateTreeNode node in this.tvList.Nodes)
            {
                if (!node.Tag.Equals("CAR"))
                {
                    row = dtAllArea.NewRow();
                    row["AreaName"] = node.AreaName;
                    row["AreaCode"] = node.Name;
                    dtAllArea.Rows.Add(row);
                    this.GetChildAreaValue(node, ref dtAllArea);
                }
            }
            row = null;
            return dtAllArea;
        }

        public DataTable GetAllCar()
        {
            DataRow row;
            DataTable dtAllCar = new DataTable();
            dtAllCar.Columns.Add(new DataColumn("CarNum"));
            dtAllCar.Columns.Add(new DataColumn("SimNum"));
            dtAllCar.Columns.Add(new DataColumn("CarId"));
            foreach (ThreeStateTreeNode node in this.tvList.Nodes)
            {
                if (node.Tag.Equals("CAR"))
                {
                    row = dtAllCar.NewRow();
                    row["CarNum"] = node.CarNum;
                    row["SimNum"] = node.SimNum;
                    row["CarId"] = node.CarId;
                    dtAllCar.Rows.Add(row);
                }
                else
                {
                    this.GetChildValue(node, ref dtAllCar);
                }
            }
            row = null;
            return dtAllCar;
        }

        public DataTable getAreaList()
        {
            DataTable table = new DataTable();
            try
            {
                this.m_bDownResult = false;
                if (this.IsFresh)
                {
                    base.Invoke(this.mySetShowTipText, new object[] { "正在下载区域信息，请稍候..." });
                }
                else
                {
                    WaitForm.Show("正在下载区域信息，请稍候...");
                }
                table = this.m_dtAllAreaList = RemotingClient.Area_getAreaInfoAll();
                if (table == null)
                {
                    WaitForm.Hide();
                    MessageBox.Show("获取区域信息失败！");
                    Record.execFileRecord("获取区域信息失败");
                    return null;
                }
                if (table.Rows.Count == 0)
                {
                    return null;
                }
                return table;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("下载区域列表", exception.ToString());
                return null;
            }
        }

        public string getCaridByWaybillCode(ref string sValueList)
        {
            string str = "";
            try
            {
                foreach (string str2 in sValueList.Split(new char[] { ',' }))
                {
                    DataRow row = this.m_dtShippingList.Rows.Find(str2);
                    if (row == null)
                    {
                        return string.Format("目标运单：{0}，不存在。", str2);
                    }
                    string str3 = row["CarId"].ToString();
                    if ((str.IndexOf(str3 + ",") != 0) && (str.IndexOf("," + str3 + ",") <= 0))
                    {
                        str = str + str3 + ",";
                    }
                }
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            sValueList = str.Trim(new char[] { ',' });
            return "";
        }

        public DataTable getCarList(DataTable dtList)
        {
            if (dtList == null)
            {
                WaitForm.Hide();
                return dtList;
            }
            try
            {
                this.m_iCarCnt = int.Parse(dtList.Rows[0]["TotalCount"].ToString());
                this.m_iPagNum = 0;
                this.m_dtCarList = null;
                if (this.IsFresh)
                {
                    base.Invoke(this.mySetShowTipText, new object[] { "正在下载车辆列表，请稍候..." });
                }
                else
                {
                    WaitForm.Show("正在下载车辆列表，请稍候...");
                }
                if (!this.GetCarList())
                {
                    WaitForm.Hide();
                    MessageBox.Show("获取车辆列表失败！");
                    return null;
                }
                if (this.m_dtCarList == null)
                {
                    return null;
                }
                this.m_dtCarList.PrimaryKey = new DataColumn[] { this.m_dtCarList.Columns["CarId"] };
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置区域列表", exception.ToString());
            }
            return dtList;
        }

        private bool GetCarList()
        {
            this.m_bDownResult = true;
            Record.execFileRecord("开始下载车辆列表", string.Format("每页 {0} 条记录", Variable.sRecsPerPage));
            Thread thread = new Thread(new ThreadStart(this.execDownData));
            Thread thread2 = new Thread(new ThreadStart(this.execDownData));
            Thread thread3 = new Thread(new ThreadStart(this.execDownData));
            Thread thread4 = new Thread(new ThreadStart(this.execDownData));
            Thread thread5 = new Thread(new ThreadStart(this.execDownData));
            thread.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            do
            {
                Thread.Sleep(500);
                if (!this.m_bDownResult)
                {
                    return this.m_bDownResult;
                }
            }
            while (((thread.IsAlive || thread2.IsAlive) || (thread3.IsAlive || thread4.IsAlive)) || thread5.IsAlive);
            return this.m_bDownResult;
        }

        public string getCarType(string sCarId)
        {
            ThreeStateTreeNode node = this.tvList.getNodeById(sCarId);
            if (node == null)
            {
                return string.Empty;
            }
            return node.TerminalType;
        }

        public string getCheckedCar()
        {
            string str = "";
            try
            {
                foreach (ThreeStateTreeNode node in MainForm.myCarList.tvList.Nodes)
                {
                    if ((node.Tag != null) && node.Tag.Equals("CAR"))
                    {
                        if (node.Checked)
                        {
                            str = str + node.CarId + ",";
                        }
                    }
                    else
                    {
                        str = str + this.getSubCheckCar(node);
                    }
                }
            }
            catch
            {
            }
            return str.Trim(new char[] { ',' });
        }

        private void GetChildAreaValue(ThreeStateTreeNode node, ref DataTable dtAllArea)
        {
            DataRow row;
            foreach (ThreeStateTreeNode node2 in node.Nodes)
            {
                if (!node2.Tag.Equals("CAR"))
                {
                    row = dtAllArea.NewRow();
                    row["AreaName"] = node2.AreaName;
                    row["AreaCode"] = node2.Name;
                    dtAllArea.Rows.Add(row);
                    this.GetChildAreaValue(node2, ref dtAllArea);
                }
            }
            row = null;
        }

        private void GetChildValue(ThreeStateTreeNode node, ref DataTable dtAllCar)
        {
            DataRow row;
            foreach (ThreeStateTreeNode node2 in node.Nodes)
            {
                if (node2.Tag.Equals("CAR"))
                {
                    row = dtAllCar.NewRow();
                    row["CarNum"] = node2.CarNum;
                    row["SimNum"] = node2.SimNum;
                    row["CarId"] = node2.CarId;
                    dtAllCar.Rows.Add(row);
                }
                else
                {
                    this.GetChildValue(node2, ref dtAllCar);
                }
            }
            row = null;
        }

        private void GetChildValue(string sGetType, ThreeStateTreeNode node, ref string sCarValues)
        {
            foreach (ThreeStateTreeNode node2 in node.Nodes)
            {
                if (!node2.Tag.Equals("CAR"))
                {
                    this.GetChildValue(sGetType, node2, ref sCarValues);
                    continue;
                }
                string str = "";
                string str2 = sGetType;
                if (str2 != null)
                {
                    if (!(str2 == "CarNum"))
                    {
                        if (str2 == "CarId")
                        {
                            str = str + node2.CarId + ",";
                        }
                        if (str2 == "SimNum")
                        {
                            str = str + node2.SimNum + ",";
                        }
                    }
                    else
                    {
                        str = str + node2.CarNum + ",";
                    }
                }
                sCarValues = sCarValues + str;
            }
        }

        private string GetSelectedCarValue(string sGetType)
        {
            string selectedCarValue = "";
            if (this.tvTrackCar.Visible)
            {
                selectedCarValue = this.GetSelectedCarValue(sGetType, this.tvTrackCar);
                if (selectedCarValue.Trim().Length == 0)
                {
                    selectedCarValue = this.GetSelectedCarValue(sGetType, this.tvList);
                }
            }
            else
            {
                selectedCarValue = this.GetSelectedCarValue(sGetType, this.tvList);
            }
            return selectedCarValue.Trim(new char[] { ',' });
        }

        private string GetSelectedCarValue(string sGetType, ThreeStateTreeView tvThreeState)
        {
            string sCarValues = "";
            foreach (ThreeStateTreeNode node in tvThreeState.SelectedNodes)
            {
                TreeNode item = node;
                bool flag = false;
                while (item.Parent != null)
                {
                    item = item.Parent;
                    if (tvThreeState.SelectedNodes.Contains(item))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }
                if (!node.Tag.Equals("CAR"))
                {
                    this.GetChildValue(sGetType, node, ref sCarValues);
                    continue;
                }
                string str2 = "";
                string str3 = sGetType;
                if (str3 != null)
                {
                    if (!(str3 == "CarNum"))
                    {
                        if (str3 == "CarId")
                        {
                            str2 = node.CarId + ",";
                        }
                        if (str3 == "SimNum")
                        {
                            str2 = node.SimNum + ",";
                        }
                    }
                    else
                    {
                        str2 = node.CarNum + ",";
                    }
                }
                sCarValues = sCarValues + str2;
                continue;

            }
            return sCarValues.Trim(new char[] { ',' });
        }

        public int getSelectedCnt()
        {
            int num = 0;
            ThreeStateTreeNode item = null;
            bool flag = false;
            foreach (ThreeStateTreeNode node2 in this.tvList.SelectedNodes)
            {
                flag = false;
                item = node2;
                while (item.Parent != null)
                {
                    item = item.Parent as ThreeStateTreeNode;
                    if ((item != null) && this.tvList.SelectedNodes.Contains(item))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    if (node2.Tag.Equals("CAR"))
                    {
                        num++;
                    }
                    else
                    {
                        num += node2.CarCnt;
                    }
                }
            }
            return num;
        }

        public bool GetShippingList()
        {
            this.m_iPagNum = 0;
            this.m_bShippingResult = true;
            this.bShippingEnd = false;
            this.m_dtShippingListTemp = null;
            Record.execFileRecord("开始下载订单列表", string.Format("每页 {0} 条记录", Variable.sRecsPerPage));
            Thread thread = new Thread(new ThreadStart(this.execDownShippingData));
            Thread thread2 = new Thread(new ThreadStart(this.execDownShippingData));
            Thread thread3 = new Thread(new ThreadStart(this.execDownShippingData));
            Thread thread4 = new Thread(new ThreadStart(this.execDownShippingData));
            Thread thread5 = new Thread(new ThreadStart(this.execDownShippingData));
            thread.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            do
            {
                Thread.Sleep(500);
                if (!this.m_bShippingResult)
                {
                    return this.m_bShippingResult;
                }
            }
            while (((thread.IsAlive || thread2.IsAlive) || (thread3.IsAlive || thread4.IsAlive)) || thread5.IsAlive);
            try
            {
                this.m_dtShippingList = this.m_dtShippingListTemp;
            }
            catch
            {
            }
            return this.m_bShippingResult;
        }

        private string getSubCheckCar(ThreeStateTreeNode tn)
        {
            string str = "";
            try
            {
                foreach (ThreeStateTreeNode node in tn.Nodes)
                {
                    if ((node.Tag != null) && node.Tag.Equals("CAR"))
                    {
                        if (node.Checked)
                        {
                            str = str + node.CarId + ",";
                        }
                    }
                    else
                    {
                        str = str + this.getSubCheckCar(node);
                    }
                }
            }
            catch
            {
            }
            return str;
        }

        public ThreeStateTreeNode GetTreeNodeOfCar(string carid)
        {
            if (this.tvList.hasCarPath.ContainsKey(carid))
            {
                return (this.tvList.hasCarPath[carid] as ThreeStateTreeNode);
            }
            return null;
        }

        private string getWaybillCodeList(ThreeStateTreeNode tn)
        {
            string str = "";
            if (Variable.sShippingEnable.Equals("1") && (this.m_dtShippingList != null))
            {
                try
                {
                    DataView view = new DataView(this.m_dtShippingList, string.Format("SimNum={0}", tn.SimNum), "WaybillCode", DataViewRowState.CurrentRows);
                    if (view.Count <= 0)
                    {
                        return str;
                    }
                    str = "\r\n------------------------------------";
                    str = str + string.Format("\r\n运单列表：{0}：{1}-->{2}", view[0]["WaybillCode"].ToString(), view[0]["ShippingLocation"].ToString(), view[0]["Destination"].ToString());
                    for (int i = 1; i < view.Count; i++)
                    {
                        str = str + string.Format("\r\n          {0}：{1}-->{2}", view[i]["WaybillCode"].ToString(), view[i]["ShippingLocation"].ToString(), view[i]["Destination"].ToString());
                    }
                }
                catch
                {
                }
            }
            return str;
        }

        private void OpenAlarmWindow()
        {
            try
            {
                if (Variable.sAlarmPopupWindow.Equals("1") && ((this._弹出警报窗口 == null) || !this._弹出警报窗口.IsHandleCreated))
                {
                    TreeNode node = null;
                    for (int i = 0; i < this.tvTrackCar.Nodes[0].Nodes.Count; i++)
                    {
                        if (this.tvTrackCar.Nodes[0].Nodes[i].ForeColor == Color.Red)
                        {
                            this.tvTrackCar.Nodes[0].Expand();
                            node = this.tvTrackCar.Nodes[0].Nodes[i];
                            break;
                        }
                    }
                    if (node != null)
                    {
                        DataRow row = this.m_dtCarAlermList.Rows.Find(node.Name);
                        if (row != null)
                        {
                            string alermType = row["statuName"].ToString();
                            string gpsTime = row["ReceTime"].ToString();
                            string longitude = row["Longitude"].ToString();
                            string latitude = row["Latitude"].ToString();
                            if ((this._弹出警报窗口 == null) || !this._弹出警报窗口.IsHandleCreated)
                            {
                                this._弹出警报窗口 = new CarAlarmEx(node.Name, alermType, gpsTime, longitude, latitude);
                                this._弹出警报窗口.StartPosition = FormStartPosition.CenterScreen;
                                this._弹出警报窗口.Show(Program.mainForm);
                                this.setNodeFontDefault(node as ThreeStateTreeNode);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("打开车辆警报弹出窗口(CarList)==>", exception.Message);
            }
        }

        public void RefreshSetWatchCar()
        {
            try
            {
                foreach (TreeNode node in this.tvList.Nodes)
                {
                    ThreeStateTreeNode node2 = node as ThreeStateTreeNode;
                    if (node2 != null)
                    {
                        execSetWatchCar(new object[] { node2.Name, !node2.Tag.Equals("CAR"), false });
                    }
                }
            }
            catch
            {
            }
        }

        public void resetAlermList()
        {
            try
            {
                DataTable dtCarList = RemotingClient.CarDataInfoBuffer_GetArarmCarList();
                this.tsbAlarmAffirm.Image = Resources.AlarmCancel;
                this.iTipCount = int.Parse(Variable.sGetNodeTipShowType);
                if (this.tvTrackCar != null)
                {
                    this.tvTrackCar.Nodes.Clear();
                    this.tvTrackCar.hasCarPath.Clear();
                }
                if (this.m_dtCarAlermList != null)
                {
                    this.m_dtCarAlermList.Clear();
                }
                WaitForm.Hide();
                if ((dtCarList == null) || (dtCarList.Rows.Count == 0))
                {
                    this.AddAlerm(null);
                }
                else
                {
                    this.IsPlayAlarmSound = true;
                    this.tPlayAlarmSount.Enabled = true;
                    foreach (DataRow row in dtCarList.Rows)
                    {
                        row["carStatus"] = "1";
                        this.AddAlermList(row["CarId"].ToString(), row);
                        this.AddAlerm(row);
                    }
                    AlarmSound.GetInstance().IsCustomAlarmSound(this.m_dtCarAlermList);
                    MainForm.myMap.setShowCar(dtCarList, true);
                    dtCarList = null;
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("重置报警列表", exception.ToString());
            }
        }

        private bool searchTrackCarByDriver(string searchkey)
        {
            try
            {
                DataView view = new DataView(this.m_dtCarList, searchkey, "AreaCode,CarNum", DataViewRowState.CurrentRows);
                if (view.Count == 0)
                {
                    this.txtCarNo.Focus();
                    return false;
                }
                view[0]["CarNum"].ToString();
                int nodeIndex = -1;
                if (this.tvTrackCar.CurrentNode != null)
                {
                    nodeIndex = ((ThreeStateTreeNode)this.tvTrackCar.CurrentNode).NodeIndex;
                }
                ThreeStateTreeNode node = new ThreeStateTreeNode();
                bool flag = false;
                foreach (DataRowView view2 in view)
                {
                    string sCarId = view2["CarId"].ToString();
                    ThreeStateTreeNode node2 = this.tvTrackCar.getNodeById(sCarId);
                    if ((node2 != null) && (node2.NodeIndex > nodeIndex))
                    {
                        node = node2;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    string str2 = view[0]["CarId"].ToString();
                    ThreeStateTreeNode node3 = this.tvTrackCar.getNodeById(str2);
                    if (node3 == null)
                    {
                        this.txtCarNo.Focus();
                        return false;
                    }
                    node = node3;
                }
                this.tvTrackCar.setSelectNode(node);
                node.EnsureVisible();
                this.tvTrackCar.Focus();
                view = null;
            }
            catch
            {
            }
            return true;
        }

        public void setAlarm(DataTable dtAlarm)
        {
            try
            {
                tSetOnline = new Thread(new ParameterizedThreadStart(this.setCarAlarm));
                tSetOnline.Start(dtAlarm.Copy());
            }
            catch (Exception exception)
            {
                Record.execFileRecord("报警处理", exception.Message);
            }
        }

        public void setAlarmCarList()
        {
            if (this.m_dtCarAlermList != null)
            {
                try
                {
                    DataTable table = this.m_dtCarAlermList.Copy();
                    string sCarId = "";
                    ThreeStateTreeNode myNode = null;
                    foreach (DataRow row in table.Rows)
                    {
                        sCarId = row["CarId"].ToString();
                        myNode = this.tvList.getNodeById(sCarId);
                        if (myNode != null)
                        {
                            bool flag = false;
                            if ("1".Equals(row["AccOn"].ToString()))
                            {
                                flag = true;
                            }
                            if (flag)
                            {
                                myNode.CarStatus = ThreeStateTreeNode.sAlarm;
                            }
                            else
                            {
                                myNode.CarStatus = m_sStopAlarmKey;
                            }
                            myNode.IsAlarm = true;
                            this.setNodeValue(myNode, row);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("刷新列表时设置报警车辆", exception.Message);
                }
            }
        }

        public void setAllCarOffline()
        {
            foreach (TreeNode node in this.tvList.Nodes)
            {
                if (node.Tag.Equals("CAR"))
                {
                    ThreeStateTreeNode node2 = node as ThreeStateTreeNode;
                    if (!node2.IsAlarm)
                    {
                        node2.CarStatus = ThreeStateTreeNode.sOffLine;
                        node2 = null;
                    }
                }
                else
                {
                    this.setCarOffline(node);
                }
            }
            this.setAreaText();
        }

        private void setAMenuEnable()
        {
            if (!string.IsNullOrEmpty(this.tvTrackCar.SelectedNode.Name) && (this.m_menuList != null))
            {
                ThreeStateTreeNode node = this.tvList.getNodeById(this.tvTrackCar.SelectedNode.Name);
                if (node != null)
                {
                    this.tvList.setSelectNode(node);
                    int num = this.getSelectedCnt();
                    if ((num > int.Parse(Variable.sMaxSendCount)) || (num <= 0))
                    {
                        this.m_menuList.Enabled = false;
                    }
                    else
                    {
                        if ((num > 1) || ((this.tvList.SelectedNode.Tag != null) && "AREA".Equals(this.tvList.SelectedNode.Tag.ToString())))
                        {
                            this.m_menuList.Enabled = true;
                            this.m_menuList.Items["MenuItemRealTimePlace"].Enabled = false;
                            this.m_menuList.Items["MenuItemTrain"].Enabled = false;
                            this.m_menuList.Items["MenuItemContrailReturn"].Enabled = false;
                            this.m_menuList.Items["MenuItemAreaAlarm"].Enabled = false;
                            this.m_menuList.Items["MenuItemVersatileAlarm"].Enabled = false;
                            this.m_menuList.Items["MenuItemRunAlarm"].Enabled = false;
                            this.m_menuList.Items["MenuItemOilAlarm"].Enabled = false;
                            this.m_menuList.Items["MenuItemTemperatureAlarm"].Enabled = false;
                            this.m_menuList.Items["MenuItemTradeApp"].Enabled = false;
                            this.m_menuList.Items["MenuItemClearCarContrail"].Enabled = false;
                            this.m_menuList.Items["MenuItemAttribute"].Enabled = false;
                        }
                        else
                        {
                            this.m_menuList.Enabled = true;
                            this.m_menuList.Items["MenuItemRealTimePlace"].Enabled = true;
                            this.m_menuList.Items["MenuItemTrain"].Enabled = true;
                            this.m_menuList.Items["MenuItemContrailReturn"].Enabled = true;
                            this.m_menuList.Items["MenuItemAreaAlarm"].Enabled = true;
                            this.m_menuList.Items["MenuItemVersatileAlarm"].Enabled = true;
                            this.m_menuList.Items["MenuItemRunAlarm"].Enabled = true;
                            this.m_menuList.Items["MenuItemOilAlarm"].Enabled = true;
                            this.m_menuList.Items["MenuItemTemperatureAlarm"].Enabled = true;
                            this.m_menuList.Items["MenuItemTradeApp"].Enabled = true;
                            this.m_menuList.Items["MenuItemClearCarContrail"].Enabled = true;
                            this.m_menuList.Items["MenuItemAttribute"].Enabled = true;
                        }
                        if ((num > int.Parse(Variable.sImportCarMax)) || !this.chkAllChecked())
                        {
                            this.m_menuList.Items["MenuItemStressWatch"].Enabled = false;
                        }
                        else
                        {
                            this.m_menuList.Items["MenuItemStressWatch"].Enabled = true;
                        }
                        foreach (object obj2 in this.m_menuList.Items)
                        {
                            if (obj2.GetType() == typeof(ToolStripMenuItem))
                            {
                                if (!((ToolStripMenuItem)obj2).Enabled)
                                {
                                    foreach (ToolStripItem item in ((ToolStripMenuItem)obj2).DropDownItems)
                                    {
                                        item.Visible = false;
                                    }
                                }
                                else
                                {
                                    ((MainForm)base.ParentForm).setMenuVisible((ToolStripMenuItem)obj2);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void setAreaCar(ThreeStateTreeNode myNode, string strAreaId)
        {
            ThreeStateTreeNode node;
            string text = "";
            string key = "";
            string str3 = "";
            DataView view = new DataView(this.m_dtCarList, "AreaId='" + strAreaId + "'", "CarNum", DataViewRowState.CurrentRows);
            for (int i = 0; i < view.Count; i++)
            {
                text = view[i]["CarNum"].ToString();
                key = view[i]["CarId"].ToString();
                str3 = view[i]["SimNum"].ToString();

                string showCarNum = string.Empty;
                if (!Variable.sJGShowCar.Equals("0"))
                {
                    string reg = "[\u4e00-\u9fa5][A-Z][A-Z0-9]{5}$";
                    if (Variable.sJGShowCar.Equals("1"))
                    {
                        showCarNum = new Regex(reg).Replace(view[i]["CarNum"].ToString(), "").Trim(new char[] { ' ', '-' });
                    }
                    else
                    {
                        showCarNum = new Regex(reg).Match(view[i]["CarNum"].ToString()).Value;
                    }
                }
                if (string.IsNullOrEmpty(showCarNum))
                {
                    showCarNum = view[i]["CarNum"].ToString();
                }

                node = new ThreeStateTreeNode(text)
                {
                    Tag = "CAR",
                    Name = key,
                    SimNum = str3,
                    CarId = key,
                    CarAreaName = myNode.AreaName,
                    ImageKey = m_sOffLineKey,
                    SelectedImageKey = m_sOffLineKey,
                    EndTime = view[i]["SvrEndTime"].ToString(),
                    CarType = view[i]["CarTypeName"].ToString(),
                    CarColor = view[i]["CarColor"].ToString(),
                    CarPName = view[i]["OwnerName"].ToString(),
                    CarPTel = view[i]["OwnerSimNum"].ToString(),
                    CarEmail = view[i]["OwnerEmail"].ToString(),
                    WordCompany = view[i]["CorpName"].ToString(),
                    CarPID = view[i]["PersonID"].ToString(),
                    FirstName = view[i]["FirstConnectorName"].ToString(),
                    FirstTel = view[i]["FirstConnectTele"].ToString(),
                    SecondName = view[i]["ConnectorName"].ToString(),
                    SecondTel = view[i]["ConnectTele"].ToString(),
                    Text = showCarNum
                };
                if (view.Table.Columns.Contains("TerminalType"))
                {
                    node.TerminalType = view[i]["TerminalType"].ToString();
                }
                node.ReceTime = view[i]["ReceTime"].ToString();
                node.GpsTime = view[i]["GpsTime"].ToString();
                node.Longitude = view[i]["Longitude"].ToString();
                node.Latitude = view[i]["Latitude"].ToString();
                node.Direction = view[i]["Direct"].ToString();
                node.Speed = view[i]["Speed"].ToString();
                node.ALLDiff = view[i]["DistanceDiff"].ToString();
                if (view.Table.Columns.Contains("DriverName"))
                {
                    node.DriverCode = view[i]["DriverCode"].ToString();
                    node.DriverName = view[i]["DriverName"].ToString();
                }
                if (view.Table.Columns.Contains("Altitude"))
                {
                    node.Altitude = view[i]["Altitude"].ToString();
                }
                if (view.Table.Columns.Contains("AreaType"))
                {
                    node.AreaType = view[i]["AreaType"].ToString();
                }
                if (view.Table.Columns.Contains("PlateColor"))
                {
                    node.PlateColor = view[i]["PlateColor"].ToString();
                }
                if (view.Table.Columns.Contains("Company"))
                {
                    node.Company = view[i]["Company"].ToString();
                }
                if (view.Table.Columns.Contains("TermSerial"))
                {
                    node.TermSerial = view[i]["TermSerial"].ToString();
                }
                if (view.Table.Columns.Contains("TransportStatu"))
                {
                    node.TransportStatu = view[i]["TransportStatu"].ToString();
                }
                node.NodeIndex = this.iIndex;
                this.iIndex++;
                node.ContextMenuStrip = this.m_menuList;
                this.setCarTipShowType(node);
                this.tvList.hasCarPath.Add(key, node);
                myNode.Nodes.Add(node);
            }
            node = null;
        }

        public void setAreaText()
        {
            if (this.tvList.areaNodeHashTable.Count != 0)
            {
                try
                {
                    ThreeStateTreeNode[] array = new ThreeStateTreeNode[this.tvList.areaNodeHashTable.Count];
                    this.tvList.areaNodeHashTable.Values.CopyTo(array, 0);
                    foreach (ThreeStateTreeNode node in array)
                    {
                        base.Invoke(this.mySetAreaText, new object[] { node });
                    }
                    array = null;
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("统计在线车辆并刷新树节点文本", exception.Message);
                }
            }
        }

        public void setCancelAlarm(string sCarId, bool bAccOn)
        {
            try
            {
                ThreeStateTreeNode node = this.tvList.getNodeById(sCarId);
                if (node.IsAlarm)
                {
                    string sImage = bAccOn ? m_sOnLineKey : m_sStopOnLineKey;
                    if (node.GetIsFill)
                    {
                        sImage = bAccOn ? m_sFillKey : m_sStopFillKey;
                    }
                    this.setCarImag(sCarId, sImage);
                }
            }
            catch
            {
            }
        }

        public void setCarAlarm(object obj)
        {
            ThreeStateTreeNode nodeById;
            DataTable dataTable = obj as DataTable;
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return;
            }
            this.execWriteAlarmLog(dataTable);
            int num = 1;
            try
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        MainForm.sAlarmShowCnt = num.ToString();
                        num++;
                        nodeById = this.tvList.getNodeById(row["CarId"].ToString());
                        if (nodeById == null)
                        {
                            continue;
                        }
                        this.setCarStatus(nodeById, row, true);
                        this.setNodeValue(nodeById, row);
                    }
                    nodeById = null;
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("设置报警车辆（集合）2", exception.StackTrace);
                }
            }
            finally
            {
                dataTable.Clear();
                dataTable = null;
                nodeById = null;
            }
            this.setAreaText();
        }

        public int setCarChecked(string sCarNum, bool bChecked)
        {
            int num = -1;
            DataView view = new DataView(this.m_dtCarList, "CarNum='" + sCarNum + "'", "", DataViewRowState.CurrentRows);
            if (view.Count == 0)
            {
                return num;
            }
            string sCarId = view[0]["CarId"].ToString();
            ThreeStateTreeNode node = this.tvList.getNodeById(sCarId);
            if (node == null)
            {
                return num;
            }
            if (!node.Checked)
            {
                num = RemotingClient.Car_WatchCar(sCarId, false, true);
                if (num == 0)
                {
                    node.CheckState = TriState.Checked;
                    this.tvList.RecursiveSetNodeTriState(node);
                }
                return num;
            }
            return 0;
        }

        private void setCarImag(string sCarId, string sImage)
        {
            try
            {
                ThreeStateTreeNode node = this.tvList.getNodeById(sCarId);
                if ((node != null) && (node.CarStatus != sImage))
                {
                    if (sImage.Equals(m_sAlarmKey) || sImage.Equals(m_sStopAlarmKey))
                    {
                        node.IsAlarm = true;
                    }
                    else
                    {
                        node.IsAlarm = false;
                    }
                    node.CarStatus = sImage;
                }
            }
            catch
            {
            }
        }

        public DataTable setCarList()
        {
            DataTable table = null;
            try
            {
                this.tsbRefreshList.Visible = true;
                table = this.getCarList(this.getAreaList());
                Record.execFileRecord("设置车辆列表", "完成，车辆总数为：" + ((this.m_dtCarList == null) ? "0" : this.m_dtCarList.Rows.Count.ToString()));
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置车辆列表", exception.Message);
            }
            return table;
        }

        public void setCarOffline(string sCarId)
        {
            ThreeStateTreeNode node = this.tvList.getNodeById(sCarId);
            if ((node != null) && (node.CarStatus != ThreeStateTreeNode.sOffLine))
            {
                node.CarStatus = ThreeStateTreeNode.sOffLine;
            }
        }

        private bool setCarOffline(TreeNode Node)
        {
            bool flag = false;
            foreach (TreeNode node in Node.Nodes)
            {
                if (node.Tag.Equals("CAR"))
                {
                    ThreeStateTreeNode node2 = node as ThreeStateTreeNode;
                    if (!node2.IsAlarm)
                    {
                        node2.CarStatus = ThreeStateTreeNode.sOffLine;
                        flag = true;
                        node2 = null;
                    }
                }
                else if (this.setCarOffline(node))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void setOffLine2(string sCarId)
        {
            ThreeStateTreeNode node = this.tvList.getNodeById(sCarId);
            if ((node != null) && (node.CarStatus != ThreeStateTreeNode.sOffLine2))
            {
                node.CarStatus = ThreeStateTreeNode.sOffLine2;
            }
        }

        private void setCarOnline(object obj)
        {
            DataTable table = obj as DataTable;
            if (table != null)
            {
                ThreeStateTreeNode node;
                int num = 1;
                try
                {
                    foreach (DataRow row in table.Rows)
                    {
                        MainForm.sCurrentShowCnt = num.ToString();
                        num++;
                        node = this.tvList.getNodeById(row["CarId"].ToString());
                        if (node != null)
                        {
                            this.setCarStatus(node, row, false);
                            this.setNodeValue(node, row);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("设置在线车辆(集合/新线程)2", exception.ToString());
                }
                finally
                {
                    table.Clear();
                    table = null;
                    node = null;
                }
                this.setAreaText();
            }
        }

        public void setCarParticularPlace(string sPlace)
        {
            try
            {
                string[] separator = new string[] { ":::" };
                string[] strArray2 = sPlace.Split(separator, StringSplitOptions.None);
                if (strArray2.Length > 0)
                {
                    string sCarId = strArray2[4];
                    ThreeStateTreeNode tn = this.tvList.getNodeById(sCarId);
                    tn.Address = strArray2[1];
                    if (this.tvList.Visible)
                    {
                        if (this.tvList.CurrentNode == tn)
                        {
                            this.ShowCarDetail(tn);
                        }
                    }
                    else if ((this.tvTrackCar.CurrentNode as ThreeStateTreeNode).CarId == tn.CarId)
                    {
                        this.ShowCarDetail(tn);
                    }
                }
            }
            catch
            {
                Record.execFileRecord("设置车辆详细位置信息（精确到建筑物）", sPlace);
            }
        }

        private void setCarPlace(string sPlaceParam)
        {
            if (MainForm.myMap.MapReaded)
            {
                try
                {
                    string[] districtInfo = GisService.GetDistrictInfo(sPlaceParam.Trim(new char[] { '|' }).Split(new char[] { '|' }));
                    if (districtInfo != null)
                    {
                        foreach (string str in districtInfo)
                        {
                            string[] strArray3 = str.Split(new char[] { ':' });
                            if (strArray3.Length >= 2)
                            {
                                foreach (string str2 in strArray3[1].Split(new char[] { ',' }))
                                {
                                    ThreeStateTreeNode node = this.tvList.getNodeById(str2);
                                    if (node != null)
                                    {
                                        if (string.IsNullOrEmpty(strArray3[0]))
                                        {
                                            Record.execFileRecord("行政区为空的车辆", node.CarNum + ":" + node.Longitude + "," + node.Latitude);
                                        }
                                        else
                                        {
                                            node.Place = strArray3[0];
                                            base.Invoke(this.myUpdatePlace, new object[] { 1, node });
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Record.execFileRecord("获取车辆位置信息为空", sPlaceParam + "/" + districtInfo);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("设置车辆位置信息setCarPlace", exception.Message + "  " + sPlaceParam);
                    }
                }
            }
        }

        private void setCarStatus(ThreeStateTreeNode node, string sKey)
        {
            try
            {
                if ((this.tvList != null) && (this.tvList.Nodes.Count != 0))
                {
                    if (node.CarStatus != sKey)
                    {
                        node.CarStatus = sKey;
                    }
                    if (sKey.Equals(m_sOffLineKey))
                    {
                        MainForm.myMap.execDeleteCar(node.Name);
                    }
                }
            }
            catch
            {
            }
        }

        private void setCarStatus(ThreeStateTreeNode tn, DataRow dr, bool isAlarm)
        {
            bool flag = false;
            if ("1".Equals(dr["AccOn"].ToString()))
            {
                flag = true;
            }
            if ("1".Equals(dr["CarStatus"].ToString()))
            {
                string strB = dr["ReceTime"].ToString();
                if (tn.LastAlarmStopTime.CompareTo(strB) <= 0)
                {
                    tn.LastAlarmSetTime = strB;
                    if (isAlarm)
                    {
                        this.AddAlermList(tn.Name, dr);
                    }
                    if (flag)
                    {
                        base.Invoke(this.mySetCarStatus, new object[] { tn, m_sAlarmKey });
                    }
                    else
                    {
                        base.Invoke(this.mySetCarStatus, new object[] { tn, m_sStopAlarmKey });
                    }
                    tn.IsAlarm = true;
                }
            }
            else if (tn.IsAlarm)
            {
                if (flag)
                {
                    base.Invoke(this.mySetCarStatus, new object[] { tn, m_sAlarmKey });
                }
                else
                {
                    base.Invoke(this.mySetCarStatus, new object[] { tn, m_sStopAlarmKey });
                }
            }
            else if ("0".Equals(dr["GpsValid"].ToString()) && flag)
            {
                //修改为只有ACC开时，定位状态无效，才设置图标为警告图标 huzh 2014.2.14
                base.Invoke(this.mySetCarStatus, new object[] { tn, m_sFaultKey });
            }
            else if ("1".Equals(dr["IsFill"].ToString()))
            {
                if (flag)
                {
                    base.Invoke(this.mySetCarStatus, new object[] { tn, m_sFillKey });
                }
                else
                {
                    base.Invoke(this.mySetCarStatus, new object[] { tn, m_sStopFillKey });
                }
            }
            else if (flag)
            {
                base.Invoke(this.mySetCarStatus, new object[] { tn, m_sOnLineKey });
            }
            else
            {
                base.Invoke(this.mySetCarStatus, new object[] { tn, m_sStopOnLineKey });
            }
        }

        //自定义附加消息显示 周立山 2014.1.3
        private string[] TransAddMsgTxt(string addMsgTxt)
        {
            List<string> results = new List<string>();

            try
            {
                //addMsgTxt = "10/M100000/20/ME8A8";

                string[] addmsgtxts = addMsgTxt.Split('/');

                foreach (string s in addmsgtxts)
                {
                    if (!s.StartsWith("ME8"))
                        continue;

                    byte byt = Convert.ToByte(s.Substring(3), 16);

                    if ((byt & 128) != 0)
                        results.Add("制动/开");
                    else
                        results.Add("制动/关");
                    if ((byt & 64) != 0)
                        results.Add("左转向灯/开");
                    else
                        results.Add("左转向灯/关");
                    if ((byt & 32) != 0)
                        results.Add("右转向灯/开");
                    else
                        results.Add("右转向灯/关");
                    if ((byt & 16) != 0)
                        results.Add("远光灯/开");
                    else
                        results.Add("远光灯/关");
                    if ((byt & 8) != 0)
                        results.Add("近光灯/开");
                    else
                        results.Add("近光灯/关");
                }
            }
            catch
            {
                //Record.execFileRecord("自定义附加消息时失败！");
            }
            return results.ToArray();
        }


        public void setCarTipShowType(ThreeStateTreeNode tn)
        {
            StringBuilder builder = new StringBuilder();
            if (tn.CarStatusValue != null)
            {
                string[] strArray = tn.CarStatusValue.Replace("\r\n", "").Split(new char[] { ';' });
                Graphics graphics = this.tvList.CreateGraphics();
                StringBuilder builder2 = new StringBuilder();
                string text = "";
                foreach (string str2 in strArray)
                {
                    text = text + str2 + ";";
                    float num2 = graphics.MeasureString(text, this.tvList.Font).Width - (Screen.PrimaryScreen.WorkingArea.Width / 2);
                    if (num2 > 0f)
                    {
                        text = text + "\r\n      ";
                        builder2.Append(text);
                        text = "";
                    }
                }
                if (text.Length > 0)
                {
                    builder2.Append(text.Trim(new char[] { ';' }) + ";");
                }
                graphics.Dispose();
                tn.CarStatusValue = builder2.ToString();
                builder2.Length = 0;
            }
            string str3 = string.Format("车牌：{0}\r\n车号：{1}\r\n手机：{2}\r\n状态：{3}", new object[] { tn.CarNum, tn.CarId, tn.SimNum, tn.CarStatusValue });

            //自定义附加消息显示 周立山 2014.1.3
            string[] status = TransAddMsgTxt(tn.AddMsgTxt);
            foreach (var s in status)
            {
                if (s.EndsWith("/开"))
                    str3 += s.Replace("/开", ";");
            }

            if (this.iTipCount == 0)
            {
                this.iTipCount = int.Parse(Variable.sGetNodeTipShowType);
                if (this.iTipCount == 0)
                {
                    tn.ToolTipText = str3;
                    if ((this.iTipCount == 0) && !Variable.sShippingEnable.Equals("1"))
                    {
                        tn.ToolTipText = str3;
                        return;
                    }
                }
            }
            if ((this.iTipCount & 1) != 0)
            {
                builder.Append(string.Format("\r\n所属区域：{0}", tn.CarAreaName));
            }
            if ((this.iTipCount & 2) != 0)
            {
                builder.Append(string.Format("\r\n车辆类型：{0}", tn.CarType));
            }
            if ((this.iTipCount & 4) != 0)
            {
                builder.Append(string.Format("\r\n车辆颜色：{0}", tn.CarColor));
                builder.Append(string.Format("\r\n车牌颜色：{0}", tn.PlateColor));
            }
            if ((this.iTipCount & 8) != 0)
            {
                builder.Append(string.Format("\r\n车主姓名：{0}", tn.CarPName));
            }
            if ((this.iTipCount & 16) != 0)
            {
                builder.Append(string.Format("\r\n车主电话：{0}", tn.CarPTel));
            }
            if ((this.iTipCount & 32) != 0)
            {
                builder.Append(string.Format("\r\n工作单位：{0}", tn.WordCompany));
            }
            if ((this.iTipCount & 64) != 0)
            {
                builder.Append(string.Format("\r\n车主EMAIL：{0}", tn.CarEmail));
            }
            if ((this.iTipCount & 128) != 0)
            {
                builder.Append(string.Format("\r\n身份证号码：{0}", tn.CarPID));
            }
            string str4 = "";
            if (((this.iTipCount & 256) != 0) && (tn.FirstName != null))
            {
                str4 = tn.FirstName.Trim() + " ";
            }
            if (((this.iTipCount & 512) != 0) && (tn.FirstTel != null))
            {
                str4 = str4 + tn.FirstTel.Trim();
            }
            if (!string.IsNullOrEmpty(str4))
            {
                builder.Append(string.Format("\r\n第一联系人：{0}", str4));
            }
            string str5 = "";
            if (((this.iTipCount & 1024) != 0) && (tn.SecondName != null))
            {
                str5 = tn.SecondName.Trim() + " ";
            }
            if (((this.iTipCount & 2048) != 0) && (tn.SecondTel != null))
            {
                str5 = str5 + tn.SecondTel.Trim();
            }
            if (!string.IsNullOrEmpty(str5))
            {
                builder.Append(string.Format("\r\n第二联系人：{0}", str5));
            }
            if (builder.ToString().Length > 0)
            {
                str3 = str3 + "\r\n--------------------------" + builder.ToString();
            }
            str3 = str3 + this.getWaybillCodeList(tn);
            if (tn.ToolTipText != str3)
            {
                tn.ToolTipText = str3;
            }
            builder = null;
        }

        public void setCarTipShowType(ThreeStateTreeNode node, ThreeStateTreeNode AlarmNode)
        {
            StringBuilder builder = new StringBuilder();
            if (node.CarStatusValue != null)
            {
                string[] strArray = node.CarStatusValue.Replace("\r\n", "").Split(new char[] { ';' });
                Graphics graphics = this.tvList.CreateGraphics();
                StringBuilder builder2 = new StringBuilder();
                string text = "";
                foreach (string str2 in strArray)
                {
                    text = text + str2 + ";";
                    float num2 = graphics.MeasureString(text, this.tvList.Font).Width - (Screen.PrimaryScreen.WorkingArea.Width / 2);
                    if (num2 > 0f)
                    {
                        text = text + "\r\n      ";
                        builder2.Append(text);
                        text = "";
                    }
                }
                if (text.Length > 0)
                {
                    builder2.Append(text.Trim(new char[] { ';' }) + ";");
                }
                graphics.Dispose();
                node.CarStatusValue = builder2.ToString();
                builder2.Length = 0;
            }
            string str3 = string.Format("车牌：{0}\r\n车号：{1}\r\n手机：{2}\r\n状态：{3}", new object[] { node.CarNum, node.CarId, node.SimNum, node.CarStatusValue });

            //自定义附加消息显示 周立山 2014.1.3
            string[] status = TransAddMsgTxt(node.AddMsgTxt);
            foreach (var s in status)
            {
                if (s.EndsWith("/开"))
                    str3 += s.Replace("/开", ";");
            }

            if (this.iTipCount == 0)
            {
                node.ToolTipText = str3;
            }
            else
            {
                if ((this.iTipCount & 1) != 0)
                {
                    builder.Append(string.Format("\r\n所属区域：{0}", AlarmNode.CarAreaName));
                }
                if ((this.iTipCount & 2) != 0)
                {
                    builder.Append(string.Format("\r\n车辆类型：{0}", AlarmNode.CarType));
                }
                if ((this.iTipCount & 4) != 0)
                {
                    builder.Append(string.Format("\r\n车辆颜色：{0}", AlarmNode.CarColor));
                }
                if ((this.iTipCount & 8) != 0)
                {
                    builder.Append(string.Format("\r\n车主姓名：{0}", AlarmNode.CarPName));
                }
                if ((this.iTipCount & 16) != 0)
                {
                    builder.Append(string.Format("\r\n车主电话：{0}", AlarmNode.CarPTel));
                }
                if ((this.iTipCount & 32) != 0)
                {
                    builder.Append(string.Format("\r\n工作单位：{0}", AlarmNode.WordCompany));
                }
                if ((this.iTipCount & 64) != 0)
                {
                    builder.Append(string.Format("\r\n车主EMAIL：{0}", AlarmNode.CarEmail));
                }
                if ((this.iTipCount & 128) != 0)
                {
                    builder.Append(string.Format("\r\n身份证号码：{0}", AlarmNode.CarPID));
                }
                string str4 = "";
                if (((this.iTipCount & 256) != 0) && (AlarmNode.FirstName != null))
                {
                    str4 = AlarmNode.FirstName.Trim() + " ";
                }
                if (((this.iTipCount & 512) != 0) && (AlarmNode.FirstTel != null))
                {
                    str4 = str4 + AlarmNode.FirstTel.Trim();
                }
                if (!string.IsNullOrEmpty(str4))
                {
                    builder.Append(string.Format("\r\n第一联系人：{0}", str4));
                }
                string str5 = "";
                if (((this.iTipCount & 1024) != 0) && (AlarmNode.SecondName != null))
                {
                    str5 = AlarmNode.SecondName.Trim() + " ";
                }
                if (((this.iTipCount & 2048) != 0) && (AlarmNode.SecondTel != null))
                {
                    str5 = str5 + AlarmNode.SecondTel.Trim();
                }
                if (!string.IsNullOrEmpty(str5))
                {
                    builder.Append(string.Format("\r\n第二联系人：{0}", str5));
                }
                if (builder.ToString().Length > 0)
                {
                    str3 = str3 + "\r\n--------------------------" + builder.ToString();
                }
                str3 = str3 + this.getWaybillCodeList(AlarmNode);
                if (node.ToolTipText != str3)
                {
                    node.ToolTipText = str3;
                }
                if (AlarmNode.ToolTipText != str3)
                {
                    AlarmNode.ToolTipText = str3;
                }
                builder = null;
            }
        }

        private void setChangeNodeAddress()
        {
            this.SetShowCarDetailVisible();
        }

        private void setCheckCar()
        {
            if (!string.IsNullOrEmpty(this.m_sCheckedCar))
            {
                foreach (string str in this.m_sCheckedCar.Split(new char[] { ',' }))
                {
                    ThreeStateTreeNode currNode = this.tvList.getNodeById(str);
                    if (currNode != null)
                    {
                        this.tvList.CheckChang(currNode);
                    }
                }
                this.m_sCheckedCar = "";
            }
        }

        private void setDgvTrackCar()
        {
            if ((this.m_dtCarAlermList != null) && (this.dgvTrackCar.DisplayedColumnCount(true) > 2))
            {
                try
                {
                    for (int i = 1; i < this.dgvTrackCar.Columns.Count; i++)
                    {
                        if (this.dgvTrackCar.Columns[i].Visible)
                        {
                            lock (this.dgvTrackCar)
                            {
                                this.dgvTrackCar.Columns[i].Visible = false;
                            }
                        }
                    }
                    this.dgvTrackCar.Columns["CarNum"].Visible = true;
                    this.dgvTrackCar.Columns["CarNum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("setDgvTrackCar", exception.StackTrace);
                }
            }
        }

        private void setEnabled(bool bEnabled)
        {
            this.tvList.Enabled = bEnabled;
        }

        public string setMapTipDetail(DataRow dr)
        {
            string input = "";
            try
            {
                string sCarId = dr["CarId"].ToString();
                ThreeStateTreeNode node = this.tvList.getNodeById(sCarId);
                string str3 = (node == null) ? "未知" : node.PlateColor;
                string str4 = (node == null) ? dr["Simnum"].ToString() : node.SimNum;
                string str5 = (node == null) ? "未知" : node.DriverName;
                string str6 = (node == null) ? "未知" : node.Company;
                string str7 = (node == null) ? "未知" : node.TermSerial;
                input = string.Format("车牌[{0}]；车牌颜色[{2}]；终端ID[{6}]；Sim卡号[{3}]；驾驶员[{4}]；所属公司[{5}]；{1}；", new object[] { dr["CarNum"].ToString(), dr["Describe"].ToString(), str3, str4, str5, str6, str7 });

                input.IndexOf("", 0);
                Match match = Regex.Match(input, "^([^；]+；){3}");
                input = input.Substring(0, match.Length) + "</br>" + input.Substring(match.Length);
                match = Regex.Match(input, "^([^；]+；){5}");
                input = input.Substring(0, match.Length) + "</br>" + input.Substring(match.Length);
                match = Regex.Match(input, "^([^；]+；){6}");
                input = input.Substring(0, match.Length) + "</br>" + input.Substring(match.Length);
                input = input.Substring(0, input.LastIndexOf("]；") + 1);
                string str8 = "";
                str8 = (MainForm.EbillTextList[dr["carid"].ToString()] == null) ? "" : MainForm.EbillTextList[dr["carid"].ToString()].ToString();
                if (str8 != "")
                {
                    return (input + string.Format("电子运单[{0}]", str8));
                }
                input = input + string.Format("电子运单[{0}]", "");

                //自定义附加消息显示 周立山 2014.1.3
                string[] status = TransAddMsgTxt(dr["AddMsgTxt"].ToString());
                foreach (var s in status)
                {
                    if (s.EndsWith("/开"))
                        input += s.Replace("/开", "[开];");
                    else
                        input += s.Replace("/关", "[关];");
                }
            }
            catch
            {
            }
            return input;
        }

        /// <summary>
        /// 加载右键菜单
        /// </summary>
        private void setMenuEnable()
        {
            try
            {
                int num = this.getSelectedCnt();
                if (this.m_menuList != null)
                {
                    if ((num > 1) || ((this.tvList.SelectedNode.Tag != null) && "AREA".Equals(this.tvList.SelectedNode.Tag.ToString())))
                    {
                        foreach (string str in this._disableMenuList.ToLower().Split(new char[] { ',' }))
                        {
                            Program.mainForm.setMenuEnable(str, false);
                        }
                        this.m_menuList.Items["MenuItemTradeApp"].Enabled = false;
                        foreach (ToolStripMenuItem item in (this.m_menuList.Items["MenuItemTradeApp"] as ToolStripMenuItem).DropDownItems)
                        {
                            item.Enabled = false;
                        }

                        ////视频监控菜单 2013.12.16 周立山
                        //this.m_menuList.Items["MenuItemCarVideo"].Visible = false;
                        //this.m_menuList.Items["MenuItemCarVideo"].Enabled = false;
                    }
                    else
                    {
                        foreach (string str2 in this._disableMenuList.ToLower().Split(new char[] { ',' }))
                        {
                            Program.mainForm.setMenuEnable(str2, true);
                        }
                        this.m_menuList.Items["MenuItemTradeApp"].Enabled = true;
                        foreach (ToolStripMenuItem item2 in (this.m_menuList.Items["MenuItemTradeApp"] as ToolStripMenuItem).DropDownItems)
                        {
                            item2.Enabled = true;
                        }

                        ////视频监控菜单 2013.12.16 周立山
                        //this.m_menuList.Items["MenuItemCarVideo"].Visible = true;
                        //this.m_menuList.Items["MenuItemCarVideo"].Enabled = true;

                    }
                    if ((num > int.Parse(Variable.sImportCarMax)) || !this.chkAllChecked())
                    {
                        Program.mainForm.setMenuEnable("itmImportReport".ToLower(), false);
                    }
                    else
                    {
                        Program.mainForm.setMenuEnable("itmImportReport".ToLower(), true);
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = ex.ToString();
            }
        }

        public void setMenuList(ContextMenuStrip menuList)
        {
            this.m_menuList = menuList;
        }

        public void setNodeFontDefault(ThreeStateTreeNode myNode)
        {
            myNode.ForeColor = SystemColors.ControlText;
        }

        public void setNodeFontNewStyle(ThreeStateTreeNode myNode)
        {
            myNode.ForeColor = Color.Red;
        }

        private void setNodeShow(ThreeStateTreeNode myNode)
        {
            myNode.setNodeShow();
        }

        private void setNodeValue(ThreeStateTreeNode myNode, DataRow dr)
        {
            myNode.SetIsFill = dr["IsFill"].ToString();
            myNode.AccOn = dr["AccOn"].ToString();
            myNode.Longitude = dr["Longitude"].ToString();
            myNode.Latitude = dr["Latitude"].ToString();
            myNode.GpsTime = dr["GpsTime"].ToString();
            myNode.Speed = dr["Speed"].ToString();
            myNode.GpsValid = dr["GpsValid"].ToString();
            myNode.AlarmType = dr["AlarmType"].ToString();
            myNode.ReceTime = dr["ReceTime"].ToString();
            myNode.ALLDiff = dr["Distance"].ToString();
            myNode.Direction = dr["Direct"].ToString();
            try
            {
                myNode.Altitude = dr["Altitude"].ToString();
            }
            catch
            {

            }
            try
            {
                myNode.TransportStatu = dr["TransportStatu"].ToString();
            }
            catch
            {

            }

            //自定义附加消息显示 周立山 2014.1.7
            try
            {
                if ((myNode.CarStatusValue == null)
                    ||
                    !myNode.CarStatusValue.Equals(dr["StatuName"].ToString())
                    ||
                    myNode.AddMsgTxt != dr["AddMsgTxt"].ToString()
                    )
                {
                    if (!string.IsNullOrEmpty(dr["StatuName"].ToString()))
                    {
                        myNode.CarStatusValue = dr["StatuName"].ToString();
                    }
                    else
                    {
                        Record.execFileRecord(string.Format("StatuName is null RecordTime-{0},GpsTime-{1},GpsValid-{2},ReceTime-{3},CarId-{4},CarNum-{5}", new object[] { DateTime.Now.ToString(), myNode.GpsTime, myNode.GpsValid, myNode.ReceTime, myNode.CarId, myNode.CarNum }));
                    }
                    if (myNode.AddMsgTxt != dr["AddMsgTxt"].ToString())
                    {
                        myNode.AddMsgTxt = dr["AddMsgTxt"].ToString();
                    }
                    this.setCarTipShowType(myNode);
                }
            }
            catch
            {
                //Record.execFileRecord("解析服务端收到的数据时发生异常，可能是服务端未发送相关字段所导致");
            }

            //if ((myNode.CarStatusValue == null) || !myNode.CarStatusValue.Equals(dr["StatuName"].ToString()))
            //{
            //    if (!string.IsNullOrEmpty(dr["StatuName"].ToString()))
            //    {
            //        myNode.CarStatusValue = dr["StatuName"].ToString();
            //        this.setCarTipShowType(myNode);
            //    }
            //    else
            //    {
            //        Record.execFileRecord(string.Format("StatuName is null RecordTime-{0},GpsTime-{1},GpsValid-{2},ReceTime-{3},CarId-{4},CarNum-{5}", new object[] { DateTime.Now.ToString(), myNode.GpsTime, myNode.GpsValid, myNode.ReceTime, myNode.CarId, myNode.CarNum }));
            //    }
            //}

            if (myNode.CarId == this.sDetailCarId)
            {
                this.ChangeNodeAddress();
            }
        }

        /// <summary>
        /// 设置单个车辆树节点在线
        /// </summary>
        /// <param name="dr"></param>
        public void setOnline(DataRow dr)
        {
            string str = dr["CarId"].ToString();
            DataView view = new DataView(this.m_dtCarList, string.Format("CarId={0}", str), "", DataViewRowState.CurrentRows);
            if (view.Count != 0)
            {
                ThreeStateTreeNode myNode = this.tvList.getNodeById(str);
                if (myNode != null)
                {
                    this.setNodeValue(myNode, dr);
                    this.setCarStatus(myNode, dr, false);
                    this.setAreaText();
                }
                view = null;
            }
        }

        /// <summary>
        /// 批量设置车辆树节点在线
        /// </summary>
        /// <param name="dtOnLine"></param>
        public void setOnline(DataTable dtOnLine)
        {
            try
            {
                tSetOnline = new Thread(new ParameterizedThreadStart(this.setCarOnline));
                tSetOnline.Start(dtOnLine.Copy());
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置在线车辆", exception.ToString());
            }
        }

        private void SetShowCarDetailVisible()
        {
            try
            {
                this.rtxtCarDetail.Text = "";
                if (this.pbRichText.Visible)
                {
                    this.tsbShowDetail.Image = this.CarImageList.Images["Down"];
                    this.tsbShowDetail.ToolTipText = "隐藏车辆详细信息";
                    ThreeStateTreeNode tn = null;
                    if (this.tvTrackCar.Visible)
                    {
                        if (this.tvTrackCar.CurrentNode != null)
                        {
                            tn = this.tvList.getNodeById(this.tvTrackCar.CurrentNode.Name);
                        }
                    }
                    else
                    {
                        tn = this.tvList.CurrentNode as ThreeStateTreeNode;
                    }
                    if ((tn != null) && tn.Tag.ToString().Equals("CAR"))
                    {
                        if (!string.IsNullOrEmpty(tn.Latitude))
                        {
                            MainForm.myMap.excuteSpatialQueryById(tn.CarId, tn.Longitude, tn.Latitude);
                        }
                        this.ShowCarDetail(tn);
                    }
                }
                else
                {
                    this.tsbShowDetail.Image = this.CarImageList.Images["Up"];
                    this.tsbShowDetail.ToolTipText = "显示车辆详细信息";
                }
            }
            catch (Exception exception)
            {
                if (Variable.bLogin)
                {
                    Record.execFileRecord("设置车辆详细信息显示框是否可见", exception.ToString());
                }
            }
        }

        private void SetShowTipText(string sValue)
        {
            WaitForm.Show(sValue, this);
        }

        public void setWatchCar()
        {
            foreach (ThreeStateTreeNode node in this.tvList.Nodes)
            {
                if (node.CheckState == TriState.Checked)
                {
                    execSetWatchCar(new object[] { node.Name, !node.Tag.Equals("CAR"), true });
                }
                else if (node.CheckState == TriState.Indeterminate)
                {
                    this.setWatchCar(node);
                }
            }
        }

        private void setWatchCar(ThreeStateTreeNode node)
        {
            foreach (ThreeStateTreeNode node2 in node.Nodes)
            {
                if (node2.CheckState == TriState.Checked)
                {
                    execSetWatchCar(new object[] { node2.Name, !node2.Tag.Equals("CAR"), true });
                }
                else if (node2.CheckState == TriState.Indeterminate)
                {
                    this.setWatchCar(node2);
                }
            }
        }

        private void ShowCarDetail(ThreeStateTreeNode tn)
        {
            if (((tn != null) && (tn.Tag != null)) && tn.Tag.Equals("CAR"))
            {
                this.sDetailCarId = tn.CarId;
                int num = 0;
                int num2 = int.Parse(Variable.sGetNodeDetailShowType);
                StringBuilder builder = new StringBuilder();
                if (num2 == 0)
                {
                    this.rtxtCarDetail.Text = tn.ToolTipText;
                }
                else
                {
                    if ((num2 & 1) != 0)
                    {
                        builder.Append(string.Format("基本信息：{0}|*", tn.CarNum ));//+ "  " + tn.CarAreaName
                        num++;
                    }
                    builder.Append(string.Format("罐子状态：{0}|*", (tn.DynamicAttr.ContainsKey("罐子状态") ? tn.DynamicAttr["罐子状态"] : "")));
                    num++;
                    builder.Append(string.Format("当前油量：{0}|*", (tn.DynamicAttr.ContainsKey("oil") ? tn.DynamicAttr["oil"] : "")));
                    num++;
                    if ((num2 & 2) != 0)
                    {
                        builder.Append(string.Format("上报时间：{0}|*", tn.ReceTime));
                        num++;
                    }
                    if ((num2 & 4) != 0)
                    {
                        builder.Append(string.Format("定位时间：{0}|*", tn.GpsTime));
                        num++;
                    }
                    if ((num2 & 8) != 0)
                    {
                        builder.Append(string.Format("当前位置：{0}|*", tn.Address));
                        num++;
                    }

                    //自定义附加消息显示 周立山 2014.1.7
                    string[] status = TransAddMsgTxt(tn.AddMsgTxt);
                    foreach (var s in status)
                    {
                        if (s.StartsWith("制动"))
                            builder.Append(string.Format("制    动：{0}|*", s.EndsWith("开") ? "开启" : "关闭"));
                        if (s.StartsWith("左转向灯"))
                            builder.Append(string.Format("左转向灯：{0}|*", s.EndsWith("开") ? "开启" : "关闭"));
                        if (s.StartsWith("右转向灯"))
                            builder.Append(string.Format("右转向灯：{0}|*", s.EndsWith("开") ? "开启" : "关闭"));
                        if (s.StartsWith("远光灯"))
                            builder.Append(string.Format("远 光 灯：{0}|*", s.EndsWith("开") ? "开启" : "关闭"));
                        if (s.StartsWith("近光灯"))
                            builder.Append(string.Format("近 光 灯：{0}|*", s.EndsWith("开") ? "开启" : "关闭"));
                    }

                    if ((num2 & 16) != 0)
                    {
                        builder.Append(string.Format("速    度：{0}|*", tn.Speed));
                        num++;
                    }
                    if ((num2 & 32) != 0)
                    {
                        builder.Append(string.Format("累计里程：{0}|*", tn.ALLDiff));
                        num++;
                    }
                    if ((num2 & 64) != 0)
                    {
                        builder.Append(string.Format("经 纬 度：{0}|*", tn.Longitude + ";" + tn.Latitude));
                        num++;
                    }
                    if ((num2 & 128) != 0)
                    {
                        builder.Append(string.Format("运营状态：{0}|*", tn.TransportStatu));
                        num++;
                    }
                    if ((num2 & 256) != 0)
                    {
                        builder.Append(string.Format("方 向 角：{0}|*", tn.Direction));
                        num++;
                        builder.Append(string.Format("海拔高度：{0}|*", tn.Altitude));
                        num++;
                    }
                    if ((num2 & 512) != 0)
                    {
                        builder.Append(string.Format("到期时间：{0}|*", tn.EndTime));
                        num++;
                    }
                    string str = builder.ToString();
                    str = str.Substring(0, str.Length - 2).Replace("|*", "\r\n");
                    this.rtxtCarDetail.Text = str;
                    builder = null;
                    this.rtxtCarDetail.Height = (num * 16) + 21;
                }
            }
            else
            {
                this.sDetailCarId = "";
                this.rtxtCarDetail.Text = "";
                if (tn == null)
                {
                    Record.execFileRecord("左下角车辆信息栏有时会空白显示", " 树节点值为NULL");
                }
                else if (tn.Tag == null)
                {
                    Record.execFileRecord("左下角车辆信息栏有时会空白显示", " 节点ID-" + tn.Name + " 节点名称-" + tn.Text + "树节点Tag值为NULL");
                }
                else
                {
                    Record.execFileRecord("左下角车辆信息栏有时会空白显示", " 节点ID-" + tn.Name + " 节点名称-" + tn.Text + "节点Tag-" + tn.Tag.ToString());
                }
            }
        }

        public void StopAlerm(string sCarId)
        {
            if (this.m_dtCarAlermList != null)
            {
                try
                {
                    DataRow row = this.m_dtCarAlermList.Rows.Find(sCarId);
                    if (row != null)
                    {
                        this.m_dtCarAlermList.Rows.Remove(row);
                        ThreeStateTreeNode node = this.tvTrackCar.getNodeById(sCarId);
                        if (node == null)
                        {
                            return;
                        }
                        this.tvTrackCar.Nodes.Remove(node);
                        this.tvTrackCar.hasCarPath.Remove(sCarId);
                        ThreeStateTreeNode node2 = this.tvList.getNodeById(sCarId);
                        if (node2 != null)
                        {
                            node2.IsAlarm = false;
                        }
                        (this.tvTrackCar.Nodes[0] as ThreeStateTreeNode).SetNodeText("报警车辆(" + this.tvTrackCar.Nodes[0].Nodes.Count + ")");
                        row = null;
                    }
                    AlarmSound.GetInstance().IsCustomAlarmSound(this.m_dtCarAlermList);
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("从报警车辆列表删除停止报警车辆", exception.ToString());
                }
            }
        }

        private void tcCarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tcCarList.SelectedTab.Name == this.tpTrackCar.Name)
            {
                this.tsbAlarmAffirm.Visible = true;
                this.tsbRefreshList.Visible = false;
                this.tvTrackCar.Visible = true;
                this.tvList.Visible = false;
            }
            else
            {
                if (!"1".Equals(Variable.sAllowRefresh))
                {
                    this.tsbRefreshList.Visible = !this.m_bDownResult;
                }
                else
                {
                    this.tsbRefreshList.Visible = true;
                }
                this.tsbAlarmAffirm.Visible = false;
                this.tvTrackCar.Visible = false;
                this.tvList.Visible = true;
            }
            this.SetShowCarDetailVisible();
        }

        private void tGetShippingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.tGetShippingTimer.Interval = 3600000.0;
            try
            {
                if (this.GetShippingList())
                {
                    string str = "";
                    string str2 = "";
                    foreach (DataRow row in this.m_dtShippingList.Rows)
                    {
                        str = row["CarId"].ToString();
                        if (!str.Equals(str2))
                        {
                            ThreeStateTreeNode tn = this.tvList.getNodeById(row["CarId"].ToString());
                            if (tn != null)
                            {
                                str2 = str;
                                this.setCarTipShowType(tn);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            this.tGetShippingTimer.Interval = 300000.0;
        }

        private void tPlayAlarmSount_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.tPlayAlarmSount.Interval = 60000.0;
            try
            {
                if (string.IsNullOrEmpty(Variable.sAlarmSoundStatusFilePath) || !File.Exists(Variable.sAlarmSoundStatusFilePath))
                {
                    Variable.sAlarmSoundStatusFilePath = Application.StartupPath + @"\Sound\Alarm.WAV";
                }
                if ((Variable.sAlarmSoundStatus.Equals("开") && this.IsPlayAlarmSound) && (AlarmSound.GetInstance().AlarmSoundFilePath.Trim().Length > 0))
                {
                    if ((this.m_dtCarAlermList != null) && (this.m_dtCarAlermList.Rows.Count > 0))
                    {
                        SoundPlay.PlaySoundEx(AlarmSound.GetInstance().AlarmSoundFilePath);
                    }
                }
                else if (((Variable.sAlarmSoundStatus.Equals("开") && this.IsPlayAlarmSound) && (File.Exists(Variable.sAlarmSoundStatusFilePath) && (this.m_dtCarAlermList != null))) && (this.m_dtCarAlermList.Rows.Count > 0))
                {
                    SoundPlay.PlaySoundEx(Variable.sAlarmSoundStatusFilePath);
                }
            }
            finally
            {
                this.tPlayAlarmSount.Interval = 1000.0;
            }
        }

        private void tsbAlarmAffirm_Click(object sender, EventArgs e)
        {
            this.AlarmConfirm();
        }

        private void tsbRefreshList_Click(object sender, EventArgs e)
        {
            this.IsFresh = true;
            try
            {
                base.Enabled = false;
                if ("1".Equals(Variable.sAllowRefresh) && !string.IsNullOrEmpty(this.getCheckedCar()))
                {
                    this.m_sCheckedCar = this.getCheckedCar();
                }
                this.tvList.Nodes.Clear();
                this.delCarDetail();
                this.workerRefresh = new BackgroundWorker();
                this.workerRefresh.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.workerRefresh_RunWorkerCompleted);
                this.workerRefresh.DoWork += new DoWorkEventHandler(this.workerRefresh_DoWork);
                this.workerRefresh.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("刷新列表", exception.Message);
            }
        }

        private void tsbShowDetail_Click(object sender, EventArgs e)
        {
            this.pbRichText.Visible = !this.pbRichText.Visible;
            this.SetShowCarDetailVisible();
        }

        private void tUpdateCarPlace_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (((this.tvList != null) && (this.tvList.hasCarPath != null)) && MainForm.myMap.MapReaded)
            {
                this.tUpdateCarPlace.Interval = 1200000.0;
                try
                {
                    DataTable table = RemotingClient.Updata_GetCarCurrentPosNotSelByCompress();

                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            ThreeStateTreeNode myNode = this.tvList.getNodeById(row["CarId"].ToString());
                            if (myNode != null)
                            {
                                this.setNodeValue(myNode, row);
                            }
                        }
                    }
                    string sPlaceParam = "";
                    int num = 0;
                    foreach (string str2 in this.tvList.hasCarPath.Keys)
                    {
                        ThreeStateTreeNode node2 = this.tvList.getNodeById(str2);
                        if ((node2 != null) && node2.PlaceChangeed)
                        {
                            sPlaceParam = sPlaceParam + string.Format("{0},{1},{2}|", node2.CarId, node2.Longitude, node2.Latitude);
                            node2.PlaceChangeed = false;
                            num++;
                            if (num >= Variable.iMaxGetPlaceCnt)
                            {
                                this.setCarPlace(sPlaceParam);
                                num = 0;
                                sPlaceParam = "";
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(sPlaceParam))
                    {
                        this.setCarPlace(sPlaceParam);
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("设置车辆位置", exception.Message);
                }
                this.tUpdateCarPlace.Interval = 600000.0;
            }
        }

        private void tvList_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "Folder_Collapse";
            e.Node.SelectedImageKey = "Folder_Collapse";
        }

        private void tvList_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "Folder_Expand";
            e.Node.SelectedImageKey = "Folder_Expand";
            foreach (ThreeStateTreeNode node in e.Node.Nodes)
            {
                node.setNodeShow();
            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ThreeStateTreeNode node = e.Node as ThreeStateTreeNode;
            this.tvList.SetCurrentNode(node);

            if (!(string.IsNullOrEmpty(node.Latitude) && string.IsNullOrEmpty(node.Longitude)))
            {
                //跳转到车辆位置
                MainForm.myMap.setZoomCar(node.CarId);
            }

            if (this.pbRichText.Visible)
            {
                try
                {
                    if (((node != null) && (node.Tag != null)) && node.Tag.Equals("CAR"))
                    {
                        this.ShowCarDetail(node);
                        if (!string.IsNullOrEmpty(node.Latitude))
                        {
                            MainForm.myMap.excuteSpatialQueryById(node.CarId, node.Longitude, node.Latitude);
                        }
                    }
                    else
                    {
                        this.rtxtCarDetail.Text = "";
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("更改选中节点事件", exception.Message);
                }
            }
        }

        private void tvList_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!this.tvList.AllowCheck)
            {
                WaitForm.Show("正在更新服务器数据", this);
                try
                {
                    ThreeStateTreeNode argument = e.Node as ThreeStateTreeNode;
                    if (argument == null)
                    {
                        return;
                    }
                    if (this.worker_SetWatchCar == null)
                    {
                        this.worker_SetWatchCar = new BackgroundWorker();
                        this.worker_SetWatchCar.WorkerReportsProgress = true;
                        this.worker_SetWatchCar.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_SetWatchCar_RunWorkerCompleted);
                        this.worker_SetWatchCar.DoWork += new DoWorkEventHandler(this.worker_SetWatchCar_DoWork);
                        this.worker_SetWatchCar.RunWorkerAsync(argument);
                        this.tvList.Enabled = false;
                    }

                }
                catch (Exception exception)
                {
                    Record.execFileRecord("选中树节点前事件", exception.Message);
                    return;
                }
                e.Cancel = true;
            }
        }

        private void tvList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.setMenuEnable();
            }
        }

        private void tvList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && e.Node.Tag.ToString().Equals("CAR"))
            {
                MainForm.myMap.setTrackingCar(e.Node.Name);
                ThreeStateTreeNode tn = e.Node as ThreeStateTreeNode;
                if (tn != null)
                {
                    if (!this.pbRichText.Visible)
                    {
                        this.pbRichText.Visible = true;
                        this.tsbShowDetail.Image = this.CarImageList.Images["Down"];
                        this.tsbShowDetail.ToolTipText = "隐藏车辆详细信息";
                        if (!string.IsNullOrEmpty(tn.Latitude))
                        {
                            MainForm.myMap.excuteSpatialQueryById(tn.CarId, tn.Longitude, tn.Latitude);
                        }
                    }
                    this.ShowCarDetail(tn);
                    if (Variable.sShowTogether.Equals("1"))
                    {
                        MainForm.myLogForms.myCurrentPos.showNodeRecord(tn.CarId);
                    }
                }
            }
        }

        private void tvTrackCar_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.ImageKey = "Folder_Collapse";
                e.Node.SelectedImageKey = "Folder_Collapse";
            }
        }

        private void tvTrackCar_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.ImageKey = "Folder_Expand";
                e.Node.SelectedImageKey = "Folder_Expand";
            }
        }

        private void tvTrackCar_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ThreeStateTreeNode node = e.Node as ThreeStateTreeNode;
            this.tvTrackCar.setSelectNode(node);
            this.setNodeFontDefault(node);
            if (this.pbRichText.Visible)
            {
                try
                {
                    ThreeStateTreeNode tn = this.tvList.getNodeById(node.CarId);
                    if (((tn != null) && (tn.Tag != null)) && tn.Tag.Equals("CAR"))
                    {
                        this.ShowCarDetail(tn);
                        if (!string.IsNullOrEmpty(tn.Latitude))
                        {
                            MainForm.myMap.excuteSpatialQueryById(tn.CarId, tn.Longitude, tn.Latitude);
                        }
                    }
                    else
                    {
                        this.rtxtCarDetail.Text = "";
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("更改选中节点事件", exception.Message);
                }
            }
        }

        private void tvTrackCar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.setAMenuEnable();
            }
        }

        private void tvTrackCar_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node.Tag != null) || e.Node.Tag.Equals("CAR"))
            {
                ThreeStateTreeNode tn = this.tvList.getNodeById(e.Node.Name);
                if (tn != null)
                {
                    this.ShowCarDetail(tn);
                }
                this.setNodeFontDefault(e.Node as ThreeStateTreeNode);
            }
        }

        private void tvTrackCar_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && e.Node.Tag.ToString().Equals("CAR"))
            {
                MainForm.myMap.setTrackingCar(e.Node.Name);
                ThreeStateTreeNode tn = this.tvList.getNodeById(e.Node.Name);
                if (tn == null)
                {
                    return;
                }
                if (!this.pbRichText.Visible)
                {
                    this.pbRichText.Visible = true;
                    this.tsbShowDetail.Image = this.CarImageList.Images["Down"];
                    this.tsbShowDetail.ToolTipText = "隐藏车辆详细信息";
                    if (!string.IsNullOrEmpty(tn.Latitude))
                    {
                        MainForm.myMap.excuteSpatialQueryById(tn.CarId, tn.Longitude, tn.Latitude);
                    }
                }
                this.ShowCarDetail(tn);
                this.setNodeFontDefault(e.Node as ThreeStateTreeNode);
            }
            if ((e.Node.Level == 1) && (e.Node.Parent != null))
            {
                DataRow row = this.m_dtCarAlermList.Rows.Find(e.Node.Name);
                if (row != null)
                {
                    string alermType = row["statuName"].ToString();
                    string gpsTime = row["ReceTime"].ToString();
                    string longitude = row["Longitude"].ToString();
                    string latitude = row["Latitude"].ToString();
                    new CarAlerm(e.Node.Name, alermType, gpsTime, longitude, latitude).ShowDialog();
                }
            }
        }

        private void txtCarNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                if (this.tvTrackCar.Visible)
                {
                    this.execSearchAlarmCar();
                }
                else
                {
                    this.execSearchCar();
                }
            }
        }

        private void updCarPlace(int iType, ThreeStateTreeNode node)
        {
            try
            {
                string showText = string.Empty;
                if (!Variable.sJGShowCar.Equals("0"))
                {
                    string reg = "[\u4e00-\u9fa5][A-Z][A-Z0-9]{5}$";
                    if (Variable.sJGShowCar.Equals("1"))
                    {
                        showText = new Regex(reg).Replace(node.CarNum, "").TrimEnd(new char[]{' ', '-'});
                    }
                    else
                    {
                        showText = new Regex(reg).Match(node.CarNum).Value;
                    }
                }
                if (string.IsNullOrEmpty(showText))
                {
                    showText = node.CarNum;
                }
                if (iType == 0)
                {
                    MainForm.myMap.excuteSpatialQueryById(node.CarId, node.Longitude, node.Latitude);
                }
                else if (iType == 1)
                {
                    node.SetNodeText(string.Format("{0}({1})", showText, node.Place));
                    ThreeStateTreeNode node2 = this.tvTrackCar.getNodeById(node.CarId);
                    if (node2 != null)
                    {
                        node2.SetNodeText(string.Format("{0}({1})", showText, node.Place));
                    }
                    node2 = null;
                }
            }
            catch (Exception exception)
            {
                if (Variable.bLogin)
                {
                    Record.execFileRecord("设置车辆位置信息updCarPlace", exception.Message);
                }
            }
        }

        private void worker_SetWatchCar_DoWork(object sender, DoWorkEventArgs e)
        {
            ThreeStateTreeNode argument = e.Argument as ThreeStateTreeNode;
            if (argument != null)
            {
                bool flag = argument.Checked;
                object[] oParam = new object[] { argument.Name, !argument.Tag.Equals("CAR"), !flag };
                if (execSetWatchCar(oParam) != 0)
                {
                    string format = "对{0} {1} 的监控状态更新失败！";
                    if (argument.Tag.Equals("CAR"))
                    {
                        e.Result = string.Format(format, "车辆", argument.CarNum);
                    }
                    else
                    {
                        e.Result = string.Format(format, "区域", argument.AreaName);
                    }
                    this.worker_SetWatchCar.ReportProgress(100);
                }
                else
                {
                    base.Invoke(this.myCheckChange, new object[] { argument });
                    if (flag)
                    {
                        this.cancelWatchNode(argument);
                    }
                    //else
                    //{
                    //    if(argument.Tag.Equals("CAR") && !string.IsNullOrEmpty(argument.Longitude) && !string.IsNullOrEmpty(argument.Longitude))
                    //    {
                    //        //在地图上添加离线车辆
                    //        string str = "xxx";
                    //        MainForm.myMap.execShowCar(argument.CarNum, argument.Longitude, argument.Latitude, 100, 1, null, str, "4", "0", false, false, true, argument.CarId);
                    //    }
                    //}
                    this.worker_SetWatchCar.ReportProgress(100);
                }
            }
        }

        private void worker_SetWatchCar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string str = "";
            try
            {
                str = e.Result.ToString();
            }
            catch
            {
            }
            finally
            {
                this.tvList.Enabled = true;
                WaitForm.Hide();
                this.worker_SetWatchCar = null;
            }
            if (!string.IsNullOrEmpty(str))
            {
                MessageBox.Show(str);
            }
        }

        private void workerRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = this.setCarList();
        }

        private void workerRefresh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            base.Enabled = true;
            if (e.Result == null)
            {
                WaitForm.Hide();
                Record.execFileRecord("worker2_RunWorkerCompleted", "异步下载车辆列表失败！" + e.Error);
                MainForm.myLogForms.myNewLog.AddUserMessageToNewLog("获取车辆列表失败！");
            }
            else
            {
                try
                {
                    DataTable result = e.Result as DataTable;
                    this.CreateCarList(result);
                    this.setAlarmCarList();
                    this.setAreaText();
                    if (this.m_sCheckedCar != "")
                    {
                        this.setCheckCar();
                    }
                    ((MainForm)base.ParentForm).setMenuVisible();
                    this.tcCarList_SelectedIndexChanged(sender, e);
                    this.AutoCheckAllCar();
                    this.tUpdateCarPlace.Interval = 10000.0;
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("worker2_RunWorkerCompleted", exception.StackTrace);
                }
                finally
                {
                    WaitForm.Hide();
                }
            }
        }

        public DataTable AlarmCarList
        {
            get
            {
                return this.m_dtCarAlermList;
            }
        }

        public DataTable AllCar
        {
            get
            {
                return this.GetAllCar();
            }
        }

        public DataTable AreaList
        {
            get
            {
                return this.m_dtAllAreaList;
            }
        }

        public string SelectedCarId
        {
            get
            {
                return this.GetSelectedCarValue("CarId");
            }
        }

        public string SelectedCarNum
        {
            get
            {
                return this.GetSelectedCarValue("CarNum");
            }
        }

        public string SelectedSimNum
        {
            get
            {
                return this.GetSelectedCarValue("SimNum");
            }
        }

        private delegate void dCheckChange(ThreeStateTreeNode tn);

        private delegate void dSetAlarmText(DataRow myRow);

        private delegate void dSetAreaText(ThreeStateTreeNode myNode);

        public delegate void dSetCarStatus(ThreeStateTreeNode myNode, string sKey);

        private delegate void dSetChangeNodeAddress();

        private delegate void dSetEnabled(bool bEnabled);

        private delegate void dSetShowTipText(string sValue);

        private delegate void dShowCarDetail(ThreeStateTreeNode tn);

        private delegate void dUpdatePlace(int iType, ThreeStateTreeNode node);
    
    }
}
