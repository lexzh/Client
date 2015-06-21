namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itemsettemp : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itemsettemp(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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

        private void chkStopAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkStopAlarm.Checked)
            {
                this.numMaxTemperature.Value = 0M;
                this.numMinTemperature.Value = 0M;
                this.numMaxTemperature.Enabled = false;
                this.numMinTemperature.Enabled = false;
            }
            else
            {
                this.numMaxTemperature.Enabled = true;
                this.numMinTemperature.Enabled = true;
            }
        }

 private bool getParam()
        {
            if (this.numMaxTemperature.Value < this.numMinTemperature.Value)
            {
                MessageBox.Show("最低温度不能高于最高温度");
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.LowTemprature = Convert.ToDouble(this.numMinTemperature.Value);
            this.m_SimpleCmd.HighTemprature = Convert.ToDouble(this.numMaxTemperature.Value);
            return true;
        }


    }
}