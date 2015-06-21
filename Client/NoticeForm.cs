namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public partial class NoticeForm : FixedForm
    {
        public MainForm Opener;
        private const int SW_SHOWNOACTIVATE = 4;

        public NoticeForm()
        {
            this.m_sCarId = "";
            this.m_sCarPw = "";
            this.d_CurrentOpacity = 1.0;
            this.waitCount = 12000;
            this.marginRight = 1;
            this.endHeight = 200;
            this.moveHeight = 8;
            this.InitializeComponent();
            this.lblMsg.Text = "当前收到{0}条" + Variable.sNoticeLogText + "，\r\n点击查看详情。";
            this.Text = Variable.sNoticeLogText + "提示";
        }

        public NoticeForm(string sText)
        {
            this.m_sCarId = "";
            this.m_sCarPw = "";
            this.d_CurrentOpacity = 1.0;
            this.waitCount = 12000;
            this.marginRight = 1;
            this.endHeight = 200;
            this.moveHeight = 8;
            this.InitializeComponent();
            this.lblMsg.Text = "当前收到{0}条" + sText + "，\r\n点击查看详情。";
            this.Text = sText + "提示";
            this.IsNoticeEx = true;
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            MainForm.myLogForms.ParentForm.Activate();
            if (MainForm.myLogForms.ParentForm.WindowState == FormWindowState.Minimized)
            {
                MainForm.myLogForms.ParentForm.WindowState = FormWindowState.Maximized;
            }
            if (this.IsNoticeEx)
            {
                MainForm.myLogForms.setCurrentTabPageEx();
            }
            else
            {
                MainForm.myLogForms.setCurrentTabPage();
            }
            this.tMoveTimer.Enabled = false;
            base.Close();
        }

 private void moveDown()
        {
            if (!this.mouseEnter)
            {
                if (base.Location.Y <= (this.StartPoint.Y - 5))
                {
                    Point point = new Point {
                        X = base.Location.X,
                        Y = base.Location.Y + this.moveHeight
                    };
                    base.Location = point;
                    base.Height -= this.moveHeight;
                    this.State = FormMoveState.MoveDown;
                }
                else
                {
                    this.tMoveTimer.Enabled = false;
                    base.Close();
                }
            }
        }

        private void moveUp()
        {
            if ((base.Location.Y - 1) >= this.EndPoint.Y)
            {
                this.moveCount++;
                Point point = new Point {
                    X = base.Location.X,
                    Y = base.Location.Y - this.moveHeight
                };
                base.Location = point;
                this.State = FormMoveState.MoveUp;
            }
            else
            {
                this.NextState = FormMoveState.Waiting;
            }
        }

        private void moveWait()
        {
            if (this.waitedCount < this.waitCount)
            {
                this.waitedCount++;
                this.State = FormMoveState.Waiting;
            }
            else
            {
                this.NextState = FormMoveState.MoveDown;
            }
        }

        private void NoticeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tMoveTimer.Enabled = false;
            try
            {
                this.tMoveTimer = null;
                base.Dispose();
            }
            catch
            {
            }
        }

        private void NoticeForm_Load(object sender, EventArgs e)
        {
            base.Width = 260;
            this.endHeight = 200;
            Screen primaryScreen = Screen.PrimaryScreen;
            this.StartPoint = new Point();
            this.StartPoint.X = (primaryScreen.WorkingArea.Width - base.Width) - this.marginRight;
            this.StartPoint.Y = primaryScreen.WorkingArea.Height;
            this.EndPoint = new Point();
            this.EndPoint.X = this.StartPoint.X;
            this.EndPoint.Y = primaryScreen.WorkingArea.Height - 200;
            base.Location = this.StartPoint;
            this.tMoveTimer.Enabled = true;
            this.NextState = FormMoveState.MoveUp;
            ShowWindow(base.Handle, 4);
        }

        public void showInfo(string sNoticeCnt, string sReCnt)
        {
            string format = "当前收到{0}条" + Variable.sNoticeLogText + "，\r\n点击查看详情。";
            this.lblMsg.Text = string.Format(format, sReCnt);
        }

        public void showInfo(string sNoticeCnt, string sReCnt, string sText)
        {
            string format = "当前收到{0}条" + sText + "，\r\n点击查看详情。";
            this.lblMsg.Text = string.Format(format, sReCnt);
        }

        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hWnd, short cmdShow);
        private void tMoveTimer_Tick(object sender, EventArgs e)
        {
            switch (this.NextState)
            {
                case FormMoveState.MoveUp:
                    this.moveUp();
                    return;

                case FormMoveState.Waiting:
                    this.tMoveTimer.Enabled = false;
                    return;

                case FormMoveState.MoveDown:
                    this.tMoveTimer.Enabled = false;
                    return;
            }
        }

        public string CarId
        {
            get
            {
                return this.m_sCarId;
            }
        }

        public int Y
        {
            get
            {
                return this.EndPoint.Y;
            }
        }
    }
}

