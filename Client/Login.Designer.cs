namespace Client
{
    partial class Login
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
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnSetParam = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLoginVersion = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblWaitText = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbPicWait = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblCenter = new System.Windows.Forms.Label();
            this.txtValidateCode = new System.Windows.Forms.TextBox();
            this.txtCenter = new System.Windows.Forms.TextBox();
            this.lblAdc = new System.Windows.Forms.Label();
            this.lblValidateCodeRemark = new System.Windows.Forms.Label();
            this.txtAdc = new System.Windows.Forms.TextBox();
            this.lblValidateCode = new System.Windows.Forms.Label();
            this.btnSendValidateCode = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginTitle.Location = new System.Drawing.Point(53, 12);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(264, 16);
            this.lblLoginTitle.TabIndex = 1;
            this.lblLoginTitle.Text = "星辰北斗兼容智能位置服务运营平台";
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtUser.Location = new System.Drawing.Point(458, 171);
            this.txtUser.MaxLength = 100;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(116, 21);
            this.txtUser.TabIndex = 2;
            // 
            // btnSetParam
            // 
            this.btnSetParam.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetParam.Location = new System.Drawing.Point(303, 275);
            this.btnSetParam.Name = "btnSetParam";
            this.btnSetParam.Size = new System.Drawing.Size(75, 23);
            this.btnSetParam.TabIndex = 6;
            this.btnSetParam.Text = "设置(&P)";
            this.btnSetParam.UseVisualStyleBackColor = true;
            this.btnSetParam.Click += new System.EventHandler(this.btnSetParam_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Location = new System.Drawing.Point(487, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(382, 204);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 12);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "用户密码：";
            // 
            // lblLoginVersion
            // 
            this.lblLoginVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginVersion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginVersion.Location = new System.Drawing.Point(480, 12);
            this.lblLoginVersion.Name = "lblLoginVersion";
            this.lblLoginVersion.Size = new System.Drawing.Size(161, 16);
            this.lblLoginVersion.TabIndex = 3;
            this.lblLoginVersion.Text = "V1.2";
            this.lblLoginVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPassword.Location = new System.Drawing.Point(458, 200);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(116, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // lblWaitText
            // 
            this.lblWaitText.AutoSize = true;
            this.lblWaitText.BackColor = System.Drawing.Color.Transparent;
            this.lblWaitText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWaitText.Location = new System.Drawing.Point(52, 325);
            this.lblWaitText.Name = "lblWaitText";
            this.lblWaitText.Size = new System.Drawing.Size(119, 12);
            this.lblWaitText.TabIndex = 9;
            this.lblWaitText.Text = "正在登录，请稍候...";
            this.lblWaitText.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(565, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbPicWait
            // 
            this.pbPicWait.BackColor = System.Drawing.Color.Transparent;
            this.pbPicWait.Image = global::Client.Properties.Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new System.Drawing.Point(29, 323);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new System.Drawing.Size(16, 16);
            this.pbPicWait.TabIndex = 10;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.pbPicWait.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Location = new System.Drawing.Point(382, 175);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(65, 12);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "用 户 名：";
            // 
            // lblCenter
            // 
            this.lblCenter.AutoSize = true;
            this.lblCenter.BackColor = System.Drawing.Color.Transparent;
            this.lblCenter.Location = new System.Drawing.Point(382, 117);
            this.lblCenter.Name = "lblCenter";
            this.lblCenter.Size = new System.Drawing.Size(65, 12);
            this.lblCenter.TabIndex = 6;
            this.lblCenter.Text = "监控中心：";
            // 
            // txtValidateCode
            // 
            this.txtValidateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidateCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtValidateCode.Location = new System.Drawing.Point(458, 229);
            this.txtValidateCode.MaxLength = 6;
            this.txtValidateCode.Name = "txtValidateCode";
            this.txtValidateCode.Size = new System.Drawing.Size(116, 21);
            this.txtValidateCode.TabIndex = 5;
            this.txtValidateCode.Visible = false;
            // 
            // txtCenter
            // 
            this.txtCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCenter.Location = new System.Drawing.Point(458, 113);
            this.txtCenter.Name = "txtCenter";
            this.txtCenter.ReadOnly = true;
            this.txtCenter.Size = new System.Drawing.Size(116, 21);
            this.txtCenter.TabIndex = 0;
            this.txtCenter.TabStop = false;
            // 
            // lblAdc
            // 
            this.lblAdc.AutoSize = true;
            this.lblAdc.BackColor = System.Drawing.Color.Transparent;
            this.lblAdc.Location = new System.Drawing.Point(382, 146);
            this.lblAdc.Name = "lblAdc";
            this.lblAdc.Size = new System.Drawing.Size(65, 12);
            this.lblAdc.TabIndex = 6;
            this.lblAdc.Text = "集团编号：";
            // 
            // lblValidateCodeRemark
            // 
            this.lblValidateCodeRemark.AutoSize = true;
            this.lblValidateCodeRemark.BackColor = System.Drawing.Color.Transparent;
            this.lblValidateCodeRemark.ForeColor = System.Drawing.Color.Red;
            this.lblValidateCodeRemark.Location = new System.Drawing.Point(580, 233);
            this.lblValidateCodeRemark.Name = "lblValidateCodeRemark";
            this.lblValidateCodeRemark.Size = new System.Drawing.Size(83, 12);
            this.lblValidateCodeRemark.TabIndex = 8;
            this.lblValidateCodeRemark.Tag = "9999";
            this.lblValidateCodeRemark.Text = "(5分钟内有效)";
            this.lblValidateCodeRemark.Visible = false;
            // 
            // txtAdc
            // 
            this.txtAdc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAdc.Location = new System.Drawing.Point(458, 142);
            this.txtAdc.MaxLength = 100;
            this.txtAdc.Name = "txtAdc";
            this.txtAdc.Size = new System.Drawing.Size(116, 21);
            this.txtAdc.TabIndex = 1;
            // 
            // lblValidateCode
            // 
            this.lblValidateCode.AutoSize = true;
            this.lblValidateCode.BackColor = System.Drawing.Color.Transparent;
            this.lblValidateCode.Location = new System.Drawing.Point(382, 233);
            this.lblValidateCode.Name = "lblValidateCode";
            this.lblValidateCode.Size = new System.Drawing.Size(65, 12);
            this.lblValidateCode.TabIndex = 8;
            this.lblValidateCode.Text = "验 证 码：";
            this.lblValidateCode.Visible = false;
            // 
            // btnSendValidateCode
            // 
            this.btnSendValidateCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnSendValidateCode.Location = new System.Drawing.Point(577, 199);
            this.btnSendValidateCode.Name = "btnSendValidateCode";
            this.btnSendValidateCode.Size = new System.Drawing.Size(75, 23);
            this.btnSendValidateCode.TabIndex = 4;
            this.btnSendValidateCode.Text = "发送验证码";
            this.btnSendValidateCode.UseVisualStyleBackColor = true;
            this.btnSendValidateCode.Visible = false;
            this.btnSendValidateCode.Click += new System.EventHandler(this.btnSendValidateCode_Click);
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.BackColor = System.Drawing.SystemColors.Control;
            this.btnChangePwd.Location = new System.Drawing.Point(384, 275);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(83, 23);
            this.btnChangePwd.TabIndex = 11;
            this.btnChangePwd.Text = "修改密码(&C)";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Visible = false;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackgroundImage = global::Client.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.lblLoginTitle);
            this.Controls.Add(this.btnSendValidateCode);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblValidateCode);
            this.Controls.Add(this.btnSetParam);
            this.Controls.Add(this.txtAdc);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblValidateCodeRemark);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblAdc);
            this.Controls.Add(this.lblLoginVersion);
            this.Controls.Add(this.txtCenter);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtValidateCode);
            this.Controls.Add(this.lblWaitText);
            this.Controls.Add(this.lblCenter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pbPicWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnSetParam;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLoginVersion;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblWaitText;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbPicWait;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblCenter;
        private System.Windows.Forms.TextBox txtValidateCode;
        private System.Windows.Forms.TextBox txtCenter;
        private System.Windows.Forms.Label lblAdc;
        private System.Windows.Forms.Label lblValidateCodeRemark;
        private System.Windows.Forms.TextBox txtAdc;
        private System.Windows.Forms.Label lblValidateCode;
        private System.Windows.Forms.Button btnSendValidateCode;
        private System.Windows.Forms.Button btnChangePwd;
    }
}
