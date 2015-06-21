namespace Client
{
    using JTB;
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    partial class ImageList
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
            this.pbImage = new PictureBox();
            this.linkLblDownImg = new LinkLabel();
            this.pnlMedia = new Panel();
            this.btnSound = new Panel();
            this.btnVideo = new Panel();
            base.pnlLog.SuspendLayout();
            base.pnlSelect.SuspendLayout();
            base.pnlCarNum.SuspendLayout();
            base.pnlWorkType.SuspendLayout();
            base.pnlSendResult.SuspendLayout();
            base.pnlLogType.SuspendLayout();
            base.scData.Panel2.SuspendLayout();
            base.scData.SuspendLayout();
            base.pnlLogCnt.SuspendLayout();
            base.m_dtLogData.BeginInit();
            base.m_dvLogData.BeginInit();
            ((ISupportInitialize) this.pbImage).BeginInit();
            this.pnlMedia.SuspendLayout();
            base.SuspendLayout();
            base.pnlLog.Size = new Size(959, 198);
            base.pnlSelect.Size = new Size(959, 26);
            base.pnlSendResult.Visible = false;
            base.pnlTool.Size = new Size(167, 26);
            base.scData.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            base.scData.Panel2.Controls.Add(this.linkLblDownImg);
            base.scData.Panel2.Controls.Add(this.pbImage);
            base.scData.Panel2.Controls.Add(this.pnlMedia);
            base.scData.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            base.scData.Panel2Collapsed = false;
            base.scData.Size = new Size(959, 172);
            base.scData.SplitterDistance = 634;
            this.pbImage.BackgroundImageLayout = ImageLayout.Stretch;
            this.pbImage.Dock = DockStyle.Fill;
            this.pbImage.Location = new Point(0, 24);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new Size(321, 148);
            this.pbImage.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            this.linkLblDownImg.AutoSize = true;
            this.linkLblDownImg.Location = new Point(97, 78);
            this.linkLblDownImg.Name = "linkLblDownImg";
            this.linkLblDownImg.Size = new Size(53, 12);
            this.linkLblDownImg.TabIndex = 1;
            this.linkLblDownImg.TabStop = true;
            this.linkLblDownImg.Text = "下载图片";
            this.linkLblDownImg.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLblDownImg_LinkClicked);
            this.pnlMedia.Controls.Add(this.btnSound);
            this.pnlMedia.Controls.Add(this.btnVideo);
            this.pnlMedia.Dock = DockStyle.Top;
            this.pnlMedia.Location = new Point(0, 0);
            this.pnlMedia.Name = "pnlMedia";
            this.pnlMedia.Size = new Size(321, 24);
            this.pnlMedia.TabIndex = 2;
            this.pnlMedia.Visible = false;
            this.btnSound.BackgroundImage = Resources.Sound;
            this.btnSound.Cursor = Cursors.Hand;
            this.btnSound.Dock = DockStyle.Left;
            this.btnSound.Location = new Point(24, 0);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new Size(24, 24);
            this.btnSound.TabIndex = 1;
            this.btnSound.Visible = false;
            this.btnSound.Click += new EventHandler(this.btnSound_Click);
            this.btnVideo.BackgroundImage = Resources.Video;
            this.btnVideo.Cursor = Cursors.Hand;
            this.btnVideo.Dock = DockStyle.Left;
            this.btnVideo.Location = new Point(0, 0);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new Size(24, 24);
            this.btnVideo.TabIndex = 0;
            this.btnVideo.Visible = false;
            this.btnVideo.Click += new EventHandler(this.btnVideo_Click);
            base.Name = "ImageList";
            base.Size = new Size(959, 198);
            base.pnlLog.ResumeLayout(false);
            base.pnlSelect.ResumeLayout(false);
            base.pnlCarNum.ResumeLayout(false);
            base.pnlCarNum.PerformLayout();
            base.pnlWorkType.ResumeLayout(false);
            base.pnlWorkType.PerformLayout();
            base.pnlSendResult.ResumeLayout(false);
            base.pnlSendResult.PerformLayout();
            base.pnlLogType.ResumeLayout(false);
            base.pnlLogType.PerformLayout();
            base.scData.Panel2.ResumeLayout(false);
            base.scData.Panel2.PerformLayout();
            base.scData.ResumeLayout(false);
            base.pnlLogCnt.ResumeLayout(false);
            base.pnlLogCnt.PerformLayout();
            base.m_dtLogData.EndInit();
            base.m_dvLogData.EndInit();
            ((ISupportInitialize) this.pbImage).EndInit();
            this.pnlMedia.ResumeLayout(false);
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private BackgroundWorker _mediaDownLoadThread;
        private bool bIsCompleted;
        private Panel btnSound;
        private Panel btnVideo;
        private LinkLabel linkLblDownImg;
        private System.Windows.Forms.PictureBox pbImage;
        private Panel pnlMedia;
        private BackgroundWorker worker;
    }
}