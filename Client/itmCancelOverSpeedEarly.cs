namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    

    public partial class itmCancelOverSpeedEarly : CarForm
    {
        private AppRequest appRequest = new AppRequest();
        private AppRespone appRespone = new AppRespone();
        private object pvArg = new object();

        public itmCancelOverSpeedEarly(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                this.appRespone = RemotingClient.DownData_icar_SendRawPackage(this.appRequest, this.pvArg);
                if (this.appRespone.ResultCode != 0)
                {
                    MessageBox.Show(this.appRespone.ResultMsg);
                }
                else
                {
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

 private bool getParam()
        {
            this.appRequest.OrderCode = base.OrderCode;
            this.appRequest.ParamType = base.ParamType;
            this.appRequest.CarValues = base.sValue;
            this.appRequest.CarPw = base.sPw;
            this.appRequest.CommMode = CmdParam.CommMode.未知方式;
            this.pvArg = null;
            return true;
        }

 private void itmCancelOverSpeedEarly_Load(object sender, EventArgs e)
        {
        }
    }
}

