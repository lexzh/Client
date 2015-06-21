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

    public partial class m2mLedSetLight : CarForm
    {
        private int iMaxSendLists = 10;
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mLedSetLight(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.initCmbLight();
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

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            if (this.lvLedLight.Items.Count <= 0)
            {
                MessageBox.Show("时间列表不能为空！");
                return false;
            }
            ArrayList list = new ArrayList();
            string[] strArray = new string[this.lvLedLight.Items.Count];
            for (int i = 0; i < this.lvLedLight.Items.Count; i++)
            {
                strArray[i] = this.lvLedLight.Items[i].Tag.ToString();
            }
            list.Add(strArray);
            this.m_SimpleCmd.CmdParams = list;
            return true;
        }

        private void initCmbLight()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.cmbLight.addItems(i, i);
            }
        }

 private void m2mLedSetLight_Load(object sender, EventArgs e)
        {
            this.dt = new DataTable();
            this.dt.Columns.Add("StartTime", typeof(string));
            this.dt.Columns.Add("EndTime", typeof(string));
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            this.lvLedLight.Focus();
            if (this.dtpBeginTime.Value.TimeOfDay > this.dtpEndTime.Value.TimeOfDay)
            {
                MessageBox.Show("开始时间大于结束时间");
                this.dtpBeginTime.Focus();
            }
            else
            {
                string str = this.dtpBeginTime.Value.ToString("HH:mm:ss");
                string str2 = this.dtpEndTime.Value.ToString("HH:mm:ss");
                string str3 = string.Format("{0}～{1}", str, str2);
                if (this.lvLedLight.Items.Count >= this.iMaxSendLists)
                {
                    MessageBox.Show(string.Format("时间段已达到{0}个", this.iMaxSendLists));
                }
                else if (this.checkTimeIsRepeat(str, str2))
                {
                    MessageBox.Show("添加的时间段已存在");
                    this.dtpBeginTime.Focus();
                }
                else
                {
                    ListViewItem item = new ListViewItem {
                        Text = string.Format("时间：{0}；亮度：{1}", str3, this.cmbLight.SelectedValue),
                        Name = str3,
                        Tag = string.Format("{0},{1},{2}", str, str2, this.cmbLight.SelectedValue.ToString())
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

