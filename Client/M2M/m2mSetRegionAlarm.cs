namespace Client.M2M
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class m2mSetRegionAlarm : CarForm
    {
        private static string ERRORPATHAlARM = "解析区域失败！";
        private DataTable m_dtRegion = new DataTable();
        private static int m_iSelectCntMax = 64;
        private RegionAlarmList m_RegionAlarmList = new RegionAlarmList();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mSetRegionAlarm(CmdParam.OrderCode OrderCode, string sTitle)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.Text = sTitle;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRegionFeature = 0;
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue) && this.getParam(iRegionFeature))
                {
                    if (base.OrderCode == CmdParam.OrderCode.区域报警设置)
                    {
                        base.reResult = RemotingClient.DownData_SetRegionAlarm_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                    }
                    else if (base.OrderCode == CmdParam.OrderCode.行车记录设置)
                    {
                        base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
                if (this.getRegionType(i) >= 0)
                {
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
                if (base.OrderCode == CmdParam.OrderCode.行车记录设置)
                {
                    if ((cell.OwningColumn.Name == "InRegion") && bool.Parse(cell.Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["OutRegion"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["InOutRegion"].Value = false;
                    }
                    if ((cell.OwningColumn.Name == "OutRegion") && bool.Parse(cell.Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["InRegion"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["InOutRegion"].Value = false;
                    }
                    if ((cell.OwningColumn.Name == "InOutRegion") && bool.Parse(cell.Value.ToString()))
                    {
                        this.dgvArea.Rows[rowIndex].Cells["InRegion"].Value = false;
                        this.dgvArea.Rows[rowIndex].Cells["OutRegion"].Value = false;
                    }
                }
                else if (base.OrderCode == CmdParam.OrderCode.区域报警设置)
                {
                    if (cell.OwningColumn.Name == "InRegion")
                    {
                        if (bool.Parse(cell.Value.ToString()))
                        {
                            this.dgvArea.Rows[rowIndex].Cells["OutRegion"].Value = false;
                        }
                        else if (!bool.Parse(this.dgvArea.Rows[e.RowIndex].Cells["OutRegion"].Value.ToString()))
                        {
                            this.bSameChange = true;
                            this.dgvArea.Rows[rowIndex].Cells["InOutRegion"].Value = false;
                            this.bSameChange = false;
                        }
                    }
                    if (cell.OwningColumn.Name == "OutRegion")
                    {
                        if (bool.Parse(cell.Value.ToString()))
                        {
                            this.dgvArea.Rows[rowIndex].Cells["InRegion"].Value = false;
                        }
                        else if (!bool.Parse(this.dgvArea.Rows[e.RowIndex].Cells["InRegion"].Value.ToString()))
                        {
                            this.bSameChange = true;
                            this.dgvArea.Rows[rowIndex].Cells["InOutRegion"].Value = false;
                            this.bSameChange = false;
                        }
                    }
                    if ((cell.OwningColumn.Name == "InOutRegion") && !this.bSameChange)
                    {
                        this.bSameChange = true;
                        if ((!bool.Parse(this.dgvArea.Rows[e.RowIndex].Cells["InRegion"].Value.ToString()) && !bool.Parse(this.dgvArea.Rows[e.RowIndex].Cells["OutRegion"].Value.ToString())) && bool.Parse(this.dgvArea.Rows[e.RowIndex].Cells["InOutRegion"].Value.ToString()))
                        {
                            this.bSameChange = true;
                            this.dgvArea.Rows[e.RowIndex].Cells["InOutRegion"].Value = false;
                            this.bSameChange = false;
                            MessageBox.Show("请先选中越入或越出！再设置主区域");
                        }
                        else
                        {
                            bool flag = false;
                            foreach (DataGridViewRow row in (IEnumerable) this.dgvArea.Rows)
                            {
                                DataGridViewCheckBoxCell cell2 = row.Cells["InOutRegion"] as DataGridViewCheckBoxCell;
                                if (((cell2 != null) && bool.Parse(cell2.Value.ToString())) && (row.Index != e.RowIndex))
                                {
                                    flag = true;
                                    this.bSameChange = true;
                                    cell2.Value = false;
                                    this.bSameChange = false;
                                }
                                this.bSameChange = false;
                            }
                            if (flag)
                            {
                                this.bSameChange = true;
                                this.dgvArea.Rows[rowIndex].Cells["InOutRegion"].Value = true;
                                this.bSameChange = false;
                            }
                        }
                    }
                }
            }
        }

 private bool getParam(int iRegionFeature)
        {
            if (base.OrderCode == CmdParam.OrderCode.区域报警设置)
            {
                int num = 0;
                string str = "";
                int num2 = 0;
                string str2 = "";
                if (!this.chkSeletRegion())
                {
                    this.dgvArea.Focus();
                    return false;
                }
                this.m_RegionAlarmList = new RegionAlarmList();
                for (int i = 0; i < this.dgvArea.Rows.Count; i++)
                {
                    int num4 = this.getRegionType(i);
                    if (num4 >= 0)
                    {
                        ArrayList list = new ArrayList();
                        RegionAlarm alarm = new RegionAlarm();
                        str = this.dgvArea.Rows[i].Cells["RegionName"].Value.ToString(); ///ToString
                        num2 = int.Parse(this.dgvArea.Rows[i].Cells["RegionId"].Value.ToString());
                        if (bool.Parse(this.dgvArea.Rows[i].Cells["InOutRegion"].Value.ToString()))
                        {
                            alarm.newRegionId = 0;
                        }
                        else
                        {
                            alarm.newRegionId = num2;
                        }
                        alarm.PathName = str;
                        alarm.RegionType = num4;
                        alarm.RegionID = num2;
                        str2 = this.dgvArea.Rows[i].Cells["RegionDot"].Value.ToString(); ///ToString
                        alarm.AlarmRegionDot = num4 + @"\" + str2.Replace("*", @"\").Trim(new char[] { '\\' });
                        string[] strArray = str2.Split(new char[] { '*' });
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
                        this.m_RegionAlarmList.Add(alarm);
                    }
                }
                this.m_RegionAlarmList.OrderCode = base.OrderCode;
            }
            else if (base.OrderCode == CmdParam.OrderCode.行车记录设置)
            {
                if (!this.chkSeletRegion())
                {
                    this.dgvArea.Focus();
                    return false;
                }
                this.m_SimpleCmd.OrderCode = CmdParam.OrderCode.行车记录设置;
                ArrayList list2 = new ArrayList();
                for (int k = 0; k < this.dgvArea.Rows.Count; k++)
                {
                    int num7 = this.getRegionType(k);
                    if (num7 >= 0)
                    {
                        string[] strArray3 = new string[4];
                        strArray3[0] = "1";
                        strArray3[1] = this.numStartIndex.Value.ToString();
                        string[] strArray4 = this.dgvArea.Rows[k].Cells["RegionDot"].Value.ToString().Replace("*", @"\").Trim(new char[] { '\\' }).Split(new char[] { '\\' });
                        strArray3[2] = strArray4[2] + "," + strArray4[3] + "," + strArray4[6] + "," + strArray4[7];
                        strArray3[3] = num7.ToString();
                        list2.Add(strArray3);
                    }
                }
                this.m_SimpleCmd.CmdParams = list2;
            }
            return true;
        }

        private int getRegionType(int iRow)
        {
            int num = -1;
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["InRegion"].Value.ToString()))
            {
                num = 1;
            }
            if (bool.Parse(this.dgvArea.Rows[iRow].Cells["OutRegion"].Value.ToString()))
            {
                num = 0;
            }
            if ((base.OrderCode == CmdParam.OrderCode.行车记录设置) && bool.Parse(this.dgvArea.Rows[iRow].Cells["InOutRegion"].Value.ToString()))
            {
                num = 2;
            }
            return num;
        }

        private void InitData()
        {
            this.InitDataSource();
            int iRegionFeature = 0;
            DataTable table = RemotingClient.Car_GetRegionInfo(MainForm.myCarList.SelectedCarId, iRegionFeature);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string str2 = table.Rows[i]["regionName"].ToString();
                    string str3 = table.Rows[i]["RegionId"].ToString();
                    string sRegionDot = table.Rows[i]["regionDot"].ToString();
                    string s = table.Rows[i]["regionType"].ToString();
                    if ((base.OrderCode != CmdParam.OrderCode.行车记录设置) || PublicClass.Check.isRectangle(sRegionDot))
                    {
                        DataRow row = this.m_dtRegion.NewRow();
                        row["regionName"] = str2;
                        row["regionId"] = str3;
                        row["regionDot"] = sRegionDot;
                        if (s.Length == 0)
                        {
                            this.m_dtRegion.Rows.Add(row);
                            continue;
                        }
                        int num3 = int.Parse(s);
                        if (base.OrderCode == CmdParam.OrderCode.行车记录设置)
                        {
                            switch (num3)
                            {
                                case 0:
                                    row["InRegion"] = false;
                                    row["OutRegion"] = true;
                                    row["InOutRegion"] = false;
                                    break;

                                case 1:
                                    row["InRegion"] = true;
                                    row["OutRegion"] = false;
                                    row["InOutRegion"] = false;
                                    break;

                                case 2:
                                    row["InRegion"] = false;
                                    row["OutRegion"] = false;
                                    row["InOutRegion"] = true;
                                    break;
                            }
                        }
                        else if (base.OrderCode == CmdParam.OrderCode.区域报警设置)
                        {
                            switch (num3)
                            {
                                case 0:
                                    row["InRegion"] = false;
                                    row["OutRegion"] = true;
                                    row["InOutRegion"] = table.Rows[i]["NewRegionId"].ToString() == "0";
                                    break;

                                case 1:
                                    row["InRegion"] = true;
                                    row["OutRegion"] = false;
                                    row["InOutRegion"] = table.Rows[i]["NewRegionId"].ToString() == "0";
                                    break;
                            }
                        }
                        this.m_dtRegion.Rows.Add(row);
                    }
                }
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
            this.dgvArea.DataSource = this.m_dtRegion;
        }

        private void initForm()
        {
            this.InitData();
            this.dgvArea.Columns["InRegion"].Tag = "Chk";
            this.dgvArea.Columns["OutRegion"].Tag = "Chk";
            this.dgvArea.Columns["InOutRegion"].Tag = "Chk";
            if (base.OrderCode == CmdParam.OrderCode.区域报警设置)
            {
                this.lblStartIndex.Text = "起始标号：";
                this.dgvArea.Columns["InRegion"].Visible = true;
                this.dgvArea.Columns["OutRegion"].Visible = true;
                this.dgvArea.Columns["InOutRegion"].Visible = true;
                this.pnlCarRecord.Visible = false;
                this.dgvArea.Columns["InOutRegion"].HeaderText = "主区域";
            }
            else if (base.OrderCode == CmdParam.OrderCode.行车记录设置)
            {
                this.pnlCarRecord.Visible = true;
                this.lblStartIndex.Text = "站点标号:";
                this.dgvArea.Columns["InRegion"].Visible = true;
                this.dgvArea.Columns["OutRegion"].Visible = true;
                this.dgvArea.Columns["InOutRegion"].Visible = true;
                this.dgvArea.Columns["InRegion"].HeaderText = "进站点";
                this.dgvArea.Columns["OutRegion"].HeaderText = "出站点";
                this.dgvArea.Columns["InOutRegion"].HeaderText = "穿越站点";
            }
        }

 private void SetAreaAlarm_Load(object sender, EventArgs e)
        {
            this.initForm();
        }
    }
}

