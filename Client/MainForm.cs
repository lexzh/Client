using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Remoting;
//using GlsService;
using System.Threading;
using PublicClass;
using System.Collections;
using ParamLibrary.Entity;
using WinFormsUI.Docking;
using System.IO;
using WinFormsUI.Controls;
using System.Diagnostics;
using System.Reflection;
using Client.Plugin;
using ParamLibrary.Application;
using Client.JTB;
using System.Net;
using Client.DB44;
using Client.M2M;
using System.Security.Cryptography;
using ParamLibrary.CmdParamInfo;
using Client.JTB.MonitoringPlatform;

namespace Client
{
    public partial class MainForm : Form
    {
        //视频监控窗体指针 2013.12.16 周立山
        //private CarVideoForm _carVideoForm;

        private PrintOption _mapPrint;
        private WebSystem _webSystem;
        private ArrayList arrPlugins = new ArrayList();
        private bool bRespCallBack = true;
        private bool bTimeOut;
        public static Hashtable EbillTextList = new Hashtable();
        public static GpsClientObj gpsClientObj = new GpsClientObj();
        private const string GrantType = "1";
        public static Hashtable htBatchName = null;
        private int iGetUpDateTime = 2000;
        private bool isWebSystem;
        public AutoResetEvent LoadWebSystem = new AutoResetEvent(false);
        private bool m_bCloseAsk = true;
        private bool m_bSaveLayout = true;
        private WinFormsUI.Docking.DeserializeDockContent m_deserializeDockContent;
        public static DataTable m_dtMenu = new DataTable();
        public static string m_sSelectedMap = "";
        private static System.Timers.Timer m_tGetAlarmUpDataTimer;
        private static System.Timers.Timer m_tGetNewLogTimer;
        private static System.Timers.Timer m_tGetUpDataTimer;
        private static System.Timers.Timer m_tRegistrationTimer;
        private CarImageList myCarImageList;
        private dexecCarLine myCarLine;
        public static CarList myCarList;
        private dCarLog myCarLog;
        public static itmCarPlayTrack myCarPlayTrack = null;
        private CarTextList myCarTextList;
        private dCloseForm myCloseForm;
        public static itmImportReport myImportReport = null;
        public static LogForms myLogForms = new LogForms();
        public static Map myMap = new Map();
        private static NoticeForm myNoticeForm = null;
        private static NoticeForm myNoticeFormEx = null;
        private PerformanceView myPerformanceView;
        private static QueryCarInfo myQueryCarInfo = null;
        public static SearchCarList mySearchCarList = new SearchCarList();
        public static SearchFeature mySearchFeature = new SearchFeature();
        public static string POITypes = null;
        private RecentUseMenu recentMenu;
        private Response resUpdate;
        private string sAlarmCnt = "0";
        private string sAlarmLastCnt = "0";
        private string sAlarmLastTime = DateTime.Now.ToString();
        private string sAlarmOther = "";
        public static string sAlarmShowCnt = "0";
        private string sCurrentCnt = "0";
        private string sCurrentLastCnt = "0";
        private string sCurrentLastTime = DateTime.Now.ToString();
        private string sCurrentOther = "";
        public static string sCurrentShowCnt = "0";
        private Dictionary<string, ToolStripMenuItem> menuList = new Dictionary<string, ToolStripMenuItem>();
        private List<ToolStripMenuItem> parentMenuList = new List<ToolStripMenuItem>();
        private Dictionary<string, ToolStripMenuItem> topMenuList = new Dictionary<string, ToolStripMenuItem>();
        private System.Timers.Timer tHeart = new System.Timers.Timer(10000.0);
        private UserCollectionMenu userCollectionMenu;
        //添加打开视频窗口 2013.12.16 周立山
        //private ToolStripMenuItem 透传命令MenuItem;

        public MainForm()
        {
            // MessageBox.Show("msg");
            if (!this.DUpdate())
            {
                RemotingManager.OffRegHttpChannel();
                this.InitializeComponent();
                myCarList = new CarList();
                myCarList.setMenuList(this.MenuStripList);
                new Login { myMainForm = this }.ShowDialog();
                if (Variable.bLogin)
                {
                    if (Variable.sProjectID.Equals("zhongtong", StringComparison.OrdinalIgnoreCase) && (Variable.sWebMenuList.Trim().Length > 0))
                    {
                        WaitForm.Show("正在加载...", this);
                    }
                    this.Text = Variable.sTitle + "V" + Variable.sVersion;
                    ToolWindow.myMainForm = this;
                    this.m_deserializeDockContent = new DeserializeDockContent(this.GetContentFromPersistString);
                    string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
                    try
                    {
                        try
                        {
                            this.dockPanel.LoadFromXml(fileName, this.m_deserializeDockContent);
                            this.setMenuViewChecked();
                        }
                        catch
                        {
                        }
                        if (this.dockPanel.Contents.IndexOf(myMap) < 0)
                        {
                            myMap.SetDocument();
                            myMap.Show(this.dockPanel);
                        }
                        if (this.dockPanel.Contents.IndexOf(myCarList) < 0)
                        {
                            myCarList.Show(this.dockPanel, DockState.DockLeft);
                        }
                        else if (((myCarList.DockState != DockState.DockTop) && (myCarList.DockState != DockState.DockLeft)) && ((myCarList.DockState != DockState.DockRight) && (myCarList.DockState != DockState.DockBottom)))
                        {
                            myCarList.DockState = DockState.DockLeft;
                        }
                        if (this.dockPanel.Contents.IndexOf(myLogForms) < 0)
                        {
                            myLogForms.Show(this.dockPanel, DockState.DockBottom);
                        }
                        if ((this.dockPanel.Contents.IndexOf(mySearchCarList) < 0) && this.MenuSearchCarList.Checked)
                        {
                            mySearchCarList.Show(this.dockPanel, DockState.DockRight);
                        }
                        if (this.dockPanel.Contents.IndexOf(mySearchFeature) < 0)
                        {
                            mySearchFeature.Show(this.dockPanel, DockState.DockRight);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        Record.execFileRecord("主画面初始化", exception.Message);
                    }
                    this.seSkin.SkinFile = Variable.sSkinFiles[int.Parse(Variable.sSkinDataIndex)];
                    ((ToolStripMenuItem)this.MenuSkin.DropDownItems[int.Parse(Variable.sSkinDataIndex)]).Checked = true;
                }
            }
        }

        private void addCalculation()
        {
            ListBox box = new ListBox();
            box.Items.AddRange(new object[] { "圆形量算", "矩形量算", "多边形量算" });
            box.Height = 50;
            box.Width = 70;
            box.MouseClick += delegate(object sender, MouseEventArgs e)
            {
                if (box.SelectedItem.ToString().Equals("测距"))
                {
                    myMap.setMeasureTool();
                }
                else if (box.SelectedItem.ToString().Equals("圆形量算"))
                {
                    myMap.setCircleMesTool();
                }
                else if (box.SelectedItem.ToString().Equals("矩形量算"))
                {
                    myMap.setRectangleMesTool();
                }
                else if (box.SelectedItem.ToString().Equals("多边形量算"))
                {
                    myMap.setPolygonMesTool();
                }
                this._量算.HideDropDown();
            };
            this._量算 = new AutoDropDown(box);
            base.Controls.Add(this._量算);
        }

        /// <summary>
        /// 添加插件函数 
        /// </summary>
        private void addPlugin()
        {
            string path = Application.StartupPath + @"\Plugins";
            if (Directory.Exists(path))
            {
                //扫描插件目录
                foreach (string str2 in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
                {
                    if (str2.Length != 0)
                    {
                        //获取插件信息
                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(str2);
                        string productName = versionInfo.ProductName;
                        string fileDescription = versionInfo.FileDescription;
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str2);
                        try
                        {
                            //加载插件程序集
                            Assembly assembly = Assembly.LoadFile(str2);
                            foreach (System.Type type in assembly.GetTypes())
                            {
                                //验证插件
                                if (this.IsValidPlugin(type))
                                {
                                    object obj2 = null;
                                    try
                                    {
                                        //obj2 = new BDPlugin.Report.Common.ReportClass();
                                        obj2 = assembly.CreateInstance(type.FullName);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    if (obj2 != null)
                                    {
                                        IPlugin plugin = obj2 as IPlugin;
                                        if (plugin != null)
                                        {
                                            plugin.Load(gpsClientObj);
                                            this.arrPlugins.Add(plugin);
                                        }
                                    }
                                }
                            }
                        }
                        catch (BadImageFormatException)
                        {
                        }
                        catch (Exception exception)
                        {
                            Record.execFileRecord("插件[" + fileNameWithoutExtension + "]加裁失败！" + exception.Message);
                        }
                    }
                }
            }
        }

        private void addRecentMenu(string menuTag, string menuName)
        {
            if (this.recentMenu == null)
            {
                this.recentMenu = new RecentUseMenu(this.MenuStripList, new EventHandler(this.AllMenu_Click), this.menuList);
                this.recentMenu.LoadMenu();
            }
            if (!string.IsNullOrEmpty(menuTag))
            {
                this.recentMenu.AddMenu(menuTag, menuName);
            }
        }

        private void addUserCollectionMenu()
        {
        }

        private void afterInitMenuList()
        {
            this.MenuStripList.Items.Add(this.MenuStripList.Items["MenuItemTradeApp"]);
            this.parentMenuList.ForEach(delegate(ToolStripMenuItem menu)
            {
                if (!menu.HasDropDownItems)
                {
                    menu.Visible = false;
                }
            });
        }
        /// <summary>
        /// 右键菜单事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllMenu_Click(object sender, EventArgs e)
        {
            if (this.CheckSlectedCarCnt())
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item.Tag != null)
                {
                    this.OpenDialog(item.Tag.ToString().Trim(), item.Text);
                }
                else
                {
                    SimpleCmd cmdParameter = new SimpleCmd();
                    string carVals = myCarList.SelectedCarId.Split(new char[] { ',' })[0];

                    //if (item.Name.Equals("MenuItemJtbLogOutLinkRout"))
                    //{
                    //    if (MessageBox.Show("是否确定注销主链路", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    //    {
                    //        cmdParameter.OrderCode = CmdParam.OrderCode.注销主链路;
                    //        RemotingClient.Car_CommandParameterInsterToDB(CmdParam.ParamType.CarId, carVals, "", cmdParameter, "", CmdParam.OrderCode.注销主链路.ToString());
                    //    }
                    //}
                    //else if (item.Name.Equals("MenuItemMenuItemJtbResumeLinkRout"))
                    //{
                    //    if (MessageBox.Show("是否确定恢复主链路", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    //    {
                    //        cmdParameter.OrderCode = CmdParam.OrderCode.恢复主链路;
                    //        RemotingClient.Car_CommandParameterInsterToDB(CmdParam.ParamType.CarId, carVals, "", cmdParameter, "", CmdParam.OrderCode.恢复主链路.ToString());
                    //    }
                    //}
                    //else if (item.Name.Equals("MenuItemJtbCloseLinkRout"))
                    //{
                    //    if (MessageBox.Show("是否确定主动关闭主从链路通知", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    //    {
                    //        cmdParameter.OrderCode = CmdParam.OrderCode.主动关闭主从链路通知;
                    //        RemotingClient.Car_CommandParameterInsterToDB(CmdParam.ParamType.CarId, carVals, "", cmdParameter, "", CmdParam.OrderCode.主动关闭主从链路通知.ToString());
                    //    }
                    //}
                    //else if (item.Name.Equals("MenuItemJtbCloseMainLinkRout") && (MessageBox.Show("是否确定主动关闭主链路通知", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    //{
                    //    cmdParameter.OrderCode = CmdParam.OrderCode.主动关闭主链路通知;
                    //    RemotingClient.Car_CommandParameterInsterToDB(CmdParam.ParamType.CarId, carVals, "", cmdParameter, "", CmdParam.OrderCode.主动关闭主链路通知.ToString());
                    //}
                }
            }
        }

        private void CaptureScreen()
        {
            Graphics g = base.CreateGraphics();
            Size blockRegionSize = myMap.Size;
            this.memoryImage = new Bitmap(blockRegionSize.Width, blockRegionSize.Height, g);
            Graphics.FromImage(this.memoryImage).CopyFromScreen(myMap.Left, myMap.Top, 0, 0, blockRegionSize);
        }

        private void changeMenuList(DataView dv, ToolStripMenuItem parentMenu)
        {
            int num = -1;
            for (int i = 0; i < dv.Count; i++)
            {
                DataView view = new DataView(m_dtMenu, "ParentID='" + dv[i]["ID"].ToString() + "'", m_dtMenu.Columns.Contains("MenuOrder") ? "MenuOrder Asc" : "", DataViewRowState.CurrentRows);
                ToolStripMenuItem item = null;
                if ((!this.menuList.ContainsKey(dv[i]["MenuCode"].ToString().ToLower()) && (view != null)) && (view.Count > 0))
                {
                    item = new ToolStripMenuItem(dv[i]["MenuName"].ToString())
                    {
                        Tag = dv[i]["MenuCode"].ToString().Remove(dv[i]["MenuCode"].ToString().Trim().Length - 1, 1)
                    };
                    this.menuList[dv[i]["MenuCode"].ToString().ToLower()] = item;
                }
                else
                {
                    if (!this.menuList.ContainsKey(dv[i]["MenuCode"].ToString().ToLower()))
                    {
                        continue;
                    }
                    item = this.menuList[dv[i]["MenuCode"].ToString().ToLower()];
                }
                if ((dv[i]["MenuOrder"] != null) && (dv[i]["MenuOrder"].ToString().Length > 0))
                {
                    if ((num != -1) && ((Convert.ToInt32(dv[i]["MenuOrder"]) - num) >= 600))
                    {
                        if (parentMenu == null)
                        {
                            this.MenuStripList.Items.Add(new ToolStripSeparator());
                        }
                        else
                        {
                            parentMenu.DropDownItems.Add(new ToolStripSeparator());
                        }
                        num = Convert.ToInt32(dv[i]["MenuOrder"]);
                    }
                    num = Convert.ToInt32(dv[i]["MenuOrder"]);
                }
                item.Text = dv[i]["MenuName"].ToString();
                if (parentMenu == null)
                {
                    this.MenuStripList.Items.Add(item);
                }
                else
                {
                    parentMenu.DropDownItems.Add(item);
                }
                this.changeMenuList(view, item);
                view = null;
            }
        }

