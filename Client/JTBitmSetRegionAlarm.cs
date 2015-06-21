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
    using System.Threading;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBitmSetRegionAlarm : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private static string ERRORPATHAlARM = "解析区域失败！";
        private DataTable m_dtPathGroup = new DataTable();
        private DataTable m_dtRegion = new DataTable();
        private static int m_iSelectCntMax = 255;
        private RegionAlarmList m_RegionAlarmList = new RegionAlarmList();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBitmSetRegionAlarm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.dgvArea.NotMultiSelectedColumnName.Add("MainRegion");
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
                        if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
                        {
                            base.reResult = RemotingClient.DownData_SetRegionAlarm(base.ParamType, str, base.sPw, CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                        }
                        else
                        {
                            base.reResult = RemotingClient.DownData_SetRegionAlarm_FJYD(base.ParamType, str, base.sPw, CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                        }
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                        Thread.Sleep(50);
                    }
                }
                else if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
                {
                    base.reResult = RemotingClient.DownData_SetRegionAlarm(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                }
                else
                {
                    base.reResult = RemotingClient.DownData_SetRegionAlarm_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置分段偏移路线报警-->", exception.Message);
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

        private void _区域属性_VisibilityChange(bool isvisible)
        {
            ListBoxEx innerControl = this._区域属性.InnerControl as ListBoxEx;
            if (!isvisible)
            {
                string str = "";
                new List<string>();
                ListBox.SelectedObjectCollection selectedItems = innerControl.SelectedItems;
                int count = innerControl.Items.Count;
                ArrayList val = new ArrayList(count);
                for (int i = 0; i < count; i++)
                {
                    string str2 = "";
                    if (selectedItems.Contains(innerControl.Items[i]))
                    {
                        str2 = "1";
                        ListBoxItem item = innerControl.Items[i] as ListBoxItem;
                        str = str + item.Name.ToString() + ",";
                    }
                    else
                    {
                        str2 = "0";
                    }
                    val.Add(str2);
                }
                this.setTimeSpeedReadOnly(this.dgvArea.CurrentRow, val);
                if (this.dgvArea.CurrentCell != null)
                {
                    this.dgvArea.CurrentCell.Value = str.Trim(",".ToCharArray());
                    this.dgvArea.CurrentCell.Tag = val;
                }
            }
            else
            {
                innerControl.ClearSelected();
                if (this.dgvArea.CurrentCell.Tag == null)
                {
                    List<string> list2 = new List<string>();
                    list2.AddRange(this.dgvArea.CurrentCell.Value.ToString().Split(",".ToCharArray()));
                    int num3 = innerControl.Items.Count;
                    for (int j = 0; j < num3; j++)
                    {
                        ListBoxItem item2 = innerControl.Items[j] as ListBoxItem;
                        if (list2.Contains(item2.Name))
                        {
                            innerControl.SetSelected(j, true);
                        }
                    }
                }
                else if (this.dgvArea.CurrentCell.Tag != null)
                {
                    ArrayList tag = this.dgvArea.CurrentCell.Tag as ArrayList;
                    for (int k = 0; k < innerControl.Items.Count; k++)
                    {
                        innerControl.SetSelected(k, tag[k].ToString().Equals("1"));
                    }
                }
            }
        }

        private void Add区域属性()
        {
            ListBoxEx con = new ListBoxEx {
                Width = 160,
                Height = 140,
                ItemHeight = 16
            };
            ListBoxItem item = new ListBoxItem("根据时间", "0");
            ListBoxItem item2 = new ListBoxItem("限速", "1");
            ListBoxItem item3 = new ListBoxItem("进区域报警给驾驶员", "2");
            ListBoxItem item4 = new ListBoxItem("进区域报警给平台", "3");
            ListBoxItem item5 = new ListBoxItem("出区域报警给驾驶员", "4");
            ListBoxItem item6 = new ListBoxItem("出区域报警给平台", "5");
            ListBoxItem item7 = new ListBoxItem("南纬", "6");
            ListBoxItem item8 = new ListBoxItem("西经", "7");
            con.DrawMode = DrawMode.OwnerDrawFixed;
            con.FormattingEnabled = true;
            con.IsCheckBox = true;
            con.SelectionMode = SelectionMode.MultiSimple;
            con.Items.AddRange(new object[] { item, item2, item3, item4, item5, item6, item7, item8 });
            this._区域属性 = new AutoDropDown(con);
            base.Controls.Add(this._区域属性);
            this._区域属性.VisibilityChange += new VisibleChanged(this._区域属性_VisibilityChange);
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

        private bool chkSeletRegion()
        {
            if (this.IsIDRepeat())
            {
                return false;
            }
            return true;
        }

        private void dgvArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewCell cell = this.dgvArea.Rows[rowIndex].Cells[e.ColumnIndex];
                if (cell != null)
                {
                    if ((cell.OwningColumn.Name == "ColseGSm") || (cell.OwningColumn.Name == "ColseData"))
                    {
                        DataGridViewCell cell2 = this.dgvArea.Rows[rowIndex].Cells["InRegion"];
                        if (bool.Parse(cell2.Value.ToString()))
                        {
                            this.dgvArea.Rows[rowIndex].Cells["ColseGSm"].ReadOnly = false;
                            this.dgvArea.Rows[rowIndex].Cells["ColseData"].ReadOnly = false;
                            object obj2 = this.dgvArea.Rows[rowIndex].Cells[cell.OwningColumn.Name].Value;
                            this.dgvArea.Rows[rowIndex].Cells[cell.OwningColumn.Name].Value = (obj2 == null) ? ((object) 0) : ((object) !bool.Parse(obj2.ToString()));
                        }
                        else
                        {
                            this.dgvArea.Rows[rowIndex].Cells["ColseGSm"].Value = false;
                            this.dgvArea.Rows[rowIndex].Cells["ColseData"].Value = false;
                            this.dgvArea.Rows[rowIndex].Cells["ColseGSm"].ReadOnly = true;
                            this.dgvArea.Rows[rowIndex].Cells["ColseData"].ReadOnly = true;
                        }
                        cell2 = null;
                    }
                    if (base.OrderCode != CmdParam.OrderCode.设置多功能区域报警)
                    {
                        if (((cell.OwningColumn.Name == "distanceToBegin") || (cell.OwningColumn.Name == "distanceToEnd")) || ((cell.OwningColumn.Name == "planUpBeginTime") || (cell.OwningColumn.Name == "planDownBeginTime")))
                        {
                            DataGridViewCell cell3 = this.dgvArea.Rows[rowIndex].Cells["EndPoint"];
                            if (bool.Parse(cell3.Value.ToString()))
                            {
                                this.dgvArea.Rows[rowIndex].Cells["distanceToBegin"].ReadOnly = false;
                                this.dgvArea.Rows[rowIndex].Cells["distanceToEnd"].ReadOnly = false;
                                this.dgvArea.Rows[rowIndex].Cells["planUpBeginTime"].ReadOnly = false;
                                this.dgvArea.Rows[rowIndex].Cells["planDownBeginTime"].ReadOnly = false;
                            }
                            else
                            {
                                this.dgvArea.Rows[rowIndex].Cells["distanceToBegin"].Value = "";
                                this.dgvArea.Rows[rowIndex].Cells["distanceToEnd"].Value = "";
                                this.dgvArea.Rows[rowIndex].Cells["planUpBeginTime"].Value = "";
                                this.dgvArea.Rows[rowIndex].Cells["planDownBeginTime"].Value = "";
                                this.dgvArea.Rows[rowIndex].Cells["distanceToBegin"].ReadOnly = true;
                                this.dgvArea.Rows[rowIndex].Cells["distanceToEnd"].ReadOnly = true;
                                this.dgvArea.Rows[rowIndex].Cells["planUpBeginTime"].ReadOnly = true;
                                this.dgvArea.Rows[rowIndex].Cells["planDownBeginTime"].ReadOnly = true;
                            }
                            cell3 = null;
                        }
                        if ((cell.OwningColumn.Name == "beginTime") || (cell.OwningColumn.Name == "endTime"))
                        {
                            DataGridViewCell cell4 = this.dgvArea.Rows[rowIndex].Cells["StopPoint"];
                            if (bool.Parse(cell4.Value.ToString()))
                            {
                                this.dgvArea.Rows[rowIndex].Cells["beginTime"].ReadOnly = false;
                                this.dgvArea.Rows[rowIndex].Cells["endTime"].ReadOnly = false;
                            }
                            else
                            {
                                this.dgvArea.Rows[rowIndex].Cells["beginTime"].Value = "";
                                this.dgvArea.Rows[rowIndex].Cells["endTime"].Value = "";
                                this.dgvArea.Rows[rowIndex].Cells["beginTime"].ReadOnly = true;
                                this.dgvArea.Rows[rowIndex].Cells["endTime"].ReadOnly = true;
                            }
                            cell4 = null;
                        }
                    }
                }
            }
        }

        private void dgvArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
            {
                DataGridViewCell currentCell = ((DataGridView) sender).CurrentCell;
                if ((currentCell.ColumnIndex == this.dgvArea.Columns["BeginTime"].Index) || ((currentCell.ColumnIndex == this.dgvArea.Columns["EndTime"].Index) && this.isSetTime(currentCell.RowIndex)))
                {
                    SetDateTime time = new SetDateTime(currentCell.Value.ToString(), false); ///ToString
                    if (time.ShowDialog() == DialogResult.OK)
                    {
                        currentCell.Value = time.Time;
                    }
                }
                if (currentCell.ColumnIndex == this.dgvArea.Columns["AlarmCondition"].Index)
                {
                    SetAlarmCondition condition = new SetAlarmCondition(this.m_sCustName) {
                        AlarmCondition = currentCell.Value.ToString()
                    };
                    if (condition.ShowDialog() == DialogResult.OK)
                    {
                        currentCell.Value = condition.AlarmCondition;
                    }
                }
                if (currentCell.ColumnIndex == this.dgvArea.Columns["区域属性"].Index)
                {
                    System.Drawing.Point location = this.dgvArea.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    this._区域属性.ShowDropDown(new System.Drawing.Point(location.X + 3, (location.Y + this._区域属性.Height) + 150));
                }
            }
        }

        private void dgvArea_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                DataGridViewCell cell = this.dgvArea.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    this.dgvArea.EndEdit();
                }
            }
        }

        private void dgvArea_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewCell cell = this.dgvArea.Rows[rowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "InRegion")
                {
                    if (bool.Parse(cell.Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["OutRegion"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["InOutRegion"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["ColseGSm"].ReadOnly = false;
                        this.dgvArea.Rows[rowIndex].Cells["ColseData"].ReadOnly = false;
                    }
                    else
                    {
                        this.dgvArea.Rows[rowIndex].Cells["ColseGSm"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["ColseData"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["ColseGSm"].ReadOnly = true;
                        this.dgvArea.Rows[rowIndex].Cells["ColseData"].ReadOnly = true;
                        this.dgvArea.Rows[rowIndex].Cells["MainRegion"].Value = false;
                    }
                }
                if (cell.OwningColumn.Name == "OutRegion")
                {
                    if (bool.Parse(cell.Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["InRegion"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["InOutRegion"].Value = false;
                    }
                    else
                    {
                        this.dgvArea.Rows[rowIndex].Cells["MainRegion"].Value = false;
                    }
                }
                if ((cell.OwningColumn.Name == "InOutRegion") && bool.Parse(cell.Value.ToString()))
                {
                    this.dgvArea.Rows[rowIndex].Cells["InRegion"].Value = false;
                    this.dgvArea.Rows[rowIndex].Cells["OutRegion"].Value = false;
                }
                if ((cell.OwningColumn.Name == "MainRegion") && bool.Parse(cell.Value.ToString()))
                {
                    if (!bool.Parse(this.dgvArea.Rows[rowIndex].Cells["InRegion"].Value.ToString()) && !bool.Parse(this.dgvArea.Rows[rowIndex].Cells["OutRegion"].Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["MainRegion"].Value = false;
                    }
                    else
                    {
                        foreach (DataGridViewRow row in (IEnumerable) this.dgvArea.Rows)
                        {
                            try
                            {
                                if ((row.Index != cell.RowIndex) && Convert.ToBoolean(row.Cells["MainRegion"].Value))
                                {
                                    row.Cells["MainRegion"].Value = false;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                if (base.OrderCode != CmdParam.OrderCode.设置多功能区域报警)
                {
                    if ((cell.OwningColumn.Name == "StartPoint") && bool.Parse(cell.Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["PassPoint"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["EndPoint"].Value = false;
                    }
                    if ((cell.OwningColumn.Name == "PassPoint") && bool.Parse(cell.Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["StartPoint"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["EndPoint"].Value = false;
                    }
                    if (cell.OwningColumn.Name == "EndPoint")
                    {
                        if (bool.Parse(cell.Value.ToString()))
                        {
                            this.dgvArea.Rows[rowIndex].Cells["StartPoint"].Value = false;
                            this.dgvArea.Rows[rowIndex].Cells["PassPoint"].Value = false;
                            this.dgvArea.Rows[rowIndex].Cells["distanceToBegin"].ReadOnly = false;
                            this.dgvArea.Rows[rowIndex].Cells["distanceToEnd"].ReadOnly = false;
                            this.dgvArea.Rows[rowIndex].Cells["planUpBeginTime"].ReadOnly = false;
                            this.dgvArea.Rows[rowIndex].Cells["planDownBeginTime"].ReadOnly = false;
                        }
                        else
                        {
                            this.dgvArea.Rows[rowIndex].Cells["distanceToBegin"].Value = "";
                            this.dgvArea.Rows[rowIndex].Cells["distanceToEnd"].Value = "";
                            this.dgvArea.Rows[rowIndex].Cells["planUpBeginTime"].Value = "";
                            this.dgvArea.Rows[rowIndex].Cells["planDownBeginTime"].Value = "";
                            this.dgvArea.Rows[rowIndex].Cells["distanceToBegin"].ReadOnly = true;
                            this.dgvArea.Rows[rowIndex].Cells["distanceToEnd"].ReadOnly = true;
                            this.dgvArea.Rows[rowIndex].Cells["planUpBeginTime"].ReadOnly = true;
                            this.dgvArea.Rows[rowIndex].Cells["planDownBeginTime"].ReadOnly = true;
                        }
                    }
                    if (cell.OwningColumn.Name == "StopPoint")
                    {
                        if (bool.Parse(cell.Value.ToString()))
                        {
                            this.dgvArea.Rows[rowIndex].Cells["beginTime"].ReadOnly = false;
                            this.dgvArea.Rows[rowIndex].Cells["endTime"].ReadOnly = false;
                        }
                        else
                        {
                            this.dgvArea.Rows[rowIndex].Cells["beginTime"].Value = "";
                            this.dgvArea.Rows[rowIndex].Cells["endTime"].Value = "";
                            this.dgvArea.Rows[rowIndex].Cells["beginTime"].ReadOnly = true;
                            this.dgvArea.Rows[rowIndex].Cells["endTime"].ReadOnly = true;
                        }
                    }
                }
            }
        }

        private void dgvArea_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = this.dgvArea.CurrentCell.ColumnIndex;
            if ((this.dgvArea.Columns[columnIndex].Name == "最高时速") || (this.dgvArea.Columns[columnIndex].Name == "超速持续时间"))
            {
                this.EditingControl = (DataGridViewTextBoxEditingControl) e.Control;
                this.EditingControl.KeyPress += new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
            else if (this.EditingControl != null)
            {
                this.EditingControl.KeyPress -= new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
        }

        private void dgvArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (base.OrderCode == CmdParam.OrderCode.设置区域报警)
            {
                if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != ':')) && ((e.KeyChar != ',') && (e.KeyChar != '\b')))
                {
                    e.Handled = true;
                }
            }
            else if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != ':')) && ((e.KeyChar != ',') && (e.KeyChar != '\b')))
            {
                e.Handled = true;
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
            DataView defaultView = this.m_dtRegion.DefaultView;
            defaultView.RowFilter = sFilter;
            string[] columnNames = new string[this.dgvArea.Columns.Count];
            for (int i = 0; i < this.dgvArea.Columns.Count; i++)
            {
                columnNames[i] = this.dgvArea.Columns[i].DataPropertyName;
            }
            DataTable table = defaultView.ToTable(true, columnNames);
            this.dgvArea.DataSource = table;
            this.setInitReadOnly();
        }

        private ArrayList GeneralDomainText(string text)
        {
            ListBoxEx innerControl = this._区域属性.InnerControl as ListBoxEx;
            string str = "";
            int count = innerControl.Items.Count;
            ArrayList list = new ArrayList(count);
            for (int i = 0; i < count; i++)
            {
                string str2 = "";
                if (text.Contains(innerControl.Items[i].ToString()))
                {
                    str2 = "1";
                    ListBoxItem item = innerControl.Items[i] as ListBoxItem;
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
            ListBoxEx innerControl = this._区域属性.InnerControl as ListBoxEx;
            int count = innerControl.Items.Count;
            string str2 = Convert.ToString(val, 2).PadLeft(8, '0');
            for (int i = 0; i < count; i++)
            {
                if (str2.ToCharArray()[(count - i) - 1].ToString().Equals("1"))
                {
                    str = str + (innerControl.Items[i] as ListBoxItem).Name + ",";
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

        private string getAlarmCondition(string strAlarmCom)
        {
            string str = string.Empty;
            long alarmStatus = 0L;
            if (!string.IsNullOrEmpty(strAlarmCom))
            {
                alarmStatus = long.Parse(strAlarmCom);
            }
            if ((alarmStatus & 2L) != 0L)
            {
                str = str + "紧急报警,";
            }
            if ((alarmStatus & 16) != 0L)
            {
                str = str + "求助报警,";
            }
            if ((alarmStatus & 32) != 0L)
            {
                str = str + "位移报警,";
            }
            if ((alarmStatus & 256) != 0L)
            {
                str = str + "欠压报警,";
            }
            if ((alarmStatus & 4096) != 0L)
            {
                str = str + "超速报警,";
            }
            if ((alarmStatus & 512) != 0L)
            {
                str = str + "掉电报警,";
            }
            if ((alarmStatus & 2097152) != 0L)
            {
                str = str + "探测报警,";
            }
            if ((alarmStatus & 32768) != 0L)
            {
                str = str + "防盗报警,";
            }
            if ((alarmStatus & 4194304) != 0L)
            {
                str = str + "开油箱盖,";
            }
            if ((alarmStatus & 8388608) != 0L)
            {
                str = str + "刹车报警,";
            }
            if ((alarmStatus & 65536) != 0L)
            {
                str = str + "非法点火,";
            }
            if ((alarmStatus & 64) != 0L)
            {
                str = str + "超时停车,";
            }
            if ((alarmStatus & 128) != 0L)
            {
                str = str + "超时驾驶,";
            }
            if ((alarmStatus & 131072) != 0L)
            {
                str = str + "开车门,";
            }
            if ((alarmStatus & 262144) != 0L)
            {
                str = str + "开车窗,";
            }
            if ((alarmStatus & 524288) != 0L)
            {
                str = str + "开前盖,";
            }
            if ((alarmStatus & 1048576) != 0L)
            {
                str = str + "开后盖,";
            }
            if (string.IsNullOrEmpty(this.m_sCustName))
            {
                return str;
            }
            string[] strCustNameList = this.m_sCustName.Split(new char[] { '*' });
            if (strCustNameList.Length <= 0)
            {
                return str;
            }
            return (((str + this.GetCustName(alarmStatus, strCustNameList, "16777216", "自定义1", CmdParam.CarAlarmState.终端IO1输入) + this.GetCustName(alarmStatus, strCustNameList, "33554432", "自定义2", CmdParam.CarAlarmState.适配器S0)) + this.GetCustName(alarmStatus, strCustNameList, "67108864", "自定义3", CmdParam.CarAlarmState.适配器S1) + this.GetCustName(alarmStatus, strCustNameList, "134217728", "自定义4", CmdParam.CarAlarmState.适配器S2)) + this.GetCustName(alarmStatus, strCustNameList, "268435456", "自定义5", CmdParam.CarAlarmState.适配器S3) + this.GetCustName(alarmStatus, strCustNameList, "536870912", "自定义6", CmdParam.CarAlarmState.适配器S4)).Trim(new char[] { ',' });
        }

        private string GetCustName(long AlarmStatus, string[] strCustNameList, string value, string name, CmdParam.CarAlarmState state)
        {
            string str = string.Empty;
            if ((AlarmStatus & (long)state) == 0L)
            {
                return str;
            }
            if (strCustNameList.Length > 0)
            {
                for (int i = 0; i < strCustNameList.Length; i++)
                {
                    string[] strArray = strCustNameList[i].Split(new char[] { '/' });
                    if (strArray[0] == value)
                    {
                        return (str + strArray[1] + ",");
                    }
                }
                return str;
            }
            return (str + name + ",");
        }

        private long GetCustValue(string sName)
        {
            long num = 0L;
            if (!string.IsNullOrEmpty(this.m_sCustName))
            {
                foreach (string str in this.m_sCustName.Trim(new char[] { '*' }).Split(new char[] { '*' }))
                {
                    string[] strArray2 = str.Split(new char[] { '/' });
                    if (strArray2[1] == sName)
                    {
                        return long.Parse(strArray2[0]);
                    }
                }
                return num;
            }
            switch (sName)
            {
                case "自定义1":
                    return 16777216;

                case "自定义2":
                    return 33554432;

                case "自定义3":
                    return 67108864;

                case "自定义4":
                    return 134217728;

                case "自定义5":
                    return 268435456;

                case "自定义6":
                    return 536870912;
            }
            return num;
        }

        private long getMultiAlarmCondition(int iRow)
        {
            long num = 0L;
            if ((iRow >= 0) && (iRow < this.dgvArea.Rows.Count))
            {
                foreach (string str2 in this.dgvArea.Rows[iRow].Cells["alarmCondition"].Value.ToString().Trim().Trim(new char[] { ',' }).Split(new char[] { ',' }))
                {
                    switch (str2)
                    {
                        case "紧急报警":
                            num |= 2L;
                            break;

                        case "求助报警":
                            num |= 16;
                            break;

                        case "位移报警":
                            num |= 32;
                            break;

                        case "欠压报警":
                            num |= 256;
                            break;

                        case "超速报警":
                            num |= 4096;
                            break;

                        case "掉电报警":
                            num |= 512;
                            break;

                        case "探测报警":
                            num |= 2097152;
                            break;

                        case "防盗报警":
                            num |= 32768;
                            break;

                        case "开油箱盖":
                            num |= 4194304;
                            break;

                        case "刹车报警":
                            num |= 8388608;
                            break;

                        case "非法点火":
                            num |= 65536;
                            break;

                        case "超时停车":
                            num |= 64;
                            break;

                        case "超时驾驶":
                            num |= 128;
                            break;

                        case "开车门":
                            num |= 131072;
                            break;

                        case "开车窗":
                            num |= 262144;
                            break;

                        case "开前盖":
                            num |= 524288;
                            break;

                        case "开后盖":
                            num |= 1048576;
                            break;

                        default:
                            num |= this.GetCustValue(str2);
                            break;
                    }
                }
            }
            return num;
        }

        private bool getParam()
        {
            int num = 0;
            string str = "";
            int num2 = 0;
            string strDate = "";
            string str3 = "";
            string str4 = "";
            this.m_RegionAlarmList = new RegionAlarmList();
            if (!this.chkSeletRegion())
            {
                this.dgvArea.Focus();
                return false;
            }
            int num3 = 0;
            if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
            {
                this.m_RegionAlarmList.protocolType = CarProtocolType.交通厅;
                num3 = 1;
            }
            bool flag = true;
            for (int i = 0; i < this.dgvArea.Rows.Count; i++)
            {
                int num5 = this.getRegionType(i);
                if (this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().Trim().Length > 0)
                {
                    flag = false;
                    ArrayList list = new ArrayList();
                    RegionAlarm alarm = new RegionAlarm();
                    str = this.dgvArea.Rows[i].Cells["RegionName"].Value.ToString();   ///ToString
                    num2 = int.Parse(this.dgvArea.Rows[i].Cells["RegionId"].Value.ToString());
                    if (bool.Parse(this.dgvArea.Rows[i].Cells["MainRegion"].Value.ToString()))
                    {
                        alarm.newRegionId = 0;
                    }
                    else
                    {
                        alarm.newRegionId = num2;
                    }
                    alarm.PathName = str;
                    alarm.RegionType = num5;
                    alarm.RegionID = num2;
                    str4 = this.dgvArea.Rows[i].Cells["RegionDot"].Value.ToString(); ///
                    alarm.AlarmRegionDot = num5 + @"\" + str4.Replace("*", @"\").Trim(new char[] { '\\' });
                    string[] strArray = str4.Split(new char[] { '*' });
                    num += strArray.Length;
                    for (int j = 0; j < (strArray.Length - 1); j++)
                    {
                        if (string.IsNullOrEmpty(strArray[j]))
                        {
                            MessageBox.Show(ERRORPATHAlARM);
                            return false;
                        }
                        string[] strArray2 = strArray[j].Split(new char[] { '\\' });
                        if (strArray2.Length < 2)
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
                    alarm.Points = list;
                    strDate = this.dgvArea.Rows[i].Cells["beginTime"].Value.ToString(); ///
                    str3 = this.dgvArea.Rows[i].Cells["endTime"].Value.ToString(); ///
                    if (num3 == 1)
                    {
                        string strResultDate = "";
                        string str6 = "";
                        PublicClass.Check.CheckIsDate(strDate, out strResultDate);
                        PublicClass.Check.CheckIsDate(str3, out str6);
                        if ((this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().IndexOf("根据时间") >= 0) && ((strResultDate.Length == 0) || (str6.Length == 0)))
                        {
                            MessageBox.Show("区域\"" + str + "\"须设置起始时间和终止时间!");
                            return false;
                        }
                        if ((this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().IndexOf("根据时间") >= 0) && (Convert.ToDateTime(strDate) > Convert.ToDateTime(str3)))
                        {
                            MessageBox.Show("区域\"" + str + "\"设置的起始时间不能大于终止时间!");
                            return false;
                        }
                        alarm.AlarmCondition = this.getMultiAlarmCondition(i);
                        if (strResultDate.Trim().Length > 0)
                        {
                            alarm.BeginTime = strResultDate;
                        }
                        if (str6.Trim().Length > 0)
                        {
                            alarm.EndTime = str6;
                        }
                        if (this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().Trim().Length > 0)
                        {
                            if (this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().Trim().Length == 0)
                            {
                                MessageBox.Show("区域\"" + str + "\"的区域属性不能为空!");
                                return false;
                            }
                            if ((this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().IndexOf("限速") >= 0) && (this.dgvArea.Rows[i].Cells["最高时速"].Value.ToString().Trim().Length == 0))
                            {
                                MessageBox.Show("区域\"" + str + "\"的最高时速不能为空!");
                                return false;
                            }
                            if ((this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().IndexOf("限速") >= 0) && (this.dgvArea.Rows[i].Cells["超速持续时间"].Value.ToString().Trim().Length == 0))
                            {
                                MessageBox.Show("区域\"" + str + "\"的超速持续时间不能为空!");
                                return false;
                            }
                            if (this.dgvArea.Rows[i].Cells["区域属性"].Tag != null)
                            {
                                alarm.AlarmFlag = this.GeneralValue(this.dgvArea.Rows[i].Cells["区域属性"].Tag as ArrayList);
                            }
                            else if ((this.dgvArea.Rows[i].Cells["区域属性"].Tag == null) && (this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().Trim().Length > 0))
                            {
                                alarm.AlarmFlag = this.GeneralValue(this.GeneralDomainText(this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString()));
                            }
                            int result = 0;
                            int num8 = 0;
                            if (this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().IndexOf("限速") >= 0)
                            {
                                if (int.TryParse(this.dgvArea.Rows[i].Cells["最高时速"].Value.ToString(), out result))
                                {
                                    if (result <= 0)
                                    {
                                        MessageBox.Show("区域\"" + str + "\"的最高时速须大于0!");
                                        return false;
                                    }
                                    if (!PublicClass.Check.isNumeric(result.ToString(), PublicClass.Check.NumType.sByte))
                                    {
                                        MessageBox.Show("区域\"" + str + "\"最高时速必须为1-255的数字！");
                                        return false;
                                    }
                                    alarm.MaxSpeed = new int?(result);
                                }
                                else
                                {
                                    MessageBox.Show("区域\"" + str + "\"的最高时速项只能输入整数!");
                                    return false;
                                }
                                if (int.TryParse(this.dgvArea.Rows[i].Cells["超速持续时间"].Value.ToString(), out num8))
                                {
                                    if (num8 <= 0)
                                    {
                                        MessageBox.Show("区域\"" + str + "\"的超速持续时间须大于0!");
                                        return false;
                                    }
                                    if (!PublicClass.Check.isNumeric(num8.ToString(), PublicClass.Check.NumType.sByte))
                                    {
                                        MessageBox.Show("区域\"" + str + "\"持续时长必须为1-255之间的数字！");
                                        return false;
                                    }
                                    alarm.HodeTime = new int?(num8);
                                }
                                else
                                {
                                    MessageBox.Show("区域\"" + str + "\"的超速持续时间项只能输入整数!");
                                    return false;
                                }
                            }
                        }
                    }
                    alarm.newRegionId = Convert.ToInt32(this.dgvArea.Rows[i].Cells["newRegionID"].Value);
                    this.m_RegionAlarmList.Add(alarm);
                }
            }
            int num9 = 7;
            switch (this.cbRegionType.SelectedIndex)
            {
                case 0:
                    num9 = 7;
                    break;

                case 1:
                    num9 = 1;
                    break;

                case 2:
                    num9 = 2;
                    break;

                case 3:
                    num9 = 4;
                    break;
            }
            this.m_RegionAlarmList.OperationType = new int?(num9 | 8);
            this.m_RegionAlarmList.RegionFeature = num3;
            this.m_RegionAlarmList.OrderCode = base.OrderCode;
            if (flag)
            {
                MessageBox.Show("没有选择区域。");
                return false;
            }
            return true;
        }

        private int GetRegionParam(int iRow)
        {
            int num = 0;
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["StartPoint"].Value.ToString()))
            {
                num |= 1;
            }
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["PassPoint"].Value.ToString()))
            {
                num |= 2;
            }
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["EndPoint"].Value.ToString()))
            {
                num |= 4;
            }
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["StopPoint"].Value.ToString()))
            {
                num |= 8;
            }
            return num;
        }

        private int getRegionType(int iRow)
        {
            int num = -1;
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["InRegion"].Value.ToString()))
            {
                num = 1;
                if (bool.Parse(this.dgvArea.Rows[iRow].Cells["ColseGSm"].Value.ToString()))
                {
                    num |= 192;
                }
                if (bool.Parse(this.dgvArea.Rows[iRow].Cells["ColseData"].Value.ToString()))
                {
                    num |= 160;
                }
            }
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["OutRegion"].Value.ToString()))
            {
                num = 0;
            }
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["InOutRegion"].Value.ToString()))
            {
                num = 2;
            }
            return num;
        }

        private float getToTime(string sStr)
        {
            float num = 0f;
            if (sStr.Trim().Length <= 0)
            {
                return num;
            }
            try
            {
                return float.Parse(sStr);
            }
            catch
            {
                return -1f;
            }
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

        private void InitData()
        {
            this.InitDataSource();
            int iRegionFeature = 0;
            if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
            {
                iRegionFeature = 1;
            }
            string selectedCarId = MainForm.myCarList.SelectedCarId;
            DataTable table = RemotingClient.Car_GetRegionInfo((selectedCarId.Split(new char[] { ',' }).Length > 1) ? selectedCarId.Split(new char[] { ',' })[0] : selectedCarId, iRegionFeature);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string str2 = table.Rows[i]["regionName"].ToString();
                    string str3 = table.Rows[i]["RegionId"].ToString();
                    string sRegionDot = table.Rows[i]["regionDot"].ToString();
                    string s = table.Rows[i]["regionType"].ToString();
                    string str6 = table.Rows[i]["pathgroupid"].ToString();
                    DataRow row = this.m_dtRegion.NewRow();
                    row["regionName"] = str2;
                    row["regionId"] = str3;
                    row["regionDot"] = sRegionDot;
                    row["pathgroupid"] = str6;
                    if (PublicClass.Check.isRectangle(sRegionDot))
                    {
                        row["RegionType2"] = 0;
                    }
                    else if (PublicClass.Check.isRoundness(sRegionDot))
                    {
                        row["RegionType2"] = 1;
                    }
                    else
                    {
                        row["RegionType2"] = 2;
                    }
                    if (s.Length == 0)
                    {
                        row["newRegionID"] = "";
                        this.m_dtRegion.Rows.Add(row);
                        continue;
                    }
                    int num3 = int.Parse(s);
                    string strDate = table.Rows[i]["beginTime"].ToString();
                    string str8 = table.Rows[i]["endTime"].ToString();
                    string str9 = table.Rows[i]["NewRegionId"].ToString();
                    switch (num3)
                    {
                        case 0:
                            row["InRegion"] = false;
                            row["OutRegion"] = true;
                            row["InOutRegion"] = false;
                            if (!"0".Equals(str9))
                            {
                                goto Label_02F9;
                            }
                            row["MainRegion"] = true;
                            goto Label_033F;

                        case 1:
                            row["InRegion"] = true;
                            row["OutRegion"] = false;
                            row["InOutRegion"] = false;
                            if (!"0".Equals(str9))
                            {
                                break;
                            }
                            row["MainRegion"] = true;
                            goto Label_033F;

                        case 2:
                            row["InRegion"] = false;
                            row["OutRegion"] = false;
                            row["InOutRegion"] = true;
                            goto Label_033F;

                        default:
                            goto Label_033F;
                    }
                    row["MainRegion"] = false;
                    goto Label_033F;
                Label_02F9:
                    row["MainRegion"] = false;
                Label_033F:
                    if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
                    {
                        string strAlarmCom = table.Rows[i]["alarmCondition"].ToString();
                        row["alarmCondition"] = this.getAlarmCondition(strAlarmCom);
                        if ((strDate.Length == 12) && (str8.Length == 12))
                        {
                            row["beginTime"] = PublicClass.Check.ChangeDateFormat(strDate);
                            row["endTime"] = PublicClass.Check.ChangeDateFormat(str8);
                        }
                        if (table.Columns.Contains("AlarmFlag"))
                        {
                            if ((table.Rows[i]["AlarmFlag"] != null) && (table.Rows[i]["AlarmFlag"].ToString().Trim().Length > 0))
                            {
                                int result = 0;
                                string showtext = "";
                                if (int.TryParse(table.Rows[i]["AlarmFlag"].ToString(), out result))
                                {
                                    this.GeneralDomainValue(result, out showtext);
                                }
                                row["AlarmFlag"] = showtext;
                            }
                            row["MaxSpeed"] = table.Rows[i]["MaxSpeed"].ToString().Equals("0") ? DBNull.Value : table.Rows[i]["MaxSpeed"];
                            row["HodeTime"] = table.Rows[i]["HodeTime"].ToString().Equals("0") ? DBNull.Value : table.Rows[i]["HodeTime"];
                        }
                    }
                    else
                    {
                        int num5 = int.Parse(table.Rows[i]["regionParam"].ToString());
                        float num6 = float.Parse(table.Rows[i]["distanceToBegin"].ToString());
                        float num7 = float.Parse(table.Rows[i]["distanceToEnd"].ToString());
                        string str12 = table.Rows[i]["planUpBeginTime"].ToString();
                        string str13 = table.Rows[i]["planDownBeginTime"].ToString();
                        string str14 = "";
                        string str15 = "";
                        if (num6 != 0f)
                        {
                            str14 = num6.ToString("N");
                        }
                        if (num6 != 0f)
                        {
                            str15 = num7.ToString("N");
                        }
                        if (num5 == -1)
                        {
                            num5 = 0;
                        }
                        if ((num5 & 1) != 0)
                        {
                            row["StartPoint"] = true;
                            row["PassPoint"] = false;
                            row["EndPoint"] = false;
                            row["distanceToBegin"] = str14;
                            row["distanceToEnd"] = str15;
                        }
                        if ((num5 & 2) != 0)
                        {
                            row["StartPoint"] = false;
                            row["PassPoint"] = true;
                            row["EndPoint"] = false;
                            row["distanceToBegin"] = str14;
                            row["distanceToEnd"] = str15;
                        }
                        if ((num5 & 4) != 0)
                        {
                            row["StartPoint"] = false;
                            row["PassPoint"] = false;
                            row["EndPoint"] = true;
                            row["distanceToBegin"] = str14;
                            row["distanceToEnd"] = str15;
                            row["planUpBeginTime"] = str12;
                            row["planDownBeginTime"] = str13;
                        }
                        if ((num5 & 8) != 0)
                        {
                            row["StopPoint"] = true;
                            row["beginTime"] = strDate;
                            row["endTime"] = str8;
                        }
                    }
                    row["newRegionID"] = str9;
                    this.m_dtRegion.Rows.Add(row);
                }
                this.execDistinctData("");
            }
        }

        private void InitDataSource()
        {
            this.m_dtRegion.Columns.Add("regionName");
            this.m_dtRegion.Columns.Add("regionId");
            this.m_dtRegion.Columns.Add("regionDot");
            this.m_dtRegion.Columns.Add("InRegion");
            this.m_dtRegion.Columns["InRegion"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("OutRegion");
            this.m_dtRegion.Columns["OutRegion"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("InOutRegion");
            this.m_dtRegion.Columns["InOutRegion"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("ColseGSm");
            this.m_dtRegion.Columns["ColseGSm"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("ColseData");
            this.m_dtRegion.Columns["ColseData"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("StartPoint");
            this.m_dtRegion.Columns["StartPoint"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("PassPoint");
            this.m_dtRegion.Columns["PassPoint"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("EndPoint");
            this.m_dtRegion.Columns["EndPoint"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("distanceToBegin");
            this.m_dtRegion.Columns["distanceToBegin"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("distanceToEnd");
            this.m_dtRegion.Columns["distanceToEnd"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("planUpBeginTime");
            this.m_dtRegion.Columns["planUpBeginTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("planDownBeginTime");
            this.m_dtRegion.Columns["planDownBeginTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("StopPoint");
            this.m_dtRegion.Columns["StopPoint"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("beginTime");
            this.m_dtRegion.Columns["beginTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("endTime");
            this.m_dtRegion.Columns["endTime"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("AlarmCondition");
            this.m_dtRegion.Columns["AlarmCondition"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("MainRegion");
            this.m_dtRegion.Columns["MainRegion"].DefaultValue = false;
            this.m_dtRegion.Columns.Add("PathGroupId");
            this.m_dtRegion.Columns["PathGroupId"].DefaultValue = "";
            this.m_dtRegion.Columns.Add("MaxSpeed");
            this.m_dtRegion.Columns.Add("HodeTime");
            this.m_dtRegion.Columns.Add("AlarmFlag");
            this.m_dtRegion.Columns.Add("RegionType2");
            this.m_dtRegion.Columns.Add("newRegionID");
        }

 private bool IsIDRepeat()
        {
            for (int i = 0; i < this.dgvArea.Rows.Count; i++)
            {
                if (this.dgvArea.Rows[i].Cells["区域属性"].Value.ToString().ToString().Trim().Length > 0)
                {
                    int num2;
                    string s = this.dgvArea.Rows[i].Cells["newRegionID"].Value.ToString();
                    if (s.Length == 0)
                    {
                        MessageBox.Show("ID不能为空。");
                        return true;
                    }
                    if (!int.TryParse(s, out num2) || (num2 < 0))
                    {
                        MessageBox.Show("ID只能为正整数。");
                        return true;
                    }
                    for (int j = i + 1; j < this.dgvArea.Rows.Count; j++)
                    {
                        if (this.dgvArea.Rows[j].Cells["区域属性"].Value.ToString().ToString().Trim().Length > 0)
                        {
                            string str4 = this.dgvArea.Rows[j].Cells["newRegionID"].Value.ToString();
                            if (str4.Length == 0)
                            {
                                MessageBox.Show("ID不能为空。");
                                return true;
                            }
                            if (!int.TryParse(str4, out num2) || (num2 < 0))
                            {
                                MessageBox.Show("ID只能为正整数。");
                                return true;
                            }
                            if (s.Equals(str4))
                            {
                                MessageBox.Show("下发ID不能相同。");
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
            if (this.dgvArea.Rows[rowIndex].Cells["区域属性"].Value.ToString().IndexOf("根据时间") < 0)
            {
                return false;
            }
            return true;
        }

        private void SetAreaAlarm_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
            DataTable table = RemotingClient.Car_GetCarAlarmState(base.sCarId);
            if ((table != null) && (table.Rows.Count > 0))
            {
                this.m_sCustName = table.Rows[0]["cust_name"].ToString();
            }
            this.InitData();
            this.dgvArea.Columns["InRegion"].Tag = "Chk";
            this.dgvArea.Columns["OutRegion"].Tag = "Chk";
            this.dgvArea.Columns["InOutRegion"].Tag = "Chk";
            this.dgvArea.Columns["MainRegion"].Tag = "Chk";
            this.InitComboBox();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = this.grpArea.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        private void setGroupVisible()
        {
            base.Width = 668;
            if (base.OrderCode == CmdParam.OrderCode.设置区域报警)
            {
                this.dgvArea.Columns[17].Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
            {
                this.Add区域属性();
                this.cbRegionType.SelectedIndex = 0;
            }
        }

        private void setInitReadOnly()
        {
            if ((this.dgvArea != null) && (this.dgvArea.Rows.Count > 0))
            {
                foreach (DataGridViewRow row in (IEnumerable) this.dgvArea.Rows)
                {
                    this.setTimeSpeedReadOnly(row, this.GeneralDomainText(row.Cells["区域属性"].Value.ToString()));
                }
            }
        }

        private void setTimeSpeedReadOnly(DataGridViewRow dgvr, ArrayList val)
        {
            if (val[0].ToString() != "1")
            {
                dgvr.Cells["beginTime"].Value = "";
                dgvr.Cells["endTime"].Value = "";
            }
            if (val[1].ToString() != "1")
            {
                dgvr.Cells["最高时速"].Value = "";
                dgvr.Cells["超速持续时间"].Value = "";
                dgvr.Cells["最高时速"].ReadOnly = true;
                dgvr.Cells["超速持续时间"].ReadOnly = true;
            }
            else
            {
                dgvr.Cells["最高时速"].ReadOnly = false;
                dgvr.Cells["超速持续时间"].ReadOnly = false;
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
                    string str = this.comboBoxLines.SelectedValue.ToString();
                    string sFilter = "pathGroupID ='" + str + "'";
                    this.execDistinctData(sFilter);
                }
                catch
                {
                }
            }
        }

        private void tsBtnFilter2_Click(object sender, EventArgs e)
        {
            string str = (this.cbRegionType.SelectedIndex == 0) ? "%" : ((this.cbRegionType.SelectedIndex - 1)).ToString();
            string sFilter = "RegionType2 like '" + str + "'";
            this.execDistinctData(sFilter);
        }
    }
}

