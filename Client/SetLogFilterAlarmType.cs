namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public partial class SetLogFilterAlarmType : UserControl
    {

        public event EventHandler SetParam;

        public SetLogFilterAlarmType()
        {
            this.InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dgvList.DataSource != null)
            {
                long num = 0L;
                long num2 = 0L;
                DataTable dataSource = this.dgvList.DataSource as DataTable;
                foreach (DataRow row in dataSource.Rows)
                {
                    if (row["Type"].ToString().Equals("1") && Convert.ToBoolean(row["isCheck"]))
                    {
                        num |= Convert.ToInt64(row["CarStatu"]);
                    }
                    else if (row["Type"].ToString().Equals("2") && Convert.ToBoolean(row["isCheck"]))
                    {
                        num2 |= Convert.ToInt64(row["CarStatu"]);
                    }
                }
                this.setParam(num.ToString() + "," + num2.ToString());
            }
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dgvList.DataSource != null)
            {
                DataTable dataSource = this.dgvList.DataSource as DataTable;
                foreach (DataRow row in dataSource.Rows)
                {
                    row["isCheck"] = this.chkCheckAll.Checked;
                }
            }
        }

 public void Init()
        {
            string sql = "select CarStatu,CarStatuName,Type from CarStatuTable Where Type=1";
            DataTable table = RemotingClient.ExecSql(sql);
            if ((table != null) && (table.Rows.Count > 0))
            {
                DataColumn column = new DataColumn("isCheck") {
                    DefaultValue = false
                };
                table.Columns.Add(column);
                long result = 0L;
                if (Variable.sLogFilterAlarmType.Trim().Length > 0)
                {
                    long.TryParse(Variable.sLogFilterAlarmType.Split(new char[] { ',' })[0], out result);
                    foreach (DataRow row in table.Rows)
                    {
                        if ((Convert.ToInt64(row["CarStatu"]) & result) != 0L)
                        {
                            row["isCheck"] = true;
                        }
                    }
                }
            }
            sql = "select CarStatuEx as CarStatu,CarStatuExName as CarStatuName,2 Type from CarStatuExTable";
            DataTable table2 = RemotingClient.ExecSql(sql);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                DataColumn column3 = new DataColumn("isCheck") {
                    DefaultValue = false
                };
                table2.Columns.Add(column3);
                long num3 = 0L;
                if ((Variable.sLogFilterAlarmType.Trim().Length > 0) && (Variable.sLogFilterAlarmType.Split(new char[] { ',' }).Length == 2))
                {
                    long.TryParse(Variable.sLogFilterAlarmType.Split(new char[] { ',' })[1], out num3);
                    foreach (DataRow row2 in table2.Rows)
                    {
                        if ((Convert.ToInt64(row2["CarStatu"]) & num3) != 0L)
                        {
                            row2["isCheck"] = true;
                        }
                    }
                }
            }
            if ((table != null) && (table2 != null))
            {
                foreach (DataRow row3 in table.Rows)
                {
                    table2.Rows.Add(row3.ItemArray);
                }
                table2.DefaultView.Sort = "Type Asc";
                this.dgvList.DataSource = table2;
            }
        }

 private void SetLogFilterAlarmType_Load(object sender, EventArgs e)
        {
            this.dgvList.Focus();
        }

        private void setParam(string val)
        {
            if (this.SetParam != null)
            {
                this.SetParam(val, null);
            }
        }
    }
}

