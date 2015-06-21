namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using Sunisoft.IrisSkin;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class QueryCarInfo : FixedForm
    {
        public Button btnClose;
        public Button btnLoad;
        public Button btnOK;
        public Button btnStop;
        private static Hashtable htCurrentCarList = new Hashtable();
        private string[] sTelephoneList;
        private Thread[] tSearchs;

        public QueryCarInfo()
        {
            this.objLock = new object();
            this.objLockProgress = new object();
            this.tSearchs = new Thread[10];
            this.iCntPerPage = 50;
            this.sExecSql = "";
            this.InitializeComponent();
        }

        public QueryCarInfo(string[] sPoints)
        {
            this.objLock = new object();
            this.objLockProgress = new object();
            this.tSearchs = new Thread[10];
            this.iCntPerPage = 50;
            this.sExecSql = "";
            this.InitializeComponent();
            this.execRefRegion(sPoints);
        }

        private void addProgress()
        {
            this.pbDownLoad.Value += 3;
            if ((this.pbDownLoad.Value == this.pbDownLoad.Maximum) || !this.bSearchResult)
            {
                this.btnOK.Enabled = true;
                this.chkShowCar.Enabled = true;
                this.btnStop.Enabled = false;
                this.panelLoading.Visible = false;
                this.dgvQueryResult.Refresh();
                if (this.bSearchResult)
                {
                    MessageBox.Show("查询已完成！");
                }
                else
                {
                    MessageBox.Show("查询已完成，但在查询过程中存在异常！");
                }
                this.SetEnable(true);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.dtLonLatList.Rows.Count >= 3)
            {
                MessageBox.Show("最多可以设置三个！");
            }
            else if (string.IsNullOrEmpty(this.txtLon11.Text))
            {
                MessageBox.Show("经纬度值为空，请先设置经纬度值！");
            }
            else
            {
                string sRegionId = this.cmbRegionType1.SelectedValue.ToString();
                string text = this.cmbRegionType1.Text;
                string sLonLat = "1".Equals(this.cmbRegionType1.SelectedValue.ToString()) ? (this.txtLon11.Text + "," + this.txtLat11.Text + "," + this.txtLon12.Text) : (this.txtLon11.Text + "," + this.txtLat11.Text + "," + this.txtLon12.Text + "," + this.txtLat12.Text);
                string s = this.dtpStartDate1.Value.ToString("yyyy-MM-dd") + " " + this.dtpStartTime1.Value.ToString("HH:mm:ss");
                string str5 = this.dtpEndDate1.Value.ToString("yyyy-MM-dd") + " " + this.dtpEndTime1.Value.ToString("HH:mm:ss");
                if (DateTime.Parse(s) > DateTime.Parse(str5))
                {
                    MessageBox.Show("开始时间大于结束时间");
                }
                else if (this.CheckSameRow(sRegionId, text, sLonLat, s, str5))
                {
                    MessageBox.Show("该设置已存在，请重新设置！");
                }
                else
                {
                    this.dtLonLatList.Rows.Add(new object[] { sRegionId, text, sLonLat, s, str5 });
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = true;
            this.chkShowCar.Enabled = true;
            this.SetEnable(true);
            try
            {
                for (int i = 0; i < this.tSearchs.Length; i++)
                {
                    if ((this.tSearchs[i] != null) && this.tSearchs[i].IsAlive)
                    {
                        this.tSearchs[i].Abort();
                    }
                }
                this.pbDownLoad.Value = 0;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("日期查车->停止", exception.Message);
            }
            this.panelLoading.Visible = false;
            this.bSearchResult = true;
        }

        private void btnClearRegionData_Click(object sender, EventArgs e)
        {
            if (this.dtSearchCar != null)
            {
                this.dtSearchCar.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvLonLat.CurrentRow != null)
            {
                int index = this.dgvLonLat.CurrentRow.Index;
                this.dgvLonLat.Rows.RemoveAt(index);
                this.dgvLonLat.Refresh();
            }
        }

        private void btnGetLatLon1_Click(object sender, EventArgs e)
        {
            QueryMap map = new QueryMap(int.Parse(this.cmbRegionType1.SelectedValue.ToString()));
            if (map.ShowDialog() == DialogResult.OK)
            {
                this.cmbRegionType1.SelectedValue = map.m_iRegionType;
                if (map.m_iRegionType == 1)
                {
                    this.txtLon11.Text = map.Longitude1;
                    this.txtLat11.Text = map.Latitude1;
                    this.txtLon12.Text = map.Radius.ToString();
                }
                else
                {
                    this.txtLat11.Text = map.Latitude1;
                    this.txtLon11.Text = map.Longitude1;
                    this.txtLat12.Text = map.Latitude2;
                    this.txtLon12.Text = map.Longitude2;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (this.dgvQueryResult.Rows.Count <= 0)
            {
                MessageBox.Show("日期查车结果为空，无数据可供导出！");
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Filter = "Execl files (*.xls)|*.xls",
                    FilterIndex = 0,
                    RestoreDirectory = true,
                    CreatePrompt = true,
                    FileName = "日期查车报表-" + DateTime.Now.ToString("yyyy-MM-dd"),
                    Title = "导出文件保存路径"
                };
                string fileName = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        WaitForm.Show("正在导出数据...", this);
                        try
                        {
                            this.excelWorker = new BackgroundWorker();
                            this.excelWorker.DoWork += new DoWorkEventHandler(this.excelWorker_DoWork);
                            this.excelWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.excelWorker_RunWorkerCompleted);
                            this.excelWorker.RunWorkerAsync(fileName);
                        }
                        catch (Exception exception)
                        {
                            WaitForm.Hide();
                            MessageBox.Show(exception.Message + "\r\n原因：文件可能已打开！");
                            Record.execFileRecord("日期查车->导出到Excel", exception.Message);
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sWheres = "";
            this.iPage = 0;
            this.pbDownLoad.Value = 0;
            this.pbDownLoad.Maximum = 2147483647;
            try
            {
                if (this.dtSearchCar != null)
                {
                    this.dtSearchCar.Clear();
                }
                if (string.IsNullOrEmpty(this.txtLon11.Text))
                {
                    MessageBox.Show("请先设置区域时间范围！");
                }
                else
                {
                    sWheres = this.GetWheres();
                    if (sWheres == null)
                    {
                        MessageBox.Show("未设置区域时间范围！");
                    }
                    else
                    {
                        string str2 = this.getAreaCarList();
                        if (string.IsNullOrEmpty(str2))
                        {
                            MessageBox.Show("未找到符合条件的车辆！");
                        }
                        else
                        {
                            this.SetEnable(false);
                            this.panelLoading.Visible = true;
                            this.btnOK.Enabled = false;
                            this.chkShowCar.Enabled = false;
                            this.btnStop.Enabled = true;
                            this.bSearchResult = true;
                            this.execThread(str2, sWheres);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("日期查车->查询", exception.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvLonLat.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(this.txtLon11.Text))
                {
                    MessageBox.Show("经纬度值为空，请先设置经纬度值！");
                }
                else
                {
                    try
                    {
                        string sRegionId = this.cmbRegionType1.SelectedValue.ToString();
                        string text = this.cmbRegionType1.Text;
                        string sLonLat = "1".Equals(this.cmbRegionType1.SelectedValue.ToString()) ? (this.txtLon11.Text + "," + this.txtLat11.Text + "," + this.txtLon12.Text) : (this.txtLon11.Text + "," + this.txtLat11.Text + "," + this.txtLon12.Text + "," + this.txtLat12.Text);
                        string s = this.dtpStartDate1.Value.ToString("yyyy-MM-dd") + " " + this.dtpStartTime1.Value.ToString("HH:mm:ss");
                        string str5 = this.dtpEndDate1.Value.ToString("yyyy-MM-dd") + " " + this.dtpEndTime1.Value.ToString("HH:mm:ss");
                        if (DateTime.Parse(s) > DateTime.Parse(str5))
                        {
                            MessageBox.Show("开始时间大于结束时间");
                        }
                        else if (this.CheckSameRow(sRegionId, text, sLonLat, s, str5))
                        {
                            MessageBox.Show("该设置已存在，请重新设置！");
                        }
                        else
                        {
                            DataGridViewRow row = this.dgvLonLat.Rows[this.dgvLonLat.CurrentRow.Index];
                            row.Cells["RegionId"].Value = sRegionId;
                            row.Cells["RegionType"].Value = text;
                            row.Cells["LonLat"].Value = sLonLat;
                            row.Cells["StartTime"].Value = s;
                            row.Cells["EndTime"].Value = str5;
                            this.dgvLonLat.Refresh();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("更新失败，" + exception.Message);
                    }
                }
            }
        }

        private void ChangeCircleToZoomBox(string sLon, string sLat, string sDis, out string sLon1, out string sLon2, out string sLat1, out string sLat2)
        {
            double num = double.Parse(sDis) / 99898.7;
            double num2 = double.Parse(sDis) / 111194.8;
            double num3 = double.Parse(sLon) - num;
            double num4 = double.Parse(sLon) + num;
            double num5 = double.Parse(sLat) - num2;
            double num6 = double.Parse(sLat) + num2;
            sLon1 = Convert.ToDouble(num3).ToString("0.000000");
            sLon2 = Convert.ToDouble(num4).ToString("0.000000");
            sLat1 = Convert.ToDouble(num5).ToString("0.000000");
            sLat2 = Convert.ToDouble(num6).ToString("0.000000");
        }

        private bool CheckSameRow(string sRegionId, string sRegionType, string sLonLat, string sStartTime, string sEndTime)
        {
            foreach (DataRow row in this.dtLonLatList.Rows)
            {
                if (((sRegionId.Equals(row["RegionId"].ToString()) && sRegionType.Equals(row["RegionType"].ToString())) && (sLonLat.Equals(row["LonLat"].ToString()) && sStartTime.Equals(row["StartTime"].ToString()))) && sEndTime.Equals(row["EndTime"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private void cmdRegionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComBox box = sender as ComBox;
            if (box != null)
            {
                if ("1".Equals(box.SelectedValue.ToString()))
                {
                    this.lblLon12.Text = "半径：";
                    this.lblLat12.Visible = false;
                    this.txtLat12.Visible = false;
                    this.lblRadius1.Visible = true;
                }
                else
                {
                    this.lblLon12.Text = "到";
                    this.lblLat12.Visible = true;
                    this.txtLat12.Visible = true;
                    this.lblRadius1.Visible = false;
                }
                this.txtLat11.Text = "";
                this.txtLat12.Text = "";
                this.txtLon11.Text = "";
                this.txtLon12.Text = "";
            }
        }

        private void dgvLonLat_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvLonLat.CurrentRow != null)
            {
                string s = this.dgvLonLat.CurrentRow.Cells["RegionId"].Value.ToString();
                string str2 = this.dgvLonLat.CurrentRow.Cells["LonLat"].Value.ToString();
                string str3 = this.dgvLonLat.CurrentRow.Cells["StartTime"].Value.ToString();
                string str4 = this.dgvLonLat.CurrentRow.Cells["EndTime"].Value.ToString();
                string[] strArray = str2.Split(new char[] { ',' });
                this.cmbRegionType1.SelectedValue = int.Parse(s);
                this.txtLon11.Text = strArray[0];
                this.txtLat11.Text = strArray[1];
                this.txtLon12.Text = strArray[2];
                if (strArray.Length == 4)
                {
                    this.txtLat12.Text = strArray[3];
                }
                this.dtpStartTime1.Value = DateTime.Parse(str3);
                this.dtpStartDate1.Value = DateTime.Parse(str3);
                this.dtpEndTime1.Value = DateTime.Parse(str4);
                this.dtpEndDate1.Value = DateTime.Parse(str4);
            }
        }

        private void dgvQueryResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sCarId = this.dgvQueryResult.Rows[e.RowIndex].Cells["CarId"].Value.ToString();
                MainForm.myMap.setTrackingCar(sCarId);
            }
            catch
            {
            }
        }

 private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReportExcel.OutputExcel(this.dgvQueryResult, " 日期查车报表 ", e.Argument.ToString(), "日期查车报表", true);
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WaitForm.Hide();
        }

        public void execRefRegion(string[] sPointLst)
        {
            try
            {
                this.txtLon11.Text = sPointLst[0].Split(new char[] { ',' })[0];
                this.txtLon12.Text = sPointLst[1].Split(new char[] { ',' })[0];
                this.txtLat11.Text = sPointLst[0].Split(new char[] { ',' })[1];
                this.txtLat12.Text = sPointLst[1].Split(new char[] { ',' })[1];
            }
            catch (Exception exception)
            {
                Record.execFileRecord("日期查车->设置经纬度", exception.Message);
            }
        }

        private void execSearch()
        {
            try
            {
                do
                {
                    string str = "";
                    lock (this.objLock)
                    {
                        str = this.sTelephoneList[this.iPage];
                        this.iPage++;
                    }
                    string sql = string.Format(this.sExecSql, str);
                    int num = 0;
                    DataTable dt = null;
                    do
                    {
                        dt = RemotingClient.ExecSql(sql);
                        num++;
                    }
                    while ((dt == null) && (num < 3));
                    lock (this.objLockProgress)
                    {
                        this.execShowCarResult(dt);
                        base.Invoke(this.myAddProgress);
                    }
                }
                while (this.iPage < this.sTelephoneList.Length);
            }
            catch (ThreadAbortException)
            {
                this.bSearchResult = false;
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                base.Invoke(this.myAddProgress);
                Record.execFileRecord("日期查车", exception.Message);
                this.bSearchResult = false;
            }
        }

        private void execShowCarResult(DataTable dt)
        {
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataRow row in dt.Rows)
                {
                    string str = row["CarNum"].ToString();
                    string str2 = row["SimNum"].ToString();
                    string str3 = row["GPSTIME"].ToString();
                    string str4 = Convert.ToDouble(row["LONGITUDE"]).ToString("0.000000");
                    string str5 = Convert.ToDouble(row["LATITUDE"]).ToString("0.000000");
                    string str6 = Convert.ToDouble(row["SPEED"]).ToString("0.00");
                    string str7 = row["CarStatu"].ToString();
                    string str8 = row["DIRECT"].ToString();
                    string[] strArray = htCurrentCarList[str] as string[];
                    string str9 = "";
                    string str10 = "";
                    if (strArray != null)
                    {
                        str9 = strArray[1];
                        str10 = strArray[2];
                    }
                    this.dtSearchCar.Rows.Add(new object[] { str, str9, str2, str10, str3, str4, str5, str6, str7, str8 });
                    if (this.chkShowCar.Checked)
                    {
                        base.Invoke(this.myShowCar, new object[] { row });
                    }
                }
            }
        }

        private void execThread(string sSimNumList, string sWheres)
        {
            string[] separator = new string[] { "'@'" };
            this.pbDownLoad.Maximum = MainForm.myCarList.tvList.hasAreaPath.Count * 4;
            this.sTelephoneList = sSimNumList.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.pbDownLoad.Maximum = this.sTelephoneList.Length * 4;
            this.pbDownLoad.Value = this.sTelephoneList.Length;
            this.sExecSql = "select * from GetRECEREALTIMEDATA('{0}'," + sWheres + ")";
            for (int i = 0; (i < this.tSearchs.Length) && (i < this.sTelephoneList.Length); i++)
            {
                this.tSearchs[i] = new Thread(new ThreadStart(this.execSearch));
                this.tSearchs[i].Start();
            }
        }

        private string getAreaCarList()
        {
            string text = this.txtCarName.Text;
            int num = 0;
            StringBuilder builder = new StringBuilder();
            int num2 = 0;
            if (htCurrentCarList != null)
            {
                htCurrentCarList.Clear();
            }
            else
            {
                htCurrentCarList = new Hashtable();
            }
            try
            {
                int count = MainForm.myCarList.tvList.hasAreaPath.Count;
                foreach (string str2 in this.tvAreaList.hasAreaPath.Keys)
                {
                    ThreeStateTreeNode node = this.tvAreaList.getAreaById(str2);
                    if ((node != null) && node.Checked)
                    {
                        foreach (ThreeStateTreeNode node2 in MainForm.myCarList.tvList.getAreaById(str2).Nodes)
                        {
                            if ((node2.Tag.Equals("CAR") && (string.IsNullOrEmpty(text) || node2.Text.Contains(text))) && !htCurrentCarList.ContainsKey(node2.Name))
                            {
                                if (num >= this.iCntPerPage)
                                {
                                    builder.Append("'@'");
                                    num = 0;
                                }
                                num++;
                                string[] strArray = new string[] { node2.CarId, node2.CarNum, node2.CarAreaName };
                                htCurrentCarList.Add(node2.Name, strArray);
                                builder.Append(node2.SimNum + "|" + node2.Name + ";");
                            }
                        }
                        this.pbDownLoad.Value = num2++;
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("日期查车->获取勾选中的所有车辆", exception.Message);
            }
            return builder.ToString();
        }

        private string GetWheres()
        {
            string str = null;
            string str2 = ",";
            if (this.dgvLonLat.Rows.Count <= 0)
            {
                return null;
            }
            foreach (DataRow row in this.dtLonLatList.Rows)
            {
                string str3 = row["StartTime"].ToString();
                string str4 = row["EndTime"].ToString();
                string[] strArray = row["LonLat"].ToString().Split(new char[] { ',' });
                string sLon = strArray[0];
                string sLat = strArray[1];
                string str8 = "";
                string str9 = "";
                if (strArray.Length == 3)
                {
                    string sDis = strArray[2];
                    this.ChangeCircleToZoomBox(sLon, sLat, sDis, out sLon, out str8, out sLat, out str9);
                }
                else
                {
                    str8 = strArray[2];
                    str9 = strArray[3];
                }
                if (str == null)
                {
                    str2 = "";
                }
                else
                {
                    str2 = ",";
                }
                string str11 = str;
                str = str11 + str2 + "'" + str3 + "','" + str4 + "','" + sLon + "','" + str8 + "','" + sLat + "','" + str9 + "'";
            }
            for (int i = this.dtLonLatList.Rows.Count; i < 3; i++)
            {
                str = str + ",null,null,null,null,null,null";
            }
            return str;
        }

 private void InitRegionType()
        {
            this.cmbRegionType1.addItems("矩形区域", 2);
            this.cmbRegionType1.addItems("圆形区域", 1);
        }

        private void initTreeView()
        {
            this.tvAreaList.Nodes.Clear();
            this.tvAreaList.hasAreaPath.Clear();
            foreach (ThreeStateTreeNode node2 in MainForm.myCarList.tvList.Nodes)
            {
                if (node2.Tag.Equals("AREA"))
                {
                    ThreeStateTreeNode node = new ThreeStateTreeNode {
                        Name = node2.Name,
                        Text = node2.AreaName,
                        CarNum = node2.CarNum,
                        SimNum = node2.SimNum,
                        Tag = "AREA"
                    };
                    this.tvAreaList.Nodes.Add(node);
                    this.tvAreaList.hasAreaPath.Add(node2.Name, node);
                    if (node2.Nodes.Count > 0)
                    {
                        this.initTreeView(node, node2);
                    }
                }
            }
        }

        private void initTreeView(ThreeStateTreeNode rootNode, ThreeStateTreeNode newNode)
        {
            foreach (ThreeStateTreeNode node2 in newNode.Nodes)
            {
                if (node2.Tag.Equals("AREA"))
                {
                    ThreeStateTreeNode node = new ThreeStateTreeNode {
                        Name = node2.Name,
                        Text = node2.AreaName,
                        CarNum = node2.CarNum,
                        SimNum = node2.SimNum,
                        Tag = "AREA"
                    };
                    rootNode.Nodes.Add(node);
                    this.tvAreaList.hasAreaPath.Add(node2.Name, node);
                    if (node2.Nodes.Count > 0)
                    {
                        this.initTreeView(node, node2);
                    }
                }
            }
        }

        private void MapFlag_Load(object sender, EventArgs e)
        {
            this.myAddProgress = new dAddProgress(this.addProgress);
            this.myShowCar = new dShowCar(this.RegionShowCar);
            this.dtpStartDate1.Value = DateTime.Now;
            this.dtpEndDate1.Value = DateTime.Now;
            this.panelLoading.Visible = false;
            this.lblWaitText.BackColor = Color.Transparent;
            if (this.dtSearchCar == null)
            {
                this.dtSearchCar = new DataTable();
                this.dtSearchCar.Columns.Add("CarID", typeof(string));
                this.dtSearchCar.Columns.Add("CarNum", typeof(string));
                this.dtSearchCar.Columns.Add("SimNum", typeof(string));
                this.dtSearchCar.Columns.Add("AreaName", typeof(string));
                this.dtSearchCar.Columns.Add("GpsTime", typeof(string));
                this.dtSearchCar.Columns.Add("Longitude", typeof(string));
                this.dtSearchCar.Columns.Add("Latitude", typeof(string));
                this.dtSearchCar.Columns.Add("Speed", typeof(string));
                this.dtSearchCar.Columns.Add("CarStatu", typeof(string));
                this.dtSearchCar.Columns.Add("Direct", typeof(string));
            }
            this.dgvQueryResult.DataSource = new DataView(this.dtSearchCar, "", "", DataViewRowState.CurrentRows);
            if (this.dtLonLatList == null)
            {
                this.dtLonLatList = new DataTable();
                this.dtLonLatList.Columns.Add("RegionId", typeof(string));
                this.dtLonLatList.Columns.Add("RegionType", typeof(string));
                this.dtLonLatList.Columns.Add("LonLat", typeof(string));
                this.dtLonLatList.Columns.Add("StartTime", typeof(string));
                this.dtLonLatList.Columns.Add("EndTime", typeof(string));
            }
            this.dgvLonLat.DataSource = this.dtLonLatList;
            this.InitRegionType();
            try
            {
                this.initTreeView();
                this.tvAreaList.CheckBoxes = true;
                foreach (ThreeStateTreeNode node in this.tvAreaList.Nodes)
                {
                    node.Expand();
                }
            }
            catch
            {
            }
        }

        private void QueryCarInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason != CloseReason.FormOwnerClosing)
                {
                    for (int i = 0; i < this.tSearchs.Length; i++)
                    {
                        if ((this.tSearchs[i] != null) && (this.tSearchs[i].ThreadState == ThreadState.Running))
                        {
                            MessageBox.Show("请先停止查询！");
                            e.Cancel = true;
                            return;
                        }
                    }
                    for (int j = 0; j < this.tSearchs.Length; j++)
                    {
                        this.tSearchs[j] = null;
                    }
                    this.tSearchs = null;
                    if (htCurrentCarList != null)
                    {
                        htCurrentCarList.Clear();
                        htCurrentCarList = null;
                    }
                }
            }
            catch
            {
            }
        }

        private void RegionShowCar(DataRow dr)
        {
            try
            {
                string str = string.Format("车牌[{0}]GPS时间[{1}]；经度[{2}]纬度[{3}]速度[{4}km/h]", new object[] { dr["CarNum"].ToString(), dr["gpsTime"].ToString(), Convert.ToDouble(dr["Longitude"]).ToString("0.00000"), Convert.ToDouble(dr["Latitude"]).ToString("0.00000"), Convert.ToDouble(dr["speed"]).ToString("N") });
                bool bIsFill = false;
                bool bAccOn = true;
                bool bGpsValid = true;
                string[] strArray = htCurrentCarList[dr["CarNum"].ToString()] as string[];
                string sCarId = strArray[0];
                string sCarNum = strArray[1];
                MainForm.myMap.execShowCar(sCarNum, dr["Longitude"].ToString(), dr["Latitude"].ToString(), null, 1, null, str.Replace("；", "\r\n"), 2, null, bIsFill, bAccOn, bGpsValid, sCarId);
            }
            catch
            {
            }
        }

        private void SetEnable(bool bEnable)
        {
            this.pnlCarName.Enabled = bEnable;
            this.grpLonLat1.Enabled = bEnable;
            this.grpSetResult.Enabled = bEnable;
        }

        private void tvAreaList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ThreeStateTreeNode node = (ThreeStateTreeNode) e.Node;
            if (node.Checked)
            {
                node.CheckState = TriState.Checked;
            }
            else
            {
                node.CheckState = TriState.Unchecked;
            }
            foreach (ThreeStateTreeNode node2 in node.Nodes)
            {
                this.tvAreaList.SetNodeTriState(node2);
            }
            this.tvAreaList.RecursiveSetNodeTriState((ThreeStateTreeNode) e.Node);
        }

        private void tvAreaList_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "Folder_Collapse";
            e.Node.SelectedImageKey = "Folder_Collapse";
        }

        private void tvAreaList_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "Folder_Expand";
            e.Node.SelectedImageKey = "Folder_Expand";
        }

        private delegate void dAddProgress();

        private delegate void dShowCar(DataRow dr);
    }
}

