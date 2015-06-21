namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmCarReport : CarForm
    {
        private CmdParam.CommMode m_CommondMode = CmdParam.CommMode.未知方式;
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmCarReport(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                this.getParam();
                if (base.OrderCode != CmdParam.OrderCode.设置重点监控)
                {
                    if (base.OrderCode == CmdParam.OrderCode.末次位置查询)
                    {
                        base.reResult = RemotingClient.DownData_SetLastDotQuery(base.ParamType, base.sValue, base.sPw, this.m_CommondMode, base.OrderCode);
                    }
                    else if (base.OrderCode == CmdParam.OrderCode.远程升级车台软件)
                    {
                        base.reResult = RemotingClient.DownData_RemoteUpdate(base.ParamType, base.sValue, base.sPw, this.m_CommondMode);
                    }
                    else if (base.OrderCode == CmdParam.OrderCode.实时点名查询)
                    {
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
                        base.reResult = RemotingClient.DownData_SetPosReport(CmdParam.ParamType.CarNum, base.sCarNum, "", CmdParam.CommMode.未知方式, posReport);
                        if (base.reResult.ResultCode == 0L)
                        {
                            foreach (string str2 in base.sCarId.Split(new char[] { ',' }))
                            {
                                if (MainForm.htBatchName == null)
                                {
                                    MainForm.htBatchName = new Hashtable();
                                }
                                if (!MainForm.htBatchName.ContainsKey(str2))
                                {
                                    MainForm.htBatchName.Add(str2, null);
                                }
                            }
                        }
                    }
                    else if (base.OrderCode == CmdParam.OrderCode.取消定时抓拍图像监控)
                    {
                        string sCarSimNum = base.sCarSimNum;
                        if (base.sCarSimNum.IndexOf(',') > 0)
                        {
                            sCarSimNum = sCarSimNum.Replace(",", "','");
                        }
                        sCarSimNum = "'" + sCarSimNum + "'";
                        string sql = "delete from GpsCarPicParam where SimNum in (" + sCarSimNum + ")";
                        base.reResult = RemotingClient.ExecNoQuery(sql);
                        string sOrderResult = "成功";
                        if (base.reResult.ResultCode != 0L)
                        {
                            sOrderResult = "失败";
                        }
                        string dBCurrentDateTime = RemotingClient.GetDBCurrentDateTime();
                        if (string.IsNullOrEmpty(dBCurrentDateTime))
                        {
                            dBCurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        string sOrderId = "0";
                        string sOrderType = "发送";
                        string sOrderName = base.OrderCode.ToString();
                        string sMsg = "";
                        MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(dBCurrentDateTime, base.sCarNum, sOrderId, sOrderType, sOrderName, sOrderResult, sMsg);
                    }
                    else
                    {
                        base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, this.m_CommondMode, this.m_SimpleCmd);
                    }
                }
                else
                {
                    string[] strArray = base.sCarNum.Split(new char[] { ',' });
                    if (strArray.Length > int.Parse(Variable.sImportCarMax))
                    {
                        MessageBox.Show(string.Format("监控车辆车辆不能超过{0}辆", Variable.sImportCarMax));
                    }
                    foreach (string str in strArray)
                    {
                        if (MainForm.myCarList.setCarChecked(str, true) != 0)
                        {
                            MessageBox.Show("更新重点监控参数失败");
                            return;
                        }
                    }
                    int num2 = RemotingClient.Car_UpdateImportWatch(base.sCarSimNum, 1);
                    base.reResult = new Response();
                    if (num2 < 0)
                    {
                        MessageBox.Show("更新重点监控参数失败");
                    }
                    base.reResult.ResultCode = 0L;
                }
            }
            if ((base.reResult != null) && (base.reResult.ResultCode != 0L))
            {
                MessageBox.Show(base.reResult.ErrorMsg);
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

 private void getParam()
        {
            if (base.OrderCode == CmdParam.OrderCode.短信强制复位)
            {
                this.m_CommondMode = CmdParam.CommMode.短信;
            }
            CmdParam.OrderCode orderCode = base.OrderCode;
            this.m_SimpleCmd.OrderCode = base.OrderCode;
        }


    }
}