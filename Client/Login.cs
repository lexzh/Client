using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;
using PublicClass;
using ParamLibrary.Entity;
using Remoting;
using System.Threading;
//using GlsService;
using System.IO;

namespace Client
{
    public partial class Login : Client.FixedForm
    {
        private DateTime dtCreateValidateCode = DateTime.Now;
        public const int HTCAPTION = 2;
        private int iCountDown = 30;
        private int iCurrentCountDown;
        private int m_iLoginCnt;
        private dCountDown myCountDown;
        public MainForm myMainForm;
        public const int SC_MOVE = 61456;
        private string sValidateCode = "";
        private System.Timers.Timer tCountDown;
        public const int WM_SYSCOMMAND = 274;
        private BackgroundWorker workerLoadData;
        private BackgroundWorker workerSendMsg;

        public Login()
        {
            InitializeComponent();
            lblLoginVersion.Text = "V" + Application.ProductVersion;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            base.Close();
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            Variable.sUserId = this.txtUser.Text;
            new itmSetPass { IsLoginForm = true }.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.chkUserEmpty())
            {
                if ("1".Equals(Variable.sCheckAdc) && this.txtValidateCode.Visible)
                {
                    if (string.IsNullOrEmpty(this.txtValidateCode.Text))
                    {
                        MessageBox.Show(string.Format("验证码不能为空！", new object[0]));
                        this.txtValidateCode.Focus();
                        return;
                    }
                    if ((!Variable.sAdcNo.Equals(this.txtAdc.Text) || !Variable.sUserId.Equals(this.txtUser.Text)) || !this.sValidateCode.Equals(this.txtValidateCode.Text))
                    {
                        MessageBox.Show(string.Format("验证码校验失败！", new object[0]));
                        this.txtValidateCode.Focus();
                        return;
                    }
                }
                else
                {
                    Variable.sPhone = this.txtUser.Text;
                }
                this.pbPicWait.Visible = true;
                this.lblWaitText.Visible = true;
                this.btnOK.Enabled = false;
                this.btnSetParam.Enabled = false;
                this.btnChangePwd.Enabled = false;
                this.txtPassword.Enabled = false;
                this.txtUser.Enabled = false;
                this.txtAdc.Enabled = false;
                this.txtValidateCode.Enabled = false;
                this.btnSendValidateCode.Enabled = false;
                Variable.sUserId = this.txtUser.Text;
                Variable.sAdcNo = this.txtAdc.Text;
                Variable.sPassword = this.txtPassword.Text;
                WaitForm.ShowImageForm("正在加载画面，请稍候...");
                if (this.workerLoadData == null)
                {
                    this.workerLoadData = new BackgroundWorker();
                    this.workerLoadData.DoWork += new DoWorkEventHandler(this.execDataLoading);
                    this.workerLoadData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.exedDataLoaded);
                    this.workerLoadData.ProgressChanged += new ProgressChangedEventHandler(this.setText);
                    this.workerLoadData.WorkerReportsProgress = true;
                    this.workerLoadData.WorkerSupportsCancellation = true;
                    this.workerLoadData.RunWorkerAsync();
                }
            }
        }

        private void btnSendValidateCode_Click(object sender, EventArgs e)
        {
            if (this.chkUserEmpty())
            {
                Variable.sUserId = this.txtUser.Text;
                Variable.sAdcNo = this.txtAdc.Text;
                Variable.sPassword = this.txtPassword.Text;
                this.pbPicWait.Visible = true;
                this.lblWaitText.Visible = true;
                this.lblWaitText.Text = "正在发送验证码，请稍候...";
                this.btnSendValidateCode.Enabled = false;
                this.execCreateValidateCode();
                if (this.workerLoadData == null)
                {
                    this.workerSendMsg = new BackgroundWorker();
                    this.workerSendMsg.DoWork += new DoWorkEventHandler(this.execSendMsg);
                    this.workerSendMsg.ProgressChanged += new ProgressChangedEventHandler(this.execProgressChanged);
                    this.workerSendMsg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.exedSendMsged);
                    this.workerSendMsg.WorkerReportsProgress = true;
                    this.workerSendMsg.WorkerSupportsCancellation = true;
                    this.workerSendMsg.RunWorkerAsync();
                }
            }
        }

        private void btnSetParam_Click(object sender, EventArgs e)
        {
            if (execSetParam())
            {
                this.txtCenter.Text = Variable.sServerIp;
            }
        }

        private bool chkUserEmpty()
        {
            if (this.txtAdc.Visible && string.IsNullOrEmpty(this.txtAdc.Text))
            {
                MessageBox.Show(string.Format("集团编号不能为空！", new object[0]));
                this.txtAdc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtUser.Text))
            {
                MessageBox.Show(string.Format("用户名不能为空！", new object[0]));
                this.txtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show(string.Format("用户密码不能为空！", new object[0]));
                this.txtPassword.Focus();
                return false;
            }
            return true;
        }

        public static bool execConnectionServer()
        {
            Response response = RemotingClient.LoginSys_Login(false, true);
            if (response.ResultCode == 0L)
            {
                if (!string.IsNullOrEmpty(response.ErrorMsg))
                {
                    MessageBox.Show(response.ErrorMsg);
                }
                Variable.bLogin = true;
                Record.execFileRecord(Variable.sUserId, "登陆成功");
                return true;
            }
            Thread.Sleep(100);
            MessageBox.Show(response.ErrorMsg);
            Record.execFileRecord("用户登录", string.Format("{0}登录失败：{1}", Variable.sUserId, response.ErrorMsg));
            Variable.bLogin = false;
            return false;
        }

        private void execCountDown()
        {
            this.btnSendValidateCode.Text = this.iCurrentCountDown.ToString();
            if (this.iCurrentCountDown <= 0)
            {
                this.btnSendValidateCode.Text = "重新发送";
                this.btnSendValidateCode.Enabled = this.btnOK.Enabled;
            }
        }

        private void execCreateValidateCode()
        {
            Random random = new Random();
            this.sValidateCode = random.Next(100, 999999).ToString().PadLeft(6, '0');
            this.dtCreateValidateCode = DateTime.Now;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void execDataLoading(object sender, DoWorkEventArgs e)
        {
            DataTable table;
            try
            {
                this.workerLoadData.ReportProgress(0, "0");
                if (!execConnectionServer())
                {
                    this.workerLoadData.ReportProgress(0, "-1");
                    e.Cancel = true;
                    return;
                }
                try
                {
                    this.workerLoadData.ReportProgress(0, "1");
                    //PasConnectManager.CheckStart();
                }
                catch (Exception exception)
                {
                    Record.execFileRecord("登录验证", exception.Message);
                    MessageBox.Show(exception.Message);
                    return;
                }
                //if (!PasConnectManager.IsPass)
                //{
                //    if (!string.IsNullOrEmpty(PasConnectManager.ResultMsg))
                //    {
                //        MessageBox.Show(PasConnectManager.ResultMsg);
                //    }
                //    if (PasConnectManager.iGlsResult != 1)
                //    {
                //        Variable.bLogin = false;
                //        this.m_iLoginCnt = 3;
                //        this.workerLoadData.ReportProgress(0, "-100");
                //        e.Cancel = true;
                //        return;
                //    }
                //}
                this.myMainForm.FirstLoadWebSystem(this);
                RemotingClient.GetCorpName();
                RemotingClient.GetTitleName();
                //RemotingClient.GetMapAddr();
                this.workerLoadData.ReportProgress(10, "2");
                MainForm.myCarList.getAlermList();
                this.workerLoadData.ReportProgress(20, "3");
                table = MainForm.myCarList.getAreaList();
                this.workerLoadData.ReportProgress(50, "4");
                table = MainForm.myCarList.getCarList(table);
                if (Variable.sShippingEnable.Equals("1"))
                {
                    this.workerLoadData.ReportProgress(70, "6");
                    MainForm.myCarList.GetShippingList();
                }
                this.workerLoadData.ReportProgress(90, "5");
                MainForm.myCarList.CreateCarList(table);
                string format = " select PassWord from gpsUser where userid = '{0}' ";
                DataTable table2 = RemotingClient.ExecSql(string.Format(format, Variable.sUserId));
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    Variable.sDBPwd = table2.Rows[0][0].ToString();
                }
                else
                {
                    Variable.sDBPwd = Variable.sPassword;
                }
            }
            catch (Exception exception2)
            {
                Record.execFileRecord("加载数据操作", exception2.ToString());
            }
            table = null;
        }

        private void execProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (e.UserState != null)
                {
                    MessageBox.Show(this, e.UserState.ToString());
                }
                if (this.workerLoadData == null)
                {
                    this.pbPicWait.Visible = false;
                    this.lblWaitText.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void execSendMsg(object sender, DoWorkEventArgs e)
        {
            try
            {
                Response response = RemotingClient.LoginSys_LoginSendMsg(this.sValidateCode);
                if (response.ResultCode != 0L)
                {
                    e.Cancel = true;
                }
                this.workerSendMsg.ReportProgress(0, response.ErrorMsg);
            }
            catch (Exception exception)
            {
                Record.execFileRecord("加载数据操作", exception.Message);
                e.Result = exception.Message;
                e.Cancel = true;
            }
        }

        public static bool execSetParam()
        {
            SetParam param = new SetParam();
            return (param.ShowDialog() == DialogResult.OK);
        }

        private void exedDataLoaded(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.workerLoadData.DoWork -= new DoWorkEventHandler(this.execDataLoading);
                this.workerLoadData.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.exedDataLoaded);
                this.workerLoadData.ProgressChanged -= new ProgressChangedEventHandler(this.setText);
                this.workerLoadData = null;
            }
            else
            {
                base.Close();
            }
        }

        private void exedSendMsged(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    this.workerSendMsg.DoWork -= new DoWorkEventHandler(this.execSendMsg);
                    this.workerSendMsg.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.exedSendMsged);
                    this.workerSendMsg.ProgressChanged -= new ProgressChangedEventHandler(this.execProgressChanged);
                    this.workerSendMsg = null;
                    this.btnSendValidateCode.Enabled = true;
                }
                else if (this.workerLoadData == null)
                {
                    this.iCurrentCountDown = this.iCountDown;
                    this.tCountDown.Enabled = true;
                }
            }
            catch
            {
            }
        }

        private void iniNoAdcForm()
        {
            this.lblAdc.Visible = false;
            this.txtAdc.Visible = false;
            this.btnSendValidateCode.Visible = false;
            this.lblValidateCode.Visible = false;
            this.txtValidateCode.Visible = false;
            this.lblValidateCodeRemark.Visible = false;
            int num = (this.btnCancel.Location.X + this.btnCancel.Width) - this.txtCenter.Location.X;
            this.txtCenter.Width = num;
            this.txtUser.Width = num;
            this.txtPassword.Width = num;
            this.lblCenter.Location = this.lblAdc.Location;
            this.txtCenter.Location = this.txtAdc.Location;
            this.lblUser.Location = new Point(this.lblUser.Location.X, this.lblUser.Location.Y + 10);
            this.txtUser.Location = new Point(this.txtUser.Location.X, this.txtUser.Location.Y + 10);
            this.lblPassword.Location = new Point(this.lblPassword.Location.X, this.lblPassword.Location.Y + 20);
            this.txtPassword.Location = new Point(this.txtPassword.Location.X, this.txtPassword.Location.Y + 20);
            this.btnSetParam.Location = new Point(this.btnSetParam.Location.X, this.btnCancel.Location.Y - 15);
            this.btnOK.Location = new Point(this.btnOK.Location.X, this.btnCancel.Location.Y - 15);
            this.btnCancel.Location = new Point(this.btnCancel.Location.X, this.btnCancel.Location.Y - 15);
            this.btnChangePwd.Location = new Point(this.btnChangePwd.Location.X, this.btnChangePwd.Location.Y - 15);
        }

        private void isAdcForm()
        {
            this.lblCenter.Location = new Point(377, 132);
            this.txtCenter.Location = new Point(453, 130);
            this.lblAdc.Location = new Point(377, 165);
            this.txtAdc.Location = new Point(453, 163);
            this.lblUser.Location = new Point(377, 198);
            this.txtUser.Location = new Point(453, 196);
            this.lblPassword.Location = new Point(377, 231);
            this.txtPassword.Location = new Point(453, 229);
            this.txtCenter.Size = this.txtAdc.Size = this.txtUser.Size = this.txtPassword.Size = new Size(194, 21);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.iCurrentCountDown = 0;
            this.tCountDown.Enabled = false;
            this.tCountDown.Stop();
            if (this.workerSendMsg != null)
            {
                this.workerSendMsg.DoWork -= new DoWorkEventHandler(this.execSendMsg);
                this.workerSendMsg.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.exedSendMsged);
                this.workerSendMsg.ProgressChanged -= new ProgressChangedEventHandler(this.execProgressChanged);
                this.workerSendMsg.Dispose();
                this.workerSendMsg = null;
                this.btnSendValidateCode.Enabled = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            RemotingClient.iniResult();
            Record.execDeleteRecord();
            Record.execDeletePic();
            this.Text = Variable.sLoginTitle + "V" + Variable.sVersion;
            this.lblLoginTitle.Text = Variable.sLoginTitle;
            //this.lblLoginVersion.Text = Variable.sVersion;
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Icon\login.jpg")))
            {
                this.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Icon\login.jpg"));
            }
            this.txtCenter.Text = Variable.sServerIp;
            this.txtUser.Text = Variable.sUserId;
            if ("1".Equals(Variable.sCheckAdc))
            {
                this.txtAdc.Text = Variable.sAdcNo;
                this.isAdcForm();
            }
            else
            {
                this.iniNoAdcForm();
            }
            base.MouseDown += new MouseEventHandler(this.Login_MouseDown);
            this.lblLoginTitle.MouseDown += new MouseEventHandler(this.Login_MouseDown);
            this.lblLoginVersion.MouseDown += new MouseEventHandler(this.Login_MouseDown);
            this.myCountDown = new dCountDown(this.execCountDown);
            this.tCountDown = new System.Timers.Timer(1000.0);
            this.tCountDown.Elapsed += new ElapsedEventHandler(this.tCountDown_Elapsed);
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.Y < 30))
            {
                ReleaseCapture();
                SendMessage(base.Handle, 274, 61458, 0);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void setText(object sender, ProgressChangedEventArgs e)
        {
            string str = e.UserState.ToString();
            string str2 = "6";
            if (Variable.sShippingEnable.Equals("1"))
            {
                str2 = "7";
            }
            switch (str)
            {
                case "-100":
                    WaitForm.Hide();
                    base.Close();
                    return;

                case "-1":
                    this.m_iLoginCnt++;
                    if (this.m_iLoginCnt >= 3)
                    {
                        MessageBox.Show("超过最大登录次数，系统退出！");
                        Record.execFileRecord("用户登录", "超过最大登录次数，系统退出！");
                        base.Close();
                    }
                    this.pbPicWait.Visible = false;
                    this.lblWaitText.Visible = false;
                    WaitForm.Hide();
                    this.btnOK.Enabled = true;
                    this.btnSetParam.Enabled = true;
                    this.btnChangePwd.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.txtPassword.Enabled = true;
                    this.txtUser.Enabled = true;
                    this.txtAdc.Enabled = true;
                    this.txtValidateCode.Enabled = true;
                    this.btnSendValidateCode.Enabled = this.iCurrentCountDown <= 0;
                    return;

                case "0":
                    this.lblWaitText.Text = string.Format("1/{0} 正在验证用户信息，请稍候...", str2);
                    return;

                case "1":
                    this.lblWaitText.Text = string.Format("2/{0} 正在进行授权验证，请稍候...", str2);
                    return;

                case "2":
                    this.lblWaitText.Text = string.Format("3/{0} 正在下载报警列表，请稍候...", str2);
                    return;

                case "3":
                    this.lblWaitText.Text = string.Format("4/{0} 正在下载区域列表，请稍候...", str2);
                    return;

                case "4":
                    this.lblWaitText.Text = string.Format("5/{0} 正在下载车辆列表，请稍候...", str2);
                    return;

                case "5":
                    this.lblWaitText.Text = string.Format("{0}/{0} 正在创建车辆列表，请稍候...", str2);
                    return;

                case "6":
                    this.lblWaitText.Text = string.Format("6/{0} 正在下载运单列表，请稍候...", str2);
                    return;
            }
        }

        private void tCountDown_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.iCurrentCountDown > 0)
            {
                this.iCurrentCountDown--;
            }
            if (this.iCurrentCountDown <= 0)
            {
                this.tCountDown.Enabled = false;
            }
            this.btnSendValidateCode.Invoke(this.myCountDown);
        }

        private delegate void dCountDown();
    }
}
