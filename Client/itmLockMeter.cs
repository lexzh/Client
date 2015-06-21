namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmLockMeter : CarForm
    {
        private AppRequest m_appRequest = new AppRequest();

        public itmLockMeter(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue))
                {
                    this.getParam();
                    AppRespone respone = RemotingClient.Car_SetCommonCmd_Pass(this.m_appRequest);
                    if (respone.ResultCode != 0)
                    {
                        MessageBox.Show(respone.ResultMsg);
                    }
                    else
                    {
                        base.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

 private void getParam()
        {
            this.m_appRequest.OrderCode = base.OrderCode;
            this.m_appRequest.ParamType = base.ParamType;
            this.m_appRequest.CarValues = base.sValue;
            this.m_appRequest.CarPw = base.sPw;
            this.m_appRequest.CommMode = CmdParam.CommMode.未知方式;
            this.m_appRequest.ParamCont = new string[] { this.dtpLockDate.Value.ToString("yyyyMMdd") + this.dtpLockTime.Value.ToString("HHmmss") };
        }

 private void itmLockMeter_Load(object sender, EventArgs e)
        {
        }
    }
}

