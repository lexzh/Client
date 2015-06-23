namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Library;

    public partial class itmCancelRegionAlarm : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();
        private string m_sTitle = "";

        public itmCancelRegionAlarm(CmdParam.OrderCode OrderCode, string sTitle)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.m_sTitle = sTitle;
            if ((OrderCode == CmdParam.OrderCode.取消报警区域值) && sTitle.Equals("取消多功能区域报警"))
            {
                this.iRegionFeature = 1;
            }
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
            foreach (string str in this.txtAreaId.Text.Trim().Split(new char[] { '\\' }))
            {
                if (!string.IsNullOrEmpty(str) && !Check.isNumeric(str, Check.NumType.sByte))
                {
                    MessageBox.Show(this.lblAreaId.Text.Trim(new char[] {(char)65306 }) + "超过指定范围！(0=<x<=64)");
                    this.txtAreaId.Focus();
                    return false;
                }
            }
            string str2 = this.txtAreaId.Text.Trim();
            if (string.IsNullOrEmpty(str2) && (base.OrderCode == CmdParam.OrderCode.取消偏移路线报警))
            {
                DataTable table = RemotingClient.Car_GetAlarmPathDotFromGisCar(base.sCarId);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    foreach (string str4 in table.Rows[0]["AlarmPathDot"].ToString().Split(new char[] { '*' }))
                    {
                        string[] strArray3 = str4.Split(new char[] { '\\' });
                        if (strArray3.Length >= 2)
                        {
                            str2 = str2 + strArray3[0] + @"\";
                        }
                    }
                }
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.RegionIds = str2.Trim(new char[] { '\\' });
            return true;
        }

        private void itmCancelRegionAlarm_Load(object sender, EventArgs e)
        {
            this.Text = this.m_sTitle;
            this.setGroupText();
        }

        private void setGroupText()
        {
            if (base.OrderCode == CmdParam.OrderCode.取消偏移路线报警)
            {
                this.lblAreaId.Text = "路线ID：";
                this.grpCancelParam.Text = "取消路线报警参数";
            }
        }

        private void txtAreaId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != '\\')) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

