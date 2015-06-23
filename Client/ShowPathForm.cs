using Client.Properties;
using PublicClass;
using Remoting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WinFormsUI.Controls;
using Library;

namespace Client
{
    public partial class ShowPathForm : SizableForm
    {
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        private string dotString = "AlarmPathDot";
        private System.Windows.Forms.Label lblName;
        private string pathId = "PathId";
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private GisMap gisMap;
        private int pathType = 1;
        private string sLines = "";
        private System.Windows.Forms.Label lblTipRed;
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        private int showMaxCount = 30;
        private ToolStripButton tsbFilter;
        private CheckedListBox clbItems;
        private DataTable linesDataDataTable = new DataTable();
        private System.Windows.Forms.Panel panel1;
        private ToolStrip tsFilter;
        private ToolStrip tsFind;
        private ToolStripButton tsbFind;
        private System.Windows.Forms.Label lblStatus;
        private GroupBox grpMain;
        private PictureBox pb1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlOpt;
        private System.Windows.Forms.Label lblFilter;
        private string pathName = "PathName";
        private DataTable dt2 = new DataTable();
        private List<object> list1 = new List<object>();
        private object[] objs;
        private ComboBox cbbGroupName;
        private System.Windows.Forms.TextBox txtFilter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gisMap">地图对象</param>
        /// <param name="type">类型，1=线路，2=区域</param>
        public ShowPathForm(GisMap gisMap, int type)
        {
            this.InitializeComponent();
            this.gisMap = gisMap;
            this.pathType = type;
            if (type == 1)
            {
                this.pathId = "PathId";
                this.pathName = "PathName";
                this.dotString = "AlarmPathDot";
                this.Text = "偏移路线显示控制";
                this.grpMain.Text = "选择预显示路线名称";
            }
            else
            {
                this.pathId = "RegionId";
                this.pathName = "RegionName";
                this.dotString = "RegionDot";
                this.Text = "区域显示控制";
                this.grpMain.Text = "选择预显示区域名称";
            }
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new DoWorkEventHandler(this.backRunWork);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backRunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.backWorkerProgressChanged);
        }

        [CompilerGenerated]
        private void execClearAllPath()
        {
            this.gisMap.execClearAllPath();
        }

        private void ShowPathForm_Load(object sender, EventArgs e)
        {
            string format = "select UserId, Type, DotValue from GpsPathRegionShowInfo where Userid = '{0}' and Type = '{1}'";
            DataTable table = RemotingClient.ExecSql(string.Format(format, Variable.sUserId, this.pathType));
            if ((table != null) && (table.Rows.Count > 0))
            {
                this.sLines = table.Rows[0]["DotValue"].ToString();
            }
            else
            {
                this.sLines = "";
            }
            this.GetPathInfo();
            this.O1100OO1l11O();
        }

