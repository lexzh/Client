using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParamLibrary.CmdParamInfo;
using ParamLibrary.Application;
using PublicClass;
using Remoting;

namespace Client
{
    public partial class itmRealTimeImage : Client.CarForm
    {
        private static string SaveCapture = "终端保存图片";

        private static string Driver = "驾驶员变更拍照";

        private CaptureEx m_CaptureEx = new CaptureEx();

        private StopCapture m_StopCapture = new StopCapture();

        private bool IsSimple;

        public itmRealTimeImage(CmdParam.OrderCode OrderCode)
        {
            InitializeComponent();
            this.lblWatchTimeExplain.Text = string.Concat("(0-", Variable.sNumMaxPicMonitorTime, ")");
            this.numWatchTime.Maximum = decimal.Parse(Variable.sNumMaxPicMonitorTime);
            base.OrderCode = OrderCode;
        }

        public itmRealTimeImage(CmdParam.OrderCode OrderCode, bool IsSimple)
        {
            this.InitializeComponent();
            this.lblWatchTimeExplain.Text = string.Concat("(0-", Variable.sNumMaxPicMonitorTime, ")");
            this.numWatchTime.Maximum = decimal.Parse(Variable.sNumMaxPicMonitorTime);
            base.OrderCode = OrderCode;
            this.IsSimple = IsSimple;
            this.setTag99999(this);
            this.setSimpleEnable();
        }

        private void btnAddPicTime_Click(object sender, EventArgs e)
        {
            string text = this.dtpPicParamTime.Text;
            bool flag = false;
            foreach (ListViewItem item in this.lvPicTimeList.Items)
            {
                if (!text.Equals(item.Text))
                {
                    continue;
                }
                flag = true;
                break;
            }
            if (!flag)
            {
                this.lvPicTimeList.Items.Add(text);
            }
            this.lvPicTimeList.Sort();
        }

        private void btnDelPicTime_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (ListViewItem item in this.lvPicTimeList.Items)
            {
                if (!item.Checked)
                {
                    continue;
                }
                flag = true;
                break;
            }
            if (!flag)
            {
                MessageBox.Show("请先选择要删除的时间点！");
                return;
            }
            if (MessageBox.Show("确定要删除所选择的时间点吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            foreach (ListViewItem listViewItem in this.lvPicTimeList.Items)
            {
                if (!listViewItem.Checked)
                {
                    continue;
                }
                this.lvPicTimeList.Items.Remove(listViewItem);
            }
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (string.IsNullOrEmpty(this.sValue))
            {
                return;
            }
            if (!this.getParam())
            {
                return;
            }
            if (base.OrderCode == CmdParam.OrderCode.停止图像监控)
            {
                this.reResult = RemotingClient.DownData_StopCapture(this.ParamType, this.sValue, this.sPw, CmdParam.CommMode.未知方式, this.m_StopCapture);
            }
            else if (base.OrderCode != CmdParam.OrderCode.定时抓拍图像监控)
            {
                if (base.OrderCode == CmdParam.OrderCode.实时图像监控)
                {
                    this.m_CaptureEx.protocolType = CarProtocolType.交通厅;
                }
                this.reResult = RemotingClient.DownData_SetCaptureEx(this.ParamType, this.sValue, this.sPw, CmdParam.CommMode.未知方式, this.m_CaptureEx);
            }
            else
            {
                string str = "";
                foreach (ListViewItem item in this.lvPicTimeList.Items)
                {
                    string text = item.Text;
                    char[] chrArray = new char[] { ':' };
                    str = (text.Split(chrArray)[0].Length != 2 ? string.Concat(str, "0", item.Text, ",") : string.Concat(str, item.Text, ","));
                }
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("请输入定时图像抓拍的时间段！");
                    return;
                }
                if (str != "")
                {
                    str = str.Substring(0, str.Length - 1);
                }
                this.reResult = RemotingClient.SetCarPicTimeParam(this.sCarSimNum, this.m_CaptureEx, str);
                string str1 = "成功";
                if (this.reResult.ResultCode != (long)0)
                {
                    str1 = "失败";
                }
                string str2 = "";
                string[] strArrays = this.sCarId.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string str3 = strArrays[i];
                    str2 = string.Concat(str2, "0|", str3, ";");
                }
                this.reResult.OrderIDParam = str2;
                object[] isMulitFramebool = new object[] { "定时抓拍时间-", str, "是否多帧-", this.m_CaptureEx.IsMulitFramebool, ",监控次数-", this.m_CaptureEx.Times, ",间隔时间-", (double)this.m_CaptureEx.Interval * 0.1, ",图像质量-", this.m_CaptureEx.Quality, ",图像亮度-", this.m_CaptureEx.Brightness, ",图像对比度-", this.m_CaptureEx.Contrast, ",图像饱和度-", this.m_CaptureEx.Saturation, ",图像色度", this.m_CaptureEx.Chroma, ",停车是否拍照-", this.m_CaptureEx.IsCapWhenStop };
                string str4 = string.Concat(isMulitFramebool);
                if (this.cmbShootingType.SelectedIndex == 1)
                {
                    str4 = string.Concat(str4, ",图像分辨率-", this.cmbImageResolution.SelectedItem.ToString());
                }
                string dBCurrentDateTime = RemotingClient.GetDBCurrentDateTime();
                if (string.IsNullOrEmpty(dBCurrentDateTime))
                {
                    dBCurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                string str5 = "0";
                string str6 = "发送";
                string str7 = base.OrderCode.ToString();
                string str8 = str4;
                MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(dBCurrentDateTime, this.sCarNum, str5, str6, str7, str1, str8);
            }
            if (this.reResult == null)
            {
                MessageBox.Show("该终端暂不支持此操作");
                base.Close();
                return;
            }
            if (this.reResult.ResultCode == (long)0)
            {
                base.DialogResult = DialogResult.OK;
                return;
            }
            MessageBox.Show(this.reResult.ErrorMsg);
        }

