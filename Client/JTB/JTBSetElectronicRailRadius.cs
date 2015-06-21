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

    public partial class JTBSetElectronicRailRadius : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBSetElectronicRailRadius(CmdParam.OrderCode OrderCode)
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
            if ((this.numRadius.Text.Trim().Length == 0) || this.numRadius.Text.Trim().Equals("-"))
            {
                MessageBox.Show("请检查输入是否正确?", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.R = (long) this.numRadius.Value;
            return true;
        }


    }
}