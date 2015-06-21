namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmCutPower : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();
        private SimpleCmdEx m_SimpleCmdEx = new SimpleCmdEx();

        public itmCutPower(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                if (base.OrderCode == CmdParam.OrderCode.断电)
                {
                    if (MessageBox.Show("操作将使车辆电路关闭，可能会造成严重后果\r\n确定发送断电命令吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    {
                        return;
                    }
                    AdminDiv div = new AdminDiv();
                    if (div.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
                this.getParam();
                base.reResult = RemotingClient.DownData_SimpleCmdEx(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmdEx);
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

 private void getParam()
        {
            this.m_SimpleCmdEx.CommFlag = (CmdParam.CommMode) int.Parse(this.cmbSendType.SelectedValue.ToString());
            this.m_SimpleCmdEx.OrderCode = base.OrderCode;
            if (base.OrderCode == CmdParam.OrderCode.断电)
            {
                this.m_SimpleCmdEx.StarDateTime = this.dtpEnableDate.Value.ToString("yyyyMMdd") + this.dtpEnableTime.Value.ToString("HHmmss");
            }
        }

 private void itmCutPower_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
        }

        private void setGroupVisible()
        {
            this.cmbSendType.addItems("短信方式", 0);
            this.cmbSendType.addItems("GPRS/CDMA方式", 1);
            this.cmbSendType.addItems("混合方式", 2);
            this.cmbSendType.SelectedValue = 1;
            if (base.OrderCode == CmdParam.OrderCode.断电)
            {
                this.grpEnable.Visible = true;
            }
            else
            {
                this.grpEnable.Visible = false;
            }
        }
    }
}

