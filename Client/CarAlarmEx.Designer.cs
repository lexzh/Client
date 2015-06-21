namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class CarAlarmEx
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
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 388);
            // 
            // CarAlarmEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 421);
            this.Name = "CarAlarmEx";
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    
        private IContainer components;
        private int _报警车数量;
        private int _显示当前车辆;
    }
}