namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmCarReset : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmCarReset(CmdParam.OrderCode OrderCode)
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
                    base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            if (base.OrderCode == CmdParam.OrderCode.设置车台复位)
            {
                this.m_SimpleCmd.ResetParam = this.cmbSetType.SelectedValue.ToString();
            }
            else if (base.OrderCode == CmdParam.OrderCode.自检)
            {
                this.m_SimpleCmd.SeftParam = this.cmbSetType.SelectedValue.ToString();
            }
            else if (base.OrderCode == CmdParam.OrderCode.终端电话接听策略)
            {
                this.m_SimpleCmd.ListenModeStrategy = this.cmbSetType.SelectedIndex;
            }
        }

 private void itmCarReset_Load(object sender, EventArgs e)
        {
            this.setControl();
        }

        private void setControl()
        {
            if (base.OrderCode == CmdParam.OrderCode.设置车台复位)
            {
                this.cmbSetType.addItems("整机复位", 0);
                this.cmbSetType.addItems("恢复出厂设置", 2);
                this.lblSetType.Text = "复位参数";
            }
            else if (base.OrderCode == CmdParam.OrderCode.自检)
            {
                this.cmbSetType.addItems("上报启动信息", 0);
                this.cmbSetType.addItems("定位上报启动信息", 1);
                this.cmbSetType.addItems("不上报启动信息", 2);
                this.lblSetType.Text = "自检指令";
            }
            else if (base.OrderCode == CmdParam.OrderCode.终端电话接听策略)
            {
                this.cmbSetType.addItems("自动接听", 0);
                this.cmbSetType.addItems("ACC ON时自动接听,OFF时手动接听", 1);
                this.lblSetType.Text = "接听方式";
            }
        }
    }
}

