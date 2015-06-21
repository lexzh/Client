namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmPreSetPath : SizableForm
    {
        private Dictionary<string, string> cachSegment = new Dictionary<string, string>();
        private BindingSource m_segmentsSource = new BindingSource();
        private static string m_sPathKong = "(无)";
        private string remark = "";

        public itmPreSetPath(PreType type)
        {
            this.InitializeComponent();
            this.preType = type;
        }

        private void addCachSegmentToDt(string pathid)
        {
            DataRow[] rowArray = this.m_segmentsDt.Select("Pathid='" + pathid + "'");
            if ((rowArray != null) && (rowArray.Length > 0))
            {
                for (int i = 0; i < rowArray.Length; i++)
                {
                    this.m_segmentsDt.Rows.Remove(rowArray[i]);
                }
            }
            foreach (KeyValuePair<string, string> pair in this.cachSegment)
            {
                this.addPathSegments(pathid, pair.Key, pair.Value, "");
            }
        }

        private void addPathSegments(string pathid, string PathSegmentName, string alarmSegmentDot, string PathSegmentID)
        {
            DataRow row = this.m_segmentsDt.NewRow();
            row["PathID"] = pathid;
            row["PathSegmentName"] = PathSegmentName;
            row["alarmSegmentDot"] = alarmSegmentDot.Replace(",", "*").Replace(";", "/");
            row["PathSegmentID"] = 0;
            this.m_segmentsDt.Rows.Add(row);
        }

        private void btnAddSegment_Click(object sender, EventArgs e)
        {
            if (this.cachSegment.ContainsKey(this.txtSegment.Text.Trim()))
            {
                MessageBox.Show("已存在该路段名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                try
                {
                    object obj2 = this.wbMap.getLineCoordStr();
                    if ((obj2 != null) && (obj2.ToString().Length > 0))
                    {
                        if (this.cachSegment.ContainsValue(obj2.ToString()))
                        {
                            MessageBox.Show("该路段已存在，请添加新的路段!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        this.grpSegment.Tag = obj2;
                    }
                    else
                    {
                        MessageBox.Show("请在地图上添加路段!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.cachSegment[this.txtSegment.Text.Trim()] = this.grpSegment.Tag.ToString();
                    this.setSegmentControlState(false);
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("路线添加路段", exception.Message);
                }
            }
        }

        private void btnCancelAddSegment_Click(object sender, EventArgs e)
        {
            this.setSegmentControlState(false);
        }

        private void btnDelPath_Click(object sender, EventArgs e)
        {
            string text = this.cmbPath.Text;
            if (text == m_sPathKong)
            {
                MessageBox.Show("没有路线");
            }
            else if (MessageBox.Show(string.Format("您确认要删除路线{0}吗？", text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!RemotingClient.Alarm_DelPathCheckAuth(-1, text))
                {
                    MessageBox.Show(string.Format("您无权限删除路线{0}!", text));
                }
                else if (RemotingClient.Alarm_DelPath(-1, text) < 0)
                {
                    MessageBox.Show("路线删除失败");
                }
                else
                {
                    DataTable dataSource = (DataTable) this.cmbPath.DataSource;
                    foreach (DataRow row in dataSource.Select(string.Format("PathName='{0}'", text)))
                    {
                        dataSource.Rows.Remove(row);
                        if (this.cmbPath.SelectedItem != null)
                        {
                            this.delPathSegments(((DataRowView) this.cmbPath.SelectedItem)["Pathid"].ToString());
                        }
                        if (dataSource.Rows.Count > 0)
                        {
                            this.cmbPath_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            this.cmbPath.DataSource = null;
                            this.cmbPath.Items.Clear();
                            this.cmbPath.Items.Add(m_sPathKong);
                            this.cmbPath.Text = m_sPathKong;
                        }
                    }
                }
            }
        }

        private void btnDelPoint_Click(object sender, EventArgs e)
        {
            this.wbMap.setDelPoint();
            this.SetMapContextMenu(false);
            this.clearCachSegment();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnDisplay.Dock = DockStyle.Top;
            this.btnTool.Dock = DockStyle.Bottom;
            this.btnSet.SendToBack();
            this.btnSetPath.Visible = false;
            this.btnSetPathSTD.Visible = false;
            this.btnPreviewDel.Visible = true;
            this.btnMove.Visible = false;
            this.btnZoomIn.Visible = false;
            this.btnZoonOut.Visible = false;
            this.btnDistance.Visible = false;
            this.btnDelPoint.Visible = false;
        }

        private void btnDistance_Click(object sender, EventArgs e)
        {
            this.wbMap.setMeasureTool();
            this.SetMapContextMenu(false);
            this.clearCachSegment();
        }

        private void btnModifyPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPath.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择路线!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (this.isUpdate)
                {
                    this.wbMap.setPanTool();
                    this.setUpdateUIState(false);
                }
                else
                {
                    this.clearCachSegment();
                    this.setUpdateUIState(true);
                    if (MessageBox.Show("是否只修改名称(不重新设置路线经纬度)!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.cmbPathSegments.Items.Count > 0)
                        {
                            for (int i = 0; i < this.cmbPathSegments.Items.Count; i++)
                            {
                                string str = (this.cmbPathSegments.Items[i] as DataRowView)["alarmSegmentDot"].ToString().Replace("*", ",").Replace("/", ";");
                                string str2 = (this.cmbPathSegments.Items[i] as DataRowView)["PathSegmentName"].ToString();
                                this.cachSegment[str2] = str;
                            }
                        }
                        this.modifyPath((DataRowView) this.cmbPath.SelectedItem, this.cmbPath.SelectedValue.ToString().Replace("*", ",").Replace("/", ";").Trim(new char[] { ';' }), false, false);
                    }
                    else
                    {
                        this.btnSetPath_Click(sender, e);
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("预设路线-->修改", exception.Message);
                this.clearCachSegment();
                this.setUpdateUIState(false);
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            this.wbMap.setPanTool();
            this.SetMapContextMenu(false);
            this.clearCachSegment();
        }

        private void btnPreviewDel_Click(object sender, EventArgs e)
        {
            this.pnlRegion.Visible = true;
            DataTable table = RemotingClient.Alarm_GetPathInfo();
            this.m_segmentsDt = RemotingClient.Alarm_GetPathSegmentInfo();
            this.m_segmentsSource.DataSource = this.m_segmentsDt;
            if (this.m_segmentsDt != null)
            {
                foreach (DataColumn column in this.m_segmentsDt.Columns)
                {
                    column.ReadOnly = false;
                }
            }
            if (table != null)
            {
                foreach (DataColumn column2 in table.Columns)
                {
                    column2.ReadOnly = false;
                }
            }
            DataColumn column3 = new DataColumn("PathNamePy");
            table.Columns.Add(column3);
            if (table != null)
            {
                int count = table.Rows.Count;
            }
            table.DefaultView.Sort = "PathName Asc";
            if ((table != null) && (table.Rows.Count > 0))
            {
                this.cmbPath.DataSource = table;
                this.cmbPath.SelectedIndex = 0;
            }
            else
            {
                this.cmbPath.DataSource = null;
                this.cmbPath.Items.Clear();
                this.cmbPath.Items.Add(m_sPathKong);
                this.cmbPath.Text = m_sPathKong;
            }
            this.SetMapContextMenu(false);
            this.wbMap.setPanTool();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.wbMap.Refresh();
            this.SetMapContextMenu(false);
            this.clearCachSegment();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnDisplay.Dock = DockStyle.Bottom;
            this.btnTool.Dock = DockStyle.Bottom;
            this.btnTool.SendToBack();
            this.btnSetPath.Visible = true;
            this.btnSetPathSTD.Visible = true;
            this.btnPreviewDel.Visible = false;
            this.btnMove.Visible = false;
            this.btnZoomIn.Visible = false;
            this.btnZoonOut.Visible = false;
            this.btnDistance.Visible = false;
            this.btnDelPoint.Visible = false;
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            this.wbMap.execClearAllPath();
            MessageBox.Show("请首先在地图上点击您要设定的路线，右键可添加路段，鼠标双击结束设置。");
            this.wbMap.setPathTool();
            this.SetMapContextMenu(true);
        }

        private void btnSetPathSTD_Click(object sender, EventArgs e)
        {
            this.wbMap.setPanTool();
            this.wbMap.setPathToolSTD();
            this.wbMap.execClearAllPath();
            this.wbMap.ContextMenuStrip = null;
            this.clearCachSegment();
            MessageBox.Show("请首先通过导航栏设置起点和终点再点击导航结束设置。");
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnDisplay.Dock = DockStyle.Top;
            this.btnTool.Dock = DockStyle.Top;
            this.btnDisplay.SendToBack();
            this.btnSet.SendToBack();
            this.btnSetPath.Visible = false;
            this.btnSetPathSTD.Visible = false;
            this.btnPreviewDel.Visible = false;
            this.btnMove.Visible = true;
            this.btnZoomIn.Visible = true;
            this.btnZoonOut.Visible = true;
            this.btnDistance.Visible = true;
            this.btnDelPoint.Visible = true;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomUpTool();
            this.SetMapContextMenu(false);
            this.clearCachSegment();
        }

        private void btnZoonOut_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomDownTool();
            this.SetMapContextMenu(false);
            this.clearCachSegment();
        }

        private void clearCachSegment()
        {
            this.cachSegment.Clear();
        }

        private void cmbPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.wbMap.execClearAllPath();
            if ((this.cmbPath.Text != m_sPathKong) && (this.cmbPath.Text != ""))
            {
                string str = this.cmbPath.SelectedValue.ToString();
                string sLongitude = "";
                string sLatitude = "";
                string sPathName = "";
                string[] strArray = str.Trim(new char[] { '/' }).Replace("*", "/").Split(new char[] { '/' });
                if (strArray.Length > 1)
                {
                    sPathName = this.cmbPath.Text;
                    int num = strArray.Length / 2;
                    for (int i = 0; i < num; i++)
                    {
                        sLongitude = sLongitude + strArray[i * 2] + ",";
                        sLatitude = sLatitude + strArray[(i * 2) + 1] + ",";
                    }
                    sLongitude = sLongitude.Trim(new char[] { ',' });
                    sLatitude = sLatitude.Trim(new char[] { ',' });
                    if (this.cmbPath.SelectedItem != null)
                    {
                        try
                        {
                            this.cmbPathSegmentBindData(((DataRowView) this.cmbPath.SelectedItem)["Pathid"].ToString());
                            this.remark = ((DataRowView) this.cmbPath.SelectedItem)["remark"].ToString();
                        }
                        catch (Exception exception)
                        {
                            Record.execFileRecord("预设路线", exception.Message);
                        }
                    }
                    this.wbMap.execShowPath(sPathName, sLongitude, sLatitude, true);
                    if (this.cmbPathSegments.Items.Count > 0)
                    {
                        this.wbMap.execClearAllPath();
                        for (int j = 0; j < this.cmbPathSegments.Items.Count; j++)
                        {
                            DataRow row = (this.cmbPathSegments.Items[j] as DataRowView).Row;
                            string[] strArray2 = row["alarmSegmentDot"].ToString().Trim(new char[] { '/' }).Replace("*", "/").Split(new char[] { '/' });
                            if (strArray2.Length <= 1)
                            {
                                return;
                            }
                            sPathName = row["pathSegmentName"].ToString();
                            sLongitude = sLatitude = "";
                            int num4 = strArray2.Length / 2;
                            for (int k = 0; k < num4; k++)
                            {
                                sLongitude = sLongitude + strArray2[k * 2] + ",";
                                sLatitude = sLatitude + strArray2[(k * 2) + 1] + ",";
                            }
                            sLongitude = sLongitude.Trim(new char[] { ',' });
                            sLatitude = sLatitude.Trim(new char[] { ',' });
                            this.wbMap.execShowPath(sPathName, sLongitude, sLatitude, false);
                        }
                    }
                }
            }
        }

        private void cmbPathSegmentBindData(string pathid)
        {
            if (this.m_segmentsDt != null)
            {
                this.m_segmentsSource.Filter = "PathID = '" + pathid + "'";
                this.m_segmentsSource.Sort = "PathSegmentName Asc";
                this.cmbPathSegments.DataSource = this.m_segmentsSource;
            }
        }

        private void delPathSegments(string pathid)
        {
            this.m_segmentsSource.Filter = "Pathid='" + pathid + "'";
            for (int i = 0; i < this.m_segmentsSource.List.Count; i++)
            {
                this.m_segmentsSource.Remove(this.m_segmentsSource.List[i]);
            }
        }

 private void itmPreSetPath_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void itmPreSetPath_Load(object sender, EventArgs e)
        {
            new Point((this.wbMap.Location.X + this.wbMap.Width) / 2, ((this.wbMap.Location.Y + this.wbMap.Height) / 2) - 17);
            this.picLoadMap.Visible = true;
            this.pnlSetRegion.Enabled = false;
            this.wbMap.Url = new Uri(Variable.MapUrl);
            this.Text = this.preType.ToString();
        }

        private void MenuItem撤销路线_Click(object sender, EventArgs e)
        {
            this.wbMap.setPathRemoveLastSection();
        }

        private void MenuItem添加路段_Click(object sender, EventArgs e)
        {
            this.setSegmentControlState(true);
        }

        private void modifyPath(DataRowView selectItemDataRowView, string pathdot, bool isNewPathDot, bool isMapDirection)
        {
            MapPath path = new MapPath(this.preType) {
                IsMapDirection = isMapDirection,
                IsUpdate = true,
                PathLonLatChange = isNewPathDot,
                PathId = selectItemDataRowView["Pathid"].ToString(),
                PathName = selectItemDataRowView["PathName"].ToString(),
                PathDot = pathdot,
                PathSegment = this.cachSegment,
                ReMark = this.remark,
                BeginName = selectItemDataRowView["factoryName"].ToString(),
                EndName = selectItemDataRowView["buildingSitName"].ToString(),
                Group = selectItemDataRowView["pathGroupID"].ToString(),
                PathType = selectItemDataRowView["pathType"].ToString(),
                Radius = selectItemDataRowView["region_radius"].ToString().Equals("") ? 300M : Convert.ToDecimal(selectItemDataRowView["region_radius"])
            };
            if (path.ShowDialog() == DialogResult.OK)
            {
                if (isNewPathDot)
                {
                    this.addCachSegmentToDt(path.PathId);
                }
                if (this.pnlRegion.Visible)
                {
                    DataRow row = selectItemDataRowView.Row;
                    row["PathName"] = path.PathName;
                    row["AlarmPathDot"] = path.PathDot;
                    row["Remark"] = path.ReMark;
                    row["region_radius"] = path.Radius;
                    row["factoryName"] = path.BeginName;
                    row["buildingSitName"] = path.EndName;
                    row["pathGroupID"] = path.Group;
                    row["pathType"] = path.PathType;
                }
            }
            this.clearCachSegment();
            this.cmbPath_SelectedIndexChanged(null, null);
            this.wbMap.setPanTool();
            this.setUpdateUIState(false);
        }

        private void searchPathName()
        {
            if (this.cmbPath.Items.Count > 0)
            {
                DataView defaultView = (this.cmbPath.DataSource as DataTable).DefaultView;
                bool flag = false;
                int num = (this.cmbPath.SelectedIndex == (this.cmbPath.Items.Count - 1)) ? 0 : (this.cmbPath.SelectedIndex + 1);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = num; j < defaultView.Count; j++)
                    {
                        if ((defaultView[j]["PathName"].ToString().IndexOf(this.txtSearch.Text, 0, StringComparison.OrdinalIgnoreCase) >= 0) || (defaultView[j]["PathNamePy"].ToString().IndexOf(this.txtSearch.Text, 0, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            flag = true;
                            this.cmbPath.SelectedIndex = j;
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                    flag = true;
                    num = 0;
                }
            }
        }

        private void SetMapContextMenu(bool isadd)
        {
            if (isadd)
            {
                this.wbMap.ContextMenuStrip = this.mapMenu;
            }
            else
            {
                this.wbMap.ContextMenuStrip = null;
                this.clearCachSegment();
                this.setUpdateUIState(false);
            }
        }

        private void setSegmentControlState(bool isshow)
        {
            if (isshow)
            {
                this.grpSegment.Visible = true;
                this.grpSegment.BringToFront();
            }
            else
            {
                this.grpSegment.Visible = false;
                this.txtSegment.Text = "";
                this.grpSegment.SendToBack();
            }
        }

        private void setUpdateUIState(bool isupdate)
        {
            if (!isupdate)
            {
                this.cmbPath_SelectedIndexChanged(null, null);
            }
            this.btnModifyPath.Text = isupdate ? "取消修改" : "修改路线";
            this.isUpdate = isupdate;
            this.cmbPath.Enabled = this.btnDelPath.Enabled = !isupdate;
        }

        private void txtSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.searchPathName();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.searchPathName();
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
            if (((obj2 != null) && bool.Parse(obj2.ToString())) && (this.wbMap.m_sTool == GisMap.MapTool.设置路线))
            {
                try
                {
                    string str = this.wbMap.getSketchPoints().ToString().Trim(new char[] { ';' });
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] strArray = str.Split(new char[] { ';' });
                        if ((strArray.Length >= 2) && ((strArray.Length != 2) || (strArray[0] != strArray[1])))
                        {
                            if (!this.isUpdate)
                            {
                                MapPath path = new MapPath(this.preType) {
                                    PathDot = str,
                                    PathSegment = this.cachSegment,
                                    ReMark = ""
                                };
                                if (path.ShowDialog() == DialogResult.OK)
                                {
                                    this.addCachSegmentToDt(path.PathId);
                                    if (this.pnlRegion.Visible)
                                    {
                                        DataTable dataSource = (DataTable) this.cmbPath.DataSource;
                                        DataRow row = dataSource.NewRow();
                                        row["PathId"] = path.PathId;
                                        row["PathName"] = path.PathName;
                                        row["AlarmPathDot"] = path.PathDot;
                                        row["Remark"] = path.ReMark;
                                        row["region_radius"] = path.Radius;
                                        row["factoryName"] = path.BeginName;
                                        row["buildingSitName"] = path.EndName;
                                        row["pathGroupID"] = path.Group;
                                        row["pathType"] = path.PathType;
                                        dataSource.Rows.Add(row);
                                        this.cmbPath.SelectedIndex = dataSource.DefaultView.Find(path.PathName);
                                    }
                                }
                                else
                                {
                                    this.cmbPath_SelectedIndexChanged(sender, e);
                                }
                                this.clearCachSegment();
                                this.wbMap.setPanTool();
                            }
                            else
                            {
                                this.modifyPath((DataRowView) this.cmbPath.SelectedItem, str, true, false);
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void wbMap_MapDirectionEvent(object sender, HtmlElementEventArgs e)
        {
            try
            {
                string str = this.wbMap.getSketchPoints().ToString().Trim(new char[] { ';' });
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray = str.Split(new char[] { ';' });
                    if ((strArray.Length >= 2) && ((strArray.Length != 2) || (strArray[0] != strArray[1])))
                    {
                        if (!this.isUpdate)
                        {
                            MapPath path = new MapPath(this.preType) {
                                PathDot = str
                            };
                            this.cachSegment["路段"] = str;
                            path.IsMapDirection = true;
                            path.PathSegment = this.cachSegment;
                            path.ReMark = "";
                            if (path.ShowDialog() == DialogResult.OK)
                            {
                                this.addCachSegmentToDt(path.PathId);
                                if (this.pnlRegion.Visible)
                                {
                                    DataTable dataSource = (DataTable) this.cmbPath.DataSource;
                                    DataRow row = dataSource.NewRow();
                                    row["PathId"] = path.PathId;
                                    row["PathName"] = path.PathName;
                                    row["AlarmPathDot"] = path.PathDot;
                                    row["Remark"] = path.ReMark;
                                    row["region_radius"] = path.Radius;
                                    row["factoryName"] = path.BeginName;
                                    row["buildingSitName"] = path.EndName;
                                    row["pathGroupID"] = path.Group;
                                    row["pathType"] = path.PathType;
                                    dataSource.Rows.Add(row);
                                    this.cmbPath.SelectedIndex = dataSource.DefaultView.Find(path.PathName);
                                }
                            }
                            else
                            {
                                this.cmbPath_SelectedIndexChanged(sender, e);
                            }
                            this.clearCachSegment();
                        }
                        else
                        {
                            this.modifyPath((DataRowView) this.cmbPath.SelectedItem, str, true, true);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public enum PreType
        {
            预设报警区域,
            预设多功能报警区域,
            预设报警路线
        }
    }
}

