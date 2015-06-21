namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class m2mSetRegionTimeAlarm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.colSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.regionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSet = new System.Windows.Forms.Panel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblSpeed2 = new System.Windows.Forms.Label();
            this.grpSet = new System.Windows.Forms.GroupBox();
            this.pnlRegion = new System.Windows.Forms.Panel();
            this.rbtnRegionOut = new System.Windows.Forms.RadioButton();
            this.rbtnRegionIn = new System.Windows.Forms.RadioButton();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.pnlSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.grpSet.SuspendLayout();
            this.pnlRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(203, 3);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 363);
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.dgvArea);
            this.grpArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpArea.Location = new System.Drawing.Point(5, 206);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(363, 157);
            this.grpArea.TabIndex = 11;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "预设区域";
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.AllowUserToResizeRows = false;
            this.dgvArea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvArea.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSel,
            this.regionName,
            this.regionDot,
            this.RegionId});
            this.dgvArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArea.Location = new System.Drawing.Point(3, 17);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.RowHeadersVisible = false;
            this.dgvArea.RowTemplate.Height = 20;
            this.dgvArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvArea.Size = new System.Drawing.Size(357, 137);
            this.dgvArea.TabIndex = 0;
            this.dgvArea.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArea_CellMouseUp);
            // 
            // colSel
            // 
            this.colSel.DataPropertyName = "colSel";
            this.colSel.FalseValue = "False";
            this.colSel.HeaderText = "选中";
            this.colSel.MinimumWidth = 30;
            this.colSel.Name = "colSel";
            this.colSel.TrueValue = "True";
            this.colSel.Width = 35;
            // 
            // regionName
            // 
            this.regionName.DataPropertyName = "regionName";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.regionName.DefaultCellStyle = dataGridViewCellStyle1;
            this.regionName.HeaderText = "区域名称";
            this.regionName.MinimumWidth = 100;
            this.regionName.Name = "regionName";
            this.regionName.ReadOnly = true;
            this.regionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // regionDot
            // 
            this.regionDot.DataPropertyName = "regionDot";
            this.regionDot.HeaderText = "regionDot";
            this.regionDot.Name = "regionDot";
            this.regionDot.ReadOnly = true;
            this.regionDot.Visible = false;
            this.regionDot.Width = 84;
            // 
            // RegionId
            // 
            this.RegionId.DataPropertyName = "RegionId";
            this.RegionId.HeaderText = "RegionId";
            this.RegionId.Name = "RegionId";
            this.RegionId.Visible = false;
            this.RegionId.Width = 78;
            // 
            // pnlSet
            // 
            this.pnlSet.Controls.Add(this.lblSpeed);
            this.pnlSet.Controls.Add(this.numSpeed);
            this.pnlSet.Controls.Add(this.lblSpeed2);
            this.pnlSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSet.Location = new System.Drawing.Point(3, 17);
            this.pnlSet.Name = "pnlSet";
            this.pnlSet.Size = new System.Drawing.Size(357, 34);
            this.pnlSet.TabIndex = 3;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(47, 9);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(65, 12);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "超速时间：";
            // 
            // numSpeed
            // 
            this.numSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSpeed.Location = new System.Drawing.Point(119, 7);
            this.numSpeed.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(161, 21);
            this.numSpeed.TabIndex = 1;
            this.numSpeed.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblSpeed2
            // 
            this.lblSpeed2.AutoSize = true;
            this.lblSpeed2.Location = new System.Drawing.Point(286, 11);
            this.lblSpeed2.Name = "lblSpeed2";
            this.lblSpeed2.Size = new System.Drawing.Size(29, 12);
            this.lblSpeed2.TabIndex = 4;
            this.lblSpeed2.Tag = "；";
            this.lblSpeed2.Text = "分钟";
            // 
            // grpSet
            // 
            this.grpSet.AutoSize = true;
            this.grpSet.Controls.Add(this.pnlRegion);
            this.grpSet.Controls.Add(this.pnlSet);
            this.grpSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSet.Location = new System.Drawing.Point(5, 121);
            this.grpSet.Name = "grpSet";
            this.grpSet.Size = new System.Drawing.Size(363, 85);
            this.grpSet.TabIndex = 12;
            this.grpSet.TabStop = false;
            this.grpSet.Text = "参数设置";
            // 
            // pnlRegion
            // 
            this.pnlRegion.Controls.Add(this.rbtnRegionOut);
            this.pnlRegion.Controls.Add(this.rbtnRegionIn);
            this.pnlRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRegion.Location = new System.Drawing.Point(3, 51);
            this.pnlRegion.Name = "pnlRegion";
            this.pnlRegion.Size = new System.Drawing.Size(357, 31);
            this.pnlRegion.TabIndex = 4;
            // 
            // rbtnRegionOut
            // 
            this.rbtnRegionOut.AutoSize = true;
            this.rbtnRegionOut.Checked = true;
            this.rbtnRegionOut.Location = new System.Drawing.Point(119, 6);
            this.rbtnRegionOut.Name = "rbtnRegionOut";
            this.rbtnRegionOut.Size = new System.Drawing.Size(59, 16);
            this.rbtnRegionOut.TabIndex = 1;
            this.rbtnRegionOut.TabStop = true;
            this.rbtnRegionOut.Text = "区域外";
            this.rbtnRegionOut.UseVisualStyleBackColor = true;
            // 
            // rbtnRegionIn
            // 
            this.rbtnRegionIn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rbtnRegionIn.AutoSize = true;
            this.rbtnRegionIn.Location = new System.Drawing.Point(221, 6);
            this.rbtnRegionIn.Name = "rbtnRegionIn";
            this.rbtnRegionIn.Size = new System.Drawing.Size(59, 16);
            this.rbtnRegionIn.TabIndex = 2;
            this.rbtnRegionIn.TabStop = true;
            this.rbtnRegionIn.Text = "区域内";
            this.rbtnRegionIn.UseVisualStyleBackColor = true;
            // 
            // m2mSetRegionTimeAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(373, 396);
            this.Controls.Add(this.grpArea);
            this.Controls.Add(this.grpSet);
            this.Name = "m2mSetRegionTimeAlarm";
            this.Tag = "";
            this.Text = "设置区域内超速报警";
            this.Load += new System.EventHandler(this.m2mSetRegionSpeedAlarm_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpSet, 0);
            this.Controls.SetChildIndex(this.grpArea, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.pnlSet.ResumeLayout(false);
            this.pnlSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.grpSet.ResumeLayout(false);
            this.pnlRegion.ResumeLayout(false);
            this.pnlRegion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private DataGridViewCheckBoxColumn colSel;
        private DataGridView dgvArea;
        private GroupBox grpArea;
        private GroupBox grpSet;
        private Label lblSpeed;
        private Label lblSpeed2;
        private string m_sCustName;
        private NumericUpDown numSpeed;
        private Panel pnlRegion;
        private Panel pnlSet;
        private RadioButton rbtnRegionIn;
        private RadioButton rbtnRegionOut;
        private DataGridViewTextBoxColumn regionDot;
        private DataGridViewTextBoxColumn RegionId;
        private DataGridViewTextBoxColumn regionName;
    }
}