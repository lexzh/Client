namespace Client
{
    partial class itmSendTextMess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(itmSendTextMess));
            this.grpMsg = new System.Windows.Forms.GroupBox();
            this.lblMsgType = new System.Windows.Forms.Label();
            this.cmbMsgType = new WinFormsUI.Controls.ComBox();
            this.btnHistorySearch = new System.Windows.Forms.Button();
            this.lblExplain1 = new System.Windows.Forms.Label();
            this.lblSendText = new System.Windows.Forms.Label();
            this.txtMsgValue = new System.Windows.Forms.TextBox();
            this.chkOverspeed = new System.Windows.Forms.CheckBox();
            this.chkPointToPoint = new System.Windows.Forms.CheckBox();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 325);
            // 
            // grpMsg
            // 
            this.grpMsg.Controls.Add(this.lblMsgType);
            this.grpMsg.Controls.Add(this.cmbMsgType);
            this.grpMsg.Controls.Add(this.btnHistorySearch);
            this.grpMsg.Controls.Add(this.lblExplain1);
            this.grpMsg.Controls.Add(this.lblSendText);
            this.grpMsg.Controls.Add(this.txtMsgValue);
            this.grpMsg.Controls.Add(this.chkOverspeed);
            this.grpMsg.Controls.Add(this.chkPointToPoint);
            this.grpMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMsg.Location = new System.Drawing.Point(5, 121);
            this.grpMsg.Name = "grpMsg";
            this.grpMsg.Size = new System.Drawing.Size(363, 204);
            this.grpMsg.TabIndex = 11;
            this.grpMsg.TabStop = false;
            this.grpMsg.Text = "发送内容";
            // 
            // lblMsgType
            // 
            this.lblMsgType.AutoSize = true;
            this.lblMsgType.Location = new System.Drawing.Point(50, 24);
            this.lblMsgType.Name = "lblMsgType";
            this.lblMsgType.Size = new System.Drawing.Size(65, 12);
            this.lblMsgType.TabIndex = 12;
            this.lblMsgType.Text = "短信类型：";
            // 
            // cmbMsgType
            // 
            this.cmbMsgType.DisplayMember = "Display";
            this.cmbMsgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMsgType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMsgType.FormattingEnabled = true;
            this.cmbMsgType.Location = new System.Drawing.Point(122, 20);
            this.cmbMsgType.Name = "cmbMsgType";
            this.cmbMsgType.Size = new System.Drawing.Size(161, 20);
            this.cmbMsgType.TabIndex = 11;
            this.cmbMsgType.Tag = "；";
            this.cmbMsgType.ValueMember = "Value";
            // 
            // btnHistorySearch
            // 
            this.btnHistorySearch.Location = new System.Drawing.Point(122, 147);
            this.btnHistorySearch.Name = "btnHistorySearch";
            this.btnHistorySearch.Size = new System.Drawing.Size(101, 23);
            this.btnHistorySearch.TabIndex = 1;
            this.btnHistorySearch.Text = "发送历史查询";
            this.btnHistorySearch.UseVisualStyleBackColor = true;
            this.btnHistorySearch.Click += new System.EventHandler(this.btnHistorySearch_Click);
            // 
            // lblExplain1
            // 
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(10, 176);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new System.Drawing.Size(173, 12);
            this.lblExplain1.TabIndex = 1;
            this.lblExplain1.Tag = "9999";
            this.lblExplain1.Text = "*(最多可发送175个汉字和字符)";
            // 
            // lblSendText
            // 
            this.lblSendText.AutoSize = true;
            this.lblSendText.Location = new System.Drawing.Point(61, 176);
            this.lblSendText.Name = "lblSendText";
            this.lblSendText.Size = new System.Drawing.Size(65, 12);
            this.lblSendText.TabIndex = 4;
            this.lblSendText.Tag = "";
            this.lblSendText.Text = "发送内容：";
            // 
            // txtMsgValue
            // 
            this.txtMsgValue.AcceptsReturn = true;
            this.txtMsgValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMsgValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMsgValue.Location = new System.Drawing.Point(12, 46);
            this.txtMsgValue.MaxLength = 175;
            this.txtMsgValue.Multiline = true;
            this.txtMsgValue.Name = "txtMsgValue";
            this.txtMsgValue.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtMsgValue.Size = new System.Drawing.Size(340, 95);
            this.txtMsgValue.TabIndex = 0;
            // 
            // chkOverspeed
            // 
            this.chkOverspeed.AutoSize = true;
            this.chkOverspeed.Location = new System.Drawing.Point(244, 177);
            this.chkOverspeed.Name = "chkOverspeed";
            this.chkOverspeed.Size = new System.Drawing.Size(108, 16);
            this.chkOverspeed.TabIndex = 2;
            this.chkOverspeed.Text = "自定义超速报警";
            this.chkOverspeed.UseVisualStyleBackColor = true;
            this.chkOverspeed.Visible = false;
            // 
            // chkPointToPoint
            // 
            this.chkPointToPoint.AutoSize = true;
            this.chkPointToPoint.Location = new System.Drawing.Point(189, 177);
            this.chkPointToPoint.Name = "chkPointToPoint";
            this.chkPointToPoint.Size = new System.Drawing.Size(48, 16);
            this.chkPointToPoint.TabIndex = 3;
            this.chkPointToPoint.Text = "电召";
            this.chkPointToPoint.UseVisualStyleBackColor = true;
            this.chkPointToPoint.Visible = false;
            // 
            // itmSendTextMess1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 359);
            this.Controls.Add(this.grpMsg);
            this.Name = "itmSendTextMess1";
            this.Text = "itmSendTextMess1";
            this.Load += new System.EventHandler(this.itmSendTextMess1_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpMsg, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpMsg.ResumeLayout(false);
            this.grpMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMsg;
        private System.Windows.Forms.Label lblMsgType;
        private WinFormsUI.Controls.ComBox cmbMsgType;
        private System.Windows.Forms.Button btnHistorySearch;
        private System.Windows.Forms.Label lblExplain1;
        private System.Windows.Forms.Label lblSendText;
        private System.Windows.Forms.TextBox txtMsgValue;
        private System.Windows.Forms.CheckBox chkOverspeed;
        private System.Windows.Forms.CheckBox chkPointToPoint;


    }
}