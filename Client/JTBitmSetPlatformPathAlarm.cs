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

    public partial class JTBitmSetPlatformPathAlarm : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private List<object> checklist = new List<object>();
        private string checkPathList = "";
        private static string ERRORPATHAlARM = "解析行驶线路失败！";
        private object[] list;
        private DataTable m_dtAlarmCar = new DataTable();
        private DataTable m_dtPathAlarm = new DataTable();
        private DataTable m_dtPathGroup = new DataTable();
        private PathAlarmList m_PathAlarmList = new PathAlarmList();
        private ParamLibrary.CmdParamInfo.SimpleCmd m_SimpleCmd = new ParamLibrary.CmdParamInfo.SimpleCmd();
        private TrafficSimpleCmd SimpleCmd = new TrafficSimpleCmd();

        public JTBitmSetPlatformPathAlarm(CmdParam.OrderCode OrderCode)
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
                Record.execFileRecord("设置分段偏移路线平台报警-->", exception.Message);
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
        }

        private void clbSelectRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = ((DataGridView) sender).CurrentCell;
            int rowIndex = e.RowIndex;
            if (((e.RowIndex >= 0) && (currentCell.OwningColumn.Name.Equals("开始时间") || currentCell.OwningColumn.Name.Equals("结束时间"))) && this.clbSelectRoute.Rows[e.RowIndex].Cells["选择"].Value.ToString().Equals("1"))
            {
                SetDateTime time = new SetDateTime(currentCell.Value.ToString()); ///ToString
                if (time.ShowDialog() == DialogResult.OK)
                {
                    currentCell.Value = time.Time;
                    this.clbSelectRoute.EndEdit();
                }
            }
        }

        private void ClearCellValue(int row)
        {
            this.clbSelectRoute.Rows[row].Cells["开始时间"].Value = "";
            this.clbSelectRoute.Rows[row].Cells["结束时间"].Value = "";
        }

        private void dataBuffer()
        {
        }

        private void dataFilter(string filterString)
        {
        }

        private void dgvDataList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.clbSelectRoute[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("选择"))
            {
                foreach (DataGridViewRow row in (IEnumerable) this.clbSelectRoute.Rows)
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
                DataGridViewCell cell = this.clbSelectRoute.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    this.clbSelectRoute.EndEdit();
                }
            }
        }

 private DataTable getCheckPathName()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("PathID");
            DataColumn column2 = new DataColumn("BeginTime");
            DataColumn column3 = new DataColumn("EndTime");
            table.Columns.AddRange(new DataColumn[] { column, column2, column3 });
            foreach (DataGridViewRow row in (IEnumerable) this.clbSelectRoute.Rows)
            {
                if (row.Cells["选择"].Value.ToString().Equals("1"))
                {
                    if ((row.Cells["开始时间"].Value.ToString().Length == 0) || (row.Cells["结束时间"].Value.ToString().Length == 0))
                    {
                        MessageBox.Show("请设置开始时间或者结束时间!");
                        return null;
                    }
                    if (((row.Cells["开始时间"].Value.ToString().IndexOf("0000") >= 0) && (row.Cells["结束时间"].Value.ToString().IndexOf("0000") < 0)) || ((row.Cells["开始时间"].Value.ToString().IndexOf("0000") < 0) && (row.Cells["结束时间"].Value.ToString().IndexOf("0000") >= 0)))
                    {
                        MessageBox.Show(row.Cells["路线名称"].Value.ToString() + "的开始时间和结束时间设置格式不一致!");
                        return null;
                    }
                    string str = row.Cells["开始时间"].Value.ToString();
                    string str2 = row.Cells["结束时间"].Value.ToString();
                    string str3 = row.Cells["pathid"].Value.ToString();
                    DataRow row2 = table.NewRow();
                    row2["pathid"] = str3;
                    row2["beginTime"] = str.Replace("0000-00-00", "1900-01-01");
                    row2["endTime"] = str2.Replace("0000-00-00", "1900-01-01");
                    if (!str.StartsWith("0000") && (Convert.ToDateTime(row2["beginTime"]) > Convert.ToDateTime(row2["endTime"])))
                    {
                        MessageBox.Show(row.Cells["路线名称"].Value.ToString() + "的开始时间不能大于结束时间!");
                        return null;
                    }
                    table.Rows.Add(row2);
                }
            }
            return table;
        }

        private bool getParam()
        {
            this.dataFilter("");
            DataTable table = this.getCheckPathName();
            if (table == null)
            {
                return false;
            }
            this.SimpleCmd.OrderCode = base.OrderCode;
            this.SimpleCmd.CommonArgs = table;
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
            string strCarId = (base.sCarId.Split(",".ToCharArray()).Length > 1) ? base.sCarId.Split(",".ToCharArray())[0] : base.sCarId;
            this.m_dtPathAlarm = RemotingClient.Car_GetPathAlarmAnother(strCarId);
            this.m_dtAlarmCar = RemotingClient.GetCommonData(strCarId, 1, null);
            new DataTable();
            DataColumn column4 = new DataColumn("PathID") {
                DataType = this.m_dtPathAlarm.Columns["PathID"].DataType
            };
            DataColumn column = new DataColumn("BeginTime");
            DataColumn column2 = new DataColumn("EndTime");
            this.m_dtPathAlarm.Columns.AddRange(new DataColumn[] { column, column2 });
            DataColumn column3 = new DataColumn("isCheck") {
                AllowDBNull = true
            };
            this.m_dtPathAlarm.Columns.Add(column3);
            this.clbSelectRoute.AutoGenerateColumns = false;
            foreach (DataRow row in this.m_dtPathAlarm.Rows)
            {
                row["IsCheck"] = 0;
                DataRow[] rowArray = this.m_dtAlarmCar.Select("PathID='" + row["PathID"] + "'");
                if (rowArray.Length > 0)
                {
                    row["BeginTime"] = rowArray[0]["BeginTime"];
                    row["EndTime"] = rowArray[0]["EndTime"];
                }
                if (row["BeginTime"].ToString().Length > 0)
                {
                    row["IsCheck"] = 1;
                }
                row["BeginTime"] = row["BeginTime"].ToString().Replace("1900-01-01", "0000-00-00").Replace("1900-1-1", "0000-00-00");
                row["EndTime"] = row["EndTime"].ToString().Replace("1900-01-01", "0000-00-00").Replace("1900-1-1", "0000-00-00");
            }
            this.clbSelectRoute.DataSource = this.m_dtPathAlarm;
        }

        private bool isCellSelected(int row)
        {
            return this.clbSelectRoute.Rows[row].Cells["选择"].Value.ToString().Equals("1");
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

        private void setListBox(DataTable dtPathAlarm, DataTable dtPathSet)
        {
        }

        private void tsBtnFilter_Click(object sender, EventArgs e)
        {
            if ((this.comboBoxLines.SelectedValue == null) || this.comboBoxLines.SelectedValue.ToString().Equals(""))
            {
                this.setListBox(this.m_dtPathAlarm, this.m_dtAlarmCar);
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
                    this.setListBox(dtPathAlarm, this.m_dtAlarmCar);
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

