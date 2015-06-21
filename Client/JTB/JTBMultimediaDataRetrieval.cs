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

    public partial class JTBMultimediaDataRetrieval : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBMultimediaDataRetrieval(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.cmbMultimediaType.SelectedIndex = this.cmbEventCode.SelectedIndex = 0;
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
            if (this.dtpStartTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if ((this.numChannelNumber.Text.Trim().Length == 0) || this.numChannelNumber.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblChannelNumber.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numChannelNumber.Focus();
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.MediaFlag = this.cmbMultimediaType.SelectedIndex;
            this.m_SimpleCmd.ChanelID = (int) this.numChannelNumber.Value;
            this.m_SimpleCmd.EFlag = this.cmbEventCode.SelectedIndex;
            this.m_SimpleCmd.StartTime = this.dtpStartTime.Value.ToString("yyMMddHHmmss");
            this.m_SimpleCmd.EndTime = this.dtpEndTime.Value.ToString("yyMMddHHmmss");
            return true;
        }


    }
}