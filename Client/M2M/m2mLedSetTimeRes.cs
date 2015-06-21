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

    public partial class m2mLedSetTimeRes : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mLedSetTimeRes(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
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

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.LED开启或关闭)
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
                string str = this.rbtnStart.Checked ? "0" : "1";
                string[] strArray = new string[] { str, this.dtpStartDate.Value.ToString("yyyy-MM-dd") + "," + this.dtpStartTime.Value.ToString("HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd") + "," + this.dtpEndDate.Value.ToString("HH:mm:ss"), this.cmbLight.Text };
                list.Add(strArray);
            }
            this.m_SimpleCmd.CmdParams = list;
            return true;
        }

        private void initCmbLight()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.cmbLight.addItems(i, i);
            }
        }

        private void InitForm()
        {
            if (base.OrderCode == CmdParam.OrderCode.LED开启或关闭)
            {
                this.pnlLEDState.Visible = true;
                this.pnlTime.Visible = true;
                this.pnlLEDLight.Visible = true;
                this.initCmbLight();
            }
        }

 private void m2mLedSetTimeRes_Load(object sender, EventArgs e)
        {
            this.InitForm();
        }
    }
}

