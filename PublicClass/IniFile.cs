namespace PublicClass
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class IniFile
    {
        private static string sIniFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "Config.ini");

        public static long GetIniFileString(string sSection, string sKey, ref string refVal)
        {
            StringBuilder builder = new StringBuilder(2048, 2048);
            long num = GetPrivateProfileString(sSection, sKey, refVal, builder, 1024, sIniFile);
            refVal = builder.ToString();
            return num;
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder refVal, int size, string filePath);
        public static long GetProfileString(string sSection, string sKey, ref string refVal, string sFileName)
        {
            StringBuilder builder = new StringBuilder();
            long num = GetPrivateProfileString(sSection, sKey, refVal, builder, 0xff, sFileName);
            refVal = builder.ToString();
            return num;
        }

        public static bool ReadIniFile()
        {
            try
            {
                GetIniFileString("User", "UserId", ref Variable.sUserId);
                GetIniFileString("User", "AutoCheckAllCar", ref Variable.sAutoCheckAllCar);
                GetIniFileString("User", "Title", ref Variable.sLoginTitle);
                GetIniFileString("User", "CheckAdc", ref Variable.sCheckAdc);
                GetIniFileString("User", "AdcNo", ref Variable.sAdcNo);
                GetIniFileString("Server", "ServerIp", ref Variable.sServerIp);
                GetIniFileString("Server", "Port", ref Variable.sPort);
                GetIniFileString("Server", "UseHttpProxy", ref Variable.sUseHttpProxy);
                GetIniFileString("Server", "HttpProxyIp", ref Variable.sHttpProxyIp);
                GetIniFileString("Server", "HttpProxyPort", ref Variable.sHttpProxyPort);
                GetIniFileString("Server", "GpsIp", ref Variable.sGpsIp);
                GetIniFileString("Server", "GpsPort", ref Variable.sGpsPort);
                GetIniFileString("Map", "MapIp", ref Variable.sMapIp);
                GetIniFileString("Map", "MapPort", ref Variable.sMapPort);
                GetIniFileString("Map", "MapSign", ref Variable.sMapSign);
                GetIniFileString("Map", "SelectedMap", ref Variable.sSelectedMap);
                GetIniFileString("Terminal", "GetPhotoMax", ref Variable.sGetPhotoMax);
                GetIniFileString("Terminal", "SavePicDays", ref Variable.sSavePicDays);
                GetIniFileString("Terminal", "SkinDataIndex", ref Variable.sSkinDataIndex);
                GetIniFileString("Terminal", "RecsPerPage", ref Variable.sRecsPerPage);
                GetIniFileString("Terminal", "GetUpDateTime", ref Variable.sGetUpDateTime);
                GetIniFileString("Terminal", "QueryPointGetInt", ref Variable.sQueryPointGetInt);
                GetIniFileString("Terminal", "QueryPointTimeDiff", ref Variable.sQueryPointTimeDiff);
                GetIniFileString("MenuSelect", "MaxSendCount", ref Variable.sMaxSendCount);
                GetIniFileString("MenuSelect", "ImportCarMax", ref Variable.sImportCarMax);
                GetIniFileString("TreeNode", "GetNodeTipShowType", ref Variable.sGetNodeTipShowType);
                GetIniFileString("TreeNode", "GetNodeDetailShowType", ref Variable.sGetNodeDetailShowType);
                GetIniFileString("Other", "AlarmSoundStatus", ref Variable.sAlarmSoundStatus);
                GetIniFileString("Other", "CarListTextColunmsVisibleType", ref Variable.sCarListTextColunmsVisibleType);
                GetIniFileString("Other", "CompressDownCarInfo", ref Variable.sCompressDownCarInfo);
                GetIniFileString("Other", "ShippingEnable", ref Variable.sShippingEnable);
                GetIniFileString("Other", "ShowTogether", ref Variable.sShowTogether);
                GetIniFileString("Other", "AllowMultiShoot", ref Variable.sAllowMultiShoot);
                GetIniFileString("Other", "AllowRefresh", ref Variable.sAllowRefresh);
                GetIniFileString("Other", "AllowLCSType", ref Variable.sAllowLCSType);
                GetIniFileString("Other", "AlarmPopupWindow", ref Variable.sAlarmPopupWindow);
                GetIniFileString("Other", "CustomAlarmSound", ref Variable.sCustomAlarmSound);
                GetIniFileString("Other", "AdminSystemState", ref Variable.sAdminSystemState);
                GetIniFileString("Other", "LogFilterAlarmType", ref Variable.sLogFilterAlarmType);
                GetIniFileString("Other", "MapCarLegendShowAreaName", ref Variable.sMapCarLegendShowAreaName);
                GetIniFileString("Other", "CarServerTimeRemind", ref Variable.sCarServerTimeRemind);
                GetIniFileString("Other", "LogListAreaVisible", ref Variable.sLogListAreaVisible);
                GetIniFileString("Other", "ProjectID", ref Variable.sProjectID);
                GetIniFileString("Other", "WebMenuList", ref Variable.sWebMenuList);
                GetIniFileString("Other", "ShowManagerSystem", ref Variable.sShowManagerSystem);
                GetIniFileString("Other", "ShowCarPlayTrackTime", ref Variable.sGetNodeTrackShowType);
                GetIniFileString("Other", "ShowUnCheckedCarInfo", ref Variable.sShowUnCheckedCarInfo);
                GetIniFileString("Other", "ShowUnCheckedCarInfoDetail", ref Variable.sShowUnCheckedCarInfoDetail);
                GetIniFileString("Other", "AutoCancelAlarm", ref Variable.sAutoCancelAlarm);
                GetIniFileString("Other", "LCSPosInterval", ref Variable.sLCSPosInterval);
                GetIniFileString("Other", "CustomMenuTitle", ref Variable.sCustomMenuTitle);
                GetIniFileString("Other", "CustomSoftwarePath", ref Variable.sCustomSoftwarePath);
                GetIniFileString("Other", "sLonLatDis", ref Variable.sLonLatDis);
                GetIniFileString("Other", "MaxPicMonitorTime", ref Variable.sNumMaxPicMonitorTime);
                GetIniFileString("Other", "UserLevel", ref Variable.sLevelInfo);
                GetIniFileString("ToolBar", "ItemState", ref Variable.sToolBarItemState);
                GetIniFileString("Other", "JGShowCarNum", ref Variable.sJGShowCar);//建工显示车牌和或者自编号     
                return true;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("读取配置文件", exception.ToString());
                return false;
            }
        }

        public static bool WriteIniFile()
        {
            try
            {
                WriteIniFileString("User", "UserId", Variable.sUserId);
                WriteIniFileString("User", "AdcNo", Variable.sAdcNo);
                WriteIniFileString("Server", "ServerIp", Variable.sServerIp);
                WriteIniFileString("Server", "Port", Variable.sPort);
                WriteIniFileString("Server", "UseHttpProxy", Variable.sUseHttpProxy);
                WriteIniFileString("Server", "HttpProxyIp", Variable.sHttpProxyIp);
                WriteIniFileString("Server", "HttpProxyPort", Variable.sHttpProxyPort);
                WriteIniFileString("Server", "GpsIp", Variable.sGpsIp);
                WriteIniFileString("Server", "GpsPort", Variable.sGpsPort);
                WriteIniFileString("Map", "MapIp", Variable.sMapIp);
                WriteIniFileString("Map", "MapPort", Variable.sMapPort);
                WriteIniFileString("Map", "MapSign", Variable.sMapSign);
                WriteIniFileString("Map", "SelectedMap", Variable.sSelectedMap);
                WriteIniFileString("Terminal", "GetPhotoMax", Variable.sGetPhotoMax);
                WriteIniFileString("Terminal", "SavePicDays", Variable.sSavePicDays);
                WriteIniFileString("Terminal", "SaveLogDays", Variable.sSaveLogDays);
                WriteIniFileString("Terminal", "SkinDataIndex", Variable.sSkinDataIndex);
                WriteIniFileString("Terminal", "RecsPerPage", Variable.sRecsPerPage);
                WriteIniFileString("Terminal", "GetUpDateTime", Variable.sGetUpDateTime);
                WriteIniFileString("Terminal", "QueryPointTimeDiff", Variable.sQueryPointTimeDiff);
                WriteIniFileString("Terminal", "QueryPointGetInt", Variable.sQueryPointGetInt);
                WriteIniFileString("MenuSelect", "MaxSendCount", Variable.sMaxSendCount);
                WriteIniFileString("MenuSelect", "ImportCarMax", Variable.sImportCarMax);
                WriteIniFileString("TreeNode", "GetNodeTipShowType", Variable.sGetNodeTipShowType);
                WriteIniFileString("TreeNode", "GetNodeDetailShowType", Variable.sGetNodeDetailShowType);
                WriteIniFileString("Other", "AlarmSoundStatus", Variable.sAlarmSoundStatus);
                WriteIniFileString("Other", "CarListTextColunmsVisibleType", Variable.sCarListTextColunmsVisibleType);
                WriteIniFileString("Other", "CompressDownCarInfo", Variable.sCompressDownCarInfo);
                WriteIniFileString("Other", "AlarmPopupWindow", Variable.sAlarmPopupWindow);
                WriteIniFileString("Other", "CustomAlarmSound", Variable.sCustomAlarmSound);
                WriteIniFileString("Other", "LogFilterAlarmType", Variable.sLogFilterAlarmType);
                WriteIniFileString("Other", "MapCarLegendShowAreaName", Variable.sMapCarLegendShowAreaName);
                WriteIniFileString("Other", "CarServerTimeRemind", Variable.sCarServerTimeRemind);
                WriteIniFileString("Other", "LogListAreaVisible", Variable.sLogListAreaVisible);
                WriteIniFileString("Other", "ShowUnCheckedCarInfo", Variable.sShowUnCheckedCarInfo);
                WriteIniFileString("Other", "AutoCancelAlarm", Variable.sAutoCancelAlarm);
                WriteIniFileString("Other", "ShowManagerSystem", Variable.sShowManagerSystem);
                WriteIniFileString("Other", "ShowCarPlayTrackTime", Variable.sGetNodeTrackShowType);
                WriteIniFileString("Other", "sLonLatDis", Variable.sLonLatDis);
                WriteIniFileString("Other", "MaxPicMonitorTime", string.IsNullOrEmpty(Variable.sNumMaxPicMonitorTime) ? "65535" : Variable.sNumMaxPicMonitorTime);
                WriteIniFileString("Other", "UserLevel", Variable.sLevelInfo);
                WriteIniFileString("Other", "JGShowCarNum", Variable.sJGShowCar);
                return true;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("读取配置文件", exception.ToString());
                return false;
            }
        }

        public static long WriteIniFileString(string sSection, string sKey, string sVal)
        {
            if (string.IsNullOrEmpty(sVal))
            {
                return -1L;
            }
            return WritePrivateProfileString(sSection, sKey, sVal, sIniFile);
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        public static long WriteProfileString(string sSection, string sKey, string sVal, string sFileName)
        {
            return WritePrivateProfileString(sSection, sKey, sVal, sFileName);
        }
    }
}

