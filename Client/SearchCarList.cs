namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;
    using WinFormsUI.Docking;

    public partial class SearchCarList : ToolWindow
    {

        public SearchCarList()
        {
            this.InitializeComponent();
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
                {
                    string str = this.dgvSearchCarList.Rows[e.RowIndex].Cells["CarTipText"].Value.ToString();
                    e.ToolTipText = str;
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("拉框查车显示提示内容", exception.Message);
            }
        }

        private void dgvSearchCarList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                try
                {
                    string str = this.dgvSearchCarList.Rows[e.RowIndex].Cells["CarId"].Value.ToString();
                    if (!"0".Equals(str))
                    {
                        MainForm.myMap.setTrackingCar(str);
                    }
                }
                catch
                {
                }
            }
        }

 public void execRefRegion(string sPoints)
        {
            this.initSearchCarList();
            this.myCompleteGetRefRegion = new CompleteGetRefRegion(this.MCompleteGetRefRegion);
            this.myCompleteGetRefRegionDataTable = new CompleteGetRefRegionDataTable(this.MCompleteGetRefRegion);
            this.myMsgBox = new DelegateMsgBox(this.MsgBox);
            try
            {
                this.thread = new Thread(new ParameterizedThreadStart(this.ThreadGetRefRegion));
                this.thread.Start(sPoints);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("获取拉框查车结果", exception.Message);
            }
        }

        public void execShowCarResult(DataTable dt)
        {
            this.myMsgBox = new DelegateMsgBox(this.MsgBox);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                this.iCarCnt = dt.Rows.Count;
                base.Invoke(this.myMsgBox, new object[] { this.iCarCnt });
                base.Invoke(this.myCompleteGetRefRegionDataTable, new object[] { dt });
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    base.Invoke(this.myCompleteGetRefRegion, new object[] { dt.Rows[i] });
                }
            }
            else if (this.iCarCnt == 0)
            {
                base.Invoke(this.myMsgBox, new object[] { 0 });
            }
        }

 public void initSearchCarList()
        {
            this.iCarCnt = 0;
            this.tvSearchCarListNodesClear();
            this.myMsgBox = new DelegateMsgBox(this.MsgBox);
            this.myCompleteGetRefRegionDataTable = new CompleteGetRefRegionDataTable(this.MCompleteGetRefRegion);
            this.myCompleteGetRefRegion = new CompleteGetRefRegion(this.MCompleteGetRefRegion);
            if (MainForm.mySearchCarList.DockState == DockState.DockRightAutoHide)
            {
                MainForm.mySearchCarList.DockState = DockState.DockRight;
                MainForm.mySearchCarList.Show(base.DockPanel);
            }
            if (this.dtSearchCar == null)
            {
                this.dtSearchCar = new DataTable();
                this.dtSearchCar.Columns.Add("CarNum", typeof(string));
                this.dtSearchCar.Columns.Add("CarTipText", typeof(string));
                this.dtSearchCar.Columns.Add("CarId", typeof(string));
                this.dtSearchCar.Columns.Add("SimNum");
                this.dtSearchCar.Columns.Add("Longitude");
                this.dtSearchCar.Columns.Add("Latitude");
                this.dtSearchCar.Columns.Add("Speed");
                this.dtSearchCar.Columns.Add("GpsTime");
            }
            this.dtSearchCar.Rows.Clear();
            this.dgvSearchCarList.DataSource = this.dtSearchCar;
            this.dgvSearchCarList.Columns[0].Visible = false;
            this.dgvSearchCarList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvSearchCarList.Columns[2].Visible = false;
            this.dgvSearchCarList.Columns[3].Visible = false;
        }

        private void MCompleteGetRefRegion(DataRow dr)
        {
            this.RegionShowCar(dr);
        }

        private void MCompleteGetRefRegion(DataTable dt)
        {
            try
            {
                this.dgvSearchCarList.Columns[0].Visible = true;
                this.dtSearchCar.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string str = row["CarNum"].ToString().Trim();
                    string str2 = row["SimNum"].ToString();
                    string str3 = row["StatuName"].ToString();
                    string str4 = row["AreaName"].ToString();
                    string str5 = row["CarID"].ToString();
                    string str6 = row["speed"].ToString();
                    string str7 = "车牌:" + str + "\r\n车号:" + str5 + "\r\n电话:" + str2 + "\r\n状态:" + str3 + "\r\n属于:" + str4 + "\r\n速度:" + str6 + "km/h\r\n时间:" + row["GpsTime"].ToString() + "\r\n";
                    this.dtSearchCar.Rows.Add(new object[] { row["CarNum"], str7, str5, str2, row["Longitude"], row["Latitude"], str6, row["GpsTime"] });
                }
                this.grbSearchCarList.Text = string.Format("查车结果({0})", dt.Rows.Count);
                this.dgvSearchCarList.Columns[2].Visible = false;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("拉框查车加裁查车表", exception.Message);
            }
        }

        private void MsgBox(int iCount)
        {
            string str = iCount.ToString();
            try
            {
                int iCarCnt = this.iCarCnt;
                this.grbSearchCarList.Text = string.Format("查车结果({0})", str);
                this.myMsgBox = null;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("拉框查车结果", exception.Message);
            }
        }

        private void RegionShowCar(DataRow dr)
        {
            try
            {
                MainForm.myMap.execShowCar(dr);
            }
            catch
            {
            }
        }

        private void SearchCarList_DockStateChanged(object sender, EventArgs e)
        {
            if ((base.ParentForm != null) && (base.ParentForm.Name == "MainForm"))
            {
                ((MainForm) base.ParentForm).setMenuViewChecked();
            }
        }

        private void ThreadGetRefRegion(object sPoints)
        {
            DataTable dt = RemotingClient.Car_GetRefRegion(sPoints.ToString());
            this.execShowCarResult(dt);
        }

        public void tvSearchCarListNodesClear()
        {
            if (this.dgvSearchCarList.DataSource != null)
            {
                DataTable dataSource = this.dgvSearchCarList.DataSource as DataTable;
                dataSource.Rows.Clear();
                this.dgvSearchCarList.DataSource = dataSource;
            }
            this.grbSearchCarList.Text = string.Format("查车结果({0})", 0);
        }

        private delegate void CompleteGetRefRegion(DataRow dr);

        private delegate void CompleteGetRefRegionDataTable(DataTable dt);

        private delegate void DelegateMsgBox(int count);
    }
}

