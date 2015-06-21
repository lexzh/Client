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

    public partial class m2mModCenterPhone : CarForm
    {
        private int m_iPhoneMaxCnt = 32;
        private SimpleCmd m_SimpleCmd = new SimpleCmd();
        private string m_sTtile = "";

        public m2mModCenterPhone(CmdParam.OrderCode OrderCode, string sTitle)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this.m_sTtile = sTitle;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue))
            {
                try
                {
                    if (this.getParam())
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
                catch
                {
                }
            }
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            string str = "";
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.设置限拨的电话号码)
            {
                if (string.IsNullOrEmpty(this.txtLimitTelLst.Text.Trim()))
                {
                    string[] strArray = new string[] { "", "" };
                    list.Add(strArray);
                }
                else
                {
                    if (this.txtLimitTelLst.Lines.Length > this.m_iPhoneMaxCnt)
                    {
                        MessageBox.Show(string.Format("限拨电话号码列表的个数大于{0}个", this.m_iPhoneMaxCnt.ToString()));
                        return false;
                    }
                    string str2 = "";
                    foreach (string str3 in this.txtLimitTelLst.Lines)
                    {
                        if ((str3.Length <= 0) || (str3.Length > 15))
                        {
                            MessageBox.Show("限拨列表中，电话号码的长度大于15，或者等于0");
                            this.txtLimitTelLst.Focus();
                            return false;
                        }
                        str2 = str2 + str3 + ",";
                    }
                    if (!string.IsNullOrEmpty(str2))
                    {
                        str2 = str2.Substring(0, str2.Length - 1);
                    }
                    string[] strArray2 = new string[] { this.numStartPosition.Value.ToString(), str2.Trim(new char[] { ',' }).ToString() };
                    list.Add(strArray2);
                }
                this.m_SimpleCmd.CmdParams = list;
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置取消限拨的电话号)
            {
                if (this.txtPosition.Text.Contains("0"))
                {
                    string[] strArray3 = new string[] { "0" };
                    list.Add(strArray3);
                }
                else
                {
                    str = this.txtPosition.Text.Replace("，", ",").Trim();
                    if (string.IsNullOrEmpty(str))
                    {
                        MessageBox.Show("起始位置不能为空！");
                        return false;
                    }
                    string[] strArray4 = new string[] { str.Trim(new char[] { ',' }) };
                    list.Add(strArray4);
                }
                this.m_SimpleCmd.CmdParams = list;
            }
            else if (base.OrderCode == CmdParam.OrderCode.控制车机通话权限)
            {
                string[] strArray5 = new string[] { this.cmbPhoneStatus.SelectedValue.ToString() };
                list.Add(strArray5);
                this.m_SimpleCmd.CmdParams = list;
            }
            return true;
        }

        private void initForm()
        {
            if (base.OrderCode == CmdParam.OrderCode.设置限拨的电话号码)
            {
                this.grpLimitTel.Visible = true;
                this.grpCancelTel.Visible = false;
                this.grpPhoneStatus.Visible = false;
                base.Top = ((base.Top + base.Height) - 279) / 2;
            }
            else if (base.OrderCode == CmdParam.OrderCode.设置取消限拨的电话号)
            {
                this.grpLimitTel.Visible = false;
                this.grpCancelTel.Visible = true;
                this.grpPhoneStatus.Visible = false;
                base.Top = ((base.Top + base.Height) - 170) / 2;
            }
            else if (base.OrderCode == CmdParam.OrderCode.控制车机通话权限)
            {
                this.grpLimitTel.Visible = false;
                this.grpCancelTel.Visible = false;
                this.grpPhoneStatus.Visible = true;
                this.cmbPhoneStatus.addItems("禁止呼入呼出", "0");
                this.cmbPhoneStatus.addItems("限制通话", "1");
                this.cmbPhoneStatus.addItems("取消所有限制", "2");
                this.cmbPhoneStatus.addItems("取消呼入限制", "3");
                this.cmbPhoneStatus.addItems("取消呼出限制", "4");
                base.Top = ((base.Top + base.Height) - 150) / 2;
            }
        }

 private void itmModCenterPhone_Load(object sender, EventArgs e)
        {
            this.Text = this.m_sTtile;
            this.initForm();
        }

        private void txtLimitTelLst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b')) && (e.KeyChar != '\r'))
            {
                e.Handled = true;
            }
        }

        private void txtPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

