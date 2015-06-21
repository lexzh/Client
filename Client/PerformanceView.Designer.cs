namespace Client
{
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class PerformanceView
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
            this.rtxtView = new RichTextBox();
            this.btnExit = new Button();
            this.btnServerBuffer = new Button();
            this.grpServer = new GroupBox();
            this.btnRefreshServer = new Button();
            this.rtxtServerBuffer = new RichTextBox();
            this.panel1 = new Panel();
            this.grpServer.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.rtxtView.BackColor = Color.White;
            this.rtxtView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtView.Location = new Point(3, 3);
            this.rtxtView.Name = "rtxtView";
            this.rtxtView.ReadOnly = true;
            this.rtxtView.Size = new Size(330, 201);
            this.rtxtView.TabIndex = 0;
            this.rtxtView.Text = "";
            this.btnExit.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new Point(257, 210);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnServerBuffer.Location = new Point(5, 210);
            this.btnServerBuffer.Name = "btnServerBuffer";
            this.btnServerBuffer.Size = new Size(75, 23);
            this.btnServerBuffer.TabIndex = 2;
            this.btnServerBuffer.Text = "服务端>>";
            this.btnServerBuffer.UseVisualStyleBackColor = true;
            this.btnServerBuffer.Click += new EventHandler(this.btnServerBuffer_Click);
            this.grpServer.AccessibleRole =  System.Windows.Forms.AccessibleRole.None;
            this.grpServer.Controls.Add(this.btnRefreshServer);
            this.grpServer.Controls.Add(this.rtxtServerBuffer);
            this.grpServer.Dock = DockStyle.Fill;
            this.grpServer.Location = new Point(0, 239);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new Size(336, 123);
            this.grpServer.TabIndex = 3;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "应用服务端缓存";
            this.grpServer.Visible = false;
            this.btnRefreshServer.Location = new Point(292, 21);
            this.btnRefreshServer.Name = "btnRefreshServer";
            this.btnRefreshServer.Size = new Size(38, 23);
            this.btnRefreshServer.TabIndex = 1;
            this.btnRefreshServer.Text = "刷新";
            this.btnRefreshServer.UseVisualStyleBackColor = true;
            this.btnRefreshServer.Click += new EventHandler(this.btnRefreshServer_Click);
            this.rtxtServerBuffer.BackColor = Color.White;
            this.rtxtServerBuffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtServerBuffer.Dock = DockStyle.Left;
            this.rtxtServerBuffer.Location = new Point(3, 17);
            this.rtxtServerBuffer.Name = "rtxtServerBuffer";
            this.rtxtServerBuffer.ReadOnly = true;
            this.rtxtServerBuffer.Size = new Size(284, 103);
            this.rtxtServerBuffer.TabIndex = 0;
            this.rtxtServerBuffer.Text = "";
            this.panel1.Controls.Add(this.rtxtView);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnServerBuffer);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(336, 239);
            this.panel1.TabIndex = 4;
            base.AcceptButton = this.btnExit;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(336, 362);
            base.Controls.Add(this.grpServer);
            base.Controls.Add(this.panel1);
            base.KeyPreview = true;
            base.Name = "PerformanceView";
            this.Text = "性能查看";
            base.KeyPress += new KeyPressEventHandler(this.PerformanceView_KeyPress);
            this.grpServer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private Button btnExit;
        private Button btnRefreshServer;
        private Button btnServerBuffer;
        private GroupBox grpServer;
        private Panel panel1;
        private RichTextBox rtxtServerBuffer;
        private System.Windows.Forms.RichTextBox rtxtView;
    }
}