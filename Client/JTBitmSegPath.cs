using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParamLibrary.CmdParamInfo;
using WinFormsUI.Controls;
using PublicClass;
using System.Collections;
using ParamLibrary.Application;
using Remoting;
using Library;

namespace Client
{
    public partial class JTBitmSegPath : Client.CarForm
    {
        private static string ERRORPATHAlARM = "解析行驶线路失败！";

        private DataTable m_dtSegPathData = new DataTable();

        private PathAlarmList m_pathAlarmList = new PathAlarmList();

        private DataTable m_dtPathGroup = new DataTable();

        private BackgroundWorker _worker = new BackgroundWorker();

        private DataTable _路段属性DT;

        private BindingSource _路段source = new BindingSource();

        private AutoDropDown _路线属性;

        private DataGridViewTextBoxEditingControl EditingControl;

        public JTBitmSegPath(CmdParam.OrderCode OrderCode)
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
                string[] strArrays = this.sValue.Split(new char[] { ',' });
                int length = (int)strArrays.Length;
                int num = 0;
                if (length <= 1)
                {
                    this.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(this.ParamType, this.sValue, this.sPw, CmdParam.CommMode.未知方式, this.m_pathAlarmList);
                }
                else
                {
                    string[] strArrays1 = strArrays;
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        string str = strArrays1[i];
                        this.reResult = RemotingClient.DownData_SetMultiSegSpeedAlarm(this.ParamType, str, this.sPw, CmdParam.CommMode.未知方式, this.m_pathAlarmList);
                        num++;
                        this._worker.ReportProgress((int)((double)num / (double)length * 100));
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
            Label label = this.lblWaitText;
            double progressPercentage = (double)e.ProgressPercentage / 100;
            label.Text = string.Concat("已完成：", progressPercentage.ToString("P").Replace(".00", ""));
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlEnable(true);
            if (this.reResult.ResultCode == (long)0)
            {
                base.DialogResult = DialogResult.OK;
                return;
            }
            MessageBox.Show(this.reResult.ErrorMsg);
        }

        private void _路线属性_VisibilityChange(bool isvisible)
        {
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            if (isvisible)
            {
                innerControl.ClearSelected();
                if (this.dgvSubSpeedParam.CurrentCell.Tag == null)
                {
                    List<string> strs = new List<string>();
                    strs.AddRange(this.dgvSubSpeedParam.CurrentCell.Value.ToString().Split(",".ToCharArray()));
                    int count = innerControl.Items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (strs.Contains((innerControl.Items[i] as ListBoxItem).Name))
                        {
                            innerControl.SetSelected(i, true);
                        }
                    }
                    return;
                }
                if (this.dgvSubSpeedParam.CurrentCell.Tag != null)
                {
                    ArrayList tag = this.dgvSubSpeedParam.CurrentCell.Tag as ArrayList;
                    if (!(tag[0] as char[])[0].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(4, false);
                    }
                    else
                    {
                        innerControl.SetSelected(4, true);
                    }
                    if (!(tag[0] as char[])[1].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(3, false);
                    }
                    else
                    {
                        innerControl.SetSelected(3, true);
                    }
                    if (!(tag[0] as char[])[2].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(2, false);
                    }
                    else
                    {
                        innerControl.SetSelected(2, true);
                    }
                    if (!(tag[0] as char[])[3].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(1, false);
                    }
                    else
                    {
                        innerControl.SetSelected(1, true);
                    }
                    if ((tag[0] as char[])[5].ToString().Equals("1"))
                    {
                        innerControl.SetSelected(0, true);
                        return;
                    }
                    innerControl.SetSelected(0, false);
                }
            }
            else
            {
                string str = "";
                List<string> strs1 = new List<string>();
                ListBox.SelectedObjectCollection selectedItems = innerControl.SelectedItems;
                int num = innerControl.Items.Count;
                ArrayList arrayLists = new ArrayList(num);
                int num1 = 0;
                for (int j = 0; j < num; j++)
                {
                    if (selectedItems.Contains(innerControl.Items[j]))
                    {
                        ListBoxItem item = innerControl.Items[j] as ListBoxItem;
                        num1 = num1 | Convert.ToInt32(item.Tag.ToString());
                        str = string.Concat(str, item.Name.ToString(), ",");
                    }
                }
                this.setTimeSpeedReadOnly(this.dgvSubSpeedParam.CurrentRow, num1);
                arrayLists.Add(Convert.ToString(num1, 2).PadLeft(6, '0').ToCharArray());
                if (this.dgvSubSpeedParam.CurrentCell != null)
                {
                    try
                    {
                        this.dgvSubSpeedParam.CurrentCell.Value = str.Trim(",".ToCharArray());
                        this.dgvSubSpeedParam.CurrentCell.Tag = arrayLists;
                    }
                    catch (Exception exception)
                    {
                    }
                }
            }
        }

