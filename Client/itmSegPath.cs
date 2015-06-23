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
    using Library;

    public partial class itmSegPath : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private static string ERRORPATHAlARM = "解析行驶线路失败！";
        private DataTable m_dtPathGroup = new DataTable();
        private DataTable m_dtSegPathData = new DataTable();
        private PathAlarmList m_pathAlarmList = new PathAlarmList();

        public itmSegPath(CmdParam.OrderCode OrderCode)
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
                        base.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(base.ParamType, str, base.sPw, CmdParam.CommMode.未知方式, this.m_pathAlarmList);
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                    }
                }
                else
                {
                    base.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_pathAlarmList);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置分段超速报警-->", exception.Message);
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

        private void btmAllSelect_Click(object sender, EventArgs e)
        {
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有预设路线！");
            }
            else if (this.btmAllSelect.Text == "全选")
            {
                foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
                {
                    if (row.Cells["Choose"].Value.ToString() != "1")
                    {
                        row.Cells["Choose"].Value = true;
                    }
                }
                this.btmAllSelect.Text = "全不选";
            }
            else
            {
                foreach (DataGridViewRow row2 in (IEnumerable) this.dgvSubSpeedParam.Rows)
                {
                    if (row2.Cells["Choose"].Value.ToString() == "1")
                    {
                        row2.Cells["Choose"].Value = false;
                    }
                }
                this.btmAllSelect.Text = "全选";
            }
        }

        private void btnCopyToSelected_Click(object sender, EventArgs e)
        {
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有预设路线！");
            }
            else
            {
                int rowIndex = this.dgvSubSpeedParam.CurrentCell.RowIndex;
                if ((rowIndex >= 0) && (rowIndex <= this.dgvSubSpeedParam.Rows.Count))
                {
                    if ((((this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value == null) || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value == null)) || ((this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value == null) || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value == null))) || (((this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value.ToString() == "") || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value.ToString() == "")) || ((this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value.ToString() == "") || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value.ToString() == ""))))
                    {
                        MessageBox.Show("请输入数据或选择有数据的行");
                    }
                    else
                    {
                        foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
                        {
                            if (row.Cells["Choose"].Value.ToString() == "1")
                            {
                                row.Cells["TopSpeed"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value;
                                row.Cells["HoldTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value;
                                row.Cells["BeginTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value;
                                row.Cells["EndTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value;
                            }
                        }
                    }
                }
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

        private void dataFilter(string filterString)
        {
            try
            {
                base.Enabled = false;
                if (this.dgvSubSpeedParam.DataSource != null)
                {
                    DataTable dataSource = this.dgvSubSpeedParam.DataSource as DataTable;
                    dataSource.DefaultView.RowFilter = "PathName like '%" + filterString + "%'";
                    this.dgvSubSpeedParam.Refresh();
                }
            }
            catch
            {
            }
            finally
            {
                base.Enabled = true;
            }
        }

        private void dgvSubSpeedParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                int rowIndex = e.RowIndex;
                DataGridViewCell cell = this.dgvSubSpeedParam.Rows[rowIndex].Cells[e.ColumnIndex];
                if (((cell.OwningColumn.Name == "TopSpeed") || (cell.OwningColumn.Name == "HoldTime")) || ((cell.OwningColumn.Name == "BeginTime") || (cell.OwningColumn.Name == "EndTime")))
                {
                    DataGridViewCell cell2 = this.dgvSubSpeedParam.Rows[rowIndex].Cells["Choose"];
                    if (!string.IsNullOrEmpty(cell2.Value.ToString()) && (cell2.Value.ToString() == "1"))
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].ReadOnly = false;
                    }
                    else
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value = "";
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value = "";
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].ReadOnly = true;
                    }
                    cell2 = null;
                }
            }
        }

        private void dgvSubSpeedParam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = ((DataGridView) sender).CurrentCell;
            if ((currentCell.ColumnIndex == this.dgvSubSpeedParam.Columns["BeginTime"].Index) || (currentCell.ColumnIndex == this.dgvSubSpeedParam.Columns["EndTime"].Index))
            {
                DataGridViewCell cell2 = this.dgvSubSpeedParam.Rows[e.RowIndex].Cells["Choose"];
                if (!string.IsNullOrEmpty(cell2.Value.ToString()) && (cell2.Value.ToString() == "1"))
                {
                    SetDateTime time = new SetDateTime(currentCell.Value.ToString()); ///ToString
                    if (time.ShowDialog() == DialogResult.OK)
                    {
                        currentCell.Value = time.Time;
                        this.dgvSubSpeedParam.EndEdit();
                    }
                }
            }
        }

        private void dgvSubSpeedParam_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                DataGridViewCell cell = this.dgvSubSpeedParam.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    this.dgvSubSpeedParam.EndEdit();
                }
            }
        }

        private void dgvSubSpeedParam_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                int rowIndex = e.RowIndex;
                DataGridViewCell cell = this.dgvSubSpeedParam.Rows[rowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "Choose")
                {
                    if (!string.IsNullOrEmpty(cell.Value.ToString()) && (cell.Value.ToString() == "1"))
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].ReadOnly = false;
                    }
                    else
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value = "";
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value = "";
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].ReadOnly = true;
                    }
                }
            }
        }

        private void dgvSubSpeedParam_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = this.dgvSubSpeedParam.CurrentCell.ColumnIndex;
            if ((this.dgvSubSpeedParam.Columns[columnIndex].Name == "TopSpeed") || (this.dgvSubSpeedParam.Columns[columnIndex].Name == "HoldTime"))
            {
                this.EditingControl = (DataGridViewTextBoxEditingControl) e.Control;
                this.EditingControl.KeyPress += new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
        }

 private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private void execDistinctData(string sFilter)
        {
            DataView defaultView = this.m_dtSegPathData.DefaultView;
            defaultView.RowFilter = sFilter;
            string[] columnNames = new string[this.dgvSubSpeedParam.Columns.Count];
            for (int i = 0; i < this.dgvSubSpeedParam.Columns.Count; i++)
            {
                columnNames[i] = this.dgvSubSpeedParam.Columns[i].DataPropertyName;
            }
            DataTable table = defaultView.ToTable(true, columnNames);
            this.dgvSubSpeedParam.DataSource = table;
        }

        private string getCheckPathName()
        {
            string str = "";
            foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
            {
                if (row.Cells["Choose"].Value.ToString() == "1")
                {
                    str = str + "'" + row.Cells["PathName"].Value.ToString() + "',";
                }
            }
            return str.Trim(new char[] { ',' });
        }

        private bool getParam()
        {
            this.dataFilter("");
            string str = this.getCheckPathName();
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("没有选择预设路线！");
                return false;
            }
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有路线");
                return false;
            }
            DataTable table = RemotingClient.Car_GetPathRouteByPathName(str);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                MessageBox.Show("没有读取到偏移路线数据，请重新设置");
                return false;
            }
            foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
            {
                if (row.Cells["Choose"].Value.ToString() == "1")
                {
                    string str2 = row.Cells["PathName"].Value.ToString();
                    PathAlarm alarm = new PathAlarm();
                    ArrayList list = new ArrayList();
                    alarm.Points = list;
                    alarm.PathName = str2;
                    DataView view = new DataView(table, "PathName='" + str2 + "'", "", DataViewRowState.CurrentRows);
                    string str3 = string.Empty;
                    if ((view != null) && (view.Count > 0))
                    {
                        str3 = view[0]["alarmPathDot"].ToString();
                    }
                    if (string.IsNullOrEmpty(str3))
                    {
                        MessageBox.Show(ERRORPATHAlARM);
                        return false;
                    }
                    string[] strArray = str3.Split(new char[] { '/' });
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
                    string pStrNum = row.Cells["TopSpeed"].Value.ToString();
                    string str5 = row.Cells["HoldTime"].Value.ToString();
                    if (!Check.isNumeric(pStrNum, Check.NumType.sByte))
                    {
                        MessageBox.Show("路线\"" + str2 + "\"最高时速必须为0-255的数字！");
                        return false;
                    }
                    alarm.Speed = byte.Parse(pStrNum);
                    if (!Check.isNumeric(str5, Check.NumType.sByte) || ((int.Parse(str5) % 5) != 0))
                    {
                        MessageBox.Show("路线\"" + str2 + "\"持续时长必须为0-255之间5的倍数！");
                        return false;
                    }
                    alarm.Time = byte.Parse(str5);
                    string strDate = row.Cells["BeginTime"].Value.ToString();
                    string str7 = row.Cells["EndTime"].Value.ToString();
                    string strResultDate = string.Empty;
                    string str9 = string.Empty;
                    if (strDate.Length == 0)
                    {
                        MessageBox.Show("路线\"" + str2 + "\"没有设置起始时间！");
                        return false;
                    }
                    if (str7.Length == 0)
                    {
                        MessageBox.Show("路线\"" + str2 + "\"没有设置终止时间！");
                        return false;
                    }
                    if (!Check.CheckIsDate(strDate, out strResultDate))
                    {
                        MessageBox.Show("路线\"" + str2 + "\"起始时间格式有误！");
                        return false;
                    }
                    if (!Check.CheckIsDate(str7, out str9))
                    {
                        MessageBox.Show("路线\"" + str2 + "\"终止时间格式有误！");
                        return false;
                    }
                    alarm.BeginTime = strDate;
                    alarm.EndTime = str7;
                    alarm.sBeginTime = strResultDate;
                    alarm.sEndTime = str9;
                    string str10 = alarm.BeginTime.Substring(0, 4);
                    string str11 = alarm.EndTime.Substring(0, 4);
                    if (((str10 == "0000") && (str11 != "0000")) || ((str11 == "0000") && (str10 != "0000")))
                    {
                        MessageBox.Show("路线\"" + str2 + "\"设置起始时间和终止时间时，固定时段参数勾选状态需保持一致！");
                        return false;
                    }
                    if ((str10 != "0000") && (DateTime.Parse(alarm.BeginTime) > DateTime.Parse(alarm.EndTime)))
                    {
                        MessageBox.Show("路线\"" + str2 + "\"起始时间不能大于终止时间！");
                        return false;
                    }
                    this.m_pathAlarmList.Add(alarm);
                }
            }
            if ((this.m_pathAlarmList == null) || (this.m_pathAlarmList.Count < 0))
            {
                return false;
            }
            this.m_pathAlarmList.OrderCode = base.OrderCode;
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

        private void InitGridView()
        {
            string strCarId = (base.sCarId.Split(",".ToCharArray()).Length > 1) ? base.sCarId.Split(",".ToCharArray())[0] : base.sCarId;
            this.m_dtSegPathData = RemotingClient.Car_GetPathAlarm(strCarId);
            if (this.m_dtSegPathData != null)
            {
                this.execDistinctData("");
            }
            this.dgvSubSpeedParam.Columns["Choose"].Tag = "Chk";
        }

 private void itmSegPath_Load(object sender, EventArgs e)
        {
            this.InitGridView();
            this.InitComboBox();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = this.grpSetSubSpeedAlarmParam.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
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
                    string s = this.comboBoxLines.SelectedValue.ToString();
                    string sFilter = "pathGroupID =" + int.Parse(s);
                    this.execDistinctData(sFilter);
                }
                catch
                {
                }
            }
        }

        private void tsBtnSearchdata_Click(object sender, EventArgs e)
        {
            this.dataFilter(this.txtFindRegion.Text);
        }

        private void txtFindRegion_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

