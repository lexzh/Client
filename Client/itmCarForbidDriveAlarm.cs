namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class itmCarForbidDriveAlarm : CarForm
    {
        private AppRequest appRequest = new AppRequest();
        private AppRespone appRespone = new AppRespone();
        private object pvArg = new object();

        public itmCarForbidDriveAlarm(CmdParam.OrderCode OrderCode)
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

        private void chkCancelAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCancelAlarm.Checked)
            {
                this.dtpStartTime.Text = "00:00";
                this.dtpEndTime.Text = "00:00";
                this.txtText.Text = "";
                this.dtpStartTime.Enabled = false;
                this.dtpEndTime.Enabled = false;
                this.txtText.Enabled = false;
            }
            else
            {
                this.dtpStartTime.Enabled = true;
                this.dtpEndTime.Enabled = true;
                this.txtText.Enabled = true;
            }
        }

 private bool getParam()
        {
            if (!this.chkCancelAlarm.Checked && this.txtText.Enabled)
            {
                if (string.IsNullOrEmpty(this.txtText.Text))
                {
                    MessageBox.Show("请输入播报内容");
                    this.txtText.Focus();
                    return false;
                }
                if (Encoding.Default.GetBytes(this.txtText.Text).Length > 64)
                {
                    MessageBox.Show(string.Format("播报内容超过64字节", new object[0]));
                    this.txtText.Focus();
                    return false;
                }
            }
            this.appRequest.OrderCode = base.OrderCode;
            this.appRequest.ParamType = base.ParamType;
            this.appRequest.CarValues = base.sValue;
            this.appRequest.CarPw = base.sPw;
            this.appRequest.CommMode = CmdParam.CommMode.未知方式;
            byte num = Convert.ToByte(this.dtpStartTime.Value.Hour);
            byte num2 = Convert.ToByte(this.dtpStartTime.Value.Minute);
            byte num3 = Convert.ToByte(this.dtpEndTime.Value.Hour);
            byte num4 = Convert.ToByte(this.dtpEndTime.Value.Minute);
            byte length = (byte) Encoding.Unicode.GetBytes(this.txtText.Text).Length;
            byte[] bytes = Encoding.Unicode.GetBytes(this.txtText.Text);
            byte[] array = new byte[5 + bytes.Length];
            int index = 0;
            array[index] = num;
            index++;
            array[index] = num2;
            index++;
            array[index] = num3;
            index++;
            array[index] = num4;
            index++;
            array[index] = length;
            index++;
            bytes.CopyTo(array, index);
            this.pvArg = array;
            return true;
        }

 private void itmCarForbidDriveInTimeAlarm_Load(object sender, EventArgs e)
        {
        }
    }
}

