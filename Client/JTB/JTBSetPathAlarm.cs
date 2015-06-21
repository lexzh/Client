namespace Client.JTB
{
    using Client;
    using Properties;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBSetPathAlarm : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private string currentPathName = "";
        private Dictionary<string, DataTable> datalist = new Dictionary<string, DataTable>();
        private DataTable pathdt = new DataTable();
        private DataTable pathSectiondt = new DataTable();
        private BindingSource pathSectionSource = new BindingSource();
        private BindingSource pathSource = new BindingSource();
        private List<PathAlarmList> sendlist = new List<PathAlarmList>();

        public JTBSetPathAlarm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._worker_RunWorkerCompleted);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
            this.pathSectionSource.AllowNew = true;
            DataColumn column = new DataColumn("SectionName");
            DataColumn column2 = new DataColumn("MaxSpeed");
            DataColumn column3 = new DataColumn("MaxSpeedTm");
            DataColumn column4 = new DataColumn("MaxTm");
            DataColumn column5 = new DataColumn("MinTm");
            DataColumn column6 = new DataColumn("LanLon");
            this.pathSectiondt.Columns.AddRange(new DataColumn[] { column, column2, column3, column4, column5, column6 });
            DataColumn column7 = new DataColumn("pathname");
            DataColumn column8 = new DataColumn("begintm");
            DataColumn column9 = new DataColumn("endtm");
            DataColumn column10 = new DataColumn("pathattr");
            this.pathdt.Columns.AddRange(new DataColumn[] { column7, column8, column9, column10 });
            this.dgvPath.DataSource = this.pathdt;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string[] strArray = base.sValue.Split(new char[] { ',' });
                int length = strArray.Length;
                int num2 = 0;
                if (length > 1)
                {
                    foreach (string str in strArray)
                    {
                        foreach (PathAlarmList list in this.sendlist)
                        {
                            base.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(base.ParamType, str, base.sPw, CmdParam.CommMode.未知方式, list);
                        }
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                    }
                }
                else
                {
                    foreach (PathAlarmList list2 in this.sendlist)
                    {
                        base.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, list2);
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置分段超速报警-->", exception.Message);
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double num = ((double) e.ProgressPercentage) / 100.0;
            this.lblWaitText.Text = "已完成：" + num.ToString("P").Replace(".00", "");
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlEnable(true);
            if (base.reResult.ResultCode != 0L)
            {
                MessageBox.Show(base.reResult.ErrorMsg);
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void _路线属性_VisibilityChange(bool isvisible)
        {
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            if (!isvisible)
            {
                string str = "";
                new List<string>();
                ListBox.SelectedObjectCollection selectedItems = innerControl.SelectedItems;
                int count = innerControl.Items.Count;
                ArrayList list = new ArrayList(count);
                for (int i = 0; i < count; i++)
                {
                    string str2 = "";
                    if (selectedItems.Contains(innerControl.Items[i]))
                    {
                        str2 = "1";
                        Client.ListBoxItem item = innerControl.Items[i] as Client.ListBoxItem;
                        str = str + item.Name.ToString() + ",";
                    }
                    else
                    {
                        str2 = "0";
                    }
                    list.Add(str2);
                }
                if (this.dgvPath.CurrentCell != null)
                {
                    try
                    {
                        this.dgvPath.CurrentCell.Value = str.Trim(",".ToCharArray());
                        this.dgvPath.CurrentCell.Tag = list;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                innerControl.ClearSelected();
                if (this.dgvPath.CurrentCell.Tag == null)
                {
                    if (this.dgvPath.CurrentCell.Value != null)
                    {
                        List<string> list2 = new List<string>();
                        list2.AddRange(this.dgvPath.CurrentCell.Value.ToString().Split(",".ToCharArray()));
                        int num3 = innerControl.Items.Count;
                        for (int j = 0; j < num3; j++)
                        {
                            Client.ListBoxItem item2 = innerControl.Items[j] as Client.ListBoxItem;
                            if (list2.Contains(item2.Name))
                            {
                                innerControl.SetSelected(j, true);
                            }
                        }
                    }
                }
                else if (this.dgvPath.CurrentCell.Tag != null)
                {
                    ArrayList tag = this.dgvPath.CurrentCell.Tag as ArrayList;
                    for (int k = 0; k < innerControl.Items.Count; k++)
                    {
                        innerControl.SetSelected(k, tag[k].ToString().Equals("1"));
                    }
                }
            }
        }

        private void Add路线属性()
        {
            ListBoxEx con = new ListBoxEx();
            Client.ListBoxItem item = new Client.ListBoxItem("根据时间", "0");
            Client.ListBoxItem item2 = new Client.ListBoxItem("限速", "1");
            Client.ListBoxItem item3 = new Client.ListBoxItem("进区域报警给驾驶员", "2");
            Client.ListBoxItem item4 = new Client.ListBoxItem("进区域报警给平台", "3");
            Client.ListBoxItem item5 = new Client.ListBoxItem("出区域报警给驾驶员", "4");
            Client.ListBoxItem item6 = new Client.ListBoxItem("出区域报警给平台", "5");
            con.DrawMode = DrawMode.OwnerDrawFixed;
            con.FormattingEnabled = true;
            con.IsCheckBox = true;
            con.SelectionMode = SelectionMode.MultiSimple;
            con.Items.AddRange(new object[] { item, item2, item3, item4, item5, item6 });
            this._路线属性 = new AutoDropDown(con);
            base.Controls.Add(this._路线属性);
            this._路线属性.VisibilityChange += new VisibleChanged(this._路线属性_VisibilityChange);
        }

        private void btnAddPathRegion_Click(object sender, EventArgs e)
        {
            if (this.currentPathName.Trim().Length == 0)
            {
                MessageBox.Show("请选择路线!");
            }
            else
            {
                MessageBox.Show("请首先在地图上点击您要设定的路段，鼠标双击结束设置。");
                this.wbMap.execClearAllPath();
                this.wbMap.setPathTool();
            }
        }

        private void btnAddPathSection_Click(object sender, EventArgs e)
        {
            if (this.txtPathSection.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (this.numMaxTm.Value < this.numMinTm.Value)
            {
                MessageBox.Show("行驶最长时间不能小于行驶最短时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!PublicClass.Check.isNumeric(this.numMaxSpeedTm.Value.ToString(), PublicClass.Check.NumType.sByte) || ((Convert.ToInt32(this.numMaxSpeedTm.Value.ToString()) % 5) != 0))
            {
                MessageBox.Show("持续时长必须为0-255之间5的倍数！");
            }
            else if (this.pathSectionSource.DataSource != null)
            {
                DataTable dataSource = this.pathSectionSource.DataSource as DataTable;
                DataRow row = dataSource.NewRow();
                row["SectionName"] = this.txtPathSection.Text;
                row["MaxSpeed"] = (int) this.numMaxSpeed.Value;
                row["MaxSpeedTm"] = (int) this.numMaxSpeedTm.Value;
                row["MaxTm"] = (int) this.numMaxTm.Value;
                row["MinTm"] = (int) this.numMinTm.Value;
                row["LanLon"] = this.pnlAddPathSection.Tag.ToString();
                dataSource.Rows.Add(row);
                this.btnCancelPathSectionAdd_Click(null, null);
            }
        }

        private void btnCancelPathSectionAdd_Click(object sender, EventArgs e)
        {
            this.pnlAddPathSection.Visible = false;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (((!string.IsNullOrEmpty(base.sValue) && this.checkGrid()) && this.getParam()) && !this._worker.IsBusy)
                {
                    this.SetControlEnable(false);
                    this._worker.RunWorkerAsync();
                }
            }
            catch (Exception exception)
            {
                this.SetControlEnable(true);
                MessageBox.Show(exception.Message);
            }
        }

        private bool checkGrid()
        {
            DataTable dataSource = this.dgvPath.DataSource as DataTable;
            foreach (DataRow row in dataSource.Rows)
            {
                string str = row["pathName"].ToString();
                string strDate = row["begintm"].ToString();
                string str3 = row["endtm"].ToString();
                string strResultDate = string.Empty;
                string str5 = string.Empty;
                if (strDate.Length == 0)
                {
                    MessageBox.Show("路线\"" + str + "\"没有设置起始时间！");
                    return false;
                }
                if (str3.Length == 0)
                {
                    MessageBox.Show("路线\"" + str + "\"没有设置终止时间！");
                    return false;
                }
                if (!PublicClass.Check.CheckIsDate(strDate, out strResultDate))
                {
                    MessageBox.Show("路线\"" + str + "\"起始时间格式有误！");
                    return false;
                }
                if (!PublicClass.Check.CheckIsDate(str3, out str5))
                {
                    MessageBox.Show("路线\"" + str + "\"终止时间格式有误！");
                    return false;
                }
                string str6 = strDate.Substring(0, 4);
                string str7 = str3.Substring(0, 4);
                if (((str6 == "0000") && (str7 != "0000")) || ((str7 == "0000") && (str6 != "0000")))
                {
                    MessageBox.Show("路线\"" + str + "\"设置起始时间和终止时间时，固定时段参数勾选状态需保持一致！");
                    return false;
                }
                if ((str6 != "0000") && (DateTime.Parse(strDate) > DateTime.Parse(str3)))
                {
                    MessageBox.Show("路线\"" + str + "\"起始时间不能大于终止时间！");
                    return false;
                }
                if ((row["pathattr"] == null) || (row["pathattr"].ToString().Trim().Length == 0))
                {
                    MessageBox.Show("请设置\"" + str + "\"的路线属性！");
                    return false;
                }
            }
            return true;
        }

        private void dgvPath_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgvPath.CurrentRow.IsNewRow)
            {
                this.currentPathName = this.dgvPath.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (this.datalist.ContainsKey(this.currentPathName))
                {
                    this.pathSectionSource.DataSource = this.datalist[this.currentPathName];
                }
                else
                {
                    DataTable table = this.pathSectiondt.Clone();
                    this.datalist[this.currentPathName] = table;
                    this.pathSectionSource.DataSource = this.datalist[this.currentPathName];
                }
                this.dgvPathSection.DataSource = this.pathSectionSource;
            }
        }

        private void dgvPath_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell currentCell = this.dgvPath.CurrentCell;
            if ((e.RowIndex >= 0) && (currentCell.OwningColumn.Name.ToLower().Equals("begintm") || currentCell.OwningColumn.Name.ToLower().Equals("endtm")))
            {
                SetDateTime time = new SetDateTime(currentCell.Value.ToString()); ///ToString
                if (time.ShowDialog() == DialogResult.OK)
                {
                    currentCell.Value = time.Time;
                    this.dgvPath.EndEdit();
                }
            }
            else if (this.dgvPath.CurrentCell.OwningColumn.Name.ToLower().Equals("pathattr"))
            {
                System.Drawing.Point location = this.dgvPath.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                this._路线属性.ShowDropDown(new System.Drawing.Point(location.X + 3, (location.Y + this._路线属性.Height) + 150));
            }
        }

        private void dgvPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Delete) && !this.dgvPath.CurrentRow.IsNewRow) && (this.dgvPath.CurrentRow != null))
            {
                this.dgvPath.Rows.Remove(this.dgvPath.CurrentRow);
            }
        }

        private void dgvPathSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string[] strArray = this.dgvPathSection.CurrentRow.Cells["LanLon"].Value.ToString().Split(new char[] { ';' });
                if ((strArray != null) && (strArray.Length > 0))
                {
                    string str = "";
                    string str2 = "";
                    foreach (string str3 in strArray)
                    {
                        string[] strArray2 = str3.Split(new char[] { ',' });
                        str = str + strArray2[0] + ",";
                        str2 = str2 + strArray2[1] + ",";
                    }
                    this.wbMap.execClearAllPath();
                    this.wbMap.execShowPath("ttt", str.Trim(new char[] { ',' }), str2.Trim(new char[] { ',' }), true);
                }
            }
            catch
            {
            }
        }

        private void dgvPathSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Delete) && !this.dgvPathSection.CurrentRow.IsNewRow) && (this.dgvPathSection.CurrentRow != null))
            {
                this.dgvPathSection.Rows.Remove(this.dgvPathSection.CurrentRow);
            }
        }

 private ArrayList GeneralDomainText(string text)
        {
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            string str = "";
            int count = innerControl.Items.Count;
            ArrayList list = new ArrayList(count);
            for (int i = 0; i < count; i++)
            {
                string str2 = "";
                if (text.Contains(innerControl.Items[i].ToString()))
                {
                    str2 = "1";
                    Client.ListBoxItem item = innerControl.Items[i] as Client.ListBoxItem;
                    str = str + item.Name.ToString() + ",";
                }
                else
                {
                    str2 = "0";
                }
                list.Add(str2);
            }
            return list;
        }

        private void GeneralDomainValue(int val, out string showtext)
        {
            string str = "";
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            int count = innerControl.Items.Count;
            string str2 = this.ToErJin(val).ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i < 6; i++)
            {
                if (str2.Length > i)
                {
                    list.Add(str2.Substring((str2.Length - i) - 1, 1));
                }
                else
                {
                    list.Add("0");
                }
            }
            for (int j = 0; j < count; j++)
            {
                if (list[j].ToString().Equals("1"))
                {
                    Client.ListBoxItem item = innerControl.Items[j] as Client.ListBoxItem;
                    str = str + item.Name.ToString() + ",";
                }
            }
            showtext = str.Trim(",".ToCharArray());
        }

        private int GeneralValue(ArrayList list)
        {
            ArrayList list2 = list.Clone() as ArrayList;
            list2.Reverse();
            string str = "";
            for (int i = 0; i < list2.Count; i++)
            {
                str = str + list2[i];
            }
            return this.ToShijin(Convert.ToInt32(str));
        }

        private bool getParam()
        {
            DataTable dataSource = this.dgvPath.DataSource as DataTable;
            foreach (DataRow row in dataSource.Rows)
            {
                PathAlarmList item = new PathAlarmList {
                    OrderCode = base.OrderCode
                };
                string str = row["pathname"].ToString();
                DataTable table2 = this.datalist[str];
                int num = 1;
                foreach (DataRow row2 in table2.Rows)
                {
                    PathAlarm alarm = new PathAlarm();
                    ArrayList list2 = new ArrayList();
                    alarm.Points = list2;
                    alarm.PathName = str;
                    alarm.ID = num;
                    foreach (string str2 in row2["lanlon"].ToString().Split(new char[] { ';' }))
                    {
                        ParamLibrary.CmdParamInfo.Point point = new ParamLibrary.CmdParamInfo.Point();
                        string[] strArray2 = str2.Split(new char[] { ',' });
                        if (strArray2.Length == 2)
                        {
                            point.Latitude = Convert.ToDouble(strArray2[1]);
                            point.Longitude = Convert.ToDouble(strArray2[0]);
                            list2.Add(point);
                        }
                    }
                    string pStrNum = row2["MaxSpeed"].ToString();
                    string str4 = row2["MaxSpeedTm"].ToString();
                    if (!PublicClass.Check.isNumeric(pStrNum, PublicClass.Check.NumType.sByte))
                    {
                        MessageBox.Show("路线\"" + str + "\"最高时速必须为0-255的数字！");
                        return false;
                    }
                    alarm.Speed = byte.Parse(pStrNum);
                    if (!PublicClass.Check.isNumeric(str4, PublicClass.Check.NumType.sByte) || ((int.Parse(str4) % 5) != 0))
                    {
                        MessageBox.Show("路线\"" + str + "\"持续时长必须为0-255之间5的倍数！");
                        return false;
                    }
                    alarm.Time = byte.Parse(str4);
                    alarm.DriEnough = Convert.ToInt32(row2["maxtm"].ToString());
                    alarm.DriNoEnough = Convert.ToInt32(row2["mintm"].ToString());
                    item.Add(alarm);
                    num++;
                }
                string str5 = row["Begintm"].ToString();
                string str6 = row["Endtm"].ToString();
                item.BeginTime = str5;
                item.EndTime = str6;
                item.PathFlag = this.GeneralValue(this.GeneralDomainText(row["pathattr"].ToString()));
                this.sendlist.Add(item);
            }
            return true;
        }

 private void JTBSetPathAlarm_Load(object sender, EventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point((this.wbMap.Location.X + this.wbMap.Width) / 2, ((this.wbMap.Location.Y + this.wbMap.Height) / 2) - 17);
            this.picLoadMap.Location = point;
            this.picLoadMap.Visible = true;
            this.wbMap.Url = new Uri(Variable.MapUrl);
            this.Add路线属性();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        public int ToErJin(int value)
        {
            int num = 0;
            int num2 = 1;
            while (num2 != 0)
            {
                num2 = value / 2;
                int num3 = value % 2;
                value = num2;
                num += num3;
                if (num2 != 0)
                {
                    num *= 10;
                }
            }
            string str = num.ToString();
            int length = str.Length;
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            {
                s = str[i] + s;
            }
            return int.Parse(s);
        }

        public int ToShijin(int value)
        {
            string str = value.ToString();
            int length = str.Length;
            int num2 = 0;
            for (int i = 0; i < length; i++)
            {
                char ch = str[i];
                num2 += int.Parse(ch.ToString()) * ((int) Math.Pow(2.0, (double) ((length - 1) - i)));
            }
            return num2;
        }

        public int ToShijin2(int value)
        {
            int num = 0;
            int num2 = value;
            for (int i = 0; num2 != 0; i++)
            {
                int num3 = num2 % 10;
                num2 /= 10;
                num += num3 * ((int) Math.Pow(2.0, (double) i));
            }
            return num;
        }

        private void wbMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
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
            }
            catch
            {
                this.picLoadMap.Visible = false;
            }
            this.picLoadMap.Visible = false;
        }

        private void wbMap_MapDoubleClick(object sender, HtmlElementEventArgs e)
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
                        if ((strArray.Length == 2) && (strArray[0] == strArray[1]))
                        {
                            str = str.Substring(0, str.IndexOf(';'));
                        }
                        this.pnlAddPathSection.Visible = true;
                        this.pnlAddPathSection.BringToFront();
                        this.pnlAddPathSection.Tag = str;
                    }
                }
                catch
                {
                }
            }
        }
    }
}

