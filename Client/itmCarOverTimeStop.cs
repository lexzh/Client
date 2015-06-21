namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmCarOverTimeStop : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmCarOverTimeStop(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            this.cmbTelType.SelectedIndex = 1;
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                this.getParam();
                base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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

        private void cmbTelType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cmbTelType.SelectedIndex == 1)
            {
                this.lblDriveTime.Text = "通话持续时长：";
            }
            else if (this.cmbTelType.SelectedIndex == 0)
            {
                this.lblDriveTime.Text = "每次最长通话：";
            }
        }

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            int result = 0;
            int.TryParse(this.numDriveTime.Value.ToString(), out result);
            if (base.OrderCode == CmdParam.OrderCode.设置通话时间限制)
            {
                this.m_SimpleCmd.CallTimeLimit = result;
                this.m_SimpleCmd.CallTimeLimitType = this.cmbTelType.SelectedIndex;
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置超时停车报警)
            {
                this.m_SimpleCmd.TimeOutTime = result * 60;
            }
        }

 private void itmCarOverTimeStop_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
        }

        private void setGroupVisible()
        {
            if (base.OrderCode == CmdParam.OrderCode.设置超时停车报警)
            {
                this.grpSetOverTimeDrive.Text = "超时停车参数";
                this.lblDriveTime.Text = "停车持续时长：";
                if (WorkBench.SystemID != 1)
                {
                    this.numDriveTime.Maximum = 65535M;
                    this.label1.Text = "*当时长为0时，表示不限制(0-65535)";
                }
                else
                {
                    this.numDriveTime.Maximum = 4294967295M;
                    this.label1.Text = "设置范围(0-4294967295)";
                    this.lblMinute1.Text = "分";
                }
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置通话时间限制)
            {
                this.grpSetOverTimeDrive.Text = "通话限制参数：";
                this.lblDriveTime.Text = "通话持续时长：";
                if (WorkBench.SystemID != 1)
                {
                    this.numDriveTime.Maximum = 65535M;
                    this.label1.Text = "*当时长为65535时，表示不限制(0-65535)";
                }
                else
                {
                    this.numDriveTime.Maximum = 4294967295M;
                    this.label1.Text = "*当时长为4294967295时，表示不限制(0-4294967295)";
                    this.lblMinute1.Text = "秒";
                }
                this.lblTelType.Visible = this.cmbTelType.Visible = true;
            }
        }
    }
}

