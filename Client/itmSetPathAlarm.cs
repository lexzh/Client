namespace Client
{
    using Properties;
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
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    public partial class itmSetPathAlarm : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private List<object> checklist = new List<object>();
        private static string ERRORPATHAlARM = "解析行驶线路失败！";
        private object[] list;
        private DataTable m_dtAlarmDot = new DataTable();
        private DataTable m_dtPathAlarm = new DataTable();
        private DataTable m_dtPathGroup = new DataTable();
        private PathAlarmList m_PathAlarmList = new PathAlarmList();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmSetPathAlarm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._worker_RunWorkerCompleted);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (base.OrderCode == CmdParam.OrderCode.下载兴趣点)
                {
                    base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                }
                else
                {
                    string[] strArray = base.sValue.Split(new char[] { ',' });
                    int length = strArray.Length;
                    int num2 = 0;
                    if (length > 1)
                    {
                        foreach (string str in strArray)
                        {
                            base.reResult = RemotingClient.DownData_SelMultiPathAlarm(base.ParamType, str, base.sPw, CmdParam.CommMode.未知方式, this.m_PathAlarmList);
                            num2++;
                            this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                        }
                    }
                    else
                    {
                        base.reResult = RemotingClient.DownData_SelMultiPathAlarm(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_PathAlarmList);
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置分段偏移路线报警-->", exception.Message);
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double num = ((double) e.ProgressPercentage) / 100.0;
            this.lblWaitText.Text = "已完成：" + num.ToString("P").Replace(".00", "");
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlEnable(true);
            if (base.reResult.ResultCode != 0L)
            {
                MessageBox.Show(base.reResult.ErrorMsg);
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if ((!string.IsNullOrEmpty(base.sValue) && this.getParam()) && !this._worker.IsBusy)
                {
                    this.SetControlEnable(false);
                    this._worker.RunWorkerAsync();
                }
            }
            catch (Exception exception)
            {
                this.SetControlEnable(true);
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

        private void dataBuffer()
        {
            this.checklist.Clear();
            this.list = new object[this.clbSelectRoute.Items.Count];
            this.clbSelectRoute.Items.CopyTo(this.list, 0);
        }

        private void dataFilter(string filterString)
        {
            try
            {
                base.Enabled = false;
                for (int i = 0; i < this.checklist.Count; i++)
                {
                    int index = this.clbSelectRoute.Items.IndexOf(this.checklist[i]);
                    if ((index >= 0) && !this.clbSelectRoute.CheckedItems.Contains(this.clbSelectRoute.Items[index]))
                    {
                        this.checklist.Remove(this.clbSelectRoute.Items[index]);
                    }
                }
                for (int j = 0; j < this.clbSelectRoute.CheckedItems.Count; j++)
                {
                    if (!this.checklist.Contains(this.clbSelectRoute.CheckedItems[j]))
                    {
                        this.checklist.Add(this.clbSelectRoute.CheckedItems[j]);
                    }
                }
                this.clbSelectRoute.Items.Clear();
                for (int k = 0; k < this.list.Length; k++)
                {
                    if (this.list[k].ToString().Contains(filterString))
                    {
                        bool isChecked = false;
                        if (this.checklist.Contains(this.list[k]))
                        {
                            isChecked = true;
                        }
                        this.clbSelectRoute.Items.Add(this.list[k], isChecked);
                    }
                }
                this.clbSelectRoute.Refresh();
            }
            catch
            {
            }
            finally
            {
                base.Enabled = true;
            }
        }

 private string getCheckPathName()
        {
            string str = "";
            foreach (System.Web.UI.WebControls.ListItem item in this.clbSelectRoute.CheckedItems)
            {
                str = str + "'" + item.Value + "',";
            }
            return str.Trim(new char[] { ',' });
        }

        private bool getParam()
        {
            if (base.OrderCode != CmdParam.OrderCode.下载兴趣点)
            {
                this.m_PathAlarmList = new PathAlarmList();
                this.dataFilter("");
                string str2 = this.getCheckPathName();
                if (string.IsNullOrEmpty(str2))
                {
                    MessageBox.Show("没有选择预设路线！");
                    return false;
                }
                DataTable table4 = RemotingClient.Car_GetPathRouteByPathName(str2);
                if ((table4 == null) || (table4.Rows.Count <= 0))
                {
                    MessageBox.Show("没有读取到偏移路线数据，请重新设置");
                    return false;
                }
                foreach (DataRow row2 in table4.Rows)
                {
                    PathAlarm alarm = new PathAlarm();
                    ArrayList list = new ArrayList();
                    string str3 = row2["PathName"] as string;
                    string str4 = row2["alarmPathDot"] as string;
                    if (string.IsNullOrEmpty(str4))
                    {
                        MessageBox.Show(ERRORPATHAlARM);
                        return false;
                    }
                    string[] strArray = str4.Split(new char[] { '/' });
                    alarm.PointCount = strArray.Length;
                    for (int i = 0; i < (strArray.Length - 1); i++)
                    {
                        if (string.IsNullOrEmpty(strArray[i]))
                        {
                            MessageBox.Show(ERRORPATHAlARM);
                            return false;
                        }
                        string[] strArray2 = strArray[i].Split(new char[] { '*' });
                        if (strArray2.Length != 2)
                        {
                            MessageBox.Show(ERRORPATHAlARM);
                            return false;
                        }
                        ParamLibrary.CmdParamInfo.Point point = new ParamLibrary.CmdParamInfo.Point {
                            Longitude = double.Parse(strArray2[0]),
                            Latitude = double.Parse(strArray2[1])
                        };
                        list.Add(point);
                    }
                    alarm.Points = list;
                    alarm.PathName = str3;
                    this.m_PathAlarmList.Add(alarm);
                }
                if ((this.m_PathAlarmList == null) || (this.m_PathAlarmList.Count < 0))
                {
                    return false;
                }
            }
            else
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
            }
            this.m_PathAlarmList.OrderCode = base.OrderCode;
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            return true;
        }

        private void InitComboBox()
        {
            this.m_dtPathGroup = RemotingClient.Alarm_GetGroupType();
            if ((this.m_dtPathGroup == null) || (this.m_dtPathGroup.Rows.Count <= 0))
            {
                this.comboBoxLines.Items.Add("(无)");
                this.comboBoxLines.Text = "(无)";
            }
            else
            {
                DataRow row = this.m_dtPathGroup.NewRow();
                this.m_dtPathGroup.Rows.InsertAt(row, 0);
                this.comboBoxLines.DataSource = this.m_dtPathGroup;
            }
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
            else
            {
                string strCarId = (base.sCarId.Split(",".ToCharArray()).Length > 1) ? base.sCarId.Split(",".ToCharArray())[0] : base.sCarId;
                this.m_dtPathAlarm = RemotingClient.Car_GetPathAlarmAnother(strCarId);
                this.m_dtAlarmDot = RemotingClient.Car_GetAlarmPathDotFromGisCar(strCarId);
                this.setListBox(this.m_dtPathAlarm, this.m_dtAlarmDot);
            }
        }

        private void itmSetPathAlarm_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
            this.InitListBox();
            this.InitComboBox();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = this.grpSelectRoute.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        private void setGroupVisible()
        {
            if (base.OrderCode == CmdParam.OrderCode.下载兴趣点)
            {
                this.grpSelectRoute.Text = "";
            }
            else
            {
                this.pnlSelectAll.Visible = false;
            }
        }

        private void setListBox(DataTable dtPathAlarm, DataTable dtAlarmDot)
        {
            this.clbSelectRoute.Items.Clear();
            if ((dtPathAlarm != null) && (dtPathAlarm.Rows.Count > 0))
            {
                string str = string.Empty;
                if ((dtAlarmDot != null) && (dtAlarmDot.Rows.Count > 0))
                {
                    str = dtAlarmDot.Rows[0]["AlarmPathDot"] as string;
                }
                foreach (DataRow row in dtPathAlarm.Rows)
                {
                    string text = row["pathName"].ToString();
                    System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(text, text);
                    if (this.clbSelectRoute.Items.IndexOf(item) < 0)
                    {
                        if (string.IsNullOrEmpty(str))
                        {
                            this.clbSelectRoute.Items.Add(item, false);
                        }
                        else
                        {
                            string str3 = row["AlarmPathDot"] as string;
                            string[] strArray = str3.Replace('*', '/').Trim(new char[] { '/' }).Split(new char[] { '/' });
                            str3 = string.Empty;
                            StringBuilder builder = new StringBuilder();
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                builder.Append(strArray[i].PadRight(10, '0') + '\\');
                            }
                            if (!string.IsNullOrEmpty(builder.ToString()))
                            {
                                str3 = builder.ToString().Trim(new char[] { '\\' });
                            }
                            if (str.IndexOf(str3) >= 0)
                            {
                                item.Selected = true;
                                this.clbSelectRoute.Items.Add(item, true);
                            }
                            else
                            {
                                item.Selected = false;
                                this.clbSelectRoute.Items.Add(item, false);
                            }
                        }
                    }
                }
                this.dataBuffer();
            }
            else
            {
                System.Web.UI.WebControls.ListItem item2 = new System.Web.UI.WebControls.ListItem("(无)", "");
                this.clbSelectRoute.Items.Add(item2, false);
            }
        }

        private void tsBtnFilter_Click(object sender, EventArgs e)
        {
            if ((this.comboBoxLines.SelectedValue == null) || this.comboBoxLines.SelectedValue.ToString().Equals(""))
            {
                this.setListBox(this.m_dtPathAlarm, this.m_dtAlarmDot);
            }
            else
            {
                DataTable dtPathAlarm = new DataTable();
                DataView view = new DataView(this.m_dtPathAlarm);
                try
                {
                    string s = this.comboBoxLines.SelectedValue.ToString();
                    string str2 = "pathgroupID =" + int.Parse(s);
                    view.RowFilter = str2;
                    dtPathAlarm = view.ToTable();
                    this.setListBox(dtPathAlarm, this.m_dtPathAlarm);
                }
                catch
                {
                }
            }
        }

        private void tsBtnSearchdata_Click(object sender, EventArgs e)
        {
            this.dataFilter(this.txtFindRoad.Text);
        }

        private void txtFindRoad_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

