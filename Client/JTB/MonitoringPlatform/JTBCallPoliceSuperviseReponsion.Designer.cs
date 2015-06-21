namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBCallPoliceSuperviseReponsion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpParam = new System.Windows.Forms.GroupBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.txtSimNum = new System.Windows.Forms.TextBox();
            this.txtCarNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbResolve = new System.Windows.Forms.ComboBox();
            this.lblResolve = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grpParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(158, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grpParam
            // 
            this.grpParam.Controls.Add(this.txtDetails);
            this.grpParam.Controls.Add(this.txtSimNum);
            this.grpParam.Controls.Add(this.txtCarNum);
            this.grpParam.Controls.Add(this.label2);
            this.grpParam.Controls.Add(this.label1);
            this.grpParam.Controls.Add(this.cmbResolve);
            this.grpParam.Controls.Add(this.lblResolve);
            this.grpParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpParam.Location = new System.Drawing.Point(0, 0);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new System.Drawing.Size(481, 142);
            this.grpParam.TabIndex = 1;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "设置参数";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(213, 16);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(256, 105);
            this.txtDetails.TabIndex = 6;
            // 
            // txtSimNum
            // 
            this.txtSimNum.Enabled = false;
            this.txtSimNum.Location = new System.Drawing.Point(86, 58);
            this.txtSimNum.Name = "txtSimNum";
            this.txtSimNum.Size = new System.Drawing.Size(121, 21);
            this.txtSimNum.TabIndex = 5;
            // 
            // txtCarNum
            // 
            this.txtCarNum.Enabled = false;
            this.txtCarNum.Location = new System.Drawing.Point(86, 16);
            this.txtCarNum.Name = "txtCarNum";
            this.txtCarNum.Size = new System.Drawing.Size(121, 21);
            this.txtCarNum.TabIndex = 4;
            // 
            // lblCompany
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "手机号码：";
            // 
            // lblVersion
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "车牌号：";
            // 
            // cmbResolve
            // 
            this.cmbResolve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResolve.FormattingEnabled = true;
            this.cmbResolve.Items.AddRange(new object[] {
            "处理中",
            "已处理完毕",
            "不作处理",
            "将来处理"});
            this.cmbResolve.Location = new System.Drawing.Point(86, 101);
            this.cmbResolve.Name = "cmbResolve";
            this.cmbResolve.Size = new System.Drawing.Size(121, 20);
            this.cmbResolve.TabIndex = 1;
            // 
            // lblResolve
            // 
            this.lblResolve.AutoSize = true;
            this.lblResolve.Location = new System.Drawing.Point(15, 104);
            this.lblResolve.Name = "lblResolve";
            this.lblResolve.Size = new System.Drawing.Size(65, 12);
            this.lblResolve.TabIndex = 0;
            this.lblResolve.Text = "处理情况：";
            // 
            // JTBCallPoliceSuperviseReponsion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 177);
            this.Controls.Add(this.grpParam);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JTBCallPoliceSuperviseReponsion";
            this.panel1.ResumeLayout(false);
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            this.ResumeLayout(false);

        }
    
        private IContainer components;
        private string _carNum;
        private Button btnCancel;
        private Button btnOk;
        private ComboBox cmbResolve;
        private GroupBox grpParam;
        private Label label1;
        private Label label2;
        private Label lblResolve;
        private ParamLibrary.Application.CmdParam.OrderCode OrderCode;
        private System.Windows.Forms.Panel panel1;
        private Response reResult;
        private TextBox txtCarNum;
        private TextBox txtDetails;
        private TextBox txtSimNum;
    }
}