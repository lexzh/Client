using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PublicClass;
using Client.Properties;
using Remoting;
using WinFormsUI.Controls;

namespace Client
{
    public partial class LogForm : UserControl
    {
        protected DataTable m_dtLogData = new DataTable();
        protected DataView m_dvLogData;
        public dAddLog myAddLog;
        protected int iMaxLogCnt = 500;
        private System.Drawing.Image img;
        private int iScroll;
        public static DetailLog myDetailLog = new DetailLog();

        public LogForm()
        {
            InitializeComponent();
            this.m_dvLogData = new DataView(this.m_dtLogData);
            this.cmbOrderType.Items.Clear();
            this.cmbOrderType.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
            this.cmbOrderType.Items.Add(LogType.报告);
            this.cmbOrderType.Items.Add(LogType.报警);
            this.cmbOrderType.Items.Add(LogType.警告);
            this.cmbOrderType.Items.Add(LogType.信息);
            this.cmbOrderType.Items.Add(LogType.接收);
            this.cmbOrderType.Items.Add(LogType.发送);
            this.cmbOrderResult.Items.Clear();
            this.cmbOrderResult.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
            this.cmbOrderResult.Items.Add(SendResult.成功);
            this.cmbOrderResult.Items.Add(SendResult.不成功);
            this.dgvLogData.AutoGenerateColumns = false;
            this.dgvLogData.ClearSelection();
        }

        private void addAreaNameColumn()
        {
            DataGridViewCellFormattingEventHandler handler = null;
            if (Variable.sLogListAreaVisible.Equals("1", StringComparison.OrdinalIgnoreCase))
            {
                this.dgvLogData.Columns["区域"].Visible = true;
                if (handler == null)
                {
                    handler = delegate(object sender1, DataGridViewCellFormattingEventArgs e1)
                    {
                        try
                        {
                            if ((((e1.RowIndex >= 0) && (e1.ColumnIndex >= 0)) && ((e1.Value != null) && this.dgvLogData.Rows[e1.RowIndex].Cells["区域"].ColumnIndex.Equals(e1.ColumnIndex))) && MainForm.myCarList.tvList.hasCarPath.ContainsKey(e1.Value))
                            {
                                e1.Value = (MainForm.myCarList.tvList.hasCarPath[e1.Value] as ThreeStateTreeNode).CarAreaName;
                            }
                        }
                        catch
                        {
                        }
                    };
                }
                this.dgvLogData.CellFormatting += handler;
            }
        }

