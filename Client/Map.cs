using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Controls;
using Remoting;
using Client.M2M;
using System.Collections;
using PublicClass;
using System.Text.RegularExpressions;
using Library;

namespace Client
{
    [System.Runtime.InteropServices.ComVisible(true)]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public partial class Map : Client.ToolWindow
    {
        private bool m_bMapReaded;
        private PointType m_PointType;
        private static string m_sMapErr = "读取地图失败！\r\n地图相关功能将无法使用！";
        private System.Timers.Timer m_tShowCar;
        private QueryCarInfo myQueryCarInfo;
        public dShowCar myShowCar;
        public dShowFlag myShowFlag;
        public m2mSmallArea mySmallArea;
        public Queue queueList = new Queue();

        private BackgroundWorker showFlagWorker;
        private BackgroundWorker showRegionWorker;
        private BackgroundWorker showPathWorker;

        private bool[] workStates = new bool[3];
        public Map()
        {
            this.InitializeComponent();
        }

        public void ClearAllCar()
        {
            try
            {
                MainForm.mySearchCarList.tvSearchCarListNodesClear();
                this.delAllCar();
                MainForm.myCarList.setAllCarOffline();
            }
            catch
            {
            }
        }

        private void DataCopy(DataTable dtShowCar)
        {
            if (!this.queueList.Contains(dtShowCar))
            {
                lock (this.queueList)
                {
                    this.queueList.Enqueue(dtShowCar);
                }
                if (this.queueList.Count > Variable.iMaxCnt)
                {
                    MainForm.setUpdateEnabled(false);
                }
            }
        }

        public void delAllCar()
        {
            this.wbMap.delAllCar();
        }

        public void deleteSpatialQueryFlag()
        {
            this.wbMap.deleteSpatialQueryFlag();
        }

        public void excuteSpatialQueryById(string sCarId, string sLon, string sLat)
        {
            try
            {
                this.wbMap.excuteSpatialQueryById(sCarId, sLon, sLat);
            }
            catch
            {
            }
        }

        public void execClearAllAlarm()
        {
            this.wbMap.execClearAllPolygon();
            this.wbMap.execClearAllPath();
        }

        public void execClearAllFlag()
        {
            this.wbMap.execClearAllFlag();
        }

        public void execClearPath()
        {
            string selectedCarId = MainForm.myCarList.SelectedCarId;
            string selectedCarNum = MainForm.myCarList.SelectedCarNum;
            DataTable table = RemotingClient.Car_GetAlarmPathDotFromGisCar(selectedCarId);
            if ((table != null) && (table.Rows.Count > 0))
            {
                string[] strArray = table.Rows[0]["alarmPathDot"].ToString().Split(new char[] { '*' });
                if ((strArray.Length >= 1) && ((strArray.Length != 1) || (strArray[0].Length != 0)))
                {
                    foreach (string str4 in strArray)
                    {
                        string sPathName = "";
                        string[] strArray2 = str4.Split(new char[] { '\\' });
                        if (strArray2.Length > 1)
                        {
                            string str6 = strArray2[0];
                            sPathName = string.Format("【{0} {1}号路线】", selectedCarNum, str6);
                            this.wbMap.execClearPath(sPathName);
                        }
                    }
                }
            }
        }

        public void execClearTrack(string sCarId)
        {
            this.wbMap.execClearTrack(sCarId);
        }

        public void execDeleteCar(string sCarId)
        {
            this.wbMap.execDeleteCar(sCarId);
        }

        public void execExcuteTrackPointQuerty(string sQueryType, string sRequesId, string sLon, string sLat)
        {
            try
            {
                this.wbMap.execExcuteTrackPointQuerty(sQueryType, sRequesId, sLon, sLat);
            }
            catch
            {
            }
        }

        public void execExcuteTrackPointQuerty(string sQueryType, string sRequesId, string sLon, string sLat, bool IsFilterRoadInfo)
        {
            try
            {
                this.wbMap.execExcuteTrackPointQuerty(sQueryType, sRequesId, sLon, sLat, IsFilterRoadInfo);
            }
            catch
            {
            }
        }

        public void execMapChangeBaseLayer(string sText, string sValue)
        {
            this.wbMap.execMapChangeBaseLayer(sText, sValue);
        }

        public void execRefrshMap()
        {
            try
            {
                this.m_bMapReaded = false;
                this.setWaitForm(0);
                this.wbMap.AllowNavigation = true;
                this.wbMap.Url = new Uri(Variable.MapUrl);
            }
            catch (Exception exception)
            {
                this.picLoadMap.Visible = false;
                this.setWaitForm(1);
                MessageBox.Show(m_sMapErr);
                Record.execFileRecord("刷新地图", exception.Message);
            }
        }

        public void execSelectSpace(string sKey)
        {
            this.wbMap.execSelectSpace(sKey);
        }

        public void execShowAlarmRegion(ShowRegionType showRegionType)
        {
            string selectedCarId = MainForm.myCarList.SelectedCarId;
            string selectedCarNum = MainForm.myCarList.SelectedCarNum;
            string str3 = "";
            int num = -10;
            int iRegionFeature = 0;
            switch (showRegionType)
            {
                case ShowRegionType.越出区域:
                    str3 = "越出";
                    num = 0;
                    iRegionFeature = 0;
                    break;

                case ShowRegionType.进入区域:
                    str3 = "进入";
                    num = 1;
                    iRegionFeature = 0;
                    break;

                case ShowRegionType.多功能越出区域:
                    str3 = "多功能越出";
                    num = 0;
                    iRegionFeature = 1;
                    break;

                case ShowRegionType.多功能进入区域:
                    str3 = "多功能进入";
                    num = 1;
                    iRegionFeature = 1;
                    break;
            }
            DataTable table = RemotingClient.Car_GetRegionInfo(selectedCarId, iRegionFeature);
            if (table == null)
            {
                MessageBox.Show("获取区域信息失败！");
            }
            else
            {
                DataRow[] rowArray = !table.Columns.Contains("AlarmFlag") ? table.Select("regionType='" + num + "'") : table.Select("AlarmFlag is not null");
                if (table.Columns.Contains("AlarmFlag"))
                {
                    List<DataRow> list = new List<DataRow>();
                    foreach (DataRow row in rowArray)
                    {
                        char[] chArray = Convert.ToString(Convert.ToInt32(row["AlarmFlag"]), 2).PadLeft(6, '0').ToCharArray();
                        if (((showRegionType == ShowRegionType.多功能进入区域) && (chArray[2] != '1')) && (chArray[3] != '1'))
                        {
                            row.Delete();
                        }
                        else if (((showRegionType == ShowRegionType.多功能越出区域) && (chArray[0] != '1')) && (chArray[1] != '1'))
                        {
                            row.Delete();
                        }
                        else
                        {
                            list.Add(row);
                        }
                    }
                    rowArray = list.ToArray();
                }
                if ((rowArray != null) && (rowArray.Length <= 0))
                {
                    MessageBox.Show(string.Format("该车辆没有设置{0}报警区域", str3));
                }
                else
                {
                    foreach (DataRow row2 in rowArray)
                    {
                        this.showRegion(row2["regionDot"].ToString(), string.Format("【{0} {1}号报警区域】", selectedCarNum, row2["NewRegionId"].ToString()));
                    }
                }
            }
        }

        public void execShowAlarmRegion_back(ShowRegionType showRegionType)
        {
            string selectedCarId = MainForm.myCarList.SelectedCarId;
            string selectedCarNum = MainForm.myCarList.SelectedCarNum;
            string str3 = "";
            switch (showRegionType)
            {
                case ShowRegionType.越出区域:
                    str3 = "越出";
                    break;

                case ShowRegionType.进入区域:
                    str3 = "进入";
                    break;

                case ShowRegionType.多功能越出区域:
                    str3 = "多功能越出";
                    break;

                case ShowRegionType.多功能进入区域:
                    str3 = "多功能进入";
                    break;
            }
            DataTable table = RemotingClient.Car_GetCarAlarmRegionInfo(selectedCarId);
            if (table == null)
            {
                MessageBox.Show("获取区域信息失败！");
            }
            else if (table.Rows.Count <= 0)
            {
                MessageBox.Show(string.Format("该车辆没有设置{0}报警区域", str3));
            }
            else
            {
                string[] strArray;
                string sRegionDot = table.Rows[0]["regionDot"].ToString();
                if ((showRegionType == ShowRegionType.进入区域) || (showRegionType == ShowRegionType.多功能进入区域))
                {
                    strArray = this.getInRegionStr(sRegionDot).Split(new char[] { '*' });
                }
                else
                {
                    strArray = this.getOutRegionStr(sRegionDot).Split(new char[] { '*' });
                }
                if ((strArray.Length < 1) || ((strArray.Length == 1) && (strArray[0].Length == 0)))
                {
                    MessageBox.Show(string.Format("该车辆没有设置{0}报警区域", str3));
                }
                else
                {
                    foreach (string str5 in strArray)
                    {
                        string sLongitude = "";
                        string sLatitude = "";
                        string circleName = "";
                        string[] strArray2 = str5.Split(new char[] { '\\' });
                        if (strArray2.Length > 2)
                        {
                            string str9 = strArray2[0];
                            circleName = string.Format("【{0} {1}号报警区域】", selectedCarNum, str9);
                            if (strArray2.Length == 5)
                            {
                                double centerPointX = double.Parse(strArray2[2]);
                                double centerPointY = double.Parse(strArray2[3]);
                                int radius = int.Parse(strArray2[4]);
                                this.wbMap.showCircle(circleName, centerPointX, centerPointY, radius);
                            }
                            else
                            {
                                int num4 = strArray2.Length / 2;
                                for (int i = 1; i < num4; i++)
                                {
                                    sLongitude = sLongitude + strArray2[i * 2] + ",";
                                    sLatitude = sLatitude + strArray2[(i * 2) + 1] + ",";
                                }
                                sLongitude = sLongitude.Trim(new char[] { ',' });
                                sLatitude = sLatitude.Trim(new char[] { ',' });
                                this.wbMap.showpolygonForCS(circleName, sLongitude, sLatitude, true);
                            }
                        }
                    }
                }
            }
        }

        public void execShowCar(DataRow dr)
        {
            if (this.m_bMapReaded)
            {
                this.ShowCar(dr);
            }
        }

        private void execShowCar(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (this.m_bMapReaded)
                {
                    this.m_tShowCar.Interval = 60000.0;
                    if (this.queueList.Count <= Variable.iMaxCnt)
                    {
                        MainForm.setUpdateEnabled(true);
                    }
                    if (this.queueList.Count <= 0)
                    {
                        this.m_tShowCar.Interval = 1000.0;
                        if (this.queueList == null)
                        {
                            this.queueList = new Queue();
                        }
                    }
                    else
                    {
                        DataTable table = new DataTable();
                        try
                        {
                            table = this.queueList.Dequeue() as DataTable;
                            if ((table != null) && (table.Rows.Count > 0))
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    base.Invoke(this.myShowCar, new object[] { row });
                                }
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            this.m_tShowCar.Interval = 10000.0;
                        }
                        catch (Exception exception)
                        {
                            if (Variable.bLogin)
                            {
                                Record.execFileRecord("显示车辆（集合）", exception.ToString());
                            }
                        }
                        finally
                        {
                            if (table != null)
                            {
                                table.Clear();
                                table.Dispose();
                                table = null;
                            }
                            if (this.queueList.Count > 0)
                            {
                                this.m_tShowCar.Interval = 100.0;
                            }
                            else
                            {
                                this.m_tShowCar.Interval = 1000.0;
                                this.queueList = null;
                                this.queueList = new Queue();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void execShowCar(object sCarNum, object x, object y, object iDirection, object iIconType, object IsZoom, object sHintText, object iCarStatus, object iAlarmType, object bIsFill, object bAccOn, object bGpsValid, object sCarId)
        {
            if (this.m_bMapReaded)
            {
                this.wbMap.execShowCar(sCarNum, x, y, iDirection, iIconType, IsZoom, sHintText, iCarStatus, iAlarmType, bIsFill, bAccOn, bGpsValid, sCarId, false);
            }
        }

        public void execShowPath()
        {
            string selectedCarId = MainForm.myCarList.SelectedCarId;
            string selectedCarNum = MainForm.myCarList.SelectedCarNum;
            DataTable table = RemotingClient.Car_GetAlarmPathDotFromGisCar(selectedCarId);
            if (table == null)
            {
                MessageBox.Show("获取偏移路线信息失败！");
            }
            else if (table.Rows.Count <= 0)
            {
                MessageBox.Show("该车辆没有设置偏移路线报警");
            }
            else
            {
                string[] strArray = table.Rows[0]["alarmPathDot"].ToString().Split(new char[] { '*' });
                if ((strArray.Length < 1) || ((strArray.Length == 1) && (strArray[0].Length == 0)))
                {
                    MessageBox.Show("该车辆没有设置偏移路线报警");
                }
                else
                {
                    foreach (string str4 in strArray)
                    {
                        string sLongitude = "";
                        string sLatitude = "";
                        string sPathName = "";
                        string[] strArray2 = str4.Split(new char[] { '\\' });
                        if (strArray2.Length > 1)
                        {
                            string str8 = strArray2[0];
                            sPathName = string.Format("【{0} {1}号路线】", selectedCarNum, str8);
                            int num = (strArray2.Length - 1) / 2;
                            for (int i = 0; i < num; i++)
                            {
                                sLongitude = sLongitude + strArray2[(i * 2) + 1] + ",";
                                sLatitude = sLatitude + strArray2[(i * 2) + 2] + ",";
                            }
                            sLongitude = sLongitude.Trim(new char[] { ',' });
                            sLatitude = sLatitude.Trim(new char[] { ',' });
                            this.wbMap.execShowPath(sPathName, sLongitude, sLatitude, true);
                        }
                    }
                }
            }
        }

        public void execStopPlayTrackLine(string sQueryType)
        {
            try
            {
                this.wbMap.execStopPlayTrackLine(sQueryType);
            }
            catch
            {
            }
        }

        private string getInRegionStr(string sRegionDot)
        {
            string str = "";
            foreach (string str2 in sRegionDot.Split(new char[] { '*' }))
            {
                string[] strArray2 = str2.Split(new char[] { '\\' });
                if ((strArray2.Length > 2) && ((int.Parse(strArray2[1]) == 1) || (int.Parse(strArray2[1]) == 2)))
                {
                    str = str2 + "*" + str;
                }
            }
            return str.Trim(new char[] { '*' });
        }

        public string getMapView()
        {
            try
            {
                return this.wbMap.getMapView();
            }
            catch
            {
            }
            return null;
        }

        private string getOutRegionStr(string sRegionDot)
        {
            string str = "";
            foreach (string str2 in sRegionDot.Split(new char[] { '*' }))
            {
                string[] strArray2 = str2.Split(new char[] { '\\' });
                if ((strArray2.Length > 2) && ((int.Parse(strArray2[1]) == 0) || (int.Parse(strArray2[1]) == 2)))
                {
                    str = str2 + "*" + str;
                }
            }
            return str.Trim(new char[] { '*' });
        }

        public object getTrackPointQueryInfo(string sQueryType)
        {
            try
            {
                return this.wbMap.getTrackPointQueryInfo(sQueryType);
            }
            catch
            {
                return null;
            }
        }

        public void initMap()
        {
            try
            {
                this.setWaitForm(0);
                this.wbMap.Url = null;
                this.wbMap.Url = new Uri(Variable.MapUrl);
            }
            catch (Exception exception)
            {
                WaitForm.Hide();
                WaitForm.Hide2();
                MessageBox.Show(m_sMapErr);
                Record.execFileRecord("地图初始化", exception.Message);
            }
        }

        private void Map_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.m_tShowCar.Enabled = false;
            }
            catch
            {
            }
        }

        private void Map_Load(object sender, EventArgs e)
        {
            Point point = new Point((base.Width / 2) - 85, (base.Height / 2) - 17);
            this.picLoadMap.Location = point;
            try
            {
                this.setWaitForm(0);
                this.wbMap.Url = new Uri(Variable.MapUrl);
            }
            catch (Exception exception)
            {
                this.picLoadMap.Visible = false;
                this.setWaitForm(1);
                MessageBox.Show(m_sMapErr);
                Record.execFileRecord("地图初始化", exception.Message);
                return;
            }
            this.myShowFlag = new dShowFlag(this.showFlag);
            this.myShowCar = new dShowCar(this.ShowCar);
            this.m_tShowCar = new System.Timers.Timer(1000.0);
            this.m_tShowCar.Elapsed += new System.Timers.ElapsedEventHandler(this.execShowCar);
            this.m_tShowCar.Enabled = true;
        }

        private void MenuAddPoint_Click(object sender, EventArgs e)
        {
            this.setPointTool();
        }

        private void MenuClearAlarmRegion_Click(object sender, EventArgs e)
        {
            this.execClearAllAlarm();
        }

        private void MenuClearAllCar_Click(object sender, EventArgs e)
        {
            this.ClearAllCar();
        }

        private void MenuClearImage_Click(object sender, EventArgs e)
        {
            this.deleteSpatialQueryFlag();
        }

        private void MenuDelPoint_Click(object sender, EventArgs e)
        {
            this.setDelPoint();
        }

        private void MenuZoomToMapCenter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variable.sMapSign))
            {
                MessageBox.Show("未设置标志点！");
            }
            else
            {
                this.setMap(Variable.sMapSign);
            }
        }

