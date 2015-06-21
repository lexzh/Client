namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    partial class OpenUrlForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(OpenUrlForm));
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.label2 = new Label();
            this.addressTextBox = new TextBox();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.invalidAddressLabel = new Label();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.addressTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.addressTextBox.AutoCompleteSource = AutoCompleteSource.AllUrl;
            resources.ApplyResources(this.addressTextBox, "addressTextBox");
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.TextChanged += new EventHandler(this.textBox1_TextChanged);
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new EventHandler(this.okButton_Click);
            this.cancelButton.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.invalidAddressLabel, "invalidAddressLabel");
            this.invalidAddressLabel.Name = "invalidAddressLabel";
            base.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.cancelButton;
            base.Controls.Add(this.invalidAddressLabel);
            base.Controls.Add(this.cancelButton);
            base.Controls.Add(this.okButton);
            base.Controls.Add(this.addressTextBox);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.label1);
            base.Name = "OpenUrlForm";
            base.Load += new EventHandler(this.OpenUrlForm_Load);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private Uri _url;
        private TextBox addressTextBox;
        private Button cancelButton;
        private Label invalidAddressLabel;
        private Label label1;
        private Label label2;
        private Button okButton;
        private PictureBox pictureBox1;
    }
}