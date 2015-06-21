namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    partial class OptionsForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(OptionsForm));
            this.popupBlockerGroupBox = new GroupBox();
            this.filterLevelHighRadioButton = new RadioButton();
            this.filterLevelMediumRadioButton = new RadioButton();
            this.filterLevelLowRadioButton = new RadioButton();
            this.filterLevelNoneRadioButton = new RadioButton();
            this.groupBox2 = new GroupBox();
            this.doNotShowScriptErrorsCheckBox = new CheckBox();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.label1 = new Label();
            this.popupBlockerGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.popupBlockerGroupBox.Controls.Add(this.filterLevelHighRadioButton);
            this.popupBlockerGroupBox.Controls.Add(this.filterLevelMediumRadioButton);
            this.popupBlockerGroupBox.Controls.Add(this.filterLevelLowRadioButton);
            this.popupBlockerGroupBox.Controls.Add(this.filterLevelNoneRadioButton);
            resources.ApplyResources(this.popupBlockerGroupBox, "popupBlockerGroupBox");
            this.popupBlockerGroupBox.Name = "popupBlockerGroupBox";
            this.popupBlockerGroupBox.TabStop = false;
            resources.ApplyResources(this.filterLevelHighRadioButton, "filterLevelHighRadioButton");
            this.filterLevelHighRadioButton.Name = "filterLevelHighRadioButton";
            this.filterLevelHighRadioButton.TabStop = true;
            this.filterLevelHighRadioButton.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.filterLevelMediumRadioButton, "filterLevelMediumRadioButton");
            this.filterLevelMediumRadioButton.Name = "filterLevelMediumRadioButton";
            this.filterLevelMediumRadioButton.TabStop = true;
            this.filterLevelMediumRadioButton.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.filterLevelLowRadioButton, "filterLevelLowRadioButton");
            this.filterLevelLowRadioButton.Name = "filterLevelLowRadioButton";
            this.filterLevelLowRadioButton.TabStop = true;
            this.filterLevelLowRadioButton.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.filterLevelNoneRadioButton, "filterLevelNoneRadioButton");
            this.filterLevelNoneRadioButton.Name = "filterLevelNoneRadioButton";
            this.filterLevelNoneRadioButton.TabStop = true;
            this.filterLevelNoneRadioButton.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.doNotShowScriptErrorsCheckBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.doNotShowScriptErrorsCheckBox, "doNotShowScriptErrorsCheckBox");
            this.doNotShowScriptErrorsCheckBox.Name = "doNotShowScriptErrorsCheckBox";
            this.doNotShowScriptErrorsCheckBox.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new EventHandler(this.okButton_Click);
            this.cancelButton.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            base.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.cancelButton;
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cancelButton);
            base.Controls.Add(this.okButton);
            base.Controls.Add(this.popupBlockerGroupBox);
            base.FormBorderStyle =  System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "OptionsForm";
            base.Load += new EventHandler(this.OptionsForm_Load);
            this.popupBlockerGroupBox.ResumeLayout(false);
            this.popupBlockerGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private Button cancelButton;
        private CheckBox doNotShowScriptErrorsCheckBox;
        private RadioButton filterLevelHighRadioButton;
        private RadioButton filterLevelLowRadioButton;
        private RadioButton filterLevelMediumRadioButton;
        private RadioButton filterLevelNoneRadioButton;
        private GroupBox groupBox2;
        private Label label1;
        private Button okButton;
        private GroupBox popupBlockerGroupBox;
    }
}