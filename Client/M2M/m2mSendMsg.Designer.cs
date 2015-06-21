namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class m2mSendMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(m2mSendMsg));
            this.grpMsgType = new System.Windows.Forms.GroupBox();
            this.pnlLedMsg = new System.Windows.Forms.Panel();
            this.lblLedMsgIndex = new System.Windows.Forms.Label();
            this.numLedMsgIndex = new System.Windows.Forms.NumericUpDown();
            this.pnlMsgType = new System.Windows.Forms.Panel();
            this.lblMsgType = new System.Windows.Forms.Label();
            this.cmbMsgType = new WinFormsUI.Controls.ComBox();
            this.pnlMsgGroup = new System.Windows.Forms.Panel();
            this.lblMsgGroup = new System.Windows.Forms.Label();
            this.numMsgGroup = new System.Windows.Forms.NumericUpDown();
            this.pnlMsgIndex = new System.Windows.Forms.Panel();
            this.lblMsgIndex = new System.Windows.Forms.Label();
            this.numMsgIndex = new System.Windows.Forms.NumericUpDown();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.pnlCompart = new System.Windows.Forms.Panel();
            this.lblCompart = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpMsgType.SuspendLayout();
            this.pnlLedMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLedMsgIndex)).BeginInit();
            this.pnlMsgType.SuspendLayout();
            this.pnlMsgGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsgGroup)).BeginInit();
            this.pnlMsgIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsgIndex)).BeginInit();
            this.pnlMsg.SuspendLayout();
            this.pnlCompart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 365);
            this.pnlBtn.TabIndex = 2;
            // 
            // grpMsgType
            // 
            this.grpMsgType.AutoSize = true;
            this.grpMsgType.Controls.Add(this.pnlLedMsg);
            this.grpMsgType.Controls.Add(this.pnlMsgType);
            this.grpMsgType.Controls.Add(this.pnlMsgGroup);
            this.grpMsgType.Controls.Add(this.pnlMsgIndex);
            this.grpMsgType.Controls.Add(this.pnlMsg);
            this.grpMsgType.Controls.Add(this.pnlCompart);
            this.grpMsgType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMsgType.Location = new System.Drawing.Point(5, 121);
            this.grpMsgType.Name = "grpMsgType";
            this.grpMsgType.Size = new System.Drawing.Size(363, 244);
            this.grpMsgType.TabIndex = 1;
            this.grpMsgType.TabStop = false;
            // 
            // pnlLedMsg
            // 
            this.pnlLedMsg.Controls.Add(this.lblLedMsgIndex);
            this.pnlLedMsg.Controls.Add(this.numLedMsgIndex);
            this.pnlLedMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLedMsg.Location = new System.Drawing.Point(3, 17);
            this.pnlLedMsg.Name = "pnlLedMsg";
            this.pnlLedMsg.Size = new System.Drawing.Size(357, 30);
            this.pnlLedMsg.TabIndex = 0;
            // 
            // lblLedMsgIndex
            // 
            this.lblLedMsgIndex.AutoSize = true;
            this.lblLedMsgIndex.Location = new System.Drawing.Point(47, 6);
            this.lblLedMsgIndex.Name = "lblLedMsgIndex";
            this.lblLedMsgIndex.Size = new System.Drawing.Size(65, 12);
            this.lblLedMsgIndex.TabIndex = 2;
            this.lblLedMsgIndex.Text = "短信索引：";
            // 
            // numLedMsgIndex
            // 
            this.numLedMsgIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLedMsgIndex.Location = new System.Drawing.Point(119, 2);
            this.numLedMsgIndex.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numLedMsgIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLedMsgIndex.Name = "numLedMsgIndex";
            this.numLedMsgIndex.Size = new System.Drawing.Size(161, 21);
            this.numLedMsgIndex.TabIndex = 0;
            this.numLedMsgIndex.Tag = "；";
            this.numLedMsgIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlMsgType
            // 
            this.pnlMsgType.Controls.Add(this.lblMsgType);
            this.pnlMsgType.Controls.Add(this.cmbMsgType);
            this.pnlMsgType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMsgType.Location = new System.Drawing.Point(3, 47);
            this.pnlMsgType.Name = "pnlMsgType";
            this.pnlMsgType.Size = new System.Drawing.Size(357, 30);
            this.pnlMsgType.TabIndex = 1;
            // 
            // lblMsgType
            // 
            this.lblMsgType.AutoSize = true;
            this.lblMsgType.Location = new System.Drawing.Point(47, 6);
            this.lblMsgType.Name = "lblMsgType";
            this.lblMsgType.Size = new System.Drawing.Size(65, 12);
            this.lblMsgType.TabIndex = 2;
            this.lblMsgType.Text = "短信类型：";
            // 
            // cmbMsgType
            // 
            this.cmbMsgType.DisplayMember = "Display";
            this.cmbMsgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMsgType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMsgType.FormattingEnabled = true;
            this.cmbMsgType.Location = new System.Drawing.Point(119, 2);
            this.cmbMsgType.Name = "cmbMsgType";
            this.cmbMsgType.Size = new System.Drawing.Size(161, 20);
            this.cmbMsgType.TabIndex = 0;
            this.cmbMsgType.Tag = "；";
            this.cmbMsgType.ValueMember = "Value";
            // 
            // pnlMsgGroup
            // 
            this.pnlMsgGroup.Controls.Add(this.lblMsgGroup);
            this.pnlMsgGroup.Controls.Add(this.numMsgGroup);
            this.pnlMsgGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMsgGroup.Location = new System.Drawing.Point(3, 77);
            this.pnlMsgGroup.Name = "pnlMsgGroup";
            this.pnlMsgGroup.Size = new System.Drawing.Size(357, 30);
            this.pnlMsgGroup.TabIndex = 2;
            // 
            // lblMsgGroup
            // 
            this.lblMsgGroup.AutoSize = true;
            this.lblMsgGroup.Location = new System.Drawing.Point(47, 6);
            this.lblMsgGroup.Name = "lblMsgGroup";
            this.lblMsgGroup.Size = new System.Drawing.Size(65, 12);
            this.lblMsgGroup.TabIndex = 0;
            this.lblMsgGroup.Text = "短信组号：";
            // 
            // numMsgGroup
            // 
            this.numMsgGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMsgGroup.Location = new System.Drawing.Point(119, 2);
            this.numMsgGroup.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMsgGroup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMsgGroup.Name = "numMsgGroup";
            this.numMsgGroup.Size = new System.Drawing.Size(161, 21);
            this.numMsgGroup.TabIndex = 0;
            this.numMsgGroup.Tag = "；";
            this.numMsgGroup.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlMsgIndex
            // 
            this.pnlMsgIndex.Controls.Add(this.lblMsgIndex);
            this.pnlMsgIndex.Controls.Add(this.numMsgIndex);
            this.pnlMsgIndex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMsgIndex.Location = new System.Drawing.Point(3, 107);
            this.pnlMsgIndex.Name = "pnlMsgIndex";
            this.pnlMsgIndex.Size = new System.Drawing.Size(357, 30);
            this.pnlMsgIndex.TabIndex = 3;
            // 
            // lblMsgIndex
            // 
            this.lblMsgIndex.AutoSize = true;
            this.lblMsgIndex.Location = new System.Drawing.Point(47, 6);
            this.lblMsgIndex.Name = "lblMsgIndex";
            this.lblMsgIndex.Size = new System.Drawing.Size(65, 12);
            this.lblMsgIndex.TabIndex = 2;
            this.lblMsgIndex.Text = "起始编号：";
            // 
            // numMsgIndex
            // 
            this.numMsgIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMsgIndex.Location = new System.Drawing.Point(119, 2);
            this.numMsgIndex.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMsgIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMsgIndex.Name = "numMsgIndex";
            this.numMsgIndex.Size = new System.Drawing.Size(161, 21);
            this.numMsgIndex.TabIndex = 0;
            this.numMsgIndex.Tag = "；";
            this.numMsgIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlMsg
            // 
            this.pnlMsg.Controls.Add(this.lblMsg);
            this.pnlMsg.Controls.Add(this.txtMsg);
            this.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMsg.Location = new System.Drawing.Point(3, 137);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Size = new System.Drawing.Size(357, 76);
            this.pnlMsg.TabIndex = 4;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(47, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(65, 12);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "消息内容：";
            // 
            // txtMsg
            // 
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMsg.Location = new System.Drawing.Point(119, 2);
            this.txtMsg.MaxLength = 255;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(161, 67);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.Tag = "；";
            // 
            // pnlCompart
            // 
            this.pnlCompart.Controls.Add(this.lblCompart);
            this.pnlCompart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCompart.Location = new System.Drawing.Point(3, 213);
            this.pnlCompart.Name = "pnlCompart";
            this.pnlCompart.Size = new System.Drawing.Size(357, 28);
            this.pnlCompart.TabIndex = 5;
            // 
            // lblCompart
            // 
            this.lblCompart.AutoSize = true;
            this.lblCompart.Location = new System.Drawing.Point(117, 4);
            this.lblCompart.Name = "lblCompart";
            this.lblCompart.Size = new System.Drawing.Size(149, 12);
            this.lblCompart.TabIndex = 0;
            this.lblCompart.Tag = "9999";
            this.lblCompart.Text = "注：多条信息用“，”分隔";
            // 
            // m2mSendMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(373, 398);
            this.Controls.Add(this.grpMsgType);
            this.Name = "m2mSendMsg";
            this.Text = "位置查询";
            this.Load += new System.EventHandler(this.m2mSendMsg_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpMsgType, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpMsgType.ResumeLayout(false);
            this.pnlLedMsg.ResumeLayout(false);
            this.pnlLedMsg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLedMsgIndex)).EndInit();
            this.pnlMsgType.ResumeLayout(false);
            this.pnlMsgType.PerformLayout();
            this.pnlMsgGroup.ResumeLayout(false);
            this.pnlMsgGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsgGroup)).EndInit();
            this.pnlMsgIndex.ResumeLayout(false);
            this.pnlMsgIndex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsgIndex)).EndInit();
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.pnlCompart.ResumeLayout(false);
            this.pnlCompart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private ComBox cmbMsgType;
        private GroupBox grpMsgType;
        private Label lblCompart;
        private Label lblLedMsgIndex;
        private Label lblMsg;
        private Label lblMsgGroup;
        private Label lblMsgIndex;
        private Label lblMsgType;
        private int m_iMsgType;
        private SimpleCmd m_SimpleCmd;
        private NumericUpDown numLedMsgIndex;
        private NumericUpDown numMsgGroup;
        private NumericUpDown numMsgIndex;
        private Panel pnlCompart;
        private Panel pnlLedMsg;
        private Panel pnlMsg;
        private Panel pnlMsgGroup;
        private Panel pnlMsgIndex;
        private Panel pnlMsgType;
        private TextBox txtMsg;
    }
}