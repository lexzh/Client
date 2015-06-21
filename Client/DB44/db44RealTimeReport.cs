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

    public partial class db44RealTimeReport : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public db44RealTimeReport(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
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

        private void db44RealTimeReport_Load(object sender, EventArgs e)
        {
            this.setControl();
        }

 private void getParam()
        {
            if ("定距监控".Equals(this.cmbWatchType.Text))
            {
                this.m_SimpleCmd.OrderCode = CmdParam.OrderCode.定距监控查看;
            }
            else
            {
                this.m_SimpleCmd.OrderCode = CmdParam.OrderCode.定时监控查看;
            }
            base.OrderCode = this.m_SimpleCmd.OrderCode;
            ArrayList list = new ArrayList();
            string[] strArray = new string[] { "0" };
            list.Add(strArray);
            this.m_SimpleCmd.CmdParams = list;
        }

 private void setControl()
        {
            this.cmbWatchType.addItems("定时监控", 1);
            this.cmbWatchType.addItems("定距监控", 2);
        }
    }
}