        private bool CheckAllLCSCar()
        {
            foreach (string str in myCarList.SelectedCarId.Split(new char[] { ',' }))
            {
                if (!Variable.sAllowLCSType.Equals(myCarList.getCarType(str)))
                {
                    MessageBox.Show(string.Format("选中车辆类型必须全部为：{0}", Variable.sAllowLCSType), "提示");
                    return false;
                }
            }
            return true;
        }

        private bool CheckSlectedCarCnt()
        {
            if (myCarList.tvTrackCar.Visible)
            {
                if ((myCarList.m_dtCarAlermList == null) || (myCarList.m_dtCarAlermList.Rows.Count == 0))
                {
                    MessageBox.Show("请先选中车辆！", "提示");
                    return false;
                }
                if (myCarList.m_dtCarAlermList.Rows.Count > int.Parse(Variable.sMaxSendCount))
                {
                    MessageBox.Show("单次群发车辆不能超过" + Variable.sMaxSendCount + "台", "提示");
                    return false;
                }
            }
            else if (myCarList.getSelectedCnt() > int.Parse(Variable.sMaxSendCount))
            {
                MessageBox.Show("单次群发车辆不能超过" + Variable.sMaxSendCount + "台", "提示");
                return false;
            }
            return true;
        }

        private bool chkAllSubFormClosed()
        {
            if ((myCarPlayTrack != null) && myCarPlayTrack.IsHandleCreated)
            {
                return false;
            }
            if ((myImportReport != null) && myImportReport.IsHandleCreated)
            {
                return false;
            }
            if ((myQueryCarInfo != null) && myQueryCarInfo.IsHandleCreated)
            {
                return false;
            }
            return true;
        }

        public bool chkMapEnable(string sMapSign)
        {
            if (this.cmbSelectMap.Items.Count > 0)
            {
                try
                {
                    if (((DataTable)this.cmbSelectMap.ComboBox.DataSource).Select(string.Format("values='{0}'", sMapSign)).Length > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                }
            }
            return false;
        }

        private void cmbSelectMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_sSelectedMap != this.cmbSelectMap.ComboBox.SelectedValue.ToString())
                {
                    string itemText = this.cmbSelectMap.ComboBox.GetItemText(this.cmbSelectMap.SelectedItem);
                    string sValue = this.cmbSelectMap.ComboBox.SelectedValue.ToString();
                    myMap.execMapChangeBaseLayer(itemText, sValue);
                    m_sSelectedMap = sValue;
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("选择地图", exception.Message);
            }
        }

        private void ContrailReturnQuery()
        {
            if ((myCarPlayTrack == null) || !myCarPlayTrack.IsHandleCreated)
            {
                itmCarPlayTrack track = new itmCarPlayTrack
                {
                    Text = "轨迹回放"
                };
                myCarPlayTrack = track;
                myCarPlayTrack.Show(this);
            }
            else
            {
                myCarPlayTrack.Activate();
                myCarPlayTrack.WindowState = FormWindowState.Maximized;
            }
        }

        private bool DoUpdateClientFile(string sPath)
        {
            if (System.IO.File.Exists(sPath))
            {
                new Process { StartInfo = { FileName = sPath } }.Start();
                return true;
            }
            return false;
        }

        private bool DUpdate()
        {
            IniFile.ReadIniFile();
            this.resUpdate = null;
            DelegateUpdateClient client = new DelegateUpdateClient(this.getUpdateClient);
            try
            {
                client.BeginInvoke(new AsyncCallback(this.RespCallback), null);
                for (int i = 0; i < 25; i++)
                {
                    if (!this.bRespCallBack)
                    {
                        break;
                    }
                    Thread.Sleep(200);
                }
                if (this.bRespCallBack)
                {
                    Record.execFileRecord("更新程序", "获取更新程序超时，超时时间 5 秒");
                    this.bTimeOut = true;
                    return false;
                }
                if (this.resUpdate != null)
                {
                    return this.UpdateClient(this.resUpdate);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("更新程序", exception.Message);
            }
            finally
            {
                client = null;
            }
            return false;
        }

        private void execCarLine(string sLine)
        {
            try
            {
                if ("1".Equals(sLine))
                {
                    this.execOffLine();
                }
                else if ("0".Equals(sLine))
                {
                    this.execOnLine();
                    myCarList.setWatchCar();
                }
                else if ("【与服务器连接成功】".Equals(sLine))
                {
                    myLogForms.myNewLog.AddUserMessageToNewLog(sLine, "信息 ");
                    WaitForm.Show("正在下载报警车辆列表...");
                    myCarList.resetAlermList();
                }
                else
                {
                    myLogForms.myNewLog.AddUserMessageToNewLog(sLine);
                }
            }
            catch (Exception exception)
            {
                if (Variable.bLogin)
                {
                    Record.execFileRecord("掉线与上线处理", exception.ToString());
                }
            }
        }

        private void execChangeUserPw()
        {
            new itmSetPass().ShowDialog();
        }

        private bool execConnection()
        {
            Response response = RemotingClient.LoginSys_Login(true, false);
            if (response.ResultCode != 0L)
            {
                Record.execFileRecord("用户登录", string.Format("{0}登录失败：{1}", Variable.sUserId, response.ErrorMsg));
                return false;
            }
            base.Invoke(this.myCarLine, new object[] { "【与服务器连接成功】" });
            return true;
        }

        private bool execConnectionServer()
        {
            if (this.execConnection())
            {
                Record.execFileRecord("连接服务器", "已重新连接上服务器");
                this.execOnLine();
                myCarList.tvList.areaNodeHashTable.Clear();
                this.GetLoginSysAllMenu();
                myCarList.iTipCount = int.Parse(Variable.sGetNodeTipShowType);
                myCarList.IsFresh = true;
                myCarList.tvList.Nodes.Clear();
                myCarList.delCarDetail();
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(this.worker2_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker2_RunWorkerCompleted);
                worker.RunWorkerAsync();
                return true;
            }
            myLogForms.myNewLog.AddUserMessageToNewLog("与服务器连接失败！");
            this.execOffLine();
            return false;
        }

        private void execCutOffServer()
        {
            Record.execFileRecord("断开服务器", "已断开服务器");
            if (myCarList != null)
            {
                myCarList.Enabled = false;
            }
            if (this.tHeart != null)
            {
                this.tHeart.Enabled = false;
            }
            RemotingClient.CutOff();
            if (m_dtMenu != null)
            {
                m_dtMenu.Clear();
            }
            this.execOffLine();
        }

        public void execOffLine()
        {
            this.MenuConnection.Enabled = true;
            this.MenuCut.Enabled = false;
            this.tsbConnection.Enabled = true;
            this.tsbCut.Enabled = false;
            this.MenuAddPoint.Enabled = false;
            this.MenuDelPoint.Enabled = false;
            this.MenuFlagTypeDisplayControl.Enabled = false;
            this.tsbTextList.Enabled = false;
            Variable.bLogin = false;
            try
            {
                m_tGetUpDataTimer.Enabled = false;
                m_tGetAlarmUpDataTimer.Enabled = false;
                m_tRegistrationTimer.Enabled = false;
            }
            catch
            {
            }
            this.setStateConn();
            this.setMenuVisible();
        }

        public void execOnLine()
        {
            this.tHeart.Enabled = true;
            m_tGetUpDataTimer.Enabled = true;
            m_tGetAlarmUpDataTimer.Enabled = true;
            m_tRegistrationTimer.Enabled = true;
            this.MenuConnection.Enabled = false;
            this.MenuCut.Enabled = true;
            this.tsbConnection.Enabled = false;
            this.tsbCut.Enabled = true;
            this.MenuAddPoint.Enabled = true;
            this.MenuDelPoint.Enabled = true;
            this.MenuFlagTypeDisplayControl.Enabled = true;
            this.tsbTextList.Enabled = true;
            Variable.bLogin = true;
            this.setStateConn();
            this.setManagerSystemState();
        }

        private void execRegistration(object sender, System.Timers.ElapsedEventArgs arg)
        {
            //try
            //{
            //    //PasConnectManager.CheckStart();
            //}
            //catch (Exception exception)
            //{
            //    if (Variable.bLogin)
            //    {
            //        Record.execFileRecord("认证", exception.Message);
            //    }
            //    return;
            //}
            //if (!PasConnectManager.IsPass)
            //{
            //    this.m_bCloseAsk = false;
            //    base.Invoke(this.myCloseForm, new object[] { sender, new EventArgs() });
            //}
        }

        public void execSetMenu(int iType, ToolStripMenuItem tsm)
        {
            if (iType == 0)
            {
                this.MenuItemTradeApp.DropDownItems.Add(tsm);
                this.MenuItemTradeApp.Visible = true;
            }
            else
            {
                this.MenuTradeApp.DropDownItems.Add(tsm);
                this.MenuTradeApp.Visible = true;
            }
        }

        private void execSetParam()
        {
            Login.execSetParam();
        }

        public void FirstLoadWebSystem(Login login)
        {
            MethodInvoker method = null;
            if (Variable.sProjectID.Equals("zhongtong", StringComparison.OrdinalIgnoreCase) && (Variable.sWebMenuList.Trim().Length > 0))
            {
                if (method == null)
                {
                    method = () => this.gotoWebSystem();
                }
                login.Invoke(method);
                this.LoadWebSystem.WaitOne();
            }
        }

        private void GetCarAlarmData()
        {
            if ((myCarList.m_dtCarAlermList != null) && (myCarList.m_dtCarAlermList.Rows.Count > 0))
            {
                this.RefreshNewLogMsg(LogForm.LogFormType.报警日志, myCarList.m_dtCarAlermList);
                myCarList.setAlarm(myCarList.m_dtCarAlermList);
                myMap.setShowCar(myCarList.m_dtCarAlermList, true);
            }
        }

        private void GetCarReachDateData()
        {
            DataTable dtMsgResult = RemotingClient.Updata_GetCarReachDateData();
            if ((dtMsgResult != null) && (dtMsgResult.Rows.Count > 0))
            {
                this.RefreshNewLogMsg(LogForm.LogFormType.最新日志, dtMsgResult);
            }
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(SearchCarList).ToString())
            {
                return mySearchCarList;
            }
            if (persistString == typeof(Map).ToString())
            {
                myMap.SetDocument();
                return myMap;
            }
            if (persistString == typeof(CarList).ToString())
            {
                return myCarList;
            }
            if (persistString == typeof(LogForms).ToString())
            {
                return myLogForms;
            }
            if (persistString == typeof(SearchFeature).ToString())
            {
                return mySearchFeature;
            }
            return myMap;
        }

        private string getCurrentVersion()
        {
            string productVersion = "";
            try
            {
                productVersion = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\GpsClient.exe").ProductVersion;
                //Variable.sVersion = string.Format(" V{0}", productVersion);
                string[] strArray = productVersion.Split(new char[] { '.' });
                if (strArray.Length == 1)
                {
                    return (productVersion + ".0.0.0");
                }
                if (strArray.Length == 2)
                {
                    return (productVersion + ".0.0");
                }
                if (strArray.Length == 3)
                {
                    productVersion = productVersion + ".0";
                }
            }
            catch
            {
            }
            return productVersion;
        }

        private void GetLoginSysAllMenu()
        {
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(this.workerGrant_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.workerGrant_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取菜单权限", exception.Message);
            }
        }

        /// <summary>
        /// 获取右键菜单功能模块
        /// </summary>
        /// <param name="menuTag"></param>
        /// <returns></returns>
        public CarForm GetModule(string menuTag)
        {
            return this.GetModule(menuTag, this.menuList[menuTag.ToLower() + "1".ToString()].Text);
        }

