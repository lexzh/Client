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

    public partial class db44MileageCnt : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public db44MileageCnt(CmdParam.OrderCode OrderCode)
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

        private void db44MileageCnt_Load(object sender, EventArgs e)
        {
            this.setControl();
        }

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            string[] strArray = new string[1];
            if (base.OrderCode == CmdParam.OrderCode.查询累计里程)
            {
                strArray[0] = this.cmbViewType.SelectedValue.ToString();
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置特征系数)
            {
                strArray[0] = this.numParam.Value.ToString();
            }
            list.Add(strArray);
            this.m_SimpleCmd.CmdParams = list;
        }

 private void setControl()
        {
            if (base.OrderCode == CmdParam.OrderCode.查询累计里程)
            {
                this.grpParam.Visible = false;
                this.cmbViewType.addItems("两个日历天的累计里程", 0);
                this.cmbViewType.addItems("360小时的累计里程", 1);
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置特征系数)
            {
                this.grpViewType.Visible = false;
            }
        }
    }
}