        public void MouseWheel(int i)
        {
            if (i > 0)
            {
                this.wbMap.fixZoomIn();
            }
            else if (i < 0)
            {
                this.wbMap.fixZoomOut();
            }
        }

        public void setArrowheadTool()
        {
            this.wbMap.setgetCarIDTool();
        }

        public void setCarAlarm(object sCarId, object isalarm)
        {
            try
            {
                this.wbMap.setCarAlarm(sCarId, isalarm);
            }
            catch
            {
            }
        }

        public void setCircleMesTool()
        {
            this.wbMap.setCircleMesTool();
        }

        public void setClickZoomDownTool()
        {
            this.wbMap.setClickZoomDownTool();
        }

        public void setClickZoomUpTool()
        {
            this.wbMap.setClickZoomUpTool();
        }

        public void setDelPoint()
        {
            this.wbMap.setDelPoint();
        }

        public void setDistributary()
        {
            try
            {
                object obj2 = this.wbMap.getCurrentPoint();
                if (obj2 != null)
                {
                    string[] strArray = obj2.ToString().Split(new char[] { ';' });
                    itmZBDistributary module = (itmZBDistributary)Program.mainForm.GetModule("itmZBDistributary");
                    module.Longitude = strArray[0];
                    module.Latitude = strArray[1];
                    module.ShowDialog();
                    this.setPanTool();
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("鼠标点击地图事件->分流短信", exception.Message);
            }
        }

        public void setDistributaryTool()
        {
            this.wbMap.setPointTool();
            this.m_PointType = PointType.分流短信;
        }

        public void setMap(string sExtend)
        {
            try
            {
                this.wbMap.setMap(sExtend);
            }
            catch
            {
            }
        }

        public void setMapToCenter()
        {
            this.wbMap.setMapToCenter();
        }

        public void setMapToolAddPoints(GisMap CurrentMap)
        {
            try
            {
                object obj2 = CurrentMap.getCurrentPoint();
                if (obj2 != null)
                {
                    string[] strArray = obj2.ToString().Split(new char[] { ';' });
                    new MapFlag(strArray[0], strArray[1], CurrentMap).ShowDialog();
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("鼠标点击地图事件->增加地图标注", exception.Message);
            }
        }

        public void setMapToolDelPoints(GisMap CurrentMap)
        {
            try
            {
                object obj2 = CurrentMap.getFlagName();
                if ((obj2 != null) && !string.IsNullOrEmpty(obj2.ToString()))
                {
                    string[] sFlag = obj2.ToString().Split(new char[] { '|' });
                    if (DialogResult.OK == MessageBox.Show(string.Format("请确认是否删除标注\"{0}\"", sFlag[0]), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        if (RemotingClient.MapFlag_DeleteFlagMap(sFlag[0]))
                        {
                            CurrentMap.execDeleteFlag(sFlag);
                        }
                        else
                        {
                            MessageBox.Show("删除标注失败！");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("鼠标点击地图事件->删除标注", exception.Message);
            }
        }

        private void setMapToolQueryCarInfo()
        {
            try
            {
                object obj2 = this.wbMap.getZoomBoxPoints();
                if (obj2 != null)
                {
                    string str = obj2.ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] sPoints = str.Split(new char[] { ';' });
                        if ((sPoints.Length >= 2) && ((sPoints.Length != 2) || (sPoints[0] != sPoints[1])))
                        {
                            if ((this.myQueryCarInfo == null) || !this.myQueryCarInfo.IsHandleCreated)
                            {
                                this.myQueryCarInfo = new QueryCarInfo(sPoints);
                                this.myQueryCarInfo.Show(this);
                                this.setPanTool();
                            }
                            else
                            {
                                this.myQueryCarInfo.execRefRegion(sPoints);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("鼠标点击地图事件->日期查车", exception.Message);
            }
        }

        private void setMapToolSearchCar()
        {
            try
            {
                object obj2 = this.wbMap.getZoomBoxPoints();
                if (obj2 != null)
                {
                    string str = obj2.ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] strArray = str.Split(new char[] { ';' });
                        if ((strArray.Length >= 2) && ((strArray.Length != 2) || (strArray[0] != strArray[1])))
                        {
                            string[] strArray2 = str.Replace(";", ",").Split(new char[] { ',' });
                            str = strArray[0] + ";";
                            str = ((str + strArray2[0] + "," + strArray2[3] + ";") + strArray[1] + ";") + strArray2[2] + "," + strArray2[1];
                            if (MessageBox.Show(this, "是否要查找所选择区域下的车辆？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                MainForm.mySearchCarList.execRefRegion(str);
                            }
                            else
                            {
                                this.wbMap.setPanTool();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("鼠标点击地图事件->拉框查车", exception.Message);
            }
        }

        private void setMapToolSmallArea()
        {
            object obj2 = this.wbMap.getZoomBoxPoints();
            if (obj2 != null)
            {
                string str = obj2.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray = str.Split(new char[] { ';' });
                    if ((strArray.Length >= 2) && ((strArray.Length != 2) || (strArray[0] != strArray[1])))
                    {
                        this.mySmallArea = new m2mSmallArea(str);
                        this.mySmallArea.Show(this);
                    }
                }
            }
        }

        public void setMeasureTool()
        {
            this.wbMap.setMeasureTool();
        }

        public void setNavigation()
        {
            try
            {
                object obj2 = this.wbMap.getCurrentPoint();
                if (obj2 != null)
                {
                    string[] strArray = obj2.ToString().Split(new char[] { ';' });
                    itmZBNavigation module = (itmZBNavigation)Program.mainForm.GetModule("itmZBNavigation");
                    module.Longitude = strArray[0];
                    module.Latitude = strArray[1];
                    module.ShowDialog();
                    this.setPanTool();
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("鼠标点击地图事件->一键导航", exception.Message);
            }
        }

        public void setNavigationTool()
        {
            this.wbMap.setPointTool();
            this.m_PointType = PointType.一键导航;
        }

        public void setPanTool()
        {
            this.wbMap.setPanTool();
        }

        public void setPathToolSTD()
        {
            this.wbMap.setPathToolSTD();
        }

        public void setPointTool()
        {
            this.wbMap.setPointTool();
            this.m_PointType = PointType.标注地图;
        }

        public void setPolygonMesTool()
        {
            this.wbMap.setPolygonMesTool();
        }

        public void setQuerySearchCar()
        {
            this.wbMap.setQuerySearchCar();
        }

        public void setRectangleMesTool()
        {
            this.wbMap.setRectangleMesTool();
        }

        public void setSearchCar()
        {
            this.wbMap.setZoomBoxExTool();
        }

        public void setShowCar(DataTable dtCarList, bool IsAlarm)
        {
            if (this.m_bMapReaded && (dtCarList != null))
            {
                try
                {
                    if (MainForm.myCarList.m_dtCarAlermList != null)
                    {
                        foreach (DataRow row in dtCarList.Select("CarStatus<>'1'"))
                        {
                            if (MainForm.myCarList.m_dtCarAlermList.Rows.Find(row["CarId"]) != null)
                            {
                                row["CarStatus"] = "1";
                            }
                        }
                    }
                    this.DataCopy(dtCarList.Copy());
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("设置显示车辆集合", exception.Message);
                }
                finally
                {
                    if (dtCarList != null)
                    {
                        dtCarList = null;
                    }
                }
            }
        }

        public void setSmallArea()
        {
            this.wbMap.setSmallArea();
        }

        private void SetToMapCenter()
        {
            try
            {
                string str = this.getMapView();
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("设置标志点失败！");
                }
                else
                {
                    object obj2 = this.wbMap.getCurrentPoint();
                    if (obj2 != null)
                    {
                        string[] strArray = str.Split(new char[] { ',' });
                        string[] strArray2 = obj2.ToString().Split(new char[] { ';' });
                        strArray[0] = strArray2[0];
                        strArray[1] = strArray2[1];
                        str = "";
                        foreach (string str2 in strArray)
                        {
                            str = str + str2 + ",";
                        }
                        str = str.Trim(new char[] { ',' });
                    }
                    if (string.IsNullOrEmpty(str))
                    {
                        MessageBox.Show("设置标志点失败！");
                    }
                    else
                    {
                        Variable.sMapSign = str;
                        MessageBox.Show("设置标志点成功！");
                        this.wbMap.setPanTool();
                        if (!string.IsNullOrEmpty(ToolWindow.myMainForm.SelectMapValue))
                        {
                            Variable.sSelectedMap = ToolWindow.myMainForm.SelectMapValue;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void setTrackingCar(string sCarId)
        {
            this.wbMap.setTrackingCar(sCarId);
        }

        public void setWaitForm(int iFlag)
        {
            this.picLoadMap.Visible = iFlag == 0;
        }

        public void setZoomCar(string sCarId)
        {
            this.wbMap.zoomToCar(sCarId);
        }

        public void setZoomDownTool()
        {
            this.wbMap.setZoomDownTool();
        }

        public void setZoomToCenter()
        {
            this.wbMap.setZoomToCenter();
        }

        public void setZoomUpTool()
        {
            this.wbMap.setZoomUpTool();
        }

        public void showAllFlagMap()
        {
            DataTable table = RemotingClient.MapFlag_showFlagMap();
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    base.Invoke(this.myShowFlag, new object[] { row });
                }
                catch
                {
                }
            }
            if (table != null)
            {
                table.Clear();
                table.Dispose();
                table = null;
            }
        }

        private void ShowCar(DataRow dr)
        {
            try
            {
                if (((MainForm.myImportReport == null) || (MainForm.myImportReport.m_dtImportCar == null)) || ((MainForm.myImportReport.m_dtImportCar.Rows.Count <= 0) || (MainForm.myImportReport.m_dtImportCar.Select("CarNum='" + dr["CarNum"].ToString() + "'").Length <= 0)))
                {
                    string str = null;
                    str = MainForm.myCarList.setMapTipDetail(dr);
                    string str2 = "";
                    str2 = (MainForm.EbillTextList[dr["carid"].ToString()] == null) ? "" : MainForm.EbillTextList[dr["carid"].ToString()].ToString();
                    if (string.IsNullOrEmpty(str))
                    {
                        string str3 = "关";
                        if ("1".Equals(dr["AccOn"].ToString()))
                        {
                            str3 = "开";
                        }
                        string sCarId = dr["CarId"].ToString();
                        ThreeStateTreeNode node = MainForm.myCarList.tvList.getNodeById(sCarId);
                        string str5 = (node == null) ? "未知" : node.PlateColor;
                        string str6 = (node == null) ? dr["Simnum"].ToString() : node.SimNum;
                        string str7 = (node == null) ? "未知" : node.DriverName;
                        string str8 = (node == null) ? "未知" : node.Company;
                        string str9 = (node == null) ? "未知" : node.TermSerial;
                        str = string.Format("车牌[{0}]车牌颜色[{6}]终端ID[{10}]Sim卡号[{7}]驾驶员[{8}]所属公司[{9}]ACC[{1}]GPS时间[{2}]；经度[{3}]纬度[{4}]速度[{5}km/h]", new object[] { dr["CarNum"].ToString(), str3, dr["gpsTime"].ToString(), dr["Longitude"].ToString(), dr["Latitude"].ToString(), dr["speed"].ToString(), str5, str6, str7, str8, str9 });
                        if (str2 != "")
                        {
                            str = str + string.Format("电子运单[{0}]", str2);
                        }
                        else
                        {
                            str = str + string.Format("电子运单[{0}]", "");
                        }
                    }
                    bool bIsFill = false;
                    bool bAccOn = false;
                    bool bGpsValid = false;
                    bool bIsShowTrack = false;
                    object iDirection = null;
                    if (dr["IsFill"].ToString() == "1")
                    {
                        bIsFill = true;
                    }
                    if (dr["AccOn"].ToString() == "1")
                    {
                        bAccOn = true;
                    }
                    if (dr["GpsValid"].ToString() == "1")
                    {
                        bGpsValid = true;
                    }
                    //修改当ACC关闭时，定位状态为无效的置为有效。
                    if (dr["GpsValid"].ToString() == "0" && dr["AccOn"].ToString() == "0")
                    {
                        bGpsValid = true;
                    }
                    if (dr.Table.Columns.Contains("Direct"))
                    {
                        iDirection = dr["Direct"];
                    }
                    string carAreaName = string.Empty;
                    if (Variable.sMapCarLegendShowAreaName.Equals("1", StringComparison.OrdinalIgnoreCase))
                    {
                        carAreaName = MainForm.myCarList.GetTreeNodeOfCar(dr["CarId"].ToString()).CarAreaName;
                    }

                    string showCarNum = string.Empty;
                    if (!Variable.sJGShowCar.Equals("0"))
                    {
                        string reg = "[\u4e00-\u9fa5][A-Z][A-Z0-9]{5}$";
                        if (Variable.sJGShowCar.Equals("1"))
                        {
                            showCarNum = new Regex(reg).Replace(dr["CarNum"].ToString(), "").TrimEnd(new char[] { ' ', '-' });
                        }
                        else
                        {
                            showCarNum = new Regex(reg).Match(dr["CarNum"].ToString()).Value;
                        }
                    }
                    if (string.IsNullOrEmpty(showCarNum))
                    {
                        showCarNum = dr["CarNum"].ToString();
                    }

                    this.wbMap.execShowCar(string.IsNullOrEmpty(carAreaName) ?
                        showCarNum : (carAreaName + " " + showCarNum)
                        , dr["Longitude"].ToString(), dr["Latitude"].ToString(), iDirection, 1, null, str, dr["CarStatus"].ToString(), dr["AlarmType"].ToString(), bIsFill, bAccOn, bGpsValid, dr["CarId"].ToString(), bIsShowTrack);
                    dr = null;
                }
            }
            catch
            {
            }
        }

        private void showFlag(GisMap map, DataRow dr)
        {
            try
            {
                map.ShowFlag(dr["flagName"].ToString(), dr["Lon"].ToString(), dr["Lat"].ToString(), "OpenLayers/img/" + dr["ICON"].ToString());
            }
            catch
            {
            }
        }

        public void showFlagMap(GisMap CurrentMap)
        {
            if (this.showFlagWorker == null)
            {
                this.showFlagWorker = new BackgroundWorker();
                this.showFlagWorker.DoWork += new DoWorkEventHandler(this.worder_DoWork);
                this.showFlagWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worder_RunWorkerCompleted);
                this.showFlagWorker.WorkerReportsProgress = true;
                this.showFlagWorker.RunWorkerAsync(CurrentMap);
            }
        }

        private void showRegion(string sRegionDots, string sRegionName)
        {
            string sLongitude = "";
            string sLatitude = "";
            string[] strArray = sRegionDots.Trim(new char[] { '*' }).Split(new char[] { '*' });
            if (strArray.Length == 1)
            {
                try
                {
                    string[] strArray2 = strArray[0].Split(new char[] { '\\' });
                    double centerPointX = double.Parse(strArray2[0]);
                    double centerPointY = double.Parse(strArray2[1]);
                    int radius = int.Parse(strArray2[2]);
                    this.wbMap.showCircle(sRegionName, centerPointX, centerPointY, radius);
                }
                catch
                {
                }
            }
            else
            {
                string[] strArray3 = sRegionDots.Trim(new char[] { '*' }).Replace(@"\", "*").Split(new char[] { '*' });
                if (strArray3.Length > 1)
                {
                    int num4 = strArray3.Length / 2;
                    for (int i = 0; i < num4; i++)
                    {
                        sLongitude = sLongitude + strArray3[i * 2] + ",";
                        sLatitude = sLatitude + strArray3[(i * 2) + 1] + ",";
                    }
                    sLongitude = sLongitude.Trim(new char[] { ',' });
                    sLatitude = sLatitude.Trim(new char[] { ',' });
                    object[] objArray = new object[] { sRegionName, sLongitude, sLatitude, true };
                    this.wbMap.showpolygonForCS(sRegionName, sLongitude, sLatitude, true);
                }
            }
        }

        public void showSelectedFlagMap(GisMap map)
        {
            string pOITypes = MainForm.POITypes;
            if (!string.IsNullOrEmpty(pOITypes))
            {
                DataTable table = RemotingClient.MapFlag_showFlagMap();
                if ((table != null) && (table.Rows.Count > 0))
                {
                    foreach (DataRow row in table.Select(" type in (" + pOITypes + ")"))
                    {
                        try
                        {
                            base.Invoke(this.myShowFlag, new object[] { map, row });
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void wbMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.wbMap.Document.Window.Error += (sender1, e1) => { e1.Handled = true; }; ///
            this.picLoadMap.Visible = false;
            if (this.wbMap.Url.ToString().Equals("about:blank"))
            {
                this.setWaitForm(2);
            }
            else if (this.wbMap.Document.GetElementById("map") == null)
            {
                ((MainForm)base.ParentForm).setToolEnable(false);
                this.setWaitForm(2);
                MessageBox.Show(m_sMapErr);
                Record.execFileRecord("加载地图", m_sMapErr);
            }
            else
            {
                this.m_bMapReaded = true;
                ((MainForm)base.ParentForm).setToolEnable(true);
                object obj2 = this.wbMap.getMapList();
                if (obj2 == null)
                {
                    this.setWaitForm(2);
                }
                else
                {
                    ((MainForm)base.ParentForm).setMap(obj2.ToString());
                    if (((MainForm)base.ParentForm).chkMapEnable(Variable.sSelectedMap))
                    {
                        ToolWindow.myMainForm.SelectMapValue = Variable.sSelectedMap;
                        this.setMap(Variable.sMapSign);
                    }
                    this.wbMap.AllowNavigation = false;
                    this.setWaitForm(2);
                    if ((MainForm.myCarList.m_dtCarAlermList != null) && (MainForm.myCarList.m_dtCarAlermList.Rows.Count > 0))
                    {
                        this.setShowCar(MainForm.myCarList.m_dtCarAlermList, true);
                    }
                    if (!Variable.sProjectID.Equals("zhongtong", StringComparison.OrdinalIgnoreCase))
                    {
                        WaitForm.Show("正在初始化地图标注，请稍候...", this);
                    }
                    this.showFlagMap(this.wbMap);
                    this.showPathMap(this.wbMap);
                    this.showRegionMap(this.wbMap);
                }
            }
        }

        private void wbMap_EndSelectSpace(object sender, HtmlElementEventArgs e)
        {
            try
            {
                string sResult = this.wbMap.getAttributionQueryResult().ToString();
                MainForm.mySearchFeature.setSearchResult(sResult);
            }
            catch
            {
            }
        }

        private void wbMap_MapDirectionEvent(object sender, HtmlElementEventArgs e)
        {
            object obj2 = this.wbMap.Document.InvokeScript("getDirectionStep");
            if (obj2 != null)
            {
                FixedForm form;
                WebBrowser browser = new WebBrowser
                {
                    DocumentText = obj2.ToString()
                };
                form = new FixedForm
                {
                    Size = new Size(334, 379),
                    ShowIcon = false,
                    Text = "路径分析结果",
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowInTaskbar = false,
                    MinimizeBox = false   ///hzh  //form.MaximizeBox = false
                };
                browser.Dock = DockStyle.Fill;
                form.Controls.Add(browser);
                form.ShowDialog();
                form = null;
            }
        }

        private void wbMap_MapSelectedCarEvent(object sender, HtmlElementEventArgs e)
        {
            try
            {
                string str = this.wbMap.getSelectedCarID().ToString();
                MainForm.clientObj.execSendObject(5, str);
                if (Variable.sShowTogether.Equals("1"))
                {
                    MainForm.myLogForms.myCurrentPos.showNodeRecord(str);
                    TreeNode[] nodeArray = MainForm.myCarList.tvList.Nodes.Find(str, true);
                    if ((nodeArray != null) && (nodeArray.Length > 0))
                    {
                        MainForm.myCarList.tvList.setSelectNode(nodeArray[0]);
                    }
                }
            }
            catch
            {
            }
        }

        private void wbMap_MapSpatialEvent(object sender, HtmlElementEventArgs e)
        {
            try
            {
                string sPlace = this.wbMap.getSpatialQueryResult().ToString();
                MainForm.myCarList.setCarParticularPlace(sPlace);
            }
            catch
            {
            }
        }

        private void wbMap_MouseMove(object sender, HtmlElementEventArgs e)
        {
        }

        private void wbMap_MouseUp(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                object obj2 = this.wbMap.getMapClicked();
                if ((obj2 != null) && bool.Parse(obj2.ToString()))
                {
                    switch (this.wbMap.m_sTool)
                    {
                        case GisMap.MapTool.标注地图:
                            switch (this.m_PointType)
                            {
                                case PointType.标注地图:
                                    this.setMapToolAddPoints(this.wbMap);
                                    return;

                                case PointType.一键导航:
                                    this.setNavigation();
                                    return;

                                case PointType.分流短信:
                                    this.setDistributary();
                                    return;
                            }
                            return;

                        case GisMap.MapTool.删除标注:
                            this.setMapToolDelPoints(this.wbMap);
                            return;

                        case GisMap.MapTool.设置区域:
                            return;

                        case GisMap.MapTool.设置矩形区域:
                            this.setMapToolSearchCar();
                            return;

                        case GisMap.MapTool.日期查车:
                            this.setMapToolQueryCarInfo();
                            return;

                        case GisMap.MapTool.小范围电召:
                            this.setMapToolSmallArea();
                            return;

                        case GisMap.MapTool.设置圆形区域:
                            this.SetToMapCenter();
                            return;
                    }
                }
            }
        }

        private void worder_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GisMap argument = e.Argument as GisMap;
                DataTable table = RemotingClient.MapFlag_FlagMapType();
                if ((table != null) && (table.Rows.Count > 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        MainForm.POITypes = MainForm.POITypes + row["id"].ToString() + ",";
                    }
                    MainForm.POITypes = MainForm.POITypes.Trim(new char[] { ',' });
                }
                this.showSelectedFlagMap(argument);
            }
            catch
            {
            }
        }

        private void worder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WaitForm.Hide2();
            try
            {
                this.showFlagWorker.DoWork -= new DoWorkEventHandler(this.worder_DoWork);
                this.showFlagWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.worder_RunWorkerCompleted);
                this.showFlagWorker = null;
            }
            catch
            {
            }
        }

        public void zoomToMaxExtent()
        {
            this.wbMap.zoomToMaxExtent();
        }

        public void zoonmToLonLat(string sLon, string sLat, string sName)
        {
            this.wbMap.zoonmToLonLat(sLon, sLat, sName);
        }

        public bool MapReaded
        {
            get
            {
                return this.m_bMapReaded;
            }
        }

        public delegate void dShowCar(DataRow drCar);

        public delegate void dShowFlag(GisMap map, DataRow dr);

        public enum PointType
        {
            标注地图,
            一键导航,
            分流短信
        }

        public enum ShowRegionType
        {
            多功能进入区域 = 4,
            多功能越出区域 = 3,
            进入区域 = 1,
            越出区域 = 0
        }

        public void showPathMap(GisMap gisMap)
        {
            if (this.showPathWorker == null)
            {
                this.showPathWorker = new BackgroundWorker();
                this.showPathWorker.DoWork += new DoWorkEventHandler(this.showPathWorker_DoWork);
                this.showPathWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.showPathWorker_RunWorkerCompleted);
                this.showPathWorker.WorkerReportsProgress = true;
                this.showPathWorker.RunWorkerAsync(gisMap);
            }
        }

        public void showRegionMap(GisMap gisMap)
        {
            if (this.showRegionWorker == null)
            {
                this.showRegionWorker = new BackgroundWorker();
                this.showRegionWorker.DoWork += new DoWorkEventHandler(this.showRegionWorker_DoWork);
                this.showRegionWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.showRegionWorker_RunWorkerCompleted);
                this.showRegionWorker.WorkerReportsProgress = true;
                this.showRegionWorker.RunWorkerAsync(gisMap);
            }
        }

        private void showPathWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.workStates[1] = true;
                this.showPathWorker.DoWork -= new DoWorkEventHandler(this.showPathWorker_DoWork);
                this.showPathWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.showPathWorker_RunWorkerCompleted);
                this.showPathWorker = null;
            }
            catch
            {
            }
            finally
            {
                if ((this.workStates[0] && this.workStates[1]) && this.workStates[2])
                {
                    WaitForm.Hide2();
                }
            }
        }


        private void showPathWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GisMap argument = e.Argument as GisMap;
                base.Invoke(new MethodInvoker(() => argument.execClearAllPath()));
                string str = "select * from GpsPathRegionShowInfo where UserId = '{0}' and Type = '1'";
                DataTable dataTable = RemotingClient.ExecSql(string.Format(str, Variable.sUserId));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    DataTable dataTable1 = RemotingClient.Alarm_GetPathInfo();
                    if (dataTable1 != null && dataTable.Rows.Count > 0)
                    {
                        string str1 = dataTable.Rows[0]["DotValue"].ToString();
                        if (!string.IsNullOrEmpty(str1))
                        {
                            string[] strArrays = str1.Split(new char[] { ',' });
                            for (int i = 0; i < (int)strArrays.Length; i++)
                            {
                                string str2 = strArrays[i];
                                DataRow[] dataRowArray = dataTable1.Select(string.Concat("PathId = '", str2, "'"));
                                if ((int)dataRowArray.Length != 0)
                                {
                                    string str3 = "";
                                    string str4 = "";
                                    string str5 = dataRowArray[0]["AlarmPathDot"].ToString();
                                    string str6 = dataRowArray[0]["pathName"].ToString();
                                    string[] strArrays1 = str5.Split(new char[] { '/' });
                                    for (int j = 0; j < (int)strArrays1.Length; j++)
                                    {
                                        string[] strArrays2 = strArrays1[j].Split(new char[] { '*' });
                                        if ((int)strArrays2.Length == 2)
                                        {
                                            str3 = string.Concat(str3, strArrays2[0], ",");
                                            str4 = string.Concat(str4, strArrays2[1], ",");
                                        }
                                    }
                                    str3.Trim(new char[] { ',' });
                                    str4.Trim(new char[] { ',' });
                                    base.Invoke(new MethodInvoker(() => argument.execShowPath(str6, str3, str4, false)));
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void showRegionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GisMap argument = e.Argument as GisMap;
                base.Invoke(new MethodInvoker(() => argument.execClearAllPolygon()));
                string str = "select * from GpsPathRegionShowInfo where UserId = '{0}' and Type = '2'";
                DataTable dataTable = RemotingClient.ExecSql(string.Format(str, Variable.sUserId));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    DataTable dataTable1 = RemotingClient.Alarm_GetRegionInfo();
                    if (dataTable1 != null && dataTable.Rows.Count > 0)
                    {
                        string str1 = dataTable.Rows[0]["DotValue"].ToString();
                        if (!string.IsNullOrEmpty(str1))
                        {
                            string[] strArrays = str1.Split(new char[] { ',' });
                            for (int i = 0; i < (int)strArrays.Length; i++)
                            {
                                string str2 = strArrays[i];
                                DataRow[] dataRowArray = dataTable1.Select(string.Concat("RegionId = '", str2, "'"));
                                if ((int)dataRowArray.Length != 0)
                                {
                                    string str3 = "";
                                    string str4 = "";
                                    string str5 = dataRowArray[0]["RegionDot"].ToString();
                                    string str6 = dataRowArray[0]["RegionName"].ToString();
                                    if (!Check.isRoundness(str5))
                                    {
                                        string[] strArrays1 = str5.Split(new char[] { '*' });
                                        for (int j = 0; j < (int)strArrays1.Length; j++)
                                        {
                                            string[] strArrays2 = strArrays1[j].Split(new char[] { '\\' });
                                            if ((int)strArrays2.Length == 2)
                                            {
                                                str3 = string.Concat(str3, strArrays2[0], ",");
                                                str4 = string.Concat(str4, strArrays2[1], ",");
                                            }
                                        }
                                        str3.Trim(new char[] { ',' });
                                        str4.Trim(new char[] { ',' });
                                        base.Invoke(new MethodInvoker(() => argument.showpolygonForCS(str6, str3, str4, false)));
                                    }
                                    else
                                    {
                                        string str7 = str5.Trim(new char[] { '*' });
                                        char[] chrArray = new char[] { '*' };
                                        string[] strArrays3 = str7.Split(chrArray)[0].Split(new char[] { '\\' });
                                        double num = double.Parse(strArrays3[0]);
                                        double num1 = double.Parse(strArrays3[1]);
                                        int num2 = int.Parse(strArrays3[2]);
                                        base.Invoke(new MethodInvoker(() => argument.showCircle(str6, num, num1, num2, false)));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void showRegionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.workStates[2] = true;
                this.showRegionWorker.DoWork -= new DoWorkEventHandler(this.showRegionWorker_DoWork);
                this.showRegionWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.showRegionWorker_RunWorkerCompleted);
                this.showRegionWorker = null;
            }
            catch
            {
            }
            finally
            {
                if ((this.workStates[0] && this.workStates[1]) && this.workStates[2])
                {
                    WaitForm.Hide2();
                }
            }
        }
    
    }
}
