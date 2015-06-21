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

    public partial class m2mSetCarInit : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mSetCarInit(CmdParam.OrderCode CmdOrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = CmdOrderCode;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                try
                {
                    if (this.getParam())
                    {
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
                catch
                {
                }
            }
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.设置GPRS链接维持报文)
            {
                string[] strArray = new string[] { this.numTime.Value.ToString() };
                list.Add(strArray);
                this.m_SimpleCmd.CmdParams = list;
            }
            return true;
        }

 private void itmSetCarInit_Load(object sender, EventArgs e)
        {
        }
    }
}

