namespace Client.JTB
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class JTBEventSet
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(JTBEventSet));
            this.grpWatchProperty = new GroupBox();
            this.dgvEventList = new DataGridViewEx();
            this.panel1 = new Panel();
            this.cmbSetType = new ComboBox();
            this.lblSetType = new Label();
            this.chkCheckAll = new CheckBox();
            this.选择 = new DataGridViewCheckBoxColumn();
            this.EditID = new DataGridViewTextBoxColumn();
            this.内容 = new DataGridViewTextBoxColumn();
            this.ID = new DataGridViewTextBoxColumn();
            this.isSet = new DataGridViewTextBoxColumn();
            this.Interval = new DataGridViewTextBoxColumn();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            ((ISupportInitialize) this.dgvEventList).BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.Size = new Size(485, 116);
            base.pnlBtn.Controls.Add(this.chkCheckAll);
            base.pnlBtn.Location = new System.Drawing.Point(5, 375);
            base.pnlBtn.Size = new Size(485, 28);
            base.pnlBtn.Controls.SetChildIndex(base.btnOK, 0);
            base.pnlBtn.Controls.SetChildIndex(base.btnCancel, 0);
            base.pnlBtn.Controls.SetChildIndex(this.chkCheckAll, 0);
            base.btnCancel.Location = new System.Drawing.Point(405, 3);
            base.btnOK.Location = new System.Drawing.Point(320, 3);
            this.grpWatchProperty.Controls.Add(this.dgvEventList);
            this.grpWatchProperty.Controls.Add(this.panel1);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(485, 254);
            this.grpWatchProperty.TabIndex = 13;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置电话号码";
            this.dgvEventList.AllowUserToAddRows = false;
            this.dgvEventList.AllowUserToResizeRows = false;
            this.dgvEventList.BackgroundColor = Color.White;
            this.dgvEventList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventList.Columns.AddRange(new DataGridViewColumn[] { this.选择, this.EditID, this.内容, this.ID, this.isSet, this.Interval });
            this.dgvEventList.Dock = DockStyle.Fill;
            this.dgvEventList.Location = new System.Drawing.Point(3, 47);
            this.dgvEventList.Name = "dgvEventList";
            this.dgvEventList.NotMultiSelectedColumnName = (List<string>) resources.GetObject("dgvEventList.NotMultiSelectedColumnName");
            this.dgvEventList.RowHeadersVisible = false;
            this.dgvEventList.RowTemplate.Height = 23;
            this.dgvEventList.Size = new Size(479, 204);
            this.dgvEventList.TabIndex = 0;
            this.dgvEventList.CellValueChanged += new DataGridViewCellEventHandler(this.dgvEventList_CellValueChanged);
            this.panel1.Controls.Add(this.cmbSetType);
            this.panel1.Controls.Add(this.lblSetType);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(479, 30);
            this.panel1.TabIndex = 19;
            this.cmbSetType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSetType.FormattingEnabled = true;
            this.cmbSetType.Location = new System.Drawing.Point(76, 5);
            this.cmbSetType.Name = "cmbSetType";
            this.cmbSetType.Size = new Size(153, 20);
            this.cmbSetType.TabIndex = 40;
            this.cmbSetType.SelectedIndexChanged += new EventHandler(this.cmbSetType_SelectedIndexChanged);
            this.lblSetType.AutoSize = true;
            this.lblSetType.Location = new System.Drawing.Point(5, 9);
            this.lblSetType.Name = "lblSetType";
            this.lblSetType.Size = new Size(65, 12);
            this.lblSetType.TabIndex = 39;
            this.lblSetType.Text = "设置类型：";
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(9, 6);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new Size(48, 16);
            this.chkCheckAll.TabIndex = 41;
            this.chkCheckAll.Tag = "9999";
            this.chkCheckAll.Text = "全选";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new EventHandler(this.chkCheckAll_CheckedChanged);
            this.选择.DataPropertyName = "Flag";
            this.选择.FalseValue = "False";
            this.选择.HeaderText = "选择";
            this.选择.Name = "选择";
            this.选择.TrueValue = "True";
            this.选择.Width = 50;
            this.EditID.DataPropertyName = "EditID";
            this.EditID.HeaderText = "ID";
            this.EditID.Name = "EditID";
            this.EditID.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.内容.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.内容.DataPropertyName = "MsgName";
            this.内容.HeaderText = "内容";
            this.内容.Name = "内容";
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "事件ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.isSet.DataPropertyName = "isSet";
            this.isSet.HeaderText = "isSet";
            this.isSet.Name = "isSet";
            this.isSet.ReadOnly = true;
            this.isSet.Visible = false;
            this.Interval.DataPropertyName = "Interval";
            this.Interval.HeaderText = "发送间隔(秒)";
            this.Interval.Name = "Interval";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(495, 408);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBEventSet";
            this.Text = "JTBEventSet";
            base.Load += new EventHandler(this.JTBEventSet_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            base.pnlBtn.PerformLayout();
            this.grpWatchProperty.ResumeLayout(false);
            ((ISupportInitialize) this.dgvEventList).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private CheckBox chkCheckAll;
        private ComboBox cmbSetType;
        private DataGridViewEx dgvEventList;
        private DataGridViewTextBoxColumn EditID;
        private GroupBox grpWatchProperty;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Interval;
        private DataGridViewTextBoxColumn isSet;
        private Label lblSetType;
        private int MsgType;
        private Panel panel1;
        private DataGridViewTextBoxColumn 内容;
        private DataGridViewCheckBoxColumn 选择;
    }
}