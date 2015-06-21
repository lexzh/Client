namespace Client
{
    partial class CarForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarForm));
            this.grpCar = new System.Windows.Forms.GroupBox();
            this.cmbType = new WinFormsUI.Controls.ComBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.AutoSize = true;
            this.grpCar.Controls.Add(this.cmbType);
            this.grpCar.Controls.Add(this.txtPassword);
            this.grpCar.Controls.Add(this.txtCarNo);
            this.grpCar.Controls.Add(this.lblPassword);
            this.grpCar.Controls.Add(this.lblValue);
            this.grpCar.Controls.Add(this.lblType);
            this.grpCar.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCar.Location = new System.Drawing.Point(5, 5);
            this.grpCar.Name = "grpCar";
            this.grpCar.Size = new System.Drawing.Size(363, 116);
            this.grpCar.TabIndex = 1;
            this.grpCar.TabStop = false;
            this.grpCar.Text = "目标车辆";
            // 
            // cmbType
            // 
            this.cmbType.DisplayMember = "Display";
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(122, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(161, 20);
            this.cmbType.TabIndex = 0;
            this.cmbType.ValueMember = "Value";
            this.cmbType.SelectedValueChanged += new System.EventHandler(this.comType_SelectedValueChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(122, 75);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(161, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // txtCarNo
            // 
            this.txtCarNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarNo.Location = new System.Drawing.Point(122, 47);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(161, 21);
            this.txtCarNo.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 78);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 12);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "用户密码：";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(50, 50);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(65, 12);
            this.lblValue.TabIndex = 7;
            this.lblValue.Text = "查询内容：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(50, 23);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(65, 12);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "查询方式：";
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.btnCancel);
            this.pnlBtn.Controls.Add(this.btnOK);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.Location = new System.Drawing.Point(5, 121);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new System.Drawing.Size(363, 28);
            this.pnlBtn.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(288, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(203, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CarForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(373, 154);
            this.Controls.Add(this.pnlBtn);
            this.Controls.Add(this.grpCar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CarForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "CarForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CarForm_FormClosing);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox grpCar;

        public WinFormsUI.Controls.ComBox cmbType;

        public System.Windows.Forms.TextBox txtPassword;

        public System.Windows.Forms.TextBox txtCarNo;

        public System.Windows.Forms.Label lblPassword;

        public System.Windows.Forms.Label lblValue;

        public System.Windows.Forms.Label lblType;

        public System.Windows.Forms.Panel pnlBtn;

        public System.Windows.Forms.Button btnCancel;

        public System.Windows.Forms.Button btnOK;
    }
}
