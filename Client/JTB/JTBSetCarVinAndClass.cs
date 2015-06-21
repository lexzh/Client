namespace Client.JTB
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

    public partial class JTBSetCarVinAndClass : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBSetCarVinAndClass(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
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
            if (Encoding.GetEncoding("gb2312").GetByteCount(this.txtCarClassify.Text) > 17)
            {
                MessageBox.Show("您输入的" + this.lblCarClassify.Text.Replace("：", "") + "太长了!");
                return false;
            }
            if (Encoding.GetEncoding("gb2312").GetByteCount(this.txtCarNumber.Text) > 12)
            {
                MessageBox.Show("您输入的" + this.lblCarNumber.Text.Replace("：", "") + "太长了!");
                return false;
            }
            if (Encoding.GetEncoding("gb2312").GetByteCount(this.txtCarVinNumber.Text) > 12)
            {
                MessageBox.Show("您输入的" + this.lblCarVinNumber.Text.Replace("：", "") + "太长了!");
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.VIN = this.txtCarVinNumber.Text;
            this.m_SimpleCmd.CarNUM = this.txtCarNumber.Text;
            this.m_SimpleCmd.PlateType = this.txtCarClassify.Text;
            return true;
        }


    }
}