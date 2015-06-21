namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class JTBSoundRecordCommand : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBSoundRecordCommand(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.cmbRecordCmd.SelectedIndex = this.cmbSoundRatio.SelectedIndex = this.cmbStoreFlag.SelectedIndex = 0;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.icar_SetCommonCmdTraffic(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
            if ((this.numRecordTimeLong.Text.Trim().Length == 0) || this.numRecordTimeLong.Text.Trim().Equals("-"))
            {
                MessageBox.Show(this.lblRecordTimeLong.Text.Replace("：", "") + "输入格式有误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.numRecordTimeLong.Focus();
                return false;
            }
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.SoundRecordistType = this.cmbRecordCmd.SelectedIndex;
            this.m_SimpleCmd.SoundRecordistTime = (int) this.numRecordTimeLong.Value;
            this.m_SimpleCmd.IFSave = this.cmbStoreFlag.SelectedIndex;
            this.m_SimpleCmd.GFee = this.cmbSoundRatio.SelectedIndex;
            return true;
        }


    }
}