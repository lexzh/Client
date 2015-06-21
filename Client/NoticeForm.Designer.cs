namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    partial class NoticeForm
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

       
 private void InitializeComponent()
        {
            this.components = new Container();
            this.tMoveTimer = new Timer(this.components);
            this.btnLook = new Button();
            this.lblMsg = new Label();
            base.SuspendLayout();
            this.tMoveTimer.Interval = 15;
            this.tMoveTimer.Tick += new EventHandler(this.tMoveTimer_Tick);
            this.btnLook.Location = new Point(160, 113);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new Size(75, 23);
            this.btnLook.TabIndex = 0;
            this.btnLook.Text = "查看";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new EventHandler(this.btnLook_Click);
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134, true);
            this.lblMsg.Location = new Point(32, 30);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new Size(192, 32);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "当前收到{0}条掉线通知，\r\n点击查看详情。";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(259, 143);
            base.Controls.Add(this.lblMsg);
            base.Controls.Add(this.btnLook);
            base.FormBorderStyle =  System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.Name = "NoticeForm";
            this.Text = "掉线通知提示";
            base.TopMost = true;
            base.Load += new EventHandler(this.NoticeForm_Load);
            base.FormClosing += new FormClosingEventHandler(this.NoticeForm_FormClosing);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private System.ComponentModel.IContainer components;
        private Button btnLook;
        private double d_CurrentOpacity;
        private int endHeight;
        private Point EndPoint;
        private bool IsNoticeEx;
        private Label lblMsg;
        private string m_sCarId;
        private string m_sCarPw;
        private int marginRight;
        private bool mouseEnter;
        private int moveCount;
        private int moveHeight;
        private FormMoveState NextState;
        private Point StartPoint;
        private FormMoveState State;
        private Timer tMoveTimer;
        private int waitCount;
        private int waitedCount;
    }
}