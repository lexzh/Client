namespace Client.M2M
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class m2mSetRegionSpeedAlarm
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
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.chkListRegion = new WinFormsUI.Controls.CheckBoxList();
            this.pnlSet1 = new System.Windows.Forms.Panel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblSpeed2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSet = new System.Windows.Forms.GroupBox();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpArea.SuspendLayout();
            this.pnlSet1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.grpSet.SuspendLayout();
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
            this.pnlBtn.Location = new System.Drawing.Point(5, 352);
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.chkListRegion);
            this.grpArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpArea.Location = new System.Drawing.Point(5, 195);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(363, 157);
            this.grpArea.TabIndex = 11;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "区域列表";
            // 
            // chkListRegion
            // 
            this.chkListRegion.AutoScroll = true;
            this.chkListRegion.BackColor = System.Drawing.Color.White;
            this.chkListRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkListRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListRegion.Location = new System.Drawing.Point(3, 17);
            this.chkListRegion.Name = "chkListRegion";
            this.chkListRegion.Padding = new System.Windows.Forms.Padding(1);
            this.chkListRegion.Size = new System.Drawing.Size(357, 137);
            this.chkListRegion.TabIndex = 0;
            this.chkListRegion.Tag = "";
            // 
            // pnlSet1
            // 
            this.pnlSet1.Controls.Add(this.lblSpeed);
            this.pnlSet1.Controls.Add(this.numSpeed);
            this.pnlSet1.Controls.Add(this.lblSpeed2);
            this.pnlSet1.Controls.Add(this.label1);
            this.pnlSet1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSet1.Location = new System.Drawing.Point(3, 17);
            this.pnlSet1.Name = "pnlSet1";
            this.pnlSet1.Size = new System.Drawing.Size(357, 54);
            this.pnlSet1.TabIndex = 3;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(13, 7);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(99, 14);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "超速速度：";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numSpeed
            // 
            this.numSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSpeed.Location = new System.Drawing.Point(119, 7);
            this.numSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(161, 21);
            this.numSpeed.TabIndex = 1;
            // 
            // lblSpeed2
            // 
            this.lblSpeed2.AutoSize = true;
            this.lblSpeed2.Location = new System.Drawing.Point(286, 11);
            this.lblSpeed2.Name = "lblSpeed2";
            this.lblSpeed2.Size = new System.Drawing.Size(29, 12);
            this.lblSpeed2.TabIndex = 4;
            this.lblSpeed2.Tag = "；";
            this.lblSpeed2.Text = "公里";
            // 
            // lblVersion
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(118, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 12);
            this.label1.TabIndex = 31;
            this.label1.Tag = "9999";
            this.label1.Text = "*当超速速度为0时，表示取消(0-255)";
            // 
            // grpSet
            // 
            this.grpSet.AutoSize = true;
            this.grpSet.Controls.Add(this.pnlSet1);
            this.grpSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSet.Location = new System.Drawing.Point(5, 121);
            this.grpSet.Name = "grpSet";
            this.grpSet.Size = new System.Drawing.Size(363, 74);
            this.grpSet.TabIndex = 12;
            this.grpSet.TabStop = false;
            this.grpSet.Text = "参数设置";
            // 
            // m2mSetRegionSpeedAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(373, 385);
            this.Controls.Add(this.grpArea);
            this.Controls.Add(this.grpSet);
            this.Name = "m2mSetRegionSpeedAlarm";
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
            this.pnlSet1.ResumeLayout(false);
            this.pnlSet1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.grpSet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private CheckBoxList chkListRegion;
        private System.Windows.Forms.GroupBox grpArea;
        private GroupBox grpSet;
        private Label label1;
        private Label lblSpeed;
        private Label lblSpeed2;
        private string m_sCustName;
        private NumericUpDown numSpeed;
        private Panel pnlSet1;
    }
}