        private void addLogFilterAlarmType()
        {
            if ((Variable.sLogFilterAlarmType.Trim().Length > 0) && (Variable.sLogFilterAlarmType.Split(new char[] { ',' }).Length == 2))
            {
                long result = 0L;
                long num2 = 0L;
                long.TryParse(Variable.sLogFilterAlarmType.Split(new char[] { ',' })[0], out result);
                long.TryParse(Variable.sLogFilterAlarmType.Split(new char[] { ',' })[1], out num2);
                string sql = "select CarStatu,CarStatuName from CarStatuTable Where Type=1";
                if (result > 0L)
                {
                    DataTable table = RemotingClient.ExecSql(sql);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if ((Convert.ToInt64(row["CarStatu"]) & result) != 0L)
                            {
                                this.cmbOrderType.Items.Add(row["CarStatuName"]);
                            }
                        }
                    }
                }
                sql = "select CarStatuEx as CarStatu,CarStatuExName as CarStatuName,2 Type from CarStatuExTable";
                if (num2 > 0L)
                {
                    DataTable table2 = RemotingClient.ExecSql(sql);
                    if ((table2 != null) && (table2.Rows.Count > 0))
                    {
                        DataColumn column = new DataColumn("isCheck")
                        {
                            DefaultValue = false
                        };
                        table2.Columns.Add(column);
                        long num4 = 0L;
                        if (Variable.sLogFilterAlarmType.Trim().Length > 0)
                        {
                            long.TryParse(Variable.sLogFilterAlarmType.Split(new char[] { ',' })[1], out num4);
                            foreach (DataRow row2 in table2.Rows)
                            {
                                if ((Convert.ToInt64(row2["CarStatu"]) & num2) != 0L)
                                {
                                    this.cmbOrderType.Items.Add(row2["CarStatuName"]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public virtual void addLogMsg(DataTable dtLogResult)
        {
        }

        private void dgvLogData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && myDetailLog.IsHandleCreated)
            {
                this.execShowDetail(this.dgvLogData.Rows[e.RowIndex]);
            }
        }

        protected virtual void dgvLogData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.execShowDetail(this.dgvLogData.Rows[e.RowIndex]);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("双击日志数据", exception.Message);
            }
        }

        private void dgvLogData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Record.execFileRecord(e.Exception.Message);
            e.Cancel = true;
        }

        private void dgvLogData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    string str = "";
                    if (this.dgvLogData.Rows[e.RowIndex].Cells["OrderType"].Value != DBNull.Value)
                    {
                        str = this.dgvLogData.Rows[e.RowIndex].Cells["OrderType"].Value.ToString();
                    }
                    if ((str == "报警") || (str == "信息"))
                    {
                        this.img = Resources.mAlarm;
                    }
                    else if (str == "警告")
                    {
                        this.img = Resources.mNormal;
                    }
                    else
                    {
                        this.img = Resources.mInfo;
                    }
                    Rectangle rect = new Rectangle((e.RowBounds.X + 3) - this.iScroll, e.RowBounds.Y + 1, 16, 16);
                    e.Graphics.DrawImage(this.img, rect);
                }
                catch
                {
                }
            }
        }

        private void dgvLogData_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.iScroll = e.NewValue;
            }
        }


        public void execMoveSelected(int iCnt)
        {
            if (this.m_dvLogData.Count > 1)
            {
                if (this.dgvLogData.SelectedRows.Count <= 0)
                {
                    if (iCnt > 0)
                    {
                        this.dgvLogData.CurrentCell = this.dgvLogData.Rows[0].Cells["ReceTime"];
                    }
                    else
                    {
                        this.dgvLogData.CurrentCell = this.dgvLogData.Rows[this.dgvLogData.Rows.Count - 1].Cells["ReceTime"];
                    }
                }
                else
                {
                    int index = this.dgvLogData.CurrentRow.Index;
                    if ((index + iCnt) < 0)
                    {
                        if (MessageBox.Show("日志已达到首位，是否从末尾继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        {
                            return;
                        }
                        this.dgvLogData.CurrentCell = this.dgvLogData.Rows[this.dgvLogData.Rows.Count - 1].Cells["ReceTime"];
                    }
                    else if ((index + iCnt) > (this.m_dvLogData.Count - 1))
                    {
                        if (MessageBox.Show("日志已达到末尾，是否从首位继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        {
                            return;
                        }
                        this.dgvLogData.CurrentCell = this.dgvLogData.Rows[0].Cells["ReceTime"];
                    }
                    else
                    {
                        this.dgvLogData.CurrentCell = this.dgvLogData.Rows[index + iCnt].Cells["ReceTime"];
                    }
                }
                myDetailLog.setShowDetail(this.dgvLogData.Rows[this.dgvLogData.CurrentRow.Index]);
            }
        }

        private void execShowDetail(DataGridViewRow drShow)
        {
            if (this.m_dvLogData.Count != 0)
            {
                DetailLog.myLogForm = this;
                myDetailLog = new DetailLog();
                myDetailLog.setShowDetail(drShow);
                myDetailLog.ShowDialog();
            }
        }

        public void Init()
        {
            ThreadPool.QueueUserWorkItem(ooo => base.Invoke(new MethodInvoker(() => this.addLogFilterAlarmType())));
            ///old //ThreadPool.QueueUserWorkItem(ooo => base.Invoke(() => this.addLogFilterAlarmType()));
            if (Variable.sLogListAreaVisible.Equals("1", StringComparison.OrdinalIgnoreCase))
            {
                this.addAreaNameColumn();
            }
        }


        public void SetCurrentRow(DataGridView _dgvLogData, int iRowCnt, int iMaxLogCnt, int iAddCnt)
        {
            try
            {
                if (iAddCnt >= iMaxLogCnt)
                {
                    _dgvLogData.ClearSelection();
                    _dgvLogData.CurrentCell = null;
                }
                else if (_dgvLogData.CurrentCell.RowIndex >= ((iMaxLogCnt - iAddCnt) - 1))
                {
                    _dgvLogData.ClearSelection();
                    _dgvLogData.CurrentCell = null;
                }
                else if (_dgvLogData.SelectedRows.Count > 0)
                {
                    int rowIndex = _dgvLogData.CurrentCell.RowIndex;
                    if (rowIndex >= _dgvLogData.Rows.Count)
                    {
                        _dgvLogData.ClearSelection();
                    }
                    else
                    {
                        rowIndex += iAddCnt;
                        _dgvLogData.CurrentCell = _dgvLogData.Rows[rowIndex].Cells[_dgvLogData.FirstDisplayedCell.ColumnIndex];
                    }
                }
            }
            catch
            {
            }
        }

        protected virtual void tbRemove_Click(object sender, EventArgs e)
        {
            this.m_dtLogData.Rows.Clear();
            this.txtNewLogCnt.Text = "";
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            string str = "";
            if (this.m_dtLogData.Rows.Count != 0)
            {
                if (this.txtCarNo.Text.Trim().Length > 0)
                {
                    str = str + "CarNum like '%" + this.txtCarNo.Text.Trim() + "%' AND ";
                }
                if (this.cmbOrderType.Text.Trim().Length > 0)
                {
                    if (this.cmbOrderType.SelectedItem is LogType)
                    {
                        str = str + "OrderType='" + this.cmbOrderType.Text.Trim() + "' AND ";
                    }
                    else
                    {
                        str = str + "StatuName like '%" + this.cmbOrderType.Text.Trim() + "%' AND ";
                    }
                }
                if (this.cmbOrderResult.Text.Trim().Length > 0)
                {
                    if (this.cmbOrderResult.Text.Trim() == "成功")
                    {
                        str = str + "OrderResult='成功' AND ";
                    }
                    else
                    {
                        str = str + "OrderResult<>'成功' AND ";
                    }
                }
                if (this.txtMsgType.Text.Trim().Length > 0)
                {
                    str = str + "OrderName like '%" + this.txtMsgType.Text.Trim() + "%' AND ";
                }
                if (str.Length > 4)
                {
                    this.m_dvLogData.RowFilter = str.Remove(str.Length - 4);
                }
                else
                {
                    this.m_dvLogData.RowFilter = str;
                }
            }
        }

        private void tbShowAll_Click(object sender, EventArgs e)
        {
            this.m_dvLogData.RowFilter = "";
        }

        protected virtual void tbShowDetail_Click(object sender, EventArgs e)
        {
            if ((this.m_dvLogData.Count != 0) && (this.dgvLogData.SelectedRows.Count > 0))
            {
                this.execShowDetail(this.dgvLogData.SelectedRows[0]);
            }
        }

        private void txtCarNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.tbSearch.PerformClick();
            }
        }

        public delegate void dAddLog(DataRow drData);

        public enum LogFormType
        {
            最新日志,
            最新位置,
            报警日志,
            图像列表
        }

        public enum LogType
        {
            报告,
            报警,
            警告,
            信息,
            接收,
            发送
        }

        public enum SendResult
        {
            成功,
            不成功
        }
    }
}
