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

    public partial class m2mGetPhoto : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mGetPhoto(CmdParam.OrderCode OrderCode)
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
            if (this.pnlDate.Visible)
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
            }
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.图像名称查询指令)
            {
                string[] strArray = new string[] { this.dtpStartDate.Value.ToString("yyyy-MM-dd") + "," + this.dtpEndDate.Value.ToString("yyyy-MM-dd") + "," + this.dtpStartTime.Value.ToString("HH:mm:ss") + "," + this.dtpEndTime.Value.ToString("HH:mm:ss") };
                list.Add(strArray);
                this.m_SimpleCmd.CmdParams = list;
            }
            else if (base.OrderCode == CmdParam.OrderCode.获取指定图片上传指令)
            {
                string[] strArray2 = new string[2];
                if (this.rbtnGetImg.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtPhotoName.Text.Trim()))
                    {
                        MessageBox.Show("请输入图片名称");
                        this.txtPhotoName.Focus();
                        return false;
                    }
                    strArray2[0] = "1";
                    strArray2[1] = this.txtPhotoName.Text.Trim();
                }
                else
                {
                    strArray2[0] = "0";
                    strArray2[1] = "";
                }
                list.Add(strArray2);
                this.m_SimpleCmd.CmdParams = list;
            }
            return true;
        }

 private void m2mGetPhoto_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
        }

        private void rbtnGetImg_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPhotoName.Enabled = this.rbtnGetImg.Checked;
        }

        private void setGroupVisible()
        {
            if (base.OrderCode == CmdParam.OrderCode.图像名称查询指令)
            {
                this.pnlDate.Visible = true;
                this.pnlImage.Visible = false;
            }
            else if (base.OrderCode == CmdParam.OrderCode.获取指定图片上传指令)
            {
                this.pnlDate.Visible = false;
                this.pnlImage.Visible = true;
            }
        }
    }
}

