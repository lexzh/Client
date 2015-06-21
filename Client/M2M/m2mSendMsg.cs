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

    public partial class m2mSendMsg : CarForm
    {

        public m2mSendMsg(CmdParam.OrderCode OrderCode)
        {
            this.m_SimpleCmd = new SimpleCmd();
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        public m2mSendMsg(CmdParam.OrderCode OrderCode, int iMsgType)
        {
            this.m_SimpleCmd = new SimpleCmd();
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.m_iMsgType = iMsgType;
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
            string str = this.txtMsg.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("请输入消息内容！");
                this.txtMsg.Focus();
                return false;
            }
            ArrayList list = new ArrayList();
            if ((base.OrderCode == CmdParam.OrderCode.设置一级短信) && (this.m_iMsgType == 1))
            {
                string[] strArray = new string[] { "0", this.numMsgIndex.Value.ToString(), str.Replace("，", ",").Trim().ToString() };
                list.Add(strArray);
                this.m_SimpleCmd.CmdParams = list;
            }
            else if ((base.OrderCode == CmdParam.OrderCode.设置一级短信) && (this.m_iMsgType == 2))
            {
                string[] strArray2 = new string[] { this.numMsgGroup.Value.ToString(), this.numMsgIndex.Value.ToString(), str.Replace("，", ",").Trim().ToString() };
                list.Add(strArray2);
                this.m_SimpleCmd.CmdParams = list;
            }
            else if (base.OrderCode == CmdParam.OrderCode.LED短信下发)
            {
                string[] strArray3 = new string[] { this.numLedMsgIndex.Value.ToString(), this.cmbMsgType.SelectedValue.ToString(), str.ToString() };
                list.Add(strArray3);
                this.m_SimpleCmd.CmdParams = list;
            }
            return true;
        }

        private void initForm()
        {
            if ((base.OrderCode == CmdParam.OrderCode.设置一级短信) && (this.m_iMsgType == 1))
            {
                this.pnlMsgType.Visible = false;
                this.pnlMsgGroup.Visible = false;
                this.pnlLedMsg.Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置一级短信)
            {
                this.pnlMsgType.Visible = false;
                this.pnlLedMsg.Visible = false;
            }
            if (base.OrderCode == CmdParam.OrderCode.LED短信下发)
            {
                this.initMsgType();
                this.pnlMsgGroup.Visible = false;
                this.pnlMsgIndex.Visible = false;
                this.pnlCompart.Visible = false;
            }
        }

 private void initMsgType()
        {
            this.cmbMsgType.addItems("菜单类信息", 0);
            this.cmbMsgType.addItems("是否类信息", 1);
            this.cmbMsgType.addItems("广告类信息", 2);
            this.cmbMsgType.addItems("调度类信息", 3);
            this.cmbMsgType.addItems("公司类信息", 4);
            this.cmbMsgType.addItems("公众类信息", 5);
            this.cmbMsgType.addItems("即时类信息", 6);
        }

        private void m2mSendMsg_Load(object sender, EventArgs e)
        {
            this.initForm();
        }
    }
}

