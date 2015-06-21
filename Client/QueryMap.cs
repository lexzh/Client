namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class QueryMap : SizableForm
    {
        public int m_iRegionType;

        public QueryMap(int iRegionType)
        {
            this.InitializeComponent();
            this.m_iRegionType = iRegionType;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            this.wbMap.setPanTool();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            this.pnlRadius.Enabled = false;
            MessageBox.Show("请在地图上框选您要设定的区域。");
            this.wbMap.setZoomBoxExTool();
            this.m_iRegionType = 2;
            this.wbMap.execClearAllPolygon();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnTool.Dock = DockStyle.Bottom;
            this.btnTool.SendToBack();
            this.btnRectangle.Visible = true;
            this.btnSetCircle.Visible = true;
            this.btnMove.Visible = false;
            this.btnZoomIn.Visible = false;
            this.btnZoonOut.Visible = false;
            this.pnlRadius.Visible = true;
            if (this.m_iRegionType == 1)
            {
                this.btnSetCircle.Select();
                this.pnlRadius.Enabled = true;
            }
            else
            {
                this.btnRectangle.Select();
                this.pnlRadius.Enabled = false;
            }
        }

        private void btnSetCircle_Click(object sender, EventArgs e)
        {
            this.pnlRadius.Visible = true;
            this.pnlRadius.Enabled = true;
            MessageBox.Show("请在地图上点击圆形中心，并在左下方设置圆形半径。");
            this.wbMap.setCircleTool();
            this.m_iRegionType = 1;
            this.wbMap.execClearAllPolygon();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((this.Latitude1 == null) || (this.Longitude1 == null))
            {
                MessageBox.Show("请先设置矩形区域或圆形区域！");
            }
            else
            {
                if (this.m_iRegionType == 1)
                {
                    if (string.IsNullOrEmpty(this.numRadius.Value.ToString()))
                    {
                        MessageBox.Show("半径不能为空，请重新设置");
                        this.numRadius.Focus();
                        return;
                    }
                    this._iRadius = (int) this.numRadius.Value;
                    if (this.Radius == 0)
                    {
                        MessageBox.Show("半径不能为空，请重新设置");
                        this.numRadius.Focus();
                        return;
                    }
                }
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            this.btnSet.Dock = DockStyle.Top;
            this.btnTool.Dock = DockStyle.Top;
            this.btnSet.SendToBack();
            this.btnRectangle.Visible = false;
            this.btnSetCircle.Visible = false;
            this.btnMove.Visible = true;
            this.btnZoomIn.Visible = true;
            this.btnZoonOut.Visible = true;
            this.pnlRadius.Visible = false;
        }

        private void btnZoomDown_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomDownTool();
        }

        private void btnZoomUp_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomUpTool();
        }

 private void execMapChangeBaseLayer(string sText, string sValue)
        {
            this.wbMap.execMapChangeBaseLayer(sText, sValue);
        }

        private void GetCircle()
        {
            try
            {
                string str = this.wbMap.getCurrentPoint().ToString().Trim(new char[] { ';' });
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray = str.Split(new char[] { ';' });
                    if (strArray.Length <= 2)
                    {
                        this._dLon1 = strArray[0];
                        this._dLat1 = strArray[1];
                        this._dLon1 = this._dLon1.Substring(0, this._dLon1.IndexOf('.') + 7);
                        this._dLat1 = this._dLat1.Substring(0, this._dLat1.IndexOf('.') + 7);
                        this.wbMap.execClearAllPolygon();
                        this.numRadius.Focus();
                        this._iRadius = (int) this.numRadius.Value;
                        this.wbMap.showCircle("圆形区域", double.Parse(this.Longitude1), double.Parse(this.Latitude1), this.Radius);
                    }
                }
            }
            catch
            {
            }
        }

        private void GetZoomBox()
        {
            try
            {
                string str = this.wbMap.getZoomBoxPoints().ToString().Trim(new char[] { ';' });
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray = str.Split(new char[] { ';' });
                    if ((strArray.Length >= 2) && ((strArray.Length != 2) || (strArray[0] != strArray[1])))
                    {
                        this._dLon1 = strArray[0].Split(new char[] { ',' })[0];
                        this._dLat1 = strArray[0].Split(new char[] { ',' })[1];
                        this._dLon2 = strArray[1].Split(new char[] { ',' })[0];
                        this._dLat2 = strArray[1].Split(new char[] { ',' })[1];
                        this._dLon1 = this._dLon1.Substring(0, this._dLon1.IndexOf('.') + 7);
                        this._dLon2 = this._dLon2.Substring(0, this._dLon2.IndexOf('.') + 7);
                        this._dLat1 = this._dLat1.Substring(0, this._dLat1.IndexOf('.') + 7);
                        this._dLat2 = this._dLat2.Substring(0, this._dLat2.IndexOf('.') + 7);
                        string sLongitude = this._dLon1 + "," + this._dLon1 + "," + this._dLon2 + "," + this._dLon2;
                        string sLatitude = this._dLat1 + "," + this._dLat2 + "," + this._dLat2 + "," + this._dLat1;
                        this.wbMap.execClearAllPolygon();
                        this.wbMap.showpolygonForCS("矩形区域", sLongitude, sLatitude, true);
                    }
                }
            }
            catch
            {
            }
        }

        private void gisMap1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.wbMap.Url.ToString().Equals("about:blank"))
            {
                this.picLoadMap.Visible = false;
                this.isClose = true;
            }
            else if (this.wbMap.Document.GetElementById("map") == null)
            {
                this.picLoadMap.Visible = false;
                this.isClose = true;
                this.wbMap.Url = new Uri("about:blank");
                MessageBox.Show("地图初始化失败！");
                Record.execFileRecord("加载地图", "地图初始化失败！");
            }
            else if (this.wbMap.getMapList() == null)
            {
                this.picLoadMap.Visible = false;
                this.isClose = true;
            }
            else
            {
                this.wbMap.setMap(MainForm.myMap.getMapView());
                this.isClose = false;
                this.picLoadMap.Visible = false;
                this.btnSumit.Enabled = true;
                this.btnSet.Enabled = true;
                this.btnTool.Enabled = true;
                this.pnlHandle.Enabled = true;
            }
        }

 private void QueryMap_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void QueryMap_Load(object sender, EventArgs e)
        {
            Point point = new Point((this.wbMap.Width / 2) - 85, (this.wbMap.Height / 2) - 17);
            this.picLoadMap.Location = point;
            this.picLoadMap.Visible = true;
            this.pnlHandle.Enabled = false;
            this.btnSumit.Enabled = false;
            this.btnSet.Enabled = false;
            this.btnTool.Enabled = false;
            this.isClose = true;
            this.wbMap.Url = new Uri(Variable.MapUrl);
            this.pnlRadius.Visible = true;
            if (this.m_iRegionType == 1)
            {
                this.btnSetCircle.Select();
                this.pnlRadius.Enabled = true;
            }
            else
            {
                this.btnRectangle.Select();
                this.pnlRadius.Enabled = false;
            }
        }

        private void wbMap_MapMouseUp(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
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
                        this.GetZoomBox();
                        return;
                    }
                    this.GetCircle();
                }
            }
        }

        public string Latitude1
        {
            get
            {
                return this._dLat1;
            }
        }

        public string Latitude2
        {
            get
            {
                return this._dLat2;
            }
        }

        public string Longitude1
        {
            get
            {
                return this._dLon1;
            }
        }

        public string Longitude2
        {
            get
            {
                return this._dLon2;
            }
        }

        public int Radius
        {
            get
            {
                return this._iRadius;
            }
        }
    }
}

