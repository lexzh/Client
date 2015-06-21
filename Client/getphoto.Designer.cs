namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class getphoto
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
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.pnlDeleteAll = new System.Windows.Forms.Panel();
            this.chkDeleteAll = new System.Windows.Forms.CheckBox();
            this.pnlCondition = new System.Windows.Forms.Panel();
            this.lblPictureCnt = new System.Windows.Forms.Label();
            this.numPictureCnt = new System.Windows.Forms.NumericUpDown();
            this.chkDoor = new System.Windows.Forms.CheckBox();
            this.chkState = new System.Windows.Forms.CheckBox();
            this.chkExigence = new System.Windows.Forms.CheckBox();
            this.chkAgainst = new System.Windows.Forms.CheckBox();
            this.chkAcc = new System.Windows.Forms.CheckBox();
            this.chkCustom1 = new System.Windows.Forms.CheckBox();
            this.chkCustom2 = new System.Windows.Forms.CheckBox();
            this.chkCustom3 = new System.Windows.Forms.CheckBox();
            this.chkCustom4 = new System.Windows.Forms.CheckBox();
            this.chkCustom5 = new System.Windows.Forms.CheckBox();
            this.chkCustom6 = new System.Windows.Forms.CheckBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpCondition.SuspendLayout();
            this.pnlDeleteAll.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPictureCnt)).BeginInit();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.TabIndex = 0;
            // 
            // grpCar
            // 
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 399);
            this.pnlBtn.TabIndex = 2;
            // 
            // grpCondition
            // 
            this.grpCondition.AutoSize = true;
            this.grpCondition.Controls.Add(this.pnlDeleteAll);
            this.grpCondition.Controls.Add(this.pnlCondition);
            this.grpCondition.Controls.Add(this.pnlDate);
            this.grpCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCondition.Location = new System.Drawing.Point(5, 121);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(363, 278);
            this.grpCondition.TabIndex = 1;
            this.grpCondition.TabStop = false;
            this.grpCondition.Text = "获取黑匣子数据条件";
            // 
            // pnlDeleteAll
            // 
            this.pnlDeleteAll.Controls.Add(this.chkDeleteAll);
            this.pnlDeleteAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDeleteAll.Location = new System.Drawing.Point(3, 249);
            this.pnlDeleteAll.Name = "pnlDeleteAll";
            this.pnlDeleteAll.Size = new System.Drawing.Size(357, 26);
            this.pnlDeleteAll.TabIndex = 2;
            // 
            // chkDeleteAll
            // 
            this.chkDeleteAll.AutoSize = true;
            this.chkDeleteAll.Location = new System.Drawing.Point(119, 6);
            this.chkDeleteAll.Name = "chkDeleteAll";
            this.chkDeleteAll.Size = new System.Drawing.Size(72, 16);
            this.chkDeleteAll.TabIndex = 0;
            this.chkDeleteAll.Text = "全部删除";
            this.chkDeleteAll.UseVisualStyleBackColor = true;
            this.chkDeleteAll.CheckedChanged += new System.EventHandler(this.chkDeleteAll_CheckedChanged);
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.lblPictureCnt);
            this.pnlCondition.Controls.Add(this.numPictureCnt);
            this.pnlCondition.Controls.Add(this.chkDoor);
            this.pnlCondition.Controls.Add(this.chkState);
            this.pnlCondition.Controls.Add(this.chkExigence);
            this.pnlCondition.Controls.Add(this.chkAgainst);
            this.pnlCondition.Controls.Add(this.chkAcc);
            this.pnlCondition.Controls.Add(this.chkCustom1);
            this.pnlCondition.Controls.Add(this.chkCustom2);
            this.pnlCondition.Controls.Add(this.chkCustom3);
            this.pnlCondition.Controls.Add(this.chkCustom4);
            this.pnlCondition.Controls.Add(this.chkCustom5);
            this.pnlCondition.Controls.Add(this.chkCustom6);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(3, 129);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(357, 120);
            this.pnlCondition.TabIndex = 1;
            // 
            // lblPictureCnt
            // 
            this.lblPictureCnt.AutoSize = true;
            this.lblPictureCnt.Location = new System.Drawing.Point(47, 6);
            this.lblPictureCnt.Name = "lblPictureCnt";
            this.lblPictureCnt.Size = new System.Drawing.Size(65, 12);
            this.lblPictureCnt.TabIndex = 3;
            this.lblPictureCnt.Text = "图片数量：";
            // 
            // numPictureCnt
            // 
            this.numPictureCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPictureCnt.Location = new System.Drawing.Point(119, 4);
            this.numPictureCnt.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numPictureCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPictureCnt.Name = "numPictureCnt";
            this.numPictureCnt.Size = new System.Drawing.Size(158, 21);
            this.numPictureCnt.TabIndex = 0;
            this.numPictureCnt.Tag = "；";
            this.numPictureCnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkDoor
            // 
            this.chkDoor.AutoSize = true;
            this.chkDoor.Location = new System.Drawing.Point(49, 35);
            this.chkDoor.Name = "chkDoor";
            this.chkDoor.Size = new System.Drawing.Size(72, 16);
            this.chkDoor.TabIndex = 1;
            this.chkDoor.Text = "车门开合";
            this.chkDoor.UseVisualStyleBackColor = true;
            // 
            // chkState
            // 
            this.chkState.AutoSize = true;
            this.chkState.Location = new System.Drawing.Point(150, 35);
            this.chkState.Name = "chkState";
            this.chkState.Size = new System.Drawing.Size(72, 16);
            this.chkState.TabIndex = 2;
            this.chkState.Text = "运营状态";
            this.chkState.UseVisualStyleBackColor = true;
            // 
            // chkExigence
            // 
            this.chkExigence.AutoSize = true;
            this.chkExigence.Location = new System.Drawing.Point(248, 35);
            this.chkExigence.Name = "chkExigence";
            this.chkExigence.Size = new System.Drawing.Size(72, 16);
            this.chkExigence.TabIndex = 3;
            this.chkExigence.Text = "紧急报警";
            this.chkExigence.UseVisualStyleBackColor = true;
            // 
            // chkAgainst
            // 
            this.chkAgainst.AutoSize = true;
            this.chkAgainst.Location = new System.Drawing.Point(49, 57);
            this.chkAgainst.Name = "chkAgainst";
            this.chkAgainst.Size = new System.Drawing.Size(72, 16);
            this.chkAgainst.TabIndex = 4;
            this.chkAgainst.Text = "防盗报警";
            this.chkAgainst.UseVisualStyleBackColor = true;
            // 
            // chkAcc
            // 
            this.chkAcc.AutoSize = true;
            this.chkAcc.Location = new System.Drawing.Point(150, 57);
            this.chkAcc.Name = "chkAcc";
            this.chkAcc.Size = new System.Drawing.Size(66, 16);
            this.chkAcc.TabIndex = 5;
            this.chkAcc.Text = "ACC开关";
            this.chkAcc.UseVisualStyleBackColor = true;
            // 
            // chkCustom1
            // 
            this.chkCustom1.AutoSize = true;
            this.chkCustom1.Location = new System.Drawing.Point(248, 57);
            this.chkCustom1.Name = "chkCustom1";
            this.chkCustom1.Size = new System.Drawing.Size(66, 16);
            this.chkCustom1.TabIndex = 6;
            this.chkCustom1.Text = "自定义1";
            this.chkCustom1.UseVisualStyleBackColor = true;
            // 
            // chkCustom2
            // 
            this.chkCustom2.AutoSize = true;
            this.chkCustom2.Location = new System.Drawing.Point(49, 79);
            this.chkCustom2.Name = "chkCustom2";
            this.chkCustom2.Size = new System.Drawing.Size(66, 16);
            this.chkCustom2.TabIndex = 7;
            this.chkCustom2.Text = "自定义2";
            this.chkCustom2.UseVisualStyleBackColor = true;
            // 
            // chkCustom3
            // 
            this.chkCustom3.AutoSize = true;
            this.chkCustom3.Location = new System.Drawing.Point(150, 79);
            this.chkCustom3.Name = "chkCustom3";
            this.chkCustom3.Size = new System.Drawing.Size(66, 16);
            this.chkCustom3.TabIndex = 8;
            this.chkCustom3.Text = "自定义3";
            this.chkCustom3.UseVisualStyleBackColor = true;
            // 
            // chkCustom4
            // 
            this.chkCustom4.AutoSize = true;
            this.chkCustom4.Location = new System.Drawing.Point(248, 79);
            this.chkCustom4.Name = "chkCustom4";
            this.chkCustom4.Size = new System.Drawing.Size(66, 16);
            this.chkCustom4.TabIndex = 9;
            this.chkCustom4.Text = "自定义4";
            this.chkCustom4.UseVisualStyleBackColor = true;
            // 
            // chkCustom5
            // 
            this.chkCustom5.AutoSize = true;
            this.chkCustom5.Location = new System.Drawing.Point(49, 101);
            this.chkCustom5.Name = "chkCustom5";
            this.chkCustom5.Size = new System.Drawing.Size(66, 16);
            this.chkCustom5.TabIndex = 10;
            this.chkCustom5.Text = "自定义5";
            this.chkCustom5.UseVisualStyleBackColor = true;
            // 
            // chkCustom6
            // 
            this.chkCustom6.AutoSize = true;
            this.chkCustom6.Location = new System.Drawing.Point(150, 101);
            this.chkCustom6.Name = "chkCustom6";
            this.chkCustom6.Size = new System.Drawing.Size(66, 16);
            this.chkCustom6.TabIndex = 11;
            this.chkCustom6.Text = "自定义6";
            this.chkCustom6.UseVisualStyleBackColor = true;
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.lblStartDate);
            this.pnlDate.Controls.Add(this.dtpStartDate);
            this.pnlDate.Controls.Add(this.lblStartTime);
            this.pnlDate.Controls.Add(this.dtpStartTime);
            this.pnlDate.Controls.Add(this.lblEndDate);
            this.pnlDate.Controls.Add(this.dtpEndDate);
            this.pnlDate.Controls.Add(this.lblEndTime);
            this.pnlDate.Controls.Add(this.dtpEndTime);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(3, 17);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(357, 112);
            this.pnlDate.TabIndex = 0;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(47, 11);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 12);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "开始日期：";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(119, 7);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(158, 21);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.Tag = "；";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(47, 38);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(65, 12);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "开始时间：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(119, 34);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(158, 21);
            this.dtpStartTime.TabIndex = 1;
            this.dtpStartTime.Tag = "；";
            this.dtpStartTime.Value = new System.DateTime(2010, 8, 6, 0, 0, 0, 0);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(47, 65);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(65, 12);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "结束日期：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(119, 61);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(158, 21);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.Tag = "；";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(47, 92);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(65, 12);
            this.lblEndTime.TabIndex = 0;
            this.lblEndTime.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(119, 88);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(158, 21);
            this.dtpEndTime.TabIndex = 3;
            this.dtpEndTime.Tag = "；";
            // 
            // getphoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(373, 432);
            this.Controls.Add(this.grpCondition);
            this.Name = "getphoto";
            this.Text = "黑匣子图像上传";
            this.Load += new System.EventHandler(this.BlackBoxImage_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpCondition, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpCondition.ResumeLayout(false);
            this.pnlDeleteAll.ResumeLayout(false);
            this.pnlDeleteAll.PerformLayout();
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPictureCnt)).EndInit();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private CheckBox chkAcc;
        private CheckBox chkAgainst;
        private CheckBox chkCustom1;
        private CheckBox chkCustom2;
        private CheckBox chkCustom3;
        private CheckBox chkCustom4;
        private CheckBox chkCustom5;
        private CheckBox chkCustom6;
        private CheckBox chkDeleteAll;
        private CheckBox chkDoor;
        private CheckBox chkExigence;
        private CheckBox chkState;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpStartTime;
        private GroupBox grpCondition;
        private Label lblEndDate;
        private Label lblEndTime;
        private Label lblPictureCnt;
        private Label lblStartDate;
        private Label lblStartTime;
        private NumericUpDown numPictureCnt;
        private Panel pnlCondition;
        private Panel pnlDate;
        private Panel pnlDeleteAll;
    }
}