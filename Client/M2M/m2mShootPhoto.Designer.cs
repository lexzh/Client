namespace Client.M2M
{
    partial class m2mShootPhoto
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
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.lblCamera = new System.Windows.Forms.Label();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkCamera1 = new System.Windows.Forms.CheckBox();
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.lblPhotoId = new System.Windows.Forms.Label();
            this.numPhotoId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlPhotoParam = new System.Windows.Forms.Panel();
            this.lblQualityValue = new System.Windows.Forms.Label();
            this.lblModol = new System.Windows.Forms.Label();
            this.grpModle = new System.Windows.Forms.GroupBox();
            this.rdoPromptly = new System.Windows.Forms.RadioButton();
            this.rdoSave = new System.Windows.Forms.RadioButton();
            this.rdoSequence = new System.Windows.Forms.RadioButton();
            this.rdoCondition = new System.Windows.Forms.RadioButton();
            this.lblQuality = new System.Windows.Forms.Label();
            this.trkQuality = new System.Windows.Forms.TrackBar();
            this.lblQualityExplain = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.chkAcc = new System.Windows.Forms.CheckBox();
            this.chkDacoity = new System.Windows.Forms.CheckBox();
            this.chkOverTime = new System.Windows.Forms.CheckBox();
            this.chkAreaIn = new System.Windows.Forms.CheckBox();
            this.chkAreaOut = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.pnlWait = new System.Windows.Forms.Panel();
            this.pbPicWait = new System.Windows.Forms.PictureBox();
            this.lblWaitText = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.pnlCamera.SuspendLayout();
            this.grpCamera.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhotoId)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlPhotoParam.SuspendLayout();
            this.grpModle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.grpCondition.SuspendLayout();
            this.pnlWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(377, 116);
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.pnlWait);
            this.pnlBtn.Location = new System.Drawing.Point(5, 470);
            this.pnlBtn.Size = new System.Drawing.Size(377, 28);
            this.pnlBtn.TabIndex = 2;
            this.pnlBtn.Controls.SetChildIndex(this.btnOK, 0);
            this.pnlBtn.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlBtn.Controls.SetChildIndex(this.pnlWait, 0);
            // 
            // pnlCamera
            // 
            this.pnlCamera.Controls.Add(this.lblCamera);
            this.pnlCamera.Controls.Add(this.grpCamera);
            this.pnlCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCamera.Location = new System.Drawing.Point(3, 17);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Size = new System.Drawing.Size(371, 59);
            this.pnlCamera.TabIndex = 0;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Location = new System.Drawing.Point(35, 12);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(77, 12);
            this.lblCamera.TabIndex = 0;
            this.lblCamera.Text = "摄像头选择：";
            // 
            // grpCamera
            // 
            this.grpCamera.Controls.Add(this.checkBox9);
            this.grpCamera.Controls.Add(this.checkBox8);
            this.grpCamera.Controls.Add(this.checkBox5);
            this.grpCamera.Controls.Add(this.checkBox4);
            this.grpCamera.Controls.Add(this.checkBox3);
            this.grpCamera.Controls.Add(this.checkBox2);
            this.grpCamera.Controls.Add(this.checkBox1);
            this.grpCamera.Controls.Add(this.chkCamera1);
            this.grpCamera.Location = new System.Drawing.Point(119, 0);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Size = new System.Drawing.Size(189, 56);
            this.grpCamera.TabIndex = 1;
            this.grpCamera.TabStop = false;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(145, 36);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(42, 16);
            this.checkBox9.TabIndex = 7;
            this.checkBox9.Tag = "8";
            this.checkBox9.Text = "8号";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(100, 36);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(42, 16);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.Tag = "7";
            this.checkBox8.Text = "7号";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(55, 36);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(42, 16);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Tag = "6";
            this.checkBox5.Text = "6号";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(10, 36);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(42, 16);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Tag = "5";
            this.checkBox4.Text = "5号";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(145, 14);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(42, 16);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Tag = "4";
            this.checkBox3.Text = "4号";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(100, 14);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(42, 16);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Tag = "3";
            this.checkBox2.Text = "3号";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(55, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Tag = "2";
            this.checkBox1.Text = "2号";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkCamera1
            // 
            this.chkCamera1.AutoSize = true;
            this.chkCamera1.Checked = true;
            this.chkCamera1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCamera1.Location = new System.Drawing.Point(10, 14);
            this.chkCamera1.Name = "chkCamera1";
            this.chkCamera1.Size = new System.Drawing.Size(42, 16);
            this.chkCamera1.TabIndex = 0;
            this.chkCamera1.Tag = "1";
            this.chkCamera1.Text = "1号";
            this.chkCamera1.UseVisualStyleBackColor = true;
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.Controls.Add(this.lblPhotoId);
            this.pnlPhoto.Controls.Add(this.numPhotoId);
            this.pnlPhoto.Controls.Add(this.label1);
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPhoto.Location = new System.Drawing.Point(3, 76);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Size = new System.Drawing.Size(371, 53);
            this.pnlPhoto.TabIndex = 1;
            this.pnlPhoto.Visible = false;
            // 
            // lblPhotoId
            // 
            this.lblPhotoId.AutoSize = true;
            this.lblPhotoId.Location = new System.Drawing.Point(59, 13);
            this.lblPhotoId.Name = "lblPhotoId";
            this.lblPhotoId.Size = new System.Drawing.Size(53, 12);
            this.lblPhotoId.TabIndex = 0;
            this.lblPhotoId.Text = "图像ID：";
            // 
            // numPhotoId
            // 
            this.numPhotoId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPhotoId.Location = new System.Drawing.Point(119, 9);
            this.numPhotoId.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numPhotoId.Name = "numPhotoId";
            this.numPhotoId.Size = new System.Drawing.Size(161, 21);
            this.numPhotoId.TabIndex = 0;
            this.numPhotoId.Tag = "；";
            this.numPhotoId.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 0;
            this.label1.Tag = "9999";
            this.label1.Text = "注：ID为 255 时上传整张图片";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.pnlCamera);
            this.groupBox1.Controls.Add(this.pnlPhoto);
            this.groupBox1.Controls.Add(this.pnlPhotoParam);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 349);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // pnlPhotoParam
            // 
            this.pnlPhotoParam.Controls.Add(this.lblQualityValue);
            this.pnlPhotoParam.Controls.Add(this.lblModol);
            this.pnlPhotoParam.Controls.Add(this.grpModle);
            this.pnlPhotoParam.Controls.Add(this.lblQuality);
            this.pnlPhotoParam.Controls.Add(this.trkQuality);
            this.pnlPhotoParam.Controls.Add(this.lblQualityExplain);
            this.pnlPhotoParam.Controls.Add(this.lblInterval);
            this.pnlPhotoParam.Controls.Add(this.numInterval);
            this.pnlPhotoParam.Controls.Add(this.lblSecond);
            this.pnlPhotoParam.Controls.Add(this.lblCondition);
            this.pnlPhotoParam.Controls.Add(this.grpCondition);
            this.pnlPhotoParam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPhotoParam.Location = new System.Drawing.Point(3, 129);
            this.pnlPhotoParam.Name = "pnlPhotoParam";
            this.pnlPhotoParam.Size = new System.Drawing.Size(371, 217);
            this.pnlPhotoParam.TabIndex = 2;
            // 
            // lblQualityValue
            // 
            this.lblQualityValue.AutoSize = true;
            this.lblQualityValue.Location = new System.Drawing.Point(257, 67);
            this.lblQualityValue.Name = "lblQualityValue";
            this.lblQualityValue.Size = new System.Drawing.Size(11, 12);
            this.lblQualityValue.TabIndex = 6;
            this.lblQualityValue.Tag = "9999";
            this.lblQualityValue.Text = "3";
            // 
            // lblModol
            // 
            this.lblModol.AutoSize = true;
            this.lblModol.Location = new System.Drawing.Point(47, 12);
            this.lblModol.Name = "lblModol";
            this.lblModol.Size = new System.Drawing.Size(65, 12);
            this.lblModol.TabIndex = 0;
            this.lblModol.Text = "拍照模式：";
            // 
            // grpModle
            // 
            this.grpModle.Controls.Add(this.rdoPromptly);
            this.grpModle.Controls.Add(this.rdoSave);
            this.grpModle.Controls.Add(this.rdoSequence);
            this.grpModle.Controls.Add(this.rdoCondition);
            this.grpModle.Location = new System.Drawing.Point(119, 1);
            this.grpModle.Name = "grpModle";
            this.grpModle.Size = new System.Drawing.Size(189, 61);
            this.grpModle.TabIndex = 0;
            this.grpModle.TabStop = false;
            // 
            // rdoPromptly
            // 
            this.rdoPromptly.AutoSize = true;
            this.rdoPromptly.Checked = true;
            this.rdoPromptly.Location = new System.Drawing.Point(10, 14);
            this.rdoPromptly.Name = "rdoPromptly";
            this.rdoPromptly.Size = new System.Drawing.Size(71, 16);
            this.rdoPromptly.TabIndex = 0;
            this.rdoPromptly.TabStop = true;
            this.rdoPromptly.Tag = "";
            this.rdoPromptly.Text = "立即拍照";
            this.rdoPromptly.UseVisualStyleBackColor = true;
            // 
            // rdoSave
            // 
            this.rdoSave.AutoSize = true;
            this.rdoSave.Location = new System.Drawing.Point(100, 14);
            this.rdoSave.Name = "rdoSave";
            this.rdoSave.Size = new System.Drawing.Size(83, 16);
            this.rdoSave.TabIndex = 1;
            this.rdoSave.Tag = "";
            this.rdoSave.Text = "拍照并保存";
            this.rdoSave.UseVisualStyleBackColor = true;
            // 
            // rdoSequence
            // 
            this.rdoSequence.AutoSize = true;
            this.rdoSequence.Location = new System.Drawing.Point(10, 38);
            this.rdoSequence.Name = "rdoSequence";
            this.rdoSequence.Size = new System.Drawing.Size(71, 16);
            this.rdoSequence.TabIndex = 2;
            this.rdoSequence.Tag = "";
            this.rdoSequence.Text = "连续拍照";
            this.rdoSequence.UseVisualStyleBackColor = true;
            this.rdoSequence.CheckedChanged += new System.EventHandler(this.rdoSequence_CheckedChanged);
            // 
            // rdoCondition
            // 
            this.rdoCondition.AutoSize = true;
            this.rdoCondition.Location = new System.Drawing.Point(100, 38);
            this.rdoCondition.Name = "rdoCondition";
            this.rdoCondition.Size = new System.Drawing.Size(71, 16);
            this.rdoCondition.TabIndex = 3;
            this.rdoCondition.Tag = "";
            this.rdoCondition.Text = "条件拍照";
            this.rdoCondition.UseVisualStyleBackColor = true;
            this.rdoCondition.CheckedChanged += new System.EventHandler(this.rdoSequence_CheckedChanged);
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(47, 67);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(65, 12);
            this.lblQuality.TabIndex = 4;
            this.lblQuality.Text = "图像质量：";
            // 
            // trkQuality
            // 
            this.trkQuality.AutoSize = false;
            this.trkQuality.Location = new System.Drawing.Point(119, 62);
            this.trkQuality.Maximum = 5;
            this.trkQuality.Name = "trkQuality";
            this.trkQuality.Size = new System.Drawing.Size(136, 23);
            this.trkQuality.TabIndex = 1;
            this.trkQuality.Tag = "；";
            this.trkQuality.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkQuality.Value = 3;
            this.trkQuality.ValueChanged += new System.EventHandler(this.trkQuality_ValueChanged);
            // 
            // lblQualityExplain
            // 
            this.lblQualityExplain.AutoSize = true;
            this.lblQualityExplain.Location = new System.Drawing.Point(287, 67);
            this.lblQualityExplain.Name = "lblQualityExplain";
            this.lblQualityExplain.Size = new System.Drawing.Size(35, 12);
            this.lblQualityExplain.TabIndex = 7;
            this.lblQualityExplain.Tag = "9999";
            this.lblQualityExplain.Text = "(0-5)";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(47, 95);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(65, 12);
            this.lblInterval.TabIndex = 1;
            this.lblInterval.Text = "拍照间隔：";
            // 
            // numInterval
            // 
            this.numInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numInterval.Enabled = false;
            this.numInterval.Location = new System.Drawing.Point(119, 89);
            this.numInterval.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(161, 21);
            this.numInterval.TabIndex = 2;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(292, 95);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(17, 12);
            this.lblSecond.TabIndex = 1;
            this.lblSecond.Tag = "；";
            this.lblSecond.Text = "秒";
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(47, 125);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(65, 12);
            this.lblCondition.TabIndex = 1;
            this.lblCondition.Text = "拍照条件：";
            // 
            // grpCondition
            // 
            this.grpCondition.Controls.Add(this.checkBox10);
            this.grpCondition.Controls.Add(this.chkAcc);
            this.grpCondition.Controls.Add(this.chkDacoity);
            this.grpCondition.Controls.Add(this.chkOverTime);
            this.grpCondition.Controls.Add(this.chkAreaIn);
            this.grpCondition.Controls.Add(this.chkAreaOut);
            this.grpCondition.Controls.Add(this.checkBox6);
            this.grpCondition.Controls.Add(this.checkBox7);
            this.grpCondition.Enabled = false;
            this.grpCondition.Location = new System.Drawing.Point(119, 111);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(232, 102);
            this.grpCondition.TabIndex = 3;
            this.grpCondition.TabStop = false;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(122, 80);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(72, 16);
            this.checkBox10.TabIndex = 7;
            this.checkBox10.Tag = "8";
            this.checkBox10.Text = "重车拍照";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // chkAcc
            // 
            this.chkAcc.AutoSize = true;
            this.chkAcc.Location = new System.Drawing.Point(10, 14);
            this.chkAcc.Name = "chkAcc";
            this.chkAcc.Size = new System.Drawing.Size(96, 16);
            this.chkAcc.TabIndex = 0;
            this.chkAcc.Tag = "1";
            this.chkAcc.Text = "车辆点火拍照";
            this.chkAcc.UseVisualStyleBackColor = true;
            // 
            // chkDacoity
            // 
            this.chkDacoity.AutoSize = true;
            this.chkDacoity.Location = new System.Drawing.Point(122, 14);
            this.chkDacoity.Name = "chkDacoity";
            this.chkDacoity.Size = new System.Drawing.Size(96, 16);
            this.chkDacoity.TabIndex = 1;
            this.chkDacoity.Tag = "2";
            this.chkDacoity.Text = "车辆劫警拍照";
            this.chkDacoity.UseVisualStyleBackColor = true;
            // 
            // chkOverTime
            // 
            this.chkOverTime.AutoSize = true;
            this.chkOverTime.Location = new System.Drawing.Point(10, 36);
            this.chkOverTime.Name = "chkOverTime";
            this.chkOverTime.Size = new System.Drawing.Size(72, 16);
            this.chkOverTime.TabIndex = 2;
            this.chkOverTime.Tag = "3";
            this.chkOverTime.Text = "超时拍照";
            this.chkOverTime.UseVisualStyleBackColor = true;
            // 
            // chkAreaIn
            // 
            this.chkAreaIn.AutoSize = true;
            this.chkAreaIn.Location = new System.Drawing.Point(122, 36);
            this.chkAreaIn.Name = "chkAreaIn";
            this.chkAreaIn.Size = new System.Drawing.Size(96, 16);
            this.chkAreaIn.TabIndex = 3;
            this.chkAreaIn.Tag = "4";
            this.chkAreaIn.Text = "入界报警拍照";
            this.chkAreaIn.UseVisualStyleBackColor = true;
            // 
            // chkAreaOut
            // 
            this.chkAreaOut.AutoSize = true;
            this.chkAreaOut.Location = new System.Drawing.Point(10, 58);
            this.chkAreaOut.Name = "chkAreaOut";
            this.chkAreaOut.Size = new System.Drawing.Size(96, 16);
            this.chkAreaOut.TabIndex = 4;
            this.chkAreaOut.Tag = "5";
            this.chkAreaOut.Text = "出界报警拍照";
            this.chkAreaOut.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(122, 58);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(84, 16);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Tag = "6";
            this.checkBox6.Text = "车门开拍照";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(10, 80);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(96, 16);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Tag = "7";
            this.checkBox7.Text = "防盗报警拍照";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // pnlWait
            // 
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblWaitText);
            this.pnlWait.Location = new System.Drawing.Point(5, 3);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new System.Drawing.Size(129, 22);
            this.pnlWait.TabIndex = 15;
            this.pnlWait.Tag = "9999";
            // 
            // pbPicWait
            // 
            this.pbPicWait.BackColor = System.Drawing.Color.Transparent;
            this.pbPicWait.Image = global::Client.Properties.Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new System.Drawing.Point(3, 3);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new System.Drawing.Size(16, 16);
            this.pbPicWait.TabIndex = 11;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.pbPicWait.Visible = false;
            // 
            // lblWaitText
            // 
            this.lblWaitText.AutoSize = true;
            this.lblWaitText.Location = new System.Drawing.Point(22, 5);
            this.lblWaitText.Name = "lblWaitText";
            this.lblWaitText.Size = new System.Drawing.Size(89, 12);
            this.lblWaitText.TabIndex = 9;
            this.lblWaitText.Text = "正在执行中....";
            this.lblWaitText.Visible = false;
            // 
            // m2mShootPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 503);
            this.Controls.Add(this.groupBox1);
            this.Name = "m2mShootPhoto";
            this.Text = "itmShootPhoto";
            this.Load += new System.EventHandler(this.m2mShootPhoto_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.pnlCamera.ResumeLayout(false);
            this.pnlCamera.PerformLayout();
            this.grpCamera.ResumeLayout(false);
            this.grpCamera.PerformLayout();
            this.pnlPhoto.ResumeLayout(false);
            this.pnlPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhotoId)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlPhotoParam.ResumeLayout(false);
            this.pnlPhotoParam.PerformLayout();
            this.grpModle.ResumeLayout(false);
            this.grpModle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCamera;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkCamera1;
        private System.Windows.Forms.Panel pnlPhotoParam;
        private System.Windows.Forms.Label lblQualityValue;
        private System.Windows.Forms.Label lblModol;
        private System.Windows.Forms.GroupBox grpModle;
        private System.Windows.Forms.RadioButton rdoPromptly;
        private System.Windows.Forms.RadioButton rdoSave;
        private System.Windows.Forms.RadioButton rdoSequence;
        private System.Windows.Forms.RadioButton rdoCondition;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.TrackBar trkQuality;
        private System.Windows.Forms.Label lblQualityExplain;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.GroupBox grpCondition;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox chkAcc;
        private System.Windows.Forms.CheckBox chkDacoity;
        private System.Windows.Forms.CheckBox chkOverTime;
        private System.Windows.Forms.CheckBox chkAreaIn;
        private System.Windows.Forms.CheckBox chkAreaOut;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Panel pnlWait;
        private System.Windows.Forms.PictureBox pbPicWait;
        private System.Windows.Forms.Label lblWaitText;
        private System.Windows.Forms.Panel pnlPhoto;
        private System.Windows.Forms.Label lblPhotoId;
        private System.Windows.Forms.NumericUpDown numPhotoId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
