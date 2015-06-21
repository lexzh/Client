namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmCarLBSParam : CarForm
    {
        private DataTable m_dtTimeValue = new DataTable();
        private DataTable m_dtUnit = new DataTable();
        private int m_dvColumn = -1;
        private int m_dvRow = -1;
        private string[] TimeValue = new string[7];

        public itmCarLBSParam(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearColor();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if ((!string.IsNullOrEmpty(base.sValue) && this.getParam()) && (MessageBox.Show("是否确定保存？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK))
                {
                    string str = string.Format("时间-{0}～{1}", this.strStartTime, this.strEndTime);
                    string dBCurrentDateTime = RemotingClient.GetDBCurrentDateTime();
                    if (string.IsNullOrEmpty(dBCurrentDateTime))
                    {
                        dBCurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    string sOrderId = "0";
                    string sOrderType = "发送";
                    string sOrderName = base.OrderCode.ToString();
                    string sMsg = str;
                    string sOrderResult = "成功";
                    string[] strArray = base.sCarNum.Split(new char[] { ',' });
                    int index = 0;
                    string sCarNum = "";
                    foreach (string str9 in base.sCarSimNum.Split(new char[] { ',' }))
                    {
                        sCarNum = strArray[index];
                        index++;
                        for (int i = 0; i < 7; i++)
                        {
                            this.delCarLBSParam(str9, i);
                            if (this.TimeValue[i] != "")
                            {
                                int num3 = ((i + 7) - (int)(this.dtpStartTime.Value.DayOfWeek)) % 7;
                                if ((this.dtpStartTime.Value.AddDays((double) num3).Date <= this.dtpEndTime.Value.Date) && !this.insertValue(str9, i, this.strStartTime, this.strEndTime, this.TimeValue[i]))
                                {
                                    MessageBox.Show("保存失败！");
                                    sOrderResult = "失败";
                                    MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(dBCurrentDateTime, sCarNum, sOrderId, sOrderType, sOrderName, sOrderResult, sMsg);
                                    return;
                                }
                            }
                        }
                        MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(dBCurrentDateTime, sCarNum, sOrderId, sOrderType, sOrderName, sOrderResult, sMsg);
                    }
                    base.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Record.execFileRecord(base.OrderCode.ToString(), exception.Message);
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            this.clearColor();
            this.initDataGridView();
        }

        public void changeColor(DataGridViewCell myCell)
        {
            if (myCell != null)
            {
                if (myCell.Style.BackColor == Color.Blue)
                {
                    myCell.Style.BackColor = Color.Lime;
                    myCell.Style.SelectionBackColor = Color.Lime;
                }
                else
                {
                    myCell.Style.BackColor = Color.Blue;
                    myCell.Style.SelectionBackColor = Color.Blue;
                }
            }
        }

        private void clearColor()
        {
            for (int i = 0; i < 96; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DataGridViewCell myCell = this.m_dgvTimeValue.Rows[i].Cells[(j * 2) + 1];
                    if ((myCell.Style.BackColor == Color.Blue) || (myCell.Style.SelectionBackColor == Color.Blue))
                    {
                        this.changeColor(myCell);
                    }
                }
            }
        }

        private bool delCarLBSParam(string sSimNum, int iType)
        {
            try
            {
                if (RemotingClient.ExecNoQuery(string.Format("exec GpsPicServer_DelCarLBSParam '{0}', {1}", sSimNum, iType)).ResultCode == 0L)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

 private DataTable getCarLBSParam(string sSimNum)
        {
            try
            {
                return RemotingClient.ExecSql(string.Format("exec GpsPicServer_GetCarLBSParam '{0}'", sSimNum));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string getDayValue(int weekDay)
        {
            if (weekDay == 0)
            {
                weekDay = 7;
            }
            string str = "";
            for (int i = 0; i < 96; i++)
            {
                if (this.m_dgvTimeValue.Rows[i].Cells[(weekDay * 2) - 1].Style.BackColor == Color.Blue)
                {
                    str = str + this.getTime(i) + ",";
                }
            }
            return str.Trim(new char[] { ',' });
        }

        public int getNumberOfDays()
        {
            DateTime time = this.dtpStartTime.Value;
            TimeSpan span = (TimeSpan) (this.dtpEndTime.Value - time);
            return (span.Days + 1);
        }

        private bool getParam()
        {
            if (this.dtpStartTime.Value < DateTime.Now.Date)
            {
                MessageBox.Show("开始时间小于当前时间");
                this.dtpStartTime.Focus();
                return false;
            }
            if (this.dtpStartTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("开始时间大于结束时间");
                this.dtpStartTime.Focus();
                return false;
            }
            try
            {
                this.strStartTime = this.dtpStartTime.Value.ToString("yyyy-MM-dd");
                this.strEndTime = this.dtpEndTime.Value.ToString("yyyy-MM-dd");
                for (int i = 0; i < 7; i++)
                {
                    this.TimeValue[i] = this.getDayValue(i);
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("参数获取失败");
                return false;
            }
        }

        public string getTime(int rowIndex)
        {
            TimeSpan span = new TimeSpan(0, 15 * rowIndex, 0);
            return (((span.Hours < 10) ? ("0" + span.Hours.ToString()) : span.Hours.ToString()) + ":" + ((span.Minutes < 10) ? ("0" + span.Minutes.ToString()) : span.Minutes.ToString()));
        }

        private string getTimeValue()
        {
            string str = "";
            for (int i = 1; i < 14; i += 2)
            {
                for (int j = 0; j < 96; j++)
                {
                    if (this.m_dgvTimeValue.Rows[j].Cells[i].Style.BackColor == Color.Blue)
                    {
                        str = str + j.ToString() + ",";
                    }
                }
                str = str.Trim(new char[] { ',' }) + ";";
            }
            return str.TrimEnd(new char[] { ';' });
        }

        public int getWeek(string dateValue)
        {
            return (int) Convert.ToDateTime(dateValue).DayOfWeek;
        }

        private void InitData()
        {
            for (int i = 0; i < 96; i++)
            {
                DataRow row2;
                DataRow row = this.m_dtTimeValue.NewRow();
                this.m_dtTimeValue.Rows.Add(row);
                if ((i % 8) == 0)
                {
                    row2 = this.m_dtUnit.NewRow();
                    row2["Column16"] = (i + 1) / 4;
                    this.m_dtUnit.Rows.Add(row2);
                }
                else if (i == 95)
                {
                    row2 = this.m_dtUnit.NewRow();
                    row2["Column16"] = (i + 1) / 4;
                    this.m_dtUnit.Rows.Add(row2);
                }
            }
        }

        private void initDataGridView()
        {
            if ((this.dtLCSParam != null) && (this.dtLCSParam.Rows.Count > 0))
            {
                this.dtpStartTime.Value = Convert.ToDateTime(this.dtLCSParam.Rows[0][2]);
                this.dtpEndTime.Value = Convert.ToDateTime(this.dtLCSParam.Rows[0][3]);
                for (int i = 0; (i < this.dtLCSParam.Rows.Count) && (i < 7); i++)
                {
                    int week = (int) this.dtLCSParam.Rows[i][1];
                    string p = this.dtLCSParam.Rows[i][4].ToString();
                    this.setTimeValue(p, week);
                }
            }
        }

        private void InitDataSource()
        {
            this.m_dtTimeValue.Columns.Add("Column1");
            this.m_dtTimeValue.Columns.Add("Column2");
            this.m_dtTimeValue.Columns.Add("Column3");
            this.m_dtTimeValue.Columns.Add("Column4");
            this.m_dtTimeValue.Columns.Add("Column5");
            this.m_dtTimeValue.Columns.Add("Column6");
            this.m_dtTimeValue.Columns.Add("Column7");
            this.m_dtTimeValue.Columns.Add("Column8");
            this.m_dtTimeValue.Columns.Add("Column9");
            this.m_dtTimeValue.Columns.Add("Column10");
            this.m_dtTimeValue.Columns.Add("Column11");
            this.m_dtTimeValue.Columns.Add("Column12");
            this.m_dtTimeValue.Columns.Add("Column13");
            this.m_dtTimeValue.Columns.Add("Column14");
            this.m_dtTimeValue.Columns.Add("Column15");
            this.m_dtUnit.Columns.Add("Column16");
        }

 private bool insertValue(string sSimNum, int iDateType, string startDate, string endDate, string timeValue)
        {
            try
            {
                if (RemotingClient.ExecNoQuery(string.Format("exec GpsPicServer_SetCarLBSParam '{0}', {1}, '{2}', '{3}', '{4}'", new object[] { sSimNum, iDateType, startDate, endDate, timeValue })).ResultCode == 0L)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        private void itmCarLBSParam_Load(object sender, EventArgs e)
        {
            this.InitDataSource();
            this.InitData();
            this.m_dgvTimeValue.DataSource = this.m_dtTimeValue;
            for (int i = 7; i <= 87; i += 8)
            {
                this.m_dgvTimeValue.Rows[i].DividerHeight = 1;
            }
            this.m_dgvUnit.DataSource = this.m_dtUnit;
            this.m_dgvUnit.Rows[0].Height = 26;
            for (int j = 0; j < 13; j++)
            {
                this.m_dgvUnit.Rows[j].Cells[0].Style.BackColor = this.lblMonday.BackColor;
                this.m_dgvUnit.Rows[j].Cells[0].Style.SelectionBackColor = this.lblMonday.BackColor;
            }
            this.setTimeValue();
        }

        private void m_dgvTimeValue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex % 2) != 0)
            {
                this.changeColor(this.m_dgvTimeValue.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            }
        }

        private void m_dgvTimeValue_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex % 2) == 0)
            {
                this.m_dvRow = -1;
                this.m_dvColumn = -1;
            }
            else
            {
                this.bIsMove = true;
                this.bIsDown = true;
                this.m_dvRow = e.RowIndex;
                this.m_dvColumn = e.ColumnIndex;
            }
        }

        private void m_dgvTimeValue_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex % 2) != 0)
            {
                this.m_dgvTimeValue.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = this.getTime(e.RowIndex);
            }
        }

        private void m_dgvTimeValue_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (((e.ColumnIndex % 2) == 0) || (e.ColumnIndex != this.m_dvColumn))
            {
                this.m_dvRow = -1;
            }
            else if ((this.bIsDown && (this.m_dvRow != e.RowIndex)) && (this.m_dvRow != -1))
            {
                if (this.bIsMove)
                {
                    this.changeColor(this.m_dgvTimeValue.Rows[this.m_dvRow].Cells[e.ColumnIndex]);
                    this.bIsMove = false;
                    this.bMove = true;
                }
                if (e.RowIndex > this.m_dvRow)
                {
                    for (int i = this.m_dvRow + 1; i <= e.RowIndex; i++)
                    {
                        this.changeColor(this.m_dgvTimeValue.Rows[i].Cells[e.ColumnIndex]);
                    }
                    this.bUTDChanged = true;
                    if (this.bDTUChanged)
                    {
                        this.changeColor(this.m_dgvTimeValue.Rows[this.m_dvRow].Cells[e.ColumnIndex]);
                        this.bDTUChanged = false;
                    }
                    this.m_dvRow = e.RowIndex;
                }
                else
                {
                    for (int j = this.m_dvRow - 1; j >= e.RowIndex; j--)
                    {
                        this.changeColor(this.m_dgvTimeValue.Rows[j].Cells[e.ColumnIndex]);
                    }
                    this.bDTUChanged = true;
                    if (this.bUTDChanged)
                    {
                        this.changeColor(this.m_dgvTimeValue.Rows[this.m_dvRow].Cells[e.ColumnIndex]);
                        this.bUTDChanged = false;
                    }
                    this.m_dvRow = e.RowIndex;
                }
            }
        }

        private void m_dgvTimeValue_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.bIsDown = false;
            this.bUTDChanged = false;
            this.bDTUChanged = false;
            if (this.bMove && this.bIsDown)
            {
                this.changeColor(this.m_dgvTimeValue.Rows[this.m_dvRow].Cells[e.ColumnIndex]);
                this.bMove = false;
            }
            if (((this.m_dvColumn != -1) && ((e.ColumnIndex % 2) != 0)) && ((this.m_dvRow != e.RowIndex) || (this.m_dvColumn != e.ColumnIndex)))
            {
                for (int i = 0; i < 96; i++)
                {
                    DataGridViewCell cell = this.m_dgvTimeValue.Rows[i].Cells[e.ColumnIndex];
                    DataGridViewCell cell2 = this.m_dgvTimeValue.Rows[i].Cells[this.m_dvColumn];
                    if (cell2.Style.BackColor != cell.Style.BackColor)
                    {
                        cell.Style.BackColor = cell2.Style.BackColor;
                        cell.Style.SelectionBackColor = cell2.Style.SelectionBackColor;
                    }
                }
            }
        }

        private void m_dgvTimeValue_MouseUp(object sender, MouseEventArgs e)
        {
            this.bIsDown = false;
            this.bUTDChanged = false;
            this.bDTUChanged = false;
        }

        private void setTimeValue()
        {
            try
            {
                string sSimNum = base.sCarSimNum.Split(new char[] { ',' })[0];
                this.dtLCSParam = this.getCarLBSParam(sSimNum);
                this.initDataGridView();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置定位时间信息", exception.Message);
                MessageBox.Show("初始化失败");
            }
        }

        private void setTimeValue(string strTimeValue)
        {
            if ((strTimeValue != null) && (strTimeValue.Length > 0))
            {
                string[] strArray = strTimeValue.Split(new char[] { ';' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if ((strArray[i] != null) && (strArray[i].Length > 0))
                    {
                        foreach (string str in strArray[i].Split(new char[] { ',' }))
                        {
                            if ((str != null) && (str.Length > 0))
                            {
                                this.changeColor(this.m_dgvTimeValue.Rows[Convert.ToInt32(str)].Cells[(i * 2) + 1]);
                            }
                        }
                    }
                }
            }
        }

        private void setTimeValue(string p, int week)
        {
            if (week == 0)
            {
                week = 7;
            }
            foreach (string str in p.Split(new char[] { ',' }))
            {
                if ((str != null) && (str.Length > 0))
                {
                    this.changeColor(this.m_dgvTimeValue.Rows[this.TimeToInt(str)].Cells[(week * 2) - 1]);
                }
            }
        }

        private int TimeToInt(string strTimeValue)
        {
            string[] strArray = strTimeValue.Split(new char[] { ':' });
            return ((Convert.ToInt32(strArray[0]) * 4) + (Convert.ToInt32(strArray[1]) / 15));
        }
    }
}

