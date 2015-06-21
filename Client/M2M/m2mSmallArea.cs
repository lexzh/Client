namespace Client.M2M
{
    using Client;
    using Properties;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class m2mSmallArea : FixedForm
    {
        private ArrayList arrCarLst = new ArrayList();
        private bool bSmallRes = true;
        private int iSmallTime = 60;
        private string m_OderId = "";
        private SimpleCmd m_SimpleCmd = new SimpleCmd();
        private string m_sPoints = "";
        private string sCurrentStatus = "";
        private string sParam = "";
        private BackgroundWorker worder = new BackgroundWorker();

        public m2mSmallArea(string sPoints)
        {
            this.InitializeComponent();
            this.m_sPoints = sPoints;
        }

        public void AddCarList(string iOrderId, string sCarNum, string sCarId, string sOrderResult, string sOrderName, string sOrderType)
        {
            if ((this.arrCarLst != null) && (this.arrCarLst.Count != 0))
            {
                if (!"成功".Equals(sOrderResult) && this.arrCarLst.Contains(iOrderId))
                {
                    this.arrCarLst.Remove(iOrderId);
                }
                if ((!string.IsNullOrEmpty(sOrderName) && (sOrderName.IndexOf("电召") >= 0)) && (sOrderName.IndexOf("应答") >= 0))
                {
                    if (this.arrCarLst.Count == 0)
                    {
                        this.lblSending.Text = string.Format("无车辆抢答！", new object[0]);
                        this.lblSending.ForeColor = Color.Red;
                        this.lvCar.Items.Clear();
                        this.sCurrentStatus = "确定抢答";
                        this.i = 20;
                    }
                    else if (this.arrCarLst.Contains(iOrderId) && "接收".Equals(sOrderType))
                    {
                        this.btnOk.Enabled = true;
                        this.btnSendOrder.Enabled = false;
                        this.txtPhone.Enabled = true;
                        if ((this.lvCar.Items.Count > 0) && (this.lvCar.Items[0].Text == "等待车辆抢答..."))
                        {
                            this.lvCar.Items.Clear();
                            this.lblTelNumber.Text = "乘客电话：";
                            this.lblContent.Text = "乘客信息：";
                            this.txtContent.Text = "请在此输入乘客内容";
                            this.cmbResWay.Enabled = false;
                        }
                        ListViewItem item = new ListViewItem {
                            Name = sCarId,
                            Text = sCarNum
                        };
                        this.lvCar.Items.Add(item);
                        this.gbCar.Text = "抢答车辆信息(" + this.lvCar.Items.Count.ToString() + ")";
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((this.lvCar.SelectedItems.Count == 0) || (this.lvCar.Items[0].Text == "等待车辆抢答..."))
            {
                MessageBox.Show("未选中车辆信息！");
            }
            else if (string.IsNullOrEmpty(this.txtPhone.Text))
            {
                MessageBox.Show("请输入乘客电话！");
            }
            else if (string.IsNullOrEmpty(this.txtContent.Text.Trim()) || this.txtContent.Text.Equals("请在此输入乘客内容"))
            {
                MessageBox.Show("请输入乘客信息！");
            }
            else
            {
                this.sCurrentStatus = "确定抢答";
                if (MessageBox.Show(string.Format("乘客信息确认\r\n  乘客电话：{0}\r\n  乘客信息：{1}", this.txtPhone.Text, this.txtContent.Text), "乘客信息确认", MessageBoxButtons.OKCancel, MessageBoxIcon.None) == DialogResult.OK)
                {
                    try
                    {
                        string text = this.lvCar.SelectedItems[0].Text;
                        this.getParams();
                        Response response = RemotingClient.DownData_SetCommonCmd_FJYD(CmdParam.ParamType.CarNum, text, "", CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                        if (response.ResultCode != 0L)
                        {
                            MessageBox.Show(response.ErrorMsg);
                        }
                        else
                        {
                            base.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception exception)
                    {
                        Record.execFileRecord("电召->确定抢答", exception.Message);
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPhone.Text))
            {
                MessageBox.Show("请输入抢答电话！");
            }
            else if (string.IsNullOrEmpty(this.txtContent.Text.Trim()) || this.txtContent.Text.Equals("请在此输入电召内容"))
            {
                MessageBox.Show("请输入电召内容！");
            }
            else
            {
                this.sCurrentStatus = "发送抢答";
                this.pnlSending.Visible = true;
                this.pbPicWait.Visible = true;
                this.bSmallRes = false;
                this.i = 0;
                try
                {
                    this.worder = new BackgroundWorker();
                    this.worder.WorkerReportsProgress = true;
                    this.worder.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worder_RunWorkerCompleted);
                    this.worder.ProgressChanged += new ProgressChangedEventHandler(this.worder_ProgressChanged);
                    this.worder.DoWork += new DoWorkEventHandler(this.worder_DoWork);
                    this.worder.RunWorkerAsync(this.cmbResWay.SelectedValue.ToString());
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("电召->异步处理发送抢答", exception.Message);
                }
            }
        }

 private void getParams()
        {
            this.m_SimpleCmd.OrderCode = CmdParam.OrderCode.抢答确认指令;
            string text = this.txtOrderId.Text;
            string str2 = this.txtPhone.Text;
            string name = this.lvCar.SelectedItems[0].Name;
            string str4 = this.lvCar.SelectedItems[0].Text;
            string str5 = this.txtContent.Text.Trim();
            ArrayList list = new ArrayList();
            string[] strArray = new string[] { name, str2, str5, text, str4 };
            list.Add(strArray);
            this.m_SimpleCmd.CmdParams = list;
        }

 private void itmSmallArea_Load(object sender, EventArgs e)
        {
            this.btnOk.Enabled = false;
            this.btnSendOrder.Enabled = true;
            this.pbPicWait.Visible = false;
            try
            {
                string[] strArray = this.m_sPoints.Replace(";", ",").Split(new char[] { ',' });
                this.txtLeftLon.Text = strArray[0].Substring(0, strArray[0].IndexOf('.') + 7);
                this.txtLeftLat.Text = strArray[1].Substring(0, strArray[1].IndexOf('.') + 7);
                this.txtRightLon.Text = strArray[2].Substring(0, strArray[2].IndexOf('.') + 7);
                this.txtRightLat.Text = strArray[3].Substring(0, strArray[3].IndexOf('.') + 7);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("电召指令->设置经纬度", exception.ToString());
            }
            this.cmbResWay.addItems("电话抢答", "1");
            this.cmbResWay.addItems("无线抢答", "2");
            this.pnlSending.Visible = false;
        }

        private void m2mSmallArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ("发送抢答".Equals(this.sCurrentStatus) && (MessageBox.Show("正得等待抢答，确定要退出吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK))
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    this.worder = null;
                    this.arrCarLst.Clear();
                    this.arrCarLst = null;
                    this.m_SimpleCmd = null;
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("电召->关闭窗体", exception.Message);
                }
            }
        }

        private void txtContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.txtContent.Text.Equals("请在此输入电召内容") || this.txtContent.Text.Equals("请在此输入乘客内容"))
            {
                this.txtContent.Text = "";
            }
        }

        private void worder_DoWork(object sender, DoWorkEventArgs e)
        {
            string str = this.txtContent.Text.Trim();
            string text = this.txtLeftLon.Text;
            string sLeftLat = this.txtLeftLat.Text;
            string sRightLon = this.txtRightLon.Text;
            string sRightLat = this.txtRightLat.Text;
            string sResWay = e.Argument.ToString();
            string text1 = this.txtOrderId.Text;
            string sResPhone = this.txtPhone.Text.Trim();
            TxtMsg msgContext = new TxtMsg {
                OrderCode = CmdParam.OrderCode.点对点电召,
                MsgType = CmdParam.MsgType.电召信息,
                strMsg = str
            };
            try
            {
                this.worder.ReportProgress(10, "正在发送抢答，请稍候……");
                Response response = RemotingClient.Car_SmallArea_FJYD(text, sLeftLat, sRightLon, sRightLat, sResWay, sResPhone, msgContext, CmdParam.CommMode.未知方式);
                if (response.ResultCode != 0L)
                {
                    this.worder.ReportProgress(100, "发送抢答失败！");
                    this.sParam = "";
                    this.m_OderId = "";
                    MessageBox.Show(response.ErrorMsg);
                }
                else
                {
                    this.worder.ReportProgress(100, "发送抢答成功！");
                    this.sParam = response.OrderIDParam;
                    this.m_OderId = response.SvcContext;
                }
                Record.execFileRecord("电召指令", sResWay + "," + sResPhone + "," + msgContext.strMsg);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("电召->异步发送抢答", exception.Message);
            }
        }

        private void worder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                this.lblSending.Text = e.UserState.ToString();
                if (e.UserState.ToString().Contains("失败"))
                {
                    this.sCurrentStatus = "抢答失败";
                    this.lblSending.ForeColor = Color.Red;
                }
                else
                {
                    this.lblSending.ForeColor = SystemColors.Desktop;
                }
            }
        }

        private void worder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnSendOrder.Enabled = true;
            this.pbPicWait.Visible = false;
            try
            {
                this.txtOrderId.Text = this.m_OderId;
                this.lvCar.Enabled = true;
                this.lvCar.Items.Clear();
                this.arrCarLst.Clear();
                if (!string.IsNullOrEmpty(this.sParam))
                {
                    this.lvCar.Items.Add("等待车辆抢答...");
                    this.gbCar.Text = "抢答车辆信息(0)";
                    foreach (string str in this.sParam.Trim(new char[] { ';' }).Split(new char[] { ';' }))
                    {
                        string item = str.Split(new char[] { '|' })[0];
                        if (!this.arrCarLst.Contains(item))
                        {
                            this.arrCarLst.Add(item);
                        }
                    }
                    this.btnSendOrder.Enabled = false;
                    while (this.i < 10)
                    {
                        Application.DoEvents();
                        if (this.i > 10)
                        {
                            break;
                        }
                        this.btnSendOrder.Text = "发送抢答(" + ((9 - this.i)).ToString() + ")";
                        this.i++;
                        Thread.Sleep(1000);
                    }
                    this.btnSendOrder.Text = "发送抢答";
                    this.btnSendOrder.Enabled = true;
                }
            }
            catch
            {
            }
        }
    }
}

