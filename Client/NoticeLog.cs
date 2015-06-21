namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class NoticeLog : LogForm
    {

        public NoticeLog()
        {
            this.InitializeComponent();
            this.Text = Variable.sNoticeLogText;
        }

        public override void addLogMsg(DataTable dtLogResult)
        {
            if ((dtLogResult != null) && (dtLogResult.Rows.Count != 0))
            {
                try
                {
                    DataView view = null;
                    dtLogResult.Columns.Add(new DataColumn("ColLog"));
                    view = new DataView(dtLogResult) {
                        RowFilter = base.m_dvLogData.RowFilter
                    };
                    int firstDisplayedScrollingRowIndex = base.dgvLogData.FirstDisplayedScrollingRowIndex;
                    int count = view.Count;
                    if (base.m_dvLogData.RowFilter.Length > 0)
                    {
                        int length = dtLogResult.Select(base.m_dvLogData.RowFilter).Length;
                    }
                    if (base.m_dvLogData.Sort.Length == 0)
                    {
                        base.m_dtLogData = dtLogResult.Clone();
                        base.m_dvLogData = new DataView(base.m_dtLogData, "", "RECETIME DESC,AddMsgType desc", DataViewRowState.CurrentRows);
                        base.dgvLogData.DataSource = base.m_dvLogData;
                    }
                    foreach (DataRow row in dtLogResult.Select(base.m_dvLogData.RowFilter))
                    {
                        if (row["MsgType"].ToString().Equals("4355", StringComparison.OrdinalIgnoreCase))
                        {
                            row["CarNum"] = "监管平台转发";
                        }
                        if (row["addMsgType"].ToString().Equals("-999"))
                        {
                            row["Describe"] = "车辆下线";
                        }
                        if (row["addMsgType"].ToString().Equals("-888"))
                        {
                            row["Describe"] = "车辆上线";
                        }
                        base.m_dtLogData.Select("CarId='" + row["CarId"].ToString() + "'");
                        int num2 = base.dgvLogData.SelectedRows.Count;
                        base.m_dtLogData.ImportRow(row);
                        if (num2 == 0)
                        {
                            base.dgvLogData.ClearSelection();
                        }
                    }
                    if (firstDisplayedScrollingRowIndex >= 0)
                    {
                        base.dgvLogData.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                    }
                    base.dgvLogData.Refresh();
                    view.Dispose();
                    view = null;
                    if (this._popWinType == 0)
                    {
                        MainForm.NoticeFormShow(base.dgvLogData.Rows.Count, dtLogResult.Rows.Count);
                    }
                    else
                    {
                        MainForm.NoticeFormShow(base.dgvLogData.Rows.Count, dtLogResult.Rows.Count, true);
                    }
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("掉线通知添加操作", exception.Message);
                    }
                }
                finally
                {
                    if (dtLogResult != null)
                    {
                        dtLogResult = null;
                    }
                }
            }
        }

        private void dgvLogData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((base.dgvLogData.CurrentRow != null) && (e.RowIndex >= 0))
            {
                this.setDataGridViewRowDefaultStyle(base.dgvLogData.CurrentRow);
            }
        }

        protected override void dgvLogData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && ((base.m_dvLogData.Count != 0) && (base.dgvLogData.SelectedRows.Count > 0)))
            {
                this.execShowDetail(base.dgvLogData.SelectedRows[0]);
                if (base.dgvLogData.SelectedRows.Count > 0)
                {
                    this.setDataGridViewRowDefaultStyle(base.dgvLogData.SelectedRows[0]);
                }
            }
        }

        private void dgvLogData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.setDataGridViewRowNewStyle(base.dgvLogData.Rows[e.RowIndex]);
            }
        }

        private void dgvLogData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.setDataGridViewRowNewStyle(base.dgvLogData.Rows[e.RowIndex]);
            }
        }

 public void execMoveSelected(int iCnt)
        {
            if (base.m_dvLogData.Count > 1)
            {
                if (base.dgvLogData.SelectedRows.Count <= 0)
                {
                    if (iCnt > 0)
                    {
                        base.dgvLogData.CurrentCell = base.dgvLogData.Rows[0].Cells["ReceTime"];
                    }
                    else
                    {
                        base.dgvLogData.CurrentCell = base.dgvLogData.Rows[base.dgvLogData.Rows.Count - 1].Cells["ReceTime"];
                    }
                }
                else
                {
                    int index = base.dgvLogData.CurrentRow.Index;
                    if ((index + iCnt) < 0)
                    {
                        if (MessageBox.Show("日志已达到首位，是否从末尾继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        {
                            return;
                        }
                        base.dgvLogData.CurrentCell = base.dgvLogData.Rows[base.dgvLogData.Rows.Count - 1].Cells["ReceTime"];
                    }
                    else if ((index + iCnt) > (base.m_dvLogData.Count - 1))
                    {
                        if (MessageBox.Show("日志已达到末尾，是否从首位继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        {
                            return;
                        }
                        base.dgvLogData.CurrentCell = base.dgvLogData.Rows[0].Cells["ReceTime"];
                    }
                    else
                    {
                        base.dgvLogData.CurrentCell = base.dgvLogData.Rows[index + iCnt].Cells["ReceTime"];
                    }
                }
                this.setDataGridViewRowDefaultStyle(base.dgvLogData.Rows[base.dgvLogData.CurrentRow.Index]);
                this.myNoticeDetailLog.setShowInfo(base.dgvLogData.Rows[base.dgvLogData.CurrentRow.Index]);
            }
        }

        private void execShowDetail(DataGridViewRow drShow)
        {
            if (base.m_dvLogData.Count != 0)
            {
                try
                {
                    string str = drShow.Cells["CarId"].Value.ToString();
                    NoticeDetailLog.myNoticeLog = this;
                    if (this.PopWinType == 1)
                    {
                        this.myNoticeDetailLog = new NoticeDetailLog("上下线通知");
                    }
                    else
                    {
                        this.myNoticeDetailLog = new NoticeDetailLog();
                    }
                    this.myNoticeDetailLog.setShowInfo(drShow);
                    this.myNoticeDetailLog.ShowDialog();
                    if (this.myNoticeDetailLog.bSendSuccess)
                    {
                        foreach (DataRow row in base.m_dtLogData.Select("CarId='" + str + "'"))
                        {
                            base.m_dtLogData.Rows.Remove(row);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public void initDataGrid()
        {
            base.dgvLogData.Columns["ReceTime"].Visible = true;
            base.dgvLogData.Columns["carNum"].Visible = true;
            base.dgvLogData.Columns["describe"].Visible = true;
            base.dgvLogData.Columns["CarName"].Visible = false;
            base.dgvLogData.Columns["CameraId"].Visible = false;
            base.dgvLogData.Columns["orderid"].Visible = false;
            base.dgvLogData.Columns["OrderType"].Visible = false;
            base.dgvLogData.Columns["OrderName"].Visible = false;
            base.dgvLogData.Columns["msgtype"].Visible = false;
            base.dgvLogData.Columns["OrderResult"].Visible = false;
            base.dgvLogData.Columns["commFlag"].Visible = false;
            base.dgvLogData.Columns["showImage"].Visible = false;
            base.dgvLogData.Columns["GpsTime"].Visible = false;
            base.dgvLogData.Columns["carnum"].HeaderText = "来源";
            base.dgvLogData.ClearSelection();
            base.dgvLogData.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dgvLogData_CellMouseClick);
            base.dgvLogData.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvLogData_RowsAdded);
            base.dgvLogData.CellValueChanged += new DataGridViewCellEventHandler(this.dgvLogData_CellValueChanged);
        }

 private void setDataGridViewRowDefaultStyle(DataGridViewRow dgvRow)
        {
            if (dgvRow != null)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                Font font = new Font("宋体", 9f);
                style.Font = font;
                dgvRow.DefaultCellStyle = style;
            }
        }

        private void setDataGridViewRowNewStyle(DataGridViewRow dgvRow)
        {
            if (dgvRow != null)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                Font font = new Font("宋体", 9f, FontStyle.Bold);
                style.Font = font;
                dgvRow.DefaultCellStyle = style;
            }
        }

        protected override void tbShowDetail_Click(object sender, EventArgs e)
        {
            if ((base.m_dvLogData.Count != 0) && (base.dgvLogData.SelectedRows.Count > 0))
            {
                this.execShowDetail(base.dgvLogData.SelectedRows[0]);
            }
        }

        public int PopWinType
        {
            get
            {
                return this._popWinType;
            }
            set
            {
                this._popWinType = value;
            }
        }
    }
}