        private void Add路段属性()
        {
            this.setPathSegment1.PathSegmentChanged += new PathSegmentChange((PathSegmentChangeArgs args) => {
                if (args.IsClose)
                {
                    this.setPathSegment1.Visible = false;
                    this.setPathSegment1.SendToBack();
                    return;
                }
                foreach (DataRow row in this.setPathSegment1.SegmentData.Rows)
                {
                    try
                    {
                        row.Table.Columns["Pathid"].ReadOnly = false;
                        DataRow item = this._路段属性DT.Rows.Find(row["PathSegmentID"].ToString());
                        if (item != null)
                        {
                            foreach (DataColumn column in row.Table.Columns)
                            {
                                if (column.ColumnName.Equals("PathSegmentID", StringComparison.OrdinalIgnoreCase))
                                {
                                    continue;
                                }
                                item[column.ColumnName] = row[column.ColumnName];
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Record.execFileRecord("分段路线路段属性设置", exception.Message);
                    }
                }
                this.dgvSubSpeedParam.CurrentCell.Value = (args.IsSet ? "已设置" : "设置");
            });
        }

        private void Add路线属性()
        {
            ListBoxEx listBoxEx = new ListBoxEx()
            {
                Width = 160,
                Height = 100,
                ItemHeight = 16
            };
            ListBoxItem listBoxItem = new ListBoxItem("根据时间", "0")
            {
                Tag = 1
            };
            ListBoxItem listBoxItem1 = new ListBoxItem("进路线报警给驾驶员", "2")
            {
                Tag = 4
            };
            ListBoxItem listBoxItem2 = new ListBoxItem("进路线报警给平台", "3")
            {
                Tag = 8
            };
            ListBoxItem listBoxItem3 = new ListBoxItem("出路线报警给驾驶员", "4")
            {
                Tag = 16
            };
            ListBoxItem listBoxItem4 = new ListBoxItem("出路线报警给平台", "5")
            {
                Tag = 32
            };
            listBoxEx.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxEx.FormattingEnabled = true;
            listBoxEx.IsCheckBox = true;
            listBoxEx.SelectionMode = SelectionMode.MultiSimple;
            ListBox.ObjectCollection items = listBoxEx.Items;
            object[] objArray = new object[] { listBoxItem, listBoxItem1, listBoxItem2, listBoxItem3, listBoxItem4 };
            items.AddRange(objArray);
            this._路线属性 = new AutoDropDown(listBoxEx);
            base.Controls.Add(this._路线属性);
            this._路线属性.VisibilityChange += new VisibleChanged(this._路线属性_VisibilityChange);
        }

        private void btmAllSelect_Click(object sender, EventArgs e)
        {
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有预设路线！");
                return;
            }
            if (this.btmAllSelect.Text == "全选")
            {
                foreach (DataGridViewRow row in (IEnumerable)this.dgvSubSpeedParam.Rows)
                {
                    if (row.Cells["Choose"].Value.ToString() == "1")
                    {
                        continue;
                    }
                    row.Cells["Choose"].Value = true;
                }
                this.btmAllSelect.Text = "全不选";
                return;
            }
            foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvSubSpeedParam.Rows)
            {
                if (dataGridViewRow.Cells["Choose"].Value.ToString() != "1")
                {
                    continue;
                }
                dataGridViewRow.Cells["Choose"].Value = false;
            }
            this.btmAllSelect.Text = "全选";
        }

        private void btnCopyToSelected_Click(object sender, EventArgs e)
        {
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有预设路线！");
                return;
            }
            int rowIndex = this.dgvSubSpeedParam.CurrentCell.RowIndex;
            if (rowIndex < 0 || rowIndex > this.dgvSubSpeedParam.Rows.Count)
            {
                return;
            }
            if (this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value == null || this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value == null || this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value == null || this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value == null || this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value.ToString() == "" || this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value.ToString() == "" || this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value.ToString() == "" || this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value.ToString() == "")
            {
                MessageBox.Show("请输入数据或选择有数据的行");
                return;
            }
            foreach (DataGridViewRow row in (IEnumerable)this.dgvSubSpeedParam.Rows)
            {
                if (row.Cells["Choose"].Value.ToString() != "1")
                {
                    continue;
                }
                row.Cells["TopSpeed"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value;
                row.Cells["HoldTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value;
                row.Cells["BeginTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["BeginTime"].Value;
                row.Cells["EndTime"].Value = this.dgvSubSpeedParam.Rows[rowIndex].Cells["EndTime"].Value;
            }
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(this.sValue))
                {
                    if (this.getParam())
                    {
                        if (!this._worker.IsBusy)
                        {
                            this.SetControlEnable(false);
                            this._worker.RunWorkerAsync();
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.SetControlEnable(true);
                MessageBox.Show(exception.Message);
            }
        }

        private void Clear路段属性(int rowindex)
        {
            string str = this.dgvSubSpeedParam.Rows[rowindex].Cells["PathID"].Value.ToString();
            this.dgvSubSpeedParam.Rows[rowindex].Cells["路段属性"].Value = "设置";
            if (this._路段属性DT != null && this._路段属性DT.Rows.Count > 0)
            {
                DataRow[] dataRowArray = this._路段属性DT.Select(string.Concat("Pathid='", str, "'"));
                if (dataRowArray != null && (int)dataRowArray.Length > 0)
                {
                    DataRow[] dataRowArray1 = dataRowArray;
                    for (int i = 0; i < (int)dataRowArray1.Length; i++)
                    {
                        DataRow value = dataRowArray1[i];
                        value["HoldTime"] = DBNull.Value;
                        value["DriEnough"] = DBNull.Value;
                        value["TopSpeed"] = DBNull.Value;
                        value["DriNoEnough"] = DBNull.Value;
                    }
                }
            }
        }

        private void dgvSubSpeedParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            DataGridViewCell item = this.dgvSubSpeedParam.Rows[rowIndex].Cells[e.ColumnIndex];
            if (item.OwningColumn.Name == "TopSpeed" || item.OwningColumn.Name == "HoldTime" || item.OwningColumn.Name == "BeginTime" || item.OwningColumn.Name == "EndTime" || item.OwningColumn.Name == "行驶最长时间" || item.OwningColumn.Name == "行驶最短时间")
            {
                DataGridViewCell dataGridViewCell = this.dgvSubSpeedParam.Rows[rowIndex].Cells["Choose"];
                if (string.IsNullOrEmpty(dataGridViewCell.Value.ToString()) || !(dataGridViewCell.Value.ToString() == "1"))
                {
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].Value = DBNull.Value;
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].Value = DBNull.Value;
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = true;
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = true;
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["路线属性"].Value = DBNull.Value;
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["路线属性"].Tag = null;
                }
                else
                {
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = false;
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = false;
                }
                dataGridViewCell = null;
            }
        }

