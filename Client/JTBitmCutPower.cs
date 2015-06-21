namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class JTBitmCutPower : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBitmCutPower(CmdParam.OrderCode OrderCode)
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

        private void cmbCutType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dt.DefaultView.RowFilter = "Type='" + (this.cmbCutType.SelectedIndex + 1) + "'";
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.LockCarValue = this.cmbCmdType.SelectedValue.ToString();
            this.m_SimpleCmd.CarType = "1";
            return true;
        }

 private void JTBitmCutPower_Load(object sender, EventArgs e)
        {
            this.dt = new DataTable();
            this.dt.Columns.Add(new DataColumn("Name"));
            this.dt.Columns.Add(new DataColumn("Value"));
            this.dt.Columns.Add(new DataColumn("Type"));
            DataRow row = this.dt.NewRow();
            row["Name"] = "CAN一级锁车";
            row["Value"] = "1";
            row["Type"] = "1";
            DataRow row2 = this.dt.NewRow();
            row2["Name"] = "CAN二级锁车";
            row2["Value"] = "2";
            row2["Type"] = "1";
            DataRow row3 = this.dt.NewRow();
            row3["Name"] = "CAN解锁";
            row3["Value"] = "3";
            row3["Type"] = "1";
            DataRow row4 = this.dt.NewRow();
            row4["Name"] = "2.5V锁机";
            row4["Value"] = "4";
            row4["Type"] = "2";
            DataRow row5 = this.dt.NewRow();
            row5["Name"] = "2.5V解锁";
            row5["Value"] = "5";
            row5["Type"] = "2";
            DataRow row6 = this.dt.NewRow();
            row6["Name"] = "0.5V一级锁机";
            row6["Value"] = "6";
            row6["Type"] = "3";
            DataRow row7 = this.dt.NewRow();
            row7["Name"] = "0.5V一级解锁";
            row7["Value"] = "7";
            row7["Type"] = "3";
            DataRow row8 = this.dt.NewRow();
            row8["Name"] = "0.5V二级锁机";
            row8["Value"] = "8";
            row8["Type"] = "3";
            DataRow row9 = this.dt.NewRow();
            row9["Name"] = "0.5V二级解锁";
            row9["Value"] = "9";
            row9["Type"] = "3";
            this.dt.Rows.Add(row);
            this.dt.Rows.Add(row2);
            this.dt.Rows.Add(row3);
            this.dt.Rows.Add(row4);
            this.dt.Rows.Add(row5);
            this.dt.Rows.Add(row6);
            this.dt.Rows.Add(row7);
            this.dt.Rows.Add(row8);
            this.dt.Rows.Add(row9);
            this.cmbCmdType.DataSource = this.dt;
            this.cmbCutType.SelectedIndex = 0;
        }
    }
}

