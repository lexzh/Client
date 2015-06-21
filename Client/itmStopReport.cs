namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmStopReport : CarForm
    {

        public itmStopReport(CmdParam.OrderCode OrderCode)
        {
            this.m_SimpleCmd = new SimpleCmd();
            this.m_CaptureEx = new CaptureEx();
            this.m_TxtMsg = new TxtMsg();
            this.m_SimpleCmd_Listen = new SimpleCmd();
            this.m_AlarmInfo = new TrafficALarmHandle();
            this.m_cmd = new ArrayList();
            this._toPlatformContent = "";
            this.platalarmType = -1;
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        public itmStopReport(CmdParam.OrderCode OrderCode, int platalarmType)
        {
            this.m_SimpleCmd = new SimpleCmd();
            this.m_CaptureEx = new CaptureEx();
            this.m_TxtMsg = new TxtMsg();
            this.m_SimpleCmd_Listen = new SimpleCmd();
            this.m_AlarmInfo = new TrafficALarmHandle();
            this.m_cmd = new ArrayList();
            this._toPlatformContent = "";
            this.platalarmType = -1;
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.platalarmType = platalarmType;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                try
                {
                    if (this.getParam())
                    {
                        if (base.OrderCode == CmdParam.OrderCode.停止报警)
                        {
                            base.reResult = RemotingClient.StopAlarmDeal(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_AlarmInfo, (this.m_cmd.Count > 0) ? this.m_cmd[0] : null);
                        }
                        else
                        {
                            base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                        }
                        if (base.reResult.ResultCode != 0L)
                        {
                            MessageBox.Show(base.reResult.ErrorMsg);
                        }
                        else
                        {
                            if ((this._toPlatformContent.Length > 0) && (base.OrderCode == CmdParam.OrderCode.停止报警))
                            {
                                SimpleCmd cmdParameter = new SimpleCmd {
                                    OrderCode = CmdParam.OrderCode.主动上报报警处理结果信息
                                };
                                RemotingClient.Car_CommandParameterInsterToDB(base.ParamType, base.sValue, base.sPw, cmdParameter, this._toPlatformContent, "上传处理结果信息");
                                foreach (string str in base.sValue.Split(new char[] { ',' }))
                                {
                                    string sCarId = MainForm.myCarList.execChangeCarValue((int) base.ParamType, 1, str);
                                    ThreeStateTreeNode node = MainForm.myCarList.tvList.getNodeById(sCarId);
                                    if (node != null)
                                    {
                                        if (node.CarStatusValue.IndexOf("平台偏离路线") >= 0)
                                        {
                                            RemotingClient.ExecNoQuery(string.Format(" update GpsJtbCarPathAlarm_Platform set stopAlarmTime = dateadd(ss, " + Variable.sStopAlarmTime + ", getdate()) where CarID = '{0}' ", sCarId));
                                        }
                                        else if (node.CarStatusValue.IndexOf("平台区域") >= 0)
                                        {
                                            RemotingClient.ExecNoQuery(string.Format(" update GpsJtbCarRegionAlarm_Platform set stopAlarmTime = dateadd(ss, " + Variable.sStopAlarmTime + ", getdate()) where CarID = '{0}' ", sCarId));
                                        }
                                        else if (node.CarStatusValue.IndexOf("平台分路段限速") >= 0)
                                        {
                                            RemotingClient.ExecNoQuery(string.Format(" update GpsJtbCarPathSegmentAlarm_Platform set stopAlarmTime = dateadd(ss, " + Variable.sStopAlarmTime + ", getdate()) where CarID = '{0}' ", sCarId));
                                        }
                                    }
                                }
                            }
                            base.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("停止报警->确定", exception.Message);
                }
            }
        }

        private bool captureImage()
        {
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < this.pnlCamera.Controls.Count; i++)
            {
                if (this.pnlCamera.Controls[i] is CheckBox)
                {
                    CheckBox box = (CheckBox) this.pnlCamera.Controls[i];
                    if (box.Checked)
                    {
                        num |= ((int) 1) << num2;
                    }
                    num2++;
                }
            }
            if (num == 0)
            {
                MessageBox.Show("请选择摄像头！");
                this.chkCamera1.Focus();
                return false;
            }
            this.m_CaptureEx.OrderCode = CmdParam.OrderCode.实时图像监控;
            this.m_CaptureEx.CamerasID = (byte) num;
            this.m_CaptureEx.IsMultiFrame = 0;
            this.m_CaptureEx.CapWhenStop = 0;
            int num4 = 1;
            int num5 = 0;
            this.m_CaptureEx.Times = 1;
            this.m_CaptureEx.Interval = 600;
            this.m_CaptureEx.Quality = 3;
            this.m_CaptureEx.Brightness = 128;
            this.m_CaptureEx.Contrast = 71;
            this.m_CaptureEx.Saturation = 64;
            this.m_CaptureEx.Chroma = 128;
            this.m_CaptureEx.CaptureFlag = num4;
            this.m_CaptureEx.CaptureCache = num5;
            this.m_CaptureEx.protocolType = CarProtocolType.交通厅;
            this.m_CaptureEx.Type = 0;
            this.m_CaptureEx.PSize = 1;
            this.m_cmd.Add(this.m_CaptureEx);
            return true;
        }

        private bool carListen()
        {
            if (this.txtTel.Text.Trim().Length <= 0)
            {
                MessageBox.Show("电话号码不能为空！");
                return false;
            }
            this.m_SimpleCmd_Listen.ListenTel = this.txtTel.Text.Trim();
            this.m_SimpleCmd_Listen.OrderCode = CmdParam.OrderCode.设置被动监听;
            this.m_cmd.Add(this.m_SimpleCmd_Listen);
            return true;
        }

        private void cmbAlarmResolveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbAlarmResolveType.SelectedIndex == 0)
            {
                this.pnlCamera.Visible = this.pnlMsg.Visible = this.pnlListen.Visible = false;
                this.pnlStopAlarm.Visible = true;
            }
            else if ((this.cmbAlarmResolveType.SelectedIndex == 4) || (this.cmbAlarmResolveType.SelectedIndex == 5))
            {
                this.pnlCamera.Visible = this.pnlMsg.Visible = this.pnlListen.Visible = this.pnlStopAlarm.Visible = false;
            }
            else if (this.cmbAlarmResolveType.SelectedIndex == 1)
            {
                this.pnlCamera.Visible = this.pnlMsg.Visible = this.pnlStopAlarm.Visible = false;
                this.pnlListen.Visible = true;
            }
            else if (this.cmbAlarmResolveType.SelectedIndex == 2)
            {
                this.pnlListen.Visible = this.pnlMsg.Visible = this.pnlStopAlarm.Visible = false;
                this.pnlCamera.Visible = true;
            }
            else if (this.cmbAlarmResolveType.SelectedIndex == 3)
            {
                this.pnlListen.Visible = this.pnlCamera.Visible = this.pnlStopAlarm.Visible = false;
                this.pnlMsg.Visible = true;
            }
        }

 private bool getParam()
        {
            this.m_cmd.Clear();
            if (MainForm.myCarList.AlarmCarList != null)
            {
                DataRow row = MainForm.myCarList.AlarmCarList.Rows.Find(MainForm.myCarList.SelectedCarId.Split(new char[] { ',' })[0]);
                if (row != null)
                {
                    try
                    {
                        this.m_AlarmInfo.GpsTime = row["gpsTime"].ToString();
                        this.packageAlarmResult(Convert.ToDateTime(this.m_AlarmInfo.GpsTime), Convert.ToInt32((row["status"] == null) ? 0 : row["status"]), MainForm.myCarList.AlarmCarList.Columns.Contains("statusex") ? Convert.ToInt64((row["statusex"] == null) ? 0 : row["statusex"]) : 0L);
                    }
                    catch
                    {
                    }
                }
            }
            this.m_AlarmInfo.ProcMode = this.cmbAlarmResolveType.SelectedItem.ToString();
            this.m_AlarmInfo.Remark = this.txtRemark.Text;
            this.m_AlarmInfo.iProcMode = this.cmbAlarmResolveType.SelectedIndex + 1;
            if (this.cmbAlarmResolveType.SelectedIndex == 0)
            {
                this.m_SimpleCmd.OrderCode = base.OrderCode;
                this.m_SimpleCmd.ClearHistory = this.chkCoerceStop.Checked ? ((byte) 1) : ((byte) 0);
                this.m_cmd.Add(this.m_SimpleCmd);
            }
            else
            {
                if (this.cmbAlarmResolveType.SelectedIndex == 1)
                {
                    return this.carListen();
                }
                if (this.cmbAlarmResolveType.SelectedIndex == 2)
                {
                    return this.captureImage();
                }
                if (this.cmbAlarmResolveType.SelectedIndex == 3)
                {
                    return this.sendTextMsg();
                }
            }
            return true;
        }

        private void grpStopParam_SizeChanged(object sender, EventArgs e)
        {
            base.Height = ((this.grpStopParam.Height + base.grpCar.Height) + base.pnlBtn.Height) + 40;
        }

 private void initMsgType()
        {
            this.cmbMsgType.addItems("紧急消息", 641);
            this.cmbMsgType.addItems("详细调度信息", 3);
            this.cmbMsgType.addItems("固定信息点播", 1538);
            this.cmbMsgType.addItems("广告类信息", 16);
        }

        private void itmStopReport_Load(object sender, EventArgs e)
        {
            this.cmbAlarmResolveType.SelectedIndex = 0;
            if (base.OrderCode != CmdParam.OrderCode.停止报警)
            {
                foreach (Control control in this.grpStopParam.Controls)
                {
                    if (!control.Name.Equals("pnlStopAlarm", StringComparison.OrdinalIgnoreCase))
                    {
                        control.Visible = false;
                    }
                }
            }
            this.initMsgType();
        }

        private void packageAlarmResult(DateTime recetime, int statu, long statuex)
        {
            this._toPlatformContent = "";
            this._toPlatformContent = "02";
            this._toPlatformContent = this._toPlatformContent + Convert.ToString((long) recetime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds, 16).PadLeft(16, '0');
            string str = "";
            if (this.cmbAlarmResolveType.SelectedIndex == 0)
            {
                str = "01";
            }
            else if (this.cmbAlarmResolveType.SelectedIndex <= 3)
            {
                str = "00";
            }
            else if (this.cmbAlarmResolveType.SelectedIndex == 4)
            {
                str = "02";
            }
            else
            {
                str = "03";
            }
            this._toPlatformContent = this._toPlatformContent + str;
            this._toPlatformContent = this._toPlatformContent + Convert.ToString(statu, 16).PadLeft(8, '0');
            this._toPlatformContent = this._toPlatformContent + Convert.ToString(statuex, 16).PadLeft(16, '0');
        }

        private bool sendTextMsg()
        {
            if (this.txtMsgValue.Text.Trim().Length <= 0)
            {
                MessageBox.Show("发送内容不能为空！");
                this.txtMsgValue.Focus();
                return false;
            }
            this.m_TxtMsg.OrderCode = CmdParam.OrderCode.调度;
            this.m_TxtMsg.MsgType = (CmdParam.MsgType) int.Parse(this.cmbMsgType.SelectedValue.ToString());
            this.m_TxtMsg.strMsg = this.txtMsgValue.Text.Trim();
            this.m_cmd.Add(this.m_TxtMsg);
            return true;
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

