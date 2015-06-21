namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmStopReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(itmStopReport));
            this.grpStopParam = new System.Windows.Forms.GroupBox();
            this.pnlRemark = new System.Windows.Forms.Panel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.pnlListen = new System.Windows.Forms.Panel();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.lblMsgValue = new System.Windows.Forms.Label();
            this.cmbMsgType = new WinFormsUI.Controls.ComBox();
            this.txtMsgValue = new System.Windows.Forms.TextBox();
            this.lblMsgType = new System.Windows.Forms.Label();
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.lblCamera = new System.Windows.Forms.Label();
            this.chkCamera1 = new System.Windows.Forms.CheckBox();
            this.chkCamera2 = new System.Windows.Forms.CheckBox();
            this.chkCamera3 = new System.Windows.Forms.CheckBox();
            this.chkCamera4 = new System.Windows.Forms.CheckBox();
            this.chkCamera5 = new System.Windows.Forms.CheckBox();
            this.chkCamera6 = new System.Windows.Forms.CheckBox();
            this.chkCamera7 = new System.Windows.Forms.CheckBox();
            this.chkCamera8 = new System.Windows.Forms.CheckBox();
            this.pnlStopAlarm = new System.Windows.Forms.Panel();
            this.chkCoerceStop = new System.Windows.Forms.CheckBox();
            this.lblExplain = new System.Windows.Forms.Label();
            this.pnlAlarmResolveType = new System.Windows.Forms.Panel();
            this.cmbAlarmResolveType = new System.Windows.Forms.ComboBox();
            this.lblAlarmResolveType = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpStopParam.SuspendLayout();
            this.pnlRemark.SuspendLayout();
            this.pnlListen.SuspendLayout();
            this.pnlMsg.SuspendLayout();
            this.pnlCamera.SuspendLayout();
            this.pnlStopAlarm.SuspendLayout();
            this.pnlAlarmResolveType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.TabIndex = 0;
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(369, 116);
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 384);
            this.pnlBtn.Size = new System.Drawing.Size(369, 28);
            this.pnlBtn.TabIndex = 2;
            // 
            // grpStopParam
            // 
            this.grpStopParam.AutoSize = true;
            this.grpStopParam.Controls.Add(this.pnlRemark);
            this.grpStopParam.Controls.Add(this.pnlListen);
            this.grpStopParam.Controls.Add(this.pnlMsg);
            this.grpStopParam.Controls.Add(this.pnlCamera);
            this.grpStopParam.Controls.Add(this.pnlStopAlarm);
            this.grpStopParam.Controls.Add(this.pnlAlarmResolveType);
            this.grpStopParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStopParam.Location = new System.Drawing.Point(5, 121);
            this.grpStopParam.Name = "grpStopParam";
            this.grpStopParam.Size = new System.Drawing.Size(369, 263);
            this.grpStopParam.TabIndex = 1;
            this.grpStopParam.TabStop = false;
            this.grpStopParam.Text = "停止参数";
            this.grpStopParam.SizeChanged += new System.EventHandler(this.grpStopParam_SizeChanged);
            // 
            // pnlRemark
            // 
            this.pnlRemark.Controls.Add(this.lblRemark);
            this.pnlRemark.Controls.Add(this.txtRemark);
            this.pnlRemark.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRemark.Location = new System.Drawing.Point(3, 223);
            this.pnlRemark.Name = "pnlRemark";
            this.pnlRemark.Size = new System.Drawing.Size(363, 37);
            this.pnlRemark.TabIndex = 4;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(71, 6);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 17;
            this.lblRemark.Text = "备注：";
            // 
            // txtRemark
            // 
            this.txtRemark.AcceptsReturn = true;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(119, 4);
            this.txtRemark.MaxLength = 175;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtRemark.Size = new System.Drawing.Size(161, 29);
            this.txtRemark.TabIndex = 16;
            // 
            // pnlListen
            // 
            this.pnlListen.Controls.Add(this.txtTel);
            this.pnlListen.Controls.Add(this.label1);
            this.pnlListen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListen.Location = new System.Drawing.Point(3, 196);
            this.pnlListen.Name = "pnlListen";
            this.pnlListen.Size = new System.Drawing.Size(363, 27);
            this.pnlListen.TabIndex = 3;
            this.pnlListen.Visible = false;
            // 
            // txtTel
            // 
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTel.Location = new System.Drawing.Point(120, 2);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(160, 21);
            this.txtTel.TabIndex = 18;
            this.txtTel.Tag = "；";
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // lblVersion
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "监听号码：";
            // 
            // pnlMsg
            // 
            this.pnlMsg.Controls.Add(this.lblMsgValue);
            this.pnlMsg.Controls.Add(this.cmbMsgType);
            this.pnlMsg.Controls.Add(this.txtMsgValue);
            this.pnlMsg.Controls.Add(this.lblMsgType);
            this.pnlMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsg.Location = new System.Drawing.Point(3, 111);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Size = new System.Drawing.Size(363, 85);
            this.pnlMsg.TabIndex = 2;
            this.pnlMsg.Visible = false;
            // 
            // lblMsgValue
            // 
            this.lblMsgValue.AutoSize = true;
            this.lblMsgValue.Location = new System.Drawing.Point(48, 28);
            this.lblMsgValue.Name = "lblMsgValue";
            this.lblMsgValue.Size = new System.Drawing.Size(65, 12);
            this.lblMsgValue.TabIndex = 17;
            this.lblMsgValue.Text = "消息内容：";
            // 
            // cmbMsgType
            // 
            this.cmbMsgType.DisplayMember = "Display";
            this.cmbMsgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMsgType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMsgType.FormattingEnabled = true;
            this.cmbMsgType.Location = new System.Drawing.Point(119, 3);
            this.cmbMsgType.Name = "cmbMsgType";
            this.cmbMsgType.Size = new System.Drawing.Size(161, 20);
            this.cmbMsgType.TabIndex = 16;
            this.cmbMsgType.Tag = "；";
            this.cmbMsgType.ValueMember = "Value";
            // 
            // txtMsgValue
            // 
            this.txtMsgValue.AcceptsReturn = true;
            this.txtMsgValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMsgValue.Location = new System.Drawing.Point(119, 26);
            this.txtMsgValue.MaxLength = 175;
            this.txtMsgValue.Multiline = true;
            this.txtMsgValue.Name = "txtMsgValue";
            this.txtMsgValue.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtMsgValue.Size = new System.Drawing.Size(241, 55);
            this.txtMsgValue.TabIndex = 15;
            // 
            // lblMsgType
            // 
            this.lblMsgType.AutoSize = true;
            this.lblMsgType.Location = new System.Drawing.Point(47, 6);
            this.lblMsgType.Name = "lblMsgType";
            this.lblMsgType.Size = new System.Drawing.Size(65, 12);
            this.lblMsgType.TabIndex = 13;
            this.lblMsgType.Text = "消息类型：";
            // 
            // pnlCamera
            // 
            this.pnlCamera.Controls.Add(this.lblCamera);
            this.pnlCamera.Controls.Add(this.chkCamera1);
            this.pnlCamera.Controls.Add(this.chkCamera2);
            this.pnlCamera.Controls.Add(this.chkCamera3);
            this.pnlCamera.Controls.Add(this.chkCamera4);
            this.pnlCamera.Controls.Add(this.chkCamera5);
            this.pnlCamera.Controls.Add(this.chkCamera6);
            this.pnlCamera.Controls.Add(this.chkCamera7);
            this.pnlCamera.Controls.Add(this.chkCamera8);
            this.pnlCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCamera.Location = new System.Drawing.Point(3, 68);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Size = new System.Drawing.Size(363, 43);
            this.pnlCamera.TabIndex = 1;
            this.pnlCamera.Visible = false;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Location = new System.Drawing.Point(35, 7);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(77, 12);
            this.lblCamera.TabIndex = 16;
            this.lblCamera.Text = "摄像头选择：";
            // 
            // chkCamera1
            // 
            this.chkCamera1.AutoSize = true;
            this.chkCamera1.Location = new System.Drawing.Point(120, 3);
            this.chkCamera1.Name = "chkCamera1";
            this.chkCamera1.Size = new System.Drawing.Size(42, 16);
            this.chkCamera1.TabIndex = 0;
            this.chkCamera1.Text = "1号";
            this.chkCamera1.UseVisualStyleBackColor = true;
            // 
            // chkCamera2
            // 
            this.chkCamera2.AutoSize = true;
            this.chkCamera2.Location = new System.Drawing.Point(165, 3);
            this.chkCamera2.Name = "chkCamera2";
            this.chkCamera2.Size = new System.Drawing.Size(42, 16);
            this.chkCamera2.TabIndex = 1;
            this.chkCamera2.Text = "2号";
            this.chkCamera2.UseVisualStyleBackColor = true;
            // 
            // chkCamera3
            // 
            this.chkCamera3.AutoSize = true;
            this.chkCamera3.Location = new System.Drawing.Point(210, 3);
            this.chkCamera3.Name = "chkCamera3";
            this.chkCamera3.Size = new System.Drawing.Size(42, 16);
            this.chkCamera3.TabIndex = 2;
            this.chkCamera3.Text = "3号";
            this.chkCamera3.UseVisualStyleBackColor = true;
            // 
            // chkCamera4
            // 
            this.chkCamera4.AutoSize = true;
            this.chkCamera4.Location = new System.Drawing.Point(255, 3);
            this.chkCamera4.Name = "chkCamera4";
            this.chkCamera4.Size = new System.Drawing.Size(42, 16);
            this.chkCamera4.TabIndex = 3;
            this.chkCamera4.Text = "4号";
            this.chkCamera4.UseVisualStyleBackColor = true;
            // 
            // chkCamera5
            // 
            this.chkCamera5.AutoSize = true;
            this.chkCamera5.Location = new System.Drawing.Point(120, 23);
            this.chkCamera5.Name = "chkCamera5";
            this.chkCamera5.Size = new System.Drawing.Size(42, 16);
            this.chkCamera5.TabIndex = 4;
            this.chkCamera5.Text = "5号";
            this.chkCamera5.UseVisualStyleBackColor = true;
            // 
            // chkCamera6
            // 
            this.chkCamera6.AutoSize = true;
            this.chkCamera6.Location = new System.Drawing.Point(165, 23);
            this.chkCamera6.Name = "chkCamera6";
            this.chkCamera6.Size = new System.Drawing.Size(42, 16);
            this.chkCamera6.TabIndex = 5;
            this.chkCamera6.Text = "6号";
            this.chkCamera6.UseVisualStyleBackColor = true;
            // 
            // chkCamera7
            // 
            this.chkCamera7.AutoSize = true;
            this.chkCamera7.Location = new System.Drawing.Point(210, 23);
            this.chkCamera7.Name = "chkCamera7";
            this.chkCamera7.Size = new System.Drawing.Size(42, 16);
            this.chkCamera7.TabIndex = 6;
            this.chkCamera7.Text = "7号";
            this.chkCamera7.UseVisualStyleBackColor = true;
            // 
            // chkCamera8
            // 
            this.chkCamera8.AutoSize = true;
            this.chkCamera8.Location = new System.Drawing.Point(255, 23);
            this.chkCamera8.Name = "chkCamera8";
            this.chkCamera8.Size = new System.Drawing.Size(42, 16);
            this.chkCamera8.TabIndex = 7;
            this.chkCamera8.Text = "8号";
            this.chkCamera8.UseVisualStyleBackColor = true;
            // 
            // pnlStopAlarm
            // 
            this.pnlStopAlarm.Controls.Add(this.chkCoerceStop);
            this.pnlStopAlarm.Controls.Add(this.lblExplain);
            this.pnlStopAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStopAlarm.Location = new System.Drawing.Point(3, 45);
            this.pnlStopAlarm.Name = "pnlStopAlarm";
            this.pnlStopAlarm.Size = new System.Drawing.Size(363, 23);
            this.pnlStopAlarm.TabIndex = 2;
            // 
            // chkCoerceStop
            // 
            this.chkCoerceStop.AutoSize = true;
            this.chkCoerceStop.Location = new System.Drawing.Point(119, 3);
            this.chkCoerceStop.Name = "chkCoerceStop";
            this.chkCoerceStop.Size = new System.Drawing.Size(72, 16);
            this.chkCoerceStop.TabIndex = 0;
            this.chkCoerceStop.Text = "强制停止";
            this.chkCoerceStop.UseVisualStyleBackColor = true;
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.ForeColor = System.Drawing.Color.Red;
            this.lblExplain.Location = new System.Drawing.Point(198, 4);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(119, 12);
            this.lblExplain.TabIndex = 1;
            this.lblExplain.Tag = "9999";
            this.lblExplain.Text = "*会造成历史数据丢失";
            // 
            // pnlAlarmResolveType
            // 
            this.pnlAlarmResolveType.Controls.Add(this.cmbAlarmResolveType);
            this.pnlAlarmResolveType.Controls.Add(this.lblAlarmResolveType);
            this.pnlAlarmResolveType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlarmResolveType.Location = new System.Drawing.Point(3, 17);
            this.pnlAlarmResolveType.Name = "pnlAlarmResolveType";
            this.pnlAlarmResolveType.Size = new System.Drawing.Size(363, 28);
            this.pnlAlarmResolveType.TabIndex = 0;
            // 
            // cmbAlarmResolveType
            // 
            this.cmbAlarmResolveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlarmResolveType.FormattingEnabled = true;
            this.cmbAlarmResolveType.Items.AddRange(new object[] {
            "报警解除",
            "车辆监听",
            "拍照",
            "下发消息",
            "不做处理",
            "将来处理"});
            this.cmbAlarmResolveType.Location = new System.Drawing.Point(119, 3);
            this.cmbAlarmResolveType.Name = "cmbAlarmResolveType";
            this.cmbAlarmResolveType.Size = new System.Drawing.Size(161, 20);
            this.cmbAlarmResolveType.TabIndex = 1;
            this.cmbAlarmResolveType.SelectedIndexChanged += new System.EventHandler(this.cmbAlarmResolveType_SelectedIndexChanged);
            // 
            // lblAlarmResolveType
            // 
            this.lblAlarmResolveType.AutoSize = true;
            this.lblAlarmResolveType.Location = new System.Drawing.Point(47, 7);
            this.lblAlarmResolveType.Name = "lblAlarmResolveType";
            this.lblAlarmResolveType.Size = new System.Drawing.Size(65, 12);
            this.lblAlarmResolveType.TabIndex = 0;
            this.lblAlarmResolveType.Text = "处理方式：";
            // 
            // itmStopReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(379, 417);
            this.Controls.Add(this.grpStopParam);
            this.Name = "itmStopReport";
            this.Text = "位置查询";
            this.Load += new System.EventHandler(this.itmStopReport_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpStopParam, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpStopParam.ResumeLayout(false);
            this.pnlRemark.ResumeLayout(false);
            this.pnlRemark.PerformLayout();
            this.pnlListen.ResumeLayout(false);
            this.pnlListen.PerformLayout();
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.pnlCamera.ResumeLayout(false);
            this.pnlCamera.PerformLayout();
            this.pnlStopAlarm.ResumeLayout(false);
            this.pnlStopAlarm.PerformLayout();
            this.pnlAlarmResolveType.ResumeLayout(false);
            this.pnlAlarmResolveType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private string _toPlatformContent;
        private CheckBox chkCamera1;
        private CheckBox chkCamera2;
        private CheckBox chkCamera3;
        private CheckBox chkCamera4;
        private CheckBox chkCamera5;
        private CheckBox chkCamera6;
        private CheckBox chkCamera7;
        private CheckBox chkCamera8;
        private CheckBox chkCoerceStop;
        private ComboBox cmbAlarmResolveType;
        private ComBox cmbMsgType;
        private GroupBox grpStopParam;
        private Label label1;
        private Label lblAlarmResolveType;
        private Label lblCamera;
        private Label lblExplain;
        private Label lblMsgType;
        private Label lblMsgValue;
        private Label lblRemark;
        private TrafficALarmHandle m_AlarmInfo;
        private CaptureEx m_CaptureEx;
        private ArrayList m_cmd;
        private SimpleCmd m_SimpleCmd;
        private SimpleCmd m_SimpleCmd_Listen;
        private TxtMsg m_TxtMsg;
        private int platalarmType;
        private Panel pnlAlarmResolveType;
        private Panel pnlCamera;
        private Panel pnlListen;
        private Panel pnlMsg;
        private Panel pnlRemark;
        private Panel pnlStopAlarm;
        private TextBox txtMsgValue;
        private TextBox txtRemark;
        private TextBox txtTel;
    }
}