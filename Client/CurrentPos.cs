namespace Client
{
    using PublicClass;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CurrentPos : LogForm
    {
        private static DataTable m_dtShowLog = new DataTable();

        public CurrentPos()
        {
            this.InitializeComponent();
        }

        public void addData(int iAddCnt, int iScrollingRowIndex, DataView dv)
        {
            try
            {
                int iRowCnt = base.dgvLogData.Rows.Count + iAddCnt;
                int count = base.m_dvLogData.Count;
                int num3 = 0;
                if (iAddCnt >= base.iMaxLogCnt)
                {
                    base.m_dtLogData.Rows.Clear();
                    num3 = iAddCnt - base.iMaxLogCnt;
                }
                else if (iRowCnt > base.iMaxLogCnt)
                {
                    for (int i = 1; i <= (iRowCnt - base.iMaxLogCnt); i++)
                    {
                        base.m_dvLogData.Delete((int) (count - i));
                    }
                }
                base.m_dvLogData.Sort = "";
                DataRow row = null;
                int num5 = 0;
                while (num3 < iAddCnt)
                {
                    row = dv[num3].Row;
                    num5 = base.dgvLogData.SelectedRows.Count;
                    base.m_dtLogData.ImportRow(row);
                    num3++;
                }
                base.SetCurrentRow(base.dgvLogData, iRowCnt, base.iMaxLogCnt, iAddCnt);
                num5 = base.dgvLogData.SelectedRows.Count;
                row = null;
                base.m_dvLogData.Sort = "ReceTime DESC";
                if (num5 == 0)
                {
                    base.dgvLogData.ClearSelection();
                }
                if (iScrollingRowIndex >= 0)
                {
                    base.dgvLogData.FirstDisplayedScrollingRowIndex = iScrollingRowIndex;
                }
                base.dgvLogData.Refresh();
                dv.Dispose();
                dv = null;
            }
            catch
            {
            }
        }

        public override void addLogMsg(DataTable dtLogResult)
        {
            if ((dtLogResult == null) || (dtLogResult.Rows.Count == 0))
            {
                base.txtNewLogCnt2.Text = "0";
            }
            else
            {
                DataView dv = null;
                try
                {
                    dtLogResult.Columns.Add(new DataColumn("ColLog"));
                    dv = new DataView(dtLogResult) {
                        RowFilter = base.m_dvLogData.RowFilter
                    };
                    int firstDisplayedScrollingRowIndex = base.dgvLogData.FirstDisplayedScrollingRowIndex;
                    int count = dv.Count;
                    if (base.m_dvLogData.Sort.Length == 0)
                    {
                        base.m_dtLogData = dtLogResult.Clone();
                        if (Variable.sShowTogether.Equals("0"))
                        {
                            base.m_dvLogData = new DataView(base.m_dtLogData, "", "ReceTime DESC", DataViewRowState.CurrentRows);
                        }
                        else
                        {
                            dtLogResult.PrimaryKey = new DataColumn[] { dtLogResult.Columns["CarId"] };
                            base.m_dtLogData = dtLogResult.Clone();
                            base.m_dvLogData = new DataView(base.m_dtLogData, "", "CarNum", DataViewRowState.CurrentRows);
                        }
                        base.dgvLogData.DataSource = base.m_dvLogData;
                    }
                    if (Variable.sShowTogether.Equals("0"))
                    {
                        this.addData(count, firstDisplayedScrollingRowIndex, dv);
                    }
                    else
                    {
                        foreach (DataRow row in dtLogResult.Rows)
                        {
                            string key = row["CarId"].ToString();
                            if (base.m_dtLogData.Rows.Contains(key))
                            {
                                this.updateData(row);
                            }
                            else
                            {
                                base.m_dtLogData.Rows.Add(row.ItemArray);
                            }
                        }
                        base.m_dvLogData = new DataView(base.m_dtLogData, "", "CarNum", DataViewRowState.CurrentRows);
                    }
                    dv.Dispose();
                    dv = null;
                }
                catch (Exception exception)
                {
                    if (Variable.bLogin)
                    {
                        Record.execFileRecord("最新位置日志添加操作", exception.Message);
                    }
                }
            }
        }

        private void CurrentPos_Load(object sender, EventArgs e)
        {
            base.dgvLogData.ClearSelection();
        }

        protected override void dgvLogData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Variable.sShowTogether.Equals("0"))
            {
                base.dgvLogData_CellMouseDoubleClick(sender, e);
            }
            else if (e.RowIndex >= 0)
            {
                try
                {
                    string sCarId = base.dgvLogData.CurrentRow.Cells["CarId"].Value.ToString();
                    this.showRecord(sCarId);
                }
                catch
                {
                }
            }
        }

 public void showNodeRecord(string sCarId)
        {
            try
            {
                if (!string.IsNullOrEmpty(sCarId))
                {
                    foreach (DataGridViewRow row in (IEnumerable) base.dgvLogData.Rows)
                    {
                        if (row.Cells["CarId"].Value.ToString().Equals(sCarId))
                        {
                            row.Selected = true;
                            base.dgvLogData.FirstDisplayedScrollingRowIndex = row.Index;
                            return;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void showRecord(string sCarId)
        {
            try
            {
                TreeNode[] nodeArray = MainForm.myCarList.tvList.Nodes.Find(sCarId, true);
                if ((nodeArray != null) && (nodeArray.Length > 0))
                {
                    MainForm.myCarList.tvList.setSelectNode(nodeArray[0]);
                    MainForm.myMap.setTrackingCar(sCarId);
                }
            }
            catch
            {
            }
        }

        public void updateData(DataRow dr)
        {
            string key = dr["CarId"].ToString();
            try
            {
                base.m_dtLogData.Rows.Find(key).ItemArray = dr.ItemArray;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("日志更新操作", exception.Message);
            }
        }
    }
}

