using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParamLibrary.Entity;
using ParamLibrary.CmdParamInfo;
using Remoting;
using ParamLibrary.Application;
using PublicClass;

namespace Client.JTB.MonitoringPlatform
{
    public partial class JTBPlatformPostResponse : FixedForm
    {
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        private CmdParam.OrderCode OrderCode;

        private Response reResult;

        private string _content = "";

        private string _discript = "";

        private string repid = "";

        private string repContent = "";

        private string repType = "";

        private string repObjectID = "";

        private string OBJECT_ID = "";

        private string strAsk = "";

        public JTBPlatformPostResponse(CmdParam.OrderCode OrderCode, string[] responseId)
        {
            this.InitializeComponent();
            this.Text = OrderCode.ToString();
            this.OrderCode = OrderCode;
            this.repid = responseId[0];
            this.repContent = ((int)responseId.Length >= 1 ? responseId[1] : "");
            this.repType = ((int)responseId.Length >= 3 ? responseId[2] : "1");
            this.repObjectID = ((int)responseId.Length >= 4 ? responseId[3] : "");
            string[] strArrays = this.repContent.Split(new char[] { ';' }, 2, StringSplitOptions.RemoveEmptyEntries);
            this.OBJECT_ID = strArrays[0];
            string[] strArrays2 = strArrays[1].Split(new string[] { ":=" }, 2, StringSplitOptions.RemoveEmptyEntries);
            this.strAsk = strArrays2[1].Split(new char[] { '|' }, 2, StringSplitOptions.RemoveEmptyEntries)[0];
            this.txtPostContent.Text = strArrays2[1];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.getParam())
            {
                return;
            }
            string str = (MainForm.myCarList.AllCar.Rows.Count > 0 ? MainForm.myCarList.AllCar.Rows[0]["SimNum"].ToString() : "");
            this.reResult = RemotingClient.Car_CommandParameterInsterToDB(CmdParam.ParamType.SimNum, str, "", this.m_SimpleCmd, this._content, this._discript);
            if (this.reResult.ResultCode == 0L)
            {
                base.Close();
                return;
            }
            MessageBox.Show(this.reResult.ErrorMsg);
        }

        private void JTBPlatformPostResponse_Load(object sender, EventArgs e)
        {
            if (this.OrderCode == CmdParam.OrderCode.下发平台间报文应答)
            {
                this.grpContent.Text = "内容";
                this.grpReponse.Visible = false;
                this.grpContent.Dock = DockStyle.Fill;
                this.btnOK.Visible = false;
                this.btnCancel.Text = "关闭";
            }
        }

        private bool getParam()
        {
            if (this.txtPostResponse.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入应答内容!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.m_SimpleCmd.OrderCode = this.OrderCode;
            this._content = Convert.ToString(int.Parse(this.repType), 16).PadLeft(2, '0');
            string str = this.convertStringToBase16String(this.repObjectID);
            str = str.PadRight(24, '0').Substring(0, 24);
            this._content = string.Concat(this._content, str);
            this._content = string.Concat(this._content, Convert.ToString(int.Parse(this.repid), 16).PadLeft(8, '0'));
            this._discript = this.txtPostResponse.Text.Trim();
            string[] string6 = new string[] { this.OBJECT_ID, ";手动查岗应答:=", this.strAsk, "|", Variable.sUserId, "|", this.txtPostResponse.Text.Trim() };
            string str1 = string.Concat(string6);
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(str1);
            string str2 = Convert.ToString((int)bytes.Length, 16);
            this._content = string.Concat(this._content, str2.PadLeft(8, '0'));
            this._content = string.Concat(this._content, this.convertStringToBase16String(str1));
            return true;
        }

        private string convertStringToBase16String(string responseId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(responseId);
            for (int i = 0; i < (int)bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString("X2"));
            }
            return stringBuilder.ToString();
        }
    }
}
