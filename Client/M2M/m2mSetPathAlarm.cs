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
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    public partial class m2mSetPathAlarm : CarForm
    {
        private static string ERRORPATHAlARM = "解析行驶线路失败！";
        private int m_LineMaxCnt = 16;
        private PathAlarmList m_PathAlarmList = new PathAlarmList();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mSetPathAlarm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
                {
                    if (base.OrderCode == CmdParam.OrderCode.下载兴趣点)
                    {
                        base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                    }
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clbSelectRoute.Items.Count; i++)
            {
                this.clbSelectRoute.SetItemChecked(i, this.chkSelectAll.Checked);
            }
        }

 private string getCheckPathName()
        {
            string str = "";
            foreach (System.Web.UI.WebControls.ListItem item in this.clbSelectRoute.CheckedItems)
            {
                str = str + "'" + item.Text + "',";
            }
            return str.Trim(new char[] { ',' });
        }

        private bool getParam()
        {
            if (base.OrderCode == CmdParam.OrderCode.下载兴趣点)
            {
                int iPoiAutn = 0;
                string str = this.getCheckPathName().Replace("'", "").Replace(",", "/");
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("请选择预下载兴趣点的类别！");
                    return false;
                }
                DataTable table = RemotingClient.Car_GetPOIAuth();
                if (((table != null) && (table.Rows.Count > 0)) && (table.Rows[0]["POIAuth"] != DBNull.Value))
                {
                    iPoiAutn = int.Parse(table.Rows[0]["POIAuth"].ToString());
                }
                DataTable table2 = RemotingClient.Area_GetUserAreaInfo();
                DataTable table3 = null;
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    foreach (DataRow row in table2.Rows)
                    {
                        if (row["AreaCode"] != DBNull.Value)
                        {
                            table3 = RemotingClient.Car_GetInterestPointMulti(str, iPoiAutn);
                            break;
                        }
                    }
                }
                else
                {
                    table3 = RemotingClient.Car_GetInterestPointSingle(str, iPoiAutn);
                }
                if ((table3 == null) || (table3.Rows.Count <= 0))
                {
                    MessageBox.Show("没有兴趣点，请检查是否设置！");
                    return false;
                }
                this.m_SimpleCmd.MapTypes = str;
                this.m_SimpleCmd.InsterestPoints = table3;
                this.m_SimpleCmd.OrderCode = base.OrderCode;
            }
            return true;
        }

 private void InitListBox()
        {
            if (base.OrderCode == CmdParam.OrderCode.下载兴趣点)
            {
                DataTable table = RemotingClient.Car_GetMapType();
                if ((table != null) && (table.Rows.Count > 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(row["Name"].ToString(), row["Name"].ToString());
                        this.clbSelectRoute.Items.Add(item);
                    }
                }
            }
        }

        private void itmSetPathAlarm_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
            this.InitListBox();
        }

        private void setGroupVisible()
        {
            this.grpExpand.Visible = false;
            if (base.OrderCode == CmdParam.OrderCode.下载兴趣点)
            {
                this.grpSelectRoute.Text = "";
            }
        }
    }
}

