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

    public partial class JTBSetResponseAndRetransmission : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBSetResponseAndRetransmission(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.cmbChannelType.SelectedIndex = 0;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.icar_SetCommonCmdTraffic(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
            if ((this.numResponseTime.Text.Trim().Length == 0) || this.numResponseTime.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblResponseTime.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numResponseTime.Focus();
                return false;
            }
            if ((this.numRetransmission.Text.Trim().Length == 0) || this.numRetransmission.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblRetransmission.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numRetransmission.Focus();
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.ChannelType = this.cmbChannelType.SelectedIndex;
            this.m_SimpleCmd.ReplyTimeOut = (int) this.numResponseTime.Value;
            this.m_SimpleCmd.RepeatTimes = (int) this.numRetransmission.Value;
            return true;
        }


    }
}