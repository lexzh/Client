namespace Client.JTB
{
    using Client;
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

    public partial class JTBitmCancelRegionAlarm : CarForm
    {
        private int iRegionFeature = 1;
        private int m_MaxId = 64;
        private SimpleCmd m_SimpleCmd = new SimpleCmd();
        private string m_sTitle = "";

        public JTBitmCancelRegionAlarm(CmdParam.OrderCode OrderCode, string stitle)
        {
            this.InitializeComponent();
            this.m_sTitle = stitle;
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

        private void cbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            this.chkLstArea.Enabled = !this.cbAllSelect.Checked;
            this.cbRegionType.Enabled = !this.cbAllSelect.Checked;
            foreach (CheckBoxItem item in this.chkLstArea.Items)
            {
                if (item.Visible)
                {
                    item.Checked = this.cbAllSelect.Checked;
                }
            }
        }

        private void cbRegionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.cbRegionType.SelectedIndex;
            foreach (CheckBoxItem item in this.chkLstArea.Items)
            {
                if ((selectedIndex != 0) && (Convert.ToInt32(item.Tag) != selectedIndex))
                {
                    item.Visible = false;
                }
                else
                {
                    item.Visible = true;
                }
                item.Checked = false;
            }
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
            string str2 = "";
            if (this.cbAllSelect.Checked)
            {
                if (this.cbRegionType.SelectedIndex <= 0)
                {
                    str = @"0\0\0";
                    str2 = @"1\2\3";
                }
                else
                {
                    str = "0";
                    str2 = this.cbRegionType.SelectedIndex.ToString();
                }
            }
            else
            {
                foreach (CheckBoxItem item in this.chkLstArea.Items)
                {
                    if (item.Checked)
                    {
                        str = str + @"\" + item.Name;
                        str2 = str2 + @"\" + item.Tag.ToString();
                    }
                }
            }
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("未选中区域ID！");
                return false;
            }
            this.m_SimpleCmd.RegionIds = str.Trim(new char[] { '\\' });
            this.m_SimpleCmd.RegionTypes = str2.Trim(new char[] { '\\' });
            return true;
        }

        private int GetRegionType(string lanlon)
        {
            int length = lanlon.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
            int num2 = 0;
            switch (length)
            {
                case 1:
                    return 1;

                case 4:
                {
                    string[] strArray = lanlon.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    List<string> list = new List<string>();
                    foreach (string str in strArray)
                    {
                        foreach (string str2 in str.Split(@"\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (!list.Contains(str2))
                            {
                                list.Add(str2);
                            }
                        }
                    }
                    if (list.Count == 4)
                    {
                        num2 = 2;
                    }
                    else
                    {
                        num2 = 3;
                    }
                    list.Clear();
                    list = null;
                    return num2;
                }
            }
            return 3;
        }

 private void JTBitmCancelRegionAlarm_Load(object sender, EventArgs e)
        {
            this.Text = this.m_sTitle;
            this.setGroupText();
        }

        private void setGroupText()
        {
            this.chkLstArea.Clear();
            DataTable table = RemotingClient.Car_GetRegionInfo(base.sCarId, this.iRegionFeature);
            if (table != null)
            {
                DataRow[] rowArray = table.Select("NewRegionId is not null");
                int length = rowArray.Length;
                if ((table != null) && (length > 0))
                {
                    foreach (DataRow row in rowArray)
                    {
                        CheckBoxItem chk = new CheckBoxItem {
                            Text = row["RegionName"].ToString(),
                            Name = row["NewRegionId"].ToString(),
                            Tag = this.GetRegionType(row["RegionDot"].ToString())
                        };
                        this.chkLstArea.Add(chk);
                    }
                }
            }
            this.cbRegionType.SelectedIndex = 0;
        }
    }
}

