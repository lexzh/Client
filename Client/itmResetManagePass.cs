namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmResetManagePass : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmResetManagePass(CmdParam.OrderCode OrderCode)
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
            if (this.txtPw.Text.Trim().Length <= 0)
            {
                MessageBox.Show("密码不能为空！");
                this.txtPw.Focus();
                return false;
            }
            if (this.txtValidate.Text.Trim().Length <= 0)
            {
                MessageBox.Show("确认密码不能为空！");
                this.txtValidate.Focus();
                return false;
            }
            if (this.txtPw.Text.Trim() != this.txtValidate.Text.Trim())
            {
                MessageBox.Show("密码与确认密码不一致！");
                this.txtPw.Focus();
                this.txtPw.SelectAll();
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.FirstPwd = this.txtPw.Text.Trim();
            this.m_SimpleCmd.SecondPwd = this.txtValidate.Text.Trim();
            return true;
        }

 private void txtPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

