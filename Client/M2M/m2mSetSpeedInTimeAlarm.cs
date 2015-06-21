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

    public partial class m2mSetSpeedInTimeAlarm : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mSetSpeedInTimeAlarm(CmdParam.OrderCode OrderCode)
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
            try
            {
                string str = this.cmbSetIndex.SelectedValue.ToString();
                string str2 = this.numSpeed.Value.ToString();
                string str3 = this.dtpStartTime.Value.ToString("HHmm");
                string strB = this.dtpEndTime.Value.ToString("HHmm");
                if (str3.CompareTo(strB) >= 0)
                {
                    MessageBox.Show("起始时间不能大于结束时间！");
                    return false;
                }
                string str5 = this.dtpStartTime.Value.ToString("HH:mm") + "," + this.dtpEndTime.Value.ToString("HH:mm");
                ArrayList list = new ArrayList();
                string[] strArray = new string[] { str, str2, str5 };
                list.Add(strArray);
                this.m_SimpleCmd.CmdParams = list;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

 private void m2mSetSpeedInTimeAlarm_Load(object sender, EventArgs e)
        {
            this.cmbSetIndex.addItems("设置一", "1");
            this.cmbSetIndex.addItems("设置二", "2");
        }
    }
}

