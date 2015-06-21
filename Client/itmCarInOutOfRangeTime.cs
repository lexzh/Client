namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmCarInOutOfRangeTime : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private DataTable m_dtRegion = new DataTable();
        private string ParamList = "";
        private string[] simNums;
        private string sSql = "";

        public itmCarInOutOfRangeTime()
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
                        string orderName = "设置车辆按时到离站";
                        string sMsg = "设置车辆按时到离站-" + this.ParamList;
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
                Record.execFileRecord("设置平台按时进出站报警-->", exception.Message);
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
                Record.execFileRecord("设置车辆按时到离站-->", exception.Message);
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

        private void CreateComboBoxWithEnums()
        {
            this.AllRegion = RemotingClient.Alarm_GetRegionInfo();
            DataGridViewComboBoxColumn column = this.dgvPostRoute.Columns["PointName"] as DataGridViewComboBoxColumn;
            column.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            Dictionary<string, string> dataSource = new Dictionary<string, string>();
            foreach (DataRow row in this.AllRegion.Rows)
            {
                if (PublicClass.Check.isRectangle(row["RegionDot"].ToString()))
                {
                    dataSource[row["regionName"].ToString()] = row["regionID"] + "◎";
                }
            }
            if ((dataSource != null) && (dataSource.Count > 0))
            {
                column.DataSource = new BindingSource(dataSource, null);
                column.DisplayMember = "Key";
                column.ValueMember = "Value";
            }
        }

        private void DeleteRow(int Index)
        {
            if (MessageBox.Show("是否要删除第" + (Index + 1) + "行", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.dgvPostRoute.Rows.RemoveAt(Index);
                this.UpdateNum(Index);
            }
        }

        private void dgvPostRoute_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.dgvPostRoute.Columns[e.ColumnIndex].Name == "CrossDay") && (this.dgvPostRoute.Rows[e.RowIndex].Cells["PointName"].Value.ToString() != ""))
            {
                this.dgvPostRoute.Rows[e.RowIndex].Cells["CrossDay"].Value = !Convert.ToBoolean(this.dgvPostRoute.Rows[e.RowIndex].Cells["CrossDay"].Value);
            }
        }

        private void dgvPostRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = ((DataGridView) sender).CurrentCell;
            int rowIndex = e.RowIndex;
            if ((e.RowIndex >= 0) && ((currentCell.ColumnIndex == this.dgvPostRoute.Columns["StartTime"].Index) || (currentCell.ColumnIndex == this.dgvPostRoute.Columns["EndTime"].Index)))
            {
                if ((this.dgvPostRoute.CurrentRow.Cells["PointName"].Value == null) || (this.dgvPostRoute.CurrentRow.Cells["PointName"].Value.ToString() == ""))
                {
                    MessageBox.Show("请先选择站点，再添加时间。");
                }
                else
                {
                    SetDateTime time = new SetDateTime(string.IsNullOrEmpty(currentCell.Value.ToString()) ? "" : ("0000-00-00 " + currentCell.Value), true) {
                        StartPosition = FormStartPosition.Manual,
                        Location = Cursor.Position
                    };
                    if (time.ShowDialog() == DialogResult.OK)
                    {
                        currentCell.Value = time.Time.Replace("0000-00-00 ", "");
                        this.dgvPostRoute.EndEdit();
                    }
                }
            }
        }

        private void dgvPostRoute_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.dgvPostRoute.Columns[e.ColumnIndex].Name == "PointName") && (e.RowIndex >= 0))
            {
                try
                {
                    if (((this.dgvPostRoute.Rows[e.RowIndex].Cells["PointName"].Value != null) && (this.dgvPostRoute.Rows[e.RowIndex].Cells["PointName"].Value != DBNull.Value)) && (this.dgvPostRoute.Rows[e.RowIndex].Cells["PointName"].Value.ToString().IndexOf('◎') > 0))
                    {
                        int regionID = Convert.ToInt32(this.dgvPostRoute.Rows[e.RowIndex].Cells["PointName"].Value.ToString().Trim(new char[] { '◎' }));
                        this.dgvPostRoute.Rows[e.RowIndex].Cells["PointIndex"].Value = e.RowIndex + 1;
                        this.dgvPostRoute.Rows[e.RowIndex].Cells["PointID"].Value = regionID + "◎";
                        int repeatIndex = -1;
                        if (this.IsRepeat(regionID, e.RowIndex, ref repeatIndex))
                        {
                            MessageBox.Show(string.Concat(new object[] { "第", repeatIndex, "行与第", e.RowIndex + 1, "行的站点有重复，请修改" }));
                        }
                        this.dgvPostRoute.CurrentCell = this.dgvPostRoute.Rows[e.RowIndex + 1].Cells["PointName"];
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void dgvPostRoute_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvPostRoute.Columns[e.ColumnIndex].Name == "PointName")
            {
                try
                {
                    DataRow[] rowArray = this.AllRegion.Select("regionID = " + Convert.ToInt32(this.dgvPostRoute.Rows[e.RowIndex].Cells["PointID"].Value.ToString().Trim(new char[] { '◎' })));
                    if ((rowArray != null) && (rowArray.Length > 0))
                    {
                        e.Value = rowArray[0]["regionName"].ToString();
                    }
                }
                catch
                {
                }
            }
        }

        private void dgvPostRoute_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (((e.ColumnIndex >= 0) && (e.RowIndex >= 0)) && ((e.RowIndex < this.dgvPostRoute.Rows.Count) && (e.Button == MouseButtons.Right)))
            {
                this.dgvPostRoute.CurrentCell = this.dgvPostRoute.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvPostRoute_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((this.dgvPostRoute.Columns[e.ColumnIndex].Name == "PointName") && (e.Exception is ArgumentException))
            {
                e.Cancel = true;
            }
        }

        private void dgvPostRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Delete) && (this.dgvPostRoute.CurrentCell != null)) && ((this.dgvPostRoute.CurrentCell.RowIndex + 1) < this.dgvPostRoute.Rows.Count))
            {
                this.DeleteRow(this.dgvPostRoute.CurrentCell.RowIndex);
                e.Handled = true;
            }
        }

 private bool getParam()
        {
            try
            {
                if (this.IsPointNull())
                {
                    return false;
                }
                if (this.IsRepeat())
                {
                    return false;
                }
                string str = " delete from GpsCarInOutOfRangeTime where simnum = '[A]'; ";
                string format = " insert into GpsCarInOutOfRangeTime(SimNum, StartTime, EndTime, CrossDay, regionId, regionIndex) select '[A]', '{0}', '{1}', '{2}', '{3}', '{4}' ";
                string str3 = " UNION All select '[A]', '{0}', '{1}', '{2}', '{3}', '{4}' ";
                this.sSql = "";
                this.sSql = this.sSql + str;
                bool flag = true;
                if ((this.dgvPostRoute.DataSource is DataTable) && ((this.dgvPostRoute.DataSource as DataTable).Rows.Count > 0))
                {
                    foreach (DataRow row in (this.dgvPostRoute.DataSource as DataTable).Rows)
                    {
                        if (flag)
                        {
                            flag = false;
                            this.sSql = this.sSql + string.Format(format, new object[] { row["StartTime"], row["EndTime"], row["CrossDay"], row["PointId"].ToString().Replace("◎", ""), row["PointIndex"] });
                        }
                        else
                        {
                            this.sSql = this.sSql + string.Format(str3, new object[] { row["StartTime"], row["EndTime"], row["CrossDay"], row["PointId"].ToString().Replace("◎", ""), row["PointIndex"] });
                        }
                        this.ParamList = this.ParamList + row["PointName"].ToString() + ",";
                    }
                    this.ParamList = this.ParamList.Replace("◎", "").Trim(new char[] { ',' });
                }
                return true;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置车辆按时到离站参数", exception.Message);
                this.ParamList = "";
                this.sSql = "";
                return false;
            }
        }

        private void InitData()
        {
            this.simNums = base.sCarSimNum.Split(new char[] { ',' });
            string format = " select a.ID, a.SimNum, a.StartTime, a.EndTime, a.CrossDay, a.regionId, a.regionIndex, b.regionName from GpsCarInOutOfRangeTime a INNER JOIN GpsRegionType b on a.regionID = b.regionID where a.SimNum = '{0}' order by regionIndex ";
            DataTable table = RemotingClient.ExecSql(string.Format(format, this.simNums[0]));
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow row2 = this.m_dtRegion.NewRow();
                    row2["PointIndex"] = row["regionIndex"];
                    row2["PointID"] = row["regionId"];
                    row2["PointName"] = row["regionName"];
                    row2["StartTime"] = Convert.ToDateTime(row["StartTime"]).ToString("HH:mm:ss");
                    row2["EndTime"] = Convert.ToDateTime(row["EndTime"]).ToString("HH:mm:ss");
                    row2["CrossDay"] = row["CrossDay"];
                    this.m_dtRegion.Rows.Add(row2);
                }
            }
            this.dgvPostRoute.DataSource = this.m_dtRegion;
        }

        private void InitDataSource()
        {
            this.m_dtRegion.Columns.Add("PointIndex");
            this.m_dtRegion.Columns.Add("PointID");
            this.m_dtRegion.Columns.Add("PointName");
            this.m_dtRegion.Columns.Add("StartTime");
            this.m_dtRegion.Columns["StartTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("EndTime");
            this.m_dtRegion.Columns["EndTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("CrossDay");
            this.m_dtRegion.Columns["CrossDay"].DefaultValue = false;
        }

 private bool IsPointNull()
        {
            int num = 0;
            string str = "";
            foreach (DataRow row in (this.dgvPostRoute.DataSource as DataTable).Rows)
            {
                num++;
                if ((row["PointName"] == null) || (row["PointName"].ToString() == ""))
                {
                    MessageBox.Show("第" + num + "行站点名称为空，请选择。");
                    return true;
                }
                if ((row["StartTime"] == null) || (row["StartTime"].ToString() == ""))
                {
                    MessageBox.Show("第" + num + "行站点到达时间为空，请填写。");
                    return true;
                }
                if ((row["EndTime"] == null) || (row["EndTime"].ToString() == ""))
                {
                    MessageBox.Show("第" + num + "行站点离开时间为空，请填写。");
                    return true;
                }
                if (Convert.ToDateTime("1970-01-01 " + row["EndTime"].ToString()) == Convert.ToDateTime("1970-01-01 " + row["StartTime"].ToString()))
                {
                    MessageBox.Show("第" + num + "行站点离开时间与到达时间相同，请修改。");
                    return true;
                }
                if (!Convert.ToBoolean(row["CrossDay"]) && (Convert.ToDateTime("1970-01-01 " + row["EndTime"].ToString()) < Convert.ToDateTime("1970-01-01 " + row["StartTime"].ToString())))
                {
                    MessageBox.Show("第" + num + "行站点离开时间小于到达时间，请修改。");
                    return true;
                }
                if ((!string.IsNullOrEmpty(str) && !Convert.ToBoolean(row["CrossDay"])) && (Convert.ToDateTime("1970-01-01 " + row["StartTime"].ToString()) < Convert.ToDateTime("1970-01-01 " + str)))
                {
                    MessageBox.Show("第" + num + "行站点到达时间小于上一站点离开时间，请修改。");
                    return true;
                }
                str = row["EndTime"].ToString();
            }
            return false;
        }

        private bool IsRepeat()
        {
            for (int i = 0; i < (this.dgvPostRoute.Rows.Count - 2); i++)
            {
                int num2 = Convert.ToInt32(this.dgvPostRoute.Rows[i].Cells["PointID"].Value.ToString().Trim(new char[] { '◎' }));
                for (int j = i + 1; j < (this.dgvPostRoute.Rows.Count - 1); j++)
                {
                    try
                    {
                        if (Convert.ToInt32(this.dgvPostRoute.Rows[j].Cells["PointID"].Value.ToString().Trim(new char[] { '◎' })) == num2)
                        {
                            DateTime time = Convert.ToDateTime("1970-01-01 " + this.dgvPostRoute.Rows[i].Cells["StartTime"].Value.ToString());
                            DateTime time2 = Convert.ToDateTime("1970-01-01 " + this.dgvPostRoute.Rows[i].Cells["EndTime"].Value.ToString());
                            DateTime time3 = Convert.ToDateTime("1970-01-01 " + this.dgvPostRoute.Rows[j].Cells["StartTime"].Value.ToString());
                            DateTime time4 = Convert.ToDateTime("1970-01-01 " + this.dgvPostRoute.Rows[j].Cells["EndTime"].Value.ToString());
                            if (((time2 > time) && (((time3 >= time) && (time3 <= time2)) || ((time4 >= time) && (time4 <= time2)))) || ((time2 < time) && ((((time3 >= time) && (time3 <= time2.AddHours(24.0))) || ((time4 >= time) && (time4 <= time2.AddHours(24.0)))) || (((time3.AddHours(24.0) >= time) && (time3.AddHours(24.0) <= time2.AddHours(24.0))) || ((time4.AddHours(24.0) >= time) && (time4.AddHours(24.0) <= time2.AddHours(24.0)))))))
                            {
                                MessageBox.Show(string.Format(string.Concat(new object[] { "第", i + 1, "行与", j + 1, "行相同站点时间不能有重叠，请修改。" }), i + 1, j + 1));
                                return true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return false;
        }

        private bool IsRepeat(int regionID, int rowIndex, ref int repeatIndex)
        {
            return false;
        }

        private void itmCarPostalRoute_Load(object sender, EventArgs e)
        {
            this.CreateComboBoxWithEnums();
            this.InitDataSource();
            this.InitData();
        }

        private void MenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if ((this.dgvPostRoute.CurrentRow.Index + 1) >= this.dgvPostRoute.Rows.Count)
            {
                e.Cancel = true;
            }
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            this.grpPostalRoute.Enabled = base.grpCar.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        private void UpdateNum(int startIndex)
        {
            if ((this.dgvPostRoute.DataSource != null) && (startIndex < (this.dgvPostRoute.DataSource as DataTable).Rows.Count))
            {
                for (int i = startIndex; i < (this.dgvPostRoute.DataSource as DataTable).Rows.Count; i++)
                {
                    (this.dgvPostRoute.DataSource as DataTable).Rows[i]["PointIndex"] = i + 1;
                }
            }
        }

        private void 插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dgvPostRoute.CurrentCell.RowIndex;
            DataRow row = this.m_dtRegion.NewRow();
            row["PointIndex"] = rowIndex + 1;
            row["PointName"] = "";
            (this.dgvPostRoute.DataSource as DataTable).Rows.InsertAt(row, rowIndex);
            this.UpdateNum(rowIndex + 1);
        }

        private void 删除此行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteRow(this.dgvPostRoute.CurrentCell.RowIndex);
        }
    }
}

