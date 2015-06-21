namespace Client.JTB
{
    using Client;
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
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBSetTelephoneBook : CarForm
    {
        private BindingSource _source = new BindingSource();
        private TrafficPhoneNumText _trafficePhoneNumText = new TrafficPhoneNumText();

        public JTBSetTelephoneBook(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            this.CreateComboBoxWithEnums(this.dataGridViewEx1.Columns["呼叫类型"]);
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.icar_SetPhoneNumText(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this._trafficePhoneNumText);
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

        private bool chkString(string source)
        {
            Regex regex = new Regex("[＀-￿]");
            return !regex.IsMatch(source);
        }

        private void cmbSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridViewEx1.AllowUserToAddRows = true;
            if (this.dataGridViewEx1.DataSource != null)
            {
                DataTable dataSource = this.dataGridViewEx1.DataSource as DataTable;
                List<DataRow> list = new List<DataRow>();
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if (dataSource.Rows[i].RowState == DataRowState.Added)
                    {
                        list.Add(dataSource.Rows[i]);
                    }
                    else
                    {
                        dataSource.Rows[i].RejectChanges();
                    }
                }
                foreach (DataRow row in list)
                {
                    dataSource.Rows.Remove(row);
                }
            }
            if (this.cmbSetType.SelectedIndex == 2)
            {
                foreach (DataGridViewRow row2 in (IEnumerable) this.dataGridViewEx1.Rows)
                {
                    this.oldColor = row2.DefaultCellStyle.BackColor;
                    if ((row2.Cells["isold"].Value != null) && row2.Cells["isold"].Value.ToString().Equals("1"))
                    {
                        row2.Cells["IsChecked"].ReadOnly = true;
                        row2.Cells["IsChecked"].Value = false;
                        row2.Cells["描述"].ReadOnly = true;
                        row2.Cells["电话号码"].ReadOnly = true;
                        row2.Cells["呼叫类型"].ReadOnly = true;
                        row2.DefaultCellStyle.BackColor = Color.FromArgb(236, 233, 216);
                        row2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 233, 216);
                    }
                }
            }
            else if (this.cmbSetType.SelectedIndex == 3)
            {
                foreach (DataGridViewRow row3 in (IEnumerable) this.dataGridViewEx1.Rows)
                {
                    row3.Cells["IsChecked"].ReadOnly = false;
                    row3.Cells["IsChecked"].Value = false;
                    row3.Cells["描述"].ReadOnly = true;
                    row3.Cells["电话号码"].ReadOnly = false;
                    row3.Cells["呼叫类型"].ReadOnly = false;
                    row3.DefaultCellStyle.BackColor = this.oldColor;
                    row3.DefaultCellStyle.SelectionBackColor = this.oldColor;
                }
                this.dataGridViewEx1.AllowUserToAddRows = false;
            }
            else if (this.cmbSetType.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row4 in (IEnumerable) this.dataGridViewEx1.Rows)
                {
                    row4.Cells["IsChecked"].ReadOnly = true;
                    row4.Cells["IsChecked"].Value = true;
                    row4.Cells["描述"].ReadOnly = true;
                    row4.Cells["电话号码"].ReadOnly = true;
                    row4.Cells["呼叫类型"].ReadOnly = true;
                    row4.DefaultCellStyle.BackColor = this.oldColor;
                    row4.DefaultCellStyle.SelectionBackColor = this.oldColor;
                }
                this.dataGridViewEx1.AllowUserToAddRows = false;
            }
            else if (this.cmbSetType.SelectedIndex == 1)
            {
                foreach (DataGridViewRow row5 in (IEnumerable) this.dataGridViewEx1.Rows)
                {
                    row5.Cells["IsChecked"].ReadOnly = row5.Cells["描述"].ReadOnly = false;
                    row5.Cells["电话号码"].ReadOnly = row5.Cells["呼叫类型"].ReadOnly = false;
                    row5.Cells["IsChecked"].Value = false;
                    row5.DefaultCellStyle.BackColor = this.oldColor;
                    row5.DefaultCellStyle.SelectionBackColor = this.oldColor;
                }
            }
        }

        private void CreateComboBoxWithEnums(DataGridViewColumn col)
        {
            DataGridViewComboBoxColumn column = col as DataGridViewComboBoxColumn;
            column.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            Dictionary<string, int> dataSource = new Dictionary<string, int>();
            dataSource["呼入"] = 1;
            dataSource["呼出"] = 2;
            dataSource["呼入/呼出"] = 3;
            column.DataSource = new BindingSource(dataSource, null);
            column.DisplayMember = "Key";
            column.ValueMember = "Value";
        }

        private void dataGridViewEx1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 1) && (e.Value != null))
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "呼入";
                        return;

                    case "2":
                        e.Value = "呼出";
                        return;

                    case "3":
                        e.Value = "呼入/呼出";
                        return;
                }
                e.Value = "";
            }
        }

        private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.ColumnIndex == 1) && (e.Exception is ArgumentException))
            {
                e.Cancel = true;
            }
        }

        private void dataGridViewEx1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = this.dataGridViewEx1.CurrentCell.ColumnIndex;
            if (this.dataGridViewEx1.Columns[columnIndex].Name == "电话号码")
            {
                this.EditingControl = (DataGridViewTextBoxEditingControl) e.Control;
                this.EditingControl.KeyPress += new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
            else if (this.EditingControl != null)
            {
                this.EditingControl.KeyPress -= new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
            if (this.dataGridViewEx1.Columns[columnIndex].Name == "描述")
            {
                this.EditingControlEx = (DataGridViewTextBoxEditingControl) e.Control;
                this.EditingControlEx.KeyPress += new KeyPressEventHandler(this.EditingControlEx_KeyPress);
            }
            else if (this.EditingControlEx != null)
            {
                this.EditingControlEx.KeyPress -= new KeyPressEventHandler(this.EditingControlEx_KeyPress);
            }
        }

        private void dataGridViewEx1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Delete) && !this.dataGridViewEx1.CurrentRow.IsNewRow) && (this.dataGridViewEx1.CurrentRow != null))
            {
                if (!this.dataGridViewEx1.CurrentRow.Cells["isold"].Value.ToString().Equals("1"))
                {
                    this.dataGridViewEx1.Rows.Remove(this.dataGridViewEx1.CurrentRow);
                }
                else
                {
                    MessageBox.Show("不能删除已添加的电话号码!");
                }
            }
        }

 private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b')) || !this.chkString(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void EditingControlEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this.chkString(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private bool getParam()
        {
            if (this.IsNameSame())
            {
                return false;
            }
            if ((this.dataGridViewEx1.DataSource as DataTable).Rows.Count > 50)
            {
                MessageBox.Show("录入数据不能超过50行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            DataTable table = null;
            table = (this.dataGridViewEx1.DataSource != null) ? (this.dataGridViewEx1.DataSource as DataTable) : null;
            this._trafficePhoneNumText.OrderCode = base.OrderCode;
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            int num = 0;
            foreach (DataGridViewRow row in (IEnumerable) this.dataGridViewEx1.Rows)
            {
                if ((!Convert.ToBoolean(row.Cells["IsChecked"].Value) || row.IsNewRow) || ((this.cmbSetType.SelectedIndex == 0) || (table == null)))
                {
                    continue;
                }
                string str = (row.Cells["呼叫类型"].Value.ToString().Length == 0) ? "" : row.Cells["呼叫类型"].Value.ToString().Replace(",", "，");
                if (str.Trim().Length == 0)
                {
                    MessageBox.Show("请录入完整数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["呼叫类型"].Selected = true;
                    return false;
                }
                string strIn = (row.Cells["电话号码"].Value.ToString().Length == 0) ? " " : row.Cells["电话号码"].Value.ToString().Replace(",", "，");
                if ((strIn.Trim().Length == 0) || !this.IsValidTel(strIn))
                {
                    MessageBox.Show("请录入正确电话号码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["电话号码"].Selected = true;
                    return false;
                }
                if (Encoding.GetEncoding("gb2312").GetByteCount(strIn) > 20)
                {
                    MessageBox.Show("您录入的电话号码太长了!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["电话号码"].Selected = true;
                    return false;
                }
                string s = (row.Cells["描述"].Value.ToString().Length == 0) ? " " : row.Cells["描述"].Value.ToString().Replace(",", "，");
                if (s.Trim().Length == 0)
                {
                    MessageBox.Show("请录入联系人!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["描述"].Selected = true;
                    return false;
                }
                if (!this.chkString(row.Cells["描述"].Value.ToString()))
                {
                    MessageBox.Show("联系人名称输入非法，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["描述"].Selected = true;
                    return false;
                }
                if (s.Trim().IndexOf("&") >= 0)
                {
                    MessageBox.Show("'&'字符属非法字符，联系人名称中不能输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["描述"].Selected = true;
                    return false;
                }
                if (s.Trim().IndexOf("<") >= 0)
                {
                    MessageBox.Show("'<'字符属非法字符，联系人名称中不能输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["描述"].Selected = true;
                    return false;
                }
                if (Encoding.GetEncoding("gb2312").GetByteCount(s) > 40)
                {
                    MessageBox.Show("您录入的联系人太长了!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    row.Cells["描述"].Selected = true;
                    return false;
                }
                if (this.cmbSetType.SelectedIndex == 2)
                {
                    DataRow row2 = table.Rows[this.dataGridViewEx1.Rows.IndexOf(row)];
                    if ((row2 != null) && (row2.RowState == DataRowState.Added))
                    {
                        goto Label_049D;
                    }
                    continue;
                }
                if (this.cmbSetType.SelectedIndex == 3)
                {
                    DataRow row3 = table.Rows[this.dataGridViewEx1.Rows.IndexOf(row)];
                    if (row3.RowState != DataRowState.Modified)
                    {
                        continue;
                    }
                }
            Label_049D:
                builder2.Append(strIn + ",");
                builder.Append(str + ",");
                builder3.Append(s + ",");
                num++;
            }
            if (num > 10)
            {
                MessageBox.Show("一次设置不能超过10条，请重新选择!", "询问");
                return false;
            }
            StringBuilder builder4 = new StringBuilder();
            StringBuilder builder5 = new StringBuilder();
            foreach (DataRow row4 in table.Rows)
            {
                if (((this.cmbSetType.SelectedIndex == 1) && Convert.ToBoolean(row4["IsChecked"])) || ((this.cmbSetType.SelectedIndex != 1) && ((row4["isold"].ToString() == "1") || Convert.ToBoolean(row4["IsChecked"]))))
                {
                    if ((row4["isold"].ToString() == "1") && !Convert.ToBoolean(row4["IsChecked"]))
                    {
                        row4.RejectChanges();
                    }
                    builder4.Append(row4["Flag"].ToString() + "," + row4["Phone"].ToString().Replace(",", "，") + "," + row4["Name"].ToString().Replace(",", "，").Replace("#", "╆") + "#");
                    builder5.Append(row4["Flag"].ToString() + "," + row4["Phone"].ToString().Replace(",", "，") + "," + row4["Name"].ToString().Replace(",", "，").Replace("#", "╆") + "#");
                }
            }
            this._trafficePhoneNumText.m_Params = this._trafficePhoneNumText.m_ParamsReport = (this.cmbSetType.SelectedIndex == 0) ? " " : builder4.ToString();
            this._trafficePhoneNumText.Type = this.cmbSetType.SelectedIndex;
            this._trafficePhoneNumText.Nums = num;
            this._trafficePhoneNumText.FlagList = builder.ToString();
            this._trafficePhoneNumText.PhoneListList = builder2.ToString();
            this._trafficePhoneNumText.NameList = builder3.ToString();
            if (this.cmbSetType.SelectedIndex == 0)
            {
                if (MessageBox.Show("是否删除终端上所有的联系人?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return false;
                }
            }
            else if (num == 0)
            {
                if (this.cmbSetType.SelectedIndex == 2)
                {
                    MessageBox.Show("请输入新的电话号码!", "询问", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (this.cmbSetType.SelectedIndex == 3)
                {
                    MessageBox.Show("电话本数据未发生变化或未勾选，不需要修改!", "询问", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("请选择列表!", "询问", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return false;
            }
            return true;
        }

        private void InitControl()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("Flag");
            DataColumn column2 = new DataColumn("Phone");
            DataColumn column3 = new DataColumn("Name");
            DataColumn column4 = new DataColumn("isOld") {
                DefaultValue = "0"
            };
            DataColumn column5 = new DataColumn("IsChecked") {
                DefaultValue = false
            };
            table.Columns.AddRange(new DataColumn[] { column5, column, column2, column3, column4 });
            if (MainForm.myCarList.SelectedCarId.Trim().Length > 0)
            {
                DataTable phoneNumTextByCarid = RemotingClient.GetPhoneNumTextByCarid(MainForm.myCarList.SelectedCarId.Split(new char[] { ',' })[0]);
                if (phoneNumTextByCarid != null)
                {
                    foreach (DataRow row in phoneNumTextByCarid.Rows)
                    {
                        DataRow row2 = table.NewRow();
                        row2["IsChecked"] = false;
                        row2["Flag"] = row["Flag"];
                        row2["Phone"] = row["Phone"];
                        row2["Name"] = row["Name"].ToString().Replace("╆", "#");
                        row2["isOld"] = "1";
                        table.Rows.Add(row2);
                    }
                }
                phoneNumTextByCarid = null;
                this.dataGridViewEx1.DataSource = table;
                table.AcceptChanges();
            }
        }

 private bool IsNameSame()
        {
            for (int i = 0; i < (this.dataGridViewEx1.DataSource as DataTable).Rows.Count; i++)
            {
                string str = (this.dataGridViewEx1.DataSource as DataTable).Rows[i]["Name"].ToString();
                for (int j = i + 1; j < (this.dataGridViewEx1.DataSource as DataTable).Rows.Count; j++)
                {
                    string str2 = (this.dataGridViewEx1.DataSource as DataTable).Rows[j]["Name"].ToString();
                    if (str.Equals(str2))
                    {
                        MessageBox.Show("联系人 " + str + " 有重复，请修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsValidTel(string strIn)
        {
            long result = 0L;
            if (strIn.Contains("-") || strIn.Contains("+"))
            {
                return false;
            }
            if (!long.TryParse(strIn, out result))
            {
                return false;
            }
            return true;
        }

        private void JTBSetTelephoneBook_Load(object sender, EventArgs e)
        {
            this.InitControl();
            this.cmbSetType.SelectedIndex = 1;
        }
    }
}

