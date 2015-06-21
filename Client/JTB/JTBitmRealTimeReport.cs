namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class JTBitmRealTimeReport : CarForm
    {
        private TrafficPosReport trafficePostReport = new TrafficPosReport();

        public JTBitmRealTimeReport(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.cmbWatchType.SelectedIndex = this.cmbWatchProgram.SelectedIndex = 0;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.icar_SetPosReportConditions(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.trafficePostReport);
                if (base.reResult.ResultCode != 0L)
                {
                    MessageBox.Show(base.reResult.ErrorMsg);
                }
                else
                {
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

        private void cmbWatchProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetInterface();
        }

        private void cmbWatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetInterface();
        }

 private bool getParam()
        {
            this.trafficePostReport.OrderCode = base.OrderCode;
            this.trafficePostReport.RType = this.cmbWatchType.SelectedIndex;
            this.trafficePostReport.RProject = this.cmbWatchProgram.SelectedIndex;
            this.trafficePostReport.IsAutoCalArc = (int) this.numRepair.Value;
            if (this.cmbWatchType.SelectedIndex == 0)
            {
                if ((this.numDormancyInterval.Text.Trim().Length == 0) || this.numDormancyInterval.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblDormancyInterval.Text.Replace("：", "") + "输入格式有误!");
                    this.numDormancyInterval.Focus();
                    return false;
                }
                if ((this.numEmergencyAlarmInterval.Text.Trim().Length == 0) || this.numEmergencyAlarmInterval.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblEmergencyAlarmInterval.Text.Replace("：", "") + "输入格式有误!");
                    this.numEmergencyAlarmInterval.Focus();
                    return false;
                }
                if ((this.numReportInterval.Text.Trim().Length == 0) || this.numReportInterval.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblReportInterval.Text.Replace("：", "") + "输入格式有误!");
                    this.numReportInterval.Focus();
                    return false;
                }
                if (this.cmbWatchProgram.SelectedIndex == 0)
                {
                    this.trafficePostReport.RestCycleTime = (int) this.numDormancyInterval.Value;
                    this.trafficePostReport.AlarmCycleTime = (int) this.numEmergencyAlarmInterval.Value;
                    this.trafficePostReport.DefCycleTime = (int) this.numReportInterval.Value;
                }
                else
                {
                    if ((this.numNoLoginInterval.Text.Trim().Length == 0) || this.numNoLoginInterval.Text.Trim().Equals("-"))
                    {
                        MessageBox.Show(this.lblNoLoginInterval.Text.Replace("：", "") + "输入格式有误!");
                        this.numNoLoginInterval.Focus();
                        return false;
                    }
                    this.trafficePostReport.RestCycleTime = (int) this.numDormancyInterval.Value;
                    this.trafficePostReport.AlarmCycleTime = (int) this.numEmergencyAlarmInterval.Value;
                    this.trafficePostReport.DefCycleTime = (int) this.numReportInterval.Value;
                    this.trafficePostReport.NLoginCycleTime = (int) this.numNoLoginInterval.Value;
                }
            }
            else if (this.cmbWatchType.SelectedIndex == 1)
            {
                if ((this.numDormancyIntervalDis.Text.Trim().Length == 0) || this.numDormancyIntervalDis.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblDormancyIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                    this.numDormancyIntervalDis.Focus();
                    return false;
                }
                if ((this.numEmergencyAlarmIntervalDis.Text.Trim().Length == 0) || this.numEmergencyAlarmIntervalDis.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblEmergencyAlarmIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                    this.numEmergencyAlarmIntervalDis.Focus();
                    return false;
                }
                if ((this.numReportIntervalDis.Text.Trim().Length == 0) || this.numReportIntervalDis.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblReportIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                    this.numReportIntervalDis.Focus();
                    return false;
                }
                if (this.cmbWatchProgram.SelectedIndex == 0)
                {
                    this.trafficePostReport.RestCycleDis = (int) this.numDormancyIntervalDis.Value;
                    this.trafficePostReport.AlarmCycleDis = (int) this.numEmergencyAlarmIntervalDis.Value;
                    this.trafficePostReport.DefCycleDis = (int) this.numReportIntervalDis.Value;
                }
                else
                {
                    if ((this.numNoLoginIntervalDis.Text.Trim().Length == 0) || this.numNoLoginIntervalDis.Text.Trim().Equals("-"))
                    {
                        MessageBox.Show(this.lblNoLoginIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                        this.numNoLoginIntervalDis.Focus();
                        return false;
                    }
                    this.trafficePostReport.RestCycleDis = (int) this.numDormancyIntervalDis.Value;
                    this.trafficePostReport.AlarmCycleDis = (int) this.numEmergencyAlarmIntervalDis.Value;
                    this.trafficePostReport.DefCycleDis = (int) this.numReportIntervalDis.Value;
                    this.trafficePostReport.NLoginCycleDis = (int) this.numNoLoginIntervalDis.Value;
                }
            }
            else
            {
                if ((this.numDormancyInterval.Text.Trim().Length == 0) || this.numDormancyInterval.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblDormancyInterval.Text.Replace("：", "") + "输入格式有误!");
                    this.numDormancyInterval.Focus();
                    return false;
                }
                if ((this.numEmergencyAlarmInterval.Text.Trim().Length == 0) || this.numEmergencyAlarmInterval.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblEmergencyAlarmInterval.Text.Replace("：", "") + "输入格式有误!");
                    this.numEmergencyAlarmInterval.Focus();
                    return false;
                }
                if ((this.numReportInterval.Text.Trim().Length == 0) || this.numReportInterval.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblReportInterval.Text.Replace("：", "") + "输入格式有误!");
                    this.numReportInterval.Focus();
                    return false;
                }
                if ((this.numReportIntervalDis.Text.Trim().Length == 0) || this.numReportIntervalDis.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblReportIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                    this.numReportIntervalDis.Focus();
                    return false;
                }
                if ((this.numEmergencyAlarmIntervalDis.Text.Trim().Length == 0) || this.numEmergencyAlarmIntervalDis.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblEmergencyAlarmIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                    this.numEmergencyAlarmIntervalDis.Focus();
                    return false;
                }
                if ((this.numReportIntervalDis.Text.Trim().Length == 0) || this.numReportIntervalDis.Text.Trim().Equals("-"))
                {
                    MessageBox.Show(this.lblReportIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                    this.numReportIntervalDis.Focus();
                    return false;
                }
                if (this.cmbWatchProgram.SelectedIndex == 0)
                {
                    this.trafficePostReport.RestCycleTime = (int) this.numDormancyInterval.Value;
                    this.trafficePostReport.AlarmCycleTime = (int) this.numEmergencyAlarmInterval.Value;
                    this.trafficePostReport.DefCycleTime = (int) this.numReportInterval.Value;
                    this.trafficePostReport.RestCycleDis = (int) this.numDormancyIntervalDis.Value;
                    this.trafficePostReport.AlarmCycleDis = (int) this.numEmergencyAlarmIntervalDis.Value;
                    this.trafficePostReport.DefCycleDis = (int) this.numReportIntervalDis.Value;
                }
                else
                {
                    if ((this.numNoLoginInterval.Text.Trim().Length == 0) || this.numNoLoginInterval.Text.Trim().Equals("-"))
                    {
                        MessageBox.Show(this.lblNoLoginInterval.Text.Replace("：", "") + "输入格式有误!");
                        this.numNoLoginInterval.Focus();
                        return false;
                    }
                    if ((this.numNoLoginIntervalDis.Text.Trim().Length == 0) || this.numNoLoginIntervalDis.Text.Trim().Equals("-"))
                    {
                        MessageBox.Show(this.lblNoLoginIntervalDis.Text.Replace("：", "") + "输入格式有误!");
                        this.numNoLoginIntervalDis.Focus();
                        return false;
                    }
                    this.trafficePostReport.RestCycleTime = (int) this.numDormancyInterval.Value;
                    this.trafficePostReport.AlarmCycleTime = (int) this.numEmergencyAlarmInterval.Value;
                    this.trafficePostReport.DefCycleTime = (int) this.numReportInterval.Value;
                    this.trafficePostReport.RestCycleDis = (int) this.numDormancyIntervalDis.Value;
                    this.trafficePostReport.AlarmCycleDis = (int) this.numEmergencyAlarmIntervalDis.Value;
                    this.trafficePostReport.DefCycleDis = (int) this.numReportIntervalDis.Value;
                    this.trafficePostReport.NLoginCycleTime = (int) this.numNoLoginInterval.Value;
                    this.trafficePostReport.NLoginCycleDis = (int) this.numNoLoginIntervalDis.Value;
                }
            }
            return true;
        }

 private void SetInterface()
        {
            if (this.cmbWatchType.SelectedIndex == 0)
            {
                this.pnlNeed1.Visible = this.pnlNeed2.Visible = true;
                this.pnlDis1.Visible = this.pnlDis2.Visible = false;
                this.lblReportInterval.Visible = this.lblReportIntervalSecond.Visible = this.numReportInterval.Visible = true;
                if (this.cmbWatchProgram.SelectedIndex == 0)
                {
                    this.pnlLoginState.Visible = false;
                }
                else
                {
                    this.pnlLoginState.Visible = true;
                }
            }
            else if (this.cmbWatchType.SelectedIndex == 1)
            {
                this.pnlNeed1.Visible = false;
                this.pnlNeed2.Visible = true;
                this.lblReportInterval.Visible = this.lblReportIntervalSecond.Visible = this.numReportInterval.Visible = false;
                this.pnlDis1.Visible = this.pnlDis2.Visible = true;
                if (this.cmbWatchProgram.SelectedIndex == 0)
                {
                    this.pnlLoginState.Visible = false;
                    this.lblNoLoginDis.Visible = this.numNoLoginIntervalDis.Visible = this.lblNoLoginIntervalDis.Visible = false;
                }
                else
                {
                    this.pnlLoginState.Visible = false;
                    this.lblNoLoginDis.Visible = this.numNoLoginIntervalDis.Visible = this.lblNoLoginIntervalDis.Visible = true;
                }
            }
            else
            {
                this.pnlNeed1.Visible = this.pnlNeed2.Visible = true;
                this.pnlDis1.Visible = this.pnlDis2.Visible = true;
                this.lblReportInterval.Visible = this.lblReportIntervalSecond.Visible = this.numReportInterval.Visible = true;
                if (this.cmbWatchProgram.SelectedIndex == 0)
                {
                    this.pnlLoginState.Visible = false;
                    this.lblNoLoginDis.Visible = this.numNoLoginIntervalDis.Visible = this.lblNoLoginIntervalDis.Visible = false;
                }
                else
                {
                    this.pnlLoginState.Visible = true;
                    this.lblNoLoginDis.Visible = this.numNoLoginIntervalDis.Visible = this.lblNoLoginIntervalDis.Visible = true;
                }
            }
        }
    }
}

