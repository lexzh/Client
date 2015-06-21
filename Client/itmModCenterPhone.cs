namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmModCenterPhone : CarForm
    {
        private SetPhone m_SetPhone = new SetPhone();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmModCenterPhone(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                if (base.OrderCode == CmdParam.OrderCode.回拔坐席电话指令)
                {
                    base.reResult = RemotingClient.DownData_SendRawPackage(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                }
                else
                {
                    base.reResult = RemotingClient.DownData_SetPhone(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SetPhone);
                }
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
            if (base.OrderCode == CmdParam.OrderCode.回拔坐席电话指令)
            {
                if (this.txtTel.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("电话号码不能为空！");
                    this.txtTel.Focus();
                    return false;
                }
                this.m_SimpleCmd.OrderCode = base.OrderCode;
                ArrayList list = new ArrayList();
                string[] strArray = new string[] { this.txtTel.Text.Trim() };
                list.Add(strArray);
                this.m_SimpleCmd.CmdParams = list;
            }
            else
            {
                if (this.txtTel.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("电话号码不能为空！");
                    this.txtTel.Focus();
                    return false;
                }
                this.m_SetPhone.OrderCode = base.OrderCode;
                this.m_SetPhone.strPhone = this.txtTel.Text.Trim();
            }
            return true;
        }

 private void itmModCenterPhone_Load(object sender, EventArgs e)
        {
            try
            {
                this.m_SetPhone.OrderCode = base.OrderCode;
                string[] strArray = base.sCarId.Split(new char[] { ',' });
                if (strArray.Length > 0)
                {
                    DataTable table = RemotingClient.Car_GetPhonesByType(this.m_SetPhone.PhoneType, strArray[0]);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        this.txtTel.Text = table.Rows[0][0].ToString().Trim();
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord(exception.ToString());
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

