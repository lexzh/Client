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

    public partial class m2mSetAlarmParam : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mSetAlarmParam(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
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
        }

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            if (base.OrderCode == CmdParam.OrderCode.报警参数设置)
            {
                string str = this.cmbAlarmType.SelectedValue.ToString();
                string str2 = this.numDuration.Value.ToString();
                string str3 = this.numInterval.Value.ToString();
                string str4 = this.numAlarmTime.Value.ToString();
                ArrayList list = new ArrayList();
                string[] strArray = new string[] { str, str2, str3, str4 };
                list.Add(strArray);
                this.m_SimpleCmd.CmdParams = list;
            }
        }

 private void itmSetAlarmParam_Load(object sender, EventArgs e)
        {
            this.setInitAlarmType();
        }

        private void setInitAlarmType()
        {
            this.cmbAlarmType.addItems("所有报警", 0);
            this.cmbAlarmType.addItems("区域报警", 512);
            this.cmbAlarmType.addItems("超速报警", 514);
            this.cmbAlarmType.addItems("带时间段的超速报警", 515);
            this.cmbAlarmType.addItems("扩展区域报警", 516);
            this.cmbAlarmType.addItems("偏航报警", 518);
            this.cmbAlarmType.addItems("三维区域报警", 520);
            this.cmbAlarmType.addItems("三维偏航报警", 528);
            this.cmbAlarmType.addItems("疲劳驾驶报警", 530);
            this.cmbAlarmType.addItems("胎压报警", 531);
            this.cmbAlarmType.addItems("区域内超速报警", 532);
            this.cmbAlarmType.addItems("超时停车报警", 533);
            this.cmbAlarmType.addItems("区域超时停车报警", 535);
            this.cmbAlarmType.addItems("区域外罐车反转报警", 536);
        }
    }
}