        private void backRunWork(object sender, DoWorkEventArgs e)
        {
            MethodInvoker method = null;
            MethodInvoker invoker3 = null;
            try
            {
                if (this.pathType == 1)
                {
                    if (method == null)
                    {
                        method = new MethodInvoker(this.execClearAllPath);
                    }
                    base.Invoke(method);
                }
                else if (this.pathType == 2)
                {
                    if (invoker3 == null)
                    {
                        invoker3 = new MethodInvoker(this.execClearAllPolygon);
                    }
                    base.Invoke(invoker3);
                }
                int count = this.dict.Count;
                int num2 = 0;
                if (count > 0)
                {
                    if (this.pathType == 1)
                    {
                        using (Dictionary<string, string>.KeyCollection.Enumerator enumerator = this.dict.Keys.GetEnumerator())
                        {
                            PathInfo pathInfo = new PathInfo();
                            while (enumerator.MoveNext())
                            {
                                pathInfo.PathName = enumerator.Current;
                                PathEntity pathEntity = new PathEntity
                                {
                                    locals8 = pathInfo,
                                    this_4 = this,
                                    Lons = "",
                                    Lats = ""
                                };

                                string[] strArray = this.dict[pathInfo.PathName].Split(new char[] { '/' });
                                for (int i = 0; i < strArray.Length; i++)
                                {
                                    string[] strArray2 = strArray[i].Split(new char[] { '*' });
                                    if (strArray2.Length == 2)
                                    {
                                        pathEntity.Lons = pathEntity.Lons + strArray2[0] + ",";
                                        pathEntity.Lats = pathEntity.Lats + strArray2[1] + ",";
                                    }
                                }
                                pathEntity.Lons.Trim(new char[] { ',' });
                                pathEntity.Lats.Trim(new char[] { ',' });
                                base.Invoke(new MethodInvoker(pathEntity.worker_DoWork__2));
                                num2++;
                                this.backgroundWorker.ReportProgress((int)((((double)num2) / ((double)count)) * 100.0));
                            }
                            return;
                        }
                    }
                    using (Dictionary<string, string>.KeyCollection.Enumerator enumerator2 = this.dict.Keys.GetEnumerator())
                    {
                        OOll00ll0l0O11101l olllllol = new OOll00ll0l0O11101l();

                        while (enumerator2.MoveNext())
                        {
                            olllllol.PathName = enumerator2.Current;
                            MethodInvoker invoker = null;
                            O01l0ll1O0OOl1OO1O olooo = new O01l0ll1O0OOl1OO1O
                            {
                                localsc = olllllol,
                                this_4 = this,
                                Lons = "",
                                Lats = ""
                            };
                            string str2 = this.dict[olllllol.PathName];
                            if (Check.isRoundness(str2))
                            {
                                OO1l0001O1OO1O1Ol01 ol2 = new OO1l0001O1OO1O1Ol01
                                {
                                    localsf = olooo,
                                    localsc = olllllol
                                };
                                string[] strArray4 = str2.Trim(new char[] { '*' }).Split(new char[] { '*' })[0].Split(new char[] { '\\' });
                                ol2.sCenterPointX = double.Parse(strArray4[0]);
                                ol2.sCenterPointY = double.Parse(strArray4[1]);
                                ol2.sRadius = int.Parse(strArray4[2]);
                                base.Invoke(new MethodInvoker(ol2.worker_DoWork__3));
                            }
                            else
                            {
                                string[] strArray5 = str2.Split(new char[] { '*' });
                                for (int j = 0; j < strArray5.Length; j++)
                                {
                                    string[] strArray6 = strArray5[j].Split(new char[] { '\\' });
                                    if (strArray6.Length == 2)
                                    {
                                        olooo.Lons = olooo.Lons + strArray6[0] + ",";
                                        olooo.Lats = olooo.Lats + strArray6[1] + ",";
                                    }
                                }
                                olooo.Lons.Trim(new char[] { ',' });
                                olooo.Lats.Trim(new char[] { ',' });
                                if (invoker == null)
                                {
                                    invoker = new MethodInvoker(olooo.worker_DoWork__4);
                                }
                                base.Invoke(invoker);
                            }
                            num2++;
                            this.backgroundWorker.ReportProgress((int)((((double)num2) / ((double)count)) * 100.0));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("Type:" + this.pathType + ",设置偏移路线区域显示控制-->", exception.Message);
            }
        }

        private void O0O000llOl()
        {
            this.list1.Clear();
            this.objs = new object[this.clbItems.Items.Count];
            this.clbItems.Items.CopyTo(this.objs, 0);
        }

        private void backWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double num = ((double)e.ProgressPercentage) / 100.0;
            this.lblStatus.Text = "已完成：" + num.ToString("P").Replace(".00", "");
        }

        private void O1100OO1l11O()
        {
            this.dt2 = RemotingClient.Alarm_GetGroupType();
            if ((this.dt2 != null) && (this.dt2.Rows.Count > 0))
            {
                DataRow row = this.dt2.NewRow();
                this.dt2.Rows.InsertAt(row, 0);
                this.cbbGroupName.DataSource = this.dt2;
            }
            else
            {
                this.cbbGroupName.Items.Add("(无)");
                this.cbbGroupName.Text = "(无)";
            }
        }

        private void FilterLines(string line)
        {
            try
            {
                base.Enabled = false;
                for (int i = 0; i < this.list1.Count; i++)
                {
                    int index = this.clbItems.Items.IndexOf(this.list1[i]);
                    if ((index >= 0) && !this.clbItems.CheckedItems.Contains(this.clbItems.Items[index]))
                    {
                        this.list1.Remove(this.clbItems.Items[index]);
                        i--;
                    }
                }
                for (int j = 0; j < this.clbItems.CheckedItems.Count; j++)
                {
                    if (!this.list1.Contains(this.clbItems.CheckedItems[j]))
                    {
                        this.list1.Add(this.clbItems.CheckedItems[j]);
                    }
                }
                this.clbItems.Items.Clear();
                for (int k = 0; k < this.objs.Length; k++)
                {
                    if (this.objs[k].ToString().Contains(line))
                    {
                        bool isChecked = false;
                        if (this.list1.Contains(this.objs[k]))
                        {
                            isChecked = true;
                        }
                        this.clbItems.Items.Add(this.objs[k], isChecked);
                    }
                }
                this.clbItems.Refresh();
            }
            catch
            {
            }
            finally
            {
                base.Enabled = true;
            }
        }

        private void tsbFind_Clicked(object sender, EventArgs e)
        {
            if ((this.cbbGroupName.SelectedValue != null) && !this.cbbGroupName.SelectedValue.ToString().Equals(""))
            {
                DataTable table = new DataTable();
                DataView view = new DataView(this.linesDataDataTable);
                try
                {
                    string s = this.cbbGroupName.SelectedValue.ToString();
                    string str2 = "pathgroupID =" + int.Parse(s);
                    view.RowFilter = str2;
                    table = view.ToTable();
                    this.Olll001l11(table);
                }
                catch
                {
                }
            }
            else
            {
                this.Olll001l11(this.linesDataDataTable);
            }
        }

        private void EnableControl(bool status)
        {
            this.pb1.Visible = this.lblStatus.Visible = !status;
            base.ControlBox = status;
            this.grpMain.Enabled = this.btnCancel.Enabled = this.btnOK.Enabled = status;
        }

        private void backRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.EnableControl(true);
            base.DialogResult = DialogResult.OK;
        }

        private void Olll001l11(DataTable dataTable)
        {
            this.clbItems.Items.Clear();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string text = row[this.pathName].ToString();
                    string str2 = row[this.pathId].ToString();
                    ListItem item = new ListItem(text, str2);
                    if (this.clbItems.Items.IndexOf(item) < 0)
                    {
                        if (string.IsNullOrEmpty(this.sLines))
                        {
                            this.clbItems.Items.Add(item, false);
                        }
                        else
                        {
                            List<string> list = new List<string>(this.sLines.Split(new char[] { ',' }));
                            string str3 = row[this.pathId].ToString();
                            if (list.Contains(str3))
                            {
                                item.Selected = true;
                                this.clbItems.Items.Add(item, true);
                            }
                            else
                            {
                                item.Selected = false;
                                this.clbItems.Items.Add(item, false);
                            }
                        }
                    }
                }
                this.O0O000llOl();
            }
            else
            {
                System.Web.UI.WebControls.CheckBox box = new System.Web.UI.WebControls.CheckBox
                {
                    Text = "(无)"
                };
                this.clbItems.Items.Add(box, false);
            }
        }

        private string GetLines()
        {
            string str = "";
            foreach (ListItem item in this.clbItems.CheckedItems)
            {
                str = str + item.Value + ",";
            }
            return str.Trim(new char[] { ',' });
        }

        private void btnOk_Clicked(object Ol111O, EventArgs O)
        {
            if (this.FilterData())
            {
                string format = "delete from GpsPathRegionShowInfo where UserId = '{0}' and Type = '{2}';insert into GpsPathRegionShowInfo(UserId, Type, DotValue) values('{0}', '{2}', '{1}') ";
                //执行Sql，删除旧配置，添加新配置
                if (RemotingClient.ExecNoQuery(string.Format(format, Variable.sUserId, this.sLines, this.pathType)).ResultCode != 0L)
                {
                    MessageBox.Show("参数保存数据库错误，请重新尝试。");
                }
                else
                {
                    //显示线路
                    if (this.pathType == 1)
                    {
                        WaitForm.Show("正在更新地图路线信息，请稍候...", this);
                        MainForm.myMap.showPathMap(this.gisMap);
                    }
                    //显示区域
                    else
                    {
                        WaitForm.Show("正在更新地图区域信息，请稍候...", this);
                        MainForm.myMap.showRegionMap(this.gisMap);
                    }
                    base.DialogResult = DialogResult.OK;
                }
            }
        }


        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void tsbFilter_Clicked(object sender, EventArgs e)
        {
            this.FilterLines(this.txtFilter.Text);
        }

        private bool FilterData()
        {
            try
            {
                this.FilterLines("");
                this.sLines = this.GetLines();
                this.dict.Clear();
                if (!string.IsNullOrEmpty(this.sLines))
                {
                    string[] strArray = this.sLines.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray.Length > this.showMaxCount)
                    {
                        MessageBox.Show("设置显示的超过允许的最大值" + this.showMaxCount + ",请重新选择。");
                        return false;
                    }
                    foreach (string str in strArray)
                    {
                        DataRow[] rowArray = this.linesDataDataTable.Select(this.pathId + " = '" + str + "'");
                        if (rowArray.Length > 0)
                        {
                            this.dict[rowArray[0][this.pathName].ToString()] = rowArray[0][this.dotString].ToString();
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        [CompilerGenerated]
        private void execClearAllPolygon()
        {
            this.gisMap.execClearAllPolygon();
        }

        private void GetPathInfo()
        {
            if (this.pathType == 1)
            {
                this.linesDataDataTable = RemotingClient.Alarm_GetPathInfo();
            }
            else
            {
                this.linesDataDataTable = RemotingClient.Alarm_GetRegionInfo();
            }
            this.Olll001l11(this.linesDataDataTable);
        }

        [CompilerGenerated]
        private sealed class O01l0ll1O0OOl1OO1O
        {
            public ShowPathForm this_4;
            public ShowPathForm.OOll00ll0l0O11101l localsc;
            public string Lats;
            public string Lons;

            public void worker_DoWork__4()
            {
                this.this_4.gisMap.showpolygonForCS(this.localsc.PathName, this.Lons, this.Lats, false);
            }
        }

        [CompilerGenerated]
        private sealed class PathInfo
        {
            public string PathName;
        }

        [CompilerGenerated]
        private sealed class PathEntity
        {
            public ShowPathForm this_4;
            public ShowPathForm.PathInfo locals8;
            public string Lats;
            public string Lons;

            public void worker_DoWork__2()
            {
                this.this_4.gisMap.execShowPath(this.locals8.PathName, this.Lons, this.Lats, false);
            }
        }

        [CompilerGenerated]
        private sealed class OO1l0001O1OO1O1Ol01
        {
            public ShowPathForm.OOll00ll0l0O11101l localsc;
            public ShowPathForm.O01l0ll1O0OOl1OO1O localsf;
            public double sCenterPointX;
            public double sCenterPointY;
            public int sRadius;

            public void worker_DoWork__3()
            {
                this.localsf.this_4.gisMap.showCircle(this.localsc.PathName, this.sCenterPointX, this.sCenterPointY, this.sRadius);
            }
        }

        [CompilerGenerated]
        private sealed class OOll00ll0l0O11101l
        {
            public string PathName;
        }
    }
}

