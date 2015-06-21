namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmSetOilAlarm : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmSetOilAlarm(CmdParam.OrderCode OrderCode)
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

 private bool getParam()
        {
            int num = 0;
            try
            {
                num = int.Parse(this.txtOilCubage.Text);
            }
            catch
            {
                MessageBox.Show("油箱容积错误");
                return false;
            }
            int num2 = Convert.ToInt32(this.numAlarmCubage.Value);
            if (num2 > num)
            {
                MessageBox.Show(string.Format("{0}的取值范围为(0-{1})", this.lblAlarmCubage.Text, this.txtOilCubage.Text));
                this.numAlarmCubage.Focus();
                return false;
            }
            this.m_SimpleCmd.OilAlarmValue = num2;
            this.m_SimpleCmd.TimeOutTime = Convert.ToInt32(this.numDuration.Value);
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            return true;
        }

 private void itmSetOilAlarm_Load(object sender, EventArgs e)
        {
            int num = RemotingClient.CarOil_GetOilBoxVol(base.sCarId);
            if (num < 0)
            {
                MessageBox.Show("未取到车辆油箱容量值");
            }
            else
            {
                this.txtOilCubage.Text = num.ToString();
                this.numAlarmCubage.Maximum = num;
                this.numAlarmCubage.Value = decimal.Parse((num * 0.15).ToString());
            }
        }
    }
}