        private void dgvSubSpeedParam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            DataGridViewCell item = this.dgvSubSpeedParam.Rows[rowIndex].Cells["Choose"];
            if (!this.setPathSegment1.Visible && this.dgvSubSpeedParam[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("路段属性") && !string.IsNullOrEmpty(item.Value.ToString()) && item.Value.ToString() == "1")
            {
                this._路段source.Filter = string.Concat("PathID='", this.dgvSubSpeedParam.Rows[e.RowIndex].Cells["PathID"].Value.ToString(), "'");
                if (this._路段属性DT == null)
                {
                    return;
                }
                DataTable dataTable = this._路段属性DT.Clone();
                for (int i = 0; i < this._路段source.List.Count; i++)
                {
                    dataTable.Rows.Add((this._路段source.List[i] as DataRowView).Row.ItemArray);
                }
                this.setPathSegment1.Init(dataTable);
                this.setPathSegment1.Visible = true;
                this.setPathSegment1.BringToFront();
            }
        }

        private void dgvSubSpeedParam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            DataGridViewCell currentCell = ((DataGridView)sender).CurrentCell;
            int rowIndex = e.RowIndex;
            if (e.RowIndex >= 0 && (currentCell.ColumnIndex == this.dgvSubSpeedParam.Columns["BeginTime"].Index || currentCell.ColumnIndex == this.dgvSubSpeedParam.Columns["EndTime"].Index))
            {
                DataGridViewCell item = this.dgvSubSpeedParam.Rows[e.RowIndex].Cells["Choose"];
                if (!string.IsNullOrEmpty(item.Value.ToString()) && item.Value.ToString() == "1" && this.isSetTime(rowIndex))
                {
                    SetDateTime setDateTime = new SetDateTime(string.Concat(currentCell.Value), false);
                    if (setDateTime.ShowDialog() == DialogResult.OK)
                    {
                        currentCell.Value = setDateTime.Time;
                        this.dgvSubSpeedParam.EndEdit();
                        return;
                    }
                }
            }
            else if (currentCell.OwningColumn.Name.Equals("路线属性"))
            {
                DataGridViewCell dataGridViewCell = this.dgvSubSpeedParam.Rows[e.RowIndex].Cells["Choose"];
                if (!string.IsNullOrEmpty(dataGridViewCell.Value.ToString()) && dataGridViewCell.Value.ToString() == "1")
                {
                    Rectangle cellDisplayRectangle = this.dgvSubSpeedParam.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    System.Drawing.Point location = cellDisplayRectangle.Location;
                    this._路线属性.ShowDropDown(new System.Drawing.Point(location.X + 3, location.Y + this._路线属性.Height + 150));
                }
            }
        }

        private void dgvSubSpeedParam_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (this.dgvSubSpeedParam.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof(DataGridViewCheckBoxCell))
            {
                this.dgvSubSpeedParam.EndEdit();
            }
        }

        private void dgvSubSpeedParam_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            DataGridViewCell item = this.dgvSubSpeedParam.Rows[rowIndex].Cells[e.ColumnIndex];
            if (item.OwningColumn.Name == "Choose")
            {
                if (!string.IsNullOrEmpty(item.Value.ToString()) && item.Value.ToString() == "1")
                {
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["TopSpeed"].ReadOnly = false;
                    this.dgvSubSpeedParam.Rows[rowIndex].Cells["HoldTime"].ReadOnly = false;
                    return;
                }
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
                this.Clear路段属性(rowIndex);
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
            if (this.dgvSubSpeedParam.Columns[columnIndex].Name == "TopSpeed" || this.dgvSubSpeedParam.Columns[columnIndex].Name == "HoldTime" || this.dgvSubSpeedParam.Columns[columnIndex].Name == "行驶最长时间" || this.dgvSubSpeedParam.Columns[columnIndex].Name == "行驶最短时间")
            {
                this.EditingControl = (DataGridViewTextBoxEditingControl)e.Control;
                this.EditingControl.KeyPress += new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
        }

        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void execDistinctData(string sFilter)
        {
            DataView defaultView = this.m_dtSegPathData.DefaultView;
            defaultView.RowFilter = sFilter;
            string[] dataPropertyName = new string[this.dgvSubSpeedParam.Columns.Count];
            for (int i = 0; i < this.dgvSubSpeedParam.Columns.Count; i++)
            {
                dataPropertyName[i] = this.dgvSubSpeedParam.Columns[i].DataPropertyName;
            }
            DataTable table = defaultView.ToTable(true, dataPropertyName);
            this.dgvSubSpeedParam.DataSource = table;
        }

        private int GeneralDomainTextToVal(string text)
        {
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            int count = innerControl.Items.Count;
            int num = 0;
            for (int i = 0; i < count; i++)
            {
                if (text.Contains(innerControl.Items[i].ToString()))
                {
                    ListBoxItem item = innerControl.Items[i] as ListBoxItem;
                    num = num | Convert.ToInt32(item.Tag.ToString());
                }
            }
            return num;
        }

        private void GeneralDomainValue(int val, out string showtext)
        {
            string str = "";
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            int count = innerControl.Items.Count;
            char[] charArray = Convert.ToString(val, 2).PadLeft(6, '0').ToCharArray();
            if (charArray[0].ToString().Equals("1"))
            {
                ListBoxItem item = innerControl.Items[4] as ListBoxItem;
                str = string.Concat(str, item.Name, ",");
            }
            if (charArray[1].ToString().Equals("1"))
            {
                ListBoxItem listBoxItem = innerControl.Items[3] as ListBoxItem;
                str = string.Concat(str, listBoxItem.Name, ",");
            }
            if (charArray[2].ToString().Equals("1"))
            {
                ListBoxItem item1 = innerControl.Items[2] as ListBoxItem;
                str = string.Concat(str, item1.Name, ",");
            }
            if (charArray[3].ToString().Equals("1"))
            {
                ListBoxItem listBoxItem1 = innerControl.Items[1] as ListBoxItem;
                str = string.Concat(str, listBoxItem1.Name, ",");
            }
            if (charArray[5].ToString().Equals("1"))
            {
                ListBoxItem item2 = innerControl.Items[0] as ListBoxItem;
                str = string.Concat(str, item2.Name, ",");
            }
            char[] chrArray = new char[] { ',' };
            showtext = str.Trim(chrArray);
        }

        private string getCheckPathName()
        {
            string str = "";
            foreach (DataGridViewRow row in (IEnumerable)this.dgvSubSpeedParam.Rows)
            {
                if (row.Cells["Choose"].Value.ToString() != "1")
                {
                    continue;
                }
                str = string.Concat(str, "'", row.Cells["PathName"].Value.ToString(), "',");
            }
            return str.Trim(new char[] { ',' });
        }

        private bool getParam()
        {
            int num;
            int num1;
            int num2;
            int num3;
            bool flag;
            string str = "";
            string checkPathName = this.getCheckPathName();
            if (string.IsNullOrEmpty(checkPathName))
            {
                MessageBox.Show("没有选择预设路线！");
                return false;
            }
            if (this.dgvSubSpeedParam.Rows.Count <= 0)
            {
                MessageBox.Show("没有路线");
                return false;
            }
            DataTable dataTable = RemotingClient.Car_GetPathRouteByPathName(checkPathName);
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                MessageBox.Show("没有读取到偏移路线数据，请重新设置");
                return false;
            }
            bool flag1 = false;
            DataView defaultView = (this.dgvSubSpeedParam.DataSource as DataTable).DefaultView;
            defaultView.RowFilter = "PathSegment='已设置'";
            if (defaultView.Count > 0)
            {
                flag1 = true;
            }
            defaultView.RowFilter = "";
            this.m_pathAlarmList.Clear();
            IEnumerator enumerator = ((IEnumerable)this.dgvSubSpeedParam.Rows).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DataGridViewRow current = (DataGridViewRow)enumerator.Current;
                    if (current.Cells["Choose"].Value.ToString() != "1")
                    {
                        continue;
                    }
                    string str1 = current.Cells["PathName"].Value.ToString();
                    str = string.Concat(str, "路线名称：", str1, Environment.NewLine);
                    int num4 = Convert.ToInt32(current.Cells["PathId"].Value.ToString());
                    PathAlarm pathAlarm = new PathAlarm();
                    ArrayList arrayLists = new ArrayList();
                    pathAlarm.Points = arrayLists;
                    pathAlarm.ParentID = num4;
                    pathAlarm.PathName = str1;
                    DataView dataViews = new DataView(dataTable, string.Concat("PathName='", str1, "'"), "", DataViewRowState.CurrentRows);
                    string empty = string.Empty;
                    if (dataViews != null && dataViews.Count > 0)
                    {
                        empty = dataViews[0]["alarmPathDot"].ToString();
                    }
                    if (!string.IsNullOrEmpty(empty))
                    {
                        char[] chrArray = new char[] { '/' };
                        string[] strArrays = empty.Split(chrArray);
                        pathAlarm.PointCount = (int)strArrays.Length;
                        int num5 = 0;
                        while (num5 < (int)strArrays.Length - 1)
                        {
                            if (!string.IsNullOrEmpty(strArrays[num5]))
                            {
                                string[] strArrays1 = strArrays[num5].Split(new char[] { '*' });
                                if ((int)strArrays1.Length == 2)
                                {
                                    ParamLibrary.CmdParamInfo.Point point = new ParamLibrary.CmdParamInfo.Point()
                                    {
                                        Longitude = double.Parse(strArrays1[0]),
                                        Latitude = double.Parse(strArrays1[1])
                                    };
                                    arrayLists.Add(point);
                                    num5++;
                                }
                                else
                                {
                                    MessageBox.Show(ERRORPATHAlARM);
                                    flag = false;
                                    return flag;
                                }
                            }
                            else
                            {
                                MessageBox.Show(ERRORPATHAlARM);
                                flag = false;
                                return flag;
                            }
                        }
                        current.Cells["TopSpeed"].Value.ToString();
                        current.Cells["HoldTime"].Value.ToString();
                        if (current.Cells["路线属性"].Value.ToString().Trim().Length == 0)
                        {
                            MessageBox.Show(string.Concat("路线\"", str1, "\"的路线属性没有设置！"));
                            flag = false;
                            return flag;
                        }
                        else if (current.Cells["路段属性"].Value.ToString().Equals("已设置"))
                        {
                            if (current.Cells["路线属性"].Value.ToString().IndexOf("根据时间") >= 0)
                            {
                                string str2 = current.Cells["BeginTime"].Value.ToString();
                                string str3 = current.Cells["EndTime"].Value.ToString();
                                string empty1 = string.Empty;
                                string empty2 = string.Empty;
                                if (str2.Length == 0)
                                {
                                    MessageBox.Show(string.Concat("路线\"", str1, "\"没有设置起始时间！"));
                                    flag = false;
                                    return flag;
                                }
                                else if (str3.Length == 0)
                                {
                                    MessageBox.Show(string.Concat("路线\"", str1, "\"没有设置终止时间！"));
                                    flag = false;
                                    return flag;
                                }
                                else if (!Check.CheckIsDate(str2, out empty1))
                                {
                                    MessageBox.Show(string.Concat("路线\"", str1, "\"起始时间格式有误！"));
                                    flag = false;
                                    return flag;
                                }
                                else if (!Check.CheckIsDate(str3, out empty2))
                                {
                                    MessageBox.Show(string.Concat("路线\"", str1, "\"终止时间格式有误！"));
                                    flag = false;
                                    return flag;
                                }
                                else if (Convert.ToDateTime(str2) <= Convert.ToDateTime(str3))
                                {
                                    pathAlarm.BeginTime = str2;
                                    str = string.Concat(str, "起始时间：", str2, Environment.NewLine);
                                    pathAlarm.EndTime = str3;
                                    str = string.Concat(str, "终止时间：", str3, Environment.NewLine);
                                    pathAlarm.sBeginTime = empty1;
                                    pathAlarm.sEndTime = empty2;
                                    string str4 = pathAlarm.BeginTime.Substring(0, 4);
                                    string str5 = pathAlarm.EndTime.Substring(0, 4);
                                    if (str4 == "0000" && str5 != "0000" || str5 == "0000" && str4 != "0000")
                                    {
                                        MessageBox.Show(string.Concat("路线\"", str1, "\"设置起始时间和终止时间时，固定时段参数勾选状态需保持一致！"));
                                        flag = false;
                                        return flag;
                                    }
                                    else if (str4 != "0000" && DateTime.Parse(pathAlarm.BeginTime) > DateTime.Parse(pathAlarm.EndTime))
                                    {
                                        MessageBox.Show(string.Concat("路线\"", str1, "\"起始时间不能大于终止时间！"));
                                        flag = false;
                                        return flag;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(string.Concat("路线\"", str1, "\"的起始时间不能大于终止时间！"));
                                    flag = false;
                                    return flag;
                                }
                            }
                            if (current.Cells["路段属性"].Value.ToString().Equals("已设置"))
                            {
                                DataRow[] dataRowArray = this._路段属性DT.Select(string.Concat("PathID = '", num4, "'"), "PathSegmentID Asc");
                                if (dataRowArray != null && (int)dataRowArray.Length > 0)
                                {
                                    if (current.Cells["路线属性"].Tag == null && current.Cells["路线属性"].Value.ToString().Trim().Length > 0)
                                    {
                                        pathAlarm.PathFlag = this.GeneralDomainTextToVal(current.Cells["路线属性"].Value.ToString());
                                    }
                                    else if (current.Cells["路线属性"].Tag != null)
                                    {
                                        pathAlarm.PathFlag = this.GeneralDomainTextToVal(current.Cells["路线属性"].Value.ToString());
                                    }
                                    List<PathSegmentAlarm> pathSegmentAlarms = new List<PathSegmentAlarm>();
                                    int pathFlag = pathAlarm.PathFlag;
                                    str = string.Concat(str, "路线属性：", pathFlag.ToString(), Environment.NewLine);
                                    DataRow[] dataRowArray1 = dataRowArray;
                                    int num6 = 0;
                                    while (num6 < (int)dataRowArray1.Length)
                                    {
                                        DataRow dataRow = dataRowArray1[num6];
                                        PathSegmentAlarm pathSegmentAlarm = new PathSegmentAlarm();
                                        bool flag2 = false;
                                        bool flag3 = false;
                                        bool flag4 = false;
                                        bool flag5 = false;
                                        flag2 = int.TryParse(dataRow["DriEnough"].ToString(), out num);
                                        string str6 = str;
                                        string[] strArrays2 = new string[] { str6, "路段", dataRow["PathSegmentID"].ToString(), "DriEnough属性：", num.ToString(), Environment.NewLine };
                                        str = string.Concat(strArrays2);
                                        flag3 = int.TryParse(dataRow["DriNoEnough"].ToString(), out num1);
                                        string str7 = str;
                                        string[] strArrays3 = new string[] { str7, "路段", dataRow["PathSegmentID"].ToString(), "DriNoEnough属性：：", num1.ToString(), Environment.NewLine };
                                        str = string.Concat(strArrays3);
                                        flag4 = int.TryParse(dataRow["HoldTime"].ToString(), out num2);
                                        string str8 = str;
                                        string[] strArrays4 = new string[] { str8, "路段", dataRow["PathSegmentID"].ToString(), "HoldTime属性：：", num2.ToString(), Environment.NewLine };
                                        str = string.Concat(strArrays4);
                                        flag5 = int.TryParse(dataRow["TopSpeed"].ToString(), out num3);
                                        string str9 = str;
                                        string[] strArrays5 = new string[] { str9, "路段", dataRow["PathSegmentID"].ToString(), "TopSpeed属性：：", num3.ToString(), Environment.NewLine };
                                        str = string.Concat(strArrays5);
                                        if (flag2)
                                        {
                                            pathSegmentAlarm.DriEnough = new int?(num);
                                        }
                                        str = string.Concat(str, "路段Flag", dataRow["SegmentflagValue"].ToString(), Environment.NewLine);
                                        if (flag3)
                                        {
                                            pathSegmentAlarm.DriNoEnough = new int?(num1);
                                        }
                                        if (flag4)
                                        {
                                            pathSegmentAlarm.HoldTime = new int?(num2);
                                        }
                                        pathSegmentAlarm.PathId = num4;
                                        pathSegmentAlarm.PathSegmentID = Convert.ToInt32(dataRow["PathSegmentID"].ToString());
                                        if (flag5)
                                        {
                                            pathSegmentAlarm.TopSpeed = new int?(num3);
                                        }
                                        string str10 = dataRow["AlarmSegmentDot"].ToString();
                                        string[] strArrays6 = new string[] { ";" };
                                        string[] strArrays7 = str10.Split(strArrays6, StringSplitOptions.RemoveEmptyEntries);
                                        if (strArrays7 == null || (int)strArrays7.Length == 0)
                                        {
                                            MessageBox.Show(string.Concat("路线\"", str1, "\"的路段经纬度有误!"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            flag = false;
                                            return flag;
                                        }
                                        else
                                        {
                                            ArrayList arrayLists1 = new ArrayList();
                                            string str11 = str;
                                            string[] strArrays8 = new string[] { str11, "路段", dataRow["PathSegmentID"].ToString(), "经纬度：：", dataRow["AlarmSegmentDot"].ToString(), Environment.NewLine };
                                            str = string.Concat(strArrays8);
                                            string[] strArrays9 = strArrays7;
                                            for (int i = 0; i < (int)strArrays9.Length; i++)
                                            {
                                                string str12 = strArrays9[i];
                                                chrArray = new char[] { '/' };
                                                string[] strArrays10 = str12.Split(chrArray);
                                                for (int j = 0; j < (int)strArrays10.Length; j++)
                                                {
                                                    string str13 = strArrays10[j];
                                                    chrArray = new char[] { '*' };
                                                    string[] strArrays11 = str13.Split(chrArray);
                                                    ParamLibrary.CmdParamInfo.Point point1 = new ParamLibrary.CmdParamInfo.Point();
                                                    if ((int)strArrays11.Length == 2)
                                                    {
                                                        point1.Latitude = Convert.ToDouble(strArrays11[1]);
                                                        point1.Longitude = Convert.ToDouble(strArrays11[0]);
                                                        arrayLists1.Add(point1);
                                                    }
                                                }
                                            }
                                            try
                                            {
                                                pathSegmentAlarm.PathWidth = Convert.ToInt32(dataRow["PathWidth"].ToString());
                                            }
                                            catch
                                            {
                                                Record.execFileRecord("路线分路段报警设置", "路段宽度录入有误!");
                                            }
                                            pathSegmentAlarm.Points = arrayLists1;
                                            pathSegmentAlarm.Flag = Convert.ToInt32(dataRow["SegmentflagValue"].ToString());
                                            pathSegmentAlarms.Add(pathSegmentAlarm);
                                            num6++;
                                        }
                                    }
                                    pathAlarm.PathSegmentAlarmList = pathSegmentAlarms;
                                }
                            }
                            else if (flag1)
                            {
                                MessageBox.Show(string.Concat("请设置路线\"", str1, "\"的路段属性！"));
                                flag = false;
                                return flag;
                            }
                            this.m_pathAlarmList.Add(pathAlarm);
                        }
                        else
                        {
                            MessageBox.Show(string.Concat("路线\"", str1, "\"的路段属性没有设置！"));
                            flag = false;
                            return flag;
                        }
                    }
                    else
                    {
                        MessageBox.Show(ERRORPATHAlARM);
                        flag = false;
                        return flag;
                    }
                }
                if (this.m_pathAlarmList == null || this.m_pathAlarmList.Count < 0)
                {
                    return false;
                }
                this.m_pathAlarmList.OrderCode = base.OrderCode;
                this.m_pathAlarmList.protocolType = CarProtocolType.交通厅;
                return true;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            return flag;
        }

        private void InitComboBox()
        {
            this.m_dtPathGroup = RemotingClient.Alarm_GetGroupType();
            if (this.m_dtPathGroup == null || this.m_dtPathGroup.Rows.Count <= 0)
            {
                this.comboBoxLines.Items.Add("(无)");
                this.comboBoxLines.Text = "(无)";
                return;
            }
            DataRow dataRow = this.m_dtPathGroup.NewRow();
            this.m_dtPathGroup.Rows.InsertAt(dataRow, 0);
            this.comboBoxLines.DataSource = this.m_dtPathGroup;
        }

        private void InitGridView()
        {
            try
            {
                string str = ((int)this.sCarId.Split(",".ToCharArray()).Length > 1 ? this.sCarId.Split(",".ToCharArray())[0] : this.sCarId);
                this.m_dtSegPathData = RemotingClient.Car_GetPathAlarm(str);
                this._路段属性DT = RemotingClient.Car_GetPathSegmentAlarm(str);
                if (this._路段属性DT != null)
                {
                    DataTable dataTable = this._路段属性DT.Clone();
                    Hashtable hashtables = new Hashtable();
                    foreach (DataRow row in this._路段属性DT.Rows)
                    {
                        if (hashtables.ContainsKey(row["PathSegmentID"]))
                        {
                            continue;
                        }
                        dataTable.Rows.Add(row.ItemArray);
                        hashtables[row["PathSegmentID"]] = "";
                    }
                    this._路段属性DT = dataTable;
                    this._路段source.DataSource = this._路段属性DT;
                    DataColumnCollection columns = this._路段属性DT.Columns;
                    DataColumn dataColumn = new DataColumn("SegmentFlagValue")
                    {
                        DefaultValue = 0
                    };
                    columns.Add(dataColumn);
                    try
                    {
                        DataTable dataTable1 = this._路段属性DT;
                        DataColumn[] item = new DataColumn[] { this._路段属性DT.Columns["PathSegmentID"] };
                        dataTable1.PrimaryKey = item;
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        MessageBox.Show("初始化路段数据时存在脏数据，请检查！");
                        Record.execFileRecord("分段路线报警设置-->获取数据时路段数据存在脏数据", exception.Message);
                    }
                }
                if (this.m_dtSegPathData != null)
                {
                    if (!this.m_dtSegPathData.Columns.Contains("PathFlag"))
                    {
                        this.m_dtSegPathData.Columns.Add(new DataColumn("PathFlag"));
                    }
                    this.m_dtSegPathData.Columns["PathFlag"].ReadOnly = false;
                    this.m_dtSegPathData.Columns.Add(new DataColumn("PathSegment")
                    {
                        DefaultValue = "设置"
                    });
                    List<string> strs = new List<string>();
                    if (this._路段属性DT != null && this._路段属性DT.Rows.Count > 0)
                    {
                        DataRow[] dataRowArray = this._路段属性DT.Select("Flag is not null");
                        for (int i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow = dataRowArray[i];
                            if (!strs.Contains(dataRow["PathID"].ToString()))
                            {
                                strs.Add(dataRow["PathID"].ToString());
                            }
                            if (dataRow["Flag"] != null)
                            {
                                dataRow["SegmentFlagValue"] = dataRow["Flag"];
                                int num = 0;
                                string str1 = "";
                                if (int.TryParse(dataRow["Flag"].ToString(), out num))
                                {
                                    if ((num & 1) != 0)
                                    {
                                        str1 = string.Concat(str1, "行驶时间,");
                                    }
                                    if ((num & 2) != 0)
                                    {
                                        str1 = string.Concat(str1, "限速,");
                                    }
                                    if ((num & 4) != 0)
                                    {
                                        str1 = string.Concat(str1, "南纬,");
                                    }
                                    if ((num & 8) != 0)
                                    {
                                        str1 = string.Concat(str1, "西经,");
                                    }
                                    char[] chrArray = new char[] { ',' };
                                    dataRow["Flag"] = str1.Trim(chrArray);
                                }
                            }
                        }
                    }
                    foreach (DataRow value in this.m_dtSegPathData.Rows)
                    {
                        int num1 = 0;
                        bool flag = (value["choose"] == null || !value["choose"].ToString().Equals("1") ? false : true);
                        if (strs.Contains(value["PathID"].ToString()) && flag)
                        {
                            value["PathSegment"] = "已设置";
                        }
                        if (value["PathFlag"] == null || value["PathFlag"].ToString().Trim().Length <= 0)
                        {
                            continue;
                        }
                        string empty = "";
                        try
                        {
                            num1 = Convert.ToInt32(value["PathFlag"].ToString());
                            if (num1 <= 0)
                            {
                                value["PathFlag"] = DBNull.Value;
                            }
                            else
                            {
                                this.GeneralDomainValue(num1, out empty);
                                if (empty.Length > 0)
                                {
                                    value["PathFlag"] = empty;
                                }
                            }
                        }
                        catch
                        {
                        }
                        empty = string.Empty;
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
            this.InitGridView();
            this.InitComboBox();
        }

        private void SetControlEnable(bool isuse)
        {
            PictureBox pictureBox = this.pbPicWait;
            bool flag = !isuse;
            bool flag1 = flag;
            this.lblWaitText.Visible = flag;
            pictureBox.Visible = flag1;
            base.ControlBox = isuse;
            GroupBox groupBox = this.grpCar;
            GroupBox groupBox1 = this.grpSetSubSpeedAlarmParam;
            Button button = this.btnCancel;
            Button button1 = this.btnOK;
            Button button2 = this.btmAllSelect;
            bool flag2 = isuse;
            bool flag3 = flag2;
            this.btnCopyToSelected.Enabled = flag2;
            bool flag4 = flag3;
            bool flag5 = flag4;
            button2.Enabled = flag4;
            bool flag6 = flag5;
            bool flag7 = flag6;
            button1.Enabled = flag6;
            bool flag8 = flag7;
            bool flag9 = flag8;
            button.Enabled = flag8;
            bool flag10 = flag9;
            bool flag11 = flag10;
            groupBox1.Enabled = flag10;
            groupBox.Enabled = flag11;
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
            int num1 = 1;
            while (num1 != 0)
            {
                num1 = value / 2;
                int num2 = value % 2;
                value = num1;
                num = num + num2;
                if (num1 == 0)
                {
                    continue;
                }
                num = num * 10;
            }
            string str = num.ToString();
            int length = str.Length;
            string empty = string.Empty;
            for (int i = 0; i < length; i++)
            {
                empty = string.Concat(str[i], empty);
            }
            return int.Parse(empty);
        }

        public int ToShijin(int value)
        {
            string str = value.ToString();
            int length = str.Length;
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                char chr = str[i];
                num = num + int.Parse(chr.ToString()) * (int)Math.Pow(2, (double)(length - 1 - i));
            }
            return num;
        }

        public int ToShijin2(int value)
        {
            int num = 0;
            int num1 = value;
            int num2 = 0;
            while (num1 != 0)
            {
                int num3 = num1 % 10;
                num1 = num1 / 10;
                num = num + num3 * (int)Math.Pow(2, (double)num2);
                num2++;
            }
            return num;
        }

        private void tsBtnFilter_Click(object sender, EventArgs e)
        {
            if (this.comboBoxLines.SelectedValue == null || this.comboBoxLines.SelectedValue.ToString().Equals(""))
            {
                this.execDistinctData("");
                return;
            }
            try
            {
                string str = this.comboBoxLines.SelectedValue.ToString();
                string str1 = string.Concat("pathGroupID =", int.Parse(str));
                this.execDistinctData(str1);
            }
            catch
            {
            }
        }

        private void txtFindRegion_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in (IEnumerable)this.dgvSubSpeedParam.Rows)
            {
                if (!row.Cells["PathName"].Value.ToString().Contains(this.txtFindRegion.Text))
                {
                    continue;
                }
                this.dgvSubSpeedParam.FirstDisplayedScrollingRowIndex = row.Index;
                this.dgvSubSpeedParam.ClearSelection();
                row.Cells["TopSpeed"].Selected = true;
                break;
            }
        }
    
    }
}
