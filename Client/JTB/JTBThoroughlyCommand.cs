namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBThoroughlyCommand : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBThoroughlyCommand(CmdParam.OrderCode OrderCode)
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
            if (this.txtCmd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入透传命令!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            string str = "";
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(this.txtCmd.Text.Trim());
            for (int i = 0; i < bytes.Length; i++)
            {
                str = str + bytes[i].ToString("X2");
            }
            this.m_SimpleCmd.RawPackageText = this.txtCmd.Text;
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            return true;
        }


    }
}