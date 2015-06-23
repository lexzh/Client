namespace Library
{
    using Microsoft.Win32;
    using System;

    public class ReadDataFromXml
    {
        private static string sAlarmInterval;
        private static string sAppIp;
        private static string sAppointedTime;
        private static string sAppPort;
        private static string sAppPwd;
        private static string sAppUser;
        private static string sBillTime;
        private static string sBroadCastDiff;
        private static string sBroadCastMsgTime;
        private static string schkDownMsg;
        private static string sChkInterval;
        private static string schkIsSend;
        private static string schkIsSendDriverAlarm;
        private static string schkRoadSpeedAndRank;
        private static string sCommunicationUrl;
        private static string sCuffDiff;
        private static string sCurrentAddressInterval;
        private static string sDelayTime;
        private static string sDownInterval;
        private static string sDWLBSTime;
        private static string sEffectiveTime;
        private static string sExecUserId = "GpsTimerService";
        private static string sGatheredAlarmInterval;
        private static string sGetBeBackConfig;
        private static string sGetBeBackPos;
        private static string sGetCurrentPosInterval;
        private static string sGetInOutConfig;
        private static string sGetInOutPos;
        private static string sGetLBSPosDataInterval;
        private static string sIsAdminRegionAlarm;
        private static string sIsBeBackOnTime;
        private static string sIsBillPos;
        private static string sIsBroadCast;
        private static string sIsChkErr;
        private static string sIsContinuousAlarm;
        private static string sIsCuff;
        private static string sIsCurrentAddress;
        private static string sIsDWLBSPos;
        private static string sIsForbidDriveAlarm;
        private static string sIsGatheredAlarm;
        private static string sIsInOutOfRangeOnTime;
        private static string sIsJTBOnOffNotice;
        private static string sIsLBSPos;
        private static string sIsLCSPos;
        private static string sIsMsgRemind;
        private static string sIsOnlyFillCheck;
        private static string sIsPathAlarm;
        private static string sIsPathSegmentAlarm;
        private static string sIsPic;
        private static string sIsRegionAlarm;
        private static string sIsSendMsg;
        private static string sIsSendPZMsg;
        private static string sIsSeparateAndSticky;
        private static string sIsTerminalDemand;
        private static string sIsThreeLevelRoadAlarm;
        private static string sJTBOffLineTime;
        private static string sJTBOnOffInterval;
        private static string sLBSEndTime;
        private static string sLBSMuliPosType;
        private static string sLBSPosInterval;
        private static string sLBSPosMaxNum;
        private static string sLBSPosSleepTime;
        private static string sLBSStarTime;
        private static string sLBSType;
        private static string sLCSCount;
        private static string sLCSPosTime;
        private static string sLCSTime;
        private static string sLinkman;
        public static string sLinkmanMailCC;
        public static string sLinkmanMailTo;
        private static string sLogSaveDate;
        private static string sMapUrl;
        private static string snumForbidDriveInterval;
        private static string snumThreeLevelRoadInterval;
        private static string sOrderDays;
        private static string sPathAlarmInterval;
        private static string sPicTime;
        private static string sPreTime;
        private static string sPZInterval;
        private static string sPZSendMsg;
        private static string sPZType;
        private static string sRoadSpeedAndRankGisType;
        private static string sRoadSpeedAndRankInterval;
        private static string sRoadSpeedAndRankOtherGisAddress;
        private static string sSendDriverAlarmMsg;
        private static string sSendMessage;
        private static string sSendMsg;
        private static string sSeparateAndSticky;
        private static string sTerminalTypeID;
        private static string sWarnMsg1;
        private static string sWarnMsg2;
        private static string sWarnMsg3;

        public static void UpdateParameter()
        {
            sCommunicationUrl = FileHelper.ReadParamFromXml("serverIP");
            sIsPic = FileHelper.ReadParamFromXml("IsPic");
            sPicTime = FileHelper.ReadParamFromXml("PicTimeDiff");
            sIsCuff = FileHelper.ReadParamFromXml("IsCuff");
            sCuffDiff = FileHelper.ReadParamFromXml("CuffDiff");
            sPreTime = FileHelper.ReadParamFromXml("CuffBeginTime");
            sIsSendMsg = FileHelper.ReadParamFromXml("IsSendMsg");
            sSendMsg = "";
            sLogSaveDate = FileHelper.ReadParamFromXml("LogSaveDate");
            sIsBroadCast = FileHelper.ReadParamFromXml("IsBroadCast");
            sBroadCastDiff = FileHelper.ReadParamFromXml("BroadCastDiff");
            sBroadCastMsgTime = FileHelper.ReadParamFromXml("BroadCastMsgTime");
            sIsLBSPos = FileHelper.ReadParamFromXml("IsLBSPos");
            sLBSMuliPosType = FileHelper.ReadParamFromXml("LBSMuliPosTypes");
            sGetLBSPosDataInterval = FileHelper.ReadParamFromXml("GetLBSPosDataInterval");
            sLBSPosInterval = FileHelper.ReadParamFromXml("LBSPosInterval");
            sLBSPosMaxNum = FileHelper.ReadParamFromXml("LBSPosMaxNum");
            sLBSPosSleepTime = FileHelper.ReadParamFromXml("LBSPosSleepTime");
            sLBSType = FileHelper.ReadParamFromXml("LBSType");
            sLBSStarTime = FileHelper.ReadParamFromXml("LBSStartTime");
            sLBSEndTime = FileHelper.ReadParamFromXml("LBSEndTime");
            sIsBillPos = FileHelper.ReadParamFromXml("IsBillPos");
            sOrderDays = FileHelper.ReadParamFromXml("Days");
            sBillTime = FileHelper.ReadParamFromXml("BillTime");
            sMapUrl = FileHelper.ReadParamFromXml("MapUrl");
            sAppIp = FileHelper.ReadParamFromXml("AppIp");
            sAppPort = FileHelper.ReadParamFromXml("AppPort");
            sAppUser = FileHelper.ReadParamFromXml("AppUser");
            sAppPwd = FileHelper.ReadParamFromXml("AppPwd");
            sIsChkErr = FileHelper.ReadParamFromXml("IsChkErr");
            sChkInterval = FileHelper.ReadParamFromXml("ChkInterval");
            sDelayTime = FileHelper.ReadParamFromXml("DelayTime");
            sLinkman = FileHelper.ReadParamFromXml("Linkman");
            sLinkmanMailTo = FileHelper.ReadParamFromXml("LinkmanMailTo");
            sLinkmanMailCC = FileHelper.ReadParamFromXml("LinkmanMailCC");
            sIsLCSPos = FileHelper.ReadParamFromXml("IsLCSPos");
            sLCSPosTime = FileHelper.ReadParamFromXml("LCSPosTime");
            sLCSTime = FileHelper.ReadParamFromXml("LCSTime");
            sLCSCount = FileHelper.ReadParamFromXml("LCSCount");
            sExecUserId = "GpsTimerService";
            sIsAdminRegionAlarm = FileHelper.ReadParamFromXml("IsAdminRegionAlarm");
            sGetCurrentPosInterval = FileHelper.ReadParamFromXml("GetCurrentPosInterval");
            sIsBeBackOnTime = FileHelper.ReadParamFromXml("IsBeBackOnTime");
            sGetBeBackConfig = FileHelper.ReadParamFromXml("GetBeBackConfig");
            sGetBeBackPos = FileHelper.ReadParamFromXml("GetBeBackPos");
            sIsDWLBSPos = FileHelper.ReadParamFromXml("IsDWLBSPos");
            sDWLBSTime = FileHelper.ReadParamFromXml("DWLBSTime");
            sIsInOutOfRangeOnTime = FileHelper.ReadParamFromXml("IsInOutOfRangeOnTime");
            sGetInOutConfig = FileHelper.ReadParamFromXml("GetInOutConfig");
            sGetInOutPos = FileHelper.ReadParamFromXml("GetInOutPos");
            sIsPathAlarm = FileHelper.ReadParamFromXml("IsPathAlarm");
            sIsPathSegmentAlarm = FileHelper.ReadParamFromXml("IsPathSegmentAlarm");
            sIsRegionAlarm = FileHelper.ReadParamFromXml("IsRegionAlarm");
            sPathAlarmInterval = FileHelper.ReadParamFromXml("PathAlarmInterval");
            sIsOnlyFillCheck = FileHelper.ReadParamFromXml("IsOnlyFillCheck");
            sIsContinuousAlarm = FileHelper.ReadParamFromXml("IsContinuousAlarm");
            schkDownMsg = FileHelper.ReadParamFromXml("chkDownMsg");
            sIsJTBOnOffNotice = FileHelper.ReadParamFromXml("IsJTBOnOffNotice");
            sJTBOnOffInterval = FileHelper.ReadParamFromXml("JTBOnOffInterval");
            sJTBOffLineTime = FileHelper.ReadParamFromXml("JTBOffLineTime");
            sIsTerminalDemand = FileHelper.ReadParamFromXml("IsTerminalDemand");
            sDownInterval = FileHelper.ReadParamFromXml("DownInterval");
            sIsSeparateAndSticky = FileHelper.ReadParamFromXml("IsSeparateAndSticky");
            sSeparateAndSticky = FileHelper.ReadParamFromXml("SeparateAndSticky");
            sAlarmInterval = FileHelper.ReadParamFromXml("AlarmInterval");
            sIsGatheredAlarm = FileHelper.ReadParamFromXml("IsGatheredAlarm");
            sGatheredAlarmInterval = FileHelper.ReadParamFromXml("GatheredAlarmInterval");
            sEffectiveTime = FileHelper.ReadParamFromXml("EffectiveTime");
            sIsCurrentAddress = FileHelper.ReadParamFromXml("IsCurrentAddress");
            sCurrentAddressInterval = FileHelper.ReadParamFromXml("CurrentAddressInterval");
            sIsMsgRemind = FileHelper.ReadParamFromXml("IsMsgRemind");
            sAppointedTime = FileHelper.ReadParamFromXml("AppointedTime");
            sWarnMsg1 = FileHelper.ReadParamFromXml("WarnMsg1");
            sWarnMsg2 = FileHelper.ReadParamFromXml("WarnMsg2");
            sWarnMsg3 = FileHelper.ReadParamFromXml("WarnMsg3");
            sTerminalTypeID = FileHelper.ReadParamFromXml("TerminalTypeID");
            sIsSendPZMsg = FileHelper.ReadParamFromXml("IsSendPZMsg");
            sPZType = FileHelper.ReadParamFromXml("numPZType");
            sPZInterval = FileHelper.ReadParamFromXml("numPZInterval");
            sPZSendMsg = FileHelper.ReadParamFromXml("tbPZMsg");
            sIsForbidDriveAlarm = FileHelper.ReadParamFromXml("IsForbidDriveAlarm");
            snumForbidDriveInterval = FileHelper.ReadParamFromXml("numForbidDriveInterval");
            schkIsSendDriverAlarm = FileHelper.ReadParamFromXml("IsSendDriverAlarm");
            sSendDriverAlarmMsg = FileHelper.ReadParamFromXml("SendDriverAlarmMsg");
            sIsThreeLevelRoadAlarm = FileHelper.ReadParamFromXml("IsThreeLevelRoadAlarm");
            snumThreeLevelRoadInterval = FileHelper.ReadParamFromXml("numThreeLevelRoadInterval");
            schkRoadSpeedAndRank = FileHelper.ReadParamFromXml("chkRoadSpeedAndRank");
            sRoadSpeedAndRankInterval = FileHelper.ReadParamFromXml("RoadSpeedAndRankInterval");
            schkIsSend = FileHelper.ReadParamFromXml("IsSend");
            sSendMessage = FileHelper.ReadParamFromXml("SendMsg");
            sRoadSpeedAndRankGisType = FileHelper.ReadParamFromXml("RoadSpeedAndRankGisType");
            sRoadSpeedAndRankOtherGisAddress = FileHelper.ReadParamFromXml("RoadSpeedAndRankOtherGisAddress");
        }

        public static string AppIp
        {
            get
            {
                return sAppIp;
            }
        }

        public static string AppPort
        {
            get
            {
                return sAppPort;
            }
        }

        public static string AppPwd
        {
            get
            {
                return sAppPwd;
            }
        }

        public static string AppUser
        {
            get
            {
                return sAppUser;
            }
        }

        public static int BillTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sBillTime);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int BroadCastDiff
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sBroadCastDiff);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static int BroadCastMsgTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sBroadCastMsgTime);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int ChkErrDiff
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sChkInterval);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static string CommunicationUrl
        {
            get
            {
                return sCommunicationUrl;
            }
        }

        public static string CuffBeginTime
        {
            get
            {
                try
                {
                    return sPreTime;
                }
                catch
                {
                    return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

        public static int CuffDiff
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sCuffDiff);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static string DelayTime
        {
            get
            {
                return sDelayTime;
            }
        }

        public static int DownInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sDownInterval);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int DWLBSTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sDWLBSTime);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static string ExecUserId
        {
            get
            {
                return sExecUserId;
            }
        }

        public static int GetBeBackConfig
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sGetBeBackConfig);
                }
                catch
                {
                    return 10;
                }
            }
        }

        public static int GetBeBackPos
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sGetBeBackPos);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static int GetCurrentPosInfo
        {
            get
            {
                try
                {
                    return int.Parse(sGetCurrentPosInterval);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int GetInOutConfig
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sGetInOutConfig);
                }
                catch
                {
                    return 10;
                }
            }
        }

        public static int GetInOutPos
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sGetInOutPos);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static int GetLBSPosDataInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sGetLBSPosDataInterval);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int iAlarmInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sAlarmInterval);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int iAppointedTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sAppointedTime);
                }
                catch
                {
                    return 0x30;
                }
            }
        }

        public static int iCurrentAddressInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sCurrentAddressInterval);
                }
                catch
                {
                    return 5;
                }
            }
        }

        public static int iEffectiveTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sEffectiveTime);
                }
                catch
                {
                    return 0x30;
                }
            }
        }

        public static int iGatheredAlarmInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sGatheredAlarmInterval);
                }
                catch
                {
                    return 30;
                }
            }
        }

        public static int iPZInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sPZInterval);
                }
                catch
                {
                    return 9;
                }
            }
        }

        public static int iPZType
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sPZType);
                }
                catch
                {
                    return 0x34;
                }
            }
        }

        public static bool IsAdminRegionAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(sIsAdminRegionAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsBeBackOnTime
        {
            get
            {
                try
                {
                    return bool.Parse(sIsBeBackOnTime);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsBillPos
        {
            get
            {
                try
                {
                    return bool.Parse(sIsBillPos);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsBroadCast
        {
            get
            {
                try
                {
                    return bool.Parse(sIsBroadCast);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IschkDownMsg
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(schkDownMsg);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsChkError
        {
            get
            {
                try
                {
                    return bool.Parse(sIsChkErr);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IschkRoadSpeedAndRank
        {
            get
            {
                try
                {
                    return bool.Parse(schkRoadSpeedAndRank);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsContinuousAlarm
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(sIsContinuousAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsCuff
        {
            get
            {
                try
                {
                    return bool.Parse(sIsCuff);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsCurrentAddress
        {
            get
            {
                try
                {
                    return bool.Parse(sIsCurrentAddress);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsDWLBSPos
        {
            get
            {
                try
                {
                    return bool.Parse(sIsDWLBSPos);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static int iSeparateAndSticky
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sSeparateAndSticky);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static bool IsForbidDriveAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(sIsForbidDriveAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsGatheredAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(sIsGatheredAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsInOutOfRangeOnTime
        {
            get
            {
                try
                {
                    return bool.Parse(sIsInOutOfRangeOnTime);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsJTBOnOffNotice
        {
            get
            {
                try
                {
                    return bool.Parse(sIsJTBOnOffNotice);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsLBSPos
        {
            get
            {
                try
                {
                    return bool.Parse(sIsLBSPos);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsLCSPos
        {
            get
            {
                try
                {
                    return bool.Parse(sIsLCSPos);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsMsgRemind
        {
            get
            {
                try
                {
                    return bool.Parse(sIsMsgRemind);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsOnlyFillCheck
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(sIsOnlyFillCheck);
                }
                catch
                {
                    return true;
                }
            }
        }

        public static bool IsPathAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(sIsPathAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsPathSegmentAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(sIsPathSegmentAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsPic
        {
            get
            {
                try
                {
                    return bool.Parse(sIsPic);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsRegionAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(sIsRegionAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsSend
        {
            get
            {
                try
                {
                    return bool.Parse(schkIsSend);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsSendDriverAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(schkIsSendDriverAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsSendMsg
        {
            get
            {
                try
                {
                    return bool.Parse(sIsSendMsg);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsSendPZMsg
        {
            get
            {
                try
                {
                    return bool.Parse(sIsSendPZMsg);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsSeparateAndSticky
        {
            get
            {
                try
                {
                    return bool.Parse(sIsSeparateAndSticky);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsTerminalDemand
        {
            get
            {
                try
                {
                    return bool.Parse(sIsTerminalDemand);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsThreeLevelRoadAlarm
        {
            get
            {
                try
                {
                    return bool.Parse(sIsThreeLevelRoadAlarm);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static int iTerminalTypeID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sTerminalTypeID);
                }
                catch
                {
                    return 0x34;
                }
            }
        }

        public static int JTBOffLineTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sJTBOffLineTime);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int JTBOnOffInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sJTBOnOffInterval);
                }
                catch
                {
                    return 20;
                }
            }
        }

        public static string LBSEndTime
        {
            get
            {
                try
                {
                    return sLBSEndTime;
                }
                catch
                {
                    return "23:59:59";
                }
            }
        }

        public static string LBSMuliPosTypes
        {
            get
            {
                return sLBSMuliPosType;
            }
        }

        public static int LBSPosInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sLBSPosInterval);
                }
                catch
                {
                    return 60;
                }
            }
        }

        public static int LBSPosMaxNum
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sLBSPosMaxNum);
                }
                catch
                {
                    return 120;
                }
            }
        }

        public static int LBSPosSleepTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sLBSPosSleepTime);
                }
                catch
                {
                    return 30;
                }
            }
        }

        public static string LBSStarTime
        {
            get
            {
                try
                {
                    return sLBSStarTime;
                }
                catch
                {
                    return "0:00:00";
                }
            }
        }

        public static string LBSType
        {
            get
            {
                try
                {
                    return sLBSType;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static int LCSCount
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sLCSCount);
                }
                catch
                {
                    return 0xbb8;
                }
            }
        }

        public static int LCSPosTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sLCSPosTime);
                }
                catch
                {
                    return 15;
                }
            }
        }

        public static int LCSTime
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sLCSTime);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static string Linkman
        {
            get
            {
                return sLinkman;
            }
        }

        public static string LogSaveDate
        {
            get
            {
                return sLogSaveDate;
            }
        }

        public static string MapUrl
        {
            get
            {
                return sMapUrl;
            }
        }

        public static int numForbidDriveInterval
        {
            get
            {
                try
                {
                    return int.Parse(snumForbidDriveInterval);
                }
                catch
                {
                    return 3;
                }
            }
        }

        public static int numRoadSpeedAndRankInterval
        {
            get
            {
                try
                {
                    return int.Parse(sRoadSpeedAndRankInterval);
                }
                catch
                {
                    return 10;
                }
            }
        }

        public static int numThreeLevelRoadInterval
        {
            get
            {
                try
                {
                    return int.Parse(snumThreeLevelRoadInterval);
                }
                catch
                {
                    return 10;
                }
            }
        }

        public static string OrderDays
        {
            get
            {
                return sOrderDays;
            }
        }

        public static int PathAlarmInterval
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sPathAlarmInterval);
                }
                catch
                {
                    return 3;
                }
            }
        }

        public static int PicTimeDiff
        {
            get
            {
                try
                {
                    return Convert.ToInt32(sPicTime);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static string PZSendMsg
        {
            get
            {
                return sPZSendMsg;
            }
        }

        public static string RoadSpeedAndRankGisType
        {
            get
            {
                return sRoadSpeedAndRankGisType;
            }
        }

        public static string RoadSpeedAndRankOtherGisAddress
        {
            get
            {
                return sRoadSpeedAndRankOtherGisAddress;
            }
        }

        public static string SendDriverAlarmMsg
        {
            get
            {
                return sSendDriverAlarmMsg;
            }
        }

        public static string SendMessage
        {
            get
            {
                return sSendMessage;
            }
        }

        public static string SendMsg
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(sSendMsg))
                    {
                        sSendMsg = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\StarNet\GpsWebServices\1.0", "AlarmSndMsgtext", "");
                    }
                    return sSendMsg;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string WarnMsg1
        {
            get
            {
                return sWarnMsg1;
            }
        }

        public static string WarnMsg2
        {
            get
            {
                return sWarnMsg2;
            }
        }

        public static string WarnMsg3
        {
            get
            {
                return sWarnMsg3;
            }
        }
    }
}

