namespace PublicClass
{
    using PublicClass.WebGisService;
    using System;
    using System.Net;

    public class GisService
    {
        private static WebgisService _WebGis;

        public static string[] GetDistrictInfo(string[] sIdlonLats)
        {
            try
            {
                return WebGis.GetDistrictInfo(sIdlonLats);
            }
            catch (WebException exception)
            {
                Record.execFileRecord("取得县市区级位置（WebService）", sIdlonLats + " " + exception.Message);
                return null;
            }
            catch (Exception exception2)
            {
                Record.execFileRecord("取得县市区级位置（WebService）", sIdlonLats + " " + exception2.Message);
                return null;
            }
        }

        public static string[] GetRegionNames(string sReginId)
        {
            try
            {
                string[] regionNames = WebGis.GetRegionNames(sReginId);
                if (regionNames.Length <= 1)
                {
                    return null;
                }
                return regionNames;
            }
            catch (WebException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string QueryAllLayerByPoint(string sLon, string sLat)
        {
            try
            {
                double x = double.Parse(sLon);
                double y = double.Parse(sLat);
                string str = WebGis.QueryAllLayerByPoint(x, y);
                string[] separator = new string[] { ":::" };
                string[] strArray2 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (strArray2.Length <= 1)
                {
                    return "未知";
                }
                return strArray2[1];
            }
            catch (WebException exception)
            {
                Record.execFileRecord("取得详细位置信息（WebService）", sLon + "," + sLat + " " + exception.Message);
                return "未知";
            }
            catch (Exception exception2)
            {
                Record.execFileRecord("取得详细位置信息（WebService）", sLon + "," + sLat + " " + exception2.Message);
                return "未知";
            }
        }

        public static void RefreshService()
        {
            if (_WebGis != null)
            {
                _WebGis.Url = string.Format("http://{0}:{1}/{2}/OpenLayers/WebgisService.asmx", Variable.sMapIp, Variable.sMapPort, Variable.sMapName);
            }
        }

        private static WebgisService WebGis
        {
            get
            {
                if (_WebGis == null)
                {
                    _WebGis = new WebgisService();
                    _WebGis.Url = string.Format("http://{0}:{1}/{2}/OpenLayers/WebgisService.asmx", Variable.sMapIp, Variable.sMapPort, Variable.sMapName);
                }
                return _WebGis;
            }
        }
    }
}

