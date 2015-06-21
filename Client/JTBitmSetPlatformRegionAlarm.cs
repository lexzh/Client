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
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBitmSetPlatformRegionAlarm : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private DataTable dt = new DataTable();
        private DataTable m_dtPathGroup = new DataTable();
        private DataTable serverData = new DataTable();
        private TrafficSimpleCmd SimpleCmd = new TrafficSimpleCmd();
        private BindingSource source = new BindingSource();

        public JTBitmSetPlatformRegionAlarm(CmdParam.OrderCode OrderCode)
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
                string[] strArray = base.sValue.Split(new char[] { ',' });
                int length = strArray.Length;
                int num2 = 0;
                if (length > 1)
                {
                    foreach (string str in strArray)
                    {
                        base.reResult = RemotingClient.icar_SetPlatformAlarmCmd(base.ParamType, str, base.sPw, CmdParam.CommMode.未知方式, this.SimpleCmd);
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                    }
                }
                else
                {
                    base.reResult = RemotingClient.icar_SetPlatformAlarmCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.SimpleCmd);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置平台区域报警-->", exception.Message);
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

        private void ClearCellValue(int row)
        {
            this.dgvDataList.Rows[row].Cells["进入"].Value = false;
            this.dgvDataList.Rows[row].Cells["越出"].Value = false;
            this.dgvDataList.Rows[row].Cells["inRegion"].Value = false;
            this.dgvDataList.Rows[row].Cells["outRegion"].Value = false;
            this.dgvDataList.Rows[row].Cells["开始时间"].Value = "";
            this.dgvDataList.Rows[row].Cells["结束时间"].Value = "";
        }

        private void dgvDataList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string name = this.dgvDataList[e.ColumnIndex, e.RowIndex].OwningColumn.Name;
            if (!this.isCellSelected(e.RowIndex) && name.Equals("进入"))
            {
                e.Cancel = true;
            }
            if (!this.isCellSelected(e.RowIndex) && name.Equals("越出"))
            {
                e.Cancel = true;
            }
            if (!this.isCellSelected(e.RowIndex) && name.Equals("inRegion"))
            {
                e.Cancel = true;
            }
            if (!this.isCellSelected(e.RowIndex) && name.Equals("outRegion"))
            {
                e.Cancel = true;
            }
        }

        private void dgvDataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                DataGridViewCell currentCell = ((DataGridView) sender).CurrentCell;
                string name = this.dgvDataList[e.ColumnIndex, e.RowIndex].OwningColumn.Name;
                if (this.isCellSelected(currentCell.RowIndex) && (name.Equals("开始时间") || name.Equals("结束时间")))
                {
                    SetDateTime time = new SetDateTime(currentCell.Value.ToString());
                    if (time.ShowDialog() == DialogResult.OK)
                    {
                        currentCell.Value = time.Time;
                    }
                }
            }
        }

        private void dgvDataList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDataList[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("选择"))
            {
                foreach (DataGridViewRow row in (IEnumerable) this.dgvDataList.Rows)
                {
                    if (!this.isCellSelected(row.Index))
                    {
                        this.ClearCellValue(row.Index);
                    }
                }
            }
        }

        private void dgvDataList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                DataGridViewCell cell = this.dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    this.dgvDataList.EndEdit();
                }
            }
        }

 private bool getParam()
        {
            if (!this.ValidateInput())
            {
                return false;
            }
            this.serverData.Clear();
            foreach (DataRow row in this.dt.Rows)
            {
                if (Convert.ToBoolean(row["ischeck"]))
                {
                    DataRow row2 = this.serverData.NewRow();
                    row2["regionId"] = row["regionId"];
                    int num = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    if (Convert.ToBoolean(row["isin"]))
                    {
                        num = 1;
                    }
                    if (Convert.ToBoolean(row["isout"]))
                    {
                        num2 = 2;
                    }
                    if (Convert.ToBoolean(row["inRegion"]))
                    {
                        num3 = 4;
                    }
                    if (Convert.ToBoolean(row["outRegion"]))
                    {
                        num4 = 8;
                    }
                    row2["regionType"] = ((num | num2) | num3) | num4;
                    row2["beginTime"] = row["beginTime"].ToString().StartsWith("0000") ? row["beginTime"].ToString().Replace("0000-00-00", "1900-01-01") : row["beginTime"];
                    row2["endTime"] = row["endTime"].ToString().StartsWith("0000") ? row["endTime"].ToString().Replace("0000-00-00", "1900-01-01") : row["endTime"];
                    this.serverData.Rows.Add(row2);
                }
            }
            this.SimpleCmd.OrderCode = base.OrderCode;
            this.SimpleCmd.CommonArgs = this.serverData;
            return true;
        }

        private string GetSetRegionTime(DataTable data, string carid, string regionId, string columnName)
        {
            string str = string.Empty;
            if ((data == null) || (data.Rows.Count == 0))
            {
                return str;
            }
            DataRow row = data.Rows.Find(new object[] { carid, regionId });
            if (row == null)
            {
                return str;
            }
            DateTime time = Convert.ToDateTime(row[columnName]);
            if (time.Year == 1900)
            {
                return string.Concat(new object[] { "0000-00-00 ", time.Hour.ToString(), ":", time.Minute, ":", time.Second });
            }
            return time.ToString("yyyy-MM-dd HH:mm:ss");
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

        private void InitData()
        {
            string strCarId = (base.sCarId.Split(new char[] { ',' }).Length > 0) ? base.sCarId.Split(new char[] { ',' })[0].ToString() : base.sCarId;
            DataTable table = RemotingClient.Car_GetRegionInfo(strCarId, 1);
            DataTable data = RemotingClient.GetCommonData(strCarId, 2, null);
            if (data != null)
            {
                data.PrimaryKey = new DataColumn[] { data.Columns["CarID"], data.Columns["RegionID"] };
            }
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    row["regiondot"].ToString();
                    DataRow row2 = this.dt.NewRow();
                    row2["regionid"] = row["regionid"];
                    row2["regionName"] = row["regionName"];
                    bool flag = this.IsRegionInOrOut(data, strCarId, row["RegionID"].ToString(), 1);
                    bool flag2 = this.IsRegionInOrOut(data, strCarId, row["RegionID"].ToString(), 2);
                    bool flag3 = this.IsRegionInOrOut(data, strCarId, row["RegionID"].ToString(), 4);
                    bool flag4 = this.IsRegionInOrOut(data, strCarId, row["RegionID"].ToString(), 8);
                    row2["ischeck"] = ((flag || flag2) || flag3) ? ((object) 1) : ((object) flag4);
                    row2["isin"] = flag;
                    row2["isout"] = flag2;
                    row2["inRegion"] = flag3;
                    row2["outRegion"] = flag4;
                    row2["begintime"] = this.GetSetRegionTime(data, strCarId, row["RegionID"].ToString(), "begintime");
                    row2["endtime"] = this.GetSetRegionTime(data, strCarId, row["RegionID"].ToString(), "endtime");
                    row2["PathGroupId"] = row["PathGroupID"];
                    this.dt.Rows.Add(row2);
                }
            }
            this.source.DataSource = this.dt;
            this.dgvDataList.DataSource = this.source;
        }

        private void InitDataTable()
        {
            DataColumn column = new DataColumn("regionID");
            DataColumn column2 = new DataColumn("regionName");
            DataColumn column3 = new DataColumn("ischeck") {
                DefaultValue = false
            };
            DataColumn column4 = new DataColumn("isin") {
                DefaultValue = false
            };
            DataColumn column5 = new DataColumn("isout") {
                DefaultValue = false
            };
            DataColumn column6 = new DataColumn("begintime");
            DataColumn column7 = new DataColumn("endtime");
            DataColumn column8 = new DataColumn("PathGroupID");
            DataColumn column9 = new DataColumn("InRegion") {
                DefaultValue = false
            };
            DataColumn column10 = new DataColumn("OutRegion") {
                DefaultValue = false
            };
            this.dt.Columns.AddRange(new DataColumn[] { column, column2, column3, column4, column5, column9, column10, column6, column7, column8 });
            DataColumn column11 = new DataColumn("regionID");
            DataColumn column12 = new DataColumn("regionType") {
                DefaultValue = 0
            };
            DataColumn column13 = new DataColumn("begintime");
            DataColumn column14 = new DataColumn("endtime");
            this.serverData.Columns.AddRange(new DataColumn[] { column11, column12, column13, column14 });
        }

 private bool isCellSelected(int row)
        {
            return Convert.ToBoolean(this.dgvDataList.Rows[row].Cells["选择"].Value);
        }

        private bool IsRegionInOrOut(DataTable data, string carid, string regionId, int type)
        {
            bool flag = false;
            if ((data != null) && (data.Rows.Count != 0))
            {
                DataRow row = data.Rows.Find(new object[] { carid, regionId });
                if (row == null)
                {
                    return flag;
                }
                int num = Convert.ToInt32(row["RegionType"]);
                if ((type == 1) && ((num & 1) != 0))
                {
                    return true;
                }
                if ((type == 2) && ((num & 2) != 0))
                {
                    return true;
                }
                if ((type == 4) && ((num & 4) != 0))
                {
                    return true;
                }
                if ((type == 8) && ((num & 8) != 0))
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void JTBitmSetRegionAlarm_Load(object sender, EventArgs e)
        {
            this.InitDataTable();
            this.InitData();
            this.InitComboBox();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = this.grpSelectRoute.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        private void tsBtnFilter_Click(object sender, EventArgs e)
        {
            string str = this.comboBoxLines.SelectedValue.ToString();
            if (this.source.DataSource != null)
            {
                this.source.Filter = (str.Length > 0) ? ("PathGroupID='" + str + "'") : "";
            }
        }

        private bool ValidateInput()
        {
            foreach (DataGridViewRow row in (IEnumerable) this.dgvDataList.Rows)
            {
                if (this.isCellSelected(row.Index))
                {
                    if ((!Convert.ToBoolean(row.Cells["进入"].Value) && !Convert.ToBoolean(row.Cells["越出"].Value)) && (!Convert.ToBoolean(row.Cells["inRegion"].Value) && !Convert.ToBoolean(row.Cells["outRegion"].Value)))
                    {
                        MessageBox.Show("区域\"" + row.Cells["区域名称"].Value.ToString() + "\"未设置\"进入\"或\"越出\"或\"区域内\"或\"区域外\",请设置!");
                        return false;
                    }
                    if (row.Cells["开始时间"].Value.ToString().Length == 0)
                    {
                        MessageBox.Show("区域\"" + row.Cells["区域名称"].Value.ToString() + "\"未设置\"开始时间\",请设置!");
                        return false;
                    }
                    if (row.Cells["结束时间"].Value.ToString().Length == 0)
                    {
                        MessageBox.Show("区域\"" + row.Cells["区域名称"].Value.ToString() + "\"未设置\"结束时间\",请设置!");
                        return false;
                    }
                    if ((row.Cells["开始时间"].Value.ToString().StartsWith("0000") && !row.Cells["结束时间"].Value.ToString().StartsWith("0000")) || (!row.Cells["开始时间"].Value.ToString().StartsWith("0000") && row.Cells["结束时间"].Value.ToString().StartsWith("0000")))
                    {
                        MessageBox.Show("区域\"" + row.Cells["区域名称"].Value.ToString() + "\"的\"开始时间\"和\"结束时间\"格式不一致,请检查!");
                        return false;
                    }
                    if (!row.Cells["开始时间"].Value.ToString().StartsWith("0000") && (Convert.ToDateTime(row.Cells["开始时间"].Value) > Convert.ToDateTime(row.Cells["结束时间"].Value)))
                    {
                        MessageBox.Show("区域\"" + row.Cells["区域名称"].Value.ToString() + "\"的\"开始时间\"不能大于\"结束时间\",请检查!");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

