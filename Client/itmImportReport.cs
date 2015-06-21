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
    using System.Timers;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmImportReport : SizableForm
    {
        private bool bTrackingCar = true;
        public DataTable m_dtImportCar;

        public itmImportReport()
        {
            this.InitializeComponent();
            if (this.m_dtImportCar == null)
            {
                this.m_dtImportCar = new DataTable();
            }
            this.m_dtImportCar.Columns.Add(new DataColumn("CarNum"));
            this.m_dtImportCar.Columns.Add(new DataColumn("SimNum"));
            this.m_dtImportCar.PrimaryKey = new DataColumn[] { this.m_dtImportCar.Columns["SimNum"] };
        }

        public void addImportCar(string sCarNum, string sSimNum)
        {
            DataRow row = this.m_dtImportCar.NewRow();
            row["CarNum"] = sCarNum;
            row["SimNum"] = sSimNum;
            this.m_dtImportCar.Rows.Add(row);
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            this.wbMap.setPanTool();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomUpTool();
        }

        private void btnZoonOut_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomDownTool();
        }

        private bool chkIsImport(string sSimNum)
        {
            DataView view = new DataView(this.m_dtImportCar, string.Format("SimNum='{0}'", sSimNum), "", DataViewRowState.CurrentRows);
            return (view.Count > 0);
        }

        private void cmbAddCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.setSelectedItem();
            }
            else if (this.cmbAddCar.Focused && !this.cmbAddCar.DroppedDown)
            {
                this.cmbAddCar.DroppedDown = true;
            }
        }

        private void cmbAddCar_Leave(object sender, EventArgs e)
        {
            this.setSelectedItem();
        }

        private void cmbSelectMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_iSelectedMapIndex != this.cmbSelectMap.SelectedIndex)
            {
                string itemText = this.cmbSelectMap.ComboBox.GetItemText(this.cmbSelectMap.SelectedItem);
                string sValue = this.cmbSelectMap.ComboBox.SelectedValue.ToString();
                this.execMapChangeBaseLayer(itemText, sValue);
                this.m_iSelectedMapIndex = this.cmbSelectMap.SelectedIndex;
            }
        }

        public void delImportCar(string sSimNum)
        {
            DataView view = new DataView(this.m_dtImportCar, string.Format("SimNum='{0}'", sSimNum), "", DataViewRowState.CurrentRows);
            if (view.Count > 0)
            {
                if (this.lbImportCar.SelectedValue.ToString() == sSimNum)  ///ToString
                {
                    this.setTrackingCar();
                }
                view.Delete(0);
            }
        }

        public void delImportWatch()
        {
            if (this.m_dtImportCar != null)
            {
                string str = "";
                foreach (DataRow row in this.m_dtImportCar.Rows)
                {
                    string str2 = row["SimNum"].ToString();
                    str = str + str2 + ",";
                }
                if (!string.IsNullOrEmpty(str))
                {
                    int num = RemotingClient.Car_UpdateImportWatch(str.Trim(new char[] { ',' }), 0);
                    if (num < 0)
                    {
                        Record.execFileRecord("重点监控窗体关闭", string.Format("更新重点监控参数失败:{0}", num));
                    }
                    this.m_dtImportCar = null;
                }
            }
        }

 private void execMapChangeBaseLayer(string sText, string sValue)
        {
            this.wbMap.execMapChangeBaseLayer(sText, sValue);
        }

 private void itmImportReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                this.m_tMapLoadedTimer.Stop();
                this.delImportWatch();
                WaitForm.Hide2();
            }
        }

        private void itmImportReport_Load(object sender, EventArgs e)
        {
            Point point = new Point((this.wbMap.Width / 2) - 85, (this.wbMap.Height / 2) - 17);
            this.picLoadMap.Location = point;
            this.picLoadMap.Visible = true;
            this.wbMap.Url = new Uri(Variable.MapUrl);
            this.pnlHandle.Enabled = false;
            this.pnlTool.Enabled = false;
            this.lbImportCar.DataSource = this.m_dtImportCar;
            this.refCarImportLst();
            this.setCarList();
            this.m_tMapLoadedTimer = new System.Timers.Timer(1000.0);
            this.m_tMapLoadedTimer.Elapsed += new ElapsedEventHandler(this.m_tMapLoadedTimer_Elapsed);
            this.m_tMapLoadedTimer.Start();
        }

        private void lbImportCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((this.lbImportCar.SelectedIndex >= 0) && (this.wbMap.Document != null))
                {
                    if (this.lbImportCar.Items.Count > 0)
                    {
                        this.cmbAddCar.Text = this.lbImportCar.Text;
                    }
                    if (this.cmbAddCar.SelectedIndex >= 0)
                    {
                        this.setTrackingCar();
                    }
                }
            }
            catch
            {
            }
        }

        private void m_tMapLoadedTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.myTrackingCar != null)
            {
                try
                {
                    this.m_tMapLoadedTimer.Interval = 60000.0;
                    base.Invoke(this.myTrackingCar);
                }
                catch
                {
                }
                finally
                {
                    this.m_tMapLoadedTimer.Interval = 1000.0;
                }
            }
        }

        private void refCarImportLst()
        {
            if ((this.m_dtImportCar == null) || (this.m_dtImportCar.Rows.Count == 0))
            {
                this.Text = "重点监控";
            }
            else
            {
                string str = "重点监控-";
                string str2 = "";
                foreach (DataRow row in this.m_dtImportCar.Rows)
                {
                    string str3 = row["CarNum"].ToString();
                    str = str + str3 + "/";
                    str2 = str2 + "'" + str3 + "',";
                }
                this.Text = str;
            }
        }

        private void setCarList()
        {
            DataTable allCar = MainForm.myCarList.AllCar;
            allCar.Columns["CarNum"].ColumnName = "Display";
            allCar.Columns["SimNum"].ColumnName = "Value";
            this.cmbAddCar.DataSource = new DataView(allCar, "", "Display", DataViewRowState.CurrentRows);
            this.cmbAddCar.SelectedValue = MainForm.myCarList.SelectedSimNum;
        }

        public void setImportCarLst(string sSimNumLst, string sCarNumLst)
        {
            string[] strArray = sSimNumLst.Split(new char[] { ',' });
            string[] strArray2 = sCarNumLst.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                DataRow row = this.m_dtImportCar.NewRow();
                row["CarNum"] = strArray2[i];
                row["SimNum"] = strArray[i];
                this.m_dtImportCar.Rows.Add(row);
            }
        }

        private void setMap(string sMapsStr)
        {
            if (this.cmbSelectMap.Items.Count <= 0)
            {
                try
                {
                    this.cmbSelectMap.ComboBox.Items.Clear();
                    DataTable table = new DataTable();
                    table.Columns.Add("values", typeof(string));
                    table.Columns.Add("Text", typeof(string));
                    string[] strArray = sMapsStr.Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new char[] { ';' });
                        if (strArray2.Length == 2)
                        {
                            table.Rows.Add(new object[] { strArray2[0], strArray2[1] });
                        }
                    }
                    this.cmbSelectMap.ComboBox.DisplayMember = "Text";
                    this.cmbSelectMap.ComboBox.ValueMember = "values";
                    this.cmbSelectMap.ComboBox.DataSource = table;
                    this.cmbSelectMap.ComboBox.SelectedValue = MainForm.m_sSelectedMap;
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("设置地图", exception.Message);
                }
            }
        }

        private void setSelectedItem()
        {
            string text = this.cmbAddCar.Text;
            int num = this.cmbAddCar.FindString(text);
            if (num >= 0)
            {
                this.cmbAddCar.SelectedIndex = num;
                this.cmbAddCar.SelectAll();
            }
            else
            {
                this.cmbAddCar.SelectedIndex = -1;
                this.cmbAddCar.Text = "";
            }
            this.cmbAddCar.DroppedDown = false;
        }

        private void setTrackingCar()
        {
            try
            {
                if (Convert.ToBoolean(this.wbMap.isMapLoadedSuccess()))
                {
                    string sCarId = ((DataView) this.cmbAddCar.DataSource)[this.cmbAddCar.SelectedIndex]["CarId"].ToString();
                    this.wbMap.setTrackingCar(sCarId);
                    this.m_tMapLoadedTimer.Stop();
                }
            }
            catch
            {
            }
        }

        public void ShowCar(DataRow dr)
        {
            try
            {
                string sSimNum = dr["SimNum"].ToString();
                if (this.chkIsImport(sSimNum))
                {
                    string key = dr["CarId"].ToString();
                    string iCarStatus = dr["CarStatus"].ToString();
                    if (((iCarStatus != "1") && (MainForm.myCarList.m_dtCarAlermList != null)) && (MainForm.myCarList.m_dtCarAlermList.Rows.Find(key) != null))
                    {
                        iCarStatus = "1";
                    }
                    string sCarNum = dr["carNum"].ToString();
                    dr["gpsTime"].ToString();
                    string x = dr["Longitude"].ToString();
                    string y = dr["Latitude"].ToString();
                    bool bIsShowTrack = true;
                    bool bIsFill = false;
                    bool bAccOn = false;
                    bool bGpsValid = false;
                    object iDirection = null;
                    if (dr["IsFill"].ToString() == "1")
                    {
                        bIsFill = true;
                    }
                    if (dr["AccOn"].ToString() == "1")
                    {
                        bAccOn = true;
                    }
                    if (dr["GpsValid"].ToString() == "1")
                    {
                        bGpsValid = true;
                    }
                    if (dr.Table.Columns.Contains("Direct"))
                    {
                        iDirection = dr["Direct"];
                    }
                    string str7 = MainForm.myCarList.setMapTipDetail(dr);
                    if (string.IsNullOrEmpty(str7))
                    {
                        str7 = string.Format("车牌[{0}]ACC[{1}]GPS时间[{2}]；经度[{3}]纬度[{4}]速度[{5}km/h]", new object[] { dr["CarNum"].ToString(), dr["AccOn"].ToString(), dr["gpsTime"].ToString(), dr["Longitude"].ToString(), dr["Latitude"].ToString(), dr["speed"].ToString() });
                    }
                    this.wbMap.execShowCar(sCarNum, x, y, iDirection, 1, null, str7, iCarStatus, dr["AlarmType"].ToString(), bIsFill, bAccOn, bGpsValid, dr["CarId"].ToString(), bIsShowTrack);
                }
            }
            catch
            {
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.setSelectedItem();
                if (this.cmbAddCar.SelectedValue == null)
                {
                    MessageBox.Show("请选择监控车辆");
                }
                else
                {
                    string sSimNum = this.cmbAddCar.SelectedValue.ToString();  ///ToString
                    string text = this.cmbAddCar.Text;
                    ((DataView) this.cmbAddCar.DataSource)[this.cmbAddCar.SelectedIndex]["CarId"].ToString();
                    if (this.chkIsImport(sSimNum))
                    {
                        MessageBox.Show("该车辆已在当前监控窗体内！");
                    }
                    else if (this.m_dtImportCar.Rows.Count >= int.Parse(Variable.sImportCarMax))
                    {
                        MessageBox.Show(string.Format("监控车辆车辆不能超过{0}辆", Variable.sImportCarMax));
                    }
                    else if (MainForm.myCarList.setCarChecked(text, true) != 0)
                    {
                        MessageBox.Show("更新重点监控参数失败");
                    }
                    else if (RemotingClient.Car_UpdateImportWatch(sSimNum, 1) < 0)
                    {
                        MessageBox.Show("更新重点监控参数失败");
                    }
                    else
                    {
                        this.addImportCar(text, sSimNum);
                        this.lbImportCar.SelectedItem = this.lbImportCar.Items[this.lbImportCar.Items.Count - 1];
                        this.refCarImportLst();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Record.execFileRecord("添加重点监控车辆", exception.ToString());
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbAddCar.SelectedValue == null)
                {
                    MessageBox.Show("请选择监控车辆");
                    return;
                }
                if (this.lbImportCar.Items.Count == 0)
                {
                    return;
                }
                string sSimNum = this.cmbAddCar.SelectedValue.ToString(); ///ToString
                string text = this.cmbAddCar.Text;
                string sCarId = ((DataView) this.cmbAddCar.DataSource)[this.cmbAddCar.SelectedIndex]["CarId"].ToString();
                if (this.chkIsImport(sSimNum))
                {
                    if (RemotingClient.Car_UpdateImportWatch(sSimNum, 0) < 0)
                    {
                        MessageBox.Show("更新重点监控参数失败");
                        return;
                    }
                    this.delImportCar(sSimNum);
                    this.wbMap.execDeleteCar(sCarId);
                    this.refCarImportLst();
                    if (((this.wbMap.Document != null) && (this.lbImportCar.SelectedIndex >= 0)) && (this.lbImportCar.Items.Count > 0))
                    {
                        this.cmbAddCar.Text = this.lbImportCar.Text;
                    }
                }
                else
                {
                    MessageBox.Show("该车辆未在当前监控窗体内！");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Record.execFileRecord("添加重点监控车辆", exception.ToString());
            }
            this.bTrackingCar = true;
        }

        private void tsbDistance_Click(object sender, EventArgs e)
        {
            this.wbMap.setMeasureTool();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            this.wbMap.Refresh();
        }

        private void wbMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.wbMap.Url.ToString().Equals("about:blank"))
            {
                this.picLoadMap.Visible = false;
            }
            else if (this.wbMap.Document.GetElementById("map") == null)
            {
                this.picLoadMap.Visible = false;
                this.wbMap.Url = new Uri("about:blank");
                MessageBox.Show("地图初始化失败！");
                Record.execFileRecord("加载地图", "地图初始化失败！");
            }
            else
            {
                this.pnlHandle.Enabled = true;
                this.pnlTool.Enabled = true;
                object obj2 = this.wbMap.getMapList();
                if (obj2 == null)
                {
                    this.picLoadMap.Visible = false;
                }
                else
                {
                    this.setMap(obj2.ToString());
                    this.wbMap.setMap(MainForm.myMap.getMapView());
                    this.picLoadMap.Visible = false;
                    this.myTrackingCar = new dTrackingCar(this.setTrackingCar);
                }
            }
        }

        private delegate void dTrackingCar();
    }
}

