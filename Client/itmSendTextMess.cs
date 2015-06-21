using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParamLibrary.Application;
using System.IO;
using System.Diagnostics;
using ParamLibrary.CmdParamInfo;
using Remoting;

namespace Client
{
    public partial class itmSendTextMess : CarForm
    {
        private TxtMsg m_TxtMsg = new TxtMsg();
        private string sMsgFile = (Application.StartupPath + @"\msgfile.txt");

        public itmSendTextMess(CmdParam.OrderCode OrderCode)
        {
            InitializeComponent();
            base.OrderCode = OrderCode;
        }

        private bool getParam()
        {
            if (this.txtMsgValue.Text.Trim().Length <= 0)
            {
                MessageBox.Show("发送内容不能为空！");
                this.txtMsgValue.Focus();
                return false;
            }
            this.m_TxtMsg.OrderCode = base.OrderCode;
            this.m_TxtMsg.MsgType = (CmdParam.MsgType)int.Parse(this.cmbMsgType.SelectedValue.ToString());
            this.m_TxtMsg.strMsg = this.txtMsgValue.Text.Trim();
            return true;
        }

        private void initMsgType()
        {
            this.cmbMsgType.addItems("详细调度信息", 3);
            //this.cmbMsgType.addItems("电召信息", 2);
            //this.cmbMsgType.addItems("自定义超速报警", 6);
            //this.cmbMsgType.addItems("菜单类信息", 13);
            //this.cmbMsgType.addItems("是否类信息", 15);
            this.cmbMsgType.addItems("广告类信息", 16);
            //this.cmbMsgType.addItems("调度类信息", 3);
            // this.cmbMsgType.addItems("公司类信息", 17);
            //this.cmbMsgType.addItems("公众类信息", 18);
            this.cmbMsgType.addItems("固定信息点播", 1538);
            this.cmbMsgType.addItems("紧急消息", 641);
        }

        private void saveMsgtolocal()
        {
            FileStream stream = new FileInfo(this.sMsgFile).Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            string s = DateTime.Now.ToString() + " " + base.txtCarNo.Text.Trim() + " : " + this.txtMsgValue.Text.Trim() + "\r\n";
            byte[] bytes = Encoding.Default.GetBytes(s);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Close();
        }

        private void btnHistorySearch_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.sMsgFile))
            {
                try
                {
                    Process.Start(this.sMsgFile);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("打开文件错误：{0}", exception.Message));
                }
            }
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.DownData_SendTxtMsg(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_TxtMsg);
                if (base.reResult.ResultCode != 0L)
                {
                    MessageBox.Show(base.reResult.ErrorMsg);
                }
                else
                {
                    this.saveMsgtolocal();
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

        private void itmSendTextMess1_Load(object sender, EventArgs e)
        {
            initMsgType();
        }


    }
}
