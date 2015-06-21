namespace Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class SetPathSegment
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SetPathSegment));
            this.panel1 = new Panel();
            this.btnClose = new Button();
            this.lblExplain = new Label();
            this.btnClear = new Button();
            this.btnOK = new Button();
            this.grpSegmentPara = new GroupBox();
            this.dgvPathSegment = new DataGridViewEx();
            this.PathID = new DataGridViewTextBoxColumn();
            this.PathSegmentID = new DataGridViewTextBoxColumn();
            this.PathSegmentName = new DataGridViewTextBoxColumn();
            this.DriEnough = new DataGridViewTextBoxColumn();
            this.DriNoEnough = new DataGridViewTextBoxColumn();
            this.TopSpeed = new DataGridViewTextBoxColumn();
            this.HoldTime = new DataGridViewTextBoxColumn();
            this.路宽 = new DataGridViewTextBoxColumn();
            this.路段属性 = new DataGridViewTextBoxColumn();
            this.AlarmSegmentDot = new DataGridViewTextBoxColumn();
            this.SegmentFlagValue = new DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.grpSegmentPara.SuspendLayout();
            ((ISupportInitialize) this.dgvPathSegment).BeginInit();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblExplain);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(3, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(420, 34);
            this.panel1.TabIndex = 1;
            this.btnClose.Location = new Point(320, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.lblExplain.AutoSize = true;
            this.lblExplain.ForeColor = Color.Red;
            this.lblExplain.Location = new Point(3, 11);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new Size(137, 12);
            this.lblExplain.TabIndex = 2;
            this.lblExplain.Tag = "9999";
            this.lblExplain.Text = "备注：点击\"设置\"后生效";
            this.btnClear.Location = new Point(239, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.btnOK.Location = new Point(158, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "设置";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.grpSegmentPara.Controls.Add(this.dgvPathSegment);
            this.grpSegmentPara.Controls.Add(this.panel1);
            this.grpSegmentPara.Dock = DockStyle.Fill;
            this.grpSegmentPara.Location = new Point(0, 0);
            this.grpSegmentPara.Name = "grpSegmentPara";
            this.grpSegmentPara.Size = new Size(426, 247);
            this.grpSegmentPara.TabIndex = 2;
            this.grpSegmentPara.TabStop = false;
            this.grpSegmentPara.Text = "路段参数设置";
            this.dgvPathSegment.AllowUserToAddRows = false;
            this.dgvPathSegment.AllowUserToDeleteRows = false;
            this.dgvPathSegment.AllowUserToResizeRows = false;
            this.dgvPathSegment.BackgroundColor = Color.White;
            this.dgvPathSegment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPathSegment.Columns.AddRange(new DataGridViewColumn[] { this.PathID, this.PathSegmentID, this.PathSegmentName, this.DriEnough, this.DriNoEnough, this.TopSpeed, this.HoldTime, this.路宽, this.路段属性, this.AlarmSegmentDot, this.SegmentFlagValue });
            this.dgvPathSegment.Dock = DockStyle.Fill;
            this.dgvPathSegment.Location = new Point(3, 17);
            this.dgvPathSegment.Name = "dgvPathSegment";
            this.dgvPathSegment.NotMultiSelectedColumnName = (List<string>) resources.GetObject("dgvPathSegment.NotMultiSelectedColumnName");
            this.dgvPathSegment.RowHeadersVisible = false;
            this.dgvPathSegment.RowTemplate.Height = 23;
            this.dgvPathSegment.Size = new Size(420, 193);
            this.dgvPathSegment.TabIndex = 0;
            this.dgvPathSegment.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvPathSegment_CellDoubleClick);
            this.dgvPathSegment.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvSubSpeedParam_EditingControlShowing);
            this.dgvPathSegment.DataError += new DataGridViewDataErrorEventHandler(this.dgvPathSegment_DataError);
            this.PathID.DataPropertyName = "PathID";
            this.PathID.HeaderText = "PathID";
            this.PathID.Name = "PathID";
            this.PathID.Visible = false;
            this.PathSegmentID.DataPropertyName = "PathSegmentID";
            this.PathSegmentID.HeaderText = "PathSegmentID";
            this.PathSegmentID.Name = "PathSegmentID";
            this.PathSegmentID.Visible = false;
            this.PathSegmentName.DataPropertyName = "PathSegmentName";
            this.PathSegmentName.HeaderText = "路段名称";
            this.PathSegmentName.Name = "PathSegmentName";
            this.DriEnough.DataPropertyName = "DriEnough";
            this.DriEnough.HeaderText = "行驶最长时间";
            this.DriEnough.MaxInputLength = 4;
            this.DriEnough.Name = "DriEnough";
            this.DriEnough.ReadOnly = true;
            this.DriEnough.Width = 70;
            this.DriNoEnough.DataPropertyName = "DriNoEnough";
            this.DriNoEnough.HeaderText = "行驶最短时间";
            this.DriNoEnough.MaxInputLength = 4;
            this.DriNoEnough.Name = "DriNoEnough";
            this.DriNoEnough.ReadOnly = true;
            this.DriNoEnough.Width = 70;
            this.TopSpeed.DataPropertyName = "TopSpeed";
            this.TopSpeed.HeaderText = "最高时速(km/h)";
            this.TopSpeed.MaxInputLength = 3;
            this.TopSpeed.Name = "TopSpeed";
            this.TopSpeed.ReadOnly = true;
            this.TopSpeed.Width = 80;
            this.HoldTime.DataPropertyName = "HoldTime";
            this.HoldTime.HeaderText = "持续时长(秒)";
            this.HoldTime.MaxInputLength = 3;
            this.HoldTime.Name = "HoldTime";
            this.HoldTime.ReadOnly = true;
            this.HoldTime.Width = 70;
            this.路宽.DataPropertyName = "PathWidth";
            this.路宽.HeaderText = "路宽";
            this.路宽.Name = "路宽";
            this.路宽.Width = 80;
            this.路段属性.DataPropertyName = "Flag";
            this.路段属性.HeaderText = "路段属性";
            this.路段属性.Name = "路段属性";
            this.路段属性.ReadOnly = true;
            this.AlarmSegmentDot.DataPropertyName = "AlarmSegmentDot";
            this.AlarmSegmentDot.HeaderText = "AlarmSegmentDot";
            this.AlarmSegmentDot.Name = "AlarmSegmentDot";
            this.AlarmSegmentDot.Visible = false;
            this.SegmentFlagValue.DataPropertyName = "SegmentFlagValue";
            this.SegmentFlagValue.HeaderText = "SegmentFlagValue";
            this.SegmentFlagValue.Name = "SegmentFlagValue";
            this.SegmentFlagValue.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.grpSegmentPara);
            base.Name = "SetPathSegment";
            base.Size = new Size(426, 247);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpSegmentPara.ResumeLayout(false);
            ((ISupportInitialize) this.dgvPathSegment).EndInit();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private DataTable _data;
        private AutoDropDown _路线属性;
        private DataGridViewTextBoxColumn AlarmSegmentDot;
        private Button btnClear;
        private Button btnClose;
        private Button btnOK;
        private DataGridViewEx dgvPathSegment;
        private DataGridViewTextBoxColumn DriEnough;
        private DataGridViewTextBoxColumn DriNoEnough;
        private DataGridViewTextBoxEditingControl EditingControl;
        private GroupBox grpSegmentPara;
        private DataGridViewTextBoxColumn HoldTime;
        private Label lblExplain;
        private Panel panel1;
        private DataGridViewTextBoxColumn PathID;
        private DataGridViewTextBoxColumn PathSegmentID;
        private DataGridViewTextBoxColumn PathSegmentName;
        private DataGridViewTextBoxColumn SegmentFlagValue;
        private DataGridViewTextBoxColumn TopSpeed;
        private DataGridViewTextBoxColumn 路段属性;
        private DataGridViewTextBoxColumn 路宽;
    }
}