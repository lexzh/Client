namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class m2mCancleReport : CarForm
    {

        public m2mCancleReport(CmdParam.OrderCode OrderCode)
        {
            this.m_SimpleCmd = new SimpleCmd();
            this.m_sTitle = "";
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        public m2mCancleReport(CmdParam.OrderCode OrderCode, string sTitle)
        {
            this.m_SimpleCmd = new SimpleCmd();
            this.m_sTitle = "";
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.m_sTitle = sTitle;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                this.getParam();
                base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.驾驶员身份)
            {
                string[] strArray = new string[] { "0" };
                list.Add(strArray);
            }
            else if (base.OrderCode == CmdParam.OrderCode.区域外罐车反转报警设置)
            {
                string[] strArray2 = new string[] { "0", "0" };
                list.Add(strArray2);
            }
            else if (base.OrderCode == CmdParam.OrderCode.开启油耗功能)
            {
                string[] strArray3 = new string[] { "0", "0", "0" };
                list.Add(strArray3);
            }
            else if (base.OrderCode == CmdParam.OrderCode.区域超时停车报警设置)
            {
                string[] strArray4 = new string[] { "0", "0", "0", "0" };
                list.Add(strArray4);
            }
            this.m_SimpleCmd.CmdParams = list;
        }

 private void m2mCancleReport_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.m_sTitle))
            {
                this.Text = this.m_sTitle;
            }
        }
    }
}

