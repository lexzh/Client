namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class JTBCarCancelRequest : CarForm
    {
        private IContainer components;
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBCarCancelRequest(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.Car_CommandParameterInsterToDB(base.ParamType, base.sValue, base.sPw, this.m_SimpleCmd, "", "取消交换指定车辆定位信息请求");
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            return true;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "JTBCarCancelRequest";
        }
    }
}

