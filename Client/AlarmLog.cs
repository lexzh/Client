namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Web.UI.WebControls;

    public partial class AlarmLog : LogForm
    {

        public AlarmLog()
        {
            this.InitializeComponent();
        }

        public override void addLogMsg(DataTable dtLogResult)
        {
            if ((dtLogResult == null) || (dtLogResult.Rows.Count == 0))
            {
                base.txtNewLogCnt2.Text = "0";
            }
            else
            {
                try
                {
                    DataRow row;
                    dtLogResult.Columns.Add(new DataColumn("ColLog"));
                    DataView view = new DataView(dtLogResult, "", "ReceTime Desc", DataViewRowState.CurrentRows) {
                        RowFilter = base.m_dvLogData.RowFilter
                    };
                    int firstDisplayedScrollingRowIndex = base.dgvLogData.FirstDisplayedScrollingRowIndex;
                    int count = view.Count;
                    if (string.IsNullOrEmpty(base.txtNewLogCnt.Text))
                    {
                        base.txtNewLogCnt.Text = count.ToString();
                        base.txtNewLogCnt2.Text = dtLogResult.Rows.Count.ToString();
                    }
                    else
                    {
                        try
                        {
                            int num3 = int.Parse(base.txtNewLogCnt.Text);
                            base.txtNewLogCnt.Text = (num3 + count).ToString();
                            base.txtNewLogCnt2.Text = dtLogResult.Rows.Count.ToString();
                        }
                        catch
                        {
                        }
                    }
                    if (base.m_dvLogData.Sort.Length == 0)
                    {
                        base.m_dtLogData = dtLogResult.Clone();
                        base.m_dvLogData = new DataView(base.m_dtLogData, "", "ReceTime DESC", DataViewRowState.CurrentRows);
                        base.dgvLogData.DataSource = base.m_dvLogData;
                    }
                    int iRowCnt = base.dgvLogData.Rows.Count + count;
                    int num5 = base.m_dvLogData.Count;
                    int num6 = 0;
                    if (count >= base.iMaxLogCnt)
                    {
                        base.m_dtLogData.Rows.Clear();
                        num6 = count - base.iMaxLogCnt;
                    }
                    else if (iRowCnt > base.iMaxLogCnt)
                    {
                        for (int i = 1; i <= (iRowCnt - base.iMaxLogCnt); i++)
                        {
                            base.m_dvLogData.Delete((int) (num5 - i));
                        }
                    }
                    base.m_dvLogData.Sort = "";
                    int num8 = 0;
                    while (num6 < count)
                    {
                        row = view[num6].Row;
                        num8 = base.dgvLogData.SelectedRows.Count;
                        base.m_dtLogData.ImportRow(row);
                        row = null;
                        num6++;
                    }
                    base.SetCurrentRow(base.dgvLogData, iRowCnt, base.iMaxLogCnt, count);
                    num8 = base.dgvLogData.SelectedRows.Count;
                    row = null;
                    base.m_dvLogData.Sort = "ReceTime DESC";
                    if (num8 == 0)
                    {
                        base.dgvLogData.ClearSelection();
                    }
                    if (firstDisplayedScrollingRowIndex >= 0)
                    {
                        base.dgvLogData.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                    }
                    base.dgvLogData.Refresh();
                    view.Dispose();
                    view = null;
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("报警日志添加操作", exception.Message);
                    }
                }
            }
        }

        private void AlarmLog_Load(object sender, EventArgs e)
        {
            base.dgvLogData.ClearSelection();
        }


    }
}