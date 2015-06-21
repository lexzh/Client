namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class MapFlag
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MapFlag));
            this.pnlBtn = new Panel();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.grpPoint = new GroupBox();
            this.numLon = new NumericUpDown();
            this.numLat = new NumericUpDown();
            this.cmbArea = new ComBox();
            this.cmbFlagType = new ComBox();
            this.lblArea = new Label();
            this.lblLon = new Label();
            this.txtAddress = new TextBox();
            this.lblLat = new Label();
            this.lblAddress = new Label();
            this.lblFlagType = new Label();
            this.pnlBtn.SuspendLayout();
            this.grpPoint.SuspendLayout();
            this.numLon.BeginInit();
            this.numLat.BeginInit();
            base.SuspendLayout();
            this.pnlBtn.Controls.Add(this.btnCancel);
            this.pnlBtn.Controls.Add(this.btnOK);
            this.pnlBtn.Dock = DockStyle.Top;
            this.pnlBtn.Location = new Point(5, 171);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new Size(363, 28);
            this.pnlBtn.TabIndex = 1;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(288, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnOK.Location = new Point(203, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.grpPoint.Controls.Add(this.numLon);
            this.grpPoint.Controls.Add(this.numLat);
            this.grpPoint.Controls.Add(this.cmbArea);
            this.grpPoint.Controls.Add(this.cmbFlagType);
            this.grpPoint.Controls.Add(this.lblArea);
            this.grpPoint.Controls.Add(this.lblLon);
            this.grpPoint.Controls.Add(this.txtAddress);
            this.grpPoint.Controls.Add(this.lblLat);
            this.grpPoint.Controls.Add(this.lblAddress);
            this.grpPoint.Controls.Add(this.lblFlagType);
            this.grpPoint.Dock = DockStyle.Top;
            this.grpPoint.Location = new Point(5, 5);
            this.grpPoint.Name = "grpPoint";
            this.grpPoint.Size = new Size(363, 166);
            this.grpPoint.TabIndex = 0;
            this.grpPoint.TabStop = false;
            this.grpPoint.Text = "增加标注/兴趣点";
            this.numLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLon.DecimalPlaces = 5;
            int[] bits = new int[4];
            bits[0] = 1;
            bits[3] = 327680;
            this.numLon.Increment = new decimal(bits);
            this.numLon.Location = new Point(122, 76);
            int[] numArray2 = new int[4];
            numArray2[0] = 180;
            this.numLon.Maximum = new decimal(numArray2);
            int[] numArray3 = new int[4];
            numArray3[0] = 180;
            numArray3[3] = -2147483648;
            this.numLon.Minimum = new decimal(numArray3);
            this.numLon.Name = "numLon";
            this.numLon.Size = new Size(161, 21);
            this.numLon.TabIndex = 2;
            this.numLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLat.DecimalPlaces = 5;
            int[] numArray4 = new int[4];
            numArray4[0] = 1;
            numArray4[3] = 327680;
            this.numLat.Increment = new decimal(numArray4);
            this.numLat.Location = new Point(122, 104);
            int[] numArray5 = new int[4];
            numArray5[0] = 90;
            this.numLat.Maximum = new decimal(numArray5);
            int[] numArray6 = new int[4];
            numArray6[0] = 90;
            numArray6[3] = -2147483648;
            this.numLat.Minimum = new decimal(numArray6);
            this.numLat.Name = "numLat";
            this.numLat.Size = new Size(161, 21);
            this.numLat.TabIndex = 3;
            this.cmbArea.DisplayMember = "Display";
            this.cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbArea.FlatStyle = FlatStyle.Flat;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new Point(122, 131);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new Size(161, 20);
            this.cmbArea.TabIndex = 4;
            this.cmbArea.ValueMember = "Value";
            this.cmbFlagType.DisplayMember = "Display";
            this.cmbFlagType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFlagType.FlatStyle = FlatStyle.Flat;
            this.cmbFlagType.FormattingEnabled = true;
            this.cmbFlagType.Location = new Point(122, 20);
            this.cmbFlagType.Name = "cmbFlagType";
            this.cmbFlagType.Size = new Size(161, 20);
            this.cmbFlagType.TabIndex = 0;
            this.cmbFlagType.ValueMember = "Value";
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new Point(50, 134);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new Size(65, 12);
            this.lblArea.TabIndex = 8;
            this.lblArea.Text = "所属区域：";
            this.lblLon.AutoSize = true;
            this.lblLon.Location = new Point(74, 78);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new Size(41, 12);
            this.lblLon.TabIndex = 8;
            this.lblLon.Text = "经度：";
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new Point(122, 47);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new Size(161, 21);
            this.txtAddress.TabIndex = 1;
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new Point(74, 106);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new Size(41, 12);
            this.lblLat.TabIndex = 8;
            this.lblLat.Text = "纬度：";
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new Point(50, 50);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new Size(65, 12);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "地物名称：";
            this.lblFlagType.AutoSize = true;
            this.lblFlagType.Location = new Point(74, 23);
            this.lblFlagType.Name = "lblFlagType";
            this.lblFlagType.Size = new Size(41, 12);
            this.lblFlagType.TabIndex = 6;
            this.lblFlagType.Text = "类别：";
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(373, 204);
            base.Controls.Add(this.pnlBtn);
            base.Controls.Add(this.grpPoint);
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.Name = "MapFlag";
            base.Padding = new Padding(5);
            this.Text = "添加标注/兴趣点";
            base.Load += new EventHandler(this.MapFlag_Load);
            base.FormClosing += new FormClosingEventHandler(this.MapFlag_FormClosing);
            this.pnlBtn.ResumeLayout(false);
            this.grpPoint.ResumeLayout(false);
            this.grpPoint.PerformLayout();
            this.numLon.EndInit();
            this.numLat.EndInit();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private DataTable dtArea;
        private DataTable dtFlag;
        private GisMap m_CurrentMap;
        private NumericUpDown numLat;
        private NumericUpDown numLon;
    }
}