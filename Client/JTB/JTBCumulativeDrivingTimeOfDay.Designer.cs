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

    partial class JTBCumulativeDrivingTimeOfDay
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
            this.grpWatchProperty = new System.Windows.Forms.GroupBox();
            this.lblDrivingTimeOfDay = new System.Windows.Forms.Label();
            this.numDrivingTimeOfDay = new System.Windows.Forms.NumericUpDown();
            this.lblFullSecond = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrivingTimeOfDay)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(362, 116);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 168);
            this.pnlBtn.Size = new System.Drawing.Size(362, 28);
            // 
            // grpWatchProperty
            // 
            this.grpWatchProperty.Controls.Add(this.lblDrivingTimeOfDay);
            this.grpWatchProperty.Controls.Add(this.numDrivingTimeOfDay);
            this.grpWatchProperty.Controls.Add(this.lblFullSecond);
            this.grpWatchProperty.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new System.Drawing.Size(362, 47);
            this.grpWatchProperty.TabIndex = 11;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            // 
            // lblDrivingTimeOfDay
            // 
            this.lblDrivingTimeOfDay.AutoSize = true;
            this.lblDrivingTimeOfDay.Location = new System.Drawing.Point(3, 20);
            this.lblDrivingTimeOfDay.Name = "lblDrivingTimeOfDay";
            this.lblDrivingTimeOfDay.Size = new System.Drawing.Size(113, 12);
            this.lblDrivingTimeOfDay.TabIndex = 18;
            this.lblDrivingTimeOfDay.Text = "当天累计驾驶门限：";
            // 
            // numDrivingTimeOfDay
            // 
            this.numDrivingTimeOfDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDrivingTimeOfDay.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.numDrivingTimeOfDay.Location = new System.Drawing.Point(122, 15);
            this.numDrivingTimeOfDay.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numDrivingTimeOfDay.Name = "numDrivingTimeOfDay";
            this.numDrivingTimeOfDay.Size = new System.Drawing.Size(96, 21);
            this.numDrivingTimeOfDay.TabIndex = 17;
            // 
            // lblFullSecond
            // 
            this.lblFullSecond.AutoSize = true;
            this.lblFullSecond.Location = new System.Drawing.Point(224, 20);
            this.lblFullSecond.Name = "lblFullSecond";
            this.lblFullSecond.Size = new System.Drawing.Size(29, 12);
            this.lblFullSecond.TabIndex = 19;
            this.lblFullSecond.Tag = "；";
            this.lblFullSecond.Text = "小时";
            // 
            // JTBCumulativeDrivingTimeOfDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 201);
            this.Controls.Add(this.grpWatchProperty);
            this.Name = "JTBCumulativeDrivingTimeOfDay";
            this.Text = "JTBCumulativeDrivingTimeOfDay";
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpWatchProperty, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrivingTimeOfDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    
        private IContainer components;
        private GroupBox grpWatchProperty;
        private Label lblDrivingTimeOfDay;
        private Label lblFullSecond;
        private NumericUpDown numDrivingTimeOfDay;
    }
}