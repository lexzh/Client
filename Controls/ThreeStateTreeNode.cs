using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinFormsUI.Controls
{
    public class ThreeStateTreeNode : TreeNode
    {
        private string _address = "正在解析位置信息，请稍候...";
        private string _areaName;
        private bool _bshowNotice = true;
        private bool _isFill;
        private string _Latitude;
        private string _Longitude;
        private string _PlateColor;
        private string _sAllDiff;
        private string _sAltitude;
        private string _sDirect;
        private string _sLastAlarmSetTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
        private string _sLastAlarmStopTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
        private string _sSpeed;
        private int iCarCnt;
        private int iOnlineCnt;
        public static string sAlarm = "Car_r";
        private string sCarStatus = sOffLine;
        public static string sFill = "Car_f";
        public static string sOffLine = "Car_g";
        public static string sOnLine = "Car_b";
        public static string sOffLine2 = "Car_green";
        private string sSimNum;
        private string sText;
        private TriState triState;
        private Dictionary<string, string> _DynamicAttr = new Dictionary<string, string>();

        public Dictionary<string, string> DynamicAttr
        {
            get
            {
                return this._DynamicAttr;
            }
            set
            {
                this._DynamicAttr = value;
            }
        }

        public ThreeStateTreeNode()
        {
            this.sSimNum = "";
            this.sCarStatus = sOffLine;
            this.sText = "";
            this._Longitude = "";
            this._Latitude = "";
            this._areaName = "";
            this._sDirect = "";
            this._sSpeed = "";
            this._address = "正在解析位置信息，请稍候...";
            this._sAllDiff = "";
            this._sLastAlarmStopTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._sLastAlarmSetTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._bshowNotice = true;
            this._sAltitude = "";
        }

        public ThreeStateTreeNode(string text) : base(text)
        {
            this.sSimNum = "";
            this.sCarStatus = sOffLine;
            this.sText = "";
            this._Longitude = "";
            this._Latitude = "";
            this._areaName = "";
            this._sDirect = "";
            this._sSpeed = "";
            this._address = "正在解析位置信息，请稍候...";
            this._sAllDiff = "";
            this._sLastAlarmStopTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._sLastAlarmSetTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._bshowNotice = true;
            this._sAltitude = "";
            this.sText = text;
        }

        public ThreeStateTreeNode(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
        {
            this.sSimNum = "";
            this.sCarStatus = sOffLine;
            this.sText = "";
            this._Longitude = "";
            this._Latitude = "";
            this._areaName = "";
            this._sDirect = "";
            this._sSpeed = "";
            this._address = "正在解析位置信息，请稍候...";
            this._sAllDiff = "";
            this._sLastAlarmStopTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._sLastAlarmSetTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._bshowNotice = true;
            this._sAltitude = "";
        }

        public ThreeStateTreeNode(string text, TreeNode[] children) : base(text, children)
        {
            this.sSimNum = "";
            this.sCarStatus = sOffLine;
            this.sText = "";
            this._Longitude = "";
            this._Latitude = "";
            this._areaName = "";
            this._sDirect = "";
            this._sSpeed = "";
            this._address = "正在解析位置信息，请稍候...";
            this._sAllDiff = "";
            this._sLastAlarmStopTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._sLastAlarmSetTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._bshowNotice = true;
            this._sAltitude = "";
            this.sText = text;
        }

        public ThreeStateTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex)
        {
            this.sSimNum = "";
            this.sCarStatus = sOffLine;
            this.sText = "";
            this._Longitude = "";
            this._Latitude = "";
            this._areaName = "";
            this._sDirect = "";
            this._sSpeed = "";
            this._address = "正在解析位置信息，请稍候...";
            this._sAllDiff = "";
            this._sLastAlarmStopTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._sLastAlarmSetTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._bshowNotice = true;
            this._sAltitude = "";
            this.sText = text;
        }

        public ThreeStateTreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children) : base(text, imageIndex, selectedImageIndex, children)
        {
            this.sSimNum = "";
            this.sCarStatus = sOffLine;
            this.sText = "";
            this._Longitude = "";
            this._Latitude = "";
            this._areaName = "";
            this._sDirect = "";
            this._sSpeed = "";
            this._address = "正在解析位置信息，请稍候...";
            this._sAllDiff = "";
            this._sLastAlarmStopTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._sLastAlarmSetTime = DateTime.MinValue.ToString("yyyy-MM-hh HH:mm:ss");
            this._bshowNotice = true;
            this._sAltitude = "";
            this.sText = text;
        }

        private void InternalSetTriState(TriState state)
        {
            ThreeStateTreeView treeView = base.TreeView as ThreeStateTreeView;
            if (treeView != null)
            {
                WinFormsUI.Controls.NativeMethods.TVITEM lParam = new WinFormsUI.Controls.NativeMethods.TVITEM {
                    mask = 24,
                    hItem = base.Handle,
                    stateMask = 61440
                };
                switch (state)
                {
                    case TriState.Unchecked:
                        lParam.state |= 4096;
                        break;

                    case TriState.Checked:
                        lParam.state |= 8192;
                        break;

                    case TriState.Indeterminate:
                        lParam.state |= 12288;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("state");
                }
                WinFormsUI.Controls.NativeMethods.SendMessage(new HandleRef(base.TreeView, base.TreeView.Handle), 4365, 0, ref lParam);
                treeView.TreeViewAfterTriStateUpdate(this);
            }
        }

        private void setCarImg()
        {
            try
            {
                if (((base.Level <= 0) || base.Parent.IsExpanded) && (base.ImageKey != this.sCarStatus))
                {
                    base.ImageKey = this.sCarStatus;
                    base.SelectedImageKey = this.sCarStatus;
                }
            }
            catch
            {
            }
        }

        private void setCarOnline(string sStatus)
        {
            if (sStatus != this.sCarStatus)
            {
                if ((sStatus != sOffLine) && (this.sCarStatus != sOffLine))
                {
                    this.sCarStatus = sStatus;
                    this.setCarImg();
                }
                else
                {
                    this.sCarStatus = sStatus;
                    this.setCarImg();
                    int num = 0;
                    if (this.sCarStatus == sOffLine)
                    {
                        this.iOnlineCnt = 0;
                        num = -1;
                    }
                    else
                    {
                        this.iOnlineCnt = 1;
                        num = 1;
                    }
                    ThreeStateTreeNode parent = this;
                    while (parent.Level >= 1)
                    {
                        parent = parent.Parent as ThreeStateTreeNode;
                        parent.iOnlineCnt += num;
                    }
                    (base.TreeView as ThreeStateTreeView).AddAreaNodeHashTable((ThreeStateTreeNode) base.Parent);
                }
            }
        }

        public void setNodeShow()
        {
            if ((base.Level <= 0) || base.Parent.IsExpanded)
            {
                if (base.Tag.ToString().Equals("CAR"))
                {
                    if (this.IsAlarm && (this.sCarStatus == sOnLine))
                    {
                        this.sCarStatus = sAlarm;
                    }
                    if (base.ImageKey != this.sCarStatus)
                    {
                        base.ImageKey = this.sCarStatus;
                        base.SelectedImageKey = this.sCarStatus;
                    }
                }
                else if (this.ShowOnlineCnt != this.iOnlineCnt)
                {
                    this.sText = string.Format("{0}({1}/{2})", this.AreaName, this.iOnlineCnt, this.iCarCnt);
                    this.ShowOnlineCnt = this.iOnlineCnt;
                    (base.TreeView as ThreeStateTreeView).DelAreaNodeHashTable(this);
                    this.SetNodeText(this.sText);
                }
            }
        }

        public void SetNodeText(string sNodeText)
        {
            ThreeStateTreeView treeView = base.TreeView as ThreeStateTreeView;
            if (treeView != null)
            {
                WinFormsUI.Controls.NativeMethods.TVITEM lParam = new WinFormsUI.Controls.NativeMethods.TVITEM {
                    mask = 17,
                    hItem = base.Handle,
                    pszText = Marshal.StringToHGlobalAnsi(sNodeText)
                };
                WinFormsUI.Controls.NativeMethods.SendMessage(new HandleRef(base.TreeView, base.TreeView.Handle), 4365, 0, ref lParam);
                treeView.TreeViewAfterTriStateUpdate(this);
            }
        }

        private void SetTriState(TriState state)
        {
            this.triState = state;
            if (((base.TreeView != null) && base.TreeView.IsHandleCreated) && (base.Handle != IntPtr.Zero))
            {
                this.InternalSetTriState(state);
            }
        }

        public string AccOn { get; set; }

        public string Address
        {
            get
            {
                if (string.IsNullOrEmpty(this.Longitude))
                {
                    return "";
                }
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }

        public string AlarmType { get; set; }

        public string ALLDiff
        {
            get
            {
                if (string.IsNullOrEmpty(this._sAllDiff))
                {
                    this._sAllDiff = "0.00";
                }
                return string.Format("{0}公里", this._sAllDiff);
            }
            set
            {
                if (value.Length == 0)
                {
                    value = "0.00";
                }
                else if (value.Length <= 3)
                {
                    value = "0." + value;
                }
                else
                {
                    value = value.Insert(value.Length - 3, ".");
                    value = value.Substring(0, value.Length - 1);
                }
                this._sAllDiff = value;
            }
        }

        public string Altitude
        {
            get
            {
                if (string.IsNullOrEmpty(this._sAltitude))
                {
                    this._sAltitude = "0";
                }
                return string.Format("{0}米", this._sAltitude);
            }
            set
            {
                if (value.Length == 0)
                {
                    value = "0";
                }
                else
                {
                    this._sAltitude = value;
                }
            }
        }

        public string AreaName { get; set; }

        public string AreaPath { get; set; }

        public string AreaType { get; set; }

        public bool bShowNoticeForm
        {
            get
            {
                return this._bshowNotice;
            }
            set
            {
                this._bshowNotice = value;
            }
        }

        public string CarAreaName
        {
            get
            {
                if (string.IsNullOrEmpty(this._areaName))
                {
                    try
                    {
                        if (base.Parent != null)
                        {
                            this._areaName = (base.Parent as ThreeStateTreeNode).AreaName;
                        }
                    }
                    catch
                    {
                    }
                }
                return this._areaName;
            }
            set
            {
                this._areaName = value;
            }
        }

        public int CarCnt
        {
            get
            {
                return this.iCarCnt;
            }
            set
            {
                this.iCarCnt = value;
            }
        }

        public string CarColor { get; set; }

        public string CarEmail { get; set; }

        public string CarId
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        public string CarNum
        {
            get
            {
                return this.sText;
            }
            set
            {
                this.sText = value;
            }
        }

        public string CarPID { get; set; }

        public string CarPName { get; set; }

        public string CarPTel { get; set; }

        public string CarStatus
        {
            get
            {
                return this.sCarStatus;
            }
            set
            {
                this.setCarOnline(value);
            }
        }

        public string CarStatusValue { get; set; }

        public string CarType { get; set; }

        public TriState CheckState
        {
            get
            {
                return this.triState;
            }
            set
            {
                if (this.triState != value)
                {
                    this.SetTriState(value);
                    this.triState = value;
                }
            }
        }

        public string Company { get; set; }

        public string Direction
        {
            get
            {
                if (string.IsNullOrEmpty(this._sDirect))
                {
                    return this._sDirect;
                }
                return string.Format("正北{0}度", this._sDirect);
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && (value.IndexOf('.') > 0))
                {
                    value = value.Substring(0, value.IndexOf('.'));
                }
                this._sDirect = value;
            }
        }

        public string DriverCode { get; set; }

        public string DriverName { get; set; }

        public string EbillText { get; set; }

        public string EndTime { get; set; }

        public string FirstName { get; set; }

        public string FirstTel { get; set; }

        public bool GetIsFill
        {
            get
            {
                return this._isFill;
            }
        }

        public string GpsTime { get; set; }

        public string GpsValid { get; set; }

        public bool IsAlarm { get; set; }

        public string LastAlarmSetTime
        {
            get
            {
                return this._sLastAlarmSetTime;
            }
            set
            {
                this._sLastAlarmSetTime = value;
            }
        }

        public string LastAlarmStopTime
        {
            get
            {
                return this._sLastAlarmStopTime;
            }
            set
            {
                this._sLastAlarmStopTime = value;
            }
        }

        public string Latitude
        {
            get
            {
                return this._Latitude;
            }
            set
            {
                if (!this._Latitude.Equals(value))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        value = value.Substring(0, value.IndexOf('.') + 7);
                    }
                    this._Latitude = value;
                    this.PlaceChangeed = true;
                }
            }
        }

        public string Longitude
        {
            get
            {
                return this._Longitude;
            }
            set
            {
                if (!this._Longitude.Equals(value))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        value = value.Substring(0, value.IndexOf('.') + 7);
                    }
                    this._Longitude = value;
                    this.PlaceChangeed = true;
                }
            }
        }

        public int NodeIndex { get; set; }

        public string Place { get; set; }

        public bool PlaceChangeed { get; set; }

        public string PlateColor
        {
            get
            {
                return this._PlateColor;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this._PlateColor = "未知";
                }
                else
                {
                    this._PlateColor = value;
                }
            }
        }

        public string ReceTime { get; set; }

        public string SecondName { get; set; }

        public string SecondTel { get; set; }

        public string SetIsFill
        {
            set
            {
                if ((value != null) && value.ToString().Equals("1"))
                {
                    this._isFill = true;
                }
                else
                {
                    this._isFill = false;
                }
            }
        }

        public int ShowOnlineCnt { get; set; }

        public string SimNum
        {
            get
            {
                return this.sSimNum;
            }
            set
            {
                this.sSimNum = value;
            }
        }

        public string Speed
        {
            get
            {
                if (!string.IsNullOrEmpty(this._sSpeed))
                {
                    return string.Format("{0}km/h", this._sSpeed);
                }
                return "0.00km/h";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Substring(0, value.IndexOf('.') + 3);
                }
                this._sSpeed = value;
            }
        }

        public string TerminalType { get; set; }

        public string TermSerial { get; set; }

        public string TransportStatu { get; set; }

        public string WordCompany { get; set; }

        public string AddMsgTxt { get; set; }
    }
}

