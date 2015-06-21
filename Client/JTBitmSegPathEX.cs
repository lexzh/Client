namespace Client
{
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

    public partial class JTBitmSegPathEX : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private BindingSource _路段source = new BindingSource();
        private static string ERRORPATHAlARM = "解析行驶线路失败！";
        private DataTable m_dtPathGroup = new DataTable();
        private DataTable m_dtSegPathData = new DataTable();
        private PathAlarmList m_pathAlarmList = new PathAlarmList();

        public JTBitmSegPathEX(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._worker_RunWorkerCompleted);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
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
                        base.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(base.ParamType, str, base.sPw, CmdParam.CommMode.未知方式, this.m_pathAlarmList);
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                    }
                }
                else
                {
                    base.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_pathAlarmList);
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
                int val = 0;
                for (int i = 0; i < count; i++)
                {
                    if (selectedItems.Contains(innerControl.Items[i]))
                    {
                        ListBoxItem item = innerControl.Items[i] as ListBoxItem;
                        val |= Convert.ToInt32(item.Tag.ToString());
                        str = str + item.Name.ToString() + ",";
                    }
                }
                this.setTimeSpeedReadOnly(this.dgvSubSpeedParam.CurrentRow, val);
                list.Add(Convert.ToString(val, 2).PadLeft(6, '0').ToCharArray());
                if (this.dgvSubSpeedParam.CurrentCell != null)
                {
                    try
                    {
                        this.dgvSubSpeedParam.CurrentCell.Value = str.Trim(",".ToCharArray());
                        this.dgvSubSpeedParam.CurrentCell.Tag = list;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                innerControl.ClearSelected();
                if (this.dgvSubSpeedParam.CurrentCell.Tag == null)
                {
                    List<string> list2 = new List<string>();
                    list2.AddRange(this.dgvSubSpeedParam.CurrentCell.Value.ToString().Split(",".ToCharArray()));
                    int num4 = innerControl.Items.Count;
                    for (int j = 0; j < num4; j++)
                    {
                        ListBoxItem item2 = innerControl.Items[j] as ListBoxItem;
                        if (list2.Contains(item2.Name))
                        {
                            innerControl.SetSelected(j, true);
                        }
                    }
                }
                else if (this.dgvSubSpeedParam.CurrentCell.Tag != null)
                {
                    ArrayList tag = this.dgvSubSpeedParam.CurrentCell.Tag as ArrayList;
                    if ((tag[0] as char[])[0].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(4, true);
                    }
                    else
                    {
                        innerControl.SetSelected(4, false);
                    }
                    if ((tag[0] as char[])[1].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(3, true);
                    }
                    else
                    {
                        innerControl.SetSelected(3, false);
                    }
                    if ((tag[0] as char[])[2].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(2, true);
                    }
                    else
                    {
                        innerControl.SetSelected(2, false);
                    }
                    if ((tag[0] as char[])[3].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(1, true);
                    }
                    else
                    {
                        innerControl.SetSelected(1, false);
                    }
                    if ((tag[0] as char[])[5].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(0, true);
                    }
                    else
                    {
                        innerControl.SetSelected(0, false);
                    }
                }
            }
        }

        private void Add路段属性()
        {
            this.setPathSegment1.PathSegmentChanged += delegate (PathSegmentChangeArgs args) {
                if (args.IsClose)
                {
                    this.setPathSegment1.Visible = false;
                    this.setPathSegment1.SendToBack();
                }
                else
                {
                    foreach (DataRow row in this.setPathSegment1.SegmentData.Rows)
                    {
                        try
                        {
                            row.Table.Columns["Pathid"].ReadOnly = false;
                            DataRow row2 = this._路段属性DT.Rows.Find(row["PathSegmentID"].ToString());
                            if (row2 != null)
                            {
                                foreach (DataColumn column in row.Table.Columns)
                                {
                                    if (!column.ColumnName.Equals("PathSegmentID", StringComparison.OrdinalIgnoreCase))
                                    {
                                        row2[column.ColumnName] = row[column.ColumnName];
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Record.execFileRecord("分段路线路段属性设置", exception.Message);
                        }
                    }
                    this.dgvSubSpeedParam.CurrentCell.Value = args.IsSet ? "已设置" : "设置";
                }
            };
        }

        private void Add路线属性()
        {
            ListBoxEx con = new ListBoxEx {
                Width = 160,
                Height = 100,
                ItemHeight = 16
            };
            ListBoxItem item = new ListBoxItem("根据时间", "0") {
                Tag = 1
            };
            ListBoxItem item2 = new ListBoxItem("进路线报警给驾驶员", "2") {
                Tag = 4
            };
            ListBoxItem item3 = new ListBoxItem("进路线报警给平台", "3") {
                Tag = 8
            };
            ListBoxItem item4 = new ListBoxItem("出路线报警给驾驶员", "4") {
                Tag = 16
            };
            ListBoxItem item5 = new ListBoxItem("出路线报警给平台", "5") {
                Tag = 32
            };
            con.DrawMode = DrawMode.OwnerDrawFixed;
            con.FormattingEnabled = true;
            con.IsCheckBox = true;
            con.SelectionMode = SelectionMode.MultiSimple;
            con.Items.AddRange(new object[] { item, item2, item3, item4, item5 });
            this._路线属性 = new AutoDropDown(con);
            base.Controls.Add(this._路线属性);
            this._路线属性.VisibilityChange += new VisibleChanged(this._路线属性_VisibilityChange);
        }

        private void btmAllSelect_Click(object sender, EventArgs e)
        {
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有预设路线！");
            }
            else if (this.btmAllSelect.Text == "全选")
            {
                foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
                {
                    if (row.Cells["Choose"].Value.ToString() != "1")
                    {
                        row.Cells["Choose"].Value = true;
                    }
                }
                this.btmAllSelect.Text = "全不选";
            }
            else
            {
                foreach (DataGridViewRow row2 in (IEnumerable) this.dgvSubSpeedParam.Rows)
                {
                    if (row2.Cells["Choose"].Value.ToString() == "1")
                    {
                        row2.Cells["Choose"].Value = false;
                    }
                }
                this.btmAllSelect.Text = "全选";
            }
        }

        private void btnCopyToSelected_Click(object sender, EventArgs e)
        {
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有预设路线！");
            }
            else
            {
                int rowIndex = this.dgvSubSpeedParam.CurrentCell.RowIndex;
                if ((rowIndex >= 0) && (rowIndex <= this.dgvSubSpeedParam.Rows.Count))
                {
                    if ((((this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value == null) || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value == null)) || ((this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value == null) || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value == null))) || (((this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value.ToString() == "") || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value.ToString() == "")) || ((this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value.ToString() == "") || (this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value.ToString() == ""))))
                    {
                        MessageBox.Show("请输入数据或选择有数据的行");
                    }
                    else
                    {
                        foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
                        {
                            if (row.Cells["Choose"].Value.ToString() == "1")
                            {
                                row.Cells["TopSpeed"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value;
                                row.Cells["HoldTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value;
                                row.Cells["BeginTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value;
                                row.Cells["EndTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value;
                            }
                        }
                    }
                }
            }
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if ((!string.IsNullOrEmpty(base.sValue) && this.getParam()) && !this._worker.IsBusy)
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

        private void Clear路段属性(int rowindex)
        {
            string str = this.dgvSubSpeedParam.Rows[rowindex].Cells["PathID"].Value.ToString();
            this.dgvSubSpeedParam.Rows[rowindex].Cells["路段属性"].Value = "设置";
            if ((this._路段属性DT != null) && (this._路段属性DT.Rows.Count > 0))
            {
                DataRow[] rowArray = this._路段属性DT.Select("Pathid='" + str + "'");
                if ((rowArray != null) && (rowArray.Length > 0))
                {
                    foreach (DataRow row in rowArray)
                    {
                        row["HoldTime"] = DBNull.Value;
                        row["DriEnough"] = DBNull.Value;
                        row["TopSpeed"] = DBNull.Value;
                        row["DriNoEnough"] = DBNull.Value;
                    }
                }
            }
        }

        private void dgvSubSpeedParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                int rowIndex = e.RowIndex;
                DataGridViewCell cell = this.dgvSubSpeedParam.Rows[rowIndex].Cells[e.ColumnIndex];
                if ((((cell.OwningColumn.Name == "TopSpeed") || (cell.OwningColumn.Name == "HoldTime")) || ((cell.OwningColumn.Name == "BeginTime") || (cell.OwningColumn.Name == "EndTime"))) || ((cell.OwningColumn.Name == "行驶最长时间") || (cell.OwningColumn.Name == "行驶最短时间")))
                {
                    DataGridViewCell cell2 = this.dgvSubSpeedParam.Rows[rowIndex].Cells["Choose"];
                    if (!string.IsNullOrEmpty(cell2.Value.ToString()) && (cell2.Value.ToString() == "1"))
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = false;
                    }
                    else
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["路线属性"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["路线属性"].Tag = null;
                    }
                    cell2 = null;
                }
            }
        }

        private void dgvSubSpeedParam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                int rowIndex = e.RowIndex;
                DataGridViewCell cell = this.dgvSubSpeedParam.Rows[rowIndex].Cells["Choose"];
                if ((!this.setPathSegment1.Visible && this.dgvSubSpeedParam[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("路段属性")) && (!string.IsNullOrEmpty(cell.Value.ToString()) && (cell.Value.ToString() == "1")))
                {
                    this._路段source.Filter = "PathID='" + this.dgvSubSpeedParam.Rows[e.RowIndex].Cells["PathID"].Value.ToString() + "'";
                    if (this._路段属性DT != null)
                    {
                        DataTable data = this._路段属性DT.Clone();
                        for (int i = 0; i < this._路段source.List.Count; i++)
                        {
                            data.Rows.Add((this._路段source.List[i] as DataRowView).Row.ItemArray);
                        }
                        this.setPathSegment1.Init(data);
                        this.setPathSegment1.Visible = true;
                        this.setPathSegment1.BringToFront();
                    }
                }
            }
        }

        private void dgvSubSpeedParam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = ((DataGridView) sender).CurrentCell;
            int rowIndex = e.RowIndex;
            if ((e.RowIndex >= 0) && ((currentCell.ColumnIndex == this.dgvSubSpeedParam.Columns["BeginTime"].Index) || (currentCell.ColumnIndex == this.dgvSubSpeedParam.Columns["EndTime"].Index)))
            {
                DataGridViewCell cell2 = this.dgvSubSpeedParam.Rows[e.RowIndex].Cells["Choose"];
                if ((!string.IsNullOrEmpty(cell2.Value.ToString()) && (cell2.Value.ToString() == "1")) && this.isSetTime(rowIndex))
                {
                    SetDateTime time = new SetDateTime(currentCell.Value.ToString(), false); ///ToString
                    if (time.ShowDialog() == DialogResult.OK)
                    {
                        currentCell.Value = time.Time;
                        this.dgvSubSpeedParam.EndEdit();
                    }
                }
            }
            else if (currentCell.OwningColumn.Name.Equals("路线属性"))
            {
                DataGridViewCell cell3 = this.dgvSubSpeedParam.Rows[e.RowIndex].Cells["Choose"];
                if (!string.IsNullOrEmpty(cell3.Value.ToString()) && (cell3.Value.ToString() == "1"))
                {
                    System.Drawing.Point location = this.dgvSubSpeedParam.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    this._路线属性.ShowDropDown(new System.Drawing.Point(location.X + 3, (location.Y + this._路线属性.Height) + 150));
                }
            }
        }

        private void dgvSubSpeedParam_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                DataGridViewCell cell = this.dgvSubSpeedParam.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    this.dgvSubSpeedParam.EndEdit();
                }
            }
        }

        private void dgvSubSpeedParam_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                int rowIndex = e.RowIndex;
                DataGridViewCell cell = this.dgvSubSpeedParam.Rows[rowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "Choose")
                {
                    if (!string.IsNullOrEmpty(cell.Value.ToString()) && (cell.Value.ToString() == "1"))
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = false;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["newPathID"].ReadOnly = false;
                    }
                    else
                    {
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value = "";
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value = "";
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].ReadOnly = true;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["路线属性"].Value = DBNull.Value;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["路线属性"].Tag = null;
                        this.dgvSubSpeedParam.Rows[rowIndex].Cells["newPathID"].ReadOnly = true;
                        this.Clear路段属性(rowIndex);
                    }
                }
            }
        }

        private void dgvSubSpeedParam_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (this.dgvSubSpeedParam[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("行驶最长时间") || this.dgvSubSpeedParam[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("行驶最短时间"))
            {
                MessageBox.Show("您的输入不正确!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }
        }

        private void dgvSubSpeedParam_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = this.dgvSubSpeedParam.CurrentCell.ColumnIndex;
            if (((this.dgvSubSpeedParam.Columns[columnIndex].Name == "TopSpeed") || (this.dgvSubSpeedParam.Columns[columnIndex].Name == "HoldTime")) || ((this.dgvSubSpeedParam.Columns[columnIndex].Name == "行驶最长时间") || (this.dgvSubSpeedParam.Columns[columnIndex].Name == "行驶最短时间")))
            {
                this.EditingControl = (DataGridViewTextBoxEditingControl) e.Control;
                this.EditingControl.KeyPress += new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
        }

 private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private void execDistinctData(string sFilter)
        {
            DataView defaultView = this.m_dtSegPathData.DefaultView;
            defaultView.RowFilter = sFilter;
            string[] columnNames = new string[this.dgvSubSpeedParam.Columns.Count];
            for (int i = 0; i < this.dgvSubSpeedParam.Columns.Count; i++)
            {
                columnNames[i] = this.dgvSubSpeedParam.Columns[i].DataPropertyName;
            }
            DataTable table = defaultView.ToTable(true, columnNames);
            this.dgvSubSpeedParam.DataSource = table;
        }

        private int GeneralDomainTextToVal(string text)
        {
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            int count = innerControl.Items.Count;
            int num2 = 0;
            for (int i = 0; i < count; i++)
            {
                if (text.Contains(innerControl.Items[i].ToString()))
                {
                    ListBoxItem item = innerControl.Items[i] as ListBoxItem;
                    num2 |= Convert.ToInt32(item.Tag.ToString());
                }
            }
            return num2;
        }

        private void GeneralDomainValue(int val, out string showtext)
        {
            string str = "";
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            int count = innerControl.Items.Count;
            char[] chArray = Convert.ToString(val, 2).PadLeft(6, '0').ToCharArray();
            if (chArray[0].ToString().Equals("1"))
            {
                ListBoxItem item = innerControl.Items[4] as ListBoxItem;
                str = str + item.Name + ",";
            }
            if (chArray[1].ToString().Equals("1"))
            {
                ListBoxItem item2 = innerControl.Items[3] as ListBoxItem;
                str = str + item2.Name + ",";
            }
            if (chArray[2].ToString().Equals("1"))
            {
                ListBoxItem item3 = innerControl.Items[2] as ListBoxItem;
                str = str + item3.Name + ",";
            }
            if (chArray[3].ToString().Equals("1"))
            {
                ListBoxItem item4 = innerControl.Items[1] as ListBoxItem;
                str = str + item4.Name + ",";
            }
            if (chArray[5].ToString().Equals("1"))
            {
                ListBoxItem item5 = innerControl.Items[0] as ListBoxItem;
                str = str + item5.Name + ",";
            }
            showtext = str.Trim(new char[] { ',' });
        }

        private string getCheckPathName()
        {
            string str = "";
            foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
            {
                if (row.Cells["Choose"].Value.ToString() == "1")
                {
                    str = str + "'" + row.Cells["PathName"].Value.ToString() + "',";
                }
            }
            return str.Trim(new char[] { ',' });
        }

        private bool getParam()
        {
            string str = "";
            string str2 = this.getCheckPathName();
            if (string.IsNullOrEmpty(str2))
            {
                MessageBox.Show("没有选择预设路线！");
                return false;
            }
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有路线");
                return false;
            }
            DataTable table = RemotingClient.Car_GetPathRouteByPathName(str2);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                MessageBox.Show("没有读取到偏移路线数据，请重新设置");
                return false;
            }
            if (this.IsIDRepeat())
            {
                return false;
            }
            bool flag = false;
            DataView defaultView = (this.dgvSubSpeedParam.DataSource as DataTable).DefaultView;
            defaultView.RowFilter = "PathSegment='已设置'";
            if (defaultView.Count > 0)
            {
                flag = true;
            }
            defaultView.RowFilter = "";
            foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
            {
                if (row.Cells["Choose"].Value.ToString() == "1")
                {
                    string str3 = row.Cells["PathName"].Value.ToString();
                    str = str + "路线名称：" + str3 + Environment.NewLine;
                    int num = Convert.ToInt32(row.Cells["PathId"].Value.ToString());
                    PathAlarm alarm = new PathAlarm();
                    ArrayList list = new ArrayList();
                    alarm.Points = list;
                    alarm.ParentID = num;
                    alarm.ID = Convert.ToInt32(row.Cells["newPathID"].Value.ToString());
                    alarm.PathName = str3;
                    DataView view2 = new DataView(table, "PathName='" + str3 + "'", "", DataViewRowState.CurrentRows);
                    string str4 = string.Empty;
                    if ((view2 != null) && (view2.Count > 0))
                    {
                        str4 = view2[0]["alarmPathDot"].ToString();
                    }
                    if (string.IsNullOrEmpty(str4))
                    {
                        MessageBox.Show(ERRORPATHAlARM);
                        return false;
                    }
                    string[] strArray = str4.Split(new char[] { '/' });
                    alarm.PointCount = strArray.Length;
                    for (int i = 0; i < (strArray.Length - 1); i++)
                    {
                        if (string.IsNullOrEmpty(strArray[i]))
                        {
                            MessageBox.Show(ERRORPATHAlARM);
                            return false;
                        }
                        string[] strArray2 = strArray[i].Split(new char[] { '*' });
                        if (strArray2.Length != 2)
                        {
                            MessageBox.Show(ERRORPATHAlARM);
                            return false;
                        }
                        ParamLibrary.CmdParamInfo.Point point = new ParamLibrary.CmdParamInfo.Point {
                            Longitude = double.Parse(strArray2[0]),
                            Latitude = double.Parse(strArray2[1])
                        };
                        list.Add(point);
                    }
                    row.Cells["TopSpeed"].Value.ToString();
                    row.Cells["HoldTime"].Value.ToString();
                    if (row.Cells["路线属性"].Value.ToString().Trim().Length == 0)
                    {
                        MessageBox.Show("路线\"" + str3 + "\"的路线属性没有设置！");
                        return false;
                    }
                    if (!row.Cells["路段属性"].Value.ToString().Equals("已设置"))
                    {
                        MessageBox.Show("路线\"" + str3 + "\"的路段属性没有设置！");
                        return false;
                    }
                    if (row.Cells["路线属性"].Value.ToString().IndexOf("根据时间") >= 0)
                    {
                        string strDate = row.Cells["BeginTime"].Value.ToString();
                        string str6 = row.Cells["EndTime"].Value.ToString();
                        string strResultDate = string.Empty;
                        string str8 = string.Empty;
                        if (strDate.Length == 0)
                        {
                            MessageBox.Show("路线\"" + str3 + "\"没有设置起始时间！");
                            return false;
                        }
                        if (str6.Length == 0)
                        {
                            MessageBox.Show("路线\"" + str3 + "\"没有设置终止时间！");
                            return false;
                        }
                        if (!PublicClass.Check.CheckIsDate(strDate, out strResultDate))
                        {
                            MessageBox.Show("路线\"" + str3 + "\"起始时间格式有误！");
                            return false;
                        }
                        if (!PublicClass.Check.CheckIsDate(str6, out str8))
                        {
                            MessageBox.Show("路线\"" + str3 + "\"终止时间格式有误！");
                            return false;
                        }
                        if (Convert.ToDateTime(strDate) > Convert.ToDateTime(str6))
                        {
                            MessageBox.Show("路线\"" + str3 + "\"的起始时间不能大于终止时间！");
                            return false;
                        }
                        alarm.BeginTime = strDate;
                        str = str + "起始时间：" + strDate + Environment.NewLine;
                        alarm.EndTime = str6;
                        str = str + "终止时间：" + str6 + Environment.NewLine;
                        alarm.sBeginTime = strResultDate;
                        alarm.sEndTime = str8;
                        string str9 = alarm.BeginTime.Substring(0, 4);
                        string str10 = alarm.EndTime.Substring(0, 4);
                        if (((str9 == "0000") && (str10 != "0000")) || ((str10 == "0000") && (str9 != "0000")))
                        {
                            MessageBox.Show("路线\"" + str3 + "\"设置起始时间和终止时间时，固定时段参数勾选状态需保持一致！");
                            return false;
                        }
                        if ((str9 != "0000") && (DateTime.Parse(alarm.BeginTime) > DateTime.Parse(alarm.EndTime)))
                        {
                            MessageBox.Show("路线\"" + str3 + "\"起始时间不能大于终止时间！");
                            return false;
                        }
                    }
                    if (row.Cells["路段属性"].Value.ToString().Equals("已设置"))
                    {
                        DataRow[] rowArray = this._路段属性DT.Select("PathID = '" + num + "'", "PathSegmentID Asc");
                        if ((rowArray != null) && (rowArray.Length > 0))
                        {
                            if ((row.Cells["路线属性"].Tag == null) && (row.Cells["路线属性"].Value.ToString().Trim().Length > 0))
                            {
                                alarm.PathFlag = this.GeneralDomainTextToVal(row.Cells["路线属性"].Value.ToString());
                            }
                            else if (row.Cells["路线属性"].Tag != null)
                            {
                                alarm.PathFlag = this.GeneralDomainTextToVal(row.Cells["路线属性"].Value.ToString());
                            }
                            List<PathSegmentAlarm> list2 = new List<PathSegmentAlarm>();
                            str = str + "路线属性：" + alarm.PathFlag.ToString() + Environment.NewLine;
                            int num3 = 1;
                            for (int j = 0; j < rowArray.Length; j++)
                            {
                                int num5;
                                int num6;
                                int num7;
                                int num8;
                                DataRow row2 = rowArray[j];
                                PathSegmentAlarm item = new PathSegmentAlarm();
                                bool flag2 = false;
                                bool flag3 = false;
                                bool flag4 = false;
                                bool flag5 = false;
                                flag2 = int.TryParse(row2["DriEnough"].ToString(), out num5);
                                string str13 = str;
                                str = str13 + "路段" + row2["PathSegmentID"].ToString() + "DriEnough属性：" + num5.ToString() + Environment.NewLine;
                                flag3 = int.TryParse(row2["DriNoEnough"].ToString(), out num6);
                                string str14 = str;
                                str = str14 + "路段" + row2["PathSegmentID"].ToString() + "DriNoEnough属性：：" + num6.ToString() + Environment.NewLine;
                                flag4 = int.TryParse(row2["HoldTime"].ToString(), out num7);
                                string str15 = str;
                                str = str15 + "路段" + row2["PathSegmentID"].ToString() + "HoldTime属性：：" + num7.ToString() + Environment.NewLine;
                                flag5 = int.TryParse(row2["TopSpeed"].ToString(), out num8);
                                string str16 = str;
                                str = str16 + "路段" + row2["PathSegmentID"].ToString() + "TopSpeed属性：：" + num8.ToString() + Environment.NewLine;
                                if (flag2)
                                {
                                    item.DriEnough = new int?(num5);
                                }
                                str = str + "路段Flag" + row2["SegmentflagValue"].ToString() + Environment.NewLine;
                                if (flag3)
                                {
                                    item.DriNoEnough = new int?(num6);
                                }
                                if (flag4)
                                {
                                    item.HoldTime = new int?(num7);
                                }
                                item.PathId = num;
                                item.PathSegmentID = num3;
                                num3++;
                                item.PathSegmentDataBaseID = Convert.ToInt32(row2["PathSegmentID"].ToString());
                                if (flag5)
                                {
                                    item.TopSpeed = new int?(num8);
                                }
                                string[] strArray3 = row2["AlarmSegmentDot"].ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                if ((strArray3 == null) || (strArray3.Length == 0))
                                {
                                    MessageBox.Show("路线\"" + str3 + "\"的路段经纬度有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return false;
                                }
                                ArrayList list3 = new ArrayList();
                                string str17 = str;
                                str = str17 + "路段" + row2["PathSegmentID"].ToString() + "经纬度：：" + row2["AlarmSegmentDot"].ToString() + Environment.NewLine;
                                foreach (string str11 in strArray3)
                                {
                                    string[] strArray4 = str11.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                    for (int k = 0; k < strArray4.Length; k++)
                                    {
                                        string[] strArray5 = strArray4[k].Split(new char[] { '*' });
                                        ParamLibrary.CmdParamInfo.Point point2 = new ParamLibrary.CmdParamInfo.Point();
                                        if (strArray5.Length == 2)
                                        {
                                            point2.Latitude = Convert.ToDouble(strArray5[1]);
                                            point2.Longitude = Convert.ToDouble(strArray5[0]);
                                            if ((k != (strArray4.Length - 1)) || (j == (rowArray.Length - 1)))
                                            {
                                                list3.Add(point2);
                                            }
                                        }
                                    }
                                }
                                try
                                {
                                    item.PathWidth = Convert.ToInt32(row2["PathWidth"].ToString());
                                }
                                catch
                                {
                                    Record.execFileRecord("路线分路段报警设置", "路段宽度录入有误!");
                                }
                                item.Points = list3;
                                item.Flag = Convert.ToInt32(row2["SegmentflagValue"].ToString());
                                list2.Add(item);
                            }
                            alarm.PathSegmentAlarmList = list2;
                        }
                    }
                    else if (flag)
                    {
                        MessageBox.Show("请设置路线\"" + str3 + "\"的路段属性！");
                        return false;
                    }
                    this.m_pathAlarmList.Add(alarm);
                }
            }
            if ((this.m_pathAlarmList == null) || (this.m_pathAlarmList.Count < 0))
            {
                return false;
            }
            this.m_pathAlarmList.OrderCode = base.OrderCode;
            this.m_pathAlarmList.protocolType = CarProtocolType.交通厅;
            return true;
        }

        private void InitComboBox()
        {
            this.m_dtPathGroup = RemotingClient.Alarm_GetGroupType();
            if ((this.m_dtPathGroup == null) || (this.m_dtPathGroup.Rows.Count <= 0))
            {
                this.comboBoxLines.Items.Add("(无)");
                this.comboBoxLines.Text = "(无)";
            }
            else
            {
                DataRow row = this.m_dtPathGroup.NewRow();
                this.m_dtPathGroup.Rows.InsertAt(row, 0);
                this.comboBoxLines.DataSource = this.m_dtPathGroup;
            }
        }

        private void InitDataSource()
        {
            this.m_dtSegPathData.Columns.Add(new DataColumn("PathName"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("PathID"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("carID"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("Choose"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("IsChoose"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("HoldTime"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("TopSpeed"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("BeginTime"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("EndTime"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("PathGroupId"));
            this.m_dtSegPathData.Columns.Add(new DataColumn("PathFlag"));
            DataColumn column = new DataColumn("PathSegment") {
                DefaultValue = "设置"
            };
            this.m_dtSegPathData.Columns.Add(column);
            this.m_dtSegPathData.Columns.Add(new DataColumn("newPathID"));
        }

        private void InitGridView()
        {
            try
            {
                string strCarId = (base.sCarId.Split(",".ToCharArray()).Length > 1) ? base.sCarId.Split(",".ToCharArray())[0] : base.sCarId;
                DataTable table = RemotingClient.Car_GetPathAlarm(strCarId);
                this._路段属性DT = RemotingClient.Car_GetPathSegmentAlarm(strCarId);
                if (this._路段属性DT != null)
                {
                    DataTable table2 = this._路段属性DT.Clone();
                    Hashtable hashtable = new Hashtable();
                    foreach (DataRow row in this._路段属性DT.Rows)
                    {
                        if (!hashtable.ContainsKey(row["PathSegmentID"]))
                        {
                            table2.Rows.Add(row.ItemArray);
                            hashtable[row["PathSegmentID"]] = "";
                        }
                    }
                    this._路段属性DT = table2;
                    this._路段source.DataSource = this._路段属性DT;
                    DataColumn column = new DataColumn("SegmentFlagValue") {
                        DefaultValue = 0
                    };
                    this._路段属性DT.Columns.Add(column);
                    try
                    {
                        this._路段属性DT.PrimaryKey = new DataColumn[] { this._路段属性DT.Columns["PathSegmentID"] };
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("初始化路段数据时存在脏数据，请检查！");
                        Record.execFileRecord("分段路线报警设置-->获取数据时路段数据存在脏数据", exception.Message);
                    }
                }
                if (table != null)
                {
                    if (!table.Columns.Contains("PathFlag"))
                    {
                        table.Columns.Add(new DataColumn("PathFlag"));
                    }
                    table.Columns["PathFlag"].ReadOnly = false;
                    DataColumn column2 = new DataColumn("PathSegment") {
                        DefaultValue = "设置"
                    };
                    table.Columns.Add(column2);
                    List<string> list = new List<string>();
                    if ((this._路段属性DT != null) && (this._路段属性DT.Rows.Count > 0))
                    {
                        foreach (DataRow row2 in this._路段属性DT.Select("Flag is not null"))
                        {
                            if (!list.Contains(row2["PathID"].ToString()))
                            {
                                list.Add(row2["PathID"].ToString());
                            }
                            if (row2["Flag"] != null)
                            {
                                row2["SegmentFlagValue"] = row2["Flag"];
                                int result = 0;
                                string str2 = "";
                                if (int.TryParse(row2["Flag"].ToString(), out result))
                                {
                                    if ((result & 1) != 0)
                                    {
                                        str2 = str2 + "行驶时间,";
                                    }
                                    if ((result & 2) != 0)
                                    {
                                        str2 = str2 + "限速,";
                                    }
                                    if ((result & 4) != 0)
                                    {
                                        str2 = str2 + "南纬,";
                                    }
                                    if ((result & 8) != 0)
                                    {
                                        str2 = str2 + "西经,";
                                    }
                                    row2["Flag"] = str2.Trim(new char[] { ',' });
                                }
                            }
                        }
                    }
                    foreach (DataRow row3 in table.Rows)
                    {
                        if (this._路段属性DT.Select("PathId = '" + row3["PathID"].ToString() + "'").Length > 0)
                        {
                            DataRow row4 = this.m_dtSegPathData.NewRow();
                            row4["PathName"] = row3["PathName"];
                            row4["PathID"] = row3["PathID"];
                            row4["carID"] = row3["carID"];
                            row4["Choose"] = row3["Choose"];
                            row4["IsChoose"] = row3["IsChoose"];
                            row4["HoldTime"] = row3["HoldTime"];
                            row4["TopSpeed"] = row3["TopSpeed"];
                            row4["BeginTime"] = row3["BeginTime"];
                            row4["EndTime"] = row3["EndTime"];
                            row4["PathGroupID"] = row3["PathGroupID"];
                            row4["PathFlag"] = row3["PathFlag"];
                            int val = 0;
                            bool flag2 = (row3["choose"] != null) && row3["choose"].ToString().Equals("1");
                            if (list.Contains(row3["PathID"].ToString()) && flag2)
                            {
                                row4["PathSegment"] = "已设置";
                            }
                            if ((row3["PathFlag"] != null) && (row3["PathFlag"].ToString().Trim().Length > 0))
                            {
                                string showtext = "";
                                try
                                {
                                    val = Convert.ToInt32(row3["PathFlag"].ToString());
                                    if (val > 0)
                                    {
                                        this.GeneralDomainValue(val, out showtext);
                                        if (showtext.Length > 0)
                                        {
                                            row4["PathFlag"] = showtext;
                                        }
                                    }
                                    else
                                    {
                                        row4["PathFlag"] = DBNull.Value;
                                    }
                                }
                                catch
                                {
                                }
                                showtext = string.Empty;
                            }
                            row4["newPathID"] = row3["newPathID"];
                            this.m_dtSegPathData.Rows.Add(row4);
                        }
                    }
                    this.execDistinctData("");
                }
                this.dgvSubSpeedParam.Columns["Choose"].Tag = "Chk";
            }
            catch (Exception exception2)
            {
                Record.execFileRecord("分段路线报警设置-->获取数据时", exception2.Message);
            }
        }

 private bool IsIDRepeat()
        {
            DataTable dataSource = this.dgvSubSpeedParam.DataSource as DataTable;
            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                DataRow row = dataSource.Rows[i];
                if (row["Choose"].ToString().Equals("1"))
                {
                    int num2;
                    string str = row["newPathID"].ToString();
                    if (string.IsNullOrEmpty(str))
                    {
                        MessageBox.Show("下发ID不能为空。");
                        return true;
                    }
                    if (!int.TryParse(str, out num2) || (num2 < 0))
                    {
                        MessageBox.Show("ID只能为正整数。");
                        return true;
                    }
                    for (int j = i + 1; j < dataSource.Rows.Count; j++)
                    {
                        DataRow row2 = dataSource.Rows[j];
                        if (row2["Choose"].ToString().Equals("1"))
                        {
                            string str2 = row2["newPathID"].ToString();
                            if (str.Equals(str2))
                            {
                                MessageBox.Show("下发ID不能相同。");
                                return true;
                            }
                            if (!int.TryParse(str2, out num2) || (num2 < 0))
                            {
                                MessageBox.Show("ID只能为正整数。");
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool isSetTime(int rowIndex)
        {
            if (this.dgvSubSpeedParam.Rows[rowIndex].Cells["路线属性"].Value.ToString().IndexOf("根据时间") < 0)
            {
                return false;
            }
            return true;
        }

        private void itmSegPath_Load(object sender, EventArgs e)
        {
            if (base.OrderCode == CmdParam.OrderCode.设置分路段超速报警)
            {
                this.Text = "设置分段超速报警";
            }
            this.Add路线属性();
            this.Add路段属性();
            this.InitDataSource();
            this.InitGridView();
            this.InitComboBox();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = this.grpSetSubSpeedAlarmParam.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = this.btmAllSelect.Enabled = this.btnCopyToSelected.Enabled = isuse;
        }

        private void setTimeSpeedReadOnly(DataGridViewRow dgvr, int val)
        {
            if ((val & 1) == 0)
            {
                dgvr.Cells["BeginTime"].Value = "";
                dgvr.Cells["EndTime"].Value = "";
            }
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

        private void tsBtnFilter_Click(object sender, EventArgs e)
        {
            if ((this.comboBoxLines.SelectedValue == null) || this.comboBoxLines.SelectedValue.ToString().Equals(""))
            {
                this.execDistinctData("");
            }
            else
            {
                try
                {
                    string s = this.comboBoxLines.SelectedValue.ToString();
                    string sFilter = "pathGroupID =" + int.Parse(s);
                    this.execDistinctData(sFilter);
                }
                catch
                {
                }
            }
        }

        private void txtFindRegion_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in (IEnumerable) this.dgvSubSpeedParam.Rows)
            {
                if (row.Cells["PathName"].Value.ToString().Contains(this.txtFindRegion.Text))
                {
                    this.dgvSubSpeedParam.FirstDisplayedScrollingRowIndex = row.Index;
                    this.dgvSubSpeedParam.ClearSelection();
                    row.Cells["TopSpeed"].Selected = true;
                    break;
                }
            }
        }
    }
}

