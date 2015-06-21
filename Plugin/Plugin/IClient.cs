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
        /// �������ϵͳ��ַ
        /// </summary>
        string GpsIp
        {
            get;
        }
        /// <summary>
        /// �������ϵͳ�˿�
        /// </summary>
        string GpsPort
        {
            get;
        }
        /// <summary>
        /// ҵ���������ַ
        /// </summary>
        string ServerIp
        {
            get;
        }
        /// <summary>
        /// ҵ��������˿�
        /// </summary>
        string ServerPort
        {
            get;
        }
        /// <summary>
        /// ��½�˺�
        /// </summary>
		string UserId
		{
			get;
		}
        /// <summary>
        /// ��½����
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
        /// ��ȡ��ǰѡ����
        /// </summary>
        /// <returns></returns>
		IPluginParam.TCarInfo iGetCurrentCar();
		string iGetMapParam();
		DataTable iGetArea();
		string iGetDBCurrentDateTime();
        /// <summary>
        /// ִ�����ݿ��ѯ
        /// </summary>
        /// <param name="sSql">���ݲ�ѯ���</param>
        /// <returns>��ѯ���</returns>
		DataTable iExecSql(string sSql);
        /// <summary>
        /// ���ò˵�Ŀ¼
        /// </summary>
        /// <param name="iMenuType">�˵�����-1</param>
        /// <param name="tsm">�˵�����</param>
		void iSetMenu(int iMenuType, ToolStripMenuItem tsm);
		GpsResponse iSetCarChecked(string sCarId, bool bAdd);
        /// <summary>
        /// ��̨�ն˷����ı���Ϣ
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
