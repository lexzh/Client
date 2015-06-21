namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class m2mCancelRegionAlarm : CarForm
    {
        private int m_MaxId = 64;
        private SimpleCmd m_SimpleCmd = new SimpleCmd();
        private string m_sTitle = "";

        public m2mCancelRegionAlarm(CmdParam.OrderCode OrderCode)
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

        private void cbxExpandRegion_CheckedChanged(object sender, EventArgs e)
        {
            this.chkLstArea.Enabled = this.cbxExpandRegion.Checked;
        }

 private bool getParam()
        {
            if (this.chkLstArea.Count > this.m_MaxId)
            {
                MessageBox.Show(string.Concat(new object[] { this.lblAreaId.Text.Trim(new char[] { (char)65306 }), "超过指定范围！(0=<x<=", this.m_MaxId, ")" }));
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            string str = "";
            if (base.OrderCode == CmdParam.OrderCode.取消报警区域值)
            {
                if (!this.cbxExpandRegion.Checked && !this.cbxMainRegion.Checked)
                {
                    MessageBox.Show("主区域与扩展区域必须选中至少一个！");
                    return false;
                }
                if (this.cbxMainRegion.Checked)
                {
                    str = "0";
                }
                if (this.cbxExpandRegion.Checked)
                {
                    foreach (CheckBoxItem item in this.chkLstArea.Items)
                    {
                        if (item.Checked)
                        {
                            str = str + @"\" + item.Name;
                        }
                    }
                }
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("未选中区域ID！");
                    return false;
                }
                this.m_SimpleCmd.RegionIds = str.Trim(new char[] { '\\' });
            }
            return true;
        }

 private void itmCancelRegionAlarm_Load(object sender, EventArgs e)
        {
            this.Text = this.m_sTitle;
            this.setGroupText();
        }

        private void setGroupText()
        {
            this.chkLstArea.Clear();
            if (base.OrderCode == CmdParam.OrderCode.取消报警区域值)
            {
                DataTable table = RemotingClient.Car_GetRegionInfo(base.sCarId, this.iRegionFeature);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["NewRegionId"].ToString()) && !"0".Equals(row["NewRegionId"].ToString()))
                        {
                            CheckBoxItem chk = new CheckBoxItem {
                                Text = row["RegionName"].ToString(),
                                Name = row["NewRegionId"].ToString()
                            };
                            this.chkLstArea.Add(chk);
                        }
                    }
                }
                this.chkLstArea.Enabled = this.cbxExpandRegion.Checked;
            }
        }
    }
}

