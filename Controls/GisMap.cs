namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public partial class GisMap : WebBrowser
    {
        public MapTool m_sTool;

        public event HtmlElementEventHandler MapDirectionEvent;

        public event HtmlElementEventHandler MapDoubleClick;

        public event HtmlElementEventHandler MapEndSelectSpace;

        public event HtmlElementEventHandler MapMouseMove;

        public event HtmlElementEventHandler MapMouseUp;

        public event HtmlElementEventHandler MapSelectedCarEvent;

        public event HtmlElementEventHandler MapSpatialEvent;

        public GisMap()
        {
            this.InitializeComponent();
            this.MapMouseUp = new HtmlElementEventHandler(this.MouseUp);
            this.MapMouseMove = new HtmlElementEventHandler(this.MouseMove);
            this.MapDoubleClick = new HtmlElementEventHandler(this.DoubleClick);
            this.MapEndSelectSpace = new HtmlElementEventHandler(this.EndSelectSpace);
            this.MapSpatialEvent = new HtmlElementEventHandler(this.SpatialEvent);
            this.MapDirectionEvent = new HtmlElementEventHandler(this.DirectionEvent);
            this.MapSelectedCarEvent = new HtmlElementEventHandler(this.SelectedCarEvent);
            base.IsWebBrowserContextMenuEnabled = false;
        }

        public void clearAllBusRoute()
        {
            try
            {
                base.Document.InvokeScript("clearAllBusRoute");
            }
            catch
            {
            }
        }

        public void clearAllCompany()
        {
            try
            {
                base.Document.InvokeScript("clearAllCompany");
            }
            catch
            {
            }
        }

        public void clearBestRoutePath()
        {
            try
            {
                base.Document.InvokeScript("clearBestRoutePath");
            }
            catch
            {
            }
        }

        public void closeBusRoute(string routeId)
        {
            try
            {
                object[] obj = new object[] { routeId };
                base.Document.InvokeScript("closeBusRoute", obj);
            }
            catch
            {
            }
        }

        public void execHiddenTrackPointInfo()
        {
            try
            {
                base.Document.InvokeScript("hiddenTrackPointInfo");
            }
            catch
            {
            }
        }

        public void execZoomTo(string string_0, string string_1)
        {
            try
            {
                string str = base.Document.InvokeScript("getZoom").ToString();
                HtmlDocument document = base.Document;
                object[] string0 = new object[] { str, string_0, string_1 };
                document.InvokeScript("zoomTo", string0);
            }
            catch
            {
            }
        }

        public object getEditLineCoordStr(string id)
        {
            object obj;
            try
            {
                object[] obj2 = new object[] { id };
                obj = base.Document.InvokeScript("getEditLineCoordStr", obj2);
            }
            catch
            {
                obj = null;
            }
            return obj;
        }

        public void setNodeDeleTool()
        {
            try
            {
                base.Document.InvokeScript("setNodeDeleTool");
            }
            catch
            {
            }
        }

        public void setNodeDragTool()
        {
            try
            {
                base.Document.InvokeScript("setNodeDragTool");
            }
            catch
            {
            }
        }

        public void setSmallArea_Circle()
        {
            try
            {
                base.Document.InvokeScript("setpointtool");
                this.m_sTool = GisMap.MapTool.设置圆形区域;
            }
            catch
            {
            }
        }
        
        public void showBusRoute(string routeId, string routName, string lineString, string stations, bool isZoomCenter)
        {
            try
            {
                object[] obj = new object[] { routeId, routName, lineString, stations, isZoomCenter };
                base.Document.InvokeScript("showBusRoute", obj);
            }
            catch
            {
            }
        }

        public void clearTrackTo(object sCarId, object PointNum)
        {
            try
            {
                object[] args = new object[] { sCarId, PointNum };
                base.Document.InvokeScript("clearTrackTo", args);
            }
            catch
            {
            }
        }

        public void delAllCar()
        {
            try
            {
                base.Document.InvokeScript("deleteAllCar");
            }
            catch
            {
            }
        }

        public void deleteSpatialQueryFlag()
        {
            try
            {
                base.Document.InvokeScript("deleteSpatialQueryFlag");
            }
            catch
            {
            }
        }

        private void DirectionEvent(object sender, HtmlElementEventArgs e)
        {
        }

 private void DoubleClick(object sender, HtmlElementEventArgs e)
        {
        }

        private void EndSelectSpace(object sender, HtmlElementEventArgs e)
        {
        }

        public void excuteSpatialQuery(string sLon, string sLat)
        {
            try
            {
                object[] args = new object[] { sLon, sLat };
                base.Document.InvokeScript("excuteSpatialQuery", args);
            }
            catch
            {
            }
        }

        public void excuteSpatialQueryById(string sCarId, string sLon, string sLat)
        {
            try
            {
                object[] args = new object[] { sCarId, sLon, sLat };
                base.Document.InvokeScript("excuteSpatialQueryById", args);
            }
            catch
            {
            }
        }

        public void execClearAllFlag()
        {
            try
            {
                base.Document.InvokeScript("clearallflag");
            }
            catch
            {
            }
        }

        public void execClearAllPath()
        {
            try
            {
                base.Document.InvokeScript("clearAllPath");
            }
            catch
            {
            }
        }

        public void execClearAllPolygon()
        {
            try
            {
                base.Document.InvokeScript("clearallpolygon");
            }
            catch
            {
            }
        }

        public void execClearPath(string sPathName)
        {
            try
            {
                object[] args = new object[] { sPathName };
                base.Document.InvokeScript("clearPath", args);
            }
            catch
            {
            }
        }

        public void execClearTrack(string sCarId)
        {
            try
            {
                object[] args = new object[] { sCarId };
                base.Document.InvokeScript("clearTrack", args);
            }
            catch
            {
            }
        }

        public void execDeleteCar(string sCarId)
        {
            try
            {
                object[] args = new object[] { sCarId };
                base.Document.InvokeScript("deleteCar", args);
                args = null;
            }
            catch
            {
            }
        }

        public void execDeleteFlag(object[] sFlag)
        {
            try
            {
                base.Document.InvokeScript("deleteflag", sFlag);
            }
            catch
            {
            }
        }

        public void execExcuteTrackPointQuerty(string sQueryType, string sRequesId, string sLon, string sLat)
        {
            try
            {
                object[] args = new object[] { sQueryType, sRequesId, sLon, sLat };
                base.Document.InvokeScript("excuteTrackPointQuerty", args);
            }
            catch
            {
            }
        }

        public void execExcuteTrackPointQuerty(string sQueryType, string sRequesId, string sLon, string sLat, bool IsFilterRoadInfo)
        {
            try
            {
                object[] args = new object[] { sQueryType, sRequesId, sLon, sLat, IsFilterRoadInfo };
                base.Document.InvokeScript("excuteTrackPointQuerty", args);
            }
            catch
            {
            }
        }

        public void execMapChangeBaseLayer(string sText, string sValue)
        {
            try
            {
                object[] args = new object[] { sValue, sText };
                base.Document.InvokeScript("MapChangeBaseLayer", args);
                base.Focus();
            }
            catch
            {
            }
        }

        public void execRefresh()
        {
        }

        public void execSelectSpace(string sKey)
        {
            try
            {
                object[] args = new object[] { sKey };
                base.Document.InvokeScript("excuteAttributionQuery", args);
                args = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void execShowCar(object sCarNum, object x, object y, object iDirection, object iIconType, object IsZoom, object sHintText, object iCarStatus, object iAlarmType, object bIsFill, object bAccOn, object bGpsValid, object sCarId, object bIsShowTrack)
        {
            object[] args = new object[14];
            try
            {
                args[0] = sCarNum;
                args[1] = x;
                args[2] = y;
                args[3] = iDirection;
                args[4] = iIconType;
                args[5] = IsZoom;
                args[6] = sHintText;
                args[7] = iCarStatus;
                args[8] = iAlarmType;
                args[9] = bIsFill;
                args[10] = bAccOn;
                args[11] = bGpsValid;
                args[12] = sCarId;
                args[13] = bIsShowTrack;
                base.Document.InvokeScript("showCar", args);
                args = null;
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }

        public void execShowPath(string sPathName, string sLongitude, string sLatitude, bool IsZoom)
        {
            try
            {
                object[] args = new object[] { sPathName, sLongitude, sLatitude, IsZoom };
                base.Document.InvokeScript("showpathForCS", args);
            }
            catch
            {
            }
        }

        public void execStopPlayTrackLine(string sQueryType)
        {
            try
            {
                object[] args = new object[] { sQueryType };
                base.Document.InvokeScript("stopPlayTrackLine", args);
            }
            catch
            {
            }
        }

        public void fixZoomIn()
        {
            try
            {
                if (this.m_bMouseEnter)
                {
                    base.Document.InvokeScript("fixZoomIn");
                }
            }
            catch
            {
            }
        }

        public void fixZoomOut()
        {
            try
            {
                if (this.m_bMouseEnter)
                {
                    base.Document.InvokeScript("fixZoomOut");
                }
            }
            catch
            {
            }
        }

        public object getAttributionQueryResult()
        {
            try
            {
                return base.Document.InvokeScript("getAttributionQueryResult");
            }
            catch
            {
                return null;
            }
        }

        public object getCurrentPoint()
        {
            try
            {
                return base.Document.InvokeScript("getcurrentpoint");
            }
            catch
            {
                return null;
            }
        }

        public object getFlagName()
        {
            try
            {
                object[] args = this.getCurrentPoint().ToString().Split(new char[] { ';' });
                return base.Document.InvokeScript("getflagnamebyxy", args);
            }
            catch
            {
                return null;
            }
        }

        public object getLineCoordStr()
        {
            try
            {
                return base.Document.InvokeScript("getLineCoordStr");
            }
            catch
            {
                return null;
            }
        }

        public object getMapClicked()
        {
            try
            {
                return base.Document.InvokeScript("getMapClicked");
            }
            catch
            {
                return null;
            }
        }

        public object getMapList()
        {
            try
            {
                return base.Document.InvokeScript("getMapList");
            }
            catch
            {
                return null;
            }
        }

        public string getMapView()
        {
            try
            {
                object obj2 = base.Document.InvokeScript("getMapView");
                if (obj2 != null)
                {
                    return obj2.ToString();
                }
            }
            catch
            {
            }
            return "";
        }

        public object getSelectedCarID()
        {
            try
            {
                return base.Document.InvokeScript("getCarID");
            }
            catch
            {
                return null;
            }
        }

        public object getSketchPoints()
        {
            try
            {
                return base.Document.InvokeScript("getSketchPoints");
            }
            catch
            {
                return null;
            }
        }

        public object getSpatialQueryResult()
        {
            try
            {
                return base.Document.InvokeScript("getSpatialQueryResult");
            }
            catch
            {
                return null;
            }
        }

        public object getTrackPointQueryInfo(string sQueryType)
        {
            try
            {
                object[] args = new object[] { sQueryType };
                return base.Document.InvokeScript("getTrackPointQueryInfo", args);
            }
            catch
            {
                return null;
            }
        }

        public object getZoomBoxPoints()
        {
            try
            {
                return base.Document.InvokeScript("getzoomboxpoints");
            }
            catch
            {
                return null;
            }
        }

        private void GisMap_MouseEnter(object sender, HtmlElementEventArgs e)
        {
            try
            {
                this.m_bMouseEnter = true;
            }
            catch
            {
            }
        }

        private void GisMap_MouseLeave(object sender, HtmlElementEventArgs e)
        {
            this.m_bMouseEnter = false;
        }

 public object isMapLoadedSuccess()
        {
            try
            {
                return base.Document.InvokeScript("isMapLoadedSuccess");
            }
            catch
            {
                return null;
            }
        }

        private void MouseMove(object sender, HtmlElementEventArgs e)
        {
        }

        private void MouseUp(object sender, HtmlElementEventArgs e)
        {
            base.Document.Focus();
        }

        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        {
            if ((base.ReadyState == WebBrowserReadyState.Complete) && !base.Url.ToString().Equals("about:blank"))
            {
                try
                {
                    HtmlDocument document = base.Document;
                    document.GetElementById("map").MouseUp += new HtmlElementEventHandler(this.MapMouseUp.Invoke);
                    document.GetElementById("map").MouseMove += new HtmlElementEventHandler(this.MapMouseMove.Invoke);
                    document.GetElementById("map").DoubleClick += new HtmlElementEventHandler(this.MapDoubleClick.Invoke);
                    document.GetElementById("btnAttributionlEvent").Click += new HtmlElementEventHandler(this.MapEndSelectSpace.Invoke);
                    document.GetElementById("btnSpatialEvent").Click += new HtmlElementEventHandler(this.MapSpatialEvent.Invoke);
                    document.GetElementById("btnDirectionEvent").Click += new HtmlElementEventHandler(this.MapDirectionEvent.Invoke);
                    document.GetElementById("btnGetCarID").Click += new HtmlElementEventHandler(this.MapSelectedCarEvent.Invoke);
                    document.GetElementById("map").MouseEnter += new HtmlElementEventHandler(this.GisMap_MouseEnter);
                    document.GetElementById("map").MouseLeave += new HtmlElementEventHandler(this.GisMap_MouseLeave);
                }
                catch
                {
                }
                base.OnDocumentCompleted(e);
            }
        }

        private void SelectedCarEvent(object sender, HtmlElementEventArgs e)
        {
        }

        public void setArrowheadTool()
        {
            try
            {
                base.Document.InvokeScript("setShowHintTool");
                this.m_sTool = MapTool.箭头;
            }
            catch
            {
            }
        }

        public void setCarAlarm(object sCarId, object isalarm)
        {
            try
            {
                object[] args = new object[] { sCarId, isalarm };
                base.Document.InvokeScript("setCarAlarm", args);
                args = null;
            }
            catch
            {
            }
        }

        public void setCircleMesTool()
        {
            try
            {
                base.Document.InvokeScript("setCircleMesTool");
                this.m_sTool = MapTool.圆形量算;
            }
            catch
            {
            }
        }

        public void setCircleTool()
        {
            try
            {
                base.Document.InvokeScript("setpointtool");
                this.m_sTool = MapTool.设置圆形区域;
            }
            catch
            {
            }
        }

        public void setClickZoomDownTool()
        {
            try
            {
                base.Document.InvokeScript("setClickZoomOutTool");
                this.m_sTool = MapTool.点击缩小;
            }
            catch
            {
            }
        }

        public void setClickZoomUpTool()
        {
            try
            {
                base.Document.InvokeScript("setClickZoomInTool");
                this.m_sTool = MapTool.点击放大;
            }
            catch
            {
            }
        }

        public void setDelPoint()
        {
            try
            {
                base.Document.InvokeScript("setpointtool");
                this.m_sTool = MapTool.删除标注;
            }
            catch
            {
            }
        }

        public void setgetCarIDTool()
        {
            try
            {
                base.Document.InvokeScript("setgetCarIDTool");
                this.m_sTool = MapTool.箭头;
            }
            catch
            {
            }
        }

        public void setIsShowTrack(string sCarId, bool bIsShowTrace)
        {
            try
            {
                object[] args = new object[] { sCarId, bIsShowTrace };
                base.Document.InvokeScript("setIsShowTrackPoint", args);
            }
            catch
            {
            }
        }

        public void setMap(string sExtend)
        {
            object[] args = new object[] { sExtend };
            try
            {
                base.Document.InvokeScript("setMap", args);
            }
            catch
            {
            }
        }

        public void setMapToCenter()
        {
            try
            {
                base.Document.InvokeScript("setpointtool");
                this.m_sTool = MapTool.设置圆形区域;
            }
            catch
            {
            }
        }

        public void setMeasureTool()
        {
            try
            {
                base.Document.InvokeScript("setmeasuretool");
                this.m_sTool = MapTool.测距;
            }
            catch
            {
            }
        }

        public void setPanTool()
        {
            try
            {
                base.Document.InvokeScript("setpantool");
                this.m_sTool = MapTool.移动;
            }
            catch
            {
            }
        }

        public void setPathRemoveLastSection()
        {
            try
            {
                base.Document.InvokeScript("sketchBack");
                this.m_sTool = MapTool.设置路线;
            }
            catch
            {
            }
        }

        public void setPathTool()
        {
            try
            {
                base.Document.InvokeScript("setpathtool");
                this.m_sTool = MapTool.设置路线;
            }
            catch
            {
            }
        }

        public void setPathToolSTD()
        {
            try
            {
                base.Document.InvokeScript("showDirectionBar");
            }
            catch
            {
            }
        }

        public void setPointTool()
        {
            try
            {
                base.Document.InvokeScript("setpointtool");
                this.m_sTool = MapTool.标注地图;
            }
            catch
            {
            }
        }

        public void setPolygonMesTool()
        {
            try
            {
                base.Document.InvokeScript("setPolygonMesTool");
                this.m_sTool = MapTool.多边形量算;
            }
            catch
            {
            }
        }

        public void setQuerySearchCar()
        {
            try
            {
                base.Document.InvokeScript("setZoomBoxExTool");
                this.m_sTool = MapTool.日期查车;
            }
            catch
            {
            }
        }

        public void setRectangleMesTool()
        {
            try
            {
                base.Document.InvokeScript("setRectangleMesTool");
                this.m_sTool = MapTool.矩形量算;
            }
            catch
            {
            }
        }

        public void setRegionTool()
        {
            try
            {
                base.Document.InvokeScript("setregiontool");
                this.m_sTool = MapTool.设置区域;
            }
            catch
            {
            }
        }

        public void setShowHintTool()
        {
            try
            {
                base.Document.InvokeScript("setShowHintTool");
                this.m_sTool = MapTool.箭头;
            }
            catch
            {
            }
        }

        public void setSmallArea()
        {
            try
            {
                base.Document.InvokeScript("setZoomBoxExTool");
                this.m_sTool = MapTool.小范围电召;
            }
            catch
            {
            }
        }

        public void setTrackingCar(string sCarId)
        {
            try
            {
                object[] args = new object[] { sCarId };
                base.Document.InvokeScript("settrackingcar", args);
                args = null;
            }
            catch
            {
            }
        }

        public void setZoomBoxExTool()
        {
            try
            {
                base.Document.InvokeScript("setZoomBoxExTool");
                this.m_sTool = MapTool.设置矩形区域;
            }
            catch
            {
            }
        }

        public void setZoomDownTool()
        {
            try
            {
                base.Document.InvokeScript("setzoomouttool");
                this.m_sTool = MapTool.缩小;
            }
            catch
            {
            }
        }

        public void setZoomToCenter()
        {
            try
            {
                base.Document.InvokeScript("setZoomToCenter");
                this.m_sTool = MapTool.中心点;
            }
            catch
            {
            }
        }

        public void setZoomUpTool()
        {
            try
            {
                base.Document.InvokeScript("setzoomintool");
                this.m_sTool = MapTool.放大;
            }
            catch
            {
            }
        }

        public void ShowCar(object[] argsShowCar)
        {
            try
            {
                base.Document.InvokeScript("showCar", argsShowCar);
                argsShowCar = null;
            }
            catch
            {
            }
        }

        public void showCircle(string CircleName, double CenterPointX, double CenterPointY, int radius, bool isZoom)
        {
            try
            {
                object[] args = new object[] { CircleName, CenterPointX, CenterPointY, radius, isZoom };
                base.Document.InvokeScript("showCircle", args);
                args = null;
            }
            catch
            {
            }
        }

        public void showCircle(string CircleName, double CenterPointX, double CenterPointY, int radius)
        {
            try
            {
                object[] args = new object[] { CircleName, CenterPointX, CenterPointY, radius, true };
                base.Document.InvokeScript("showCircle", args);
                args = null;
            }
            catch
            {
            }
        }

        public void simplify(string id, string tolerance)
        {
            try
            {
                object[] args = new object[] { id, tolerance };
                base.Document.InvokeScript("simplify", args);
            }
            catch
            {
            }
        }

        public void showCompany(string name, string hintText, string lon, string lat)
        {
            try
            {
                object[] args = new object[] { name, hintText, lon, lat };
                base.Document.InvokeScript("showCompany", args);
            }
            catch
            {
            }
        }

        public void ShowFlag(string sName, string sLon, string sLat, string sBmpName)
        {
            try
            {
                object[] args = new object[] { sName, sLon, sLat, sBmpName };
                base.Document.InvokeScript("showflag", args);
                args = null;
            }
            catch
            {
            }
        }

        public void showpolygonForCS(string sRegionName, string sLongitude, string sLatitude, bool IsZoom)
        {
            try
            {
                object[] args = new object[] { sRegionName, sLongitude, sLatitude, IsZoom };
                base.Document.InvokeScript("showpolygonForCS", args);
                args = null;
            }
            catch
            {
            }
        }

        private void SpatialEvent(object sender, HtmlElementEventArgs e)
        {
        }

        public void zoomToCar(string sCarId)
        {
            try
            {
                object[] args = new object[] { sCarId };
                base.Document.InvokeScript("zoomToCar", args);
                args = null;
            }
            catch
            {
            }
        }

        public void zoomToMaxExtent()
        {
            try
            {
                base.Document.InvokeScript("zoomToMaxExtent");
            }
            catch
            {
            }
        }

        public void zoonmToLonLat(string sLon, string sLat, string sName)
        {
            try
            {
                object[] args = new object[] { sLon, sLat, sName };
                base.Document.InvokeScript("zoonmToLngLat", args);
                args = null;
            }
            catch
            {
            }
        }

        public void deleteCarByIconType(string iconType)
        {
            try
            {
                object[] obj = new object[] { iconType };
                base.Document.InvokeScript("deleteCarByIconType", obj);
                obj = null;
            }
            catch
            {
            }
        }

        public enum MapTool
        {
            移动 = 0,
            放大 = 1,
            缩小 = 2,
            标注地图 = 3,
            删除标注 = 4,
            设置区域 = 5,
            设置矩形区域 = 6,
            设置路线 = 7,
            测距 = 8,
            中心点 = 9,
            箭头 = 10,
            轨迹点 = 11,
            日期查车 = 12,
            小范围电召 = 13,
            设置标志点 = 14,
            设置圆形区域 = 14,
            矩形量算 = 15,
            圆形量算 = 16,
            多边形量算 = 17,
            路径分析 = 18,
            圆形小范围电召 = 19,
            点击缩小 = 20,
            点击放大 = 21
        }

    }
}

