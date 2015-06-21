namespace Client.JTB
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBInformationService : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBInformationService(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
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
            if (this.cmbInformationType.SelectedIndex < 0)
            {
                MessageBox.Show("请选择信息类型!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.txtContent.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入信息内容!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.InfoServiceType = Convert.ToInt32(this.cmbInformationType.SelectedValue);
            this.m_SimpleCmd.InforServiceText = this.txtContent.Text.Trim();
            return true;
        }

 private void JTBInformationService_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                table = RemotingClient.ExecSql("Select ID,MsgName From GpsJTBMsgParam Where MsgType='2'");
                this.cmbInformationType.DisplayMember = "MsgName";
                this.cmbInformationType.ValueMember = "ID";
                this.cmbInformationType.DataSource = table;
                if (this.cmbInformationType.Items.Count > 0)
                {
                    this.cmbInformationType.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("SQL获取数据出错", exception.Message);
            }
        }
    }
}

