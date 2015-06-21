namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    partial class SetLogFilterAlarmType
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
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            this.dgvList = new DataGridView();
            this.报警类型 = new DataGridViewTextBoxColumn();
            this.选择 = new DataGridViewCheckBoxColumn();
            this.CarStatu = new DataGridViewTextBoxColumn();
            this.Type = new DataGridViewTextBoxColumn();
            this.panel1 = new Panel();
            this.chkCheckAll = new CheckBox();
            this.btnOk = new Button();
            this.label8 = new Label();
            ((ISupportInitialize) this.dgvList).BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.BackgroundColor = Color.White;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = style;
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new DataGridViewColumn[] { this.报警类型, this.选择, this.CarStatu, this.Type });
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Window;
            style2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            style2.ForeColor = SystemColors.ControlText;
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = style2;
            this.dgvList.Dock = DockStyle.Fill;
            this.dgvList.Location = new Point(0, 0);
            this.dgvList.Name = "dgvList";
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = SystemColors.Control;
            style3.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            style3.ForeColor = SystemColors.WindowText;
            style3.SelectionBackColor = SystemColors.Highlight;
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = style3;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new Size(321, 244);
            this.dgvList.TabIndex = 0;
            this.报警类型.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.报警类型.DataPropertyName = "CarStatuName";
            this.报警类型.HeaderText = "报警类型";
            this.报警类型.Name = "报警类型";
            this.报警类型.ReadOnly = true;
            this.报警类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.选择.DataPropertyName = "isCheck";
            this.选择.FalseValue = "False";
            this.选择.HeaderText = "选择";
            this.选择.Name = "选择";
            this.选择.TrueValue = "True";
            this.选择.Width = 40;
            this.CarStatu.DataPropertyName = "CarStatu";
            this.CarStatu.HeaderText = "CarStatu";
            this.CarStatu.Name = "CarStatu";
            this.CarStatu.ReadOnly = true;
            this.CarStatu.Visible = false;
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.chkCheckAll);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(321, 29);
            this.panel1.TabIndex = 1;
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new Point(4, 6);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new Size(48, 16);
            this.chkCheckAll.TabIndex = 1;
            this.chkCheckAll.Text = "全选";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new EventHandler(this.chkCheckAll_CheckedChanged);
            this.btnOk.Location = new Point(115, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.label8.AutoSize = true;
            this.label8.ForeColor = Color.Red;
            this.label8.Location = new Point(195, 8);
            this.label8.Name = "label8";
            this.label8.Size = new Size(125, 12);
            this.label8.TabIndex = 35;
            this.label8.Tag = "9999";
            this.label8.Text = "(注：重新连接后生效)";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.dgvList);
            base.Controls.Add(this.panel1);
            base.Name = "SetLogFilterAlarmType";
            base.Size = new Size(321, 273);
            base.Load += new EventHandler(this.SetLogFilterAlarmType_Load);
            ((ISupportInitialize) this.dgvList).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private Button btnOk;
        private DataGridViewTextBoxColumn CarStatu;
        private CheckBox chkCheckAll;
        private DataGridView dgvList;
        private Label label8;
        private Panel panel1;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn 报警类型;
        private DataGridViewCheckBoxColumn 选择;
    }
}