        private void cbSameTime_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpStartDate.Enabled = !this.cbSameTime.Checked;
            this.dtpEndDate.Enabled = !this.cbSameTime.Checked;
        }

        private bool checkDateTime()
        {
            if (this.dtpStartDate.Enabled && this.dtpStartDate.Value.Date > this.dtpEndDate.Value.Date || this.dtpStartDate.Enabled && this.dtpStartDate.Value.Date == this.dtpEndDate.Value.Date && this.dtpStartTime.Value >= this.dtpEndTime.Value || this.dtpStartDate.Enabled && this.dtpStartDate.Value < DateTime.Now.Date || !this.dtpStartDate.Enabled && this.dtpStartTime.Value == this.dtpEndTime.Value)
            {
                return false;
            }
            return true;
        }

        private void chkClientSave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsSaveCapture())
            {
                this.numWatchTime.Value = new decimal(0);
                this.numWatchTime.Enabled = false;
                return;
            }
            if (Variable.sAllowMultiShoot.Equals("1"))
            {
                this.numWatchTime.Enabled = true;
            }
            this.numWatchTime.Value = new decimal(1);
        }

        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDefault.Checked)
            {
                if (Variable.sAllowMultiShoot.Equals("1"))
                {
                    if (!this.chkClientSave.Checked)
                    {
                        this.numWatchTime.Value = new decimal(1);
                    }
                    this.numInterval.Value = new decimal(600);
                }
                this.trkQuality.Value = 3;
                this.trkLight.Value = 128;
                this.trkContrast.Value = 71;
                this.trkSaturation.Value = 64;
                this.trkChroma.Value = 128;
            }
        }

        private void cmbShootingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbShootingType.SelectedIndex == 0)
            {
                this.numInterval.Minimum = new decimal(0);
                this.label2.Text = "(0-65535)";
                this.lblIntervalExplain2.Visible = true;
                this.lblIntervalExplain2.Text = "0表示按最小间隔一直拍照";
                return;
            }
            this.numInterval.Minimum = new decimal(0);
            this.label2.Text = "(0-65535)";
            this.lblIntervalExplain2.Visible = true;
            this.lblIntervalExplain2.Text = "0表示按最小间隔一直录像";
        }

        private bool getParam()
        {
            int num = 0;
            for (int i = 0; i < this.grpCamera.Controls.Count; i++)
            {
                if (((CheckBox)this.grpCamera.Controls[i]).Checked)
                {
                    num = num | 1 << (i & 31);
                }
            }
            if (num == 0)
            {
                MessageBox.Show("请选择摄像头！");
                this.chkCamera1.Focus();
                return false;
            }
            if (base.OrderCode == CmdParam.OrderCode.停止图像监控)
            {
                this.m_StopCapture.CamerasID = (byte)num;
                this.m_StopCapture.OrderCode = base.OrderCode;
                this.m_StopCapture.Flag1 = 2147483647;
                this.m_StopCapture.Flag2 = 0;
                return true;
            }
            this.m_CaptureEx.OrderCode = base.OrderCode;
            this.m_CaptureEx.CamerasID = (byte)num;
            if (!this.chkMultiFrame.Checked)
            {
                this.m_CaptureEx.IsMultiFrame = 0;
            }
            else
            {
                this.m_CaptureEx.IsMultiFrame = 1;
            }
            if (!this.chkCapWhenStop.Checked)
            {
                this.m_CaptureEx.CapWhenStop = 0;
            }
            else
            {
                this.m_CaptureEx.CapWhenStop = 1;
            }
            int num1 = 0;
            int num2 = 0;
            if (base.OrderCode == CmdParam.OrderCode.多种条件图像监控)
            {
                foreach (CheckBox control in this.pnlWatchCondition.Controls)
                {
                    if (!control.Checked)
                    {
                        continue;
                    }
                    int num3 = int.Parse(control.Tag.ToString());
                    num1 = num1 | num3;
                    num2 = num2 | num3;
                }
            }
            else if (base.OrderCode == CmdParam.OrderCode.实时图像监控)
            {
                num2 = 1;
            }
            else if (base.OrderCode == CmdParam.OrderCode.自检)
            {
                this.grbPicParam.Visible = true;
            }
            if (!this.chkClientSave.Checked)
            {
                num1 = 0;
            }
            bool flag = this.IsSaveCapture();
            if (flag)
            {
                num1 = 1;
                num2 = 0;
            }
            if (base.OrderCode == CmdParam.OrderCode.实时图像监控)
            {
                num1 = (this.chkRealTimeClientSave.Checked ? 1 : 0);
            }
            this.m_CaptureEx.Times = Convert.ToInt32(this.numWatchTime.Value);
            this.m_CaptureEx.Interval = Convert.ToInt32(this.numInterval.Value);
            this.m_CaptureEx.Quality = Convert.ToByte(this.trkQuality.Value);
            this.m_CaptureEx.Brightness = Convert.ToByte(this.trkLight.Value);
            this.m_CaptureEx.Contrast = Convert.ToByte(this.trkContrast.Value);
            this.m_CaptureEx.Saturation = Convert.ToByte(this.trkSaturation.Value);
            this.m_CaptureEx.Chroma = Convert.ToByte(this.trkChroma.Value);
            this.m_CaptureEx.CaptureFlag = num2;
            this.m_CaptureEx.CaptureCache = num1;
            this.m_CaptureEx.Type = this.cmbShootingType.SelectedIndex;
            this.m_CaptureEx.PSize = this.cmbImageResolution.SelectedIndex + 1;
            if (!this.grpTime.Visible)
            {
                this.m_CaptureEx.BeginTime = string.Empty;
                this.m_CaptureEx.EndTime = string.Empty;
            }
            else
            {
                if (!this.checkDateTime())
                {
                    MessageBox.Show("开始时间不能小于结束时间或当前时间，请修改。");
                    return false;
                }
                if (!this.dtpStartDate.Enabled)
                {
                    CaptureEx mCaptureEx = this.m_CaptureEx;
                    DateTime value = this.dtpStartTime.Value;
                    mCaptureEx.BeginTime = string.Concat("000000", value.ToString("HHmmss"));
                    CaptureEx captureEx = this.m_CaptureEx;
                    DateTime dateTime = this.dtpEndTime.Value;
                    captureEx.EndTime = string.Concat("000000", dateTime.ToString("HHmmss"));
                }
                else
                {
                    CaptureEx mCaptureEx1 = this.m_CaptureEx;
                    string str = this.dtpStartDate.Value.ToString("yyMMdd");
                    DateTime value1 = this.dtpStartTime.Value;
                    mCaptureEx1.BeginTime = string.Concat(str, value1.ToString("HHmmss"));
                    CaptureEx captureEx1 = this.m_CaptureEx;
                    string str1 = this.dtpEndDate.Value.ToString("yyMMdd");
                    DateTime dateTime1 = this.dtpEndTime.Value;
                    captureEx1.EndTime = string.Concat(str1, dateTime1.ToString("HHmmss"));
                }
            }
            if (base.OrderCode != CmdParam.OrderCode.多种条件图像监控 || flag || this.m_CaptureEx.Times != 0)
            {
                return true;
            }
            MessageBox.Show("只有当只选终端保存图片时监控次数才能选0,其它条件下不能选0，请重新选择");
            this.numWatchTime.Focus();
            return false;
        }

        private string GetPicTime()
        {
            string str = "";
            foreach (ListViewItem item in this.lvPicTimeList.Items)
            {
                str = string.Concat(str, item.Text, ",");
            }
            if (str != "")
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private void ImageWatch_Load(object sender, EventArgs e)
        {
            try
            {
                this.initControlState();
                if (base.OrderCode == CmdParam.OrderCode.实时图像监控)
                {
                    this.chkRealTimeClientSave.Visible = true;
                }
                this.initControlValue();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void initControlState()
        {
            if (base.OrderCode == CmdParam.OrderCode.多种条件图像监控)
            {
                this.chkCapWhenStop.Visible = false;
                this.grpTime.Visible = true;
                Label label = this.lblShootingType;
                ComboBox comboBox = this.cmbShootingType;
                Label label1 = this.lblImageResolution;
                this.cmbImageResolution.Visible = false;
                label1.Visible = false;
                comboBox.Visible = false;
                label.Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.实时图像监控)
            {
                this.pnlWatchCondition.Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.停止图像监控)
            {
                this.pnlTransfers.Visible = false;
                this.pnlWatchCondition.Visible = false;
                this.grpWatchParam.Visible = false;
                this.grpImageParam.Text = "停止图像监控参数";
            }
            else if (base.OrderCode == CmdParam.OrderCode.定时抓拍图像监控)
            {
                this.grbPicParam.Visible = true;
                this.pnlWatchCondition.Visible = false;
            }
            if (!Variable.sAllowMultiShoot.Equals("1"))
            {
                this.pnlTransfers.Enabled = false;
                this.numWatchTime.Enabled = false;
                this.numInterval.Enabled = false;
                this.numInterval.Value = new decimal(100);
            }
        }

        private void initControlValue()
        {
            try
            {
                ComboBox comboBox = this.cmbShootingType;
                int num = 0;
                int num1 = num;
                this.cmbImageResolution.SelectedIndex = num;
                comboBox.SelectedIndex = num1;
                if (this.IsSimple)
                {
                    this.Text = "单次图像抓拍";
                }
                else if (base.OrderCode != CmdParam.OrderCode.停止图像监控)
                {
                    if (base.OrderCode == CmdParam.OrderCode.定时抓拍图像监控)
                    {
                        DataTable dataTable = null;
                        try
                        {
                            try
                            {
                                string str = "";
                                str = (this.sCarSimNum.IndexOf(',') <= 0 ? this.sCarSimNum : this.sCarSimNum.Substring(0, this.sCarSimNum.IndexOf(',')));
                                string str1 = string.Concat("select pictime from GpsCarPicParam where SimNum = '", str, "'");
                                dataTable = RemotingClient.ExecSql(str1);
                                if (dataTable != null && dataTable.Rows.Count > 0)
                                {
                                    string str2 = dataTable.Rows[0]["PicTime"].ToString();
                                    this.SetPicTime(str2);
                                }
                            }
                            catch (Exception exception)
                            {
                                Record.execFileRecord("获取定时抓拍图像监控", exception.Message);
                            }
                        }
                        finally
                        {
                            if (dataTable != null)
                            {
                                dataTable.Clear();
                                dataTable = null;
                            }
                        }
                    }
                    string[] strArrays = this.sCarId.Split(new char[] { ',' });
                    if (!string.IsNullOrEmpty(this.sCarId) && (int)strArrays.Length > 0)
                    {
                        DataTable dataTable1 = RemotingClient.Car_GetCaptureMoniterDataByCarId(strArrays[0]);
                        if (dataTable1 != null && dataTable1.Rows.Count != 0)
                        {
                            bool flag = (dataTable1.Rows[0]["IsMultiFrame"].ToString() == "1" ? true : false);
                            bool flag1 = (dataTable1.Rows[0]["capWhenStop"].ToString() == "1" ? true : false);
                            string str3 = dataTable1.Rows[0]["Times"].ToString();
                            string str4 = dataTable1.Rows[0]["CatchInterval"].ToString();
                            string str5 = dataTable1.Rows[0]["Quality"].ToString();
                            string str6 = dataTable1.Rows[0]["Brightness"].ToString();
                            string str7 = dataTable1.Rows[0]["Contrast"].ToString();
                            string str8 = dataTable1.Rows[0]["Saturation"].ToString();
                            string str9 = dataTable1.Rows[0]["Chroma"].ToString();
                            string str10 = dataTable1.Rows[0]["CamerasID"].ToString();
                            string str11 = dataTable1.Rows[0]["CapTureMask"].ToString();
                            string str12 = dataTable1.Rows[0]["CaptureFlag"].ToString();
                            int num2 = 0;
                            if (!string.IsNullOrEmpty(str10))
                            {
                                num2 = int.Parse(str10);
                            }
                            for (int i = 0; i < this.grpCamera.Controls.Count; i++)
                            {
                                CheckBox item = (CheckBox)this.grpCamera.Controls[i];
                                item.Checked = (num2 & 1 << (i & 31)) != 0;
                            }
                            if (Variable.sAllowMultiShoot.Equals("1"))
                            {
                                if (decimal.Parse(str3) <= this.numWatchTime.Maximum)
                                {
                                    this.numWatchTime.Value = decimal.Parse(str3);
                                }
                                else
                                {
                                    this.numWatchTime.Value = this.numWatchTime.Maximum;
                                }
                                this.numInterval.Value = decimal.Parse(str4);
                            }
                            this.trkQuality.Value = int.Parse(str5);
                            this.trkLight.Value = int.Parse(str6);
                            this.trkContrast.Value = int.Parse(str7);
                            this.trkSaturation.Value = int.Parse(str8);
                            this.trkChroma.Value = int.Parse(str9);
                            this.chkMultiFrame.Checked = flag;
                            this.chkCapWhenStop.Checked = flag1;
                            int num3 = 0;
                            int num4 = 0;
                            if (!string.IsNullOrEmpty(str11))
                            {
                                num3 = int.Parse(str11);
                            }
                            if (!string.IsNullOrEmpty(str12))
                            {
                                num4 = int.Parse(str12);
                            }
                            if (base.OrderCode == CmdParam.OrderCode.多种条件图像监控)
                            {
                                foreach (CheckBox control in this.pnlWatchCondition.Controls)
                                {
                                    long num5 = long.Parse(control.Tag.ToString());
                                    control.Checked = ((long)num4 & num5) != (long)0;
                                    if (!(control.Text == SaveCapture) || num3 == 0)
                                    {
                                        continue;
                                    }
                                    control.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                Exception exception1 = exception2;
                Record.execFileRecord(base.OrderCode.ToString(), exception1.Message);
            }
        }

        private bool IsSaveCapture()
        {
            for (int i = 0; i < this.pnlWatchCondition.Controls.Count; i++)
            {
                CheckBox item = (CheckBox)this.pnlWatchCondition.Controls[i];
                if (item.Text != SaveCapture && item.Text != Driver && item.Checked)
                {
                    return false;
                }
                if (item.Text == SaveCapture && !item.Checked)
                {
                    return false;
                }
            }
            return true;
        }

        private void lbPicTimeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPicTimeList.SelectedItems.Count > 0)
            {
                this.dtpPicParamTime.Text = this.lvPicTimeList.SelectedItems[0].Text;
            }
        }

        private void SetPicTime(string spicTime)
        {
            string[] strArrays = spicTime.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                if (!string.IsNullOrEmpty(str))
                {
                    this.lvPicTimeList.Items.Add(str);
                }
            }
        }

        private void setSimpleEnable()
        {
            this.pnlTransfers.Visible = true;
            this.pnlWatchCondition.Visible = false;
            this.grbPicParam.Visible = false;
            this.numWatchTime.Enabled = false;
            this.numInterval.Enabled = false;
        }

        private void setTag99999(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control.Tag == null || !control.Tag.Equals("999"))
                {
                    control.Tag = "99999";
                }
                this.setTag99999(control);
            }
        }

        private void trkChroma_ValueChanged(object sender, EventArgs e)
        {
            this.lblChromaValue.Text = this.trkChroma.Value.ToString();
        }

        private void trkContrast_ValueChanged(object sender, EventArgs e)
        {
            this.lblContrastValue.Text = this.trkContrast.Value.ToString();
        }

        private void trkImageLight_ValueChanged(object sender, EventArgs e)
        {
            this.lblImageLightValue.Text = this.trkLight.Value.ToString();
        }

        private void trkQuality_ValueChanged(object sender, EventArgs e)
        {
            this.lblQualityValue.Text = this.trkQuality.Value.ToString();
        }

        private void trkSaturation_ValueChanged(object sender, EventArgs e)
        {
            this.lblSaturationValue.Text = this.trkSaturation.Value.ToString();
        }
    }
}
