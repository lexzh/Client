namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;
    using Library;

    public partial class itmZBDistributary : CarForm
    {
        private AppRequest appRequest = new AppRequest();
        private AppRespone appRespone = new AppRespone();
        private object pvArg = new object();

        public itmZBDistributary(CmdParam.OrderCode OrderCode)
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

        private void cmbSendType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbMsgType.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    this.txtPhone.Enabled = true;
                    this.txtLonLat.Enabled = true;
                    this.txtTitle.Enabled = true;
                    return;

                case 3:
                    this.txtPhone.Enabled = false;
                    this.txtLonLat.Enabled = false;
                    this.txtTitle.Enabled = false;
                    return;

                case 4:
                    this.txtPhone.Enabled = true;
                    this.txtLonLat.Enabled = true;
                    this.txtTitle.Enabled = false;
                    return;
            }
        }

 private bool getParam()
        {
            if (this.txtPhone.Enabled && string.IsNullOrEmpty(this.txtPhone.Text))
            {
                MessageBox.Show("请输入商家电话");
                this.txtPhone.Focus();
                return false;
            }
            if (this.txtTitle.Enabled && string.IsNullOrEmpty(this.txtTitle.Text))
            {
                MessageBox.Show("请输入标题");
                this.txtTitle.Focus();
                return false;
            }
            if (this.txtText.Enabled)
            {
                if (string.IsNullOrEmpty(this.txtText.Text))
                {
                    MessageBox.Show("请输入正文");
                    this.txtText.Focus();
                    return false;
                }
                if (Encoding.Default.GetBytes(this.txtText.Text).Length > 140)
                {
                    MessageBox.Show(string.Format("正文超过140字节", new object[0]));
                    this.txtText.Focus();
                    return false;
                }
            }
            this.appRequest.OrderCode = base.OrderCode;
            this.appRequest.ParamType = base.ParamType;
            this.appRequest.CarValues = base.sValue;
            this.appRequest.CarPw = base.sPw;
            this.appRequest.CommMode = CmdParam.CommMode.混合方式;
            byte[] buffer = new byte[20];
            byte[] buffer2 = new byte[4];
            byte[] buffer3 = new byte[4];
            byte[] buffer4 = new byte[0];
            byte[] bytes = Encoding.Unicode.GetBytes(this.txtText.Text);
            switch (this.cmbMsgType.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    buffer = Encoding.ASCII.GetBytes(this.txtPhone.Text.PadRight(20, '\0'));
                    buffer2 = Check.ConvertLatAndLon(this.Longitude);
                    buffer3 = Check.ConvertLatAndLon(this.Latitude);
                    buffer4 = Encoding.Unicode.GetBytes(this.txtTitle.Text);
                    break;

                case 3:
                    buffer = Encoding.ASCII.GetBytes("\0".PadRight(20, '\0'));
                    buffer2 = Encoding.ASCII.GetBytes("\0".PadRight(4, '\0'));
                    buffer3 = Encoding.ASCII.GetBytes("\0".PadRight(4, '\0'));
                    break;

                case 4:
                    buffer = Encoding.ASCII.GetBytes(this.txtPhone.Text.PadRight(20, '\0'));
                    buffer2 = Check.ConvertLatAndLon(this.Longitude);
                    buffer3 = Check.ConvertLatAndLon(this.Latitude);
                    break;
            }
            byte[] array = new byte[(30 + buffer4.Length) + bytes.Length];
            int index = 0;
            array[0] = (byte) (this.cmbMsgType.SelectedIndex + 1);
            index++;
            buffer.CopyTo(array, index);
            index += buffer.Length;
            buffer2.CopyTo(array, index);
            index += buffer2.Length;
            buffer3.CopyTo(array, index);
            index += buffer3.Length;
            array[index] = (byte) buffer4.Length;
            index++;
            buffer4.CopyTo(array, index);
            index += buffer4.Length;
            bytes.CopyTo(array, index);
            this.pvArg = array;
            return true;
        }

        private void iniForm()
        {
            this.txtLonLat.Text = string.Format("{0},{1}", decimal.Parse(this.Longitude).ToString("0.000000"), decimal.Parse(this.Latitude).ToString("0.000000"));
            this.cmbMsgType.addItems("餐饮美食", 1);
            this.cmbMsgType.addItems("娱乐天地", 2);
            this.cmbMsgType.addItems("生活服务", 3);
            this.cmbMsgType.addItems("走马灯", 4);
            this.cmbMsgType.addItems("调度信息", 5);
            this.cmbMsgType.SelectedValue = 1;
        }

 private void itmZBDistributary_Load(object sender, EventArgs e)
        {
            try
            {
                this.iniForm();
            }
            catch
            {
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}

