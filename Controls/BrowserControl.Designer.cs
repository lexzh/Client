namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class BrowserControl
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(BrowserControl));
            this.containerPanel = new Panel();
            this.panel2 = new Panel();
            this.goButton = new Button();
            this.addressTextBox = new TextBox();
            this.label1 = new Label();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            resources.ApplyResources(this.containerPanel, "containerPanel");
            this.containerPanel.Name = "containerPanel";
            this.panel2.Controls.Add(this.goButton);
            this.panel2.Controls.Add(this.addressTextBox);
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            resources.ApplyResources(this.goButton, "goButton");
            this.goButton.Name = "goButton";
            this.goButton.UseVisualStyleBackColor = false;
            this.goButton.Click += new EventHandler(this.goButton_Click);
            resources.ApplyResources(this.addressTextBox, "addressTextBox");
            this.addressTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.addressTextBox.AutoCompleteSource = AutoCompleteSource.AllUrl;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.KeyUp += new KeyEventHandler(this.addressTextBox_KeyUp);
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.containerPanel);
            base.Controls.Add(this.panel2);
            base.Name = "BrowserControl";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private ExtendedWebBrowser _browser;
        private TextBox addressTextBox;
        private Panel containerPanel;
        private Button goButton;
        private Label label1;
        private Panel panel2;
    }
}