namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class m2mLedDelMsg : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mLedDelMsg(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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

        private bool checkTimeIsRepeat(string sStartTime, string sEndTime)
        {
            return (((this.dt != null) && (this.dt.Rows.Count > 0)) && (this.dt.Select("(StartTime<'" + sStartTime + "' and EndTime>'" + sStartTime + "') or (StartTime<'" + sEndTime + "' and EndTime>'" + sEndTime + "') or (StartTime='" + sStartTime + "' and EndTime='" + sEndTime + "')").Length > 0));
        }

        private void chkShowTimeSecond_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            switch (box.Name)
            {
                case "chkShowModel":
                    this.grpShowModel.Enabled = box.Checked;
                    this.grpScreenModel.Enabled = box.Checked;
                    return;

                case "chkShowFont":
                    this.cmbShowFont.Enabled = box.Checked;
                    return;

                case "chkShowSpeed":
                    this.cmbShowSpeed.Enabled = box.Checked;
                    return;

                case "chkInterval":
                    this.numInterval.Enabled = box.Checked;
                    return;

                case "chkShowTimes":
                    this.numShowTimes.Enabled = box.Checked;
                    return;

                case "chkStopTime":
                    this.numStopTime.Enabled = box.Checked;
                    return;

                case "chkLighteness":
                    this.numLighteness.Enabled = box.Checked;
                    return;

                case "chkShowTime":
                    this.pnlShowTime.Enabled = box.Checked;
                    if (!box.Checked)
                    {
                        break;
                    }
                    this.chkShowTimeSecond.Checked = !box.Checked;
                    this.pnlShowTimeSecond.Enabled = !box.Checked;
                    return;

                case "chkShowTimeSecond":
                    this.pnlShowTimeSecond.Enabled = box.Checked;
                    if (box.Checked)
                    {
                        this.chkShowTime.Checked = !box.Checked;
                        this.pnlShowTime.Enabled = !box.Checked;
                    }
                    break;

                default:
                    return;
            }
        }

 private bool getParam()
        {
            string str = "";
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.LED删除指定LED短信)
            {
                string[] strArray = new string[] { this.numLedMsgIndex.Value.ToString() };
                list.Add(strArray);
            }
            else
            {
                int num = 0;
                if (this.chkShowModel.Checked)
                {
                    str = str + "A,";
                    if (this.rdoDrive.Checked)
                    {
                        str = str + "0,";
                    }
                    else if (this.rdoStop.Checked)
                    {
                        str = str + "1,";
                    }
                    else
                    {
                        str = str + "2,";
                    }
                    if (this.rdoLeft.Checked)
                    {
                        str = str + "0,";
                    }
                    else
                    {
                        str = str + "1,";
                    }
                    str = str + ";";
                    num++;
                }
                if (this.chkShowFont.Checked)
                {
                    str = (str + "B,") + this.cmbShowFont.SelectedValue.ToString() + ";";
                    num++;
                }
                if (this.chkShowSpeed.Checked)
                {
                    str = (str + "C,") + this.cmbShowSpeed.SelectedValue.ToString() + ";";
                    num++;
                }
                if (this.chkInterval.Checked)
                {
                    str = (str + "D,") + this.numInterval.Value.ToString() + ";";
                    num++;
                }
                if (this.chkShowTimes.Checked)
                {
                    str = (str + "E,") + this.numShowTimes.Value.ToString() + ";";
                    num++;
                }
                if (this.chkStopTime.Checked)
                {
                    str = (str + "F,") + this.numStopTime.Value.ToString() + ";";
                    num++;
                }
                if (this.chkLighteness.Checked)
                {
                    str = (str + "G,") + this.numLighteness.Value.ToString() + ";";
                    num++;
                }
                if (this.chkShowTime.Checked)
                {
                    if (this.dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
                    {
                        MessageBox.Show("显示时段：开始时间大于结束时间");
                        this.dtpStartDate.Focus();
                        return false;
                    }
                    if ((this.dtpStartDate.Value.Date == this.dtpEndDate.Value.Date) && (this.dtpStartTime.Value.TimeOfDay > this.dtpEndTime.Value.TimeOfDay))
                    {
                        MessageBox.Show("显示时段：开始时间大于结束时间");
                        this.dtpStartTime.Focus();
                        return false;
                    }
                    string str2 = str + "H,";
                    str = ((str2 + this.dtpStartDate.Value.ToString("yyyy-MM-dd") + "," + this.dtpEndDate.Value.ToString("yyyy-MM-dd") + ",") + this.dtpStartTime.Value.ToString("HH:mm:ss") + "," + this.dtpEndTime.Value.ToString("HH:mm:ss")) + ";";
                    num++;
                }
                if (this.chkShowTimeSecond.Checked)
                {
                    if (this.dtpStartDate2.Value.Date > this.dtpEndDate2.Value.Date)
                    {
                        MessageBox.Show("显示时长：开始日期大于结束日期");
                        this.dtpStartDate2.Focus();
                        return false;
                    }
                    if (this.lvLedLight.Items.Count <= 0)
                    {
                        MessageBox.Show("显示时长：时间列表不能为空！");
                        return false;
                    }
                    string str3 = str + "I,";
                    str = str3 + this.dtpStartDate2.Value.ToString("yyyy-MM-dd") + "," + this.dtpEndDate2.Value.ToString("yyyy-MM-dd") + ",";
                    for (int j = 0; j < this.lvLedLight.Items.Count; j++)
                    {
                        str = str + this.lvLedLight.Items[j].Tag.ToString() + ",";
                    }
                    str = str + ";";
                    num++;
                }
                if (num <= 0)
                {
                    MessageBox.Show("请选择设置属性！");
                    return false;
                }
                string[] strArray2 = new string[num + 2];
                strArray2[0] = this.numLedMsgIndex.Value.ToString();
                strArray2[1] = num.ToString();
                string[] strArray3 = str.Trim(new char[] { ';' }).Split(new char[] { ';' });
                for (int i = 0; i < num; i++)
                {
                    strArray2[i + 2] = strArray3[i].Trim(new char[] { ',' });
                }
                list.Add(strArray2);
            }
            this.m_SimpleCmd.CmdParams = list;
            return true;
        }

 private void m2mLedDelMsg_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
        }

        private void setGroupVisible()
        {
            if (base.OrderCode == CmdParam.OrderCode.LED短信属性设置)
            {
                this.lblDelIndex.Visible = false;
                this.pnlLedMsgParam.Visible = true;
                for (int i = 1; i <= 16; i++)
                {
                    this.cmbShowFont.addItems(i, i);
                }
                this.cmbShowSpeed.addItems("1字/秒", 1);
                this.cmbShowSpeed.addItems("2字/秒", 2);
                this.cmbShowSpeed.addItems("2.5字/秒", 3);
                this.cmbShowSpeed.addItems("3字/秒", 4);
                this.cmbShowSpeed.addItems("3.5字/秒", 5);
                this.cmbShowSpeed.addItems("4字/秒", 6);
                this.cmbShowSpeed.addItems("4.5字/秒", 7);
                this.cmbShowSpeed.addItems("5字/秒", 8);
                this.cmbShowSpeed.addItems("6字/秒", 9);
                this.cmbShowSpeed.addItems("最快速度", 10);
                this.dt = new DataTable();
                this.dt.Columns.Add("StartTime", typeof(string));
                this.dt.Columns.Add("EndTime", typeof(string));
            }
            else if (base.OrderCode == CmdParam.OrderCode.LED删除指定LED短信)
            {
                this.lblDelIndex.Visible = true;
                this.numLedMsgIndex.Minimum = 0M;
                this.numLedMsgIndex.Maximum = 65535M;
                this.numLedMsgIndex.Value = 0M;
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            this.lvLedLight.Focus();
            if (this.dtpStartTime2.Value.TimeOfDay > this.dtpEndTime2.Value.TimeOfDay)
            {
                MessageBox.Show("显示时长：开始时间大于结束时间");
                this.dtpStartTime2.Focus();
            }
            else
            {
                string str = this.dtpStartTime2.Value.ToString("HH:mm:ss");
                string str2 = this.dtpEndTime2.Value.ToString("HH:mm:ss");
                string str3 = string.Format("{0}～{1}", str, str2);
                if (this.checkTimeIsRepeat(str, str2))
                {
                    MessageBox.Show("显示时长：添加的时间段已存在");
                    this.dtpStartTime2.Focus();
                }
                else
                {
                    ListViewItem item = new ListViewItem {
                        Text = string.Format("{0}；", str3),
                        Name = str3,
                        Tag = string.Format("{0},{1}", str, str2)
                    };
                    this.lvLedLight.Items.Add(item);
                    item.Selected = true;
                    if (this.dt != null)
                    {
                        this.dt.Rows.Add(new object[] { str, str2 });
                    }
                }
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.lvLedLight.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请在列表中选择要删除的项");
            }
            else
            {
                string[] strArray = this.lvLedLight.SelectedItems[0].Tag.ToString().Split(new char[] { ',' });
                string str = strArray[0];
                string str2 = strArray[1];
                this.lvLedLight.Items.Remove(this.lvLedLight.SelectedItems[0]);
                if (this.lvLedLight.Items.Count > 0)
                {
                    this.lvLedLight.Items[0].Selected = true;
                }
                if (this.dt != null)
                {
                    DataRow[] rowArray = this.dt.Select("StartTime='" + str + "' and EndTime='" + str2 + "'");
                    if (rowArray.Length > 0)
                    {
                        this.dt.Rows.Remove(rowArray[0]);
                    }
                }
            }
        }
    }
}

