namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Forms;

    internal partial class ScriptErrorWindow : Form
    {

        public ScriptErrorWindow()
        {
            this.InitializeComponent();
            ScriptErrorManager.Instance.ScriptErrors.CollectionChanged += new EventHandler(this.ScriptErrors_CollectionChanged);
        }

        private void clearListToolStripButton_Click(object sender, EventArgs e)
        {
            ScriptErrorManager.Instance.ScriptErrors.Clear();
        }

 private void ScriptErrors_CollectionChanged(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        private void ScriptErrorWindow_Load(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        private void UpdateList()
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            foreach (ScriptError error in ScriptErrorManager.Instance.ScriptErrors)
            {
                ListViewItem item = new ListViewItem(error.Description);
                item.SubItems.Add(error.LineNumber.ToString(CultureInfo.CurrentCulture));
                item.SubItems.Add(error.Url.ToString());
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }
    }
}

