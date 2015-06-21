namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmSetOverSpeed : CarForm
    {
        private AppRequest appRequest = new AppRequest();
        private AppRespone appRespone = new AppRespone();
        private SpeedAlarm m_SpeedAlarm = new SpeedAlarm();
        private object pvArg = new object();

        public itmSetOverSpeed(CmdParam.OrderCode OrderCode)
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
                if (base.OrderCode == CmdParam.OrderCode.设置超速报警)
                {
                    base.reResult = RemotingClient.DownData_SetSpeedAlarm(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SpeedAlarm);
                    if (base.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(base.reResult.ErrorMsg);
                    }
                    else
                    {
                        base.DialogResult = DialogResult.OK;
                    }
                }
                else
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
        }

 private void getParam()
        {
            int num = Convert.ToInt32(this.numMaxSpeed.Value);
            int num2 = Convert.ToInt32(this.numDuration.Value);
            int num3 = 0;
            try
            {
                num3 = Convert.ToInt32(this.numDuration.Value) + Convert.ToInt32(this.cmbCueInterval.SelectedValue);
            }
            catch
            {
            }
            if (base.OrderCode == CmdParam.OrderCode.设置超速报警)
            {
                this.m_SpeedAlarm.OrderCode = base.OrderCode;
                this.m_SpeedAlarm.MaxSpeed = num;
                this.m_SpeedAlarm.RealHoldTime = num2;
                this.m_SpeedAlarm.HoldTime = num3;
            }
            else
            {
                this.appRequest.OrderCode = base.OrderCode;
                this.appRequest.ParamType = base.ParamType;
                this.appRequest.CarValues = base.sValue;
                this.appRequest.CarPw = base.sPw;
                this.appRequest.CommMode = CmdParam.CommMode.未知方式;
                byte num4 = Convert.ToByte((double) (((double) num) / 1.852));
                byte num5 = Convert.ToByte(num3);
                byte[] buffer = new byte[] { num4, num5 };
                this.pvArg = buffer;
            }
        }

 private void itmSetOverSpeed_Load(object sender, EventArgs e)
        {
            this.numDuration_ValueChanged(null, null);
        }

        private void numDuration_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}

