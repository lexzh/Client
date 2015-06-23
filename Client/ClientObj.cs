namespace Client
{
    using Client.Plugin;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class ClientObj : IClient
    {
        public event SendObject OnSendObject;

        public void execSendObject(int iObjType, object obj)
        {
            try
            {
                EventSendArgs e = new EventSendArgs {
                    ObjectType = iObjType,
                    Obj = obj
                };
                if (this.OnSendObject != null)
                {
                    this.OnSendObject(new object(), e);
                }
            }
            catch
            {
            }
        }

        private GpsResponse execToResponse(Response result)
        {
            return new GpsResponse { ResultCode = result.ResultCode, ErrorMsg = result.ErrorMsg, OrderIDParam = result.OrderIDParam };
        }

        public DataTable iExecSql(string sSql)
        {
            try
            {
                return RemotingClient.ExecSql(sSql);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->SQL查询处理", exception.Message);
                return null;
            }
        }

        public DataTable iGetArea()
        {
            try
            {
                return MainForm.myCarList.GetAllArea();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->取得区域信息", exception.Message);
                return null;
            }
        }

        public DataTable iGetCarList()
        {
            try
            {
                return MainForm.myCarList.GetAllCar();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->获取车辆列表", exception.Message);
                return null;
            }
        }

        public IPluginParam.TCarInfo iGetCurrentCar()
        {
            try
            {
                return new IPluginParam.TCarInfo { carID = MainForm.myCarList.SelectedCarId, carNum = MainForm.myCarList.SelectedCarNum, simNum = MainForm.myCarList.SelectedSimNum };
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->取得当前选中的车辆", exception.Message);
                return null;
            }
        }

        public string iGetDBCurrentDateTime()
        {
            try
            {
                return RemotingClient.GetDBCurrentDateTime();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->取得数据库当前时间", exception.Message);
                return null;
            }
        }

        public string iGetMapParam()
        {
            try
            {
                return Variable.MapUrl;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->取得地图配置参数", exception.Message);
                return null;
            }
        }

        public GpsResponse iSendTxtMess(int ParamType, string sCarValue, string sPw, int iMessageType, string sMsgTxt)
        {
            try
            {
                TxtMsg txtMsg = new TxtMsg {
                    MsgType = (CmdParam.MsgType) iMessageType,
                    strMsg = sMsgTxt,
                    OrderCode = CmdParam.OrderCode.调度
                };
                Response result = RemotingClient.DownData_SendTxtMsg((CmdParam.ParamType) ParamType, sCarValue, sPw, CmdParam.CommMode.未知方式, txtMsg);
                return this.execToResponse(result);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->向车台终端发送文本消息", exception.Message);
                return new GpsResponse(-1L) { ErrorMsg = exception.Message };
            }
        }

        public GpsResponse iSetCarChecked(string sCarId, bool bAdd)
        {
            GpsResponse response = new GpsResponse(-1L);
            try
            {
                string sCarNum = MainForm.myCarList.execChangeCarValue(1, 0, sCarId);
                int num = MainForm.myCarList.setCarChecked(sCarNum, true);
                if (num != 0)
                {
                    response.ResultCode = num;
                    response.ErrorMsg = "更新监控参数失败！";
                    return response;
                }
                return new GpsResponse(0L);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->设置需要监控的车台终端", exception.Message);
                response.ErrorMsg = exception.Message;
                return response;
            }
        }

        public GpsResponse iSetLastDotQuery(int ParamType, string sCarValue, string sPw)
        {
            try
            {
                Response result = RemotingClient.DownData_SetLastDotQuery((CmdParam.ParamType) ParamType, sCarValue, sPw, CmdParam.CommMode.未知方式, CmdParam.OrderCode.末次位置查询);
                return this.execToResponse(result);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->末次位置查询", exception.Message);
                return new GpsResponse(-1L) { ErrorMsg = exception.Message };
            }
        }

        public void iSetMenu(int iMenuType, ToolStripMenuItem tsm)
        {
            try
            {
                Program.mainForm.execSetMenu(iMenuType, tsm);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->设置菜单", exception.Message);
            }
        }

        public GpsResponse iSetPathAlarm(int ParamType, string sCarValue, string sPw, string[] PathList)
        {
            GpsResponse response = new GpsResponse(-1L);
            try
            {
                PathAlarmList pathAlarmList = new PathAlarmList();
                if (PathList.Length <= 0)
                {
                    response.ErrorMsg = "没有选择预设路线！";
                    Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                    return response;
                }
                StringBuilder builder = new StringBuilder();
                foreach (string str in PathList)
                {
                    builder.Append(str + ",");
                }
                DataTable table = RemotingClient.Car_GetPathRouteByPathName(builder.ToString().Trim(new char[] { ',' }));
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    response.ErrorMsg = "没有读取到偏移路线数据，请重新设置";
                    Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                    return response;
                }
                foreach (DataRow row in table.Rows)
                {
                    PathAlarm alarm = new PathAlarm();
                    ArrayList list2 = new ArrayList();
                    string str2 = row["PathName"] as string;
                    string str3 = row["alarmPathDot"] as string;
                    if (string.IsNullOrEmpty(str3))
                    {
                        response.ErrorMsg = "解析行驶线路失败！";
                        Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                        return response;
                    }
                    string[] strArray = str3.Split(new char[] { '/' });
                    alarm.PointCount = strArray.Length;
                    for (int i = 0; i < (strArray.Length - 1); i++)
                    {
                        if (string.IsNullOrEmpty(strArray[i]))
                        {
                            response.ErrorMsg = "解析行驶线路失败！";
                            Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                            return response;
                        }
                        string[] strArray2 = strArray[i].Split(new char[] { '*' });
                        if (strArray2.Length != 2)
                        {
                            response.ErrorMsg = "解析行驶线路失败！";
                            Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                            return response;
                        }
                        Point point = new Point {
                            Longitude = double.Parse(strArray2[0]),
                            Latitude = double.Parse(strArray2[1])
                        };
                        list2.Add(point);
                    }
                    alarm.Points = list2;
                    alarm.PathName = str2;
                    pathAlarmList.Add(alarm);
                }
                if ((pathAlarmList == null) || (pathAlarmList.Count < 0))
                {
                    response.ErrorMsg = "路线信息集合为空！";
                    Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                    return response;
                }
                pathAlarmList.OrderCode = CmdParam.OrderCode.设置偏移路线报警;
                Response result = RemotingClient.DownData_SelMultiPathAlarm((CmdParam.ParamType) ParamType, sCarValue, sPw, CmdParam.CommMode.未知方式, pathAlarmList);
                return this.execToResponse(result);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->设置偏移路线报警", exception.Message);
                response.ErrorMsg = exception.Message;
                return response;
            }
        }

        public GpsResponse iSetRegionAlarm(int ParamType, string sCarValue, string sPw, ArrayList RegionList)
        {
            GpsResponse response = new GpsResponse(-1L);
            try
            {
                int num = 0;
                string str = "";
                int num2 = 0;
                string str2 = "";
                RegionAlarmList regionAlarmList = new RegionAlarmList();
                string[] strArray = RegionList[0] as string[];
                string[] strArray2 = RegionList[1] as string[];
                int iRegionFeature = 0;
                string str3 = MainForm.myCarList.execChangeCarValue(ParamType, 1, sCarValue);
                if (string.IsNullOrEmpty(str3))
                {
                    response.ErrorMsg = string.Format("目标车辆：{0}不存在", sCarValue);
                    Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                    return response;
                }
                DataTable table = RemotingClient.Car_GetRegionInfo(str3, iRegionFeature);
                for (int i = 0; i < strArray.Length; i++)
                {
                    int num5 = int.Parse(strArray2[i]);
                    if (num5 >= 0)
                    {
                        ArrayList list2 = new ArrayList();
                        RegionAlarm alarm = new RegionAlarm();
                        num2 = int.Parse(strArray[i]);
                        DataView view = new DataView(table, string.Format("RegionId='{0}'", num2), "", DataViewRowState.CurrentRows);
                        if (view.Count <= 0)
                        {
                            response.ErrorMsg = string.Format("下发区域不存在！", new object[0]);
                            Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                            return response;
                        }
                        str = view[0]["regionName"].ToString();
                        alarm.newRegionId = num2;
                        alarm.PathName = str;
                        alarm.RegionType = num5;
                        alarm.RegionID = num2;
                        str2 = view[0]["regionDot"].ToString();
                        alarm.AlarmRegionDot = num5 + @"\" + str2.Replace("*", @"\").Trim(new char[] { '\\' });
                        string[] strArray3 = str2.Split(new char[] { '*' });
                        num += strArray3.Length;
                        for (int j = 0; j < (strArray3.Length - 1); j++)
                        {
                            if (string.IsNullOrEmpty(strArray3[j]))
                            {
                                response.ErrorMsg = "解析区域失败！";
                                Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                                return response;
                            }
                            string[] strArray4 = strArray3[j].Split(new char[] { '\\' });
                            if (strArray4.Length < 2)
                            {
                                response.ErrorMsg = "解析区域失败！";
                                Record.execFileRecord("插件操作->设置区域报警", response.ErrorMsg);
                                return response;
                            }
                            Point point = new Point {
                                Longitude = double.Parse(strArray4[0]),
                                Latitude = double.Parse(strArray4[1])
                            };
                            list2.Add(point);
                            alarm.Points = list2;
                        }
                        regionAlarmList.Add(alarm);
                    }
                }
                regionAlarmList.RegionFeature = iRegionFeature;
                regionAlarmList.OrderCode = CmdParam.OrderCode.设置区域报警;
                Response result = RemotingClient.DownData_SetRegionAlarm_FJYD((CmdParam.ParamType) ParamType, sCarValue, sPw, CmdParam.CommMode.未知方式, regionAlarmList);
                return this.execToResponse(result);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("插件操作->设置区域报警", exception.Message);
                response.ErrorMsg = exception.Message;
                return response;
            }
        }

        public string MapSign
        {
            get
            {
                return MainForm.myMap.getMapView();
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get
            {
                return Variable.sPassword;
            }
        }

        public string SelectedMap
        {
            get
            {
                return MainForm.m_sSelectedMap;
            }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserId
        {
            get
            {
                return Variable.sUserId;
            }
        }
        /// <summary>
        /// 业务服务器地址
        /// </summary>
        public string ServerIp
        {
            get { return Variable.sServerIp; }
        }
        /// <summary>
        /// 业务服务器端口
        /// </summary>
        public string ServerPort
        {
            get { return Variable.sPort; }
        }
        /// <summary>
        /// 管理分析系统地址
        /// </summary>
        public string GpsIp
        {
            get { return Variable.sGpsIp; }
        }
        /// <summary>
        /// 管理分析系统端口
        /// </summary>
        public string GpsPort
        {
            get { return Variable.sGpsPort; }
        }
    }
}

