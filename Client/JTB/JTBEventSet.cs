namespace Client.JTB
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBEventSet : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();
        private string sInterval = " UNION ALL select '[A]', '[B]', '{0}', '{1}' ";
        private string sIntervalAll = "";
        private string sSql = " update GpsJTBMsgParam set MsgName = '{0}' where ID = '{1}' and MsgType = '{2}'; ";
        private string strInterval = " delete from GpsCarSetParamEx where carid = '[A]' and MsgType = '[B]'; insert into GpsCarSetParamEx(carid, MsgType, MsgID, Param) select '[A]', '[B]', '{0}', '{1}' ";
        private string strSql = "";

        public JTBEventSet(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.cmbSetType.Items.Clear();
            if (base.OrderCode == CmdParam.OrderCode.事件设置)
            {
                this.cmbSetType.Items.AddRange(new object[] { "删除终端现有所有事件", "更新事件", "追加事件", "修改事件", "删除特定几项事件" });
                this.Interval.Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.点播菜单设置)
            {
                this.cmbSetType.Items.AddRange(new object[] { "删除终端全部信息项", "更新菜单", "追加菜单", "修改菜单" });
                this.Interval.Visible = true;
            }
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                if (!string.IsNullOrEmpty(this.strSql))
                {
                    base.reResult = RemotingClient.ExecNoQuery(this.strSql);
                    if (base.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(base.reResult.ErrorMsg);
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(this.sIntervalAll) && this.Interval.Visible)
                {
                    foreach (string str in base.sCarId.Split(new char[] { ',' }))
                    {
                        int num2 = 1537;
                        base.reResult = RemotingClient.ExecNoQuery(this.sIntervalAll.Replace("[A]", str).Replace("[B]", num2.ToString()));
                        if (base.reResult.ResultCode != 0L)
                        {
                            MessageBox.Show(base.reResult.ErrorMsg);
                            return;
                        }
                    }
                }
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

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in (IEnumerable) this.dgvEventList.Rows)
            {
                row.Cells["选择"].Value = this.chkCheckAll.Checked;
            }
        }

        private void cmbSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvEventList.Columns["选择"].ReadOnly = false;
            this.dgvEventList.Columns["内容"].ReadOnly = false;
            this.dgvEventList.Columns["EditID"].ReadOnly = false;
            this.chkCheckAll.Visible = true;
            if (this.cmbSetType.SelectedIndex == 0)
            {
                this.dgvEventList.Columns["选择"].ReadOnly = true;
                this.dgvEventList.Columns["EditID"].ReadOnly = true;
                this.chkCheckAll.Visible = false;
                (this.dgvEventList.DataSource as DataTable).DefaultView.RowFilter = "isSet='true'";
            }
            else if (this.cmbSetType.SelectedIndex == 1)
            {
                (this.dgvEventList.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            else if (this.cmbSetType.SelectedIndex == 2)
            {
                (this.dgvEventList.DataSource as DataTable).DefaultView.RowFilter = "";
                foreach (DataGridViewRow row in (IEnumerable) this.dgvEventList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["isSet"].Value))
                    {
                        row.Cells["选择"].Value = true;
                        row.Cells["选择"].ReadOnly = true;
                        row.Cells["EditID"].ReadOnly = true;
                        row.Cells["内容"].ReadOnly = true;
                    }
                }
            }
            else if (this.cmbSetType.SelectedIndex == 3)
            {
                (this.dgvEventList.DataSource as DataTable).DefaultView.RowFilter = "isSet='true'";
                this.dgvEventList.Columns["EditID"].ReadOnly = true;
            }
            else if (this.cmbSetType.SelectedIndex == 4)
            {
                (this.dgvEventList.DataSource as DataTable).DefaultView.RowFilter = "isSet='true'";
                this.dgvEventList.Columns["EditID"].ReadOnly = true;
            }
            (this.dgvEventList.DataSource as DataTable).RejectChanges();
        }

        private void dgvEventList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

 private bool getParam()
        {
            if (this.IsIDRepeat())
            {
                return false;
            }
            int num = 0;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            bool flag = true;
            if (this.cmbSetType.SelectedIndex > 0)
            {
                if (this.cmbSetType.SelectedIndex == 2)
                {
                    foreach (DataGridViewRow row in (IEnumerable) this.dgvEventList.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["选择"].Value) && !Convert.ToBoolean(row.Cells["isSet"].Value))
                        {
                            num++;
                            builder2.Append(row.Cells["内容"].Value.ToString().Replace(",", "，") + ",");
                            builder.Append(row.Cells["EditID"].Value.ToString().Replace(",", "，") + ",");
                            if (this.Interval.Visible)
                            {
                                int num3;
                                if (!int.TryParse(row.Cells["Interval"].Value.ToString(), out num3) || (num3 < 0))
                                {
                                    MessageBox.Show("发送间隔输入错误，请修改。");
                                    return false;
                                }
                                if (flag)
                                {
                                    flag = false;
                                    this.sIntervalAll = string.Format(this.strInterval, row.Cells["ID"].Value, row.Cells["Interval"].Value);
                                }
                                else
                                {
                                    this.sIntervalAll = this.sIntervalAll + string.Format(this.sInterval, row.Cells["ID"].Value, row.Cells["Interval"].Value);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row2 in (IEnumerable) this.dgvEventList.Rows)
                    {
                        if (Convert.ToBoolean(row2.Cells["选择"].Value))
                        {
                            num++;
                            builder2.Append(row2.Cells["内容"].Value.ToString().Replace(",", "，") + ",");
                            builder.Append(row2.Cells["EditID"].Value.ToString().Replace(",", "，") + ",");
                            if (this.Interval.Visible)
                            {
                                int num4;
                                if (!int.TryParse(row2.Cells["Interval"].Value.ToString(), out num4) || (num4 < 0))
                                {
                                    MessageBox.Show("发送间隔输入错误，请修改。");
                                    return false;
                                }
                                if (flag)
                                {
                                    flag = false;
                                    this.sIntervalAll = string.Format(this.strInterval, row2.Cells["ID"].Value, row2.Cells["Interval"].Value);
                                }
                                else
                                {
                                    this.sIntervalAll = this.sIntervalAll + string.Format(this.sInterval, row2.Cells["ID"].Value, row2.Cells["Interval"].Value);
                                }
                            }
                        }
                    }
                }
            }
            DataTable dataSource = this.dgvEventList.DataSource as DataTable;
            this.m_SimpleCmd.m_Params = this.m_SimpleCmd.m_ParamsReport = "";
            if (this.cmbSetType.SelectedIndex == 0)
            {
                this.m_SimpleCmd.m_Params = this.m_SimpleCmd.m_ParamsReport = " ";
            }
            else if (this.cmbSetType.SelectedIndex == 1)
            {
                foreach (DataRow row3 in dataSource.Rows)
                {
                    if (row3["Flag"].Equals(true))
                    {
                        this.m_SimpleCmd.m_Params = this.m_SimpleCmd.m_Params + (this.m_SimpleCmd.m_ParamsReport = row3["ID"].ToString() + ":" + row3["EditID"].ToString() + ",");
                        this.strSql = this.strSql + string.Format(this.sSql, row3["MsgName"].ToString(), row3["ID"].ToString(), this.MsgType);
                    }
                }
            }
            else if (this.cmbSetType.SelectedIndex == 2)
            {
                foreach (DataRow row4 in dataSource.Rows)
                {
                    if (row4["Flag"].Equals(true))
                    {
                        this.m_SimpleCmd.m_Params = this.m_SimpleCmd.m_Params + (this.m_SimpleCmd.m_ParamsReport = row4["ID"].ToString() + ":" + row4["EditID"].ToString() + ",");
                        this.strSql = this.strSql + string.Format(this.sSql, row4["MsgName"].ToString(), row4["ID"].ToString(), this.MsgType);
                    }
                    if (row4["isSet"].Equals(true))
                    {
                        num2++;
                    }
                }
            }
            else if (this.cmbSetType.SelectedIndex == 3)
            {
                foreach (DataRow row5 in dataSource.Rows)
                {
                    if (row5["isSet"].Equals(true))
                    {
                        this.m_SimpleCmd.m_Params = this.m_SimpleCmd.m_Params + (this.m_SimpleCmd.m_ParamsReport = row5["ID"].ToString() + ":" + row5["EditID"].ToString() + ",");
                        this.strSql = this.strSql + string.Format(this.sSql, row5["MsgName"].ToString(), row5["ID"].ToString(), this.MsgType);
                    }
                }
            }
            else if (this.cmbSetType.SelectedIndex == 4)
            {
                foreach (DataRow row6 in dataSource.Rows)
                {
                    if (row6["Flag"].Equals(false) && row6["isSet"].Equals(true))
                    {
                        this.m_SimpleCmd.m_Params = this.m_SimpleCmd.m_Params + (this.m_SimpleCmd.m_ParamsReport = row6["ID"].ToString() + ":" + row6["EditID"].ToString() + ",");
                        this.strSql = this.strSql + string.Format(this.sSql, row6["MsgName"].ToString(), row6["ID"].ToString(), this.MsgType);
                    }
                }
            }
            if ((num == 0) && (this.cmbSetType.SelectedIndex > 0))
            {
                MessageBox.Show("请选择列表!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (((num + num2) > 20) && (this.cmbSetType.SelectedIndex > 0))
            {
                MessageBox.Show("设置数量为" + (num + num2) + ",已超过20，请重新选择!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            if (base.OrderCode == CmdParam.OrderCode.事件设置)
            {
                this.m_SimpleCmd.EventType = this.cmbSetType.SelectedIndex;
                this.m_SimpleCmd.ENums = num;
                this.m_SimpleCmd.EventID = builder.ToString();
                this.m_SimpleCmd.EventContent = builder2.ToString();
            }
            else if (base.OrderCode == CmdParam.OrderCode.点播菜单设置)
            {
                this.m_SimpleCmd.InforMenuType = this.cmbSetType.SelectedIndex;
                this.m_SimpleCmd.InforItemNums = num;
                this.m_SimpleCmd.InforMenuIType = builder.ToString();
                this.m_SimpleCmd.InforMenuContent = builder2.ToString();
            }
            return true;
        }

 private bool IsIDRepeat()
        {
            DataTable dataSource = this.dgvEventList.DataSource as DataTable;
            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                DataRow row = dataSource.Rows[i];
                if (Convert.ToBoolean(row["Flag"]))
                {
                    int num2;
                    string str = row["EditID"].ToString();
                    if (string.IsNullOrEmpty(str))
                    {
                        MessageBox.Show("下发ID不能为空。");
                        return true;
                    }
                    if (!int.TryParse(str, out num2) || (num2 < 0))
                    {
                        MessageBox.Show("ID只能为正整数。");
                        return true;
                    }
                    for (int j = i + 1; j < dataSource.Rows.Count; j++)
                    {
                        DataRow row2 = dataSource.Rows[j];
                        if (Convert.ToBoolean(row2["Flag"]))
                        {
                            string str2 = row2["EditID"].ToString();
                            if (str.Equals(str2))
                            {
                                MessageBox.Show("下发ID不能相同。");
                                return true;
                            }
                            if (!int.TryParse(str2, out num2) || (num2 < 0))
                            {
                                MessageBox.Show("ID只能为正整数。");
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void JTBEventSet_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            try
            {
                if (base.OrderCode == CmdParam.OrderCode.事件设置)
                {
                    this.grpWatchProperty.Text = "事件参数设置";
                    table = RemotingClient.ExecSql("Select ID,MsgName From GpsJTBMsgParam Where MsgType='1'");
                    this.MsgType = 1;
                }
                else if (base.OrderCode == CmdParam.OrderCode.点播菜单设置)
                {
                    this.grpWatchProperty.Text = "点播菜单参数设置";
                    table = RemotingClient.ExecSql("Select ID,MsgName From GpsJTBMsgParam Where MsgType='2'");
                    this.MsgType = 2;
                }
                DataColumn column = new DataColumn("Flag", typeof(bool)) {
                    DefaultValue = false
                };
                DataColumn column2 = new DataColumn("isSet", typeof(bool)) {
                    DefaultValue = false
                };
                DataColumn column3 = new DataColumn("EditID");
                DataColumn column4 = new DataColumn("Interval");
                table.Columns.AddRange(new DataColumn[] { column3, column, column2, column4 });
                string paramData = RemotingClient.GetParamData(base.sCarId, base.OrderCode);
                string format = " select MsgID, Param from GpsCarSetParamEx where carid = '{0}' and MsgType = '{1}' ";
                int num = 1537;
                DataTable table2 = RemotingClient.ExecSql(string.Format(format, base.sCarId, num.ToString()));
                if (!string.IsNullOrEmpty(paramData) && (table != null))
                {
                    string[] strArray = paramData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Hashtable hashtable = new Hashtable();
                    foreach (string str3 in strArray)
                    {
                        string[] strArray2 = str3.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        if (strArray2.Length <= 1)
                        {
                            hashtable[strArray2[0]] = "";
                        }
                        else
                        {
                            hashtable[strArray2[0]] = strArray2[1];
                        }
                    }
                    foreach (DataRow row in table.Rows)
                    {
                        if (hashtable.Contains(row["ID"].ToString()))
                        {
                            row["isSet"] = true;
                            row["Flag"] = true;
                            row["EditID"] = hashtable[row["ID"].ToString()].ToString();
                            if ((table2 != null) && (table2.Rows.Count > 0))
                            {
                                DataRow[] rowArray = table2.Select("MsgID = '" + row["ID"].ToString() + "'");
                                if (rowArray.Length != 0)
                                {
                                    row["Interval"] = rowArray[0]["Param"];
                                }
                            }
                        }
                    }
                }
                this.dgvEventList.DataSource = table;
                (this.dgvEventList.DataSource as DataTable).AcceptChanges();
                this.cmbSetType.SelectedIndex = 1;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("SQL获取数据出错", exception.Message);
            }
        }
    }
}

