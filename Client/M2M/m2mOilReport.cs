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

    public partial class m2mOilReport : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mOilReport(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
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

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            string str = this.rdoUpload.Checked ? "1" : "0";
            string[] strArray = new string[] { "1", str, this.numInterval.Value.ToString() };
            list.Add(strArray);
            this.m_SimpleCmd.CmdParams = list;
            return true;
        }

 private void rdoUpload_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoUpload.Checked)
            {
                this.numInterval.Enabled = true;
            }
            else
            {
                this.numInterval.Enabled = false;
            }
        }
    }
}

