namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    internal partial class OptionsForm : Form
    {

        public OptionsForm()
        {
            this.InitializeComponent();
        }

 private void okButton_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            SettingsHelper current = SettingsHelper.Current;
            this.filterLevelNoneRadioButton.Checked = true;
            this.doNotShowScriptErrorsCheckBox.Checked = !current.ShowScriptErrors;
            if ((Environment.OSVersion.Version.Major < 5) || (Environment.OSVersion.Version.Minor < 1))
            {
                this.popupBlockerGroupBox.Enabled = false;
            }
        }
    }
}

