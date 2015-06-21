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

    public partial class JTBDynamicRepairInformation : CarForm
    {
        private string _content = "";
        private string _discript = "";
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBDynamicRepairInformation(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.cmbRepairType.SelectedIndex = 0;
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
            this._discript = "补报类型：" + this.cmbRepairType.SelectedItem.ToString() + "  开始时间：" + this.dtpStartTime.Value.ToString() + "  结束时间：" + this.dtpEndTime.Value.ToString();
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            string str = (this.cmbRepairType.SelectedIndex == 0) ? "01" : "00";
            string s = this.dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string str3 = this.dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string str4 = "";
            string str5 = "";
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(s);
            for (int i = 0; i < bytes.Length; i++)
            {
                str4 = str4 + bytes[i].ToString("X2");
            }
            byte[] buffer2 = Encoding.GetEncoding("gb2312").GetBytes(str3);
            for (int j = 0; j < buffer2.Length; j++)
            {
                str5 = str5 + buffer2[j].ToString("X2");
            }
            this._content = str + str4 + str5;
            return true;
        }


    }
}