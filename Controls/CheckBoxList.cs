namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public partial class CheckBoxList : UserControl
    {

        public event ItemCheckEventHandler CheckItem;

        public CheckBoxList()
        {
            this.InitializeComponent();
        }

        public void Add(CheckBoxItem chk)
        {
            chk.Click += new EventHandler(this.CheckedChanged);
            this.pnlChk.Controls.Add(chk);
            this.pnlChk.Controls.SetChildIndex(chk, this.Count - 1);
            chk.Dock = DockStyle.Bottom;
        }

        public void CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckItem != null)
            {
                CheckBoxItem chk = (CheckBoxItem) sender;
                int index = this.IndexOf(chk);
                if (index >= 0)
                {
                    CheckState @unchecked = CheckState.Unchecked;
                    if (chk.CheckState == CheckState.Checked)
                    {
                        @unchecked = CheckState.Unchecked;
                    }
                    else
                    {
                        @unchecked = CheckState.Checked;
                    }
                    ItemCheckEventArgs args = new ItemCheckEventArgs(index, chk.CheckState, @unchecked);
                    this.CheckItem(this, args);
                }
            }
        }

        public void Clear()
        {
            this.pnlChk.Controls.Clear();
        }

 public int IndexOf(string sText)
        {
            CheckBoxItem[] items = this.Items;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Text == sText)
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(CheckBoxItem chk)
        {
            return this.pnlChk.Controls.IndexOf(chk);
        }

 public void RemoveAt(int iIndex)
        {
            this.pnlChk.Controls.RemoveAt(iIndex);
        }

        public void SetItemChecked(int iIndex, bool bChecked)
        {
            ((CheckBoxItem) this.pnlChk.Controls[iIndex]).Checked = bChecked;
        }

        public int Count
        {
            get
            {
                return this.pnlChk.Controls.Count;
            }
        }

        public CheckBoxItem[] Items
        {
            get
            {
                CheckBoxItem[] itemArray = new CheckBoxItem[this.pnlChk.Controls.Count];
                for (int i = 0; i < this.pnlChk.Controls.Count; i++)
                {
                    itemArray[i] = (CheckBoxItem) this.pnlChk.Controls[i];
                }
                return itemArray;
            }
        }
    }
}

