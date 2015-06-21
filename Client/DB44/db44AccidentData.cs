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
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class db44AccidentData : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public db44AccidentData(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(null, null);
                if ((!string.IsNullOrEmpty(base.sValue) && this.getParam()) && ((this.m_SimpleCmd.CmdParams != null) && (this.m_SimpleCmd.CmdParams.Count != 0)))
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
            catch (Exception exception)
            {
                Record.execFileRecord("移动实时监控", exception.Message);
            }
        }

        private void cmbViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setControlEnable();
        }

        private void db44RealTimeReport_Load(object sender, EventArgs e)
        {
            this.InitForm();
        }

 private bool getParam()
        {
            string[] strArray;
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.历史轨迹)
            {
                strArray = new string[] { this.dtpBeginDate.Value.ToString("yyyyMMdd") + this.dtpBeginTime.Value.ToString("HHmmss"), this.numDotCnt.Value.ToString() };
            }
            else
            {
                strArray = new string[] { "0", "", "" };
                if (this.cmbViewType.SelectedValue.Equals(0))
                {
                    strArray[0] = this.numStopIndex.Value.ToString();
                }
                else if (this.cmbViewType.SelectedValue.Equals(1))
                {
                    strArray[1] = this.dtpBeginDate.Value.ToString("yyyyMMdd") + this.dtpBeginTime.Value.ToString("HHmmss");
                    strArray[2] = this.dtpEndDate.Value.ToString("yyyyMMdd") + this.dtpEndTime.Value.ToString("HHmmss");
                    if ((this.dtpBeginDate.Value.Date > this.dtpEndDate.Value.Date) || ((this.dtpBeginDate.Value.Date == this.dtpEndDate.Value.Date) && (this.dtpBeginTime.Value.TimeOfDay > this.dtpEndTime.Value.TimeOfDay)))
                    {
                        MessageBox.Show("起始时间大于结束时间");
                        this.dtpBeginDate.Focus();
                        return false;
                    }
                }
            }
            list.Add(strArray);
            this.m_SimpleCmd.CmdParams = list;
            return true;
        }

        private void InitForm()
        {
            if (base.OrderCode == CmdParam.OrderCode.历史轨迹)
            {
                this.pnlHistory.Visible = true;
                this.pnlAccidentData.Visible = false;
                this.pnlEndTime.Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.事故疑点数据)
            {
                this.pnlAccidentData.Visible = true;
                this.pnlEndTime.Visible = true;
                this.pnlHistory.Visible = false;
                this.cmbViewType.addItems("按序号查询", 0);
                this.cmbViewType.addItems("按时间查询", 1);
                this.cmbViewType.addItems("查询最近停车记录", 2);
                this.setControlEnable();
            }
        }

 private void setControlEnable()
        {
            if (this.cmbViewType.SelectedValue.Equals(0))
            {
                this.numStopIndex.Enabled = true;
                this.pnlBeginTime.Enabled = false;
                this.pnlEndTime.Enabled = false;
            }
            else if (this.cmbViewType.SelectedValue.Equals(1))
            {
                this.numStopIndex.Enabled = false;
                this.pnlBeginTime.Enabled = true;
                this.pnlEndTime.Enabled = true;
            }
            else
            {
                this.numStopIndex.Enabled = false;
                this.pnlBeginTime.Enabled = false;
                this.pnlEndTime.Enabled = false;
            }
        }
    }
}

