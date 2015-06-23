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
    using System.Windows.Forms;
    using WinFormsUI.Controls;
    using Library;

    public partial class itmSetRegionAlarm : CarForm
    {
        private static string ERRORPATHAlARM = "解析区域失败！";
        private DataTable m_dtPathGroup = new DataTable();
        private DataTable m_dtRegion = new DataTable();
        private static int m_iSelectCntMax = 255;
        private RegionAlarmList m_RegionAlarmList = new RegionAlarmList();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmSetRegionAlarm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.dgvArea.NotMultiSelectedColumnName.Add("MainRegion");
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
                {
                    if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
                    {
                        base.reResult = RemotingClient.DownData_SetRegionAlarm(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                    }
                    else
                    {
                        base.reResult = RemotingClient.DownData_SetRegionAlarm_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                    }
                    if (base.reResult.ResultCode != 0L)
                    {
                        MessageBox.Show(base.reResult.ErrorMsg);
                    }
                    else
                    {
                        base.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private bool chkSeletRegion()
        {
            int num = 0;
            for (int i = 0; i < this.dgvArea.Rows.Count; i++)
            {
                string str = this.dgvArea.Rows[i].Cells["RegionName"].Value.ToString();
                string strDate = this.dgvArea.Rows[i].Cells["beginTime"].Value.ToString();  ///ToString
                string str3 = this.dgvArea.Rows[i].Cells["endTime"].Value.ToString();   ///ToString
                if (this.getRegionType(i) >= 0)
                {
                    if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
                    {
                        if (strDate.Length == 0)
                        {
                            MessageBox.Show("区域\"" + str + "\"没有设置起始时间！");
                            this.dgvArea.Focus();
                            this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["beginTime"];
                            return false;
                        }
                        if (str3.Length == 0)
                        {
                            MessageBox.Show("区域\"" + str + "\"没有设置终止时间！");
                            this.dgvArea.Focus();
                            this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["endTime"];
                            return false;
                        }
                        string strResultDate = string.Empty;
                        string str5 = string.Empty;
                        if (!Check.CheckIsDate(strDate, out strResultDate))
                        {
                            MessageBox.Show("区域\"" + str + "\"起始时间格式有误！");
                            return false;
                        }
                        if (!Check.CheckIsDate(str3, out str5))
                        {
                            MessageBox.Show("区域\"" + str + "\"终止时间格式有误！");
                            return false;
                        }
                        if (((strDate.Substring(0, 4) == "0000") && (str3.Substring(0, 4) != "0000")) || ((strDate.Substring(0, 4) != "0000") && (str3.Substring(0, 4) == "0000")))
                        {
                            MessageBox.Show("路线\"" + str + "\"设置起始时间和终止时间时，固定时段参数勾选状态需保持一致！");
                            this.dgvArea.Focus();
                            this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["beginTime"];
                            return false;
                        }
                        if ((strDate.Substring(0, 11) == "0000-00-00 ") && (str3.Substring(0, 11) == "0000-00-00 "))
                        {
                            strDate = strDate.Substring(11);
                            str3 = str3.Substring(11);
                        }
                        if (DateTime.Parse(strDate) > DateTime.Parse(str3))
                        {
                            MessageBox.Show(string.Format("{0}：起始时间不能大于终止时间！", str));
                            this.dgvArea.Focus();
                            this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["beginTime"];
                            return false;
                        }
                    }
                    else
                    {
                        string sStr = this.dgvArea.Rows[i].Cells["distanceToBegin"].Value.ToString(); ///ToString
                        string str7 = this.dgvArea.Rows[i].Cells["distanceToEnd"].Value.ToString(); ///ToString
                        string s = this.dgvArea.Rows[i].Cells["planUpBeginTime"].Value.ToString(); ///ToString
                        string str9 = this.dgvArea.Rows[i].Cells["planDownBeginTime"].Value.ToString(); ///ToString
                        if (bool.Parse(this.dgvArea.Rows[i].Cells["EndPoint"].Value.ToString()))
                        {
                            DateTime time3;
                            float num3 = this.getToTime(sStr);
                            float num4 = this.getToTime(str7);
                            if (num3 < 0f)
                            {
                                MessageBox.Show(string.Format("{0}：去程车程时长格式有误！比如：'1.00'", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["distanceToBegin"];
                                return false;
                            }
                            if (num4 < 0f)
                            {
                                MessageBox.Show(string.Format("{0}：返程车程时长格式有误！比如：'1.00'", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["distanceToEnd"];
                                return false;
                            }
                            if (((num3 == 0f) || (num4 == 0f)) || ((s.Length == 0) || (str9.Length == 0)))
                            {
                                MessageBox.Show(string.Format("{0}：终点站必须设置去程车程时长、返程车程时长、去程规定始发时间和返程规定始发时间！", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["distanceToBegin"];
                                return false;
                            }
                            if (s.IndexOf(":") < 0)
                            {
                                s = s + ":00";
                            }
                            if (str9.IndexOf(":") < 0)
                            {
                                str9 = str9 + ":00";
                            }
                            if (!DateTime.TryParse(s, out time3))
                            {
                                MessageBox.Show(string.Format("{0}：去程规定始发时间格式有误！比如：'14:00'", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["planUpBeginTime"];
                                return false;
                            }
                            if (!DateTime.TryParse(str9, out time3))
                            {
                                MessageBox.Show(string.Format("{0}：返程规定始发时间格式有误！比如：'14:00'", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["planDownBeginTime"];
                                return false;
                            }
                        }
                        if (bool.Parse(this.dgvArea.Rows[i].Cells["StopPoint"].Value.ToString()))
                        {
                            DateTime time;
                            DateTime time2;
                            if ((strDate.Length == 0) || (str3.Length == 0))
                            {
                                MessageBox.Show(string.Format("{0}：停止点必须有时间段！", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["beginTime"];
                                return false;
                            }
                            if (strDate.IndexOf(":") < 0)
                            {
                                strDate = strDate + ":00";
                            }
                            if (str3.IndexOf(":") < 0)
                            {
                                str3 = strDate + ":00";
                            }
                            if (!DateTime.TryParse(strDate, out time))
                            {
                                MessageBox.Show(string.Format("{0}：起始时间格式不正确！比如：'14:00'", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["beginTime"];
                                return false;
                            }
                            if (!DateTime.TryParse(str3, out time2))
                            {
                                MessageBox.Show(string.Format("{0}：终止时间格式不正确！比如：'14:00'", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["endTime"];
                                return false;
                            }
                            if (time > time2)
                            {
                                MessageBox.Show(string.Format("{0}：起始时间不能大于终止时间！", str));
                                this.dgvArea.Focus();
                                this.dgvArea.CurrentCell = this.dgvArea.Rows[i].Cells["beginTime"];
                                return false;
                            }
                        }
                    }
                    num++;
                }
            }
            if (num <= 0)
            {
                MessageBox.Show("没有选择任何区域");
                return false;
            }
            if (num > m_iSelectCntMax)
            {
                MessageBox.Show(string.Format("选择区域个数超过{0}个！", m_iSelectCntMax.ToString()));
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
                if ((currentCell.ColumnIndex == this.dgvArea.Columns["BeginTime"].Index) || (currentCell.ColumnIndex == this.dgvArea.Columns["EndTime"].Index))
                {
                    SetDateTime time = new SetDateTime(currentCell.Value.ToString());  ///ToString
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
            if (!this.chkSeletRegion())
            {
                this.dgvArea.Focus();
                return false;
            }
            int num3 = 0;
            if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
            {
                num3 = 1;
            }
            this.m_RegionAlarmList = new RegionAlarmList();
            for (int i = 0; i < this.dgvArea.Rows.Count; i++)
            {
                int num5 = this.getRegionType(i);
                if (num5 >= 0)
                {
                    ArrayList list = new ArrayList();
                    RegionAlarm alarm = new RegionAlarm();
                    str = this.dgvArea.Rows[i].Cells["RegionName"].Value.ToString(); ///ToString
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
                    str4 = this.dgvArea.Rows[i].Cells["RegionDot"].Value.ToString(); ///ToString
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
                    strDate = this.dgvArea.Rows[i].Cells["beginTime"].Value.ToString(); ///ToString
                    str3 = this.dgvArea.Rows[i].Cells["endTime"].Value.ToString(); ///ToString
                    if (num3 == 1)
                    {
                        string strResultDate = "";
                        string str6 = "";
                        Check.CheckIsDate(strDate, out strResultDate);
                        Check.CheckIsDate(str3, out str6);
                        alarm.AlarmCondition = this.getMultiAlarmCondition(i);
                        alarm.BeginTime = strResultDate;
                        alarm.EndTime = str6;
                    }
                    else
                    {
                        string sStr = this.dgvArea.Rows[i].Cells["distanceToBegin"].Value.ToString(); ///ToString
                        string text1 = this.dgvArea.Rows[i].Cells["distanceToEnd"].Value.ToString(); ///ToString
                        string str8 = this.dgvArea.Rows[i].Cells["planUpBeginTime"].Value.ToString(); ///ToString
                        string str9 = this.dgvArea.Rows[i].Cells["planDownBeginTime"].Value.ToString(); ///ToString
                        alarm.toEndTime = this.getToTime(sStr);
                        alarm.toBackTime = this.getToTime(sStr);
                        alarm.param = this.GetRegionParam(i);
                        alarm.PlanUpTime = str8;
                        alarm.PlanDownTime = str9;
                        alarm.BeginTime = strDate;
                        alarm.EndTime = str3;
                    }
                    this.m_RegionAlarmList.Add(alarm);
                }
            }
            this.m_RegionAlarmList.RegionFeature = num3;
            this.m_RegionAlarmList.OrderCode = base.OrderCode;
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
            DataTable table = RemotingClient.Car_GetRegionInfo(MainForm.myCarList.SelectedCarId, iRegionFeature);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string str2 = table.Rows[i]["regionName"].ToString();
                    string str3 = table.Rows[i]["RegionId"].ToString();
                    string str4 = table.Rows[i]["regionDot"].ToString();
                    string s = table.Rows[i]["regionType"].ToString();
                    string str6 = table.Rows[i]["pathgroupid"].ToString();
                    DataRow row = this.m_dtRegion.NewRow();
                    row["regionName"] = str2;
                    row["regionId"] = str3;
                    row["regionDot"] = str4;
                    row["pathgroupid"] = str6;
                    if (s.Length == 0)
                    {
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
                                goto Label_026B;
                            }
                            row["MainRegion"] = true;
                            goto Label_02B1;

                        case 1:
                            row["InRegion"] = true;
                            row["OutRegion"] = false;
                            row["InOutRegion"] = false;
                            if (!"0".Equals(str9))
                            {
                                break;
                            }
                            row["MainRegion"] = true;
                            goto Label_02B1;

                        case 2:
                            row["InRegion"] = false;
                            row["OutRegion"] = false;
                            row["InOutRegion"] = true;
                            goto Label_02B1;

                        default:
                            goto Label_02B1;
                    }
                    row["MainRegion"] = false;
                    goto Label_02B1;
                Label_026B:
                    row["MainRegion"] = false;
                Label_02B1:
                    if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
                    {
                        string strAlarmCom = table.Rows[i]["alarmCondition"].ToString();
                        row["alarmCondition"] = this.getAlarmCondition(strAlarmCom);
                        if ((strDate.Length == 12) && (str8.Length == 12))
                        {
                            row["beginTime"] = Check.ChangeDateFormat(strDate);
                            row["endTime"] = Check.ChangeDateFormat(str8);
                        }
                    }
                    else
                    {
                        int num4 = int.Parse(table.Rows[i]["regionParam"].ToString());
                        float num5 = float.Parse(table.Rows[i]["distanceToBegin"].ToString());
                        float num6 = float.Parse(table.Rows[i]["distanceToEnd"].ToString());
                        string str11 = table.Rows[i]["planUpBeginTime"].ToString();
                        string str12 = table.Rows[i]["planDownBeginTime"].ToString();
                        string str13 = "";
                        string str14 = "";
                        if (num5 != 0f)
                        {
                            str13 = num5.ToString("N");
                        }
                        if (num5 != 0f)
                        {
                            str14 = num6.ToString("N");
                        }
                        if (num4 == -1)
                        {
                            num4 = 0;
                        }
                        if ((num4 & 1) != 0)
                        {
                            row["StartPoint"] = true;
                            row["PassPoint"] = false;
                            row["EndPoint"] = false;
                            row["distanceToBegin"] = str13;
                            row["distanceToEnd"] = str14;
                        }
                        if ((num4 & 2) != 0)
                        {
                            row["StartPoint"] = false;
                            row["PassPoint"] = true;
                            row["EndPoint"] = false;
                            row["distanceToBegin"] = str13;
                            row["distanceToEnd"] = str14;
                        }
                        if ((num4 & 4) != 0)
                        {
                            row["StartPoint"] = false;
                            row["PassPoint"] = false;
                            row["EndPoint"] = true;
                            row["distanceToBegin"] = str13;
                            row["distanceToEnd"] = str14;
                            row["planUpBeginTime"] = str11;
                            row["planDownBeginTime"] = str12;
                        }
                        if ((num4 & 8) != 0)
                        {
                            row["StopPoint"] = true;
                            row["beginTime"] = strDate;
                            row["endTime"] = str8;
                        }
                    }
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

        private void setGroupVisible()
        {
            base.Width = 668;
            if (base.OrderCode == CmdParam.OrderCode.设置区域报警)
            {
                this.dgvArea.Columns[17].Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置多功能区域报警)
            {
                this.dgvArea.Columns[4].Visible = false;
                this.dgvArea.Columns[7].Visible = false;
                this.dgvArea.Columns[8].Visible = false;
                this.dgvArea.Columns[9].Visible = false;
                this.dgvArea.Columns[10].Visible = false;
                this.dgvArea.Columns[11].Visible = false;
                this.dgvArea.Columns[12].Visible = false;
                this.dgvArea.Columns[13].Visible = false;
                this.dgvArea.Columns[14].Visible = false;
                this.dgvArea.Columns[15].ReadOnly = true;
                this.dgvArea.Columns[16].ReadOnly = true;
            }
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
    }
}

