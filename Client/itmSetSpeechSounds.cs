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

    public partial class itmSetSpeechSounds : CarForm
    {
        private AppRequest appRequest = new AppRequest();
        private AppRespone appRespone = new AppRespone();
        private object pvArg = new object();

        public itmSetSpeechSounds(CmdParam.OrderCode OrderCode)
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
            if (Encoding.Default.GetBytes(this.txtText.Text).Length > 64)
            {
                MessageBox.Show(string.Format("播报内容超过64字节", new object[0]));
                this.txtText.Focus();
                return false;
            }
            this.appRequest.OrderCode = base.OrderCode;
            this.appRequest.ParamType = base.ParamType;
            this.appRequest.CarValues = base.sValue;
            this.appRequest.CarPw = base.sPw;
            this.appRequest.CommMode = CmdParam.CommMode.未知方式;
            byte[] bytes = BitConverter.GetBytes(1);
            byte[] buffer2 = BitConverter.GetBytes(Encoding.Unicode.GetBytes(this.txtText.Text).Length);
            byte[] buffer3 = Encoding.Unicode.GetBytes(this.txtText.Text);
            byte[] array = new byte[4 + buffer3.Length];
            int index = 0;
            array[0] = bytes[0];
            array[1] = bytes[1];
            index += 2;
            array[2] = buffer2[0];
            array[3] = buffer2[1];
            index += 2;
            buffer3.CopyTo(array, index);
            this.pvArg = array;
            return true;
        }

 private void itmSetSpeechSounds_Load(object sender, EventArgs e)
        {
        }
    }
}

