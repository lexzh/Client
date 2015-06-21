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

    public partial class getphoto : CarForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public getphoto(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        private void BlackBoxImage_Load(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(Variable.sGetPhotoMax);
                if (num >= this.numPictureCnt.Minimum)
                {
                    this.numPictureCnt.Maximum = num;
                }
            }
            catch
            {
            }
            this.setGroupVisible();
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
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

        private void chkDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDeleteAll.Checked)
            {
                this.dtpStartDate.Enabled = false;
                this.dtpStartTime.Enabled = false;
                this.dtpEndDate.Enabled = false;
                this.dtpEndTime.Enabled = false;
            }
            else
            {
                this.dtpStartDate.Enabled = true;
                this.dtpStartTime.Enabled = true;
                this.dtpEndDate.Enabled = true;
                this.dtpEndTime.Enabled = true;
            }
        }

 private bool getParam()
        {
            if (this.chkDeleteAll.Checked)
            {
                this.m_SimpleCmd.OrderCode = CmdParam.OrderCode.删除所有图片;
            }
            else
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
                this.m_SimpleCmd.BeginTime = this.dtpStartDate.Value.Date + this.dtpStartTime.Value.TimeOfDay;
                this.m_SimpleCmd.EndTime = this.dtpEndDate.Value.Date + this.dtpEndTime.Value.TimeOfDay;
                if (base.OrderCode == CmdParam.OrderCode.根据条件获得黑匣子图片)
                {
                    this.m_SimpleCmd.ImageCnt = Convert.ToInt32(this.numPictureCnt.Value);
                    this.m_SimpleCmd.PhotoState = this.getPhotoState();
                }
                this.m_SimpleCmd.OrderCode = base.OrderCode;
            }
            return true;
        }

        private int getPhotoState()
        {
            int num = 0;
            if (this.chkDoor.Checked)
            {
                num |= 131072;
            }
            if (this.chkState.Checked)
            {
                num |= 12;
            }
            if (this.chkExigence.Checked)
            {
                num |= 2;
            }
            if (this.chkAgainst.Checked)
            {
                num |= 32768;
            }
            if (this.chkAcc.Checked)
            {
                num |= 16384;
            }
            if (this.chkCustom1.Checked)
            {
                num |= 16777216;
            }
            if (this.chkCustom2.Checked)
            {
                num |= 33554432;
            }
            if (this.chkCustom3.Checked)
            {
                num |= 67108864;
            }
            if (this.chkCustom4.Checked)
            {
                num |= 134217728;
            }
            if (this.chkCustom5.Checked)
            {
                num |= 268435456;
            }
            if (this.chkCustom6.Checked)
            {
                num |= 536870912;
            }
            return num;
        }

 private void setGroupVisible()
        {
            if (base.OrderCode == CmdParam.OrderCode.根据条件获得黑匣子图片)
            {
                this.pnlDeleteAll.Visible = false;
            }
            if (base.OrderCode == CmdParam.OrderCode.根据条件删除图片)
            {
                this.pnlCondition.Visible = false;
                this.grpCondition.Text = "删除黑匣子数据条件";
            }
        }
    }
}

