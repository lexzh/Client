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
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBWirelessUpgradeCommand : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBWirelessUpgradeCommand(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this._appServerList = new AutoDropDown(this.lboxApnAccessMode);
            this.grpWatchProperty.Controls.Add(this._appServerList);
        }

        private void btnGetManufatureId_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnGetManufatureId.Enabled = false;
                DataTable table = RemotingClient.ExecSql("SELECT TOP 1 [SimNum],[CarNum],[AuthCode],[ManufacturerID] FROM [GpsJTBSyndata] WHERE SimNum='" + MainForm.myCarList.SelectedSimNum + "'  Order by CreateDate Desc");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    this.txtManufacturerID.Text = (table.Rows[0]["ManufacturerID"] != null) ? table.Rows[0]["ManufacturerID"].ToString() : "";
                }
                else
                {
                    MessageBox.Show("未能获取到制造商ID，请重新获取!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("无线升级命令-->", exception.Message);
            }
            finally
            {
                this.btnGetManufatureId.Enabled = true;
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
            int num;
            if (this.txtManufacturerID.Text.Trim().Length == 0)
            {
                MessageBox.Show(this.lblManufacturerID.Text.Replace("：", "") + "不能为空，请点击\"获取\"按钮!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.txtApnAccessMode.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入" + this.lblApnAccessMode.Text.Replace("：", ""), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtApnAccessMode.Focus();
                return false;
            }
            if (this.txtUpgradeServerIp.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入" + this.lblUpgradeServerIp.Text.Replace("：", ""), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtUpgradeServerIp.Focus();
                return false;
            }
            if (!PublicClass.Check.CheckIpAddress(this.txtUpgradeServerIp.Text))
            {
                MessageBox.Show(this.txtUpgradeServerIp.Text.Replace("：", "") + "格式有误！");
                this.txtUpgradeServerIp.Focus();
                return false;
            }
            if ((this.numTcpPort.Text.Trim().Length == 0) || this.numTcpPort.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblTcpPort.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numTcpPort.Focus();
                return false;
            }
            if ((this.numUdpPort.Text.Trim().Length > 0) && ((!int.TryParse(this.numUdpPort.Text.Trim(), out num) || (num > 65535)) || (num < 0)))
            {
                MessageBox.Show(this.lblUdpPort.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numUdpPort.Focus();
                return false;
            }
            if ((this.numEffectiveTime.Text.Trim().Length == 0) || this.numEffectiveTime.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblEffectiveTime.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numEffectiveTime.Focus();
                return false;
            }
            if (Encoding.GetEncoding("gb2312").GetByteCount(this.txtManufacturerID.Text) > 5)
            {
                MessageBox.Show("您输入的" + this.lblManufacturerID.Text.Replace("：", "") + "太长了!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.APN = this.txtApnAccessMode.Text;
            this.m_SimpleCmd.User = this.txtUser.Text;
            this.m_SimpleCmd.Pwd = this.txtPwd.Text;
            this.m_SimpleCmd.IP = this.txtUpgradeServerIp.Text;
            this.m_SimpleCmd.WirelessTCPPort = this.numTcpPort.Value.ToString("0");
            this.m_SimpleCmd.WirelessUDPPort = this.numUdpPort.Text.Trim();
            this.m_SimpleCmd.MID = this.txtManufacturerID.Text;
            this.m_SimpleCmd.HVer = this.txtHardWareNum.Text;
            this.m_SimpleCmd.SVer = this.txtFirmWareNum.Text;
            this.m_SimpleCmd.UURL = this.txtTerminalUpgradeAddress.Text;
            this.m_SimpleCmd.Tout = (int) this.numEffectiveTime.Value;
            return true;
        }

 private void JTBWirelessUpgradeCommand_Load(object sender, EventArgs e)
        {
        }

        private void lboxApnAccessMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtApnAccessMode.Text = this.lboxApnAccessMode.SelectedItem.ToString();
            this._appServerList.HideDropDown();
        }

        private void txtApnAccessMode_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtManufacturerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

