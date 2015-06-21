namespace Client
{
    partial class ShowPathForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            this.pnlOpt = new System.Windows.Forms.Panel();
            this.tsFilter = new System.Windows.Forms.ToolStrip();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbbGroupName = new System.Windows.Forms.ComboBox();
            this.tsFind = new System.Windows.Forms.ToolStrip();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTipRed = new System.Windows.Forms.Label();
            this.grpMain.SuspendLayout();
            this.pnlOpt.SuspendLayout();
            this.tsFilter.SuspendLayout();
            this.tsFind.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.clbItems);
            this.grpMain.Controls.Add(this.pnlOpt);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Margin = new System.Windows.Forms.Padding(0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(438, 506);
            this.grpMain.TabIndex = 2;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "选择预显示路线名称";
            // 
            // clbItems
            // 
            this.clbItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbItems.CheckOnClick = true;
            this.clbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbItems.FormattingEnabled = true;
            this.clbItems.Location = new System.Drawing.Point(3, 43);
            this.clbItems.Name = "clbItems";
            this.clbItems.Size = new System.Drawing.Size(432, 460);
            this.clbItems.TabIndex = 0;
            // 
            // pnlOpt
            // 
            this.pnlOpt.Controls.Add(this.tsFilter);
            this.pnlOpt.Controls.Add(this.txtFilter);
            this.pnlOpt.Controls.Add(this.lblFilter);
            this.pnlOpt.Controls.Add(this.cbbGroupName);
            this.pnlOpt.Controls.Add(this.tsFind);
            this.pnlOpt.Controls.Add(this.lblName);
            this.pnlOpt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOpt.Location = new System.Drawing.Point(3, 17);
            this.pnlOpt.Name = "pnlOpt";
            this.pnlOpt.Size = new System.Drawing.Size(432, 26);
            this.pnlOpt.TabIndex = 3;
            // 
            // tsFilter
            // 
            this.tsFilter.Dock = System.Windows.Forms.DockStyle.None;
            this.tsFilter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFilter});
            this.tsFilter.Location = new System.Drawing.Point(380, 1);
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Size = new System.Drawing.Size(57, 25);
            this.tsFilter.TabIndex = 9;
            this.tsFilter.Text = "toolStrip2";
            // 
            // tsbFilter
            // 
            this.tsbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFilter.Image = global::Client.Properties.Resources.find;
            this.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilter.Name = "tsbFilter";
            this.tsbFilter.Size = new System.Drawing.Size(23, 22);
            this.tsbFilter.Text = "路线过滤查找";
            this.tsbFilter.Click += new System.EventHandler(this.tsbFilter_Clicked);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(310, 3);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(67, 21);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.Tag = "9999";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(268, 7);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(41, 12);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "查找：";
            // 
            // cbbGroupName
            // 
            this.cbbGroupName.DisplayMember = "PathgroupName";
            this.cbbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGroupName.FormattingEnabled = true;
            this.cbbGroupName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbbGroupName.Location = new System.Drawing.Point(101, 3);
            this.cbbGroupName.Name = "cbbGroupName";
            this.cbbGroupName.Size = new System.Drawing.Size(106, 20);
            this.cbbGroupName.TabIndex = 3;
            this.cbbGroupName.Tag = "999";
            this.cbbGroupName.ValueMember = "PathgroupID";
            // 
            // tsFind
            // 
            this.tsFind.Dock = System.Windows.Forms.DockStyle.None;
            this.tsFind.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFind});
            this.tsFind.Location = new System.Drawing.Point(210, 1);
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(26, 25);
            this.tsFind.TabIndex = 2;
            this.tsFind.Text = "toolStrip1";
            // 
            // tsbFind
            // 
            this.tsbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFind.Image = global::Client.Properties.Resources.find;
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(23, 22);
            this.tsbFind.Text = "搜索 ";
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Clicked);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(5, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Tag = "999";
            this.lblName.Text = "路线分组名称：";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(346, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Clicked);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(265, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOk_Clicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pb1);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Location = new System.Drawing.Point(9, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 22);
            this.panel1.TabIndex = 14;
            this.panel1.Tag = "";
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.Transparent;
            this.pb1.InitialImage = null;
            this.pb1.Location = new System.Drawing.Point(3, 3);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(16, 16);
            this.pb1.TabIndex = 11;
            this.pb1.TabStop = false;
            this.pb1.Tag = "9999";
            this.pb1.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(22, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 12);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "正在执行中....";
            this.lblStatus.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTipRed);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 506);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 39);
            this.panel2.TabIndex = 15;
            // 
            // lblTipRed
            // 
            this.lblTipRed.AutoSize = true;
            this.lblTipRed.ForeColor = System.Drawing.Color.Red;
            this.lblTipRed.Location = new System.Drawing.Point(162, 13);
            this.lblTipRed.Name = "lblTipRed";
            this.lblTipRed.Size = new System.Drawing.Size(95, 12);
            this.lblTipRed.TabIndex = 15;
            this.lblTipRed.Tag = "9999";
            this.lblTipRed.Text = "*最多可显示30条";
            // 
            // ShowPathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 545);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.panel2);
            this.Name = "ShowPathForm";
            this.Text = "偏移路线显示控制";
            this.Load += new System.EventHandler(this.ShowPathForm_Load);
            this.grpMain.ResumeLayout(false);
            this.pnlOpt.ResumeLayout(false);
            this.pnlOpt.PerformLayout();
            this.tsFilter.ResumeLayout(false);
            this.tsFilter.PerformLayout();
            this.tsFind.ResumeLayout(false);
            this.tsFind.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

    }
}