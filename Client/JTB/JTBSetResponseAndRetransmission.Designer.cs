namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBSetResponseAndRetransmission
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
            this.grpWatchProperty = new GroupBox();
            this.cmbChannelType = new ComboBox();
            this.lblChannelType = new Label();
            this.lblResponseTime = new Label();
            this.numResponseTime = new NumericUpDown();
            this.lblExplain1 = new Label();
            this.lblRetransmission = new Label();
            this.numRetransmission = new NumericUpDown();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numResponseTime.BeginInit();
            this.numRetransmission.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 215);
            this.grpWatchProperty.Controls.Add(this.cmbChannelType);
            this.grpWatchProperty.Controls.Add(this.lblChannelType);
            this.grpWatchProperty.Controls.Add(this.lblResponseTime);
            this.grpWatchProperty.Controls.Add(this.numResponseTime);
            this.grpWatchProperty.Controls.Add(this.lblExplain1);
            this.grpWatchProperty.Controls.Add(this.lblRetransmission);
            this.grpWatchProperty.Controls.Add(this.numRetransmission);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 94);
            this.grpWatchProperty.TabIndex = 9;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "参数设置";
            this.cmbChannelType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbChannelType.FormattingEnabled = true;
            this.cmbChannelType.Items.AddRange(new object[] { "TCP链路", "UDP链路", "短信链路" });
            this.cmbChannelType.Location = new System.Drawing.Point(121, 14);
            this.cmbChannelType.Name = "cmbChannelType";
            this.cmbChannelType.Size = new Size(162, 20);
            this.cmbChannelType.TabIndex = 38;
            this.lblChannelType.AutoSize = true;
            this.lblChannelType.Location = new System.Drawing.Point(50, 17);
            this.lblChannelType.Name = "lblChannelType";
            this.lblChannelType.Size = new Size(65, 12);
            this.lblChannelType.TabIndex = 37;
            this.lblChannelType.Text = "通道类型：";
            this.lblResponseTime.AutoSize = true;
            this.lblResponseTime.Location = new System.Drawing.Point(26, 42);
            this.lblResponseTime.Name = "lblResponseTime";
            this.lblResponseTime.Size = new Size(89, 12);
            this.lblResponseTime.TabIndex = 33;
            this.lblResponseTime.Text = "应答超时时间：";
            this.numResponseTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numResponseTime.Location = new System.Drawing.Point(121, 40);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numResponseTime.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 3;
            this.numResponseTime.Minimum = new decimal(numArray2);
            this.numResponseTime.Name = "numResponseTime";
            this.numResponseTime.Size = new Size(161, 21);
            this.numResponseTime.TabIndex = 31;
            int[] numArray3 = new int[4];
            numArray3[0] = 30;
            this.numResponseTime.Value = new decimal(numArray3);
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(288, 45);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(17, 12);
            this.lblExplain1.TabIndex = 36;
            this.lblExplain1.Tag = "；";
            this.lblExplain1.Text = "秒";
            this.lblRetransmission.AutoSize = true;
            this.lblRetransmission.Location = new System.Drawing.Point(50, 69);
            this.lblRetransmission.Name = "lblRetransmission";
            this.lblRetransmission.Size = new Size(65, 12);
            this.lblRetransmission.TabIndex = 34;
            this.lblRetransmission.Text = "重传次数：";
            this.numRetransmission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRetransmission.Location = new System.Drawing.Point(121, 67);
            int[] numArray4 = new int[4];
            numArray4[0] = 10;
            this.numRetransmission.Maximum = new decimal(numArray4);
            this.numRetransmission.Name = "numRetransmission";
            this.numRetransmission.Size = new Size(161, 21);
            this.numRetransmission.TabIndex = 32;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 248);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetResponseAndRetransmission";
            this.Text = "JTBSetResponseAndRetransmission";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numResponseTime.EndInit();
            this.numRetransmission.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private ComboBox cmbChannelType;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblChannelType;
        private Label lblExplain1;
        private Label lblResponseTime;
        private Label lblRetransmission;
        private NumericUpDown numResponseTime;
        private NumericUpDown numRetransmission;
    }
}