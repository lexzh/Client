namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class JTBReportPoliceInfo : CarForm
    {
        private string _content = "";
        private string _discript = "";
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBReportPoliceInfo(CmdParam.OrderCode OrderCode)
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
            if (this.txtPostResponse.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入报警信息内容!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this._discript = "报警信息：" + this.txtPostResponse.Text.Trim();
            this._content = "02";
            this._content = this._content + "00FF";
            this._content = this._content + Convert.ToString((long) DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds, 16).PadLeft(16, '0');
            this._content = this._content + "00001402";
            string str = "";
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(this.txtPostResponse.Text.Trim());
            this._content = this._content + Convert.ToString(bytes.Length, 16).PadLeft(8, '0');
            for (int i = 0; i < bytes.Length; i++)
            {
                str = str + bytes[i].ToString("X2");
            }
            this._content = this._content + str;
            return true;
        }


    }
}