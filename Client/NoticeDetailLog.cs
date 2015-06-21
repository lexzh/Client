namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class NoticeDetailLog : FixedForm
    {
        public bool bSendSuccess;
        public Button btnDown;
        public Button btnUp;
        public static NoticeLog myNoticeLog;

        public NoticeDetailLog()
        {
            this.m_sCarId = "";
            this.m_sCarPw = "";
            this.InitializeComponent();
            this.lblOrderNameValue.Text = Variable.sNoticeLogText;
            this.Text = Variable.sNoticeLogText;
        }

        public NoticeDetailLog(string sText)
        {
            this.m_sCarId = "";
            this.m_sCarPw = "";
            this.InitializeComponent();
            this.lblOrderNameValue.Text = sText;
            this.Text = sText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            myNoticeLog.execMoveSelected(1);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string str = this.txtReNotice.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("调度信息不能为空！");
            }
            else
            {
                TxtMsg txtMsg = new TxtMsg {
                    OrderCode = CmdParam.OrderCode.调度,
                    MsgType = CmdParam.MsgType.详细调度信息,
                    strMsg = str
                };
                Response response = RemotingClient.DownData_SendTxtMsg(CmdParam.ParamType.CarId, this.m_sCarId, this.m_sCarPw, CmdParam.CommMode.未知方式, txtMsg);
                if (response.ResultCode != 0L)
                {
                    MessageBox.Show(response.ErrorMsg);
                }
                else
                {
                    this.bSendSuccess = true;
                    response = null;
                    base.Close();
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            myNoticeLog.execMoveSelected(-1);
        }

        private void cboxCloseOwner_CheckedChanged(object sender, EventArgs e)
        {
            ThreeStateTreeNode node = MainForm.myCarList.tvList.getNodeById(this.m_sCarId);
            if (node != null)
            {
                node.bShowNoticeForm = !this.cboxCloseOwner.Checked;
            }
        }

 public void setShowInfo(DataGridViewRow drNotice)
        {
            this.lblGpsTimeValue.Text = drNotice.Cells["ReceTime"].Value.ToString();
            this.lblCarNumValue.Text = drNotice.Cells["CarNum"].Value.ToString();
            this.txtDescribe.Text = drNotice.Cells["Describe"].Value.ToString();
            this.m_sCarId = drNotice.Cells["CarId"].Value.ToString();
            ThreeStateTreeNode node = MainForm.myCarList.tvList.getNodeById(this.m_sCarId);
            if (node != null)
            {
                this.cboxCloseOwner.Checked = !node.bShowNoticeForm;
            }
            this.gbRepeat.Enabled = this.btnSend.Enabled = drNotice.Cells["ReceTime"].Value.ToString().Equals("43521", StringComparison.OrdinalIgnoreCase);
        }

        public void setShowInfo(string sCarMsg, string sCarId, string sCarPw, string sCarNum, string sGpsTime)
        {
            this.m_sCarId = sCarId;
            this.m_sCarPw = sCarPw;
            this.lblGpsTimeValue.Text = sGpsTime;
            this.lblCarNumValue.Text = sCarNum;
            this.txtDescribe.Text = sCarMsg;
        }
    }
}

