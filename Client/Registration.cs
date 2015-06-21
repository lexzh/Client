namespace Client
{
    //using GlsService;
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Registration : FixedForm
    {
        public Button btnCancel;
        public Button btnOK;

        public Registration()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //this.btnOK.Enabled = false;
            //try
            //{
            //    PasConnectManager.CheckStart();
            //    MessageBox.Show(PasConnectManager.ResultMsg);
            //    this.lblState.Text = PasConnectManager.ResultMsg;
            //}
            //catch (Exception exception)
            //{
            //    Record.execFileRecord("登录验证", exception.Message);
            //    MessageBox.Show(exception.Message);
            //}
            //finally
            //{
            //    this.btnOK.Enabled = true;
            //}
            base.Close();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            //this.txtMachineCode.Text = MachineInfoManager.GetMachineCode();
            //this.txtIp.Text = MachineInfoManager.GetIPAddress();
            //this.lblState.Text = PasConnectManager.ResultMsg;
        }
    }
}

