namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmPointToPoint : CarForm
    {
        private RemoteDial m_RemoteDial = new RemoteDial();

        public itmPointToPoint(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.DownData_RemoteDial(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_RemoteDial);
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
            string str = this.txtTel.Text.Trim();
            string str2 = this.txtMsgValue.Text.Trim();
            if (str.Length <= 0)
            {
                MessageBox.Show("电话号码不能为空！");
                this.txtTel.Focus();
                return false;
            }
            if (str2.Length <= 0)
            {
                MessageBox.Show("发送内容不能为空！");
                this.txtMsgValue.Focus();
                return false;
            }
            this.m_RemoteDial.OrderCode = base.OrderCode;
            this.m_RemoteDial.strPhone = str;
            this.m_RemoteDial.strMsg = str2;
            return true;
        }

 private void PointToPoint_Load(object sender, EventArgs e)
        {
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

