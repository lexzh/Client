namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class JTBSetCarNumberAndColor : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBSetCarNumberAndColor(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.cmbCarColor.SelectedIndex = 0;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.icar_SetCommonCmdTraffic(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
            if (base.txtCarNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入车牌号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                base.txtCarNo.Focus();
                return false;
            }
            if (Encoding.GetEncoding("gb2312").GetByteCount(base.txtCarNo.Text) > 18)
            {
                MessageBox.Show("您输入的驾驶员号太长了!");
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.CarNumber = this.txtCarNumber.Text;
            this.m_SimpleCmd.CColor = (this.cmbCarColor.SelectedIndex == (this.cmbCarColor.Items.Count - 1)) ? 9 : (this.cmbCarColor.SelectedIndex + 1);
            return true;
        }

 private void txtCarNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '\b')) && (e.KeyChar != '\r'))
            {
                e.Handled = true;
            }
        }
    }
}

