namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmSetOilRefValue
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
            this.grpOilReference = new GroupBox();
            this.dgvOilReference = new DataGridView();
            this.ParamValue = new DataGridViewTextBoxColumn();
            this.Value = new DataGridViewTextBoxColumn();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpOilReference.SuspendLayout();
            ((ISupportInitialize) this.dgvOilReference).BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 276);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpOilReference.Controls.Add(this.dgvOilReference);
            this.grpOilReference.Dock = DockStyle.Top;
            this.grpOilReference.Location = new System.Drawing.Point(5, 121);
            this.grpOilReference.Name = "grpOilReference";
            this.grpOilReference.Size = new Size(363, 155);
            this.grpOilReference.TabIndex = 1;
            this.grpOilReference.TabStop = false;
            this.grpOilReference.Text = "油量检测参考值";
            this.dgvOilReference.AllowUserToAddRows = false;
            this.dgvOilReference.AllowUserToResizeRows = false;
            this.dgvOilReference.BackgroundColor = SystemColors.ControlLightLight;
            this.dgvOilReference.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOilReference.Columns.AddRange(new DataGridViewColumn[] { this.ParamValue, this.Value });
            this.dgvOilReference.Dock = DockStyle.Fill;
            this.dgvOilReference.Location = new System.Drawing.Point(3, 17);
            this.dgvOilReference.Name = "dgvOilReference";
            this.dgvOilReference.ReadOnly = true;
            this.dgvOilReference.RowHeadersVisible = false;
            this.dgvOilReference.RowTemplate.Height = 20;
            this.dgvOilReference.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvOilReference.Size = new Size(357, 135);
            this.dgvOilReference.TabIndex = 0;
            this.ParamValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            style.BackColor = Color.FromArgb(192, 192, 255);
            this.ParamValue.DefaultCellStyle = style;
            this.ParamValue.Frozen = true;
            this.ParamValue.HeaderText = "参数值";
            this.ParamValue.MinimumWidth = 188;
            this.ParamValue.Name = "ParamValue";
            this.ParamValue.ReadOnly = true;
            this.ParamValue.Width = 188;
            this.Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Value.HeaderText = "值";
            this.Value.MinimumWidth = 150;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Resizable = DataGridViewTriState.False;
            this.Value.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Value.Width = 150;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(373, 309);
            base.Controls.Add(this.grpOilReference);
            base.Name = "itmSetOilRefValue";
            this.Text = "SetOilReference";
            base.Load += new EventHandler(this.itmSetOilRefValue_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpOilReference, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpOilReference.ResumeLayout(false);
            ((ISupportInitialize) this.dgvOilReference).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private DataGridView dgvOilReference;
        private GroupBox grpOilReference;
        private DataGridViewTextBoxColumn ParamValue;
        private DataGridViewTextBoxColumn Value;
    }
}