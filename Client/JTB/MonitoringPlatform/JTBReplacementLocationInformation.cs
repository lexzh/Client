namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class JTBReplacementLocationInformation : CarForm
    {
        private string _content = "";
        private string _discript = "";
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBReplacementLocationInformation(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.Car_CommandParameterInsterToDB(base.ParamType, base.sValue, base.sPw, this.m_SimpleCmd, this._content, this._discript);
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
            this._discript = "开始时间：" + this.dtpStartTime.Value.ToString() + "  结束时间：" + this.dtpEndTime.Value.ToString();
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            string str = Convert.ToString((long) this.dtpStartTime.Value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds, 16).PadLeft(16, '0');
            string str2 = Convert.ToString((long) this.dtpEndTime.Value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds, 16).PadLeft(16, '0');
            this._content = str + str2;
            return true;
        }


    }
}