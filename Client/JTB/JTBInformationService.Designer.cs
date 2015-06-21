namespace Client.JTB
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class JTBInformationService
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(JTBInformationService));
            this.grpWatchProperty = new GroupBox();
            this.lblContent = new Label();
            this.txtContent = new TextBox();
            this.cmbInformationType = new ComboBox();
            this.lblInformationType = new Label();
            this.dgvEventList = new DataGridViewEx();
            this.选择 = new DataGridViewCheckBoxColumn();
            this.事件内容 = new DataGridViewTextBoxColumn();
            this.事件ID = new DataGridViewTextBoxColumn();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            ((ISupportInitialize) this.dgvEventList).BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 285);
            this.grpWatchProperty.Controls.Add(this.lblContent);
            this.grpWatchProperty.Controls.Add(this.txtContent);
            this.grpWatchProperty.Controls.Add(this.cmbInformationType);
            this.grpWatchProperty.Controls.Add(this.lblInformationType);
            this.grpWatchProperty.Controls.Add(this.dgvEventList);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 164);
            this.grpWatchProperty.TabIndex = 14;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "参数设置";
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(50, 50);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new Size(65, 12);
            this.lblContent.TabIndex = 4;
            this.lblContent.Text = "信息内容：";
            this.txtContent.Location = new System.Drawing.Point(122, 47);
            this.txtContent.MaxLength = 175;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new Size(235, 111);
            this.txtContent.TabIndex = 3;
            this.cmbInformationType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbInformationType.FormattingEnabled = true;
            this.cmbInformationType.Location = new System.Drawing.Point(122, 21);
            this.cmbInformationType.Name = "cmbInformationType";
            this.cmbInformationType.Size = new Size(161, 20);
            this.cmbInformationType.TabIndex = 2;
            this.lblInformationType.AutoSize = true;
            this.lblInformationType.Location = new System.Drawing.Point(51, 24);
            this.lblInformationType.Name = "lblInformationType";
            this.lblInformationType.Size = new Size(65, 12);
            this.lblInformationType.TabIndex = 1;
            this.lblInformationType.Text = "信息类型：";
            this.dgvEventList.AllowUserToAddRows = false;
            this.dgvEventList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventList.Columns.AddRange(new DataGridViewColumn[] { this.选择, this.事件内容, this.事件ID });
            this.dgvEventList.Location = new System.Drawing.Point(467, 159);
            this.dgvEventList.Name = "dgvEventList";
            this.dgvEventList.NotMultiSelectedColumnName = (List<string>) resources.GetObject("dgvEventList.NotMultiSelectedColumnName");
            this.dgvEventList.RowHeadersVisible = false;
            this.dgvEventList.RowTemplate.Height = 23;
            this.dgvEventList.Size = new Size(10, 10);
            this.dgvEventList.TabIndex = 0;
            this.dgvEventList.Visible = false;
            this.选择.DataPropertyName = "Flag";
            this.选择.FalseValue = "False";
            this.选择.HeaderText = "选择";
            this.选择.Name = "选择";
            this.选择.TrueValue = "True";
            this.选择.Width = 50;
            this.事件内容.DataPropertyName = "MsgName";
            this.事件内容.HeaderText = "事件内容";
            this.事件内容.Name = "事件内容";
            this.事件内容.ReadOnly = true;
            this.事件内容.Width = 400;
            this.事件ID.DataPropertyName = "ID";
            this.事件ID.HeaderText = "事件ID";
            this.事件ID.Name = "事件ID";
            this.事件ID.ReadOnly = true;
            this.事件ID.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 318);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBInformationService";
            this.Text = "JTBInformationService";
            base.Load += new EventHandler(this.JTBInformationService_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            ((ISupportInitialize) this.dgvEventList).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComboBox cmbInformationType;
        private DataGridViewEx dgvEventList;
        private GroupBox grpWatchProperty;
        private Label lblContent;
        private Label lblInformationType;
        private TextBox txtContent;
        private DataGridViewTextBoxColumn 事件ID;
        private DataGridViewTextBoxColumn 事件内容;
        private DataGridViewCheckBoxColumn 选择;
    }
}