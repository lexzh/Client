namespace Client.M2M
{
    using Client;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class m2mPreSetRegion : SizableForm
    {
        private static string m_sRegionKong = "(无)";

        public m2mPreSetRegion(itmPreSetPath.PreType type)
        {
            this.InitializeComponent();
            this.preType = type;
        }

        private void btnArrowhead_Click(object sender, EventArgs e)
        {
            this.wbMap.setArrowheadTool();
            this.setModifyUiState(false);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            if (this.isRegionModify(2))
            {
                MessageBox.Show("请在地图上点击圆形的中心点所在位置。");
                this.wbMap.setCircleTool();
            }
        }

        private void btnDelRegion_Click(object sender, EventArgs e)
        {
            string text = this.cmbRegion.Text;
            if (text == m_sRegionKong)
            {
                MessageBox.Show("没有区域");
            }
            else if (MessageBox.Show(string.Format("您确认要删除区域{0}吗？", text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!RemotingClient.Alarm_DelRegionCheckAuth(text))
                {
                    MessageBox.Show(string.Format("您无权限删除区域{0}!", text));
                }
                else if (RemotingClient.Alarm_DelRegion(text) < 0)
                {
                    MessageBox.Show("区域删除失败");
                }
                else
                {
                    DataTable dataSource = (DataTable) this.cmbRegion.DataSource;
                    foreach (DataRow row in dataSource.Select(string.Format("RegionName='{0}'", text)))
                    {
                        dataSource.Rows.Remove(row);
                        if (dataSource.Rows.Count > 0)
                        {
                            this.cmbRegion_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            this.cmbRegion.DataSource = null;
                            this.cmbRegion.Items.Clear();
                            this.cmbRegion.Items.Add(m_sRegionKong);
                            this.cmbRegion.Text = m_sRegionKong;
                        }
                    }
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnDisplay.Dock = DockStyle.Top;
            this.btnTool.Dock = DockStyle.Bottom;
            this.btnSet.SendToBack();
            this.btnSetRegion.Visible = false;
            this.btnRectangle.Visible = false;
            this.btnCircle.Visible = false;
            this.btnPreviewDel.Visible = true;
            this.btnMove.Visible = false;
            this.btnZoomIn.Visible = false;
            this.btnZoonOut.Visible = false;
        }

        private void btnModifyRegion_Click(object sender, EventArgs e)
        {
            if (this.cmbRegion.Items.Count > 0)
            {
                if (!this.isModify)
                {
                    this.setModifyUiState(true);
                    if (this.currentRegionType == 1)
                    {
                        this.btnSetRegion_Click(null, null);
                    }
                    else if (this.currentRegionType == 0)
                    {
                        this.btnRectangle_Click(null, null);
                    }
                    else if (this.currentRegionType == 2)
                    {
                        this.btnCircle_Click(null, null);
                    }
                }
                else
                {
                    this.setModifyUiState(false);
                    this.cmbRegion_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            this.wbMap.setPanTool();
            this.setModifyUiState(false);
        }

        private void btnPreviewDel_Click(object sender, EventArgs e)
        {
            this.pnlRegion.Visible = true;
            DataTable table = RemotingClient.Alarm_GetRegionInfo();
            try
            {
                table.PrimaryKey = new DataColumn[] { table.Columns["regionID"] };
            }
            catch (Exception exception)
            {
                Record.execFileRecord("预设区域-->获取数据", exception.Message);
            }
            if ((table != null) && (table.Rows.Count > 0))
            {
                this.cmbRegion.DataSource = table;
                this.cmbRegion.SelectedIndex = 0;
            }
            else
            {
                this.cmbRegion.DataSource = null;
                this.cmbRegion.Items.Clear();
                this.cmbRegion.Items.Add(m_sRegionKong);
                this.cmbRegion.Text = m_sRegionKong;
            }
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            if (this.isRegionModify(0))
            {
                MessageBox.Show("请在地图上框选您要设定的区域。");
                this.wbMap.setZoomBoxExTool();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnDisplay.Dock = DockStyle.Bottom;
            this.btnTool.Dock = DockStyle.Bottom;
            this.btnTool.SendToBack();
            this.btnSetRegion.Visible = true;
            this.btnRectangle.Visible = true;
            this.btnCircle.Visible = true;
            this.btnPreviewDel.Visible = false;
            this.btnMove.Visible = false;
            this.btnZoomIn.Visible = false;
            this.btnZoonOut.Visible = false;
        }

        private void btnSetRegion_Click(object sender, EventArgs e)
        {
            if (this.isRegionModify(1))
            {
                MessageBox.Show("请首先在地图上点击您要设定的区域，鼠标双击结束设置。");
                this.wbMap.setRegionTool();
            }
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnDisplay.Dock = DockStyle.Top;
            this.btnTool.Dock = DockStyle.Top;
            this.btnDisplay.SendToBack();
            this.btnSet.SendToBack();
            this.btnSetRegion.Visible = false;
            this.btnRectangle.Visible = false;
            this.btnCircle.Visible = false;
            this.btnPreviewDel.Visible = false;
            this.btnMove.Visible = true;
            this.btnZoomIn.Visible = true;
            this.btnZoonOut.Visible = true;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomUpTool();
            this.setModifyUiState(false);
        }

        private void btnZoonOut_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomDownTool();
            this.setModifyUiState(false);
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.wbMap.execClearAllPolygon();
            if ((this.cmbRegion.Text != m_sRegionKong) && (this.cmbRegion.Text != ""))
            {
                string str = this.cmbRegion.SelectedValue.ToString();
                string sLongitude = "";
                string sLatitude = "";
                string circleName = "";
                string[] strArray = str.Trim(new char[] { '*' }).Split(new char[] { '*' });
                if (strArray.Length == 1)
                {
                    this.currentRegionType = 2;
                }
                else if (strArray.Length == 4)
                {
                    this.currentRegionType = 0;
                }
                else
                {
                    this.currentRegionType = 1;
                }
                if (strArray.Length == 1)
                {
                    try
                    {
                        circleName = this.cmbRegion.Text;
                        string[] strArray2 = strArray[0].Split(new char[] { '\\' });
                        double centerPointX = double.Parse(strArray2[0]);
                        double centerPointY = double.Parse(strArray2[1]);
                        int radius = int.Parse(strArray2[2]);
                        this.wbMap.showCircle(circleName, centerPointX, centerPointY, radius);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    if (strArray.Length == 2)
                    {
                        string[] strArray3 = str.Trim(new char[] { '*' }).Replace(@"\", "*").Split(new char[] { '*' });
                        string str5 = strArray[0] + "*";
                        string str6 = (str5 + strArray3[0] + @"\" + strArray3[3] + "*") + strArray[1] + "*";
                        str = str6 + strArray3[2] + @"\" + strArray3[1] + "*";
                    }
                    string[] strArray4 = str.Trim(new char[] { '*' }).Replace(@"\", "*").Split(new char[] { '*' });
                    if (strArray4.Length > 1)
                    {
                        circleName = this.cmbRegion.Text;
                        int num4 = strArray4.Length / 2;
                        for (int i = 0; i < num4; i++)
                        {
                            sLongitude = sLongitude + strArray4[i * 2] + ",";
                            sLatitude = sLatitude + strArray4[(i * 2) + 1] + ",";
                        }
                        sLongitude = sLongitude.Trim(new char[] { ',' });
                        sLatitude = sLatitude.Trim(new char[] { ',' });
                        object[] objArray = new object[] { circleName, sLongitude, sLatitude, true };
                        this.wbMap.showpolygonForCS(circleName, sLongitude, sLatitude, true);
                    }
                }
            }
        }

 private void execRefRegion(string sPoints)
        {
            m2mMapPath path = new m2mMapPath(this.preType) {
                PathDot = sPoints
            };
            if (this.isModify)
            {
                path.PathId = (this.cmbRegion.SelectedItem as DataRowView)["RegionId"].ToString();
                path.PathName = (this.cmbRegion.SelectedItem as DataRowView)["RegionName"].ToString();
                path.PathGroupID = (this.cmbRegion.SelectedItem as DataRowView)["pathGroupID"].ToString();
                path.IsUpdate = true;
            }
            if ((path.ShowDialog() == DialogResult.OK) && this.pnlRegion.Visible)
            {
                DataTable dataSource = (DataTable) this.cmbRegion.DataSource;
                if (this.isModify)
                {
                    DataRow row = dataSource.Rows.Find(path.PathId);
                    if (row != null)
                    {
                        row["RegionDot"] = path.PathDot;
                        row["RegionName"] = path.PathName;
                        row["pathGroupID"] = path.PathGroupID;
                    }
                    this.btnModifyRegion_Click(null, null);
                }
                else
                {
                    DataRow row2 = dataSource.NewRow();
                    row2["regionID"] = path.PathId;
                    row2["regionName"] = path.PathName;
                    row2["regionDot"] = path.PathDot;
                    row2["pathGroupID"] = path.PathGroupID;
                    dataSource.Rows.Add(row2);
                    this.cmbRegion.SelectedIndex = this.cmbRegion.Items.Count - 1;
                }
            }
        }

 private bool isRegionModify(int type)
        {
            if (!this.isModify || (type == this.currentRegionType))
            {
                return true;
            }
            string str = "";
            if (this.currentRegionType == 0)
            {
                str = "矩形区域";
            }
            else if (this.currentRegionType == 1)
            {
                str = "多边形区域";
            }
            else if (this.currentRegionType == 2)
            {
                str = "圆形区域";
            }
            MessageBox.Show("当前区域类型只能修改为" + str);
            return false;
        }

        private void itmPreSetRegion_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void itmPreSetRegion_Load(object sender, EventArgs e)
        {
            Point point = new Point((this.wbMap.Location.X + this.wbMap.Width) / 2, ((this.wbMap.Location.Y + this.wbMap.Height) / 2) - 17);
            this.picLoadMap.Location = point;
            this.picLoadMap.Visible = true;
            this.pnlSetRegion.Enabled = false;
            this.wbMap.Url = new Uri(Variable.MapUrl);
            this.Text = this.preType.ToString();
        }

        private void setModifyUiState(bool isModifys)
        {
            if (isModifys)
            {
                this.btnModifyRegion.Text = "取消修改";
                this.wbMap.execClearAllPolygon();
            }
            else
            {
                this.btnModifyRegion.Text = "修改区域";
                this.cmbRegion_SelectedIndexChanged(null, null);
            }
            this.isModify = isModifys;
            this.btnDelRegion.Enabled = this.cmbRegion.Enabled = this.btnPreviewDel.Enabled = !isModifys;
        }

        private void wbMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                //this.wbMap.Document.Window.Error += (sender1, e1) => (e1.Handled = true);
                this.wbMap.Document.Window.Error += (sender1, e1) => { e1.Handled = true; };
                if (this.wbMap.Url.ToString().Equals("about:blank"))
                {
                    this.picLoadMap.Visible = false;
                    return;
                }
                if (this.wbMap.Document.GetElementById("map") == null)
                {
                    this.picLoadMap.Visible = false;
                    this.wbMap.Url = new Uri("about:blank");
                    MessageBox.Show("地图初始化失败！");
                    Record.execFileRecord("加载地图", "地图初始化失败！");
                    return;
                }
                this.wbMap.setMap(MainForm.myMap.getMapView());
                this.pnlSetRegion.Enabled = true;
            }
            catch
            {
                this.picLoadMap.Visible = false;
            }
            this.picLoadMap.Visible = false;
        }

        private void wbMap_DoubleClick(object sender, HtmlElementEventArgs e)
        {
            object obj2 = this.wbMap.getMapClicked();
            if (((obj2 != null) && bool.Parse(obj2.ToString())) && (this.wbMap.m_sTool == GisMap.MapTool.设置区域))
            {
                try
                {
                    string str = this.wbMap.getSketchPoints().ToString().Trim(new char[] { ';' });
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] strArray = str.Split(new char[] { ';' });
                        if ((strArray.Length >= 2) && ((strArray.Length != 2) || (strArray[0] != strArray[1])))
                        {
                            this.execRefRegion(str);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("预设区域", exception.Message);
                }
            }
        }

        private void wbMap_MouseUp(object sender, HtmlElementEventArgs e)
        {
            object obj2 = this.wbMap.getMapClicked();
            if ((obj2 != null) && bool.Parse(obj2.ToString()))
            {
                GisMap.MapTool sTool = this.wbMap.m_sTool;
                if (sTool != GisMap.MapTool.设置矩形区域)
                {
                    if (sTool != GisMap.MapTool.设置圆形区域)
                    {
                        return;
                    }
                }
                else
                {
                    try
                    {
                        string str = this.wbMap.getZoomBoxPoints().ToString().Trim(new char[] { ';' });
                        if (!string.IsNullOrEmpty(str))
                        {
                            string[] strArray = str.Split(new char[] { ';' });
                            if ((strArray.Length >= 2) && ((strArray.Length != 2) || (strArray[0] != strArray[1])))
                            {
                                string[] strArray2 = str.Replace(";", ",").Split(new char[] { ',' });
                                str = strArray[0] + ";";
                                str = ((str + strArray2[0] + "," + strArray2[3] + ";") + strArray[1] + ";") + strArray2[2] + "," + strArray2[1];
                                this.execRefRegion(str);
                            }
                        }
                    }
                    catch
                    {
                    }
                    return;
                }
                try
                {
                    string str2 = this.wbMap.getCurrentPoint().ToString().Trim(new char[] { ';' });
                    if (!string.IsNullOrEmpty(str2))
                    {
                        string[] strArray3 = str2.Split(new char[] { ';' });
                        if (strArray3.Length <= 2)
                        {
                            str2 = strArray3[0] + "," + strArray3[1];
                            this.execRefRegion(str2);
                        }
                    }
                }
                catch
                {
                }
            }
        }
    }
}

