namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmCarOverTimeDrive : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmCarOverTimeDrive(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            if (WorkBench.SystemID == 1)
            {
                this.lblMinute1.Text = this.lblMinute4.Text = "分";
                this.numDriveTime.Maximum = this.numRestTime.Maximum = 4294967295M;
                this.label1.Visible = this.lblAlarmTime.Visible = this.numAlarmTime.Visible = this.lblMinute2.Visible = this.lblAlarmInterval.Visible = this.numAlarmInterval.Visible = this.lblMinute3.Visible = false;
            }
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                this.getParam();
                base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                if (base.reResult.ResultCode != 0)
                {
                    MessageBox.Show(base.reResult.ErrorMsg);
                }
                else
                {
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            if (base.OrderCode == CmdParam.OrderCode.设置超时驾驶报警)
            {
                this.m_SimpleCmd.TimeOutTime = Convert.ToInt32(this.numDriveTime.Value);
                this.m_SimpleCmd.PreAlarmTime = Convert.ToInt32(this.numAlarmTime.Value);
                this.m_SimpleCmd.PreInterval = Convert.ToInt32(this.numAlarmInterval.Value);
                this.m_SimpleCmd.RestTime = Convert.ToInt32(this.numRestTime.Value);
            }
        }


    }
}