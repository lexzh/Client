namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmSetRegionAlarmEx : FixedForm
    {
        private BindingSource _AllCarBindingSource = new BindingSource();
        private BindingSource _EndPointBindingSource = new BindingSource();
        private BindingSource _SelectCarBindingSource = new BindingSource();
        private BindingSource _StartPointBindingSource = new BindingSource();
        private BackgroundWorker _worker = new BackgroundWorker();
        private static string ERRORPATHAlARM = "解析区域失败！";
        private RegionAlarmList m_RegionAlarmList = new RegionAlarmList();
        public CmdParam.ParamType ParamType;
        private Response reResult = new Response();
        private List<string> sValue = new List<string>();

        public itmSetRegionAlarmEx(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            this.OrderCode = OrderCode;
            this.Text = "批量设置区域报警";
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._worker_RunWorkerCompleted);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string[] strArray = this.sValue.ToArray();
                int length = strArray.Length;
                int num2 = 0;
                if (length > 1)
                {
                    foreach (string str in strArray)
                    {
                        this.reResult = RemotingClient.DownData_SetRegionAlarm_FJYD(CmdParam.ParamType.SimNum, str, "", CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                    }
                }
                else
                {
                    this.reResult = RemotingClient.DownData_SetRegionAlarm_FJYD(CmdParam.ParamType.SimNum, this.sValue[0], "", CmdParam.CommMode.未知方式, this.m_RegionAlarmList);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置区域报警-->", exception.Message);
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
            if (this.reResult.ResultCode != 0L)
            {
                MessageBox.Show(this.reResult.ErrorMsg);
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            base.Enabled = false;
            try
            {
                this.lbAllCar.SuspendLayout();
                this.grpCar.SuspendLayout();
                this.lbSelectCar.SuspendLayout();
                for (int i = 0; i < this.lbAllCar.Items.Count; i++)
                {
                    this.lbAllCar.SelectedIndex = i;
                    this.lbAllCar_MouseDoubleClick(null, null);
                }
                this.lbAllCar.ResumeLayout();
                this.grpCar.ResumeLayout();
                this.lbSelectCar.ResumeLayout();
            }
            catch
            {
                this.lbAllCar.ResumeLayout();
                this.grpCar.ResumeLayout();
                this.lbSelectCar.ResumeLayout();
            }
            base.Enabled = true;
        }

        private void btnAllUnSelect_Click(object sender, EventArgs e)
        {
            this._selectdt.Rows.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.getParam())
            {
                try
                {
                    if (!this._worker.IsBusy)
                    {
                        this.lblWaitText.Text = "正在运行中……";
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
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.lbAllCar_MouseDoubleClick(null, null);
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            this.lbSelectCar_MouseDoubleClick(null, null);
        }

 private bool getParam()
        {
            if (((this.lbStartPoint.SelectedItem == null) || (this.lbEndPoint.SelectedItem == null)) || (this.lbSelectCar.Items.Count == 0))
            {
                MessageBox.Show("请选择起点站、终点站、车辆！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (((DataRowView) this.lbStartPoint.SelectedItem).Row[0].ToString().Trim().Equals(((DataRowView) this.lbEndPoint.SelectedItem).Row[0].ToString().Trim()))
            {
                MessageBox.Show("起点站和终点站不能一样！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            int num = 0;
            this.m_RegionAlarmList = new RegionAlarmList();
            if (!this.getRegionAlarmList(true, ref this.m_RegionAlarmList))
            {
                return false;
            }
            if (!this.getRegionAlarmList(false, ref this.m_RegionAlarmList))
            {
                return false;
            }
            for (int i = 0; i < this.lbSelectCar.Items.Count; i++)
            {
                this.sValue.Add((this.lbSelectCar.Items[i] as DataRowView)["SimNum"].ToString());
            }
            if (this.sValue.Count == 0)
            {
                MessageBox.Show("请选择车辆!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_RegionAlarmList.RegionFeature = num;
            this.m_RegionAlarmList.OrderCode = this.OrderCode;
            return true;
        }

        private bool getRegionAlarmList(bool isStartPoint, ref RegionAlarmList m_RegionAlarmList)
        {
            int num = 0;
            string str = "";
            int num2 = 0;
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num3 = this.getRegionType(!isStartPoint);
            ArrayList list = new ArrayList();
            RegionAlarm alarm = new RegionAlarm();
            DataRow row = isStartPoint ? (this.lbStartPoint.SelectedItem as DataRowView).Row : (this.lbEndPoint.SelectedItem as DataRowView).Row;
            str = row["RegionName"].ToString() ?? "";
            num2 = Convert.ToInt32(row["RegionId"].ToString());
            alarm.newRegionId = num2;
            alarm.PathName = str;
            alarm.RegionType = num3;
            alarm.RegionID = num2;
            str4 = row["RegionDot"].ToString() ?? "";
            alarm.AlarmRegionDot = num3 + @"\" + str4.Replace("*", @"\").Trim(new char[] { '\\' });
            string[] strArray = str4.Split(new char[] { '*' });
            num += strArray.Length;
            for (int i = 0; i < (strArray.Length - 1); i++)
            {
                if (string.IsNullOrEmpty(strArray[i]))
                {
                    MessageBox.Show(ERRORPATHAlARM);
                    return false;
                }
                string[] strArray2 = strArray[i].Split(new char[] { '\\' });
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
            str2 = "";
            str3 = "";
            string sStr = "";
            string str6 = "";
            string str7 = "";
            alarm.toEndTime = this.getToTime(sStr);
            alarm.toBackTime = this.getToTime(sStr);
            alarm.param = this.GetRegionParam(isStartPoint);
            alarm.PlanUpTime = str6;
            alarm.PlanDownTime = str7;
            alarm.BeginTime = str2;
            alarm.EndTime = str3;
            m_RegionAlarmList.Add(alarm);
            return true;
        }

        private int GetRegionParam(bool isStartPoint)
        {
            int num = 0;
            if (isStartPoint)
            {
                num |= 1;
            }
            if (!isStartPoint)
            {
                num |= 4;
            }
            return num;
        }

        private int getRegionType(bool isInRegion)
        {
            int num = -1;
            if (isInRegion)
            {
                num = 1;
            }
            if (!isInRegion)
            {
                num = 0;
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

 private void lbAllCar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lbAllCar.SelectedItems != null)
            {
                for (int i = 0; i < this.lbAllCar.SelectedItems.Count; i++)
                {
                    DataRow row = (this.lbAllCar.SelectedItems[i] as DataRowView).Row;
                    if (this._selectdt.Rows.Find(row["CarId"]) == null)
                    {
                        this._selectdt.Rows.Add(row.ItemArray);
                    }
                }
            }
        }

        private void lbSelectCar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lbSelectCar.SelectedItems != null)
            {
                List<DataRow> list = new List<DataRow>();
                for (int i = 0; i < this.lbSelectCar.SelectedItems.Count; i++)
                {
                    list.Add((this.lbSelectCar.SelectedItems[i] as DataRowView).Row);
                }
                for (int j = 0; j < list.Count; j++)
                {
                    this._selectdt.Rows.Remove(list[j]);
                }
                list.Clear();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.lbAllCar.DisplayMember = this.lbSelectCar.DisplayMember = "CarNum";
            this.lbAllCar.ValueMember = this.lbSelectCar.ValueMember = "SimNum";
            this.lbStartPoint.DisplayMember = this.lbEndPoint.DisplayMember = "REgionName";
            this.lbStartPoint.ValueMember = this.lbEndPoint.ValueMember = "RegionDot";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
            this.lblWaitText.Text = "正在加载数据中……";
            this.SetControlEnable(false);
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            this.grpCar.Enabled = this.grpRegion.Enabled = this.btnCancel.Enabled = this.btnOK.Enabled = isuse;
        }

        private void txtAllCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (this._AllCarBindingSource.Current != null)
                {
                    DataRow row = (this._AllCarBindingSource.Current as DataRowView).Row;
                    if (this._selectdt.Rows.Find(row["CarId"]) == null)
                    {
                        this._selectdt.Rows.Add(row.ItemArray);
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                int selectedIndex = this.lbAllCar.SelectedIndex;
                this.lbAllCar.ClearSelected();
                if (selectedIndex < (this.lbAllCar.Items.Count - 1))
                {
                    this.lbAllCar.SelectedIndex = selectedIndex + 1;
                }
                else
                {
                    this.lbAllCar.SelectedIndex = 0;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                int num2 = this.lbAllCar.SelectedIndex;
                this.lbAllCar.ClearSelected();
                if (num2 > 0)
                {
                    this.lbAllCar.SelectedIndex = num2 - 1;
                }
                else
                {
                    this.lbAllCar.SelectedIndex = this.lbAllCar.Items.Count - 1;
                }
            }
        }

        private void txtAllCar_TextChanged(object sender, EventArgs e)
        {
            this._AllCarBindingSource.Filter = "CarNum like '%" + this.txtAllCar.Text + "%' Or PY like '%" + this.txtAllCar.Text + "%'";
        }

        private void txtEndPoint_TextChanged(object sender, EventArgs e)
        {
            this._EndPointBindingSource.Filter = "REgionName like '%" + this.txtEndPoint.Text + "%' Or PY like '%" + this.txtEndPoint.Text + "%'";
        }

        private void txtStartPoint_TextChanged(object sender, EventArgs e)
        {
            this._StartPointBindingSource.Filter = "REgionName like '%" + this.txtStartPoint.Text + "%' Or PY like '%" + this.txtStartPoint.Text + "%'";
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable allCar = MainForm.myCarList.GetAllCar();
            allCar.Columns.Add("PY");
            allCar.PrimaryKey = new DataColumn[] { allCar.Columns["CarID"] };
            DataTable table2 = RemotingClient.ExecSql("Select RegionID,RegionDot,REgionName From gpsRegionType");
            if (table2 != null)
            {
                table2.Columns.Add("PY");
            }
            new List<ListBoxItem>();
            new List<ListBoxItem>();
            new List<ListBoxItem>();
            if ((allCar != null) && (allCar.Rows.Count > 0))
            {
                foreach (DataRow row in allCar.Rows)
                {
                    row["PY"] = StringHelper.GetChineseSpell(row["CarNum"].ToString());
                }
            }
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                foreach (DataRow row2 in table2.Rows)
                {
                    row2["PY"] = StringHelper.GetChineseSpell(row2["REgionName"].ToString());
                }
            }
            this._AllCarBindingSource.DataSource = allCar;
            this._SelectCarBindingSource.DataSource = this._selectdt = allCar.Clone();
            this._StartPointBindingSource.DataSource = table2;
            this._EndPointBindingSource.DataSource = (table2 != null) ? table2.Copy() : new DataTable();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lbAllCar.DataSource = this._AllCarBindingSource;
            this.lbSelectCar.DataSource = this._SelectCarBindingSource;
            this.lbStartPoint.DataSource = this._StartPointBindingSource;
            this.lbEndPoint.DataSource = this._EndPointBindingSource;
            this.SetControlEnable(true);
        }
    }
}

