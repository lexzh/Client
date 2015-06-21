using PublicClass;
using ParamLibrary.Application;
using Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Remoting;
using ParamLibrary.Entity;
using ParamLibrary.CmdParamInfo;
using ParamLibrary.Bussiness;
using ParamLibrary.CarEntity;

namespace Remoting
{
    public class RemotingClient
    {
        private static IRemotingServer app;

        public static int m_iWorkId;

        private static Response reResult;

        private static AppRespone appRespone;

        static RemotingClient()
        {
            RemotingClient.m_iWorkId = -1;
            RemotingClient.reResult = new Response();
            RemotingClient.appRespone = new AppRespone();
        }

        public RemotingClient()
        {
        }

        public static int Alarm_DelPath(int iPathId, string sPathName)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.Alarm_DelPath(iPathId, sPathName);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("删除路线", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("删除路线", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static bool Alarm_DelPathCheckAuth(int iPathId, string sPathName)
        {
            bool flag;
            if (RemotingClient.app == null)
            {
                return false;
            }
            try
            {
                flag = RemotingClient.app.Alarm_DelPathCheckAuth(iPathId, sPathName);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("判断是否有删除当前路线权限", socketException.Message);
                flag = false;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("判断是否有删除当前路线权限", exception.ToString());
                flag = false;
            }
            return flag;
        }

        public static int Alarm_DelRegion(string sPathName)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.Alarm_DelRegion(sPathName);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("删除区域", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("删除区域", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static bool Alarm_DelRegionCheckAuth(string sRegionName)
        {
            bool flag;
            if (RemotingClient.app == null)
            {
                return false;
            }
            try
            {
                flag = RemotingClient.app.Alarm_DelRegionCheckAuth(sRegionName);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("判断是否有删除当前区域权限", socketException.Message);
                flag = false;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("判断是否有删除当前区域权限", exception.ToString());
                flag = false;
            }
            return flag;
        }

        public static DataTable Alarm_GetGroupType()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_GetGroupType();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获得分类", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获得分类", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Alarm_GetPathInfo()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_GetPathInfo();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取用户的路线信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取用户的路线信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Alarm_GetPathSegmentInfo()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_GetPathSegmentInfo();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("预设路线路段", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("预设路线路段", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Alarm_GetRegionInfo()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_GetRegionInfo();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取用户的区域分组信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取用户的区域分组信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static int Alarm_InsertPathRelatedType(int pathGroupId, int pathId)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.Alarm_InsertPathRelatedType(pathGroupId, pathId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("添加路线关联", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("添加路线关联", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static int Alarm_InsertRelatedType(int pathGroupId, int regionId)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.Alarm_InsertRelatedType(pathGroupId, regionId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("添加关联", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("添加关联", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static int Alarm_InsertRelatedType(string[] pathGroupIdLst, int pathId)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.Alarm_InsertRelatedType(pathGroupIdLst, pathId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("添加关联", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("添加关联", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static DataTable Alarm_PreSetPath(string pathStr, string pathName, int pathType, int region_Radius, string factoryName, double lon_Factory, double lat_Factory, string buildingSitName, double lon_BuildingSit, double lat_BuildingSit)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_PreSetPath(pathStr, pathName, pathType, region_Radius, factoryName, lon_Factory, lat_Factory, buildingSitName, lon_BuildingSit, lat_BuildingSit);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("预设路线", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("预设路线", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Alarm_PreSetPathEx(string pathStr, string pathName, int pathType, int region_Radius, string factoryName, double lon_Factory, double lat_Factory, string buildingSitName, double lon_BuildingSit, double lat_BuildingSit, string remark, string[][] pathSegments)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_PreSetPathEx(pathStr, pathName, pathType, region_Radius, factoryName, lon_Factory, lat_Factory, buildingSitName, lon_BuildingSit, lat_BuildingSit, remark, pathSegments);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("预设路线", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("预设路线", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Alarm_PreSetRegion(string regionStr, string regionName, int iRegionFeature)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_PreSetRegion(regionStr, regionName, iRegionFeature);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("预设区域", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("预设区域", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Alarm_ShowGroupType()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Alarm_ShowGroupType();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获得分类", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获得分类", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static Response Alarm_UdateRegionDot(string regionStr, string regionId)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                response = RemotingClient.app.Alarm_UdateRegionDot(regionId, regionStr);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("修改预设区域", socketException.Message);
                response = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("修改预设区域", exception.ToString());
                response = null;
            }
            return response;
        }

        public static Response Alarm_UdateRegionDot(string regionId, string regionDot, string regionName, int pathGroupId)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                response = RemotingClient.app.Alarm_UdateRegionDot(regionId, regionDot, regionName, pathGroupId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("修改预设区域", socketException.Message);
                response = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("修改预设区域", exception.ToString());
                response = null;
            }
            return response;
        }

        public static DataTable Area_getAreaInfoAll()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.Area_getAreaInfoAll();
                }
                else
                {
                    byte[] numArray = RemotingClient.app.Area_getAreaInfoAllByCompress();
                    if (numArray != null)
                    {
                        dataTable = CompressHelper.Decompress(numArray);
                    }
                    else
                    {
                        dataTable = null;
                    }
                }
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取子区域的区域信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取子区域的区域信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Area_GetUserAreaInfo()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Area_GetUserAreaInfo();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取多区域的用户区域信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取多区域的用户区域信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static Response Car_CommandParameterInsterToDB(CmdParam.ParamType ParamType, string CarVals, string sPwd, SimpleCmd cmdParameter, string cmdContent, string discription)
        {
            Response dB;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                dB = RemotingClient.app.Car_CommandParameterInsterToDB(ParamType, CarVals, sPwd, cmdParameter, cmdContent, discription);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("交通部协议指令", socketException.Message);
                dB = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("交通部协议指令", remotingException.Message);
                dB = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("交通部协议指令", exception.ToString());
                dB = RemotingClient.reResult;
            }
            return dB;
        }

        public static DataTable Car_GetAlarmPathDotFromGisCar(string strCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetAlarmPathDotFromGisCar(strCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取行驶路线报警点", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取行驶路线报警点", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetCaptureMoniterDataByCarId(string strCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetCaptureMoniterDataByCarId(strCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取图像监控初始化数据", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取图像监控初始化数据", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetCarAlarmRegionInfo(string strCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetCarAlarmRegionInfo(strCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆的报警区域信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆的报警区域信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetCarAlarmState(string strCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetCarAlarmState(strCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆的报警状态", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆的报警状态", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetCarConfig(string sCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetCarConfig(sCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆的配置", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆的配置", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static CommonCar Car_GetCarDetailInfoByCarId(string CarId)
        {
            CommonCar commonCar;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                commonCar = RemotingClient.app.Car_GetCarDetailInfoByCarId(CarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("通过车辆编号获取车辆的详细信息", socketException.Message);
                commonCar = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("通过车辆编号获取车辆的详细信息", exception.ToString());
                commonCar = null;
            }
            return commonCar;
        }

        public static DataTable Car_GetCarImgInfo(string strPhone, string strGpsTime, string strCaremaId, string strReceTime)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetCarImgInfo(strPhone, strGpsTime, strCaremaId, strReceTime);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取图像监控信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取图像监控信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetCarList(int iPage)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.Car_GetCarList(iPage, int.Parse(Variable.sRecsPerPage));
                }
                else
                {
                    byte[] numArray = RemotingClient.app.Car_GetCarListByCompress(iPage, int.Parse(Variable.sRecsPerPage));
                    if (numArray != null)
                    {
                        dataTable = CompressHelper.Decompress(numArray);
                    }
                    else
                    {
                        dataTable = null;
                    }
                }
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆列表", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆列表", exception.Message);
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetCarListEx(int iPage)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.Car_GetCarListEx(iPage, int.Parse(Variable.sRecsPerPage));
                }
                else
                {
                    byte[] numArray = RemotingClient.app.Car_GetCarListExByCompress(iPage, int.Parse(Variable.sRecsPerPage));
                    if (numArray != null)
                    {
                        dataTable = CompressHelper.Decompress(numArray);
                    }
                    else
                    {
                        dataTable = null;
                    }
                }
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆列表", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆列表", exception.Message);
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetCarMutilVideoInfo(string strPhone, string strGpsTime, string strCaremaId, string picDataType, string strReceTime)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetCarMutilVideoInfo(strPhone, strGpsTime, strCaremaId, picDataType, strReceTime);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取图像监控信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取图像监控信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetDevice(string sCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetDevice(sCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得终端外设类型", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得终端外设类型", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetDeviceShareRef()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetDeviceShareRef();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得终端外设配置", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得终端外设配置", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetInterestPointMulti(string strMapType, int iPoiAutn)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetInterestPointMulti(strMapType, iPoiAutn);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("多用户兴趣点查询", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("多用户兴趣点查询", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetInterestPointSingle(string strMapType, int iPoiAutn)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetInterestPointSingle(strMapType, iPoiAutn);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("单用户兴趣点查询", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("单用户兴趣点查询", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetMapType()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetMapType();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取兴趣点类别(全部)", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取兴趣点类别(全部)", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetNewPathId(string strCarId, string strPathName, int iMaxPathId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetNewPathId(strCarId, strPathName, iMaxPathId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取新的路线Id", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取新的路线Id", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetNewRegionId(string strCarId, string strRegionName, int iMaxRegionId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetNewRegionId(strCarId, strRegionName, iMaxRegionId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取新的区域Id", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取新的区域Id", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetPassWayPathID(string strCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetPassWayPathID(strCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取出入口分段超速报警参数", socketException.Message);
                dataTable = null;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("获取出入口分段超速报警参数", remotingException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取出入口分段超速报警参数", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetPathAlarm(string strCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetPathAlarm(strCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取用户某辆车的行驶路线报警", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取用户某辆车的行驶路线报警", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetPathAlarmAnother(string strCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetPathAlarmAnother(strCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取用户辆车的行驶路线报警", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取用户辆车的行驶路线报警", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetPathRouteByPathName(string strPathNames)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetPathRouteByPathName(strPathNames);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("通过路线名称获取路线信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("通过路线名称获取路线信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetPathSegmentAlarm(string sCarid)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetPathSegmentAlarm(sCarid);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("设置分段路线报警", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置分段路线路段", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetPhonesByType(CmdParam.PhoneType phoneType, string sCarID)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetPhonesByType(phoneType, sCarID);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得电话设置的参数", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得电话设置的参数", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetPOIAuth()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetPOIAuth();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取PoiAuth", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取PoiAuth", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetRefRegion(string sPoints)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                string[] strArrays = sPoints.Split(new char[] { ';' });
                string str = strArrays[0];
                char[] chrArray = new char[] { ',' };
                double num = double.Parse(str.Split(chrArray)[0]);
                string str1 = strArrays[0];
                char[] chrArray1 = new char[] { ',' };
                double num1 = double.Parse(str1.Split(chrArray1)[1]);
                string str2 = strArrays[2];
                char[] chrArray2 = new char[] { ',' };
                double num2 = double.Parse(str2.Split(chrArray2)[0]);
                string str3 = strArrays[2];
                char[] chrArray3 = new char[] { ',' };
                double num3 = double.Parse(str3.Split(chrArray3)[1]);
                dataTable = RemotingClient.app.Car_GetRefRegion(num, num1, num2, num3);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得拉框查车列表", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得拉框查车列表", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Car_GetRegionInfo(string strCarId, int iRegionFeature)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Car_GetRegionInfo(strCarId, iRegionFeature);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取区域报警的信息", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取区域报警的信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static int Car_SaveFormCmdParam(string sCarParamInfo, string sCmdType, string sCmdContent)
        {
            int num;
            try
            {
                num = RemotingClient.app.Car_SaveFormCmdParam(sCarParamInfo, sCmdType, sCmdContent);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("保存下发参数(报表用)", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("保存下发参数(报表用)", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static int Car_SaveFormSetParam(string sCarParamInfo, string sMsgType, string sParam)
        {
            int num;
            try
            {
                num = RemotingClient.app.Car_SaveFormSetParam(sCarParamInfo, sMsgType, sParam);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("保存下发参数(界面用)", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("保存下发参数(界面用)", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static AppRespone Car_SetCommonCmd_Pass(AppRequest pAppRequest)
        {
            AppRespone appRespone;
            AppRespone appRespone1 = new AppRespone();
            if (RemotingClient.app == null)
            {
                return appRespone1;
            }
            try
            {
                appRespone = RemotingClient.app.DownData_icar_SetCommonCmd_Pass(pAppRequest);
            }
            catch (SocketException socketException1)
            {
                SocketException socketException = socketException1;
                Record.execFileRecord(pAppRequest.OrderCode.ToString(), socketException.Message);
                appRespone = appRespone1;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                Record.execFileRecord(pAppRequest.OrderCode.ToString(), exception.ToString());
                appRespone = appRespone1;
            }
            return appRespone;
        }

        public static Response Car_SmallArea(string sLongtide, string sLatitude, string sDis, TxtMsg MsgContext)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.Car_SmallArea(sLongtide, sLatitude, sDis, MsgContext);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("小范围电召", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("小范围电召", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response Car_SmallArea_FJYD(string sLeftLon, string sLeftLat, string sRightLon, string sRightLat, string sResWay, string sResPhone, TxtMsg MsgContext, CmdParam.CommMode commMode)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.Car_SmallArea_FJYD(sLeftLon, sLeftLat, sRightLon, sRightLat, sResWay, sResPhone, MsgContext, commMode);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("小范围电召(福建移动)", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("小范围电召(福建移动)", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("小范围电召(福建移动)", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static int Car_UpdateImportWatch(string sPhone, int iFlag)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.Car_UpdateImportWatch(sPhone, iFlag);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("更新重点监控参数", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("更新重点监控参数", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static int Car_WatchCar(string AreaCodeOrCarId, bool isRegion, bool isAdd)
        {
            if (RemotingClient.app == null)
            {
                return -1;
            }
            try
            {
                return RemotingClient.app.CarFilter_SetCheckedCar(AreaCodeOrCarId, isRegion, isAdd);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("添加车辆到监控列表", socketException.Message);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("添加车辆到监控列表", exception.Message);
            }
            return -1;
        }

        public static DataTable CarDataInfoBuffer_GetArarmCarList()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                byte[] numArray = RemotingClient.app.CarDataInfoBuffer_GetArarmCarListByCompress();
                DataTable dataTable1 = null;
                if (numArray != null)
                {
                    dataTable1 = CompressHelper.Decompress(numArray);
                }
                dataTable = dataTable1;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("重新取得报警列表", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("重新取得报警列表", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable CarOil_GetOilAnalogValue(string sCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.CarOil_GetOilAnalogValue(sCarId);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("油箱模拟量", exception.Message);
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable CarOil_GetOilBoxInfo(string sCarId)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.CarOil_GetOilBoxInfo(sCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆油箱容量值", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆油箱容量值", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static int CarOil_GetOilBoxVol(string sCarId)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.CarOil_GetOilBoxVol(sCarId);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆油箱容量值", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆油箱容量值", exception.ToString());
                num = -100;
            }
            return num;
        }

        public static void CutOff()
        {
            RemotingClient.app = null;
        }

        public static DataTable DownData_GetCarInfoByArea_By_Circle(string longtide, string latitude, string radius)
        {
            DataTable dataTable;
            try
            {
                dataTable = RemotingClient.app.DownData_GetCarInfoByArea_By_Circle(longtide, latitude, radius);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("小范围电召圆形区域取得车辆列表", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("小范围电召圆形区域取得车辆列表", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable DownData_GetCarInfoByArea_By_Rectangle(string leftLon, string leftLat, string rightLon, string rightLat)
        {
            DataTable dataTable;
            try
            {
                dataTable = RemotingClient.app.DownData_GetCarInfoByArea_By_Rectangle(leftLon, leftLat, rightLon, rightLat);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("小范围电召矩形区域取得车辆列表", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("小范围电召矩形区域取得车辆列表", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static AppRespone DownData_icar_SendRawPackage(AppRequest pRequest, object pvArg)
        {
            AppRespone appRespone;
            if (RemotingClient.app == null)
            {
                return RemotingClient.appRespone;
            }
            try
            {
                appRespone = RemotingClient.app.DownData_icar_SendRawPackage(pRequest, pvArg);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("通讯透传协议", exception.Message);
                appRespone = RemotingClient.appRespone;
            }
            return appRespone;
        }

        public static Response DownData_icar_SendRawPackage(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SimpleCmd simpleCmd)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SendRawPackage(ParamType, CarValues, CarPw, CommMode, simpleCmd);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("通讯透传协议", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_icar_SendRawPackage(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TrafficRawPackage trafficRawPackage)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.icar_SendRawPackage(ParamType, CarValues, CarPw, CommMode, trafficRawPackage);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("交通部透传协议", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_icar_SetCommonCmd_XCJLY(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SimpleCmd simpleCmd)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                string str = "";
                if (simpleCmd.CmdParams != null)
                {
                    foreach (string[] cmdParam in simpleCmd.CmdParams)
                    {
                        string[] strArrays = cmdParam;
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            str = string.Concat(str, strArrays[i], ";");
                        }
                        char[] chrArray = new char[] { ';' };
                        str = string.Concat(str.Trim(chrArray), "|");
                    }
                    string str1 = simpleCmd.OrderCode.ToString();
                    char[] chrArray1 = new char[] { '|' };
                    Record.execFileRecord(str1, str.Trim(chrArray1));
                }
                response = RemotingClient.app.DownData_icar_SetCommonCmd_XCJLY(ParamType, CarValues, CarPw, CommMode, simpleCmd);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("Db44简单协议指令", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("Db44简单协议指令", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("Db44简单协议指令", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_icar_SetTextMsg(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TxtMsg trafficTextMsg)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.icar_SetTextMsg(ParamType, CarValues, CarPw, CommMode, trafficTextMsg);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("发送调度信息", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_icar_SmallArea_FJYD(string leftLon, string leftLat, string rightLon, string rightLat, string tryWay, string stelNumber, ArrayList sendCarlist, TxtMsg MsgContext, CmdParam.CommMode commMode)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_icar_SmallArea_FJYD(leftLon, leftLat, rightLon, rightLat, tryWay, stelNumber, sendCarlist, MsgContext, commMode);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("小范围电召(福建移动)", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("小范围电召(福建移动)", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("小范围电召(福建移动)", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_RemoteDial(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, RemoteDial remoteDial)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_RemoteDial(ParamType, CarValues, CarPw, CommMode, remoteDial);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("点对点电召", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_RemoteUpdate(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_RemoteUpdate(ParamType, CarValues, CarPw, CommMode);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("远程升级终端软件", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SelMultiPathAlarm(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, PathAlarmList pathAlarmList)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SelMultiPathAlarm(ParamType, CarValues, CarPw, CommMode, pathAlarmList);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置多路线报警", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SelMultiPathAlarm_FJYD(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode commMode, PathAlarmList pathAlarmList)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SelMultiPathAlarm_FJYD(ParamType, CarValues, CarPw, commMode, pathAlarmList);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("设置偏航报警(福建移动)", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("设置偏航报警(福建移动)", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置偏航报警(福建移动)", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SendRawPackage(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SimpleCmd simpleCmd)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SendRawPackage(ParamType, CarValues, CarPw, CommMode, simpleCmd);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("回拔坐席电话", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SendTxtMsg(CmdParam.ParamType ParamType, string sCarValue, string sPw, CmdParam.CommMode CommMode, ParamLibrary.CmdParamInfo.TxtMsg TxtMsg)
        {
            Response response = null;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SendTxtMsg(ParamType, sCarValue, sPw, CommMode, TxtMsg);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("发送消息指令处理", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetAlarmFlag(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, AlarmEntity arlamArgs)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetAlarmFlag(ParamType, CarValues, CarPw, CommMode, arlamArgs);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置车台报警器标志位命令", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetBlackBox(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, BlackBox blackbox)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetBlackBox(ParamType, CarValues, CarPw, CommMode, blackbox);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置黑匣子采样间隔", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetCallLimit(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, CallLimit callLimit)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetCallLimit(ParamType, CarValues, CarPw, CommMode, callLimit);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置呼叫限制", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetCaptureEx(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, CaptureEx captureEx)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetCaptureEx(ParamType, CarValues, CarPw, CommMode, captureEx);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("实时图像监控和多种条件图像监控", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetCommArg(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, CommArgs commArgs)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetCommArg(ParamType, CarValues, CarPw, CommMode, commArgs);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("配置终端通讯参数", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetCommonCmd_FJYD(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SimpleCmd simpleCmd)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                if (simpleCmd.CmdParams != null)
                {
                    string str = "";
                    foreach (string[] cmdParam in simpleCmd.CmdParams)
                    {
                        string[] strArrays = cmdParam;
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            str = string.Concat(str, strArrays[i], ";");
                        }
                        char[] chrArray = new char[] { ';' };
                        str = string.Concat(str.Trim(chrArray), "|");
                    }
                    string str1 = simpleCmd.OrderCode.ToString();
                    char[] chrArray1 = new char[] { '|' };
                    Record.execFileRecord(str1, str.Trim(chrArray1));
                }
                response = RemotingClient.app.DownData_SetCommonCmd_FJYD(ParamType, CarValues, CarPw, CommMode, simpleCmd);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("移动特殊使用的简单协议指令", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("移动特殊使用的简单协议指令", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("移动特殊使用的简单协议指令", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetCustomAlarmer(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, AlarmEntity alarmEntity)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetCustomAlarmer(ParamType, CarValues, CarPw, CommMode, alarmEntity);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("配置自定义报警器", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetLastDotQuery(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, CmdParam.OrderCode ordercode)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetLastDotQuery(ParamType, CarValues, CarPw, CommMode, ordercode);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置车台报警器标志位命令", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetMinSMSReportInterval(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, MinSMSReportInterval minSmsReport)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetMinSMSReportInterval(ParamType, CarValues, CarPw, CommMode, minSmsReport);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置以短信方式汇报的最小时间间隔", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetMultiSegSpeedAlarm(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, PathAlarmList pathAlarmList)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetMultiSegSpeedAlarm(ParamType, CarValues, CarPw, CommMode, pathAlarmList);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置多路线超速报警", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetPhone(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SetPhone setPhone)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetPhone(ParamType, CarValues, CarPw, CommMode, setPhone);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置车台号码", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetPosReport(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, PosReport posReport)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetPosReport(ParamType, CarValues, CarPw, CommMode, posReport);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("车辆定位汇报", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetRegionAlarm(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, RegionAlarmList regionAlarmList)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetRegionAlarm(ParamType, CarValues, CarPw, CommMode, regionAlarmList);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置区域报警", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetRegionAlarm_FJYD(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, RegionAlarmList regionAlarmList)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetRegionAlarm_FJYD(ParamType, CarValues, CarPw, CommMode, regionAlarmList);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("设置区域报警(福建移动)", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("设置区域报警(福建移动)", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置区域报警(福建移动)", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetSpeedAlarm(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SpeedAlarm speedAlarm)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetSpeedAlarm(ParamType, CarValues, CarPw, CommMode, speedAlarm);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置超速报警", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SetTransportReport(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TransportReport transport)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SetTransportReport(ParamType, CarValues, CarPw, CommMode, transport);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置空重车汇报", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SimpleCmd(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SimpleCmd simpleCmd)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SimpleCmd(ParamType, CarValues, CarPw, CommMode, simpleCmd);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("简单车台命令", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_SimpleCmdEx(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, SimpleCmdEx simpleCmdEx)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_SimpleCmdEx(ParamType, CarValues, CarPw, CommMode, simpleCmdEx);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("简单车台命令", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response DownData_StopCapture(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, StopCapture stopCapturet)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.DownData_StopCapture(ParamType, CarValues, CarPw, CommMode, stopCapturet);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("停止图像监控", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response ExecNoQuery(string sql)
        {
            Response response;
            try
            {
                string str = SecurityHelper.EncryptString(sql);
                response = RemotingClient.app.ExecNoQuery(str);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("处理更新sql语句", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("处理更新sql语句", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response ExecParamNoQuery(string sql, List<SqlParam> param)
        {
            Response response;
            try
            {
                string str = SecurityHelper.EncryptString(sql);
                response = RemotingClient.app.ExecParamNoQuery(str, param);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("处理更新sql语句", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("处理更新sql语句", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static DataTable ExecParamSqlByCompress(string sql, List<SqlParam> param)
        {
            DataTable dataTable;
            try
            {
                string str = SecurityHelper.EncryptString(sql);
                byte[] numArray = RemotingClient.app.ExecParamSqlByCompress(str, param);
                if (numArray == null)
                {
                    dataTable = null;
                }
                else
                {
                    dataTable = CompressHelper.Decompress(numArray);
                }
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("处理查询sql语句", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("处理查询sql语句", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable ExecSql(string sql)
        {
            DataTable dataTable;
            try
            {
                string str = SecurityHelper.EncryptString(sql);
                byte[] numArray = RemotingClient.app.ExecSqlByCompress(str);
                if (numArray == null)
                {
                    dataTable = null;
                }
                else
                {
                    dataTable = CompressHelper.Decompress(numArray);
                }
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("处理查询sql语句", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("处理查询sql语句", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static string GetBufferSize()
        {
            if (RemotingClient.app == null)
            {
                return "";
            }
            try
            {
                return RemotingClient.app.GetBufferSize();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得后台队列值", socketException.Message);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得后台队列值", exception.ToString());
            }
            return "";
        }

        public static DataTable GetCommonData(string sCarId, int queryType, string[] queryCondition)
        {
            DataTable commonData;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                commonData = RemotingClient.app.GetCommonData(sCarId, queryType, queryCondition);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取公共查询数据", socketException.Message);
                commonData = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取公共查询数据", exception.ToString());
                commonData = null;
            }
            return commonData;
        }

        public static void GetCorpName()
        {
            if (RemotingClient.app == null)
            {
                return;
            }
            try
            {
                Variable.sCompany = RemotingClient.app.GetCorpName();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得公司名称", socketException.Message);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得公司名称", exception.ToString());
            }
        }

        public static void GetCustomInfo()
        {
            if (RemotingClient.app == null)
            {
                return;
            }
            try
            {
                Variable.sCustomerServiceInfo = RemotingClient.app.GetCustomInfo();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取自定义信息", socketException.Message);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取自定义信息", exception.Message);
            }
        }

        public static string GetDBCurrentDateTime()
        {
            string dBCurrentDateTime;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dBCurrentDateTime = RemotingClient.app.GetDBCurrentDateTime();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得数据库当期时间", socketException.Message);
                dBCurrentDateTime = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得数据库当期时间", exception.ToString());
                dBCurrentDateTime = null;
            }
            return dBCurrentDateTime;
        }

        public static int getE(string sComputerId, string sDogSg, string sSystemId, string sIp, ref string sErrMsg, ref string sEmpowerCd)
        {
            int e;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                e = RemotingClient.app.getE(sComputerId, sDogSg, sSystemId, sIp, ref sErrMsg, ref sEmpowerCd);
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("认证", remotingException.Message);
                e = -100;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("认证", socketException.Message);
                e = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("认证", exception.ToString());
                e = -100;
            }
            return e;
        }

        public static string GetParamData(string sCarid, CmdParam.OrderCode orderID)
        {
            string paramData;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                paramData = RemotingClient.app.GetParamData(sCarid, (int)orderID);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取事件设置和菜单点播设置数据", socketException.Message);
                paramData = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取事件设置和菜单点播设置数据", exception.ToString());
                paramData = null;
            }
            return paramData;
        }

        public static DataTable GetPathAlarmChecked(string sCarid)
        {
            DataTable pathAlarmChecked;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                pathAlarmChecked = RemotingClient.app.GetPathAlarmChecked(sCarid);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取路线报警列表", socketException.Message);
                pathAlarmChecked = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取路线报警列表", exception.ToString());
                pathAlarmChecked = null;
            }
            return pathAlarmChecked;
        }

        public static DataTable GetPhoneNumTextByCarid(string carid)
        {
            DataTable phoneNumTextByCarid;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                phoneNumTextByCarid = RemotingClient.app.GetPhoneNumTextByCarid(carid);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取设置电话本列表", socketException.Message);
                phoneNumTextByCarid = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取设置电话本列表", exception.Message);
                phoneNumTextByCarid = null;
            }
            return phoneNumTextByCarid;
        }

        private static string getServerUrl()
        {
            string str = "tcp";
            if (!"1".Equals(Variable.sUseHttpProxy))
            {
                RemotingManager.RegChannel();
            }
            else
            {
                RemotingManager.RegHttpChannel();
                str = "http";
            }
            return string.Format("{0}://{1}:{2}/GpsClientServerChannel/GpsRemotingServer", str, Variable.sServerIp, Variable.sPort);
        }

        public static void GetTitleName()
        {
            if (RemotingClient.app == null)
            {
                return;
            }
            try
            {
                Variable.sTitle = RemotingClient.app.GetTitleName();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得标题", socketException.Message);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得标题", exception.ToString());
            }
        }

        public static Response getUpdateClientList(string sCurrentVersion)
        {
            Response response;
            try
            {
                string serverUrl = RemotingClient.getServerUrl();
                IRemotingLogin obj = (IRemotingLogin)Activator.GetObject(typeof(IRemotingLogin), serverUrl);
                response = (obj != null ? obj.getUpdateClientList(sCurrentVersion) : RemotingClient.reResult);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取更新程序信息", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取更新程序信息", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response getValidateCode()
        {
            Response response;
            try
            {
                string serverUrl = RemotingClient.getServerUrl();
                IRemotingLogin obj = (IRemotingLogin)Activator.GetObject(typeof(IRemotingLogin), serverUrl);
                if (obj != null)
                {
                    Response response1 = obj.SendMsgLogin(Variable.sAdcNo, Variable.sUserId, Variable.sPassword, Variable.sComputerIp, Variable.iModuleId, RemotingClient.m_iWorkId, Variable.sServerIp, Variable.sPort, out RemotingClient.app);
                    if (response1.ResultCode == (long)0 && !string.IsNullOrEmpty(response1.SvcContext))
                    {
                        Variable.sVerfNum = response1.SvcContext;
                    }
                    obj = null;
                    response = response1;
                }
                else
                {
                    response = RemotingClient.reResult;
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取验证码", exception.Message);
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response icar_SetCommonCmdTraffic(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TrafficSimpleCmd trafficePostReport)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.icar_SetCommonCmdTraffic(ParamType, CarValues, CarPw, CommMode, trafficePostReport);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("交通部协议指令", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("交通部协议指令", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("交通部协议指令", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response icar_SetPhoneNumText(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TrafficPhoneNumText trafficPhoneNumText)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.icar_SetPhoneNumText(ParamType, CarValues, CarPw, CommMode, trafficPhoneNumText);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("交通部协议指令", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("交通部协议指令", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("交通部协议指令", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response icar_SetPlatformAlarmCmd(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TrafficSimpleCmd trafficSimpleCmd)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.icar_SetPlatformAlarmCmd(ParamType, CarValues, CarPw, CommMode, trafficSimpleCmd);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("交通部协议平台报警接口", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("交通部协议平台报警接口", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("交通部协议平台报警接口", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response icar_SetPosReportConditions(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TrafficPosReport trafficePostReport)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.icar_SetPosReportConditions(ParamType, CarValues, CarPw, CommMode, trafficePostReport);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("交通部协议指令", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("交通部协议指令", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("交通部协议指令", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static void iniResult()
        {
            RemotingClient.reResult.ResultCode = (long)-100;
            RemotingClient.reResult.ErrorMsg = "与服务器连接已断开！";
            RemotingClient.appRespone.ResultCode = -100;
            RemotingClient.appRespone.ResultMsg = "与服务器连接已断开！";
        }

        public static bool LoginSys_CheckUser(string inUserId, string inPass)
        {
            bool flag;
            if (RemotingClient.app == null)
            {
                return false;
            }
            try
            {
                flag = RemotingClient.app.LoginSys_CheckUser(inUserId, inPass);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("判断用户是否有权限", socketException.Message);
                flag = false;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("判断用户是否有权限", exception.ToString());
                flag = false;
            }
            return flag;
        }

        public static DataTable LoginSys_GetAllMenu()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.LoginSys_GetAllMenu();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取所有菜单权限", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取所有菜单权限", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static Response LoginSys_Login(bool isValidate, bool isFirst)
        {
            Response response;
            try
            {
                string serverUrl = RemotingClient.getServerUrl();
                IRemotingLogin obj = (IRemotingLogin)Activator.GetObject(typeof(IRemotingLogin), serverUrl);
                if (obj != null)
                {
                    Record.execFileRecord(string.Format("登陆前的wrkid={0}", RemotingClient.m_iWorkId));
                    Response response1 = null;
                    response1 = ((!isValidate || !isFirst )? obj.Login(Variable.sAdcNo, Variable.sUserId, Variable.sPassword, Variable.sComputerIp, Variable.iModuleId, RemotingClient.m_iWorkId, Variable.sServerIp, Variable.sPort, out RemotingClient.app) 
                        : obj.CheckSendMsgLogin(Variable.sAdcNo, Variable.sUserId, Variable.sPassword, Variable.sComputerIp, Variable.iModuleId, RemotingClient.m_iWorkId, Variable.sServerIp, Variable.sPort, out RemotingClient.app, Variable.sVerfNum, Variable.sVerfCode));
                    if (response1.ResultCode == (long)0 && !string.IsNullOrEmpty(response1.SvcContext))
                    {
                        string[] strArrays = response1.SvcContext.Split(new char[] { '|' });
                        RemotingClient.m_iWorkId = int.Parse(strArrays[0]);
                        Variable.sUserName = strArrays[1];
                        Variable.sSecurityKey = strArrays[2];
                        Record.execFileRecord(string.Format("登陆后的wrkid={0}", RemotingClient.m_iWorkId));
                        Variable.iWorkID = RemotingClient.m_iWorkId;
                    }
                    obj = null;
                    response = response1;
                }
                else
                {
                    response = RemotingClient.reResult;
                }
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("登录", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("登录", remotingException.ToString());
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("登录", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response LoginSys_LoginSendMsg(string verifyCode)
        {
            Response response;
            try
            {
                string serverUrl = RemotingClient.getServerUrl();
                IRemotingLogin obj = (IRemotingLogin)Activator.GetObject(typeof(IRemotingLogin), serverUrl);
                response = (obj != null ? obj.LoginSendMsg(Variable.sAdcNo, Variable.sUserId, Variable.sPassword, verifyCode) : RemotingClient.reResult);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("发送ADC验证码", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("发送ADC验证码", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static int MapFlag_AddFlagMap(float lon, float lat, string name, string areaCode, int flagTypeCode)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return -100;
            }
            try
            {
                num = RemotingClient.app.MapFlag_AddFlagMap(lon, lat, name, areaCode, flagTypeCode);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("添加兴趣点", socketException.Message);
                num = -100;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("添加兴趣点", exception.Message);
                num = -100;
            }
            return num;
        }

        public static bool MapFlag_DeleteFlagMap(string name)
        {
            bool flag;
            if (RemotingClient.app == null)
            {
                return false;
            }
            try
            {
                flag = RemotingClient.app.MapFlag_DeleteFlagMap(name);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("删除兴趣点", socketException.Message);
                flag = false;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("删除兴趣点", exception.Message);
                flag = false;
            }
            return flag;
        }

        public static DataTable MapFlag_FlagMapType()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.MapFlag_FlagMapType();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取兴趣点类别", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取兴趣点类别", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable MapFlag_showFlagMap()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.MapFlag_showFlagMap();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取兴趣点", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取兴趣点", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static string ModifyUserPassword(string userId, string userOldPassword, string userNewPassword)
        {
            string message;
            try
            {
                string serverUrl = RemotingClient.getServerUrl();
                IRemotingLogin obj = (IRemotingLogin)Activator.GetObject(typeof(IRemotingLogin), serverUrl);
                if (obj != null)
                {
                    Response response = obj.ModifyUserPassword(userId, userOldPassword, userNewPassword);
                    message = (response.ResultCode != (long)0 ? response.ErrorMsg : "");
                }
                else
                {
                    message = "与服务器连接失败！";
                }
            }
            catch (SocketException socketException1)
            {
                SocketException socketException = socketException1;
                Record.execFileRecord("修改用户密码", socketException.Message);
                message = socketException.Message;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                Record.execFileRecord("修改用户密码", exception.ToString());
                message = exception.Message;
            }
            return message;
        }

        public static Response SaveIOStatusName(string sCarId, string IOStatusName)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.SaveIOStatusName(sCarId, IOStatusName);
            }
            catch (Exception exception)
            {
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static int SendAuthorityFromClient(string oldMachineCode, string newMachineCode, string clientIp, string systemId, string sVersion, out string errorMessage, out string authorityCode)
        {
            int num;
            if (RemotingClient.app == null)
            {
                errorMessage = "与服务器断开连接";
                authorityCode = "";
                return -100;
            }
            try
            {
                num = RemotingClient.app.SendAuthorityFromClient(oldMachineCode, newMachineCode, clientIp, systemId, sVersion, out errorMessage, out authorityCode);
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("认证", remotingException.Message);
                errorMessage = "服务器版本过低";
                authorityCode = "";
                num = -100;
            }
            catch (SocketException socketException1)
            {
                SocketException socketException = socketException1;
                Record.execFileRecord("认证", socketException.Message);
                errorMessage = socketException.Message;
                authorityCode = "";
                num = -100;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                Record.execFileRecord("认证", exception.ToString());
                errorMessage = exception.Message;
                authorityCode = "";
                num = -100;
            }
            return num;
        }

        public static Response SetCarPicTimeParam(string sCarSimNum, CaptureEx m_CaptureEx, string sPicTime)
        {
            Response response;
            try
            {
                response = RemotingClient.app.Car_SetCarPicTimeParam(sCarSimNum, m_CaptureEx, sPicTime);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("设置定时抓拍图像监控", socketException.Message);
                response = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置定时抓拍图像监控", exception.ToString());
                response = null;
            }
            return response;
        }

        public static Response SetParam(string sOrderCode, string sParams1, string sParams2)
        {
            Response response;
            try
            {
                response = RemotingClient.app.SetParam(sOrderCode, sParams1, sParams2);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("保存下发参数", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("保存下发参数", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static Response StopAlarmDeal(CmdParam.ParamType ParamType, string CarValues, string CarPw, CmdParam.CommMode CommMode, TrafficALarmHandle alarmHandle, object objOrder)
        {
            Response response;
            if (RemotingClient.app == null)
            {
                return RemotingClient.reResult;
            }
            try
            {
                response = RemotingClient.app.StopAlarmDeal(ParamType, CarValues, CarPw, CommMode, alarmHandle, objOrder);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("交通部协议指令-->停止报警", socketException.Message);
                response = RemotingClient.reResult;
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("交通部协议指令-->停止报警", remotingException.Message);
                response = RemotingClient.reResult;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("交通部协议指令-->停止报警", exception.ToString());
                response = RemotingClient.reResult;
            }
            return response;
        }

        public static bool Test()
        {
            bool flag;
            if (RemotingClient.app == null)
            {
                return false;
            }
            try
            {
                flag = RemotingClient.app.IsAvtive();
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("心跳响应", remotingException.Message);
                flag = false;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("心跳响应", socketException.Message);
                flag = false;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("心跳响应", exception.ToString());
                flag = false;
            }
            return flag;
        }

        public static DataTable TrackReplay_GetReplayData(string BeginTime, string EndTime, string Tele, int RecordCount, int PageNum, int PageCount, int IsComputeMile, int IsQueryPic)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.TrackReplay_GetReplayData(BeginTime, EndTime, Tele, RecordCount, PageNum, PageCount, IsComputeMile, IsQueryPic);
                }
                else
                {
                    byte[] numArray = RemotingClient.app.TrackReplay_GetReplayDataByCompress(BeginTime, EndTime, Tele, RecordCount, PageNum, PageCount, IsComputeMile, IsQueryPic);
                    dataTable = CompressHelper.Decompress(numArray);
                }
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆轨迹回放数据", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆轨迹回放数据", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable TrackReplay_GetReplayDataCount(string BeginTime, string EndTime, string Tele)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.TrackReplay_GetReplayDataCount(BeginTime, EndTime, Tele);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取轨迹回放的条数和总里程数", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取轨迹回放的条数和总里程数", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable TrackReplay_GetReplayPicData(string GpsTime, string ReceTime, string Tele)
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                byte[] numArray = RemotingClient.app.TrackReplay_GetReplayPicDataByGpsRece(GpsTime, ReceTime, Tele);
                dataTable = CompressHelper.Decompress(numArray);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("获取车辆轨迹回放图片", socketException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取车辆轨迹回放图片", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Updata_GetCarAlarmLog()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.Updata_GetCarAlarmLog();
                }
                else
                {
                    byte[] numArray = RemotingClient.app.Updata_GetCarAlarmLogByCompress();
                    if (numArray != null)
                    {
                        dataTable = CompressHelper.Decompress(numArray);
                    }
                    else
                    {
                        dataTable = null;
                    }
                }
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("读取报警数据", remotingException.Message);
                dataTable = null;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("读取报警数据", socketException.Message);
                dataTable = null;
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                Record.execFileRecord("读取报警数据", "内存溢出");
                dataTable = null;
            }
            catch (IOException oException)
            {
                Record.execFileRecord("读取报警数据", oException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("读取报警数据", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Updata_GetCarCurrentPos()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.Updata_GetCarCurrentPos();
                }
                else
                {
                    byte[] numArray = RemotingClient.app.Updata_GetCarCurrentPosByCompress();
                    if (numArray != null)
                    {
                        dataTable = CompressHelper.Decompress(numArray);
                    }
                    else
                    {
                        dataTable = null;
                    }
                }
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("读取定位数据", remotingException.Message);
                dataTable = null;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("读取定位数据", socketException.Message);
                dataTable = null;
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                Record.execFileRecord("读取定位数据", "内存溢出");
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("读取定位数据", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Updata_GetCarCurrentPosNotSelByCompress()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                byte[] numArray = RemotingClient.app.Updata_GetCarCurrentPosNotSelByCompress();
                if (numArray != null)
                {
                    dataTable = CompressHelper.Decompress(numArray);
                }
                else
                {
                    dataTable = null;
                }
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("取得没有勾选的用户车辆信息", remotingException.Message);
                dataTable = null;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得没有勾选的用户车辆信息", socketException.Message);
                dataTable = null;
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                Record.execFileRecord("取得没有勾选的用户车辆信息", "内存溢出");
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得没有勾选的用户车辆信息", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Updata_GetCarNewLog()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.Updata_GetCarNewLog();
                }
                else
                {
                    byte[] numArray = RemotingClient.app.Updata_GetCarNewLogByCompress();
                    if (numArray != null)
                    {
                        dataTable = CompressHelper.Decompress(numArray);
                    }
                    else
                    {
                        dataTable = null;
                    }
                }
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("读取最新日志数据", remotingException.Message);
                dataTable = null;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("读取最新日志数据", socketException.Message);
                dataTable = null;
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                Record.execFileRecord("读取最新日志数据", "内存溢出");
                dataTable = null;
            }
            catch (IOException oException)
            {
                Record.execFileRecord("读取最新日志数据", oException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("读取最新日志数据", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Updata_GetCarPic()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                if (Variable.sCompressDownCarInfo != "1")
                {
                    dataTable = RemotingClient.app.Updata_GetCarPic();
                }
                else
                {
                    byte[] numArray = RemotingClient.app.Updata_GetCarPicByCompress();
                    if (numArray != null)
                    {
                        dataTable = CompressHelper.Decompress(numArray);
                    }
                    else
                    {
                        dataTable = null;
                    }
                }
            }
            catch (RemotingException remotingException)
            {
                Record.execFileRecord("读取图片数据", remotingException.Message);
                dataTable = null;
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("读取图片数据", socketException.Message);
                dataTable = null;
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                Record.execFileRecord("读取图片数据", "内存溢出");
                dataTable = null;
            }
            catch (IOException oException)
            {
                Record.execFileRecord("读取图片数据", oException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("读取图片数据", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Updata_GetCarReachDateData()
        {
            DataTable dataTable;
            if (RemotingClient.app == null)
            {
                return null;
            }
            try
            {
                dataTable = RemotingClient.app.Updata_GetCarReachDateData();
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("取得到期数据(dataset)", socketException.Message);
                dataTable = null;
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                Record.execFileRecord("取得到期数据", "内存溢出");
                dataTable = null;
            }
            catch (IOException oException)
            {
                Record.execFileRecord("取得到期数据", oException.Message);
                dataTable = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得到期数据(dataset)", exception.ToString());
                dataTable = null;
            }
            return dataTable;
        }

        public static int UpdatePathEx(TrafficPath pathinfo)
        {
            int num;
            if (RemotingClient.app == null)
            {
                return 0;
            }
            try
            {
                num = RemotingClient.app.UpdatePathEx(pathinfo);
            }
            catch (SocketException socketException)
            {
                Record.execFileRecord("预设路线", socketException.Message);
                num = 0;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("预设路线", exception.ToString());
                num = 0;
            }
            return num;
        }

        public static string User_ChangePassword(string sUser, string sOldPassword, string sNewPassword)
        {
            string message;
            if (RemotingClient.app == null)
            {
                return "与服务器连接失败！";
            }
            try
            {
                message = RemotingClient.app.User_ChangePassword(sUser, sOldPassword, sNewPassword);
            }
            catch (SocketException socketException1)
            {
                SocketException socketException = socketException1;
                Record.execFileRecord("更改用户密码", socketException.Message);
                message = socketException.Message;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                Record.execFileRecord("更改用户密码", exception.ToString());
                message = exception.Message;
            }
            return message;
        }
    }
}