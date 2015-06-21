namespace Client.JTB
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class JTBQuestionManage : SizableForm
    {
        private DataTable dtanswer = new DataTable();

        public JTBQuestionManage()
        {
            this.InitializeComponent();
        }

        private void bindData()
        {
            string sql = " select ID,MsgType,MsgName from GpsJTBMsgParam where MsgType = 3 order by ID ";
            this.dt = RemotingClient.ExecSql(sql);
            if ((this.dt != null) && (this.dt.Rows.Count > 0))
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("QuestionName");
                table.Columns.Add("answers");
                DataRow row = table.NewRow();
                row["ID"] = -1;
                row["QuestionName"] = "请选择问题...";
                table.Rows.Add(row);
                foreach (DataRow row2 in this.dt.Rows)
                {
                    DataRow row3 = table.NewRow();
                    string str2 = row2["MsgName"].ToString();
                    row3["ID"] = row2["ID"];
                    string[] strArray = str2.Split(new char[] { ',' }, 2);
                    row3["QuestionName"] = strArray[0];
                    row3["answers"] = strArray[1];
                    table.Rows.Add(row3);
                }
                this.cbQuestion.DisplayMember = "QuestionName";
                this.cbQuestion.ValueMember = "ID";
                this.cbQuestion.DataSource = table;
                this.cbQuestion.SelectedIndex = 0;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.cbQuestion.SelectedIndex <= 0)
            {
                MessageBox.Show("请选择问题");
            }
            else if (MessageBox.Show("是否确定删除此问题？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string str = this.cbQuestion.SelectedValue.ToString();
                string format = "delete from GpsJTBMsgParam where ID = '{0}' ";
                Response response = RemotingClient.ExecNoQuery(string.Format(format, str));
                if (response.ResultCode != 0L)
                {
                    MessageBox.Show(response.ErrorMsg);
                }
                this.bindData();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.cbQuestion.SelectedIndex = 0;
            this.txtQuestion.Text = "";
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            this.dataGridView1.AllowUserToAddRows = false;
            if (!this.checkParam())
            {
                this.dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                if (this.cbQuestion.SelectedIndex != 0)
                {
                    if (this.IsExists(this.txtQuestion.Text) && !this.txtQuestion.Text.Equals(this.cbQuestion.Text))
                    {
                        MessageBox.Show("该问题已存在。");
                        this.dataGridView1.AllowUserToAddRows = true;
                        return;
                    }
                    string str = this.cbQuestion.SelectedValue.ToString();
                    string str2 = this.txtQuestion.Text.Replace(",", "，");
                    foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
                    {
                        str2 = str2 + "," + row.Cells[0].Value.ToString().Replace(",", "，");
                    }
                    RemotingClient.ExecNoQuery("Update GpsJTBMsgParam Set MsgName = '" + str2 + "' Where msgType=3 And ID='" + str + "'");
                }
                else if (this.cbQuestion.SelectedIndex == 0)
                {
                    if (this.IsExists(this.txtQuestion.Text))
                    {
                        MessageBox.Show("该问题已存在。");
                        this.dataGridView1.AllowUserToAddRows = true;
                        return;
                    }
                    int num = 0;
                    string sql = " select Isnull(Max(ID),0) as ID from GpsJTBMsgParam where MsgType = 3 order by ID ";
                    DataTable table = RemotingClient.ExecSql(sql);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        num = Convert.ToInt32(table.Rows[0][0]) + 1;
                    }
                    string str5 = this.txtQuestion.Text.Replace(",", "，");
                    foreach (DataGridViewRow row2 in (IEnumerable) this.dataGridView1.Rows)
                    {
                        str5 = str5 + "," + row2.Cells[0].Value.ToString().Replace(",", "，");
                    }
                    Response response = RemotingClient.ExecNoQuery(string.Concat(new object[] { "Insert Into GpsJTBMsgParam(ID,MsgType,MsgName,CreateBy,CreateDate)Values('", num, "','", 3, "','", str5, "','", Variable.sUserId, "',getdate())" }));
                    if (response.ResultCode != 0L)
                    {
                        MessageBox.Show(response.ErrorMsg);
                    }
                }
                else
                {
                    MessageBox.Show("请选择问题。");
                    this.dataGridView1.AllowUserToAddRows = true;
                    return;
                }
                this.dataGridView1.AllowUserToAddRows = true;
                this.bindData();
            }
        }

        private void cbQuestion_TextChanged(object sender, EventArgs e)
        {
            if (!this.IsExists(this.cbQuestion.Text))
            {
                this.dataGridView1.Rows.Clear();
            }
        }

        private bool checkParam()
        {
            if (this.txtQuestion.Text.Trim().Equals(""))
            {
                MessageBox.Show("问题名称不能为空。");
                return false;
            }
            string str = this.txtQuestion.Text.Replace(",", "，");
            for (int i = 0; i < (this.dataGridView1.Rows.Count - 1); i++)
            {
                DataGridViewRow row = this.dataGridView1.Rows[i];
                if ((row.Cells[0].Value == null) || row.Cells[0].Value.ToString().Equals(""))
                {
                    MessageBox.Show("答案不能为空。");
                    return false;
                }
                string str2 = row.Cells[0].Value.ToString().Trim();
                for (int j = i + 1; j < this.dataGridView1.Rows.Count; j++)
                {
                    DataGridViewRow row2 = this.dataGridView1.Rows[j];
                    if ((row2.Cells[0].Value == null) || row2.Cells[0].Value.ToString().Equals(""))
                    {
                        MessageBox.Show("答案不能为空。");
                        return false;
                    }
                    string str3 = row2.Cells[0].Value.ToString().Trim();
                    if (str2.Equals(str3))
                    {
                        MessageBox.Show("答案不能相同。");
                        return false;
                    }
                }
                str = str + "," + row.Cells[0].Value.ToString().Replace(",", "，");
            }
            if (str.Length > 400)
            {
                MessageBox.Show("问题或答案过长。");
                return false;
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbQuestion.SelectedIndex <= 0)
            {
                this.txtQuestion.Text = "";
                this.lblNewQuestion.Text = "新增问题：";
                this.dataGridView1.Rows.Clear();
            }
            else
            {
                this.lblNewQuestion.Text = "修改问题：";
                DataRow row = (this.cbQuestion.SelectedItem as DataRowView).Row;
                DataTable table = new DataTable();
                table.Columns.Add("Name");
                string[] strArray = row["answers"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                this.dataGridView1.Rows.Clear();
                foreach (string str in strArray)
                {
                    this.dataGridView1.Rows.Add(new object[] { str });
                }
                this.txtQuestion.Text = this.cbQuestion.Text;
            }
        }

 private bool IsExists(string question)
        {
            if (this.dt == null)
            {
                return false;
            }
            foreach (DataRow row in this.dt.Rows)
            {
                if (row["MsgName"].ToString().Split(new char[] { ',' })[0].Equals(question))
                {
                    return true;
                }
            }
            return false;
        }

        private void JTBQuestionManage_Load(object sender, EventArgs e)
        {
            this.bindData();
        }
    }
}

