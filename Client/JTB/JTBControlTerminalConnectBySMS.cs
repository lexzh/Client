namespace Client.JTB
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBControlTerminalConnectBySMS : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBControlTerminalConnectBySMS(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this._appServerList = new AutoDropDown(this.lboxApnAccessMode);
            this.grpWatchProperty.Controls.Add(this._appServerList);
        }

        private void btnGetAuthCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnGetAuthCode.Enabled = false;
                DataTable table = RemotingClient.ExecSql("SELECT TOP 1 [SimNum],[CarNum],[AuthCode],[TerminalType] FROM [GpsJTBSyndata] WHERE SimNum='" + MainForm.myCarList.SelectedSimNum + "'  Order by CreateDate Desc");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    this.txtAuthCode.Text = (table.Rows[0]["AuthCode"] != null) ? table.Rows[0]["AuthCode"].ToString() : "";
                }
                else
                {
                    MessageBox.Show("未能获取到鉴权码，请重新获取!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("通过特权短信控制终端连接指定的中心-->", exception.Message);
            }
            finally
            {
                this.btnGetAuthCode.Enabled = true;
            }
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

        private void btnShowDropControl_Click(object sender, EventArgs e)
        {
            if (!this._appServerList.Visible)
            {
                System.Drawing.Point location = this.txtApnAccessMode.Location;
                this._appServerList.ShowDropDown(new System.Drawing.Point(location.X, location.Y + this.txtApnAccessMode.Height));
            }
        }

 private bool getParam()
        {
            if (this.txtAuthCode.Text.Trim().Length == 0)
            {
                MessageBox.Show(this.lblAuthCode.Text.Replace("：", "") + "不能为空，请点击\"获取\"按钮!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtAuthCode.Focus();
                return false;
            }
            if (this.txtApnAccessMode.Text.Trim().Length == 0)
            {
                MessageBox.Show(this.lblApnAccessMode.Text.Replace("：", "") + "不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtApnAccessMode.Focus();
                return false;
            }
            if (this.txtServerIp.Text.Trim().Length == 0)
            {
                MessageBox.Show(this.lblServerIp.Text.Replace("：", "") + "不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtServerIp.Focus();
                return false;
            }
            if (!PublicClass.Check.CheckIpAddress(this.txtServerIp.Text))
            {
                MessageBox.Show(this.lblServerIp.Text.Replace("：", "") + "格式有误！");
                this.txtServerIp.Focus();
                return false;
            }
            if (this.txtUser.Text.Trim().Length == 0)
            {
                MessageBox.Show(this.lblUser.Text.Replace("：", "") + "不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtUser.Focus();
                return false;
            }
            if (this.txtPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show(this.lblPwd.Text.Replace("：", "") + "不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtPwd.Focus();
                return false;
            }
            if ((this.numEffectiveTime.Text.Trim().Length == 0) || this.numEffectiveTime.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblEffectiveTime.Text.Replace("：", "") + "输入有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numTcpPort.Focus();
                return false;
            }
            if ((this.numTcpPort.Text.Trim().Length == 0) || this.numTcpPort.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblTcpPort.Text.Replace("：", "") + "输入有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numTcpPort.Focus();
                return false;
            }
            if ((this.numUdpPort.Text.Trim().Length == 0) || this.numUdpPort.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblUdpPort.Text.Replace("：", "") + "输入有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numUdpPort.Focus();
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.ConnectionType = this.rdoOrignalServer.Checked ? 1 : 0;
            this.m_SimpleCmd.AuthCode = this.txtAuthCode.Text;
            this.m_SimpleCmd.APNAddr = this.txtApnAccessMode.Text;
            this.m_SimpleCmd.ConnectionIP = this.txtServerIp.Text;
            this.m_SimpleCmd.ConnectionUser = this.txtUser.Text;
            this.m_SimpleCmd.ConnectionPassword = this.txtPwd.Text;
            this.m_SimpleCmd.TCPPort = this.numTcpPort.Value.ToString();
            this.m_SimpleCmd.UDPPort = this.numUdpPort.Value.ToString();
            this.m_SimpleCmd.ConnectionTout = (int) this.numEffectiveTime.Value;
            return true;
        }

 private void lboxApnAccessMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtApnAccessMode.Text = this.lboxApnAccessMode.SelectedItem.ToString();
            this._appServerList.HideDropDown();
        }

        private void txtApnAccessMode_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

