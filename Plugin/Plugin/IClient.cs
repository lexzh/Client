using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
namespace Client.Plugin
{
	public interface IClient
	{
		event SendObject OnSendObject;
        /// <summary>
        /// 管理分析系统地址
        /// </summary>
        string GpsIp
        {
            get;
        }
        /// <summary>
        /// 管理分析系统端口
        /// </summary>
        string GpsPort
        {
            get;
        }
        /// <summary>
        /// 业务服务器地址
        /// </summary>
        string ServerIp
        {
            get;
        }
        /// <summary>
        /// 业务服务器端口
        /// </summary>
        string ServerPort
        {
            get;
        }
        /// <summary>
        /// 登陆账号
        /// </summary>
		string UserId
		{
			get;
		}
        /// <summary>
        /// 登陆密码
        /// </summary>
		string Password
		{
			get;
		}
		string SelectedMap
		{
			get;
		}
		string MapSign
		{
			get;
		}
		DataTable iGetCarList();
        /// <summary>
        /// 获取当前选择车辆
        /// </summary>
        /// <returns></returns>
		IPluginParam.TCarInfo iGetCurrentCar();
		string iGetMapParam();
		DataTable iGetArea();
		string iGetDBCurrentDateTime();
        /// <summary>
        /// 执行数据库查询
        /// </summary>
        /// <param name="sSql">数据查询语句</param>
        /// <returns>查询结果</returns>
		DataTable iExecSql(string sSql);
        /// <summary>
        /// 设置菜单目录
        /// </summary>
        /// <param name="iMenuType">菜单类型-1</param>
        /// <param name="tsm">菜单名称</param>
		void iSetMenu(int iMenuType, ToolStripMenuItem tsm);
		GpsResponse iSetCarChecked(string sCarId, bool bAdd);
        /// <summary>
        /// 向车台终端发送文本消息
        /// </summary>
        /// <param name="ParamType"></param>
        /// <param name="sCarValue"></param>
        /// <param name="sPw"></param>
        /// <param name="iMessageType"></param>
        /// <param name="sMsgTxt"></param>
        /// <returns></returns>
		GpsResponse iSendTxtMess(int ParamType, string sCarValue, string sPw, int iMessageType, string sMsgTxt);
		GpsResponse iSetRegionAlarm(int ParamType, string sCarValue, string sPw, ArrayList RegionList);
		GpsResponse iSetPathAlarm(int ParamType, string sCarValue, string sPw, string[] PathList);
		GpsResponse iSetLastDotQuery(int ParamType, string CarValues, string CarPw);
	}
}
