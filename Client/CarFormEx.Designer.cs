namespace Client
{
    using ParamLibrary.Application;
    using ParamLibrary.Entity;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class CarFormEx
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(366, 116);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.Location = new System.Drawing.Point(5, 128);
            this.pnlBtn.Size = new System.Drawing.Size(366, 28);
            this.pnlBtn.SizeChanged += new System.EventHandler(this.pnlBtn_SizeChanged);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(5, 121);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(366, 7);
            this.pnlContainer.TabIndex = 11;
            // 
            // CarFormEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 161);
            this.Controls.Add(this.pnlContainer);
            this.MinimumSize = new System.Drawing.Size(382, 186);
            this.Name = "CarFormEx";
            this.Text = "CarFormEx";
            this.Load += new System.EventHandler(this.CarFormEx_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private CarFormBaseControl _carparam;
    }
}