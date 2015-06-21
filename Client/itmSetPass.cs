namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmSetPass : FixedForm
    {
        public Button btnCancel;
        public Button btnOK;
        private int iPwdMinLen = 6;
        private int iPwdMinStrong = 2;

        public itmSetPass()
        {
            this.InitializeComponent();
            this.txtUserId.Text = Variable.sUserId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string str = this.txtUserId.Text.Trim();
            string str2 = this.txtOldPassword.Text.Trim();
            string pwd = this.txtNewPassword.Text.Trim();
            string replypwd = this.txtConfirmPassword.Text.Trim();
            if (this.txtUserId.Enabled && string.IsNullOrEmpty(str))
            {
                MessageBox.Show("用户名不能为空！");
                this.clearPwd();
            }
            else if (string.IsNullOrEmpty(str2))
            {
                MessageBox.Show("原密码不能为空！");
                this.clearPwd();
            }
            else
            {
                string errMsg = "";
                if (!PublicClass.Check.CheckStrongPwd(ref errMsg, pwd, replypwd, this.iPwdMinLen, this.txtNewPassword.MaxLength, this.iPwdMinStrong))
                {
                    MessageBox.Show(errMsg);
                    this.clearPwd();
                }
                else
                {
                    if (this.bLoginForm)
                    {
                        errMsg = RemotingClient.ModifyUserPassword(str, str2, pwd);
                    }
                    else
                    {
                        errMsg = RemotingClient.User_ChangePassword(Variable.sUserId, str2, pwd);
                    }
                    if (errMsg.Length > 0)
                    {
                        MessageBox.Show(errMsg);
                        this.clearPwd();
                    }
                    else
                    {
                        Variable.sPassword = pwd;
                        Record.execFileRecord("修改密码", "成功！");
                        MessageBox.Show("密码已修改！");
                        base.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void clearPwd()
        {
            this.txtOldPassword.Text = "";
            this.txtNewPassword.Text = "";
            this.txtConfirmPassword.Text = "";
            this.txtOldPassword.Focus();
        }

 private void itmSetPass_Load(object sender, EventArgs e)
        {
            this.txtUserId.Enabled = this.bLoginForm;
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string errMsg = "";
            string pwd = this.txtNewPassword.Text.Trim();
            string replypwd = this.txtConfirmPassword.Text.Trim();
            bool flag = PublicClass.Check.CheckPwd(ref errMsg, pwd, replypwd);
            this.pnlOK.Visible = flag;
            this.pnlNG.Visible = !flag;
            Color transparent = Color.Transparent;
            if (pwd.Length >= this.iPwdMinLen)
            {
                int pwdStrong = PublicClass.Check.GetPwdStrong(pwd);
                if (pwdStrong >= this.iPwdMinStrong)
                {
                    transparent = Color.SpringGreen;
                }
                else
                {
                    transparent = Color.Red;
                }
                for (int i = 1; i <= 3; i++)
                {
                    if (pwdStrong >= i)
                    {
                        this.pnlPassword.Controls[string.Format("pnlColor{0}", i)].BackColor = transparent;
                    }
                    else
                    {
                        this.pnlPassword.Controls[string.Format("pnlColor{0}", i)].BackColor = Color.Transparent;
                    }
                }
            }
            else
            {
                for (int j = 1; j <= 3; j++)
                {
                    this.pnlPassword.Controls[string.Format("pnlColor{0}", j)].BackColor = Color.Transparent;
                }
            }
        }

        public bool IsLoginForm
        {
            get
            {
                return this.bLoginForm;
            }
            set
            {
                this.bLoginForm = value;
            }
        }
    }
}

