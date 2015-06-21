namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class m2mMeter : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mMeter(CmdParam.OrderCode cmdOrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = cmdOrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
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
        }

        private void cmbDataUpdown_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string str = this.cmbDataUpdown.SelectedValue.ToString();
                if (str.Equals("0") || str.Equals("1"))
                {
                    this.numParams.Enabled = false;
                }
                else if ("2".Equals(str))
                {
                    this.numParams.Enabled = true;
                    this.numParams.Value = 30M;
                    this.lblParams.Text = "时间间隔：";
                    this.lblParamsUnit.Text = "分钟";
                }
                else if ("3".Equals(str))
                {
                    this.numParams.Enabled = true;
                    this.numParams.Value = 1M;
                    this.lblParams.Text = "交易笔数：";
                    this.lblParamsUnit.Text = "笔";
                }
            }
            catch
            {
            }
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            if (base.OrderCode == CmdParam.OrderCode.设置计价器)
            {
                string str = this.rbtnOpen.Checked ? "1" : "0";
                string str2 = this.cmbCarReport.SelectedValue.ToString();
                string str3 = this.cmbDataUpdown.SelectedValue.ToString();
                string str4 = this.numParams.Value.ToString();
                ArrayList list = new ArrayList();
                string[] strArray = new string[] { str, str2, str3, str4 };
                list.Add(strArray);
                this.m_SimpleCmd.CmdParams = list;
            }
            else if (base.OrderCode == CmdParam.OrderCode.查询计价器)
            {
                if (this.dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
                {
                    MessageBox.Show("开始时间大于结束时间");
                    this.dtpStartDate.Focus();
                    return false;
                }
                if ((this.dtpStartDate.Value.Date == this.dtpEndDate.Value.Date) && (this.dtpStartTime.Value.TimeOfDay > this.dtpEndTime.Value.TimeOfDay))
                {
                    MessageBox.Show("开始时间大于结束时间");
                    this.dtpStartTime.Focus();
                    return false;
                }
                string str5 = this.dtpStartDate.Value.ToString("yyyy-MM-dd") + "," + this.dtpStartTime.Value.ToString("HH:mm");
                string strB = this.dtpEndDate.Value.ToString("yyyy-MM-dd") + "," + this.dtpEndDate.Value.ToString("HH:mm");
                if (str5.CompareTo(strB) >= 0)
                {
                    MessageBox.Show("起始日期不能大于结束日期！");
                    return false;
                }
                ArrayList list2 = new ArrayList();
                string[] strArray2 = new string[] { str5, strB };
                list2.Add(strArray2);
                this.m_SimpleCmd.CmdParams = list2;
            }
            return true;
        }

        private void initForm()
        {
            if (base.OrderCode == CmdParam.OrderCode.设置计价器)
            {
                this.pnlSetMeter.Visible = true;
                this.pnlQueryMeter.Visible = false;
                this.cmbCarReport.addItems("不上传计价器数据", "00");
                this.cmbCarReport.addItems("空车上传", "01");
                this.cmbCarReport.addItems("重车上传", "10");
                this.cmbCarReport.addItems("空重车都上传", "11");
                this.cmbDataUpdown.addItems("不上传", "0");
                this.cmbDataUpdown.addItems("每笔交易结束上传", "1");
                this.cmbDataUpdown.addItems("定时", "2");
                this.cmbDataUpdown.addItems("定笔", "3");
                this.cmbDataUpdown_SelectedValueChanged(null, null);
            }
            else if (base.OrderCode == CmdParam.OrderCode.查询计价器)
            {
                this.pnlSetMeter.Visible = false;
                this.pnlQueryMeter.Visible = true;
            }
        }

 private void m2mMeter_Load(object sender, EventArgs e)
        {
            this.initForm();
        }
    }
}

