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

    public partial class JTBTemporaryPositionTracking : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBTemporaryPositionTracking(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
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

 private bool getParam()
        {
            if ((this.numTimeInterval.Text.Trim().Length == 0) || this.numTimeInterval.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblTimeInterval.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numTimeInterval.Focus();
                return false;
            }
            if ((this.numTimePeriod.Text.Trim().Length == 0) || this.numTimePeriod.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblTimePeriod.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numTimePeriod.Focus();
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.RCycle = (int) this.numTimeInterval.Value;
            this.m_SimpleCmd.RTiming = (int) this.numTimePeriod.Value;
            return true;
        }


    }
}