namespace Client
{
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class AdminDiv : FixedForm
    {
        public Button btnCancel;
        public Button btnOK;
        public Panel pnlBtn;

        public AdminDiv()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string text = this.txtAdmin.Text;
            string inPass = this.txtPw.Text;
            if (text.Length <= 0)
            {
                MessageBox.Show("请输入管理员ID");
            }
            else if (inPass.Length <= 0)
            {
                MessageBox.Show("请输入管理员口令");
            }
            else if (!RemotingClient.LoginSys_CheckUser(text, inPass))
            {
                MessageBox.Show("你没有权限操作");
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }


    }
}