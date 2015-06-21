namespace Client
{
    using PublicClass;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class CarTextList : SizableForm
    {
        private DataTable dtText = new DataTable();
        private static BackgroundWorker excelWorker;
        private int iNodeCnt = 1;
        private BindingSource source = new BindingSource();
        private string sQueryTypeValue = "cartextlist";
        private string[] sSplit = new string[] { "::" };
        private static BackgroundWorker worker;

        public CarTextList()
        {
            this.InitializeComponent();
        }

        public void BindCarTextList()
        {
            try
            {
                this.dtText.Rows.Clear();
                foreach (ThreeStateTreeNode node in MainForm.myCarList.tvList.Nodes)
                {
                    if (node != null)
                    {
                        if ((node.Tag != null) && node.Tag.Equals("CAR"))
                        {
                            if (node.Checked)
                            {
                                string str = (node.AccOn == "0") ? "关" : "开";
                                object[] values = new object[14];
                                values[0] = node.CarNum;
                                values[1] = node.SimNum;
                                values[2] = (node.CarAreaName == node.WordCompany) ? node.CarAreaName : (node.WordCompany + "-" + node.CarAreaName);
                                values[3] = node.Longitude;
                                values[4] = node.Latitude;
                                values[5] = node.ALLDiff;
                                values[6] = node.ReceTime;
                                values[7] = node.GpsTime;
                                values[9] = node.Speed;
                                values[10] = str;
                                values[11] = node.DriverName;
                                values[12] = node.CarId;
                                values[13] = node.AreaType;
                                this.dtText.Rows.Add(values);
                                if (!string.IsNullOrEmpty(node.Longitude))
                                {
                                    if (!this.bRefresh)
                                    {
                                        this.iCurrentCnt++;
                                        worker.ReportProgress(this.iCurrentCnt / this.iNodeCnt, node.SimNum + "|" + node.Longitude + "," + node.Latitude);
                                    }
                                    else
                                    {
                                        MainForm.myMap.execExcuteTrackPointQuerty(this.sQueryTypeValue, node.SimNum, node.Longitude, node.Latitude);
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.getTreeNodeIsChecked(node, ref this.dtText);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("文本界面->加载数据", exception.Message);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExportExcel();
            }
            catch (Exception exception)
            {
                WaitForm.Hide();
                MessageBox.Show(exception.Message + "\r\n原因：文件可能已打开！");
                Record.execFileRecord("文本界面->导出到Excel", exception.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnRefresh.Enabled = false;
                MainForm.myMap.execStopPlayTrackLine(this.sQueryTypeValue);
                this.iCurrentCnt = 0;
                this.bRefresh = true;
                this.cboxSelectedAll.Checked = false;
                WaitForm.Show("正在刷新文本信息...", this);
                this.BindCarTextList();
                this.refleshData();
                this.lblDGVRowCount.Text = string.Format("总共 {0} 条记录", this.source.List.Count.ToString());
            }
            catch
            {
            }
            finally
            {
                this.btnRefresh.Enabled = true;
                WaitForm.Hide();
            }
        }

        private void CarTextList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((excelWorker != null) && excelWorker.IsBusy)
                {
                    MessageBox.Show("正在导出数据！");
                    e.Cancel = true;
                }
                int num = 0;
                if (this.cboxLongitude.Checked)
                {
                    num++;
                }
                if (this.cboxLatitude.Checked)
                {
                    num += 2;
                }
                if (this.cboxAllDiff.Checked)
                {
                    num += 4;
                }
                if (this.cboxReceTime.Checked)
                {
                    num += 8;
                }
                if (this.cboxGpsTime.Checked)
                {
                    num += 16;
                }
                if (this.cboxAddress.Checked)
                {
                    num += 32;
                }
                if (this.cboxSpeed.Checked)
                {
                    num += 64;
                }
                if (this.cboxAccOn.Checked)
                {
                    num += 128;
                }
                if (this.cboxDriver.Checked)
                {
                    num += 256;
                }
                Variable.sCarListTextColunmsVisibleType = num.ToString();
                this.dgvCarTextList.DataSource = null;
                this.dgvCarTextList.Rows.Clear();
                if (worker != null)
                {
                    worker.Dispose();
                    worker = null;
                }
                if (excelWorker != null)
                {
                    excelWorker.Dispose();
                    excelWorker = null;
                }
                if (this.tGetQueryTrackInfo != null)
                {
                    this.tGetQueryTrackInfo.Enabled = false;
                    this.tGetQueryTrackInfo = null;
                }
                MainForm.myMap.execStopPlayTrackLine(this.sQueryTypeValue);
                base.Dispose();
            }
            catch
            {
            }
            finally
            {
                if (this.dtText != null)
                {
                    this.dtText.Clear();
                    this.dtText.Dispose();
                    this.dtText = null;
                }
                if (this.dtLoad != null)
                {
                    this.dtLoad.Clear();
                    this.dtLoad.Dispose();
                    this.dtLoad = null;
                }
            }
        }

        private void CarTextList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvCarTextList.AutoGenerateColumns = false;
                this.initClomun();
                this.initDataTable();
                this.doWorker();
                MainForm.myMap.execStopPlayTrackLine(this.sQueryTypeValue);
                this.tGetQueryTrackInfo = new System.Timers.Timer(2000.0);
                this.tGetQueryTrackInfo.Elapsed += new ElapsedEventHandler(this.tGetQueryTrackInfo_Elapsed);
                this.tGetQueryTrackInfo.Enabled = true;
                this.myGetTrackQueryInfo = new dGetTrackQueryInfo(this.getAddress);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("文本界面->初期化", exception.ToString());
            }
            finally
            {
                WaitForm.Hide();
            }
        }

        private void cbox_Click(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box != null)
            {
                switch (box.Name)
                {
                    case "cboxLongitude":
                        this.dgvCarTextList.Columns["CarLongitude"].Visible = box.Checked;
                        return;

                    case "cboxLatitude":
                        this.dgvCarTextList.Columns["CarLatitude"].Visible = box.Checked;
                        return;

                    case "cboxAllDiff":
                        this.dgvCarTextList.Columns["CarAllDiff"].Visible = box.Checked;
                        return;

                    case "cboxReceTime":
                        this.dgvCarTextList.Columns["CarReceTime"].Visible = box.Checked;
                        return;

                    case "cboxGpsTime":
                        this.dgvCarTextList.Columns["CarGpsTime"].Visible = box.Checked;
                        return;

                    case "cboxAddress":
                        this.dgvCarTextList.Columns["CarCurrentAddress"].Visible = box.Checked;
                        return;

                    case "cboxSpeed":
                        this.dgvCarTextList.Columns["CarSpeed"].Visible = box.Checked;
                        return;

                    case "cboxAccOn":
                        this.dgvCarTextList.Columns["CarAcc"].Visible = box.Checked;
                        return;

                    case "cboxDriver":
                        this.dgvCarTextList.Columns["DriverName"].Visible = box.Checked;
                        return;
                }
            }
        }

        private void cboxSelectedAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboxSelectedAll.Text.Equals("全选"))
            {
                this.cboxSelectedAll.Text = "全取消";
                this.cboxSelectedAll.Checked = true;
            }
            else
            {
                this.cboxSelectedAll.Text = "全选";
                this.cboxSelectedAll.Checked = false;
            }
            this.setDGVCheck();
        }

        private void dgvCarTextList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                string sCarId = this.dgvCarTextList.Rows[e.RowIndex].Cells["CarID"].Value.ToString();
                string s = this.dgvCarTextList.Rows[e.RowIndex].Cells["CarLongitude"].Value.ToString();
                string str3 = this.dgvCarTextList.Rows[e.RowIndex].Cells["CarLatitude"].Value.ToString();
                double result = 0.0;
                double num2 = 0.0;
                double.TryParse(s, out result);
                double.TryParse(str3, out num2);
                if (((result != 0.0) && (num2 != 0.0)) && MainForm.myMap.MapReaded)
                {
                    MainForm.myMap.setTrackingCar(sCarId);
                }
            }
        }

        private void dgvCarTextList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Record.execFileRecord("文本界面->DataGridView_DataError", e.Exception.Message);
        }

 private void doWorker()
        {
            if (this.dtText.Rows.Count == 0)
            {
                this.iNodeCnt = MainForm.myCarList.tvList.hasCarPath.Count;
            }
            else
            {
                this.iNodeCnt = this.dtText.Rows.Count;
            }
            WaitForm.Show("正在生成文本信息...", this);
            if (this.dgvCarTextList.DataSource != null)
            {
                this.dtText.Rows.Clear();
            }
            if (worker == null)
            {
                try
                {
                    worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(this.worder_DoWork);
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worder_RunWorkerCompleted);
                    worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
                    worker.WorkerReportsProgress = true;
                    worker.RunWorkerAsync();
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("文本位置->异步加载", exception.Message);
                }
            }
        }

        private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ReportExcel.OutputExcelChk(this.dgvCarTextList, "文本位置-" + DateTime.Now.ToString("yyyy-MM-dd"), e.Argument.ToString());
            }
            catch (Exception exception)
            {
                Record.execFileRecord("文本界面->导出到Excel", exception.Message);
                e.Result = exception.Message;
            }
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                MessageBox.Show(e.Result.ToString());
            }
            WaitForm.Hide();
        }

        private void ExportExcel()
        {
            int num = 0;
            foreach (DataGridViewRow row in (IEnumerable) this.dgvCarTextList.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells["colSelect"] as DataGridViewCheckBoxCell;
                if (((cell != null) && (cell.Value != null)) && bool.Parse(cell.FormattedValue.ToString()))
                {
                    num++;
                }
            }
            if (num > 0)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Filter = "Execl files (*.xls)|*.xls",
                    FilterIndex = 0,
                    RestoreDirectory = true,
                    CreatePrompt = true,
                    FileName = "文本位置-" + DateTime.Now.ToString("yyyy-MM-dd"),
                    Title = "导出文件保存路径"
                };
                string fileName = "";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                fileName = dialog.FileName;
                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }
                WaitForm.Show("正在导出数据...", this);
                try
                {
                    excelWorker = new BackgroundWorker();
                    excelWorker.DoWork += new DoWorkEventHandler(this.excelWorker_DoWork);
                    excelWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.excelWorker_RunWorkerCompleted);
                    excelWorker.RunWorkerAsync(fileName);
                    return;
                }
                catch (Exception exception)
                {
                    WaitForm.Hide();
                    MessageBox.Show(exception.Message + "\r\n原因：文件可能已打开！");
                    Record.execFileRecord("文本界面->导出到Excel", exception.Message);
                    return;
                }
            }
            MessageBox.Show("没有数据可供导出,请先选中要导出的数据！");
        }

        private void getAddress()
        {
            object obj2 = MainForm.myMap.getTrackPointQueryInfo(this.sQueryTypeValue);
            if ((obj2 != null) && !string.IsNullOrEmpty(obj2.ToString()))
            {
                foreach (string str2 in obj2.ToString().Split(this.sSplit, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] strArray2 = str2.Split(new char[] { '|' });
                    string key = strArray2[0];
                    string str4 = strArray2[1];
                    try
                    {
                        DataRow row = this.dtText.Rows.Find(key);
                        if (row != null)
                        {
                            row["CurrentAddress"] = str4;
                        }
                    }
                    catch (Exception exception)
                    {
                        Record.execFileRecord("文本位置->设置地址信息", exception.Message);
                    }
                }
            }
        }

        private void getTreeNodeIsChecked(ThreeStateTreeNode tn, ref DataTable dt)
        {
            foreach (ThreeStateTreeNode node in tn.Nodes)
            {
                if ((node.Tag != null) && node.Tag.Equals("CAR"))
                {
                    if (node.Checked)
                    {
                        string str = (node.AccOn == "0") ? "关" : "开";
                        object[] values = new object[14];
                        values[0] = node.CarNum;
                        values[1] = node.SimNum;
                        values[2] = (node.CarAreaName == node.WordCompany) ? node.CarAreaName : (node.WordCompany + "-" + node.CarAreaName);
                        values[3] = node.Longitude;
                        values[4] = node.Latitude;
                        values[5] = node.ALLDiff;
                        values[6] = node.ReceTime;
                        values[7] = node.GpsTime;
                        values[9] = node.Speed;
                        values[10] = str;
                        values[11] = node.DriverName;
                        values[12] = node.CarId;
                        values[13] = node.AreaType;
                        dt.Rows.Add(values);
                        if (!string.IsNullOrEmpty(node.Longitude))
                        {
                            if (!this.bRefresh)
                            {
                                this.iCurrentCnt++;
                                worker.ReportProgress(this.iCurrentCnt / this.iNodeCnt, node.SimNum + "|" + node.Longitude + "," + node.Latitude);
                            }
                            else
                            {
                                MainForm.myMap.execExcuteTrackPointQuerty(this.sQueryTypeValue, node.SimNum, node.Longitude, node.Latitude);
                            }
                        }
                    }
                }
                else
                {
                    this.getTreeNodeIsChecked(node, ref dt);
                }
            }
        }

        private void initClomun()
        {
            int num = 0;
            try
            {
                num = int.Parse(Variable.sCarListTextColunmsVisibleType);
                if (num == 0)
                {
                    return;
                }
            }
            catch
            {
            }
            if ((num & 1) != 0)
            {
                this.cboxLongitude.Checked = true;
            }
            this.dgvCarTextList.Columns["CarLongitude"].Visible = this.cboxLongitude.Checked;
            if ((num & 2) != 0)
            {
                this.cboxLatitude.Checked = true;
            }
            this.dgvCarTextList.Columns["CarLatitude"].Visible = this.cboxLatitude.Checked;
            if ((num & 4) != 0)
            {
                this.cboxAllDiff.Checked = true;
            }
            this.dgvCarTextList.Columns["CarAllDiff"].Visible = this.cboxAllDiff.Checked;
            if ((num & 8) != 0)
            {
                this.cboxReceTime.Checked = true;
            }
            this.dgvCarTextList.Columns["CarReceTime"].Visible = this.cboxReceTime.Checked;
            if ((num & 16) != 0)
            {
                this.cboxGpsTime.Checked = true;
            }
            this.dgvCarTextList.Columns["CarGpsTime"].Visible = this.cboxGpsTime.Checked;
            if ((num & 32) != 0)
            {
                this.cboxAddress.Checked = true;
            }
            this.dgvCarTextList.Columns["CarCurrentAddress"].Visible = this.cboxAddress.Checked;
            if ((num & 64) != 0)
            {
                this.cboxSpeed.Checked = true;
            }
            this.dgvCarTextList.Columns["CarSpeed"].Visible = this.cboxSpeed.Checked;
            if ((num & 128) != 0)
            {
                this.cboxAccOn.Checked = true;
            }
            this.dgvCarTextList.Columns["CarAcc"].Visible = this.cboxAccOn.Checked;
            if ((num & 256) != 0)
            {
                this.cboxDriver.Checked = true;
            }
            this.dgvCarTextList.Columns["DriverName"].Visible = this.cboxDriver.Checked;
        }

        private void initDataTable()
        {
            if (this.dtText.Columns.Count <= 0)
            {
                this.dtText.Columns.Add("CarName", typeof(string));
                this.dtText.Columns.Add("CarTel", typeof(string));
                this.dtText.Columns.Add("CarArea", typeof(string));
                this.dtText.Columns.Add("Longitude", typeof(string));
                this.dtText.Columns.Add("Latitude", typeof(string));
                this.dtText.Columns.Add("ALLDiff", typeof(string));
                this.dtText.Columns.Add("ReceTime", typeof(string));
                this.dtText.Columns.Add("GpsTime", typeof(string));
                this.dtText.Columns.Add("CurrentAddress", typeof(string));
                this.dtText.Columns.Add("Speed", typeof(string));
                this.dtText.Columns.Add("Acc", typeof(string));
                this.dtText.Columns.Add("DriverName", typeof(string));
                this.dtText.Columns.Add("CarID", typeof(string));
                this.dtText.Columns.Add("AreaType", typeof(string));
                this.dtText.PrimaryKey = new DataColumn[] { this.dtText.Columns["CarTel"] };
                this.cbAreaType.SelectedIndex = 0;
            }
        }

 private void refleshData()
        {
            string str = "";
            str = ((((str + ((this.txtAreaName.Text.Trim().Length > 0) ? string.Format(this.txtAreaName.Tag.ToString(), this.txtAreaName.Text, (this.cbAreaType.SelectedIndex == 0) ? "" : this.cbAreaType.SelectedIndex.ToString()) : " 1=1 ") + " And ") + ((this.txtCarNum.Text.Trim().Length > 0) ? string.Format(this.txtCarNum.Tag.ToString(), this.txtCarNum.Text) : " 1=1 ") + " And ") + ((this.txtSimNum.Text.Trim().Length > 0) ? string.Format(this.txtSimNum.Tag.ToString(), this.txtSimNum.Text) : " 1=1 ") + " And ") + ((this.txtDriverName.Text.Trim().Length > 0) ? string.Format(this.txtDriverName.Tag.ToString(), this.txtDriverName.Text) : " 1=1 ") + " And ").Trim().Trim("And".ToCharArray());
            this.source.Filter = str;
        }

        public void SetCarPlace()
        {
            try
            {
                for (int i = 0; i < this.dtText.Rows.Count; i++)
                {
                    DataRow row = this.dtText.Rows[i];
                    string str = row["Longitude"].ToString();
                    string sLat = row["Latitude"].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        try
                        {
                            row["CurrentAddress"] = GisService.QueryAllLayerByPoint(str, sLat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("文本位置->获取详细地址", exception.Message);
            }
        }

        private void setDGVCheck()
        {
            try
            {
                foreach (DataGridViewRow row in (IEnumerable) this.dgvCarTextList.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells["colSelect"] as DataGridViewCheckBoxCell;
                    if (cell != null)
                    {
                        cell.Value = this.cboxSelectedAll.Checked;
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("文本界面->设置全选全取消", exception.Message);
            }
        }

        private void tGetQueryTrackInfo_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.tGetQueryTrackInfo.Enabled = false;
            try
            {
                base.Invoke(this.myGetTrackQueryInfo);
            }
            catch
            {
            }
            this.tGetQueryTrackInfo.Enabled = true;
        }

        private void worder_DoWork(object sender, DoWorkEventArgs e)
        {
            this.BindCarTextList();
        }

        private void worder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (this.dgvCarTextList.DataSource == null)
                {
                    this.source.DataSource = this.dtText;
                    this.dgvCarTextList.DataSource = this.source;
                }
                if ((this.dtText != null) && (this.dtText.Rows.Count > 0))
                {
                    this.refleshData();
                    this.cboxAccOn.Checked = !this.cboxAccOn.Checked;
                    this.cboxAccOn.Checked = !this.cboxAccOn.Checked;
                    this.lblDGVRowCount.Text = string.Format("总共 {0} 条记录", this.source.List.Count.ToString());
                }
                else
                {
                    this.lblDGVRowCount.Text = "";
                }
                worker.DoWork -= new DoWorkEventHandler(this.worder_DoWork);
                worker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.worder_RunWorkerCompleted);
                worker = null;
                this.dgvCarTextList.ClearSelection();
                this.dgvCarTextList.CurrentCell = this.dgvCarTextList.Rows[0].Cells[this.dgvCarTextList.FirstDisplayedCell.ColumnIndex];
                this.dgvCarTextList.FirstDisplayedScrollingRowIndex = 0;
                this.dgvCarTextList.EndEdit();
                this.dgvCarTextList.Refresh();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("文本位置->异步处理完成事件", exception.Message);
            }
            finally
            {
                WaitForm.Hide();
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                this.lblDGVRowCount.Text = string.Format("总共 {0} 条记录,已加裁{1}", this.iNodeCnt.ToString(), this.dtText.Rows.Count.ToString());
                try
                {
                    string[] strArray = e.UserState.ToString().Split(new char[] { '|' });
                    string[] strArray2 = strArray[1].Split(new char[] { ',' });
                    MainForm.myMap.execExcuteTrackPointQuerty(this.sQueryTypeValue, strArray[0], strArray2[0], strArray2[1]);
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("文本位置->异步加载完成", exception.Message);
                }
            }
        }

        private delegate void dGetTrackQueryInfo();
    }
}

