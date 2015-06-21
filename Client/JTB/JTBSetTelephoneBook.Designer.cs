namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class JTBSetTelephoneBook
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(JTBSetTelephoneBook));
            this.grpWatchProperty = new GroupBox();
            this.dataGridViewEx1 = new DataGridViewEx();
            this.IsChecked = new DataGridViewCheckBoxColumn();
            this.呼叫类型 = new DataGridViewComboBoxColumn();
            this.电话号码 = new DataGridViewTextBoxColumn();
            this.描述 = new DataGridViewTextBoxColumn();
            this.isold = new DataGridViewTextBoxColumn();
            this.panel1 = new Panel();
            this.cmbSetType = new ComboBox();
            this.lblSetType = new Label();
            this.lblExplain = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewEx1).BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.Size = new Size(577, 116);
            base.pnlBtn.Controls.Add(this.lblExplain);
            base.pnlBtn.Location = new System.Drawing.Point(5, 391);
            base.pnlBtn.Size = new Size(577, 28);
            base.pnlBtn.Controls.SetChildIndex(base.btnOK, 0);
            base.pnlBtn.Controls.SetChildIndex(base.btnCancel, 0);
            base.pnlBtn.Controls.SetChildIndex(this.lblExplain, 0);
            base.btnCancel.Location = new System.Drawing.Point(499, 5);
            base.btnOK.Location = new System.Drawing.Point(414, 5);
            this.grpWatchProperty.Controls.Add(this.dataGridViewEx1);
            this.grpWatchProperty.Controls.Add(this.panel1);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(577, 270);
            this.grpWatchProperty.TabIndex = 12;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置电话号码";
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.BackgroundColor = Color.White;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new DataGridViewColumn[] { this.IsChecked, this.呼叫类型, this.电话号码, this.描述, this.isold });
            this.dataGridViewEx1.Dock = DockStyle.Fill;
            this.dataGridViewEx1.ImeMode =  System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewEx1.Location = new System.Drawing.Point(3, 42);
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.NotMultiSelectedColumnName = (List<string>) resources.GetObject("dataGridViewEx1.NotMultiSelectedColumnName");
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 23;
            this.dataGridViewEx1.Size = new Size(571, 225);
            this.dataGridViewEx1.TabIndex = 0;
            this.dataGridViewEx1.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridViewEx1_CellFormatting);
            this.dataGridViewEx1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewEx1_EditingControlShowing);
            this.dataGridViewEx1.DataError += new DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            this.dataGridViewEx1.KeyDown += new KeyEventHandler(this.dataGridViewEx1_KeyDown);
            this.IsChecked.DataPropertyName = "IsChecked";
            this.IsChecked.FalseValue = "False";
            this.IsChecked.HeaderText = "选择";
            this.IsChecked.Name = "IsChecked";
            this.IsChecked.TrueValue = "True";
            this.呼叫类型.DataPropertyName = "Flag";
            this.呼叫类型.HeaderText = "呼叫类型";
            this.呼叫类型.Name = "呼叫类型";
            this.电话号码.DataPropertyName = "Phone";
            this.电话号码.HeaderText = "电话号码";
            this.电话号码.MaxInputLength = 20;
            this.电话号码.Name = "电话号码";
            this.电话号码.Width = 140;
            this.描述.DataPropertyName = "Name";
            this.描述.HeaderText = "联系人";
            this.描述.MaxInputLength = 20;
            this.描述.Name = "描述";
            this.描述.Width = 140;
            this.isold.DataPropertyName = "isold";
            this.isold.HeaderText = "isold";
            this.isold.Name = "isold";
            this.isold.ReadOnly = true;
            this.isold.Visible = false;
            this.panel1.Controls.Add(this.cmbSetType);
            this.panel1.Controls.Add(this.lblSetType);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(571, 25);
            this.panel1.TabIndex = 1;
            this.cmbSetType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSetType.FormattingEnabled = true;
            this.cmbSetType.Items.AddRange(new object[] { "删除终端上所有的联系人", "更新电话本", "追加电话本", "修改电话本" });
            this.cmbSetType.Location = new System.Drawing.Point(73, 3);
            this.cmbSetType.Name = "cmbSetType";
            this.cmbSetType.Size = new Size(165, 20);
            this.cmbSetType.TabIndex = 38;
            this.cmbSetType.SelectedIndexChanged += new EventHandler(this.cmbSetType_SelectedIndexChanged);
            this.lblSetType.AutoSize = true;
            this.lblSetType.Location = new System.Drawing.Point(6, 6);
            this.lblSetType.Name = "lblSetType";
            this.lblSetType.Size = new Size(65, 12);
            this.lblSetType.TabIndex = 37;
            this.lblSetType.Text = "设置类型：";
            this.lblExplain.AutoSize = true;
            this.lblExplain.ForeColor = Color.Red;
            this.lblExplain.Location = new System.Drawing.Point(9, 10);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new Size(287, 12);
            this.lblExplain.TabIndex = 39;
            this.lblExplain.Tag = "9999";
            this.lblExplain.Text = "*按Del键删除行  *更新电话本时未勾选行将会被删除";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(587, 424);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetTelephoneBook";
            this.Text = "JTBSetTelephoneBook";
            base.Load += new EventHandler(this.JTBSetTelephoneBook_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            base.pnlBtn.PerformLayout();
            this.grpWatchProperty.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewEx1).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComboBox cmbSetType;
        private DataGridViewEx dataGridViewEx1;
        private DataGridViewTextBoxEditingControl EditingControl;
        private DataGridViewTextBoxEditingControl EditingControlEx;
        private GroupBox grpWatchProperty;
        private DataGridViewCheckBoxColumn IsChecked;
        private DataGridViewTextBoxColumn isold;
        private Label lblExplain;
        private Label lblSetType;
        private Color oldColor;
        private Panel panel1;
        private DataGridViewTextBoxColumn 电话号码;
        private DataGridViewComboBoxColumn 呼叫类型;
        private DataGridViewTextBoxColumn 描述;
    }
}