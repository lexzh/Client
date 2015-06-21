namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class JTBThoroughlyCommand
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(JTBThoroughlyCommand));
            this.grpWatchProperty = new GroupBox();
            this.txtCmd = new TextBox();
            this.dgvEventList = new DataGridViewEx();
            this.选择 = new DataGridViewCheckBoxColumn();
            this.事件内容 = new DataGridViewTextBoxColumn();
            this.事件ID = new DataGridViewTextBoxColumn();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            ((ISupportInitialize) this.dgvEventList).BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 215);
            this.grpWatchProperty.Controls.Add(this.txtCmd);
            this.grpWatchProperty.Controls.Add(this.dgvEventList);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 94);
            this.grpWatchProperty.TabIndex = 15;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "透传命令";
            this.txtCmd.Location = new System.Drawing.Point(47, 15);
            this.txtCmd.MaxLength = 200;
            this.txtCmd.Multiline = true;
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new Size(269, 73);
            this.txtCmd.TabIndex = 1;
            this.dgvEventList.AllowUserToAddRows = false;
            this.dgvEventList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventList.Columns.AddRange(new DataGridViewColumn[] { this.选择, this.事件内容, this.事件ID });
            this.dgvEventList.Location = new System.Drawing.Point(467, 159);
            this.dgvEventList.Name = "dgvEventList";
            this.dgvEventList.NotMultiSelectedColumnName = (List<string>) resources.GetObject("dgvEventList.NotMultiSelectedColumnName");
            this.dgvEventList.RowHeadersVisible = false;
            this.dgvEventList.RowTemplate.Height = 23;
            this.dgvEventList.Size = new Size(10, 10);
            this.dgvEventList.TabIndex = 0;
            this.dgvEventList.Visible = false;
            this.选择.DataPropertyName = "Flag";
            this.选择.FalseValue = "False";
            this.选择.HeaderText = "选择";
            this.选择.Name = "选择";
            this.选择.TrueValue = "True";
            this.选择.Width = 50;
            this.事件内容.DataPropertyName = "MsgName";
            this.事件内容.HeaderText = "事件内容";
            this.事件内容.Name = "事件内容";
            this.事件内容.ReadOnly = true;
            this.事件内容.Width = 400;
            this.事件ID.DataPropertyName = "ID";
            this.事件ID.HeaderText = "事件ID";
            this.事件ID.Name = "事件ID";
            this.事件ID.ReadOnly = true;
            this.事件ID.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 248);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBThoroughlyCommand";
            this.Text = "JTBThoroughlyCommand";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            ((ISupportInitialize) this.dgvEventList).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private DataGridViewEx dgvEventList;
        private GroupBox grpWatchProperty;
        private TextBox txtCmd;
        private DataGridViewTextBoxColumn 事件ID;
        private DataGridViewTextBoxColumn 事件内容;
        private DataGridViewCheckBoxColumn 选择;
    }
}