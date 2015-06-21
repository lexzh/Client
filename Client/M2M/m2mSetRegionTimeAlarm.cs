namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class m2mSetRegionTimeAlarm : CarForm
    {
        private static string ERRORPATHAlARM = "解析区域失败！";
        private DataTable m_dtRegion = new DataTable();
        private static int m_iSelectCntMax = 64;
        private RegionAlarmList m_RegionAlarmList = new RegionAlarmList();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mSetRegionTimeAlarm(CmdParam.OrderCode cmdOrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = cmdOrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue) && this.getParamRegion())
                {
                    base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                    if (base.reResult.ResultCode == 0L)
                    {
                        this.getParam();
                        base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                        if (base.reResult.ResultCode != 0L)
                        {
                            MessageBox.Show(base.reResult.ErrorMsg);
                        }
                        else
                        {
                            base.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show(base.reResult.ErrorMsg);
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
                if (bool.Parse(this.dgvArea.Rows[i].Cells["ColSel"].Value.ToString()))
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

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            if (this.chkSeletRegion())
            {
                this.numSpeed.Value.ToString();
                ArrayList list = new ArrayList();
                if (base.OrderCode == CmdParam.OrderCode.区域超时停车报警设置)
                {
                    string str = this.numSpeed.Value.ToString();
                    string str2 = this.rbtnRegionIn.Checked ? "0" : "1";
                    string str3 = "";
                    for (int i = 0; i < this.dgvArea.Rows.Count; i++)
                    {
                        if (bool.Parse(this.dgvArea.Rows[i].Cells["ColSel"].Value.ToString()))
                        {
                            str3 = str3 + this.dgvArea.Rows[i].Cells["RegionId"].Value.ToString() + ",";
                        }
                    }
                    string[] strArray = new string[] { "1", str, str3.Trim(new char[] { ',' }), str2 };
                    list.Add(strArray);
                }
                else if (base.OrderCode == CmdParam.OrderCode.区域外罐车反转报警设置)
                {
                    string str4 = "";
                    for (int j = 0; j < this.dgvArea.Rows.Count; j++)
                    {
                        if (bool.Parse(this.dgvArea.Rows[j].Cells["ColSel"].Value.ToString()))
                        {
                            str4 = str4 + this.dgvArea.Rows[j].Cells["RegionId"].Value.ToString() + ",";
                        }
                    }
                    string[] strArray2 = new string[] { "1", str4.Trim(new char[] { ',' }) };
                    list.Add(strArray2);
                }
                this.m_SimpleCmd.CmdParams = list;
            }
        }

        private bool getParamRegion()
        {
            this.m_SimpleCmd.OrderCode = CmdParam.OrderCode.区域设置;
            if (!this.chkSeletRegion())
            {
                return false;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.dgvArea.Rows.Count; i++)
            {
                if (bool.Parse(this.dgvArea.Rows[i].Cells["ColSel"].Value.ToString()))
                {
                    string sRegionDot = this.dgvArea.Rows[i].Cells["regionDot"].Value.ToString();
                    string[] strArray = new string[] { this.dgvArea.Rows[i].Cells["RegionId"].Value.ToString(), this.getRegionType(sRegionDot), sRegionDot.Replace("*", @"\").Trim(new char[] { '\\' }).Replace(@"\", ",") };
                    list.Add(strArray);
                }
            }
            this.m_SimpleCmd.CmdParams = list;
            return true;
        }

        private string getRegionType(string sRegionDot)
        {
            string[] strArray = sRegionDot.Replace("*", @"\").Trim(new char[] { '\\' }).Split(new char[] { '\\' });
            if (strArray.Length == 3)
            {
                return "1";
            }
            if (strArray.Length == 4)
            {
                return "2";
            }
            return "3";
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
                    string str4 = table.Rows[i]["RegionDot"].ToString();
                    DataRow row = this.m_dtRegion.NewRow();
                    row["colSel"] = false;
                    row["regionName"] = str2;
                    row["regionId"] = str3;
                    row["regionDot"] = str4;
                    this.m_dtRegion.Rows.Add(row);
                }
            }
        }

        private void InitDataSource()
        {
            this.m_dtRegion.Columns.Add("colSel");
            this.m_dtRegion.Columns.Add("regionName");
            this.m_dtRegion.Columns.Add("regionId");
            this.m_dtRegion.Columns.Add("regionDot");
            this.dgvArea.DataSource = this.m_dtRegion;
        }

        private void initForm()
        {
            if (base.OrderCode == CmdParam.OrderCode.区域超时停车报警设置)
            {
                this.grpSet.Visible = true;
                this.lblSpeed.Text = "超时时间:";
                this.lblSpeed2.Text = "分钟";
                this.numSpeed.Value = 60M;
            }
            else if (base.OrderCode == CmdParam.OrderCode.区域外罐车反转报警设置)
            {
                this.grpSet.Visible = false;
            }
        }

 private void m2mSetRegionSpeedAlarm_Load(object sender, EventArgs e)
        {
            this.initForm();
            this.InitData();
        }
    }
}

