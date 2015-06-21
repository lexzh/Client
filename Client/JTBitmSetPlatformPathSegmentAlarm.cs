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

    public partial class JTBitmSetPlatformPathSegmentAlarm : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private DataTable m_dtAlarmCar = new DataTable();
        private DataTable m_dtPathAlarm = new DataTable();
        private DataTable m_dtPathGroup = new DataTable();
        private TrafficSimpleCmd SimpleCmd = new TrafficSimpleCmd();

        public JTBitmSetPlatformPathSegmentAlarm(CmdParam.OrderCode OrderCode)
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
                Record.execFileRecord("设置平台分路段超速报警-->", exception.Message);
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

        private void btnCloseGrpSegment_Click(object sender, EventArgs e)
        {
            (this.dgvPathSegment.DataSource as DataTable).RejectChanges();
            this.grpSegment.SendToBack();
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

        private void btnSegmentSet_Click(object sender, EventArgs e)
        {
            bool flag = true;
            foreach (DataGridViewRow row in (IEnumerable) this.dgvPathSegment.Rows)
            {
                int result = 0;
                flag = int.TryParse(row.Cells["速度"].Value.ToString(), out result);
                if (!flag || (result > 255))
                {
                    MessageBox.Show("请检查输入为空且速度值不能大于255!");
                    break;
                }
            }
            if (flag)
            {
                (this.dgvPathSegment.DataSource as DataTable).AcceptChanges();
                this.grpSegment.SendToBack();
            }
        }

        private void clbSelectRoute_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                int rowIndex = e.RowIndex;
                DataGridViewCell cell = this.clbSelectRoute.Rows[rowIndex].Cells["选择"];
                if (this.clbSelectRoute[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("设置") && (cell.Value.ToString() == "1"))
                {
                    (this.dgvPathSegment.DataSource as DataTable).DefaultView.RowFilter = "PathID='" + this.clbSelectRoute.Rows[rowIndex].Cells["PathID"].Value.ToString() + "'";
                    this.grpSegment.Location = this.clbSelectRoute.Location;
                    this.grpSegment.Size = this.clbSelectRoute.Size;
                    this.grpSegment.BringToFront();
                }
            }
        }

 private bool getParam()
        {
            this.SimpleCmd.OrderCode = base.OrderCode;
            DataTable table = (this.dgvPathSegment.DataSource as DataTable).Copy();
            foreach (DataGridViewRow row in (IEnumerable) this.clbSelectRoute.Rows)
            {
                if (row.Cells["选择"].Value.ToString().Equals("0"))
                {
                    DataRow[] rowArray = table.Select("PathID='" + row.Cells["PathID"].Value.ToString() + "'");
                    for (int i = 0; i < rowArray.Length; i++)
                    {
                        table.Rows.Remove(rowArray[i]);
                    }
                }
            }
            table.Columns.Remove("PathSegmentName");
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
            this.m_dtAlarmCar = RemotingClient.GetCommonData((base.sCarId.Split(new char[] { ',' }).Length > 0) ? base.sCarId.Split(new char[] { ',' })[0] : base.sCarId, 3, null);
            DataColumn column = new DataColumn("isCheck") {
                DefaultValue = 0
            };
            this.m_dtPathAlarm.Columns.Add(column);
            DataColumn column2 = new DataColumn("isSet") {
                DefaultValue = "设置"
            };
            this.m_dtPathAlarm.Columns.Add(column2);
            this.clbSelectRoute.AutoGenerateColumns = false;
            DataTable table = new DataTable();
            table = RemotingClient.ExecSql("select pathid,pathsegmentid,pathsegmentname from GpsPathSegment");
            table.Columns.Add("Speed");
            foreach (DataRow row in this.m_dtPathAlarm.Rows)
            {
                DataRow[] rowArray = this.m_dtAlarmCar.Select("PathID='" + row["PathID"] + "'");
                if ((rowArray.Length > 0) && (rowArray[0]["Speed"].ToString().Length > 0))
                {
                    DataRow[] rowArray2 = table.Select("PathID='" + row["PathID"] + "'");
                    if (rowArray2.Length > 0)
                    {
                        foreach (DataRow row2 in rowArray2)
                        {
                            foreach (DataRow row3 in rowArray)
                            {
                                if (row2["PathSegmentID"].ToString().Equals(row3["PathSegmentID"].ToString()))
                                {
                                    row2["Speed"] = row3["Speed"];
                                    break;
                                }
                            }
                        }
                    }
                    row["IsCheck"] = 1;
                    row["isSet"] = "已设置";
                }
            }
            this.dgvPathSegment.DataSource = table;
            this.clbSelectRoute.DataSource = this.m_dtPathAlarm;
        }

        private void JTBitmSetPlatformPathSegmentAlarm_Load(object sender, EventArgs e)
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
        }
    }
}

