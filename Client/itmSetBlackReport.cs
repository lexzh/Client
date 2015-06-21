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

    public partial class itmSetBlackReport : CarForm
    {
        private BlackBox m_Blackbox = new BlackBox();

        public itmSetBlackReport(CmdParam.OrderCode OrderCode)
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
                base.reResult = RemotingClient.DownData_SetBlackBox(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_Blackbox);
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

        private void cmbSampleType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((CmdParam.ReportType) this.cmbSampleType.SelectedValue) == CmdParam.ReportType.定距汇报)
            {
                this.lblMeter.Text = "米";
                base.OrderCode = CmdParam.OrderCode.设置黑匣子采集定距;
            }
            else
            {
                this.lblMeter.Text = "秒";
                base.OrderCode = CmdParam.OrderCode.设置黑匣子采集定时;
            }
        }

 private void getParam()
        {
            this.m_Blackbox.OrderCode = base.OrderCode;
            if (base.OrderCode == CmdParam.OrderCode.停止黑匣子采样)
            {
                this.m_Blackbox.ReportType = CmdParam.ReportType.停止汇报;
            }
            else
            {
                this.m_Blackbox.ReportType = (CmdParam.ReportType) this.cmbSampleType.SelectedValue;
                this.m_Blackbox.IsAutoCalArc = Convert.ToByte(this.numRepair.Value);
                this.m_Blackbox.ReportCycle = Convert.ToInt32(this.numDistance.Value);
                this.m_Blackbox.Flag = this.chkAutoUp.Checked ? 1 : 0;
            }
        }

 private void itmSetBlackReport_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
        }

        private void setGroupVisible()
        {
            if (base.OrderCode == CmdParam.OrderCode.停止黑匣子采样)
            {
                this.grpSampleParam.Visible = false;
            }
            else
            {
                this.cmbSampleType.addItems("定时采样", 1);
                this.cmbSampleType.addItems("定距采样", 2);
                this.cmbSampleType_SelectedValueChanged(null, null);
            }
        }
    }
}

