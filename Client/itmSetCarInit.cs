namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CarEntity;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmSetCarInit : FixedForm
    {
        private DataTable dtCarConfig = new DataTable();
        private static CommonCar m_CommonCar = new CommonCar();
        private DataTable m_dtGpsCarDeviceShareRef = new DataTable();
        private static int m_iPhoneMaxCnt = 200;
        private string sCarId = "";
        private string sCarNum = "";
        private string sCarSimNum = "";

        public itmSetCarInit(string sTitle)
        {
            this.InitializeComponent();
        }

        private void ApnModeSelected()
        {
            string text = this.cmbApnType.Text;
            if ("CMNET".Equals(text, StringComparison.OrdinalIgnoreCase))
            {
                this.chkSurrogate.Checked = false;
                this.txtSurrogateIp.Text = "";
                this.txtSurrogatePort.Text = "";
                this.txtUser.Text = "cmnet";
                this.txtPassword.Text = "cmnet";
                this.txtUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.txtSurrogateIp.Enabled = false;
                this.txtSurrogatePort.Enabled = false;
                this.chkSurrogate.Enabled = false;
            }
            else if ("CMWAP".Equals(text, StringComparison.OrdinalIgnoreCase))
            {
                this.chkSurrogate.Checked = true;
                this.txtSurrogateIp.Text = CmdParam.CON_CMWAP_IP;
                this.txtSurrogatePort.Text = CmdParam.CON_CMWAP_PORT;
                this.txtUser.Text = "cmwap";
                this.txtPassword.Text = "cmwap";
                this.txtUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.txtSurrogateIp.Enabled = false;
                this.txtSurrogatePort.Enabled = false;
                this.chkSurrogate.Enabled = false;
            }
            else if ("CARD".Equals(text, StringComparison.OrdinalIgnoreCase))
            {
                this.chkSurrogate.Checked = false;
                this.txtSurrogateIp.Text = "";
                this.txtSurrogatePort.Text = "";
                this.txtUser.Text = "CARD";
                this.txtPassword.Text = "CARD";
                this.txtUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.txtSurrogateIp.Enabled = false;
                this.txtSurrogatePort.Enabled = false;
                this.chkSurrogate.Enabled = false;
            }
            else
            {
                this.chkSurrogate.Checked = false;
                this.txtSurrogateIp.Text = "";
                this.txtSurrogatePort.Text = "";
                this.txtUser.Text = "";
                this.txtPassword.Text = "";
                this.txtUser.Enabled = true;
                this.txtPassword.Enabled = true;
                this.txtSurrogateIp.Enabled = true;
                this.txtSurrogatePort.Enabled = true;
                this.chkSurrogate.Enabled = true;
            }
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            try
            {
                CallLimit callLimit = new CallLimit();
                callLimit = this.GetCallLimit();
                if (callLimit != null)
                {
                    this.reResult = RemotingClient.DownData_SetCallLimit(CmdParam.ParamType.CarId, this.sCarId, "", CmdParam.CommMode.未知方式, callLimit);
                    if (this.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(this.reResult.ErrorMsg);
                    }
                    else
                    {
                        this.execSaveCmnParam(this.tpCallParam);
                        this.showSucceedMsg();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            try
            {
                AlarmEntity customArgs = this.GetCustomArgs();
                if (customArgs != null)
                {
                    this.reResult = RemotingClient.DownData_SetCustomAlarmer(CmdParam.ParamType.CarId, this.sCarId, "", CmdParam.CommMode.未知方式, customArgs);
                    if (this.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(this.reResult.ErrorMsg);
                    }
                    else
                    {
                        this.execSaveCmnParam(this.tpCustom);
                        this.showSucceedMsg();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            this.pnlExpandAlarm.Visible = !this.pnlExpandAlarm.Visible;
        }

        private void btnSendAnnunciator_Click(object sender, EventArgs e)
        {
            try
            {
                long num;
                long num2;
                long num3;
                long num4;
                long num5;
                long num6;
                AlarmEntity arlamArgs = null;
                this.SetAlarmValue(out num, out num2, out num3, this.pnlAlarm);
                this.SetAlarmValue(out num4, out num5, out num6, this.pnlExpandAlarm);
                arlamArgs = this.GetAlarmArgs(num, num2, num3, num5, num4, num6);
                if (arlamArgs != null)
                {
                    this.reResult = RemotingClient.DownData_SetAlarmFlag(CmdParam.ParamType.CarId, this.sCarId, "", CmdParam.CommMode.未知方式, arlamArgs);
                    if (this.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(this.reResult.ErrorMsg);
                    }
                    else
                    {
                        this.execSaveCmnParam(this.tpAnnunciator);
                        this.showSucceedMsg();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnSendCommunication_Click(object sender, EventArgs e)
        {
            try
            {
                CommArgs commArgs = new CommArgs();
                commArgs = this.GetCommArgs();
                if (commArgs != null)
                {
                    this.reResult = RemotingClient.DownData_SetCommArg(CmdParam.ParamType.CarId, this.sCarId, "", CmdParam.CommMode.未知方式, commArgs);
                    if (this.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(this.reResult.ErrorMsg);
                    }
                    else
                    {
                        this.execSaveCmnParam(this.tpCommunication);
                        this.showSucceedMsg();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnSendOther_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleCmd dutyEntity = this.GetDutyEntity();
                if (dutyEntity != null)
                {
                    this.reResult = RemotingClient.DownData_SimpleCmd(CmdParam.ParamType.CarId, this.sCarId, "", CmdParam.CommMode.未知方式, dutyEntity);
                    if (this.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(this.reResult.ErrorMsg);
                    }
                    else
                    {
                        this.execSaveCmnParam(this.grpOther);
                        this.showSucceedMsg();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnSendReport_Click(object sender, EventArgs e)
        {
            try
            {
                MinSMSReportInterval minSmsReport = this.GetminSmsReport();
                if (minSmsReport != null)
                {
                    this.reResult = RemotingClient.DownData_SetMinSMSReportInterval(CmdParam.ParamType.CarId, this.sCarId, "", CmdParam.CommMode.未知方式, minSmsReport);
                    if (this.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(this.reResult.ErrorMsg);
                    }
                    else
                    {
                        this.execSaveCmnParam(this.grpMixInterval);
                        string sParam = this.getSetParam(this.grpMixInterval);
                        RemotingClient.Car_SaveFormSetParam(this.reResult.OrderIDParam, 38.ToString(), sParam);
                        this.showSucceedMsg();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void chkAllAlarm_CheckedChanged(object sender, EventArgs e)
        {
            int pAlarmType = 0;
            if (this.chkAllAlarm.Checked)
            {
                this.SetAlarmShow(pAlarmType);
                this.chkAllClose.Checked = false;
            }
        }

        private void chkAllClose_CheckedChanged(object sender, EventArgs e)
        {
            int pAlarmType = 3;
            if (this.chkAllClose.Checked)
            {
                this.SetAlarmShow(pAlarmType);
                this.chkAllAlarm.Checked = false;
            }
        }

        private void cmbApnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ApnModeSelected();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void cmbApnType_TextChanged(object sender, EventArgs e)
        {
            this.cmbApnType_SelectedIndexChanged(sender, e);
        }

        private void execSaveCmnParam(Control ctrl)
        {
            string sCmdContent = this.getCmnParam(ctrl);
            RemotingClient.Car_SaveFormCmdParam(this.reResult.OrderIDParam, ctrl.Text, sCmdContent);
        }

        private AlarmEntity GetAlarmArgs(long car_AlarmSwitch, long car_AlarmFlag, long car_ShowAlarm, long car_ExpandAlarmFlag, long car_ExpandAlarmSwitch, long car_ExpandShowAlarm)
        {
                AlarmEntity entity = new AlarmEntity {
                OrderCode = CmdParam.OrderCode.设置车台报警器,
                CarAlarmFlag = car_AlarmFlag,
                CarAlarmSwitch = car_AlarmSwitch,
                CarShowAlarm = car_ShowAlarm,
                AlarmFlagEx = car_ExpandAlarmFlag,
                CarAlarmSwitchEx = car_ExpandAlarmSwitch,
                CarShowAlarmEx = car_ExpandShowAlarm
            };
            if (this.cmbAlarmType.SelectedIndex == 0)
            {
                entity.AlarmFlagType = CmdParam.CarAlarmTypeTag.配置报警标志位;
                return entity;
            }
            if (this.cmbAlarmType.SelectedIndex == 1)
            {
                entity.AlarmFlagType = CmdParam.CarAlarmTypeTag.配置终端文本SMS报警通知开关;
                return entity;
            }
            if (this.cmbAlarmType.SelectedIndex == 2)
            {
                entity.AlarmFlagType = CmdParam.CarAlarmTypeTag.配置报警拍摄开关;
                return entity;
            }
            if (this.cmbAlarmType.SelectedIndex == 3)
            {
                entity.AlarmFlagType = CmdParam.CarAlarmTypeTag.配置报警拍摄存储标志;
                return entity;
            }
            if (this.cmbAlarmType.SelectedIndex == 4)
            {
                entity.AlarmFlagType = CmdParam.CarAlarmTypeTag.配置关键报警标志;
            }
            return entity;
        }

        private CallLimit GetCallLimit()
        {
            CallLimit limit = new CallLimit();
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            if (this.rdoCallInOpen.Checked)
            {
                list.Add(1);
                list2.Add(1);
            }
            else if (this.rdoCallInLimit.Checked)
            {
                list2.Add(1);
            }
            if (this.rdoCallOutOpen.Checked)
            {
                list.Add(2);
                list2.Add(2);
            }
            else if (this.rdoCallOutLimit.Checked)
            {
                list2.Add(2);
            }
            if (this.rdoRushOpen.Checked)
            {
                list.Add(4);
                list2.Add(4);
            }
            else if (this.rdoRushClose.Checked)
            {
                list2.Add(4);
            }
            limit.FlagValueList = list;
            limit.FlagMaskList = list2;
            if (this.txtCallIn.Lines.Length > m_iPhoneMaxCnt)
            {
                MessageBox.Show(string.Format("限制呼入电话号码列表的个数大于{0}个", m_iPhoneMaxCnt.ToString()));
                this.txtCallIn.Focus();
                return null;
            }
            if (this.txtCallOut.Lines.Length > m_iPhoneMaxCnt)
            {
                MessageBox.Show(string.Format("限制呼出电话号码列表的个数大于{0}个", m_iPhoneMaxCnt.ToString()));
                this.txtCallOut.Focus();
                return null;
            }
            foreach (string str in this.txtCallIn.Lines)
            {
                if ((str.Length <= 0) || (str.Length > 15))
                {
                    MessageBox.Show("允许呼入列表中，电话号码的长度大于15，或者等于0");
                    this.txtCallIn.Focus();
                    return null;
                }
                limit.CallInList.Add(str);
            }
            foreach (string str2 in this.txtCallOut.Lines)
            {
                if ((str2.Length <= 0) || (str2.Length > 15))
                {
                    MessageBox.Show("允许呼出列表中，电话号码的长度大于15，或者等于0");
                    this.txtCallOut.Focus();
                    return null;
                }
                limit.CallOutList.Add(str2);
            }
            limit.OrderCode = CmdParam.OrderCode.设置车台呼叫限制;
            return limit;
        }

        private string getChkText(bool isChecked)
        {
            return PublicClass.Check.getChkText(isChecked);
        }

        private string getCmnParam(Control ctrl)
        {
            string str = "";
            foreach (Control control in ctrl.Controls)
            {
                if (!control.Visible || ((control.Tag != null) && control.Tag.ToString().Equals("9999")))
                {
                    continue;
                }
                switch (control.GetType().Name)
                {
                    case "IPAddressTextBox":
                    case "TextBox":
                    {
                        if ((control.Tag.ToString()).Length >= 2)   ///ToString
                        {
                            break;
                        }
                        str = string.Format("{0}", control.Text) + control.Tag + str;
                        continue;
                    }
                    case "ComboBox":
                    case "ComBox":
                    {
                        if (control.Name.EndsWith("Alarm"))
                        {
                            goto Label_0196;
                        }
                        str = control.Text + "；" + str;
                        continue;
                    }
                    case "Label":
                    {
                        str = control.Text + control.Tag + str;
                        continue;
                    }
                    case "NumericUpDown":
                    {
                        str = ((NumericUpDown) control).Value.ToString() + control.Tag + str;
                        continue;
                    }
                    case "CheckBox":
                    {
                        if (!(control.Text == "设置代理服务器"))
                        {
                            goto Label_023A;
                        }
                        if (!((CheckBox) control).Checked)
                        {
                            str = "";
                        }
                        str = string.Format("{0}：{1}；", control.Text, this.getChkText(((CheckBox) control).Checked)) + str;
                        continue;
                    }
                    case "RadioButton":
                    {
                        if (((RadioButton) control).Checked)
                        {
                            str = string.Format("{0}：{1}；", control.Parent.Text, control.Text) + str;
                        }
                        continue;
                    }
                    default:
                        goto Label_028F;
                }
                str = string.Format("{0}", control.Text) + str;
                continue;
            Label_0196:
                str = control.Text + "-" + str;
                continue;
            Label_023A:
                str = string.Format("{0}；", this.getChkText(((CheckBox) control).Checked)) + str;
                continue;
            Label_028F:
                str = this.getCmnParam(control) + str;
            }
            return str;
        }

        private CommArgs GetCommArgs()
        {
            CommArgs args = new CommArgs {
                OrderCode = CmdParam.OrderCode.设置GPRS参数,
                ServerType = (this.cmbServerList.SelectedIndex == 0) ? 0 : 1
            };
            string s = "0";
            if (this.rdoGprsCdma.Checked)
            {
                s = "1";
            }
            else if (this.rdoMessage.Checked)
            {
                s = "0";
            }
            else
            {
                s = "2";
            }
            int num = int.Parse(s);
            args.CommMode = (CmdParam.CommMode) num;
            if (args.CommMode == CmdParam.CommMode.短信)
            {
                args.IsUseProxy = CmdParam.IsUseProxy.不使用代理;
                args.ProxyPort = 0;
                args.strAPNAddr = "";
                args.strPassword = "";
                args.strProxyIP = "";
                args.strTCPIP = "";
                args.strUDPIP = "";
                args.strUser = "";
                args.TCPPort = 0;
                args.UDPPort = 0;
                return args;
            }
            string text = this.cmbApnType.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("请选择接入方式！");
                this.cmbApnType.Focus();
                return null;
            }
            args.strAPNAddr = text;
            string str3 = this.txtTcpIp.Text;
            string str4 = this.txtUdpIp.Text;
            if (string.IsNullOrEmpty(str3) && string.IsNullOrEmpty(str4))
            {
                MessageBox.Show("请选择TCP/UDP地址！");
                this.txtTcpIp.Focus();
                return null;
            }
            if (!string.IsNullOrEmpty(str3))
            {
                if (!PublicClass.Check.CheckIpAddress(str3))
                {
                    MessageBox.Show("TCPIP地址格式有误！");
                    this.txtTcpIp.Focus();
                    return null;
                }
                args.strTCPIP = str3;
                string str5 = this.txtTcpPort.Text;
                if (!string.IsNullOrEmpty(str5))
                {
                    try
                    {
                        args.TCPPort = int.Parse(str5);
                    }
                    catch
                    {
                    }
                }
            }
            if (!string.IsNullOrEmpty(str4))
            {
                if (!PublicClass.Check.CheckIpAddress(str4))
                {
                    MessageBox.Show("UDPIP地址格式有误！");
                    this.txtUdpIp.Focus();
                    return null;
                }
                args.strUDPIP = str4;
                string str6 = this.txtUdpPort.Text;
                if (!string.IsNullOrEmpty(str6))
                {
                    try
                    {
                        args.UDPPort = int.Parse(str6);
                    }
                    catch
                    {
                    }
                }
            }
            if (this.txtUser.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入拨号用户名！");
                this.txtUser.Focus();
                return null;
            }
            if (this.txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入拨号密码！");
                this.txtPassword.Focus();
                return null;
            }
            args.strUser = this.txtUser.Text.Trim();
            args.strPassword = this.txtPassword.Text.Trim();
            if (this.chkSurrogate.Checked)
            {
                args.IsUseProxy = CmdParam.IsUseProxy.使用代理;
                string strIpAddress = this.txtSurrogateIp.Text;
                if (!PublicClass.Check.CheckIpAddress(strIpAddress))
                {
                    MessageBox.Show("代理服务器IP地址格式有误！");
                    this.txtSurrogateIp.Focus();
                    return null;
                }
                args.strProxyIP = strIpAddress;
                string str8 = this.txtSurrogatePort.Text;
                if (!string.IsNullOrEmpty(str8))
                {
                    try
                    {
                        int result = 0;
                        if (!int.TryParse(str8, out result))
                        {
                            MessageBox.Show("代理服务器端口有误！");
                            this.txtSurrogatePort.Focus();
                            return null;
                        }
                        args.ProxyPort = result;
                        return args;
                    }
                    catch
                    {
                        return args;
                    }
                }
                MessageBox.Show("代理服务器端口有误！");
                this.txtSurrogatePort.Focus();
                return null;
            }
            args.IsUseProxy = CmdParam.IsUseProxy.不使用代理;
            return args;
        }

        private AlarmEntity GetCustomArgs()
        {
            AlarmEntity entity = new AlarmEntity();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            string str = string.Empty;
            int num5 = 6;
            int num6 = 0;
            string str2 = "cmbCustom";
            ComBox box = null;
            ComBox box2 = null;
            TextBox box3 = null;
            for (int i = 1; i <= num5; i++)
            {
                try
                {
                    box = (ComBox) this.grpCustom.Controls[str2 + i.ToString() + "Alarm"];
                    box2 = (ComBox) this.grpCustom.Controls[str2 + i.ToString() + "Elec"];
                    box3 = (TextBox) this.grpCustom.Controls["txtCustom" + i.ToString() + "Name"];
                    if (((box == null) || (box2 == null)) || (box3 == null))
                    {
                        continue;
                    }
                    num6 = Convert.ToInt32(box.Tag.ToString());
                    switch (box.SelectedIndex)
                    {
                        case 0:
                            num |= num6;
                            num2 |= num6;
                            break;

                        case 1:
                            num |= num6;
                            break;

                        case 2:
                            num |= num6;
                            num3 |= num6;
                            break;
                    }
                    if (box2.SelectedIndex == 0)
                    {
                        num4 |= num6;
                    }
                    string text = box3.Text;
                    if (string.IsNullOrEmpty(text))
                    {
                        MessageBox.Show("请自定义名称");
                        box3.Focus();
                        return null;
                    }
                    str = str + string.Format("{0}/{1}*", num6, text.Trim());
                }
                catch
                {
                }
            }
            entity.CarAlarmFlag = num2;
            entity.CarAlarmSwitch = num;
            entity.CarShowAlarm = num3;
            entity.Level = num4;
            entity.CustName = str;
            entity.OrderCode = CmdParam.OrderCode.设置自定义报警器;
            return entity;
        }

        public SimpleCmd GetDutyEntity()
        {
            SimpleCmd cmd = new SimpleCmd();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (this.chkOnDuty.Checked)
            {
                num = 1;
            }
            if (this.chkStopGSM.Checked)
            {
                num2 = 16384;
            }
            if (this.chkStopDataCall.Checked)
            {
                num3 = 16384;
            }
            cmd.OrderCode = CmdParam.OrderCode.设置车台参数;
            cmd.OnDuty = num;
            cmd.CloseGSM = num2;
            cmd.CloseDail = num3;
            return cmd;
        }

        public MinSMSReportInterval GetminSmsReport()
        {
            MinSMSReportInterval interval = new MinSMSReportInterval {
                OrderCode = CmdParam.OrderCode.终端最小汇报间隔
            };
            try
            {
                interval.SMSMode = Convert.ToInt32(this.numMsg.Value);
                interval.MixedMode = Convert.ToInt32(this.numMix.Value);
            }
            catch
            {
            }
            return interval;
        }

        private string getSetParam(Control ctrl)
        {
            string str = "";
            foreach (Control control in ctrl.Controls)
            {
                if (control.Visible && control.Enabled)
                {
                    switch (control.GetType().Name)
                    {
                        case "TextBox":
                        {
                            str = str + string.Format("{0}={1}|;", control.Name, control.Text);
                            continue;
                        }
                        case "ComboBox":
                        case "ComBox":
                        {
                            str = str + string.Format("{0}={1}|;", control.Name, ((ComboBox) control).SelectedIndex);
                            continue;
                        }
                        case "DateTimePicker":
                        {
                            str = str + string.Format("{0}={1}|;", control.Name, ((DateTimePicker) control).Value);
                            continue;
                        }
                        case "NumericUpDown":
                        {
                            str = str + string.Format("{0}={1}|;", control.Name, ((NumericUpDown) control).Value);
                            continue;
                        }
                        case "TrackBar":
                        {
                            str = str + string.Format("{0}={1}|;", control.Name, ((TrackBar) control).Value);
                            continue;
                        }
                        case "CheckBox":
                        {
                            str = str + string.Format("{0}={1}|;", control.Name, ((CheckBox) control).Checked);
                            continue;
                        }
                        case "RadioButton":
                        {
                            str = str + string.Format("{0}={1}|;", control.Name, ((RadioButton) control).Checked);
                            continue;
                        }
                    }
                    if (!(control.Name == "grpCar"))
                    {
                        str = str + this.getSetParam(control);
                    }
                }
            }
            return str;
        }

        private void InitAlarmControl(long carSwitch, long carFlag, long carShowAlarm, Panel p)
        {
            long num = 0L;
            foreach (Control control in p.Controls)
            {
                try
                {
                    if ((control != null) && (control.Tag != null))
                    {
                        ComBox box = (ComBox) control;
                        if (box != null)
                        {
                            box.addItems("报警", "0");
                            box.addItems("警告", "1");
                            box.addItems("报告", "2");
                            box.addItems("关闭", "3");
                            num = Convert.ToInt64(control.Tag);
                            if ((carSwitch & num) != 0L)
                            {
                                if ((carFlag & num) != 0L)
                                {
                                    box.SelectedIndex = 0;
                                }
                                else if ((carShowAlarm & num) != 0L)
                                {
                                    box.SelectedIndex = 2;
                                }
                                else
                                {
                                    box.SelectedIndex = 1;
                                }
                            }
                            else
                            {
                                box.SelectedIndex = 3;
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void InitAlarmFlag(long carSwitch, long carFlag, long carShowAlarm, Panel p)
        {
            this.InitAlarmControl(carSwitch, carFlag, carShowAlarm, p);
        }

        private void InitCallLimit(CommonCar Car)
        {
            if (Car != null)
            {
                int num = 0;
                int num2 = 0;
                try
                {
                    if (Car.carControlType.Trim().Length > 0)
                    {
                        num = int.Parse(Car.carControlType.Trim());
                    }
                    if (Car.carControlMask.Trim().Length > 0)
                    {
                        num2 = int.Parse(Car.carControlMask.Trim());
                    }
                }
                catch
                {
                    return;
                }
                if ((num & 1) != 0)
                {
                    this.rdoCallInOpen.Checked = true;
                }
                else if ((num2 & 1) != 0)
                {
                    this.rdoCallInLimit.Checked = true;
                    if (Car.callInList != null)
                    {
                        this.txtCallIn.Text = Car.callInList.Replace("/", "\r\n");
                    }
                }
                else
                {
                    this.rdoCallIn.Checked = true;
                }
                if ((num & 2) != 0)
                {
                    this.rdoCallOutOpen.Checked = true;
                }
                else if ((num2 & 2) != 0)
                {
                    this.rdoCallOutLimit.Checked = true;
                    if (Car.callOutList != null)
                    {
                        this.txtCallOut.Text = Car.callOutList.Replace("/", "\r\n");
                    }
                }
                else
                {
                    this.rdoCallIn.Checked = true;
                }
                if ((num & 4) != 0)
                {
                    this.rdoRushOpen.Checked = true;
                }
                else if ((num2 & 4) != 0)
                {
                    this.rdoRushClose.Checked = true;
                }
                else
                {
                    this.rdoRush.Checked = true;
                }
            }
        }

        private void InitCommArg(CommonCar Car)
        {
            this.cmbServerList.addItems("主服务器", "0");
            this.cmbServerList.addItems("备份服务器", "1");
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("Display");
            DataColumn column2 = new DataColumn("Value");
            table.Columns.AddRange(new DataColumn[] { column, column2 });
            DataRow row = table.NewRow();
            row[0] = "CMNET";
            row[1] = "CMNET";
            DataRow row2 = table.NewRow();
            row2[0] = "CMWAP";
            row2[1] = "CMWAP";
            DataRow row3 = table.NewRow();
            row3[0] = "CARD";
            row3[1] = "CARD";
            table.Rows.Add(row);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            this.cmbApnType.DataSource = table;
            if (Car == null)
            {
                this.cmbApnType_SelectedIndexChanged(new object(), new EventArgs());
            }
            else
            {
                if (Car.carCommunicationType == "1")
                {
                    this.rdoGprsCdma.Checked = true;
                }
                else if (Car.carCommunicationType == "2")
                {
                    this.rdoMessage.Checked = true;
                }
                else
                {
                    this.rdoMix.Checked = true;
                }
                if (Car.APNAddr != null)
                {
                    this.cmbApnType.Text = Car.APNAddr;
                }
                this.txtUser.Text = Car.GPRSUser;
                this.txtPassword.Text = Car.GPRSPassword;
                this.txtTcpIp.Text = Car.TcpIP;
                this.txtTcpPort.Text = Car.TcpPort;
                this.txtUdpIp.Text = Car.UdpIP;
                this.txtUdpPort.Text = Car.UdpPort;
                this.chkSurrogate.Checked = Car.isUseProxy;
                this.txtSurrogateIp.Text = Car.AgentIP;
                this.txtSurrogatePort.Text = Car.AgentPort;
                if (Car.ServerType == 0)
                {
                    this.cmbServerList.SelectedIndex = 0;
                }
                else
                {
                    this.cmbServerList.SelectedIndex = 1;
                }
            }
        }

        private void InitCustomAlarm(CommonCar car)
        {
            string strCustName = "";
            int iCarAlarmSwitch = 0;
            int iCarAlarmFlag = 0;
            int iShowAlarm = 0;
            int iCustLevel = 0;
            try
            {
                string pStrNum = car.cust_CarAlarmSwitch;
                string str2 = car.cust_CarAlarmFlag;
                string str3 = car.cust_ShowAlarm;
                string str4 = car.cust_level;
                strCustName = car.cust_Name;
                if (PublicClass.Check.isNumeric(pStrNum, PublicClass.Check.NumType.sInt))
                {
                    iCarAlarmSwitch = int.Parse(pStrNum);
                }
                if (PublicClass.Check.isNumeric(str2, PublicClass.Check.NumType.sInt))
                {
                    iCarAlarmFlag = int.Parse(str2);
                }
                if (PublicClass.Check.isNumeric(str3, PublicClass.Check.NumType.sInt))
                {
                    iShowAlarm = int.Parse(str3);
                }
                if (PublicClass.Check.isNumeric(str4, PublicClass.Check.NumType.sInt))
                {
                    iCustLevel = int.Parse(str4);
                }
            }
            catch
            {
            }
            this.SetChooseCustomAlarmIndex(iCarAlarmSwitch, iCarAlarmFlag, iShowAlarm, iCustLevel, strCustName);
        }

        private void initForm(DataTable dtCarConfig)
        {
            this.InitCommArg(m_CommonCar);
            this.InitCallLimit(m_CommonCar);
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            try
            {
                if (!string.IsNullOrEmpty(m_CommonCar.CarAlarmSwitch))
                {
                    num = int.Parse(m_CommonCar.CarAlarmSwitch);
                }
                if (!string.IsNullOrEmpty(m_CommonCar.CarAlarmFlag))
                {
                    num2 = int.Parse(m_CommonCar.CarAlarmFlag);
                }
                if (!string.IsNullOrEmpty(m_CommonCar.ShowAlarm))
                {
                    num3 = int.Parse(m_CommonCar.ShowAlarm);
                }
            }
            catch
            {
            }
            long carSwitch = 0L;
            long carFlag = 0L;
            long carShowAlarm = 0L;
            try
            {
                if (!string.IsNullOrEmpty(m_CommonCar.CarAlarmSwitchEx))
                {
                    carSwitch = Convert.ToInt64(m_CommonCar.CarAlarmSwitchEx);
                }
                if (!string.IsNullOrEmpty(m_CommonCar.CarAlarmFlagEx))
                {
                    carFlag = Convert.ToInt64(m_CommonCar.CarAlarmFlagEx);
                }
                if (!string.IsNullOrEmpty(m_CommonCar.ShowAlarmEx))
                {
                    carShowAlarm = Convert.ToInt64(m_CommonCar.ShowAlarmEx);
                }
                if (m_CommonCar.AlarmFlagType == 259)
                {
                    this.cmbAlarmType.SelectedIndex = 0;
                }
                else if (m_CommonCar.AlarmFlagType == 16392)
                {
                    this.cmbAlarmType.SelectedIndex = 1;
                }
                else if (m_CommonCar.AlarmFlagType == 16393)
                {
                    this.cmbAlarmType.SelectedIndex = 2;
                }
                else if (m_CommonCar.AlarmFlagType == 16394)
                {
                    this.cmbAlarmType.SelectedIndex = 3;
                }
                else if (m_CommonCar.AlarmFlagType == 16395)
                {
                    this.cmbAlarmType.SelectedIndex = 4;
                }
            }
            catch
            {
            }
            this.InitAlarmFlag((long) num, (long) num2, (long) num3, this.pnlAlarm);
            this.InitAlarmFlag(carSwitch, carFlag, carShowAlarm, this.pnlExpandAlarm);
            this.InitCustomAlarm(m_CommonCar);
            this.InitOther(dtCarConfig);
        }

 private void InitOther(DataTable dtCarConfig)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if ((dtCarConfig != null) && (dtCarConfig.Rows.Count > 0))
            {
                try
                {
                    num = int.Parse(dtCarConfig.Rows[0]["isOnDuty"].ToString());
                    num2 = int.Parse(dtCarConfig.Rows[0]["isCloseGsm"].ToString());
                    num3 = int.Parse(dtCarConfig.Rows[0]["isCloseDial"].ToString());
                }
                catch
                {
                }
                if (num == 1)
                {
                    this.chkOnDuty.Checked = true;
                }
                else
                {
                    this.chkOnDuty.Checked = false;
                }
                if (num2 == 16384)
                {
                    this.chkStopGSM.Checked = true;
                }
                else
                {
                    this.chkStopGSM.Checked = false;
                }
                if (num3 == 16384)
                {
                    this.chkStopDataCall.Checked = true;
                }
                else
                {
                    this.chkStopDataCall.Checked = false;
                }
            }
        }

        private void itmSetCarInit_Load(object sender, EventArgs e)
        {
            this.sCarNum = MainForm.myCarList.SelectedCarNum;
            this.sCarId = MainForm.myCarList.SelectedCarId;
            this.sCarSimNum = MainForm.myCarList.SelectedSimNum;
            this.cmbAlarmType.SelectedIndex = 0;
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            catch
            {
                this.initForm(this.dtCarConfig);
            }
            this.setParam();
        }

        private void rdoCallInLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoCallInLimit.Checked)
            {
                this.txtCallIn.Enabled = true;
            }
            else
            {
                this.txtCallIn.Clear();
                this.txtCallIn.Enabled = false;
            }
        }

        private void rdoCallOutLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoCallOutLimit.Checked)
            {
                this.txtCallOut.Enabled = true;
            }
            else
            {
                this.txtCallOut.Clear();
                this.txtCallOut.Enabled = false;
            }
        }

        private void rdoMix_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoMessage.Checked)
            {
                this.SetCommArgControl(false);
            }
            else
            {
                this.SetCommArgControl(true);
            }
        }

        private void SetAlarmShow(int pAlarmType)
        {
            foreach (Control control in this.pnlAlarm.Controls)
            {
                if ((control != null) && (control.Tag != null))
                {
                    ComBox box = control as ComBox;
                    if (box != null)
                    {
                        box.SelectedIndex = pAlarmType;
                    }
                }
            }
            foreach (Control control2 in this.pnlExpandAlarm.Controls)
            {
                if ((control2 != null) && (control2.Tag != null))
                {
                    ComBox box2 = control2 as ComBox;
                    if (box2 != null)
                    {
                        box2.SelectedIndex = pAlarmType;
                    }
                }
            }
        }

        private void SetAlarmValue(out long car_AlarmSwitch, out long car_AlarmFlag, out long car_ShowAlarm, Panel p)
        {
            car_AlarmSwitch = 0L;
            car_AlarmFlag = 0L;
            car_ShowAlarm = 0L;
            long num = 0L;
            foreach (Control control in p.Controls)
            {
                if (((control != null) && (control.Tag != null)) && !control.Tag.Equals("9999"))
                {
                    ComBox box = (ComBox) control;
                    if (box != null)
                    {
                        try
                        {
                            num = Convert.ToInt64(control.Tag);
                        }
                        catch
                        {
                        }
                        switch (box.SelectedIndex)
                        {
                            case 0:
                                car_AlarmSwitch |= num;
                                car_AlarmFlag |= num;
                                break;

                            case 1:
                                car_AlarmSwitch |= num;
                                break;

                            case 2:
                                car_AlarmSwitch |= num;
                                car_ShowAlarm |= num;
                                break;
                        }
                    }
                }
            }
        }

        private void SetChooseCustomAlarmIndex(int iCarAlarmSwitch, int iCarAlarmFlag, int iShowAlarm, int iCustLevel, string strCustName)
        {
            int num = 6;
            int num2 = 0;
            string str = "cmbCustom";
            ComBox box = null;
            ComBox box2 = null;
            TextBox box3 = null;
            for (int i = 1; i <= num; i++)
            {
                try
                {
                    box = (ComBox) this.grpCustom.Controls[str + i.ToString() + "Alarm"];
                    box2 = (ComBox) this.grpCustom.Controls[str + i.ToString() + "Elec"];
                    box3 = (TextBox) this.grpCustom.Controls["txtCustom" + i.ToString() + "Name"];
                    if (((box != null) && (box2 != null)) && (box3 != null))
                    {
                        num2 = Convert.ToInt32(box.Tag.ToString());
                        box.addItems("报警", "0");
                        box.addItems("警告", "1");
                        box.addItems("报告", "2");
                        box.addItems("关闭", "3");
                        if ((iCarAlarmSwitch & num2) != 0)
                        {
                            if ((iCarAlarmFlag & num2) != 0)
                            {
                                box.SelectedIndex = 0;
                            }
                            else if ((iShowAlarm & num2) != 0)
                            {
                                box.SelectedIndex = 2;
                            }
                            else
                            {
                                box.SelectedIndex = 1;
                            }
                        }
                        else
                        {
                            box.SelectedIndex = 3;
                        }
                        box2.addItems("高电平触发", "0");
                        box2.addItems("低电平触发", "1");
                        box2.SelectedIndex = 0;
                        if ((iCustLevel & num2) == 0)
                        {
                            box2.SelectedIndex = 1;
                        }
                        if (!string.IsNullOrEmpty(strCustName))
                        {
                            int index = strCustName.IndexOf(num2.ToString());
                            if (index >= 0)
                            {
                                int num5 = strCustName.IndexOf('/', index);
                                int num6 = strCustName.IndexOf("*", index);
                                if ((num5 != -1) && (num6 != -1))
                                {
                                    box3.Text = strCustName.Substring(num5 + 1, (num6 - num5) - 1);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void SetCommArgControl(bool isEnable)
        {
            this.cmbApnType.Enabled = isEnable;
            this.txtTcpIp.Enabled = isEnable;
            this.txtTcpPort.Enabled = isEnable;
            this.txtUdpIp.Enabled = isEnable;
            this.txtUdpPort.Enabled = isEnable;
        }

        private void setParam()
        {
            try
            {
                string str = "";
                string sCarId = "";
                if (this.sCarId.IndexOf(',') > 0)
                {
                    sCarId = this.sCarId.Substring(0, this.sCarId.IndexOf(',') - 1);
                }
                else
                {
                    sCarId = this.sCarId;
                }
                DataTable table = RemotingClient.ExecSql(((str + " Select  Param " + " From    GpsCarSetParam ") + " Where   CarId = " + sCarId) + " And     MsgType = '" + 38.ToString() + "'");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    string str3 = table.Rows[0]["Param"].ToString();
                    if (!string.IsNullOrEmpty(str3))
                    {
                        this.setParam(str3);
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得界面参数", exception.Message);
            }
        }

        private void setParam(string sParamList)
        {
            char[] separator = new char[] { '|', ';' };
            string[] strArray = sParamList.Split(separator);
            if (strArray.Length > 0)
            {
                foreach (string str in strArray)
                {
                    try
                    {
                        string[] strArray2 = str.Split(new char[] { '=' });
                        if (strArray2.Length <= 1)
                        {
                            continue;
                        }
                        Control[] controlArray = base.Controls.Find(strArray2[0], true);
                        if ((controlArray != null) && (controlArray.Length > 0))
                        {
                            Control control = controlArray[0];
                            switch (control.GetType().Name)
                            {
                                case "TextBox":
                                    control.Text = strArray2[1];
                                    break;

                                case "ComboBox":
                                case "ComBox":
                                    ((ComboBox) control).SelectedIndex = int.Parse(strArray2[1]);
                                    break;

                                case "DateTimePicker":
                                    ((DateTimePicker) control).Value = DateTime.Parse(strArray2[1]);
                                    break;

                                case "NumericUpDown":
                                    ((NumericUpDown) control).Value = int.Parse(strArray2[1]);
                                    break;

                                case "TrackBar":
                                    ((TrackBar) control).Value = int.Parse(strArray2[1]);
                                    break;

                                case "CheckBox":
                                    ((CheckBox) control).Checked = bool.Parse(strArray2[1]);
                                    break;

                                case "RadioButton":
                                    ((RadioButton) control).Checked = bool.Parse(strArray2[1]);
                                    break;
                            }
                        }
                        strArray2 = null;
                        controlArray = null;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void showSucceedMsg()
        {
            MessageBox.Show("参数配置发送成功！");
        }

        private void txtCallIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b')) && (e.KeyChar != '\r'))
            {
                e.Handled = true;
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] strArray = this.sCarId.Split(new char[] { ',' });
            if (strArray.Length > 0)
            {
                m_CommonCar = RemotingClient.Car_GetCarDetailInfoByCarId(strArray[0]);
                this.dtCarConfig = RemotingClient.Car_GetCarConfig(strArray[0]);
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.initForm(this.dtCarConfig);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ComDevParam
        {
            public string DevName;
            public int DevId;
            public int DevCode;
            public int isPtp;
        }
    }
}

