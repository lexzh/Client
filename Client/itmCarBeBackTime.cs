namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;
    using Library;

    public partial class itmCarBeBackTime : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private DataTable m_dtPathGroup = new DataTable();
        private DataTable m_dtRegion = new DataTable();
        private string ParamList = "";
        private string[] simNums;
        private string sSql = "";

        public itmCarBeBackTime()
        {
            this.InitializeComponent();
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._worker_RunWorkerCompleted);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.sSql))
                {
                    string[] strArray = base.sValue.Split(new char[] { ',' });
                    int length = strArray.Length;
                    int num2 = 0;
                    foreach (string str in strArray)
                    {
                        string CarNum = MainForm.myCarList.execChangeCarValue(this.ParamType, 0, str);
                        string newValue = MainForm.myCarList.execChangeCarValue(this.ParamType, 2, str);
                        base.reResult = RemotingClient.ExecNoQuery(this.sSql.Replace("[A]", newValue));
                        string orderResult = (base.reResult.ResultCode != 0L) ? "失败" : "成功";
                        string sGpsTime = RemotingClient.GetDBCurrentDateTime();
                        if (string.IsNullOrEmpty(sGpsTime))
                        {
                            sGpsTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        string sOrderId = "0";
                        string orderType = "发送";
                        string orderName = "设置集中停放车辆";
                        string sMsg = "设置集中停放车辆-" + this.ParamList;
                        sMsg = sMsg.Trim(new char[] { '-' });
                        //base.Invoke(() => MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(sGpsTime, CarNum, sOrderId, orderType, orderName, orderResult, sMsg));
                        base.Invoke(new MethodInvoker(() => MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(sGpsTime, CarNum, sOrderId, orderType, orderName, orderResult, sMsg)));
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置按时归班报警-->", exception.Message);
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                double num = ((double) e.ProgressPercentage) / 100.0;
                this.lblWaitText.Text = "已完成：" + num.ToString("P").Replace(".00", "");
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置集中停放车辆-->", exception.Message);
            }
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlEnable(true);
            base.DialogResult = DialogResult.OK;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue))
                {
                    this.ParamType = (int) base.cmbType.SelectedValue;
                    if (this.getParam() && !this._worker.IsBusy)
                    {
                        this.SetControlEnable(false);
                        this._worker.RunWorkerAsync();
                    }
                }
            }
            catch (Exception exception)
            {
                this.SetControlEnable(true);
                MessageBox.Show(exception.Message);
            }
        }

        private void dgvArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = ((DataGridView) sender).CurrentCell;
            if (((currentCell.ColumnIndex == this.dgvArea.Columns["beginTime"].Index) || (currentCell.ColumnIndex == this.dgvArea.Columns["endTime"].Index)) && Convert.ToBoolean(this.dgvArea.Rows[currentCell.RowIndex].Cells["Choose"].Value))
            {
                SetDateTime time = new SetDateTime((currentCell.Value.ToString().Length > 0) ? ("0000-00-00 " + currentCell.Value) : "", true);
                if (time.ShowDialog() == DialogResult.OK)
                {
                    currentCell.Value = time.Time.Replace("0000-00-00 ", "");
                }
            }
        }

        private void dgvArea_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                DataGridViewCell cell = this.dgvArea.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    this.dgvArea.EndEdit();
                }
            }
        }

        private void dgvArea_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewCell cell = this.dgvArea.Rows[rowIndex].Cells[e.ColumnIndex];
                if ((cell.OwningColumn.Name == "Choose") && !bool.Parse(cell.Value.ToString()))
                {
                    this.dgvArea.Rows[rowIndex].Cells["beginTime"].Value = "";
                    this.dgvArea.Rows[rowIndex].Cells["endTime"].Value = "";
                }
            }
        }

 private void execDistinctData(string sFilter)
        {
            DataView defaultView = this.m_dtRegion.DefaultView;
            defaultView.RowFilter = sFilter;
            string[] columnNames = new string[this.dgvArea.Columns.Count];
            for (int i = 0; i < this.dgvArea.Columns.Count; i++)
            {
                columnNames[i] = this.dgvArea.Columns[i].DataPropertyName;
            }
            DataTable table = defaultView.ToTable(true, columnNames);
            this.dgvArea.DataSource = table;
        }

        private bool getParam()
        {
            try
            {
                string str = " delete from GpsCarBeBackTime where SimNum  = '[A]'; ";
                string format = " insert into GpsCarBeBackTime(SimNum, BeginTime, EndTime, RegionId) select '[A]', '{0}', '{1}', '{2}' ";
                string str3 = "  UNION ALL SELECT '[A]', '{0}', '{1}', '{2}' ";
                this.sSql = "";
                this.sSql = this.sSql + str;
                bool flag = true;
                foreach (DataGridViewRow row in (IEnumerable) this.dgvArea.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Choose"].Value))
                    {
                        if (((row.Cells["beginTime"].Value == null) || row.Cells["beginTime"].Value.ToString().Equals("")) || ((row.Cells["endTime"].Value == null) || row.Cells["endTime"].Value.ToString().Equals("")))
                        {
                            MessageBox.Show("区域 " + row.Cells["regionName"].Value + " 起始时间或终止时间为空");
                            this.sSql = "";
                            this.ParamList = "";
                            return false;
                        }
                        if (row.Cells["beginTime"].Value.ToString().Equals(row.Cells["endTime"].Value.ToString()))
                        {
                            MessageBox.Show("区域 " + row.Cells["regionName"].Value + " 起始时间等于终止时间，请修改。");
                            this.ParamList = "";
                            this.sSql = "";
                            return false;
                        }
                        if (flag)
                        {
                            flag = false;
                            this.sSql = this.sSql + string.Format(format, row.Cells["beginTime"].Value.ToString(), row.Cells["endTime"].Value.ToString(), row.Cells["regionId"].Value);
                        }
                        else
                        {
                            this.sSql = this.sSql + string.Format(str3, row.Cells["beginTime"].Value, row.Cells["endTime"].Value, row.Cells["regionId"].Value);
                        }
                        this.ParamList = this.ParamList + row.Cells["regionName"].Value.ToString() + ",";
                    }
                }
                this.ParamList = this.ParamList.Trim(new char[] { ',' });
                return true;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置车辆按时归班参数", exception.Message);
                this.ParamList = "";
                this.sSql = "";
                return false;
            }
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
            this.simNums = base.sCarSimNum.Split(new char[] { ',' });
            int iRegionFeature = 0;
            DataTable table = RemotingClient.Car_GetRegionInfo(this.simNums[0], iRegionFeature);
            string format = " select * from GpsCarBeBackTime where SimNum = {0} ";
            DataTable table2 = RemotingClient.ExecSql(string.Format(format, this.simNums[0]));
            string str2 = "";
            string str3 = "";
            string sRegionDot = "";
            string str5 = "";
            bool flag = false;
            string str6 = "";
            string str7 = "";
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    str2 = row["regionID"].ToString();
                    str3 = row["regionName"].ToString();
                    sRegionDot = row["regionDot"].ToString();
                    if (Check.isRectangle(sRegionDot))
                    {
                        str5 = row["pathgroupid"].ToString();
                        if ((table2 != null) && (table2.Rows.Count > 0))
                        {
                            DataRow[] rowArray = table2.Select("RegionID = " + str2);
                            if ((rowArray != null) && (rowArray.Length > 0))
                            {
                                flag = true;
                                str6 = rowArray[0]["BeginTime"].ToString();
                                str7 = rowArray[0]["EndTime"].ToString();
                            }
                            else
                            {
                                flag = false;
                                str6 = "";
                                str7 = "";
                            }
                        }
                        else
                        {
                            flag = false;
                            str6 = "";
                            str7 = "";
                        }
                        DataRow row2 = this.m_dtRegion.NewRow();
                        row2["regionName"] = str3;
                        row2["regionId"] = str2;
                        row2["regionDot"] = sRegionDot;
                        row2["Choose"] = flag;
                        row2["beginTime"] = string.IsNullOrEmpty(str6) ? "" : Convert.ToDateTime(str6).TimeOfDay.ToString();
                        row2["endTime"] = string.IsNullOrEmpty(str7) ? "" : Convert.ToDateTime(str7).TimeOfDay.ToString();
                        row2["PathGroupId"] = str5;
                        this.m_dtRegion.Rows.Add(row2);
                    }
                }
                this.execDistinctData("");
            }
        }

        private void InitDataSource()
        {
            this.m_dtRegion.Columns.Add("regionName");
            this.m_dtRegion.Columns.Add("regionId");
            this.m_dtRegion.Columns.Add("regionDot");
            this.m_dtRegion.Columns.Add("Choose");
            this.m_dtRegion.Columns["Choose"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("beginTime");
            this.m_dtRegion.Columns["beginTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("endTime");
            this.m_dtRegion.Columns["endTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("PathGroupId");
            this.m_dtRegion.Columns["PathGroupId"].DefaultValue = "";
        }

 private void itmCarBeBackTime_Load(object sender, EventArgs e)
        {
            this.InitComboBox();
            this.InitDataSource();
            this.InitData();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            this.grpArea.Enabled = base.grpCar.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        private void tsBtnFilter_Click(object sender, EventArgs e)
        {
            if ((this.comboBoxLines.SelectedValue == null) || this.comboBoxLines.SelectedValue.ToString().Equals(""))
            {
                this.execDistinctData("");
            }
            else
            {
                try
                {
                    string str = this.comboBoxLines.SelectedValue.ToString();
                    string sFilter = "pathGroupID ='" + str + "'";
                    this.execDistinctData(sFilter);
                }
                catch
                {
                }
            }
        }
    }
}

