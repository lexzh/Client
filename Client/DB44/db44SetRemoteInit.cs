namespace Client.DB44
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;
    using Library;

    public partial class db44SetRemoteInit : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public db44SetRemoteInit(CmdParam.OrderCode cmdOrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = cmdOrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(null, null);
                if (!string.IsNullOrEmpty(base.sValue))
                {
                    this.getParam();
                    if ((this.m_SimpleCmd.CmdParams != null) && (this.m_SimpleCmd.CmdParams.Count != 0))
                    {
                        base.reResult = RemotingClient.DownData_icar_SetCommonCmd_XCJLY(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
            }
            catch (Exception exception)
            {
                Record.execFileRecord("移动实时监控", exception.Message);
            }
        }

        private void chkCarId_CheckedChanged(object sender, EventArgs e)
        {
            if (base.OrderCode != CmdParam.OrderCode.远程参数查看)
            {
                this.txtCarId.Enabled = this.chkCarId.Checked;
                this.txtCarNum.Enabled = this.chkCarNum.Checked;
                this.txtCarType.Enabled = this.chkCarType.Checked;
                this.txtDriveCode.Enabled = this.chkDriveCode.Checked;
                this.txtDriveCId.Enabled = this.chkDriveCId.Checked;
                this.dtpInitDate.Enabled = this.chkInitDate.Checked;
                this.txtAdminCenter.Enabled = this.chkAdminCenter.Checked;
                this.numAdminCenter.Enabled = this.chkAdminCenter.Checked;
                this.txtBakCenter.Enabled = this.chkBakCenter.Checked;
                this.numBakCenter.Enabled = this.chkBakCenter.Checked;
                this.txtMessageCenter.Enabled = this.chkMessageCenter.Checked;
                this.txtMessageNum1.Enabled = this.chkMessageNum1.Checked;
                this.txtMessageNum2.Enabled = this.chkMessageNum2.Checked;
                this.cmbSpeedType.Enabled = this.chkSpeedType.Checked;
                this.cmbGpsSwitch.Enabled = this.chkGpsSwitch.Checked;
            }
        }

        private void chkCarId_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            ArrayList list = new ArrayList(3);
            ArrayList list2 = new ArrayList(2);
            list.Add("chkCarId");
            list2.Add("chkDriveCode");
            list.Add("chkCarNum");
            list2.Add("chkDriveCId");
            list.Add("chkCarType");
            if (list.Contains(box.Name))
            {
                this.chkCarId.Checked = this.chkCarNum.Checked = this.chkCarType.Checked = box.Checked;
            }
            else if (list2.Contains(box.Name))
            {
                this.chkDriveCode.Checked = this.chkDriveCId.Checked = box.Checked;
            }
        }

        private void db44SetRemoteInit_Load(object sender, EventArgs e)
        {
            this.InitForm();
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.远程参数查看)
            {
                if (this.chkCarId.Checked)
                {
                    string[] strArray = new string[] { "1" };
                    list.Add(strArray);
                }
                if (this.chkCarNum.Checked)
                {
                    string[] strArray2 = new string[] { "2" };
                    list.Add(strArray2);
                }
                if (this.chkCarType.Checked)
                {
                    string[] strArray3 = new string[] { "3" };
                    list.Add(strArray3);
                }
                if (this.chkDriveCode.Checked)
                {
                    string[] strArray4 = new string[] { "4" };
                    list.Add(strArray4);
                }
                if (this.chkDriveCId.Checked)
                {
                    string[] strArray5 = new string[] { "5" };
                    list.Add(strArray5);
                }
                if (this.chkMIDId.Checked)
                {
                    string[] strArray6 = new string[] { "6" };
                    list.Add(strArray6);
                }
                if (this.chkVersion.Checked)
                {
                    string[] strArray7 = new string[] { "7" };
                    list.Add(strArray7);
                }
                if (this.chkInitDate.Checked)
                {
                    string[] strArray8 = new string[] { "8" };
                    list.Add(strArray8);
                }
                if (this.chkRealTime.Checked)
                {
                    string[] strArray9 = new string[] { "9" };
                    list.Add(strArray9);
                }
                if (this.chkAdminCenter.Checked)
                {
                    string[] strArray10 = new string[] { "10" };
                    list.Add(strArray10);
                }
                if (this.chkBakCenter.Checked)
                {
                    string[] strArray11 = new string[] { "11" };
                    list.Add(strArray11);
                }
                if (this.chkMessageCenter.Checked)
                {
                    string[] strArray12 = new string[] { "12" };
                    list.Add(strArray12);
                }
                if (this.chkMessageNum1.Checked)
                {
                    string[] strArray13 = new string[] { "13" };
                    list.Add(strArray13);
                }
                if (this.chkMessageNum2.Checked)
                {
                    string[] strArray14 = new string[] { "14" };
                    list.Add(strArray14);
                }
                if (this.chkParam.Checked)
                {
                    string[] strArray15 = new string[] { "15" };
                    list.Add(strArray15);
                }
                if (this.chkSpeedType.Checked)
                {
                    string[] strArray16 = new string[] { "51" };
                    list.Add(strArray16);
                }
                if (this.chkGpsSwitch.Checked)
                {
                    string[] strArray17 = new string[] { "240" };
                    list.Add(strArray17);
                }
            }
            else if (base.OrderCode == CmdParam.OrderCode.远程参数设置)
            {
                if (this.chkCarId.Checked)
                {
                    string text = this.txtCarId.Text;
                    if (string.IsNullOrEmpty(text))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkCarId.Text));
                        this.txtCarId.Focus();
                        return false;
                    }
                    if (Encoding.Default.GetBytes(text).Length > 17)
                    {
                        MessageBox.Show(string.Format("{0}超过17字节", this.chkCarId.Text));
                        this.txtCarId.Focus();
                        return false;
                    }
                    string[] strArray18 = new string[] { "1", text };
                    list.Add(strArray18);
                }
                if (this.chkCarNum.Checked)
                {
                    string str2 = this.txtCarNum.Text;
                    if (string.IsNullOrEmpty(str2))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkCarNum.Text));
                        this.txtCarNum.Focus();
                        return false;
                    }
                    if (Encoding.Default.GetBytes(str2).Length > 12)
                    {
                        MessageBox.Show(string.Format("{0}超过12字节", this.chkCarNum.Text));
                        this.txtCarNum.Focus();
                        return false;
                    }
                    string[] strArray19 = new string[] { "2", str2 };
                    list.Add(strArray19);
                }
                if (this.chkCarType.Checked)
                {
                    string str3 = this.txtCarType.Text;
                    if (string.IsNullOrEmpty(str3))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkCarType.Text));
                        this.txtCarType.Focus();
                        return false;
                    }
                    if (Encoding.Default.GetBytes(str3).Length > 12)
                    {
                        MessageBox.Show(string.Format("{0}超过12字节", this.chkCarType.Text));
                        this.txtCarType.Focus();
                        return false;
                    }
                    string[] strArray20 = new string[] { "3", str3 };
                    list.Add(strArray20);
                }
                if (this.chkDriveCode.Checked)
                {
                    string str4 = this.txtDriveCode.Text;
                    if (string.IsNullOrEmpty(str4))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkDriveCode.Text));
                        this.txtDriveCode.Focus();
                        return false;
                    }
                    string[] strArray21 = new string[] { "4", str4 };
                    list.Add(strArray21);
                }
                if (this.chkDriveCId.Checked)
                {
                    string str5 = this.txtDriveCId.Text;
                    if (string.IsNullOrEmpty(str5))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkDriveCId.Text));
                        this.txtDriveCId.Focus();
                        return false;
                    }
                    if (Encoding.Default.GetBytes(str5).Length > 18)
                    {
                        MessageBox.Show(string.Format("{0}超过18字节", this.chkDriveCId.Text));
                        this.txtDriveCId.Focus();
                        return false;
                    }
                    string[] strArray22 = new string[] { "5", str5 };
                    list.Add(strArray22);
                }
                if (this.chkInitDate.Checked)
                {
                    string str6 = this.dtpInitDate.Value.ToString("yyyyMMddHHmmss");
                    if (string.IsNullOrEmpty(str6))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkInitDate.Text));
                        this.dtpInitDate.Focus();
                        return false;
                    }
                    string[] strArray23 = new string[] { "8", str6 };
                    list.Add(strArray23);
                }
                if (this.chkRealTime.Checked)
                {
                    string dBCurrentDateTime = RemotingClient.GetDBCurrentDateTime();
                    if (string.IsNullOrEmpty(dBCurrentDateTime))
                    {
                        MessageBox.Show("获取数据库时间失败！");
                        this.chkRealTime.Focus();
                        return false;
                    }
                    string[] strArray24 = new string[] { "9", DateTime.Parse(dBCurrentDateTime).ToString("yyyyMMddHHmmss") };
                    list.Add(strArray24);
                }
                if (this.chkAdminCenter.Checked)
                {
                    string str8 = this.txtAdminCenter.Text;
                    if (string.IsNullOrEmpty(str8))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkAdminCenter.Text));
                        this.txtAdminCenter.Focus();
                        return false;
                    }
                    if (!Check.CheckIpAddress(str8))
                    {
                        MessageBox.Show(string.Format("{0}地址格式有误！", this.chkAdminCenter.Text));
                        this.txtAdminCenter.Focus();
                        return false;
                    }
                    string[] strArray25 = new string[] { "10", string.Format("{0}:{1}", str8, this.numAdminCenter.Value) };
                    list.Add(strArray25);
                }
                if (this.chkBakCenter.Checked)
                {
                    string str9 = this.txtBakCenter.Text;
                    if (string.IsNullOrEmpty(str9))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkBakCenter.Text));
                        this.txtBakCenter.Focus();
                        return false;
                    }
                    if (!Check.CheckIpAddress(str9))
                    {
                        MessageBox.Show(string.Format("{0}地址格式有误！", this.chkBakCenter.Text));
                        this.txtBakCenter.Focus();
                        return false;
                    }
                    string[] strArray26 = new string[] { "11", string.Format("{0}:{1}", str9, this.numBakCenter.Value) };
                    list.Add(strArray26);
                }
                if (this.chkMessageCenter.Checked)
                {
                    string str10 = this.txtMessageCenter.Text;
                    if (string.IsNullOrEmpty(str10))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkMessageCenter.Text));
                        this.txtMessageCenter.Focus();
                        return false;
                    }
                    string[] strArray27 = new string[] { "12", str10 };
                    list.Add(strArray27);
                }
                if (this.chkMessageNum1.Checked)
                {
                    string str11 = this.txtMessageNum1.Text;
                    if (string.IsNullOrEmpty(str11))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkMessageNum1.Text));
                        this.txtMessageNum1.Focus();
                        return false;
                    }
                    string[] strArray28 = new string[] { "13", str11 };
                    list.Add(strArray28);
                }
                if (this.chkMessageNum2.Checked)
                {
                    string str12 = this.txtMessageNum2.Text;
                    if (string.IsNullOrEmpty(str12))
                    {
                        MessageBox.Show(string.Format("请输入{0}", this.chkMessageNum2.Text));
                        this.txtMessageNum2.Focus();
                        return false;
                    }
                    string[] strArray29 = new string[] { "14", str12 };
                    list.Add(strArray29);
                }
                if (this.chkSpeedType.Checked)
                {
                    string[] strArray30 = new string[] { "51", this.cmbSpeedType.SelectedValue.ToString() };
                    list.Add(strArray30);
                }
                if (this.chkGpsSwitch.Checked)
                {
                    string[] strArray31 = new string[] { "240", this.cmbGpsSwitch.SelectedValue.ToString() };
                    list.Add(strArray31);
                }
            }
            if (list.Count <= 0)
            {
                MessageBox.Show("请选择下发参数");
                return false;
            }
            this.m_SimpleCmd.CmdParams = list;
            return true;
        }

        private void InitForm()
        {
            if (base.OrderCode == CmdParam.OrderCode.远程参数设置)
            {
                this.pnlReadOnly.Visible = false;
                this.cmbSpeedType.addItems("传感器速度", 0);
                this.cmbSpeedType.addItems("GPS速度", 1);
                this.cmbGpsSwitch.addItems("不上传", 0);
                this.cmbGpsSwitch.addItems("上传", 1);
            }
            else
            {
                foreach (Control control in this.pnlSetParam.Controls)
                {
                    if (control.GetType().Name != "CheckBox")
                    {
                        control.Visible = false;
                    }
                }
            }
        }

 private void txtMessageCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

