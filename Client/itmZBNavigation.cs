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
    using Library;

    public partial class itmZBNavigation : CarForm
    {
        private AppRequest appRequest = new AppRequest();
        private AppRespone appRespone = new AppRespone();
        private object pvArg = new object();

        public itmZBNavigation(CmdParam.OrderCode OrderCode)
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
            if (string.IsNullOrEmpty(this.txtDestinationName.Text))
            {
                MessageBox.Show("请输入目的地名称");
                return false;
            }
            this.appRequest.OrderCode = base.OrderCode;
            this.appRequest.ParamType = base.ParamType;
            this.appRequest.CarValues = base.sValue;
            this.appRequest.CarPw = base.sPw;
            this.appRequest.CommMode = CmdParam.CommMode.混合方式;
            byte[] buffer = Check.ConvertLatAndLon(this.Longitude);
            byte[] buffer2 = Check.ConvertLatAndLon(this.Latitude);
            byte[] bytes = Encoding.Unicode.GetBytes(this.txtDestinationName.Text);
            byte[] array = new byte[(buffer.Length + buffer2.Length) + bytes.Length];
            int index = 0;
            buffer.CopyTo(array, index);
            index += buffer.Length;
            buffer2.CopyTo(array, index);
            index += buffer2.Length;
            bytes.CopyTo(array, index);
            this.pvArg = array;
            return true;
        }

        private void iniForm()
        {
            this.txtLonLat.Text = string.Format("{0},{1}", decimal.Parse(this.Longitude).ToString("0.000000"), decimal.Parse(this.Latitude).ToString("0.000000"));
        }

 private void itmScreenMess_Load(object sender, EventArgs e)
        {
            try
            {
                this.iniForm();
            }
            catch
            {
            }
        }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}

