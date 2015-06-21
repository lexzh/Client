namespace Client.M2M
{
    using Client;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class m2mMapPath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(m2mMapPath));
            this.grpPoint = new System.Windows.Forms.GroupBox();
            this.pnlPath = new System.Windows.Forms.Panel();
            this.cmbPathType = new WinFormsUI.Controls.ComBox();
            this.numRadius = new System.Windows.Forms.NumericUpDown();
            this.lblMeter = new System.Windows.Forms.Label();
            this.lblRadius = new System.Windows.Forms.Label();
            this.lblEndName = new System.Windows.Forms.Label();
            this.lblBeginName = new System.Windows.Forms.Label();
            this.txtEndName = new System.Windows.Forms.TextBox();
            this.txtBeginName = new System.Windows.Forms.TextBox();
            this.lblPathType = new System.Windows.Forms.Label();
            this.pnlCircel = new System.Windows.Forms.Panel();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.lblDis = new System.Windows.Forms.Label();
            this.lblDis2 = new System.Windows.Forms.Label();
            this.pnlAll = new System.Windows.Forms.Panel();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpPoint.SuspendLayout();
            this.pnlPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).BeginInit();
            this.pnlCircel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPoint
            // 
            this.grpPoint.AutoSize = true;
            this.grpPoint.Controls.Add(this.pnlPath);
            this.grpPoint.Controls.Add(this.pnlCircel);
            this.grpPoint.Controls.Add(this.pnlAll);
            this.grpPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPoint.Location = new System.Drawing.Point(5, 5);
            this.grpPoint.Name = "grpPoint";
            this.grpPoint.Size = new System.Drawing.Size(363, 221);
            this.grpPoint.TabIndex = 0;
            this.grpPoint.TabStop = false;
            // 
            // pnlPath
            // 
            this.pnlPath.Controls.Add(this.cmbPathType);
            this.pnlPath.Controls.Add(this.numRadius);
            this.pnlPath.Controls.Add(this.lblMeter);
            this.pnlPath.Controls.Add(this.lblRadius);
            this.pnlPath.Controls.Add(this.lblEndName);
            this.pnlPath.Controls.Add(this.lblBeginName);
            this.pnlPath.Controls.Add(this.txtEndName);
            this.pnlPath.Controls.Add(this.txtBeginName);
            this.pnlPath.Controls.Add(this.lblPathType);
            this.pnlPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPath.Location = new System.Drawing.Point(3, 104);
            this.pnlPath.Name = "pnlPath";
            this.pnlPath.Size = new System.Drawing.Size(357, 114);
            this.pnlPath.TabIndex = 1;
            // 
            // cmbPathType
            // 
            this.cmbPathType.DisplayMember = "Display";
            this.cmbPathType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPathType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPathType.FormattingEnabled = true;
            this.cmbPathType.Location = new System.Drawing.Point(119, 5);
            this.cmbPathType.Name = "cmbPathType";
            this.cmbPathType.Size = new System.Drawing.Size(161, 20);
            this.cmbPathType.TabIndex = 0;
            this.cmbPathType.ValueMember = "Value";
            this.cmbPathType.SelectedIndexChanged += new System.EventHandler(this.cmbPathType_SelectedIndexChanged);
            // 
            // numRadius
            // 
            this.numRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRadius.Enabled = false;
            this.numRadius.Location = new System.Drawing.Point(119, 88);
            this.numRadius.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numRadius.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRadius.Name = "numRadius";
            this.numRadius.Size = new System.Drawing.Size(161, 21);
            this.numRadius.TabIndex = 3;
            this.numRadius.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // lblMeter
            // 
            this.lblMeter.AutoSize = true;
            this.lblMeter.Location = new System.Drawing.Point(286, 90);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new System.Drawing.Size(17, 12);
            this.lblMeter.TabIndex = 16;
            this.lblMeter.Text = "米";
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(11, 90);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(101, 12);
            this.lblRadius.TabIndex = 17;
            this.lblRadius.Text = "起点、终点半径：";
            // 
            // lblEndName
            // 
            this.lblEndName.AutoSize = true;
            this.lblEndName.Location = new System.Drawing.Point(47, 63);
            this.lblEndName.Name = "lblEndName";
            this.lblEndName.Size = new System.Drawing.Size(65, 12);
            this.lblEndName.TabIndex = 15;
            this.lblEndName.Text = "终点名称：";
            // 
            // lblBeginName
            // 
            this.lblBeginName.AutoSize = true;
            this.lblBeginName.Location = new System.Drawing.Point(47, 36);
            this.lblBeginName.Name = "lblBeginName";
            this.lblBeginName.Size = new System.Drawing.Size(65, 12);
            this.lblBeginName.TabIndex = 13;
            this.lblBeginName.Text = "起点名称：";
            // 
            // txtEndName
            // 
            this.txtEndName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndName.Enabled = false;
            this.txtEndName.Location = new System.Drawing.Point(119, 60);
            this.txtEndName.MaxLength = 50;
            this.txtEndName.Name = "txtEndName";
            this.txtEndName.Size = new System.Drawing.Size(161, 21);
            this.txtEndName.TabIndex = 2;
            // 
            // txtBeginName
            // 
            this.txtBeginName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBeginName.Enabled = false;
            this.txtBeginName.Location = new System.Drawing.Point(119, 33);
            this.txtBeginName.MaxLength = 50;
            this.txtBeginName.Name = "txtBeginName";
            this.txtBeginName.Size = new System.Drawing.Size(161, 21);
            this.txtBeginName.TabIndex = 1;
            // 
            // lblPathType
            // 
            this.lblPathType.AutoSize = true;
            this.lblPathType.Location = new System.Drawing.Point(23, 8);
            this.lblPathType.Name = "lblPathType";
            this.lblPathType.Size = new System.Drawing.Size(89, 12);
            this.lblPathType.TabIndex = 14;
            this.lblPathType.Text = "选择路线性质：";
            // 
            // pnlCircel
            // 
            this.pnlCircel.Controls.Add(this.numDistance);
            this.pnlCircel.Controls.Add(this.lblDis);
            this.pnlCircel.Controls.Add(this.lblDis2);
            this.pnlCircel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCircel.Location = new System.Drawing.Point(3, 71);
            this.pnlCircel.Name = "pnlCircel";
            this.pnlCircel.Size = new System.Drawing.Size(357, 33);
            this.pnlCircel.TabIndex = 2;
            // 
            // numDistance
            // 
            this.numDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDistance.Location = new System.Drawing.Point(119, 6);
            this.numDistance.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(161, 21);
            this.numDistance.TabIndex = 7;
            this.numDistance.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblDis
            // 
            this.lblDis.AutoSize = true;
            this.lblDis.Location = new System.Drawing.Point(47, 8);
            this.lblDis.Name = "lblDis";
            this.lblDis.Size = new System.Drawing.Size(65, 12);
            this.lblDis.TabIndex = 5;
            this.lblDis.Text = "圆形半径：";
            // 
            // lblDis2
            // 
            this.lblDis2.AutoSize = true;
            this.lblDis2.Location = new System.Drawing.Point(285, 8);
            this.lblDis2.Name = "lblDis2";
            this.lblDis2.Size = new System.Drawing.Size(17, 12);
            this.lblDis2.TabIndex = 6;
            this.lblDis2.Text = "米";
            // 
            // pnlAll
            // 
            this.pnlAll.Controls.Add(this.cmbGroup);
            this.pnlAll.Controls.Add(this.txtName);
            this.pnlAll.Controls.Add(this.lblName);
            this.pnlAll.Controls.Add(this.lblGroup);
            this.pnlAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAll.Location = new System.Drawing.Point(3, 17);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(357, 54);
            this.pnlAll.TabIndex = 0;
            // 
            // cmbGroup
            // 
            this.cmbGroup.DisplayMember = "pathgroupName";
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(119, 3);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(161, 20);
            this.cmbGroup.TabIndex = 0;
            this.cmbGroup.ValueMember = "pathgroupID";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(119, 30);
            this.txtName.MaxLength = 40;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(161, 21);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(35, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 12);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "请输入名称：";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(35, 6);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(77, 12);
            this.lblGroup.TabIndex = 10;
            this.lblGroup.Text = "请选择组别：";
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.btnCancel);
            this.pnlBtn.Controls.Add(this.btnOK);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBtn.Location = new System.Drawing.Point(5, 226);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new System.Drawing.Size(363, 28);
            this.pnlBtn.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(288, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(203, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // m2mMapPath
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(373, 259);
            this.Controls.Add(this.pnlBtn);
            this.Controls.Add(this.grpPoint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "m2mMapPath";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "设置路线";
            this.Load += new System.EventHandler(this.MapPath_Load);
            this.grpPoint.ResumeLayout(false);
            this.pnlPath.ResumeLayout(false);
            this.pnlPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).EndInit();
            this.pnlCircel.ResumeLayout(false);
            this.pnlCircel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAll.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private string _pathGroupID;
        private string _pathName;
        private ComBox cmbPathType;
        private bool isUpdate;
        private Label lblDis;
        private Label lblDis2;
        private NumericUpDown numDistance;
        private NumericUpDown numRadius;
        private Panel pnlAll;
        private Panel pnlCircel;
        private Panel pnlPath;
        private itmPreSetPath.PreType preType;
    }
}