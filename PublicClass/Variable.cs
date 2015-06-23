using System;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace PublicClass
{
    public static class Variable
    {
        private static string _ComputerIp = "";
        public static string sOffLineTime = "300";
        public static string sUserId = "";
        public static string sPassword = "";
        public static string sUserName = "";
        public static string sAutoCheckAllCar = "0";
        public static string sCheckAdc = "0";
        public static string sAdcNo = "";
        public static string sPhone = "";
        public static string sLoginTitle = "星辰北斗兼容智能位置服务运营平台";
        public static string sVsersionAll = "V1.2.0.0";
        public static string sLonLatDis = "0.001";
        public static string sVerfNum = "";
        public static string sVerfCode = "";
        public static string sServerIp = "127.0.0.1";
        public static string sPort = "80";
        public static string sUseHttpProxy = "0";
        public static string sHttpProxyIp = "127.0.0.1";
        public static string sHttpProxyPort = "80";
        public static string sConnectErrorMsg = "与服务器连接失败";
        public static string sCompany = "重庆北斗导航应用技术股份有限公司";
        public static string sTitle = "星辰北斗兼容智能位置服务运营平台";
        public static string sSecurityKey = "";
        public static string sCustomerServiceInfo = "";
        public static bool isValidate = false;
        public static string sGpsIp = "127.0.0.1";
        public static string sGpsPort = "80";
        public static int iModuleId = 4096;
        public static string sGetPhotoMax = "30";
        public static string sSavePicDays = "30";
        public static string sSaveLogDays = "30";
        public static string sSkinDataIndex = "0";
        public static string sRecsPerPage = "5000";
        public static string sGetUpDateTime = "2000";
        public static string sQueryPointTimeDiff = "120";
        public static string sQueryPointGetInt = "200";
        public static string sMaxSendCount = "500";
        public static string sImportCarMax = "20";
        public static int iMaxGetPlaceCnt = 100;
        public static string sMapIp = "127.0.0.1";
        public static string sMapPort = "80";
        public static bool bMapRefresh = false;
        public static string sMapSign = "";
        public static string sSelectedMap = "";
        public static string sGetNodeTipShowType = "0";
        public static string sGetNodeDetailShowType = "0";
        public static string sGetNodeTrackShowType = "0";
        public static string sAlarmSoundStatusFilePath = string.Concat(Application.StartupPath, "\\Sound\\Alarm.WAV");
        public static string sAlarmSoundStatus = "开";
        public static string sCarListTextColunmsVisibleType = "0";
        public static string sAllowLCSType = "LCS个人定位";
        public static string sAlarmPopupWindow = "0";
        public static int iMaxCnt = 3;
        public static string sCompressDownCarInfo = "1";
        public static string sLevelInfo = "0";
        public static string sShippingEnable = "0";
        public static string sShowTogether = "0";
        public static string sAllowMultiShoot = "1";
        public static string sAllowRefresh = "0";
        public static string[] sSkinFiles = new string[] { "Skin\\XPSilver.ssk", "Skin\\MacOS.ssk", "Skin\\Page.ssk", "Skin\\Msn.ssk", "Skin\\Steel.ssk", "Skin\\Glass.ssk" };
        public static string sPicFolderPath = string.Concat(Application.StartupPath, "\\Pic\\");
        public static string sLogFolderPath = string.Concat(Application.StartupPath, "\\Log\\");
        public static string sToolBarItemState = "";
        public static string sCustomAlarmSound = "";
        public static string sAdminSystemState = "0";
        public static string sLogFilterAlarmType = "";
        public static string sMapCarLegendShowAreaName = "";
        public static string sCarServerTimeRemind = "1";
        public static string sLogListAreaVisible = "0";
        public static string sProjectID = "";
        public static string sWebMenuList = "";
        public static string sShowManagerSystem = "1";
        public static int iPointNumber = 20;
        public static string sShowUnCheckedCarInfo = "0";
        public static string sShowUnCheckedCarInfoDetail = "28";
        public static string sAutoCancelAlarm = "5";
        public static string sLCSPosInterval = "15";
        public static string sCustomMenuTitle = "";
        public static string sCustomSoftwarePath = "";
        public static string sNumMaxPicMonitorTime = "";
        public static string[] sPlateType = new string[] { "大型汽车", "挂车", "小型汽车", "使馆汽车", "领馆汽车", "领馆摩托车", "港澳入出境车", "教练汽车", "警用汽车", "普通摩托车", "轻便摩托车", "使馆摩托车", "教练摩托车", "警用摩托车", "低速车", "临时行驶车", "临时入境汽车", "临时入境摩托", "拖拉机" };
        public static string sMapName = "StarGIS"; //增加地图名称，便于不同版本之间切换 huzh 2014.3.14
        public static int iWorkID = -1;
        public static bool bLogin = false;
        public static string sJGShowCar = "0";
        public static string sDBPwd;
        public static string sMenuItemTradeApp;
        public static string sNoticeLogText;
        public static string sStopAlarmTime;

        public static double dLonLatDis
        {
            get
            {
                return double.Parse(sLonLatDis);
            }
        }

        public static string MapUrl
        {
            get
            {
                return string.Format("http://{0}:{1}/{2}/MapPage.aspx", sMapIp, sMapPort, sMapName);
            }
        }

        public static string sComputerIp
        {
            get
            {
                if (string.IsNullOrEmpty(_ComputerIp))
                {
                    try
                    {
                        _ComputerIp = Dns.GetHostEntry(Environment.MachineName).AddressList[0].ToString();
                    }
                    catch (Exception exception)
                    {
                        Record.execFileRecord(exception.Message);
                    }
                }
                return _ComputerIp;
            }
        }

        public static string sVersion
        {
            get
            {
                return Application.ProductVersion;
            }
        }
    }
}

