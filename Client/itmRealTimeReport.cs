namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmRealTimeReport : CarForm
    {
        private PosReport m_PosReport = new PosReport();

        public itmRealTimeReport(CmdParam.OrderCode OrderCode)
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
                if (this.m_PosReport.ReportTiming > 65535)
                {
                    MessageBox.Show(string.Format("{0}必须在 0～65535 分钟以内！", this.lblTime.Text));
                }
                else
                {
                    this.saveFormParam(sender, e);
                    if (base.OrderCode == CmdParam.OrderCode.位置查询)
                    {
                        this.m_PosReport.protocolType = CarProtocolType.交通厅;
                    }
                    base.reResult = RemotingClient.DownData_SetPosReport(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_PosReport);
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
        }

        private void chkContinuWatch_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox) sender).Checked)
            {
                this.numTime.Enabled = false;
                this.numTime.Minimum = 0M;
                this.numTime.Value = 0M;
                this.cmbTime.Enabled = false;
            }
            else
            {
                this.numTime.Enabled = true;
                this.numTime.Minimum = 1M;
                this.cmbTime.Enabled = true;
            }
        }

        private void cmbWatchType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((CmdParam.ReportType) this.cmbWatchType.SelectedValue) == CmdParam.ReportType.定次汇报)
            {
                this.lblTime.Visible = true;
                this.numTime.Visible = true;
                this.lblDegree.Visible = true;
                this.lblTime.Text = "回传次数：";
                this.lblInterval.Visible = true;
                this.numInterval.Visible = true;
                this.lblSecond.Visible = true;
                this.lblInterval.Text = "间隔时间：";
                this.numInterval.Value = 60M;
                this.lblSecond.Text = "秒";
                this.cmbTime.Visible = false;
            }
            else if (((CmdParam.ReportType) this.cmbWatchType.SelectedValue) == CmdParam.ReportType.定时汇报)
            {
                this.lblInterval.Visible = true;
                this.numInterval.Visible = true;
                this.lblSecond.Visible = true;
                this.lblInterval.Text = "间隔时间：";
                this.numInterval.Value = 60M;
                this.lblSecond.Text = "秒";
                this.cmbTime.Visible = true;
                this.lblTime.Text = "监控时长：";
                this.lblDegree.Visible = false;
            }
            else if (((CmdParam.ReportType) this.cmbWatchType.SelectedValue) == CmdParam.ReportType.定距汇报)
            {
                this.lblInterval.Text = "间隔距离：";
                this.numInterval.Value = 500M;
                this.lblSecond.Text = "米";
                this.lblTime.Visible = true;
                this.numTime.Visible = true;
                this.cmbTime.Visible = false;
                this.lblTime.Text = "监控单元：";
                this.lblDegree.Visible = false;
            }
            else if (((CmdParam.ReportType) this.cmbWatchType.SelectedValue) == CmdParam.ReportType.轮询监控)
            {
                this.chkNoReport.Visible = false;
                this.lblTime.Text = "回传次数：";
                this.cmbTime.Visible = false;
                this.lblSecond.Visible = true;
                this.lblInterval.Text = "间隔时间：";
                this.numInterval.Value = 60M;
                this.lblSecond.Text = "秒";
                this.lblDegree.Visible = false;
            }
        }

 public void execSend()
        {
            base.btnOK_Click(null, null);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                this.getParam();
                if (this.m_PosReport.ReportTiming > 65535)
                {
                    MessageBox.Show(string.Format("{0}必须在 0～65535 分钟以内！", this.lblTime.Text));
                }
                else
                {
                    base.reResult = RemotingClient.DownData_SetPosReport(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_PosReport);
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
        }

        private void getFormParam()
        {
        }

        private void getParam()
        {
            this.m_PosReport.OrderCode = base.OrderCode;
            this.m_PosReport.CompressionUpTime = 0;
            this.m_PosReport.isCompressed = isCompressed;
            this.m_PosReport.ReportType = (CmdParam.ReportType) this.cmbWatchType.SelectedValue;
            if (base.OrderCode == CmdParam.OrderCode.压缩监控)
            {
                this.m_PosReport.isCompressed = CmdParam.IsCompressed.压缩传送;
            }
            else
            {
                this.m_PosReport.isCompressed = CmdParam.IsCompressed.单次传送;
            }
            bool flag = this.chkContinuWatch.Checked;
            bool flag2 = true;
            if (this.chkNoReport.Visible)
            {
                flag2 = this.chkNoReport.Checked;
            }
            this.m_PosReport.ReportWhenStop = flag2 ? CmdParam.ReportWhenStop.不汇报 : CmdParam.ReportWhenStop.汇报;
            this.m_PosReport.IsAutoCalArc = Convert.ToByte(this.numRepair.Value);
            string str = string.Empty;
            if (flag)
            {
                str = "0";
            }
            else
            {
                str = Convert.ToInt32(this.numTime.Value).ToString();
                bool flag1 = str == "0";
            }
            int num = Convert.ToInt32(this.cmbTime.SelectedValue);
            string str2 = Convert.ToInt32(this.numInterval.Value).ToString();
            if (CmdParam.ReportType.定次汇报 == this.m_PosReport.ReportType)
            {
                try
                {
                    this.m_PosReport.ReportTiming = Convert.ToInt32(str);
                    this.m_PosReport.LowReportCycle = Convert.ToInt32(str2);
                }
                catch
                {
                }
            }
            else
            {
                if (CmdParam.ReportType.定距汇报 == this.m_PosReport.ReportType)
                {
                    try
                    {
                        this.m_PosReport.ReportTiming = Convert.ToInt32(str);
                        this.m_PosReport.LowReportCycle = Convert.ToInt32(str2);
                    }
                    catch
                    {
                    }
                }
                if (CmdParam.ReportType.定时汇报 == this.m_PosReport.ReportType)
                {
                    try
                    {
                        this.m_PosReport.ReportTiming = Convert.ToInt32(str) * num;
                        this.m_PosReport.LowReportCycle = Convert.ToInt32(str2);
                    }
                    catch
                    {
                    }
                }
                if (CmdParam.ReportType.轮询监控 == this.m_PosReport.ReportType)
                {
                    try
                    {
                        this.m_PosReport.ReportTiming = Convert.ToInt32(str) * num;
                        this.m_PosReport.LowReportCycle = Convert.ToInt32(str2);
                    }
                    catch
                    {
                    }
                }
            }
        }

 private void itmRealTimeReport_Load(object sender, EventArgs e)
        {
            this.setControl();
            this.getFormParam();
        }

        private void saveFormParam(object sender, EventArgs e)
        {
        }

        private void setControl()
        {
            switch (base.OrderCode)
            {
                case CmdParam.OrderCode.位置查询:
                    this.cmbWatchType.addItems("位置查询", 3);
                    this.isCompressed = CmdParam.IsCompressed.单次传送;
                    this.chkContinuWatch.Enabled = false;
                    this.chkNoReport.Enabled = false;
                    this.numRepair.Enabled = false;
                    this.numTime.Enabled = false;
                    this.numInterval.Enabled = false;
                    this.cmbTime.Enabled = false;
                    break;

                case CmdParam.OrderCode.实时监控:
                    this.cmbWatchType.addItems("按次数监控", 3);
                    this.cmbWatchType.addItems("按时长监控", 1);
                    this.cmbWatchType.addItems("按距离监控", 2);
                    this.isCompressed = CmdParam.IsCompressed.单次传送;
                    break;

                case CmdParam.OrderCode.压缩监控:
                    this.cmbWatchType.addItems("按次数监控", 3);
                    this.cmbWatchType.addItems("按时长监控", 1);
                    this.cmbWatchType.addItems("按距离监控", 2);
                    this.isCompressed = CmdParam.IsCompressed.压缩传送;
                    break;

                case CmdParam.OrderCode.设置轮询监控:
                    this.cmbWatchType.addItems("轮询监控", 7);
                    this.isCompressed = CmdParam.IsCompressed.单次传送;
                    break;
            }
            this.cmbTime.addItems("分钟", 1);
            this.cmbTime.addItems("小时", 60);
            this.cmbWatchType_SelectedValueChanged(null, null);
        }
    }
}

