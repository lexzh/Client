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

    public partial class JTBSendQuestion : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();
        public static Hashtable sOrderId = new Hashtable();
        private BindingSource source = new BindingSource();

        public JTBSendQuestion(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            if (this.getParam())
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue))
                {
                    base.reResult = RemotingClient.icar_SetCommonCmdTraffic(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                    if (base.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(base.reResult.ErrorMsg);
                    }
                    else
                    {
                        string str = MainForm.myCarList.execChangeCarValue((int) base.ParamType, 1, base.sValue);
                        sOrderId[str] = base.reResult.OrderIDParam.Split(new char[] { '|' })[0];
                        base.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void cmbQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.source.DataSource != null) && (this.cmbQuestion.SelectedItem != null))
            {
                this.source.Filter = "ParentID='" + this.cmbQuestion.SelectedValue.ToString() + "'";
            }
        }

 private bool getParam()
        {
            if (this.cmbQuestion.SelectedItem == null)
            {
                MessageBox.Show("请选择提问问题!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (((!this.chkAdFlag.Checked && !this.chkControlFlag.Checked) && (!this.chkHandFlag.Checked && !this.chkTtsFlag.Checked)) && !this.chkUrgencyFlag.Checked)
            {
                MessageBox.Show("请选择提问类型!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            int num = 0;
            if (this.chkUrgencyFlag.Checked)
            {
                num |= Convert.ToInt32(this.chkUrgencyFlag.Tag);
            }
            if (this.chkControlFlag.Checked)
            {
                num |= Convert.ToInt32(this.chkControlFlag.Tag);
            }
            if (this.chkHandFlag.Checked)
            {
                num |= Convert.ToInt32(this.chkHandFlag.Tag);
            }
            if (this.chkTtsFlag.Checked)
            {
                num |= Convert.ToInt32(this.chkTtsFlag.Tag);
            }
            if (this.chkAdFlag.Checked)
            {
                num |= Convert.ToInt32(this.chkAdFlag.Tag);
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.QuestionFlag = num;
            this.m_SimpleCmd.Question = ((DataRowView) this.cmbQuestion.SelectedItem).Row["MsgName"].ToString();
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            this.txtanswerID.Text = "";
            foreach (DataGridViewRow row in (IEnumerable) this.dgvAnswer.Rows)
            {
                builder.Append(row.Cells[0].Value.ToString() + ",");
                builder2.Append(row.Cells[1].Value.ToString() + ",");
                string text = this.txtanswerID.Text;
                this.txtanswerID.Text = text + row.Cells["ID"].Value.ToString() + "、" + row.Cells[1].Value.ToString() + ",";
            }
            this.txtanswerID.Text = this.txtanswerID.Text.Trim(new char[] { ',' });
            if ((builder.Length == 0) || (builder2.Length == 0))
            {
                MessageBox.Show("选择的问题没有答案，请选择其他问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_SimpleCmd.ResultID = builder.ToString().Trim(new char[] { ',' });
            this.m_SimpleCmd.ResultContent = builder2.ToString().Trim(new char[] { ',' });
            return true;
        }

 private void JTBSendQuestion_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbQuestion.DisplayMember = "MsgName";
                this.cmbQuestion.ValueMember = "ID";
                DataTable table = new DataTable();
                table = RemotingClient.ExecSql("Select ID,MsgName From GpsJTBMsgParam Where MsgType='3'");
                DataTable table2 = new DataTable();
                DataColumn column = new DataColumn("id");
                DataColumn column2 = new DataColumn("MsgName");
                table2.Columns.AddRange(new DataColumn[] { column, column2 });
                DataTable table3 = new DataTable();
                DataColumn column3 = new DataColumn("id");
                DataColumn column4 = new DataColumn("parentid");
                DataColumn column5 = new DataColumn("Answer");
                table3.Columns.AddRange(new DataColumn[] { column3, column5, column4 });
                if ((table != null) && (table.Rows.Count > 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        string str = "";
                        string[] strArray = row["Msgname"].ToString().Split(new char[] { ',' });
                        if (strArray.Length > 1)
                        {
                            str = strArray[0];
                            DataRow row2 = table2.NewRow();
                            row2["id"] = row["id"];
                            row2["MsgName"] = str;
                            table2.Rows.Add(row2);
                            for (int i = 1; i < strArray.Length; i++)
                            {
                                DataRow row3 = table3.NewRow();
                                row3["id"] = i;
                                row3["parentid"] = row["id"];
                                row3["Answer"] = strArray[i];
                                table3.Rows.Add(row3);
                            }
                        }
                        str = string.Empty;
                    }
                }
                this.source.DataSource = table3;
                this.cmbQuestion.DataSource = table2;
                if (this.cmbQuestion.Items.Count > 0)
                {
                    this.cmbQuestion.SelectedIndex = 0;
                }
                this.cmbQuestion_SelectedIndexChanged(null, null);
                this.dgvAnswer.DataSource = table3;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("SQL获取数据出错", exception.Message);
            }
        }
    }
}

