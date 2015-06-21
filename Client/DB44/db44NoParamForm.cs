namespace Client.DB44
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class db44NoParamForm : CarForm
    {
        private IContainer components;
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public db44NoParamForm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(null, null);
                if (!string.IsNullOrEmpty(base.sValue))
                {
                    this.getParam();
                    base.reResult = RemotingClient.DownData_icar_SetCommonCmd_XCJLY(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
            catch (Exception exception)
            {
                Record.execFileRecord(base.OrderCode.ToString(), exception.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "db44ViewOverSpeed";
        }
    }
}