        private CarForm GetModule(string menuTag, string menuName)
        {
            CarForm form = null;
            switch (menuTag.ToLower())
            {
                case "itmquery":
                    return new itmRealTimeReport(CmdParam.OrderCode.位置查询) { Text = menuName };

                case "itmrealtimereport":
                    return new itmRealTimeReport(CmdParam.OrderCode.实时监控) { Text = menuName };

                case "itmzipreport":
                    return new itmRealTimeReport(CmdParam.OrderCode.压缩监控) { Text = menuName };

                case "itmpollreport":
                    return new itmRealTimeReport(CmdParam.OrderCode.设置轮询监控) { Text = menuName };

                case "itmtaxireport":
                    return new itmTaxiReport(CmdParam.OrderCode.设置出租车监控) { Text = menuName };

                case "itmmobilewatch":
                    if (this.CheckAllLCSCar())
                    {
                        return new itmCarLBSParam(CmdParam.OrderCode.手机监控) { Text = menuName };
                    }
                    return null;

                case "itmstopreport":
                    return new itmStopReport(CmdParam.OrderCode.停止监控) { Text = menuName };

                case "itmstoppoll":
                    return new itmStopReport(CmdParam.OrderCode.停止轮询监控) { Text = menuName };

                case "itmblindrepair":
                    return new itmBlindRepair(CmdParam.OrderCode.设置盲区补偿) { Text = menuName };

                case "itmmonitorview":
                    return new db44RealTimeReport(CmdParam.OrderCode.定距监控查看) { Text = menuName };

                case "itmhistorytrack":
                    return new db44AccidentData(CmdParam.OrderCode.历史轨迹) { Text = menuName };

                case "itmaccidentdata":
                    return new db44AccidentData(CmdParam.OrderCode.事故疑点数据) { Text = menuName };

                case "itmrealtimeimage":
                    return new itmRealTimeImage(CmdParam.OrderCode.实时图像监控) { Text = menuName };

                case "itmcardoorimage":
                    return new itmRealTimeImage(CmdParam.OrderCode.多种条件图像监控) { Text = menuName };

                case "itmstopimagereport":
                    return new itmRealTimeImage(CmdParam.OrderCode.停止图像监控) { Text = menuName };

                case "itmdevpictransport":
                    return new itmCarReport(CmdParam.OrderCode.终端图片上传) { Text = menuName };

                case "itmsetphoto":
                    return new m2mShootPhoto(CmdParam.OrderCode.图像设置指令) { Text = menuName };

                case "itmgetphotoname":
                    return new m2mGetPhoto(CmdParam.OrderCode.图像名称查询指令) { Text = menuName };

                case "itmgetphotobyname":
                    return new m2mGetPhoto(CmdParam.OrderCode.获取指定图片上传指令) { Text = menuName };

                case "itmdeftimeimage":
                    return new itmRealTimeImage(CmdParam.OrderCode.定时抓拍图像监控) { Text = menuName };

                case "itmcdeftimeimage":
                    return new itmCarReport(CmdParam.OrderCode.取消定时抓拍图像监控) { Text = menuName };

                case "itmsetblackreport":
                    return new itmSetBlackReport(CmdParam.OrderCode.黑匣子采样) { Text = menuName };

                case "itmblackdataupload":
                    return new itmCarReport(CmdParam.OrderCode.设置黑匣子数据上传) { Text = menuName };

                case "itmstopblackreport":
                    return new itmSetBlackReport(CmdParam.OrderCode.停止黑匣子采样) { Text = menuName };

                case "getphoto":
                    return new getphoto(CmdParam.OrderCode.根据条件获得黑匣子图片) { Text = menuName };

                case "delphoto":
                    return new getphoto(CmdParam.OrderCode.根据条件删除图片) { Text = menuName };

                case "itmbatchname":
                    return new itmCarReport(CmdParam.OrderCode.实时点名查询) { Text = menuName };

                case "itmtrain":
                    return new itmCarReport(CmdParam.OrderCode.驾培信息查询) { Text = menuName };

                case "itmlastdot":
                    return new itmCarReport(CmdParam.OrderCode.末次位置查询) { Text = menuName };

                case "itmdriveridentity":
                    return new db44NoParamForm(CmdParam.OrderCode.驾驶员身份) { Text = menuName };

                case "itmsetregionalarm":
                    return new itmSetRegionAlarm(CmdParam.OrderCode.设置区域报警) { Text = menuName };

                case "itmcancelregalarm":
                    return new m2mCancelRegionAlarm(CmdParam.OrderCode.取消报警区域值) { Text = menuName };

                case "itmdistrictalarm":
                    return new itmSetDistrictAlarm(CmdParam.OrderCode.设置行政区域报警) { Text = menuName };

                case "itmsetregionstalarm":
                    return new m2mSetRegionTimeAlarm(CmdParam.OrderCode.区域超时停车报警设置) { Text = menuName };

                case "itmcregionstalarm":
                    return new m2mCancleReport(CmdParam.OrderCode.区域超时停车报警设置, "取消区域内超时停车报警");

                case "itmsetexternalalarm":
                    return new m2mSetRegionTimeAlarm(CmdParam.OrderCode.区域外罐车反转报警设置) { Text = menuName };

                case "itmcexternalalarm":
                    return new m2mCancleReport(CmdParam.OrderCode.区域外罐车反转报警设置, "取消区域外罐车反转报警");

                case "itmplatregionalarm":
                    return new JTBitmSetPlatformRegionAlarm(CmdParam.OrderCode.设置区域报警) { Text = menuName };

                case "itmcarbebacktime":
                    return new itmCarBeBackTime { Text = menuName };

                case "itmcariorangetime":
                    return new itmCarInOutOfRangeTime { Text = menuName };

                case "itmsetmultiregion":
                    return new itmSetRegionAlarm(CmdParam.OrderCode.设置多功能区域报警) { Text = menuName };

                case "itmsetjtbregion":
                    return new JTBitmSetRegionAlarm(CmdParam.OrderCode.设置多功能区域报警) { Text = menuName };

                case "itmundomultiregion":
                    return new JTBitmCancelRegionAlarm(CmdParam.OrderCode.取消报警区域值, "取消多功能区域报警");

                case "itmsetoverspeed":
                    return new itmSetOverSpeed(CmdParam.OrderCode.设置超速报警) { Text = menuName };

                case "itmcancelspeed":
                    return new itmCarReport(CmdParam.OrderCode.取消超速报警) { Text = menuName };

                case "itmsetspeedearly":
                    return new itmSetOverSpeed(CmdParam.OrderCode.设置超速预警) { Text = menuName };

                case "itmcancelspeedearly":
                    return new itmCancelOverSpeedEarly(CmdParam.OrderCode.取消超速预警) { Text = menuName };

                case "itmregionspeedalarm":
                    return new m2mSetRegionSpeedAlarm(CmdParam.OrderCode.区域内超速报警设置) { Text = menuName };

                case "itmsetspeedintalarm":
                    return new m2mSetSpeedInTimeAlarm(CmdParam.OrderCode.带时间段的超速设置) { Text = menuName };

                case "itmsegpath":
                    return new itmSegPath(CmdParam.OrderCode.设置分路段超速报警) { Text = menuName };

                case "itmsetjtbpath":
                    return new JTBitmSegPath(CmdParam.OrderCode.设置分路段超速报警) { Text = menuName };

                case "itmsetjtbpathex":
                    return new JTBitmSegPathEX(CmdParam.OrderCode.设置分路段超速报警) { Text = menuName };

                case "itmsetpathalarm":
                    return new itmSetPathAlarm(CmdParam.OrderCode.设置偏移路线报警) { Text = menuName };

                case "itmcancelpathalarm":
                    return new JTBitmCancelPathAlarm(CmdParam.OrderCode.取消偏移路线报警) { Text = menuName };

                case "itmdynpathalarmon":
                    return new itmCarReport(CmdParam.OrderCode.开启报警路线动态下载) { Text = menuName };

                case "itmdynpathalarmoff":
                    return new itmCarReport(CmdParam.OrderCode.关闭报警路线动态下载) { Text = menuName };

                case "itmplatsegpath":
                    return new JTBitmSetPlatformPathSegmentAlarm(CmdParam.OrderCode.设置分路段超速报警) { Text = menuName };

                case "itmsetplatpath":
                    return new JTBitmSetPlatformPathAlarm(CmdParam.OrderCode.设置偏移路线报警) { Text = menuName };

                case "itmsetoilalarm":
                    return new itmSetOilAlarm(CmdParam.OrderCode.设置油量报警阈值) { Text = menuName };

                case "itmsetoilrefvalue":
                    return new itmSetOilRefValue(CmdParam.OrderCode.配置油量检测参考值) { Text = menuName };

                case "itmstartoilreport":
                    return new m2mOilReport(CmdParam.OrderCode.开启油耗功能) { Text = menuName };

                case "itmstopoilreport":
                    return new m2mCancleReport(CmdParam.OrderCode.开启油耗功能, "关闭油耗功能") { Text = menuName };

                case "itemsettemp":
                    return new itemsettemp(CmdParam.OrderCode.设置温度报警) { Text = menuName };

                case "itmgettemp":
                    return new itmCarReport(CmdParam.OrderCode.获得当前车台温度) { Text = menuName };

                case "itmcarovertimedrive":
                    return new itmCarOverTimeDrive(CmdParam.OrderCode.设置超时驾驶报警) { Text = menuName };

                case "itmcarovertimestop":
                    return new itmCarOverTimeStop(CmdParam.OrderCode.设置超时停车报警) { Text = menuName };

                case "itmsetforbiddrive":
                    return new itmCarForbidDriveAlarm(CmdParam.OrderCode.设置禁驾报警) { Text = menuName };

                case "itmviewoverspeed":
                    return new db44NoParamForm(CmdParam.OrderCode.查询2个日历天内超时驾驶) { Text = menuName };

                case "itmcarstopalarm":
                    return new itmStopReport(CmdParam.OrderCode.停止报警) { Text = menuName };

                case "itmsetmeter":
                    return new m2mMeter(CmdParam.OrderCode.设置计价器) { Text = menuName };

                case "itmlockmeter":
                    return new itmLockMeter(CmdParam.OrderCode.停机时间命令) { Text = menuName };

                case "itmquerymeter":
                    return new m2mMeter(CmdParam.OrderCode.查询计价器) { Text = menuName };

                case "itmsetgathertimer":
                    return new JTBSetCanGatherInterval(CmdParam.OrderCode.设置CAN采集间隔) { Text = menuName };

                case "itmseturgentacc":
                    return new JTBSetUrgentAcceleration(CmdParam.OrderCode.设置急加速参数) { Text = menuName };

                case "itmsetrapiddowm":
                    return new JTBSetRapidSlowdown(CmdParam.OrderCode.设置急减速参数) { Text = menuName };

                case "itmsetengineover":
                    return new JTBSetEngineOverspeed(CmdParam.OrderCode.设置发动机超转参数) { Text = menuName };

                case "itmsetlongidle":
                    return new JTBSetLongIdleTimes(CmdParam.OrderCode.设置超长怠速允许时长) { Text = menuName };

                case "itmsetcarrecord":
                    return new m2mSetRegionAlarm(CmdParam.OrderCode.行车记录设置, "移动行车记录设置") { Text = menuName };

                case "itmledstartstop":
                    return new m2mLedSetTimeRes(CmdParam.OrderCode.LED开启或关闭) { Text = menuName };

                case "itmledsendmsg":
                    return new m2mSendMsg(CmdParam.OrderCode.LED短信下发) { Text = menuName };

                case "itmleddeletemsg":
                    return new m2mLedDelMsg(CmdParam.OrderCode.LED删除指定LED短信) { Text = menuName };

                case "itmsetledparam":
                    return new m2mLedDelMsg(CmdParam.OrderCode.LED短信属性设置) { Text = menuName };

                case "itmsetledlight":
                    return new m2mLedSetLight(CmdParam.OrderCode.LED屏亮度设置) { Text = menuName };

                case "itminterestpoint":
                    return new m2mSetPathAlarm(CmdParam.OrderCode.下载兴趣点) { Text = menuName };

                case "itmcutpower":
                    return new itmCutPower(CmdParam.OrderCode.断电) { Text = menuName };

                case "itmresumepower":
                    return new itmCutPower(CmdParam.OrderCode.断电恢复) { Text = menuName };

                case "itmlockcar":
                    return new itmCutPower(CmdParam.OrderCode.锁车) { Text = menuName };

                case "itmunlockcar":
                    return new itmCutPower(CmdParam.OrderCode.解锁) { Text = menuName };

                case "itmpointtopoint":
                    return new itmPointToPoint(CmdParam.OrderCode.点对点电召) { Text = menuName };

                case "itmsenttextmess":
                    return new itmSendTextMess(CmdParam.OrderCode.调度) { Text = menuName };

                case "itmspeechsounds":
                    return new itmSetSpeechSounds(CmdParam.OrderCode.设置语音播报) { Text = menuName };

                case "itmsetfirstmsg":
                    return new m2mSendMsg(CmdParam.OrderCode.设置一级短信, 1) { Text = menuName };

                case "itmsetsecondmsg":
                    return new m2mSendMsg(CmdParam.OrderCode.设置一级短信, 2) { Text = menuName };

                case "itmbelisten":
                    return new itmBeListen(CmdParam.OrderCode.设置被动监听) { Text = menuName };

                case "itmanswerphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.回拔坐席电话指令) { Text = menuName };

                case "itmzbnavigation":
                    return new itmZBNavigation(CmdParam.OrderCode.展博屏一键导航) { Text = menuName };

                case "itmzbdistributary":
                    return new itmZBDistributary(CmdParam.OrderCode.展博屏分流短信) { Text = menuName };

                case "itmgetcarsoftver":
                    return new itmCarReport(CmdParam.OrderCode.获得车台终端的软件版本) { Text = menuName };

                case "itmremoteupdatecar":
                    if (MessageBox.Show("您确定要升级车台软件吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        itmCarReport report = new itmCarReport(CmdParam.OrderCode.远程升级车台软件)
                        {
                            Text = menuName
                        };
                        form = report;
                    }
                    return form;

                case "itmcarreset":
                    return new itmCarReset(CmdParam.OrderCode.设置车台复位) { Text = menuName };

                case "itemsmscarreset":
                    return new itmCarReport(CmdParam.OrderCode.短信强制复位) { Text = menuName };

                case "itmcarpost":
                    return new itmCarReset(CmdParam.OrderCode.自检) { Text = menuName };

                case "itmviewtelnetagrs":
                    return new db44SetRemoteInit(CmdParam.OrderCode.远程参数查看) { Text = menuName };

                case "itmsettelnetagrs":
                    return new db44SetRemoteInit(CmdParam.OrderCode.远程参数设置) { Text = menuName };

                case "itmviewmileagecnt":
                    return new db44MileageCnt(CmdParam.OrderCode.查询累计里程) { Text = menuName };

                case "itmsetmileagecnt":
                    return new itmSetMileageCnt(CmdParam.OrderCode.设置车台总里程) { Text = menuName };

                case "itmsetsuperpass":
                    return new itmResetManagePass(CmdParam.OrderCode.修改车台超级密码) { Text = menuName };

                case "itmresetmanagepass":
                    return new itmResetManagePass(CmdParam.OrderCode.重置车台管理密码) { Text = menuName };

                case "itmresetstealpass":
                    return new itmResetManagePass(CmdParam.OrderCode.重置车台防盗密码) { Text = menuName };

                case "itmresetcommupass":
                    return new itmResetManagePass(CmdParam.OrderCode.重置车台通话密码) { Text = menuName };

                case "itmsetcarinit":
                    {
                        itmSetCarInit init = new itmSetCarInit("车台初始化参数设置")
                        {
                            Text = menuName
                        };
                        init.ShowDialog();
                        init.Dispose();
                        init = null;
                        return form;
                    }
                case "itmsetalarmparam":
                    return new m2mSetAlarmParam(CmdParam.OrderCode.报警参数设置) { Text = menuName };

                case "itmsetphonetime":
                    return new itmCarOverTimeStop(CmdParam.OrderCode.设置通话时间限制) { Text = menuName };

                case "itmsetcharactermod":
                    return new db44MileageCnt(CmdParam.OrderCode.设置特征系数) { Text = menuName };

                case "itmsetcommunication":
                    return new m2mSetCarInit(CmdParam.OrderCode.设置GPRS链接维持报文) { Text = menuName };

                case "itmsetphonestatus":
                    return new m2mModCenterPhone(CmdParam.OrderCode.控制车机通话权限, "设置车机通话权限") { Text = menuName };

                case "itmsetlimitphone":
                    return new m2mModCenterPhone(CmdParam.OrderCode.设置限拨的电话号码, "设置限拨的电话号码") { Text = menuName };

                case "itmcancellimitphone":
                    return new m2mModCenterPhone(CmdParam.OrderCode.设置取消限拨的电话号, "取消限拨的电话号码") { Text = menuName };

                case "itmsetcenterphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.设置监控中心号码) { Text = menuName };

                case "itmmodcenterphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.修改监控中心号码) { Text = menuName };

                case "itmsetmobilecenter":
                    return new itmModCenterPhone(CmdParam.OrderCode.设置移动监控中心号码) { Text = menuName };

                case "itmsetalarmphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.设置语音报警电话号码) { Text = menuName };

                case "itmsetlistenphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.设置中心监听号码) { Text = menuName };

                case "itmsetmedicalphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.设置医疗服务电话号码) { Text = menuName };

                case "itmsetrepairphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.设置维修服务电话号码) { Text = menuName };

                case "itmsethelpphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.设置救助服务电话号码) { Text = menuName };

                case "itmclearcartrack":
                    myMap.execDeleteCar(myCarList.SelectedCarId);
                    myCarList.setCarOffline(myCarList.SelectedCarId);
                    return form;

                case "itmcardetail":
                    {
                        itmCarDetail detail = new itmCarDetail
                        {
                            Text = menuName
                        };
                        detail.ShowDialog();
                        detail.Dispose();
                        detail = null;
                        return form;
                    }
                case "itmlistenplatphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.监控平台电话号码) { Text = menuName };

                case "itmreplacementphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.复位电话号码) { Text = menuName };

                case "itmresumefacphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.恢复出厂设置电话号码) { Text = menuName };

                case "itmtermipolicphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.接收终端SMS文本报警号码) { Text = menuName };

                case "itmsetphonepolicy":
                    return new itmCarReset(CmdParam.OrderCode.终端电话接听策略) { Text = menuName };

                case "itmcutgprsconnect":
                    return new itmCarReport(CmdParam.OrderCode.断开GPRS连接) { Text = menuName };

                case "itmshutterminal":
                    return new itmCarReport(CmdParam.OrderCode.终端关机) { Text = menuName };

                case "itmshutwirecommnica":
                    return new itmCarReport(CmdParam.OrderCode.关闭所有无线通信) { Text = menuName };

                case "itmtemppostracking":
                    return new JTBTemporaryPositionTracking(CmdParam.OrderCode.临时位置跟踪控制) { Text = menuName };

                case "itmmultirealreport":
                    return new JTBitmRealTimeReport(CmdParam.OrderCode.多条件实时位置监控) { Text = menuName };

                case "itmtermiheartinter":
                    return new JTBTerminalHeartInterval(CmdParam.OrderCode.设置终端心跳发送间隔) { Text = menuName };

                case "itmsetresandretrans":
                    return new JTBSetResponseAndRetransmission(CmdParam.OrderCode.设置应答超时时间和重传次数) { Text = menuName };

                case "itmsetprovdomid":
                    return new JTBSetProvincesDomainID(CmdParam.OrderCode.设置省市域ID) { Text = menuName };

                case "itmsetcarnumcolor":
                    return new JTBSetCarNumberAndColor(CmdParam.OrderCode.设置车牌和车牌颜色) { Text = menuName };

                case "itmwireupgradecmd":
                    return new JTBWirelessUpgradeCommand(CmdParam.OrderCode.无线升级) { Text = menuName };

                case "itmsettelebook":
                    return new JTBSetTelephoneBook(CmdParam.OrderCode.设置电话本) { Text = menuName };

                case "itmmuldataretrieval":
                    return new JTBMultimediaDataRetrieval(CmdParam.OrderCode.多媒体数据检索) { Text = menuName };

                case "itmmuldataupload":
                    return new JTBMultimediaDataUpload(CmdParam.OrderCode.多媒体数据上传) { Text = menuName };

                case "itmsoundrecordcmd":
                    return new JTBSoundRecordCommand(CmdParam.OrderCode.录音命令) { Text = menuName };

                case "itmeventset":
                    return new JTBEventSet(CmdParam.OrderCode.事件设置) { Text = menuName };

                case "itmordermenuset":
                    return new JTBEventSet(CmdParam.OrderCode.点播菜单设置) { Text = menuName };

                case "itmcumulatedrivetm":
                    return new JTBCumulativeDrivingTimeOfDay(CmdParam.OrderCode.当天累计驾驶时间门限) { Text = menuName };

                case "itmacquirecarspeed":
                    return new JTBAcquisitionCarSpeedData(CmdParam.OrderCode.采集行驶速度数据) { Text = menuName };

                case "itmsendquestion":
                    return new JTBSendQuestion(CmdParam.OrderCode.发送提问) { Text = menuName };

                case "itmplatpriphone":
                    return new itmModCenterPhone(CmdParam.OrderCode.监管平台特权短信号码) { Text = menuName };

                case "itmctrltermiconn":
                    return new JTBControlTerminalConnectBySMS(CmdParam.OrderCode.控制终端连接) { Text = menuName };

                case "itmsetpicparam":
                    return new JTBSetPictureParam(CmdParam.OrderCode.设置图片参数) { Text = menuName };

                case "itminfoservice":
                    return new JTBInformationService(CmdParam.OrderCode.信息服务) { Text = menuName };

                case "itmthoroughlycmd":
                    return new JTBThoroughlyCommand(CmdParam.OrderCode.透传数据命令) { Text = menuName };

                case "itmreissueposinfo":
                    return new JTBReplacementLocationInformation(CmdParam.OrderCode.补发车辆定位信息请求) { Text = menuName };

                case "itmreplaceposinfo":
                    return new JTBReplacementLocationInformation(CmdParam.OrderCode.申请交换指定车辆定位信息请求) { Text = menuName };

                case "itmcarcancelreq":
                    return new JTBCarCancelRequest(CmdParam.OrderCode.取消交换指定车辆定位信息请求) { Text = menuName };

                case "itmreppoliceinfo":
                    return new JTBReportPoliceInfo(CmdParam.OrderCode.上报警情信息) { Text = menuName };

                case "itmdynarepairinfor":
                    return new JTBDynamicRepairInformation(CmdParam.OrderCode.车辆动态信息补发请求) { Text = menuName };

                case "itmseteleccrawlradi":
                    return new JTBSetElectronicRailRadius(CmdParam.OrderCode.设置电子围栏半径) { Text = menuName };

                case "itmsinglemediaupcm":
                    return new JTBSigleMultimediaDataUpload(CmdParam.OrderCode.单条存储多媒体数据检索上传命令) { Text = menuName };

                case "itmdrivercodelicens":
                    return new itmCarReport(CmdParam.OrderCode.采集驾驶证号及对应的机动车驾驶证号) { Text = menuName };

                case "itmtraveltimeclock":
                    return new itmCarReport(CmdParam.OrderCode.采集记录仪的实时时钟) { Text = menuName };

                case "itmtravelcarparam":
                    return new itmCarReport(CmdParam.OrderCode.采集记录仪中的车辆特征系数) { Text = menuName };

                case "itmcarvincarnumclas":
                    return new itmCarReport(CmdParam.OrderCode.采集车辆VIN号和车牌号码以及车牌分类) { Text = menuName };

                case "itmjtbaccidentdata":
                    return new itmCarReport(CmdParam.OrderCode.采集记录仪中事故疑点数据) { Text = menuName };

                case "itmsetdricodelicens":
                    return new JTBSetDriverCodeAndLicense(CmdParam.OrderCode.设置驾驶员代码和驾驶证号码) { Text = menuName };

                case "itmsetcarvincarnum":
                    return new JTBSetCarVinAndClass(CmdParam.OrderCode.设置记录仪中的车辆VIN号和车牌号以及车牌分类) { Text = menuName };

                case "itmsettravelclock":
                    return new JTBTravellingClock(CmdParam.OrderCode.设置记录仪时钟) { Text = menuName };

                case "itmqueryterminalpar":
                    return new itmCarReport(CmdParam.OrderCode.查询终端参数配置) { Text = menuName };

                case "itmsetcarlock":
                    return new JTBitmCutPower(CmdParam.OrderCode.重工项目锁车) { Text = menuName };

                case "itmspeedandrank":
                    return new PlatformcheckRoadSpeedAndRank(CmdParam.OrderCode.设置分路段超速报警) { Text = menuName };
            }
            return form;
        }

        private string getMoreMsg()
        {
            string str = myMap.queueList.Count.ToString();
            string str2 = "";
            return ((((((((((str2 + string.Format("{0}", "报警(时间单位：秒)---------------------------") + Environment.NewLine) + string.Format(">>最后接收时间/接收数：{0}/{1}", this.sAlarmLastTime, this.sAlarmLastCnt) + Environment.NewLine) + string.Format(">>当前接收数/已处理数：{0}/{1}", this.sAlarmCnt, sAlarmShowCnt) + Environment.NewLine) + string.Format(">>接收/总时间：{0}", this.sAlarmOther) + Environment.NewLine) + string.Format("{0}", "最新位置(时间单位：秒)-----------------------") + Environment.NewLine) + string.Format(">>最后接收时间/接收数：{0}/{1}", this.sCurrentLastTime, this.sCurrentLastCnt) + Environment.NewLine) + string.Format(">>当前接收数/已处理数：{0}/{1}", this.sCurrentCnt, sCurrentShowCnt) + Environment.NewLine) + string.Format(">>接收/总时间：{0}", this.sCurrentOther) + Environment.NewLine) + string.Format("{0}", "地图-----------------------------------------") + Environment.NewLine) + string.Format(">>未处理Table数：{0}", str));
        }

        private CmdParam.OrderCode GetOrderCodeByName(string OrderCodeName)
        {
            System.Type enumType = typeof(CmdParam.OrderCode);
            foreach (string str in System.Enum.GetNames(enumType))
            {
                if (str.Trim().Equals(OrderCodeName))
                {
                    return (CmdParam.OrderCode)Convert.ToInt32(System.Enum.Format(enumType, System.Enum.Parse(enumType, str), "d"));
                }
            }
            MessageBox.Show("请检查ParamLibrary.dll!");
            return CmdParam.OrderCode.位置查询;
        }

        private string GetPwdString(string pwd, string time)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(pwd + time);
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes)).Replace("-", "");
        }

        private void getUpData(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Variable.bLogin)
            {
                m_tGetUpDataTimer.Interval = 300000.0;
                DataTable dtOnLine = null;
                int totalSeconds = 0;
                try
                {
                    dtOnLine = new DataTable();
                    DateTime now = DateTime.Now;
                    dtOnLine = RemotingClient.Updata_GetCarCurrentPos();
                    DateTime time2 = DateTime.Now;
                    if ((dtOnLine != null) && (dtOnLine.Rows.Count > 0))
                    {
                        this.sCurrentCnt = dtOnLine.Rows.Count.ToString();
                        sCurrentShowCnt = "0";
                        this.sCurrentLastCnt = this.sCurrentCnt;
                        this.sCurrentLastTime = DateTime.Now.ToString();
                        this.MianFormHandleCreated();
                        if (((myImportReport != null) && (myImportReport.m_dtImportCar != null)) && (myImportReport.m_dtImportCar.Rows.Count > 0))
                        {
                            foreach (DataRow row in myImportReport.m_dtImportCar.Rows)
                            {
                                foreach (DataRow row2 in dtOnLine.Select("SimNum='" + row["SimNum"].ToString() + "'"))
                                {
                                    dtOnLine.Rows.Remove(row2);
                                }
                            }
                        }
                        base.Invoke(this.myCarLog, new object[] { LogForm.LogFormType.最新位置, dtOnLine });
                        if (dtOnLine.Rows.Count > 0)
                        {
                            myCarList.setOnline(dtOnLine);
                            myMap.setShowCar(dtOnLine, false);
                        }
                        dtOnLine.Clear();
                        dtOnLine.Dispose();
                        dtOnLine = null;
                    }
                    else
                    {
                        object[] args = new object[2];
                        args[0] = LogForm.LogFormType.最新位置;
                        base.Invoke(this.myCarLog, args);
                        this.sCurrentCnt = "0";
                        sCurrentShowCnt = "0";
                        this.sCurrentLastCnt = "0";
                        this.sCurrentLastTime = DateTime.Now.ToString();
                    }
                    DateTime time3 = DateTime.Now;
                    this.sCurrentOther = "";
                    TimeSpan span = (TimeSpan)(time2 - now);
                    totalSeconds = (int)span.TotalSeconds;
                    TimeSpan span2 = (TimeSpan)(time3 - now);
                    this.sCurrentOther = this.sCurrentOther + totalSeconds.ToString() + "/" + ((int)span2.TotalSeconds).ToString();
                }
                catch (ObjectDisposedException)
                {
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("取得上行最新位置数据", exception.ToString());
                    }
                }
                finally
                {
                    if (dtOnLine != null)
                    {
                        dtOnLine.Clear();
                        dtOnLine.Dispose();
                        dtOnLine = null;
                    }
                    if (totalSeconds >= 2)
                    {
                        m_tGetUpDataTimer.Interval = 200.0;
                    }
                    else
                    {
                        m_tGetUpDataTimer.Interval = this.iGetUpDateTime;
                    }
                }
            }
        }

        private void getUpdateClient()
        {
            string str = this.getCurrentVersion();
            if (!string.IsNullOrEmpty(str))
            {
                this.resUpdate = this.getUpdateClientList(str);
            }
        }

        private Response getUpdateClientList(string sCurrentVersion)
        {
            return RemotingClient.getUpdateClientList(sCurrentVersion);
        }

        public void gotoWebSystem()
        {
            if (Variable.sWebMenuList.Trim().Length > 0)
            {
                if (this._webSystem == null)
                {
                    this._webSystem = new WebSystem(this);
                }
                this.isWebSystem = true;
                string[] strArray = Variable.sWebMenuList.Split(new char[] { ';' });
                if (strArray[1].Equals("1", StringComparison.OrdinalIgnoreCase))
                {
                    this.LoadWebSystem.Set();
                }
                this._webSystem.GotoWeb(strArray[0]);
            }
        }

        private void HeartMain(object sender, System.Timers.ElapsedEventArgs arg)
        {
            this.tHeart.Interval = 300000.0;
            if (!RemotingClient.Test() || !Variable.bLogin)
            {
                try
                {
                    base.Invoke(this.myCarLine, new object[] { "1" });
                    if (this.execConnection())
                    {
                        base.Invoke(this.myCarLine, new object[] { "0" });
                        Record.execFileRecord("心跳", "已重新连接上服务器");
                    }
                    else
                    {
                        base.Invoke(this.myCarLine, new object[] { "与服务器的连接超时，正在登陆中心....." });
                    }
                }
                catch (InvalidOperationException exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("心跳进程", exception.ToString());
                    }
                }
                catch (Exception exception2)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("心跳进程", exception2.ToString());
                    }
                }
                finally
                {
                    this.tHeart.Interval = 5000.0;
                }
            }
            this.tHeart.Interval = 5000.0;
        }

        private void initMenu()
        {
            try
            {
                this.menuList.Clear();
                this.parentMenuList.Clear();
                this.topMenuList.Clear();
                this.initMenuList(this.MenuStripList.Items);
                this.initTopMenuList(this.msMenu.Items);
                string str = "";
                DataRow[] rowArray = m_dtMenu.Select("MenuCode='itemOther1'");
                if (rowArray.Length > 0)
                {
                    str = rowArray[0]["id"].ToString();
                    m_dtMenu.Rows.Remove(rowArray[0]);
                }
                string rowFilter = "ParentID is null ";
                if (str.Length > 0)
                {
                    rowFilter = rowFilter + "or ParentID='" + str + "'";
                }
                DataView dv = new DataView(m_dtMenu, rowFilter, m_dtMenu.Columns.Contains("MenuOrder") ? "MenuOrder Asc" : "", DataViewRowState.CurrentRows);
                this.changeMenuList(dv, null);
                this.afterInitMenuList();
                this.addUserCollectionMenu();
                this.MenuStripList.Items["MenuItemTradeApp"].Text = Variable.sMenuItemTradeApp;
                this.msMenu.Items["MenuTradeApp"].Text = Variable.sMenuItemTradeApp;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("工作站菜单生成", exception.Message);
            }
        }

        private void initMenuList(ToolStripItemCollection menu)
        {
            foreach (ToolStripItem item in menu)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem item2 = item as ToolStripMenuItem;
                    if ((item2.Tag != null) && (item2.Tag.ToString().Trim().Length > 0))
                    {
                        string str = item2.Tag.ToString().ToLower() + "1".ToString();
                        this.menuList[str] = item2;
                        str = string.Empty;
                    }
                    if (item2.HasDropDownItems)
                    {
                        this.parentMenuList.Add(item2);
                        this.initMenuList(item2.DropDownItems);
                    }
                }
                else
                {
                    item.Visible = false;
                }
            }
        }

        private void initTopMenuList(ToolStripItemCollection itms)
        {
            foreach (ToolStripItem item in itms)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem item2 = item as ToolStripMenuItem;
                    if ((item2.Tag != null) && (item2.Tag.ToString().Trim().Length > 0))
                    {
                        string str = item2.Tag.ToString().ToLower() + "1".ToString();
                        this.topMenuList[str] = item2;
                        str = string.Empty;
                    }
                    if (item2.HasDropDownItems)
                    {
                        this.parentMenuList.Add(item2);
                        this.initTopMenuList(item2.DropDownItems);
                    }
                }
            }
        }

        /// <summary>
        /// 验证类型是否为合法插件类型
        /// </summary>
        /// <param name="t">目标类型</param>
        /// <returns></returns>
        private bool IsValidPlugin(System.Type t)
        {
            foreach (System.Type type in t.GetInterfaces())
            {
                if (type.FullName == "GpsClient.Plugin.IPlugin")
                {
                    return true;
                }
            }
            return false;
        }

        private void m_tGetAlarmUpDataTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Variable.bLogin)
            {
                m_tGetAlarmUpDataTimer.Interval = 300000.0;
                DataTable dtAlarm = null;
                int totalSeconds = 0;
                try
                {
                    DateTime now = DateTime.Now;
                    dtAlarm = RemotingClient.Updata_GetCarAlarmLog();
                    DateTime time2 = DateTime.Now;
                    if ((dtAlarm != null) && (dtAlarm.Rows.Count > 0))
                    {
                        this.sAlarmCnt = dtAlarm.Rows.Count.ToString();
                        sAlarmShowCnt = "0";
                        this.sAlarmLastTime = DateTime.Now.ToString();
                        this.sAlarmLastCnt = this.sAlarmCnt;
                        this.MianFormHandleCreated();
                        base.Invoke(this.myCarLog, new object[] { LogForm.LogFormType.报警日志, dtAlarm });
                        myCarList.setAlarm(dtAlarm);
                        myMap.setShowCar(dtAlarm, true);
                        dtAlarm.Clear();
                        dtAlarm.Dispose();
                        dtAlarm = null;
                    }
                    else
                    {
                        object[] args = new object[2];
                        args[0] = LogForm.LogFormType.报警日志;
                        base.Invoke(this.myCarLog, args);
                        this.sAlarmCnt = "0";
                        sAlarmShowCnt = "0";
                        this.sAlarmLastCnt = "0";
                        this.sAlarmLastTime = DateTime.Now.ToString();
                    }
                    DateTime time3 = DateTime.Now;
                    TimeSpan span = (TimeSpan)(time2 - now);
                    totalSeconds = (int)span.TotalSeconds;
                    this.sAlarmOther = "";
                    TimeSpan span2 = (TimeSpan)(time3 - now);
                    this.sAlarmOther = this.sAlarmOther + totalSeconds.ToString() + "/" + ((int)span2.TotalSeconds).ToString();
                }
                catch (ObjectDisposedException)
                {
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("取得上行报警数据", exception.ToString());
                    }
                }
                finally
                {
                    if (dtAlarm != null)
                    {
                        dtAlarm.Clear();
                        dtAlarm.Dispose();
                        dtAlarm = null;
                    }
                    if (totalSeconds >= 2)
                    {
                        m_tGetAlarmUpDataTimer.Interval = 200.0;
                    }
                    else
                    {
                        m_tGetAlarmUpDataTimer.Interval = this.iGetUpDateTime;
                    }
                }
            }
        }

        private void m_tGetNewLogTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Variable.bLogin)
            {
                m_tGetNewLogTimer.Interval = 300000.0;
                DataTable table = null;
                try
                {
                    table = new DataTable();
                    table = RemotingClient.Updata_GetCarNewLog();
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        this.MianFormHandleCreated();
                        base.Invoke(this.myCarLog, new object[] { LogForm.LogFormType.最新日志, table });
                        table.Clear();
                        table.Dispose();
                        table = null;
                    }
                    table = new DataTable();
                    table = RemotingClient.Updata_GetCarPic();
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        this.MianFormHandleCreated();
                        base.Invoke(this.myCarLog, new object[] { LogForm.LogFormType.图像列表, table });
                        table.Clear();
                        table.Dispose();
                        table = null;
                    }
                }
                catch (ObjectDisposedException)
                {
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("取得上行最新日志与图像报文数据", exception.ToString());
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
                    m_tGetNewLogTimer.Interval = this.iGetUpDateTime;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((Variable.sProjectID.Equals("zhongtong", StringComparison.OrdinalIgnoreCase) && !this.isWebSystem) && (Variable.sWebMenuList.Trim().Length > 0))
                {
                    this.gotoWebSystem();
                    e.Cancel = true;
                    return;
                }
                if (!this.chkAllSubFormClosed())
                {
                    MessageBox.Show("请先关闭子窗体！");
                    e.Cancel = true;
                    return;
                }
                WaitForm.Hide();
                if (this.m_bCloseAsk)
                {
                    base.TopMost = true;
                    if (MessageBox.Show("是否退出系统？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        base.TopMost = false;
                        e.Cancel = true;
                        return;
                    }
                    Variable.bLogin = false;
                    if ((myImportReport != null) && myImportReport.IsHandleCreated)
                    {
                        myImportReport.delImportWatch();
                    }
                    RemotingClient.CutOff();
                    string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
                    if (this.m_bSaveLayout)
                    {
                        this.dockPanel.SaveAsXml(fileName);
                    }
                    else if (System.IO.File.Exists(fileName))
                    {
                        System.IO.File.Delete(fileName);
                    }
                    IniFile.WriteIniFile();
                }
                if (this.recentMenu != null)
                {
                    this.recentMenu.SaveMenu();
                }
                this.unLoadPlugin();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("退出系统", exception.Message);
            }
            this.tHeart.Stop();
            m_tGetUpDataTimer.Stop();
            m_tGetNewLogTimer.Stop();
            m_tGetAlarmUpDataTimer.Stop();
            m_tRegistrationTimer.Stop();
            Record.execFileRecord(Variable.sUserId, "退出系统");
            WaitForm.Hide();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.D))
            {
                string sMsg = this.getMoreMsg();
                this.myPerformanceView = new PerformanceView(sMsg);
                this.myPerformanceView.Visible = false;
                this.myPerformanceView.Show(this);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.setToolEnable(false);
            this.setToolState();
            this.setManagerSystemState();
            this.setStateConn();
            this.setStateCustomerService();
            this.iGetUpDateTime = int.Parse(Variable.sGetUpDateTime);
            this.myCarLog = new dCarLog(this.RefreshNewLogMsg);
            this.myCloseForm = new dCloseForm(this.MenuExist_Click);
            this.myCarLine = new dexecCarLine(this.execCarLine);
            m_tGetAlarmUpDataTimer = new System.Timers.Timer((double)this.iGetUpDateTime);
            m_tGetAlarmUpDataTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.m_tGetAlarmUpDataTimer_Elapsed);
            m_tGetAlarmUpDataTimer.Enabled = true;
            m_tGetUpDataTimer = new System.Timers.Timer((double)this.iGetUpDateTime);
            m_tGetUpDataTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.getUpData);
            m_tGetUpDataTimer.Enabled = true;
            m_tGetNewLogTimer = new System.Timers.Timer((double)this.iGetUpDateTime);
            m_tGetNewLogTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.m_tGetNewLogTimer_Elapsed);
            m_tGetNewLogTimer.Enabled = true;
            this.tHeart.Elapsed += new System.Timers.ElapsedEventHandler(this.HeartMain);
            this.tHeart.Enabled = true;
            m_tRegistrationTimer = new System.Timers.Timer(3600000.0);
            m_tRegistrationTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.execRegistration);
            m_tRegistrationTimer.Enabled = true;
            this.addPlugin();
            this.tsMenu.Items["tsbArrowhead"].Visible = this.arrPlugins.Count > 0;
            this.GetLoginSysAllMenu();
            if (Variable.sCarServerTimeRemind.Equals("1", StringComparison.OrdinalIgnoreCase))
            {
                this.GetCarReachDateData();
            }
            base.MouseWheel += new MouseEventHandler(this.MainForm_MouseWheel);
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            myMap.MouseWheel(e.Delta);
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void MenuAddPoint_Click(object sender, EventArgs e)
        {
            myMap.setPointTool();
        }

        private void MenuArrowhead_Click(object sender, EventArgs e)
        {
            myMap.setArrowheadTool();
        }

        private void MenuCarCommand_DropDownOpening(object sender, EventArgs e)
        {
        }

        private void MenuCarImageDesc_Click(object sender, EventArgs e)
        {
            new CarImage().ShowDialog();
        }

        private void MenuCarList_Click(object sender, EventArgs e)
        {
            if (this.MenuCarList.Checked)
            {
                myCarList.TabText = "车辆列表";
                myCarList.Show(this.dockPanel);
            }
            else
            {
                myCarList.Hide();
            }
        }

        private void MenuCenter_Click(object sender, EventArgs e)
        {
            myMap.setZoomToCenter();
        }

        private void MenuChangePw_Click(object sender, EventArgs e)
        {
            this.execChangeUserPw();
        }

        private void MenuClearAlarmRegion_Click(object sender, EventArgs e)
        {
            myMap.execClearAllAlarm();
        }

        private void MenuClearAllCar_Click(object sender, EventArgs e)
        {
            myMap.ClearAllCar();
        }

        private void MenuClearFlag_Click(object sender, EventArgs e)
        {
            myMap.execClearAllFlag();
            POITypes = string.Empty;
        }

        private void MenuClearImage_Click(object sender, EventArgs e)
        {
            myMap.deleteSpatialQueryFlag();
        }

        private void MenuCollection_Click(object sender, EventArgs e)
        {
            SetMenuCollection menus2 = new SetMenuCollection(m_dtMenu)
            {
                Text = "收藏夹"
            };
            menus2.ShowDialog();
        }

        private void MenuConnection_Click(object sender, EventArgs e)
        {
            if (this.execConnectionServer())
            {
                this.tHeart.Enabled = true;
            }
        }

        private void MenuContrail_DropDownOpening(object sender, EventArgs e)
        {
            if (myCarList.getSelectedCnt() == 1)
            {
                this.MenuContrail.DropDownItems["MenuContrailReturn"].Enabled = true;
            }
            else
            {
                this.MenuContrail.DropDownItems["MenuContrailReturn"].Enabled = false;
            }
        }

        private void MenuCut_Click(object sender, EventArgs e)
        {
            this.execCutOffServer();
        }

        private void MenuDelPoint_Click(object sender, EventArgs e)
        {
            myMap.setDelPoint();
        }

        private void MenuDistance_Click(object sender, EventArgs e)
        {
            myMap.setMeasureTool();
        }

        private void MenuExist_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void MenuFlagTypeDisplayControl_Click(object sender, EventArgs e)
        {
            new FlagForm(myMap.wbMap).ShowDialog();
        }

        private void MenuGpsAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                string time = new StreamReader(WebRequest.Create(string.Format("http://{0}:{1}/StarGps/loginC.aspx?getTick=1&t=" + DateTime.Now.Ticks.ToString(), Variable.sGpsIp, Variable.sGpsPort)).GetResponse().GetResponseStream()).ReadToEnd();
                Process.Start(string.Format("http://{0}:{1}/StarGps/loginC.aspx?u={2}&s={3}&t={4}", new object[] { Variable.sGpsIp, Variable.sGpsPort, Variable.sUserId, this.GetPwdString(Variable.sDBPwd, time), time }));
            }
            catch (Exception exception)
            {
                Record.execFileRecord("单点登录管理分析系统", exception.Message);
                Process.Start(string.Format("http://{0}:{1}/StarGps/login.aspx", Variable.sGpsIp, Variable.sGpsPort));
            }
        }

        private void MenuHelp_Click(object sender, EventArgs e)
        {
        }

        private void MenuItemAnalyse_Click(object sender, EventArgs e)
        {
            myMap.setPathToolSTD();
        }

        private void MenuItemQuestionManage_Click(object sender, EventArgs e)
        {
            new JTBQuestionManage().ShowDialog();
        }

        private void MenuItemSmallArea_Click(object sender, EventArgs e)
        {
            myMap.setSmallArea();
        }

        private void MenuLogList_Click(object sender, EventArgs e)
        {
            if (this.MenuLogList.Checked)
            {
                myLogForms.TabText = "日志列表";
                myLogForms.Show(this.dockPanel);
            }
            else
            {
                myLogForms.Hide();
            }
        }

        private void MenuMove_Click(object sender, EventArgs e)
        {
            myMap.setPanTool();
        }

        private void MenuRegistration_Click(object sender, EventArgs e)
        {
            new Registration().ShowDialog();
        }

        private void MenuSearchCarList_Click(object sender, EventArgs e)
        {
            if (this.MenuSearchCarList.Checked)
            {
                mySearchCarList.TabText = "拉框查车列表";
                mySearchCarList.Show(this.dockPanel);
            }
            else
            {
                mySearchCarList.Hide();
            }
        }

        private void MenuSearchFeature_Click(object sender, EventArgs e)
        {
            if (this.MenuSearchFeature.Checked)
            {
                mySearchFeature.TabText = "地物查询";
                mySearchFeature.Show(this.dockPanel);
            }
            else
            {
                mySearchFeature.Hide();
            }
        }

        private void MenuSetParam_Click(object sender, EventArgs e)
        {
            this.execSetParam();
            if (Variable.bMapRefresh)
            {
                myMap.execRefrshMap();
                GisService.RefreshService();
            }
        }

        private void MenuSetToMapCenter_Click(object sender, EventArgs e)
        {
            myMap.setMapToCenter();
        }

        private void MenuShowAll_Click(object sender, EventArgs e)
        {
            myMap.zoomToMaxExtent();
        }

        private void MenuXp_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item2 in this.MenuSkin.DropDownItems)
            {
                if (item2.Name == item.Name)
                {
                    Variable.sSkinDataIndex = item.Tag.ToString();
                    this.seSkin.SkinFile = Variable.sSkinFiles[int.Parse(Variable.sSkinDataIndex)];
                    if ((myImportReport != null) && myImportReport.IsHandleCreated)
                    {
                        try
                        {
                            myImportReport.seSkin.SkinFile = Variable.sSkinFiles[int.Parse(Variable.sSkinDataIndex)];
                        }
                        catch
                        {
                        }
                    }
                    item2.Checked = true;
                }
                else
                {
                    item2.Checked = false;
                }
            }
        }

        private void MenuZoomDown_Click(object sender, EventArgs e)
        {
            myMap.setZoomDownTool();
        }

        private void MenuZoomToMapCenter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variable.sMapSign))
            {
                MessageBox.Show("未设置标志点！");
            }
            else
            {
                myMap.setMap(Variable.sMapSign);
            }
        }

        private void MenuZoomUp_Click(object sender, EventArgs e)
        {
            myMap.setZoomUpTool();
        }

        private void MianFormHandleCreated()
        {
            while (!base.IsHandleCreated && Variable.bLogin)
            {
                Thread.Sleep(200);
            }
        }

        public static void NoticeFormShow(int iNoticeCnt, int iReCnt)
        {
            try
            {
                if ((myNoticeForm == null) || !myNoticeForm.IsHandleCreated)
                {
                    myNoticeForm = new NoticeForm();
                    myNoticeForm.showInfo(iNoticeCnt.ToString(), iReCnt.ToString());
                    myNoticeForm.Show();
                }
                else
                {
                    myNoticeForm.showInfo(iNoticeCnt.ToString(), iReCnt.ToString());
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("掉线通知提示", exception.Message);
            }
        }

        public static void NoticeFormShow(int iNoticeCnt, int iReCnt, bool IsNotice)
        {
            try
            {
                string sText = "上下线通知";
                if ((myNoticeFormEx == null) || !myNoticeFormEx.IsHandleCreated)
                {
                    myNoticeFormEx = new NoticeForm(sText);
                    myNoticeFormEx.showInfo(iNoticeCnt.ToString(), iReCnt.ToString(), sText);
                    myNoticeFormEx.Show();
                }
                else
                {
                    myNoticeFormEx.showInfo(iNoticeCnt.ToString(), iReCnt.ToString(), sText);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("掉线通知提示", exception.Message);
            }
        }

        private void OpenDialog(string menuTag, string menuName)
        {
            CarForm module = null;
            switch (menuTag.ToLower())
            {
                //添加打开视频窗口 2013.12.16 周立山
                //case "itmcarvideo":
                //    {  
                //        if (_carVideoForm != null)
                //        {
                //            if (!_carVideoForm.IsDisposed)
                //            {
                //                try
                //                {
                //                    _carVideoForm.Close();
                //                }
                //                catch { }
                //            }
                //            _carVideoForm = null;
                //        }
                //        _carVideoForm = new CarVideoForm(myCarList.SelectedCarId);
                //        _carVideoForm.Show();
                //    }
                //    break;
                case "itmquery1":
                    this.RealTimePlaceQuery();
                    break;

                case "itmimportreport":
                    this.StressWatchQuery();
                    break;

                case "itmcarplaytrack":
                    this.ContrailReturnQuery();
                    break;

                case "batchsetareaalarm":
                    {
                        itmSetRegionAlarmEx ex = new itmSetRegionAlarmEx(CmdParam.OrderCode.区域报警设置)
                        {
                            Text = menuName
                        };
                        ex.ShowDialog();
                        ex.Dispose();
                        ex = null;
                        break;
                    }
                case "itmshowoutregion":
                    myMap.execShowAlarmRegion(Client.Map.ShowRegionType.越出区域);
                    break;

                case "itmshowinregion":
                    myMap.execShowAlarmRegion(Client.Map.ShowRegionType.进入区域);
                    break;

                case "itmpresetregion":
                    {
                        m2mPreSetRegion region = new m2mPreSetRegion(itmPreSetPath.PreType.预设报警区域)
                        {
                            Text = menuName
                        };
                        region.ShowDialog();
                        region.Dispose();
                        region = null;
                        break;
                    }
                case "itmshowmultioutreg":
                    myMap.execShowAlarmRegion(Map.ShowRegionType.多功能越出区域);
                    break;

                case "itmshowmultiinreg":
                    myMap.execShowAlarmRegion(Map.ShowRegionType.多功能进入区域);
                    break;

                case "itmpresetmultireg":
                    {
                        itmPreSetRegion region2 = new itmPreSetRegion(itmPreSetPath.PreType.预设多功能报警区域)
                        {
                            Text = menuName
                        };
                        region2.ShowDialog();
                        region2.Dispose();
                        region2 = null;
                        break;
                    }
                case "itmpresetstation":
                    {
                        itmPreSetStation itmPreSetStation = new itmPreSetStation
                        {
                            Text = menuName
                        };
                        itmPreSetStation.ShowDialog();
                        itmPreSetStation.Dispose();
                        break;
                    }
                case "itmshowpath":
                    myMap.execShowPath();
                    break;

                case "itmclearpath":
                    myMap.execClearPath();
                    break;

                case "itmpresetpath":
                    {
                        itmPreSetPath path = new itmPreSetPath(itmPreSetPath.PreType.预设报警路线)
                        {
                            Text = menuName
                        };
                        path.ShowDialog();
                        path.Dispose();
                        path = null;
                        break;
                    }
                case "itmzbnavigation":
                    MessageBox.Show("请在地图上选择目的地！");
                    myMap.setNavigationTool();
                    break;

                case "itmzbdistributary":
                    MessageBox.Show("请在地图上选择目的地！");
                    myMap.setDistributaryTool();
                    break;

                case "itmsetcarinit":
                    {
                        itmSetCarInit init = new itmSetCarInit("车台初始化参数设置")
                        {
                            Text = menuName
                        };
                        init.ShowDialog();
                        init.Dispose();
                        init = null;
                        break;
                    }
                case "itmclearcartrack":
                    myMap.execDeleteCar(myCarList.SelectedCarId);
                    myCarList.setCarOffline(myCarList.SelectedCarId);
                    break;

                case "itmcardetail":
                    {
                        itmCarDetail detail = new itmCarDetail
                        {
                            Text = menuName
                        };
                        detail.ShowDialog();
                        detail.Dispose();
                        detail = null;
                        break;
                    }
                default:
                    module = this.GetModule(menuTag, menuName);
                    break;
            }
            if (module != null)
            {
                module.ShowDialog();
                module.Dispose();
                module = null;
            }
            if (((Process.GetCurrentProcess().WorkingSet64 / 1024) / 1000) > 1000)
            {
                GC.Collect();
                GC.Collect();
                GC.Collect();
                if (base.WindowState == FormWindowState.Normal)
                {
                    base.WindowState = FormWindowState.Minimized;
                    base.WindowState = FormWindowState.Normal;
                }
                else if (base.WindowState == FormWindowState.Maximized)
                {
                    base.WindowState = FormWindowState.Minimized;
                    base.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void pdMap_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(this.memoryImage, 0, 0);
        }

        private void RealTimePlaceQuery()
        {
            string selectedCarNum = myCarList.SelectedCarNum;
            PosReport posReport = new PosReport
            {
                OrderCode = CmdParam.OrderCode.位置查询,
                CompressionUpTime = 0,
                isCompressed = CmdParam.IsCompressed.单次传送,
                ReportType = CmdParam.ReportType.定次汇报,
                ReportTiming = 1,
                LowReportCycle = 60,
                ReportWhenStop = CmdParam.ReportWhenStop.汇报,
                IsAutoCalArc = 0,
                protocolType = CarProtocolType.交通厅
            };
            Response response = RemotingClient.DownData_SetPosReport(CmdParam.ParamType.CarNum, selectedCarNum, "", CmdParam.CommMode.未知方式, posReport);
            if (response.ResultCode != 0L)
            {
                MessageBox.Show(response.ErrorMsg);
            }
            else
            {
                RemotingClient.Car_SaveFormCmdParam(response.OrderIDParam, "实时位置查询", "");
            }
        }

        private void RefreshNewLogMsg(LogForm.LogFormType oType, DataTable dtMsgResult)
        {
            switch (oType)
            {
                case LogForm.LogFormType.最新日志:
                    {
                        DataTable dtLogResult = null;
                        DataTable table2 = new DataTable();
                        table2 = dtMsgResult.Clone();
                        DataTable table3 = null;
                        foreach (DataRow row in dtMsgResult.Rows)
                        {
                            if (row["OrderName"].ToString().Equals("提问消息应答"))
                            {
                                string str = JTBSendQuestion.sOrderId[row["carid"].ToString().Trim()].ToString();
                                if (string.IsNullOrEmpty(str) || !row["OrderID"].ToString().Equals(str))
                                {
                                    row["describe"] = row["describe"].ToString() + "，未找到对应问题";
                                }
                                else
                                {
                                    try
                                    {
                                        //string str2 = row["describe"].ToString().Split(new char[] { ':', 65306 }, StringSplitOptions.RemoveEmptyEntries)[1];
                                        string str2 = row["describe"].ToString().Split(new char[] { (char)65306 }, StringSplitOptions.RemoveEmptyEntries)[1];
                                        string format = " select  Param from dbo.GpsCarSetParam where MsgType  = '16406' and carId = '{0}' ";
                                        string str4 = row["carId"].ToString();
                                        DataTable table4 = RemotingClient.ExecSql(string.Format(format, str4));
                                        if ((table4 != null) && (table4.Rows.Count > 0))
                                        {
                                            string str5 = table4.Rows[0][0].ToString();
                                            int index = str5.IndexOf("txtanswerID");
                                            if (index >= 0)
                                            {
                                                str5 = str5.Substring(index).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)[0];
                                                if (str5.IndexOf(str2) < 0)
                                                {
                                                    row["describe"] = row["describe"].ToString() + "，未找到对应答案信息。";
                                                }
                                                else
                                                {
                                                    string[] strArray2 = str5.Split(new char[] { '=' })[1].Split(new char[] { ',' });
                                                    string str6 = "";
                                                    foreach (string str7 in strArray2)
                                                    {
                                                        if (str7.IndexOf(str2) >= 0)
                                                        {
                                                            str6 = str7.Split(new char[] { '、' })[1];
                                                        }
                                                    }
                                                    row["describe"] = row["describe"].ToString() + "、" + str6;
                                                }
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            if (row["MsgType"].Equals("43521"))
                            {
                                if (myCarList.tvList.hasCarPath.ContainsKey(row["CarId"].ToString()))
                                {
                                    if (dtLogResult == null)
                                    {
                                        dtLogResult = new DataTable();
                                        dtLogResult = dtMsgResult.Clone();
                                    }
                                    if (table3 == null)
                                    {
                                        table3 = new DataTable();
                                        table3 = dtMsgResult.Clone();
                                    }
                                    if (dtMsgResult.Columns.Contains("addMsgType"))
                                    {
                                        if (row["addMsgType"].ToString().Equals("-888"))
                                        {
                                            table3.Rows.Add(row.ItemArray);
                                            RemotingClient.DownData_SetLastDotQuery(CmdParam.ParamType.CarId, row["CarId"].ToString(), "", CmdParam.CommMode.未知方式, CmdParam.OrderCode.末次位置查询);
                                        }
                                        else if (row["addMsgType"].ToString().Equals("-999"))
                                        {
                                            table3.Rows.Add(row.ItemArray);
                                            myCarList.cancelWatchNode(myCarList.tvList.getNodeById(row["CarId"].ToString()));
                                        }
                                        else
                                        {
                                            dtLogResult.Rows.Add(row.ItemArray);
                                        }
                                    }
                                    else
                                    {
                                        dtLogResult.Rows.Add(row.ItemArray);
                                    }
                                }
                            }
                            else if (row["MsgType"].Equals("4353"))
                            {
                                //屏蔽自动查岗
                                table2.Rows.Add(row.ItemArray);
                                string[] responseId = row["Describe"].ToString().Replace("消息ID：", "").Replace("消息内容：", "").Replace("查岗对象类型：", "").Replace("查岗对象的ID：", "").Split(new char[] { ',' });
                                if (responseId.Length > 0)
                                {
                                    new JTBPlatformPostResponse(CmdParam.OrderCode.平台查岗应答, responseId) { StartPosition = FormStartPosition.CenterScreen }.Show(Program.mainForm);
                                }
                            }
                            else if (row["MsgType"].Equals("4911"))
                            {
                                table2.Rows.Add(row.ItemArray);
                                string[] strArray5 = row["Describe"].ToString().Replace("消息ID：", "").Replace("消息内容：", "").Replace("查岗对象类型：", "").Replace("查岗对象的ID：", "").Split(new char[] { ',' });
                                if (strArray5.Length > 0)
                                {
                                    new JTBPlatformPostResponse(CmdParam.OrderCode.下发平台间报文应答, strArray5) { StartPosition = FormStartPosition.CenterScreen }.Show(Program.mainForm);
                                }
                            }
                            else if (row["MsgType"].Equals("4354"))
                            {
                                if (dtLogResult == null)
                                {
                                    dtLogResult = new DataTable();
                                    dtLogResult = dtMsgResult.Clone();
                                }
                                dtLogResult.Rows.Add(row.ItemArray);
                                string[] strArray6 = row["Describe"].ToString().Replace("报警督办ID：", "").Split(new char[] { ',' });
                                if (strArray6.Length > 0)
                                {
                                    //new JTBCallPoliceSuperviseReponsion(CmdParam.OrderCode.报警督办应答, strArray6[0], row["CarNum"].ToString()) { StartPosition = FormStartPosition.CenterScreen }.Show(Program.mainForm);
                                    new JTBCallPoliceSuperviseReponsion(CmdParam.OrderCode.报警督办应答, row["Describe"].ToString(), row["CarNum"].ToString()) { StartPosition = FormStartPosition.CenterScreen }.Show(Program.mainForm);
                                }
                            }
                            else if (row["MsgType"].Equals("4355"))
                            {
                                if (dtLogResult == null)
                                {
                                    dtLogResult = new DataTable();
                                    dtLogResult = dtMsgResult.Clone();
                                }
                                dtLogResult.Rows.Add(row.ItemArray);
                            }
                            else if (row["Describe"].ToString().IndexOf("电子运单内容：") >= 0)
                            {
                                EbillTextList[row["carId"].ToString()] = row["Describe"].ToString().Substring(row["Describe"].ToString().IndexOf("：") + 1);
                                table2.Rows.Add(row.ItemArray);
                            }
                            else if (row["OrderName"].ToString().Equals("驾驶员身份信息应答"))
                            {
                                string str8 = row["Carid"].ToString();
                                string str9 = " select Name from GpsDriver where carid = '{0}' ";
                                DataTable table5 = RemotingClient.ExecSql(string.Format(str9, str8));
                                if ((table5 != null) && (table5.Rows.Count > 0))
                                {
                                    ThreeStateTreeNode node = myCarList.tvList.getNodeById(str8);
                                    if (node != null)
                                    {
                                        node.DriverName = table5.Rows[0][0].ToString();
                                    }
                                }
                                table2.Rows.Add(row.ItemArray);
                            }
                            else
                            {
                                table2.Rows.Add(row.ItemArray);
                                if ((myMap.mySmallArea != null) && myMap.mySmallArea.IsHandleCreated)
                                {
                                    this.SmallAreaAddCarList(row);
                                }
                            }
                        }
                        myLogForms.myNewLog.addLogMsg(table2);
                        myLogForms.myNoticeLog.addLogMsg(dtLogResult);
                        myLogForms.myNoticeLogEx.addLogMsg(table3);
                        table2.Clear();
                        table2.Dispose();
                        table2 = null;
                        if (dtLogResult != null)
                        {
                            dtLogResult.Clear();
                            dtLogResult.Dispose();
                            dtLogResult = null;
                        }
                        break;
                    }
                case LogForm.LogFormType.最新位置:
                    myLogForms.myCurrentPos.addLogMsg(dtMsgResult);
                    break;

                case LogForm.LogFormType.报警日志:
                    myLogForms.myAlarmLog.addLogMsg(dtMsgResult);
                    if ((this.myPerformanceView != null) && this.myPerformanceView.IsHandleCreated)
                    {
                        this.myPerformanceView.SetViewText(this.getMoreMsg());
                    }
                    break;

                case LogForm.LogFormType.图像列表:
                    myLogForms.myImageList.addLogMsg(dtMsgResult);
                    break;
            }
            gpsClientObj.execSendObject((int)oType, dtMsgResult);
            dtMsgResult = null;
        }

        private void RespCallback(IAsyncResult ar)
        {
            if (!this.bTimeOut)
            {
                this.bRespCallBack = false;
            }
        }

        public void SetAllControlVisible(bool isvisible, string excludeControlName)
        {
            this.isWebSystem = !isvisible;
            if (!isvisible)
            {
                base.Controls.Find(excludeControlName, true)[0].BringToFront();
            }
            else
            {
                base.Controls.Find(excludeControlName, true)[0].SendToBack();
            }
        }

        private void setManagerSystemState()
        {
            if (Variable.sShowManagerSystem.Equals("0", StringComparison.OrdinalIgnoreCase))
            {
                ToolStripItem[] itemArray = this.tsMenu.Items.Find("tsbGpsAdmin", true);
                if ((itemArray != null) && (itemArray.Length > 0))
                {
                    itemArray[0].Visible = false;
                    (this.msMenu.Items["MenuView"] as ToolStripMenuItem).DropDownItems["MenuGpsAdmin"].Visible = false;
                    (this.msMenu.Items["MenuView"] as ToolStripMenuItem).DropDownItems["toolStripSeparator20"].Visible = false;
                }
            }
            else
            {
                ToolStripItem[] itemArray2 = this.tsMenu.Items.Find("tsbGpsAdmin", true);
                if ((itemArray2 != null) && (itemArray2.Length > 0))
                {
                    itemArray2[0].Visible = true;
                    (this.msMenu.Items["MenuView"] as ToolStripMenuItem).DropDownItems["MenuGpsAdmin"].Visible = true;
                    (this.msMenu.Items["MenuView"] as ToolStripMenuItem).DropDownItems["toolStripSeparator20"].Visible = true;
                }
            }
        }

        public void setMap(string sMapsStr)
        {
            if (this.cmbSelectMap.Items.Count <= 0)
            {
                try
                {
                    this.cmbSelectMap.ComboBox.Items.Clear();
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
                    this.cmbSelectMap.ComboBox.DisplayMember = "Text";
                    this.cmbSelectMap.ComboBox.ValueMember = "values";
                    this.cmbSelectMap.ComboBox.DataSource = table;
                    if (this.cmbSelectMap.ComboBox.SelectedIndex >= 0)
                    {
                        m_sSelectedMap = this.cmbSelectMap.ComboBox.SelectedValue.ToString();
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("设置地图", exception.Message);
                }
            }
        }

        public void setMenuCheck(string sMenuName, bool bChecked)
        {
            string str = sMenuName;
            if (str != null)
            {
                if (!(str == "车辆列表"))
                {
                    if (!(str == "日志列表"))
                    {
                        if (!(str == "地物查询"))
                        {
                            if (str == "拉框查车列表")
                            {
                                this.MenuSearchCarList.Checked = false;
                            }
                            return;
                        }
                        this.MenuSearchFeature.Checked = false;
                        return;
                    }
                }
                else
                {
                    this.MenuCarList.Checked = false;
                    return;
                }
                this.MenuLogList.Checked = false;
            }
        }

        private void setMenuEnable(ToolStripMenuItem tsParentMenu)
        {
            int num = 0;
            foreach (ToolStripItem item in this.MenuCarCommand.DropDownItems)
            {
                if ((item.GetType() == typeof(ToolStripMenuItem)) && item.Enabled)
                {
                    num++;
                    break;
                }
            }
            if (num == 0)   
            {
                this.MenuCarCommand.Enabled = false;
            }
        }

        public void setMenuEnable(string menuItemTag, bool isEnable)
        {
            if (this.menuList.ContainsKey(menuItemTag.ToLower() + "1"))
            {
                this.setMenuEnable(this.menuList[menuItemTag.ToLower() + "1"], isEnable);
                if (this.topMenuList.ContainsKey(menuItemTag.ToLower() + "1"))
                {
                    this.setMenuEnable(this.topMenuList[menuItemTag.ToLower() + "1"], isEnable);
                }
            }
            if (this.recentMenu != null)
            {
                this.recentMenu.SetMenuEnable(menuItemTag, isEnable);
            }
        }

        private void setMenuEnable(ToolStripMenuItem item, bool isEnable)
        {
            item.Enabled = isEnable;
            foreach (ToolStripItem item2 in item.DropDownItems)
            {
                item2.Enabled = isEnable;
                if (item2 is ToolStripMenuItem)
                {
                    this.setMenuEnable(item2 as ToolStripMenuItem, isEnable);
                }
            }
        }

        public void setMenuViewChecked()
        {
            if (mySearchCarList.DockState == DockState.Hidden)
            {
                this.MenuSearchCarList.Checked = false;
            }
            else
            {
                this.MenuSearchCarList.Checked = true;
            }
            if (myCarList.DockState == DockState.Hidden)
            {
                this.MenuCarList.Checked = false;
            }
            else
            {
                this.MenuCarList.Checked = true;
            }
            if (myLogForms.DockState == DockState.Hidden)
            {
                this.MenuLogList.Checked = false;
            }
            else
            {
                this.MenuLogList.Checked = true;
            }
            if (mySearchFeature.DockState == DockState.Hidden)
            {
                this.MenuSearchFeature.Checked = false;
            }
            else
            {
                this.MenuSearchFeature.Checked = true;
            }
        }

        public void setMenuVisible()
        {
            if ((m_dtMenu == null) || (m_dtMenu.Rows.Count == 0))
            {
                this.setMenuVisible(this.MenuCarCommand);
                this.setMenuVisible(this.MenuContrail);
                this.MenuCarCommand.Enabled = false;
                this.MenuContrail.Enabled = false;
                this.MenuStripList.Visible = false;
                foreach (ToolStripItem item in this.MenuStripList.Items)
                {
                    if (item.Tag != null)
                    {
                        item.Visible = false;
                    }
                }
            }
            else
            {
                bool flag = false;
                bool flag2 = false;
                this.MenuCarCommand.Enabled = true;
                this.MenuContrail.Enabled = true;
                ToolStripSeparator separator = new ToolStripSeparator();
                foreach (object obj2 in this.MenuStripList.Items)
                {
                    if (obj2.GetType() == typeof(ToolStripMenuItem))
                    {
                        ToolStripMenuItem tsParentMenu = (ToolStripMenuItem)obj2;
                        if (((ToolStripMenuItem)obj2).Tag != null)
                        {
                            string str = ((ToolStripMenuItem)obj2).Tag.ToString() + "1";
                            if (m_dtMenu.Select(string.Format("MenuCode='{0}'", str)).Length > 0)
                            {
                                tsParentMenu.Visible = true;
                                tsParentMenu.Enabled = true;
                                this.setMenuVisible(tsParentMenu);
                                flag = true;
                                flag2 = false;
                            }
                            else
                            {
                                tsParentMenu.Visible = false;
                                tsParentMenu.Enabled = false;
                            }
                        }
                    }
                    else if (obj2.GetType() == typeof(ToolStripSeparator))
                    {
                        ToolStripSeparator separator2 = (ToolStripSeparator)obj2;
                        if (!flag)
                        {
                            separator2.Visible = false;
                        }
                        else
                        {
                            separator2.Visible = true;
                            flag = false;
                            flag2 = true;
                            separator = separator2;
                        }
                    }
                }
                if (flag2)
                {
                    separator.Visible = false;
                }
                this.setMenuVisible(this.MenuCarCommand);
                this.setMenuVisible(this.MenuContrail);
                this.setMenuEnable(this.MenuCarCommand);
                this.setMenuEnable(this.MenuContrail);
            }
        }

        public void setMenuVisible(ToolStripMenuItem tsParentMenu)
        {
            if ((m_dtMenu == null) || (m_dtMenu.Rows.Count == 0))
            {
                foreach (ToolStripItem item in tsParentMenu.DropDownItems)
                {
                    item.Visible = false;
                }
            }
            else
            {
                bool flag = false;
                bool flag2 = false;
                ToolStripSeparator separator = new ToolStripSeparator();
                foreach (object obj2 in tsParentMenu.DropDownItems)
                {
                    if (obj2.GetType() == typeof(ToolStripMenuItem))
                    {
                        ToolStripMenuItem item2 = (ToolStripMenuItem)obj2;
                        if (item2.Tag != null)
                        {
                            string str = item2.Tag.ToString() + "1";
                            DataRow[] rowArray = m_dtMenu.Select(string.Format("MenuCode='{0}'", str));
                            if ((m_dtMenu != null) && (rowArray.Length > 0))
                            {
                                item2.Text = rowArray[0]["MenuName"].ToString();
                                item2.Visible = true;
                                item2.Enabled = true;
                                item2.OwnerItem.Visible = true;
                                this.setMenuVisible(item2);
                                flag = true;
                                flag2 = false;
                            }
                            else
                            {
                                item2.Visible = false;
                                item2.Enabled = false;
                            }
                        }
                        else if (item2.Name == this.MenuSetCarParam.Name)
                        {
                            item2.Visible = false;
                            this.setMenuVisible(item2);
                        }
                    }
                    else if (obj2.GetType() == typeof(ToolStripSeparator))
                    {
                        ToolStripSeparator separator2 = (ToolStripSeparator)obj2;
                        if (!flag)
                        {
                            separator2.Visible = false;
                        }
                        else
                        {
                            separator2.Visible = true;
                            flag = false;
                            flag2 = true;
                            separator = separator2;
                        }
                    }
                }
                if (flag2)
                {
                    separator.Visible = false;
                }
            }
        }

        public void setStateConn()
        {
            if (Variable.bLogin)
            {
                this.slConnection.Text = "已连接";
                this.lblConnTime.Text = "上线时间：";
                this.slConnectTime.Text = DateTime.Now.ToString("yy-MM-dd HH:mm:ss");
                this.slServerIp.Text = Variable.sServerIp;
                this.slUser.Text = Variable.sUserName;
            }
            else if ("已连接".Equals(this.slConnection.Text))
            {
                this.slConnection.Text = "断开连接";
                this.lblConnTime.Text = "断线时间：";
                this.slConnectTime.Text = DateTime.Now.ToString("yy-MM-dd HH:mm:ss");
            }
        }

        private void setStateCustomerService()
        {
            if (!string.IsNullOrEmpty(Variable.sCustomerServiceInfo))
            {
                this.tslTel.Text = Variable.sCustomerServiceInfo;
            }
        }

        public void setStateLocation(string sLocation)
        {
            this.slLocation.Text = sLocation;
        }

        public void setToolEnable(bool bEnable)
        {
            this.tsbArrowhead.Enabled = bEnable;
            this.tsbMove.Enabled = bEnable;
            this.tsbZoomUp.Enabled = bEnable;
            this.tsbZoomDown.Enabled = bEnable;
            this.tsbCenter.Enabled = bEnable;
            this.tsbDistance.Enabled = this.tsbCalculate.Enabled = this.tsbPathAnalyse.Enabled = bEnable;
            this.tsbShowAll.Enabled = bEnable;
            this.tsbAddPoint.Enabled = bEnable;
            this.tsbDelPoint.Enabled = bEnable;
            this.tsbSearchCar.Enabled = bEnable;
            this.tsbCallCar.Enabled = bEnable;
            this.tsbSearchDateCar.Enabled = bEnable;
            this.tsbPrint.Enabled = this.tsbMapSave.Enabled = bEnable;
            this.MenuMapHandle.Enabled = bEnable;
            this.tsbClickZoomUp.Enabled = bEnable;
            this.tsbClickZoomDown.Enabled = bEnable;
        }

        public void setToolState()
        {
            if (Variable.sToolBarItemState.Trim().Length > 0)
            {
                foreach (string str in Variable.sToolBarItemState.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] strArray2 = str.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray2.Length == 2)
                    {
                        ToolStripItem[] itemArray = this.tsMenu.Items.Find(strArray2[0], true);
                        if ((itemArray != null) && (itemArray.Length > 0))
                        {
                            if (strArray2[1].Equals("0"))
                            {
                                itemArray[0].Visible = false;
                            }
                            else if (strArray2[1].Equals("1"))
                            {
                                itemArray[0].Visible = true;
                            }
                            else if (strArray2[1].Equals("2"))
                            {
                                itemArray[0].Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        public static void setUpdateEnabled(bool bEnabled)
        {
            if (m_tGetUpDataTimer.Enabled != bEnabled)
            {
                m_tGetUpDataTimer.Enabled = bEnabled;
            }
        }

        private void SmallAreaAddCarList(DataRow dr)
        {
            string iOrderId = dr["OrderId"].ToString();
            string sCarNum = dr["CarNum"].ToString();
            string sCarId = dr["CarId"].ToString();
            string sOrderResult = dr["OrderResult"].ToString();
            string sOrderName = dr["OrderName"].ToString();
            string sOrderType = dr["OrderType"].ToString();
            myMap.mySmallArea.AddCarList(iOrderId, sCarNum, sCarId, sOrderResult, sOrderName, sOrderType);
        }

        public static void startGetUpData()
        {
            m_tGetUpDataTimer.Enabled = true;
        }

        private void StressWatchQuery()
        {
            if ((myImportReport == null) || !myImportReport.IsHandleCreated)
            {
                itmCarReport report = new itmCarReport(CmdParam.OrderCode.设置重点监控)
                {
                    Text = "设置重点监控"
                };
                if (report.ShowDialog() == DialogResult.OK)
                {
                    myImportReport = new itmImportReport();
                    myImportReport.setImportCarLst(report.sCarSimNum, report.sCarNum);
                    myImportReport.Show(this);
                }
            }
            else
            {
                myImportReport.Activate();
                myImportReport.WindowState = FormWindowState.Normal;
            }
        }

        private void test()
        {
            CarFormEx ex = new CarFormEx(CmdParam.OrderCode.报警参数设置)
            {
                Text = "test",
                Width = 400,
                Height = 240
            };
            ex.CarParam = new testcmd();
            ex.ShowDialog();
        }

        private void tsbCalculate_Click(object sender, EventArgs e)
        {
            if (this._量算 == null)
            {
                this.addCalculation();
            }
            ToolStripButton button = sender as ToolStripButton;
            this._量算.ShowDropDown(base.PointToScreen(new System.Drawing.Point((button.Bounds.Location.X - base.Location.X) - 5, ((button.Bounds.Y + button.Height) - base.Location.Y) - 2)));
        }

        private void tsbClickZoomDown_Click(object sender, EventArgs e)
        {
            myMap.setClickZoomDownTool();
        }

        private void tsbClickZoomUp_Click(object sender, EventArgs e)
        {
            myMap.setClickZoomUpTool();
        }

        private void tsbGpsAdmin_MouseEnter(object sender, EventArgs e)
        {
            if (this.currentCursou == null)
            {
                this.currentCursou = this.Cursor;
            }
            this.Cursor = Cursors.Hand;
        }

        private void tsbGpsAdmin_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = this.currentCursou;
            this.currentCursou = null;
        }

        private void tsbImageList_Click(object sender, EventArgs e)
        {
            if (myCarList.tvList == null)
            {
                MessageBox.Show("请先选中要显示的车辆！");
            }
            else
            {
                bool flag = false;
                foreach (ThreeStateTreeNode node in myCarList.tvList.Nodes)
                {
                    if (node.CheckState != WinFormsUI.Controls.TriState.Unchecked)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    MessageBox.Show("请先勾选要显示的车辆！");
                }
                else if ((this.myCarImageList == null) || !this.myCarImageList.IsHandleCreated)
                {
                    this.myCarImageList = new CarImageList();
                    this.myCarImageList.Show(this);
                }
            }
        }

        private void tsbMapSave_Click(object sender, EventArgs e)
        {
            PrintOption option = new PrintOption(myMap);
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "图片(*.bmp;*.png;*.gif;*.jpg)|*.bmp;*.png;*.gif;*.jpg"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                option.PrintImage.Save(dialog.FileName);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (this._mapPrint == null)
            {
                this._mapPrint = new PrintOption(myMap);
            }
            else
            {
                this._mapPrint.RefleshPrintImage(myMap, 0, 0);
            }
            this._mapPrint.PageSetup();
            this._mapPrint.PrintPreview();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            myMap.initMap();
            myMap.showAllFlagMap();
        }

        private void tsbSearchCar_Click(object sender, EventArgs e)
        {
            myMap.setSearchCar();
            mySearchCarList.Show();
        }

        private void tsbSearchDateCar_Click(object sender, EventArgs e)
        {
            if ((myQueryCarInfo == null) || !myQueryCarInfo.IsHandleCreated)
            {
                myQueryCarInfo = new QueryCarInfo();
                myQueryCarInfo.Show(this);
            }
        }

        private void tsbTextList_Click(object sender, EventArgs e)
        {
            if (myCarList.tvList == null)
            {
                MessageBox.Show("请先选中要显示的车辆！");
            }
            else
            {
                bool flag = false;
                foreach (ThreeStateTreeNode node in myCarList.tvList.Nodes)
                {
                    if (node.CheckState != WinFormsUI.Controls.TriState.Unchecked)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    MessageBox.Show("请先勾选要显示的车辆！");
                }
                else if ((this.myCarTextList == null) || !this.myCarTextList.IsHandleCreated)
                {
                    this.myCarTextList = new CarTextList();
                    this.myCarTextList.Show();
                }
            }
        }

        private void unLoadPlugin()
        {
            try
            {
                foreach (IPlugin plugin in this.arrPlugins)
                {
                    try
                    {
                        plugin.UnLoad();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private bool UpdateClient(Response res)
        {
            try
            {
                string sErrMsg = this.getCurrentVersion();
                if (res.ResultCode != 0L)
                {
                    Record.execFileRecord("更新程序", "当前程序已是最新版");
                    return false;
                }
                string[] strArray = res.SvcContext.Split(new char[] { '|' });
                if (string.IsNullOrEmpty(strArray[0]))
                {
                    Record.execFileRecord("更新程序", "升级路径为空");
                    return false;
                }
                Record.execFileRecord("检测到更新程序,当前版本号", sErrMsg);
                if (MessageBoxEx.Show("检测到新的程序，是否更新？", "程序更新提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Record.execFileRecord("下载更新程序", "开始");
                    UpdateClient client = new UpdateClient(strArray[0]);
                    if (client.ShowDialog() == DialogResult.OK)
                    {
                        Record.execFileRecord("下载更新程序", "结束");
                        string sPath = client.sFolder + client.sFileNmae;
                        if (this.DoUpdateClientFile(sPath))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    Record.execFileRecord("更新程序", "选择不升级");
                    if ((strArray.Length < 2) || !"true".Equals(strArray[1]))
                    {
                        return false;
                    }
                    if (MessageBox.Show("检测到重要更新，不更新可能影响程序的正常运行!", "", MessageBoxButtons.OK, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return true;
                    }
                    Record.execFileRecord("下载更新程序", "开始");
                    UpdateClient client2 = new UpdateClient(strArray[0]);
                    if (client2.ShowDialog() == DialogResult.OK)
                    {
                        Record.execFileRecord("下载更新程序", "结束");
                        string str4 = client2.sFolder + client2.sFileNmae;
                        if (this.DoUpdateClientFile(str4))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("更新程序 失败", exception.ToString());
            }
            return false;
        }

        private void worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = myCarList.setCarList();
            }
            catch (Exception exception)
            {
                e.Result = null;
                Record.execFileRecord("worker2_RunWorkerCompleted", exception.StackTrace);
            }
        }

        private void worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myCarList.Enabled = true;
            if (e.Result == null)
            {
                if (m_dtMenu != null)
                {
                    m_dtMenu.Rows.Clear();
                }
                this.setMenuVisible();
                WaitForm.Hide();
                myLogForms.myNewLog.AddUserMessageToNewLog("下载车辆列表失败！");
                Record.execFileRecord("worker2_RunWorkerCompleted", "下载车辆列表失败！" + e.Error);
            }
            else
            {
                try
                {
                    DataTable result = e.Result as DataTable;
                    myCarList.CreateCarList(result);
                    myCarList.setAlarmCarList();
                    myCarList.setAreaText();
                    myCarList.AddAlerm(null);
                    WaitForm.Hide();
                    myCarList.AutoCheckAllCar();
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("worker2_RunWorkerCompleted", exception.StackTrace);
                    WaitForm.Hide();
                }
            }
        }

        private void workerGrant_DoWork(object sender, DoWorkEventArgs e)
        {
            m_dtMenu = RemotingClient.LoginSys_GetAllMenu();
            foreach (DataRow dr in m_dtMenu.Rows)
            {
                string str = dr["MenuName"].ToString();
            }
        }

        private void workerGrant_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (m_dtMenu == null)
            {
                myLogForms.myNewLog.AddUserMessageToNewLog("获取菜单权限信息错误！");
                Record.execFileRecord("获取菜单权限信息错误");
            }
            this.setMenuVisible();
            this.initMenu();
        }

        public RecentUseMenu RecentUseMenuList
        {
            get
            {
                return this.recentMenu;
            }
        }

        public string SelectMapValue
        {
            get
            {
                try
                {
                    if (this.cmbSelectMap.ComboBox.SelectedIndex >= 0)
                    {
                        return this.cmbSelectMap.ComboBox.SelectedValue.ToString();
                    }
                }
                catch
                {
                }
                return "";
            }
            set
            {
                try
                {
                    this.cmbSelectMap.ComboBox.SelectedValue = value;
                    if (this.cmbSelectMap.ComboBox.SelectedValue == null)
                    {
                        this.cmbSelectMap.ComboBox.SelectedIndex = 0;
                        this.cmbSelectMap_SelectedIndexChanged(new object(), new EventArgs());
                    }
                }
                catch
                {
                    this.cmbSelectMap.ComboBox.SelectedIndex = 0;
                }
            }
        }

        private delegate void dCarLog(LogForm.LogFormType oType, DataTable dtData);

        private delegate void dCloseForm(object sender, EventArgs e);

        private delegate void DelegateUpdateClient();

        private delegate void dexecCarLine(string sLine);

        /// <summary>
        /// 偏移路线显示控制菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPathTypeDisplayControl_Click(object sender, EventArgs e)
        {

            new ShowPathForm(myMap.wbMap, 1).ShowDialog();
        }

        /// <summary>
        /// 区域显示控制菜单被点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRegionTypeDisplayControl_Click(object sender, EventArgs e)
        {
            new ShowPathForm(myMap.wbMap, 2).ShowDialog();
        }
    
    }
}
