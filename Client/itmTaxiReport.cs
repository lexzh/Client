namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmTaxiReport : CarForm
    {
        private TransportReport m_Transport = new TransportReport();

        public itmTaxiReport(CmdParam.OrderCode OrderCode)
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
                base.reResult = RemotingClient.DownData_SetTransportReport(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_Transport);
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
            this.m_Transport.OrderCode = base.OrderCode;
            this.m_Transport.ReportFlag = 0;
            try
            {
                this.m_Transport.nStatuFree = Convert.ToInt32(this.numEmptyReport.Value);
                this.m_Transport.nStatuBusy = Convert.ToInt32(this.numFullReport.Value);
            }
            catch
            {
            }
        }


    }
}