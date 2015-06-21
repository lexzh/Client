namespace WinFormsUI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class DataGridViewEx : DataGridView
    {
        private DataGridViewCell _firstSelectedCell;
        private bool _isControlKey;
        private List<string> _notMultiSelectedColumnName = new List<string>();
        private DataGridViewSelectedCellCollection _selectCells;
        private IContainer components;

        public DataGridViewEx()
        {
            this.InitializeComponent();
        }

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
            this.components = new Container();
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);
            if ((((this._selectCells != null) && (this._selectCells.Count > 1)) && ((base.SelectedCells.Count > 0) && (base.SelectedCells[0] is DataGridViewCheckBoxCell))) && (this._selectCells.Contains(base.SelectedCells[0]) && !base.SelectedCells[0].EditedFormattedValue.Equals(base.SelectedCells[0].Value)))
            {
                foreach (DataGridViewCell cell in this._selectCells)
                {
                    if ((((cell.RowIndex != base.CurrentCell.RowIndex) && !this._notMultiSelectedColumnName.Contains(cell.OwningColumn.Name)) && ((cell is DataGridViewCheckBoxCell) && !cell.ReadOnly)) && ((cell.Value != null) && (cell.Value.ToString() != base.CurrentCell.Value.ToString())))
                    {
                        cell.Value = base.CurrentCell.Value;
                    }
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control || e.Shift)
            {
                this._isControlKey = true;
            }
            if (((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.V)) && Clipboard.ContainsText())
            {
                string[] strArray = Clipboard.GetText().Split("\r\n".ToCharArray());
                if ((base.SelectedCells.Count > 0) && (strArray.Length > 0))
                {
                    foreach (DataGridViewCell cell in base.SelectedCells)
                    {
                        if ((cell is DataGridViewTextBoxCell) && !cell.ReadOnly)
                        {
                            cell.Value = strArray[0];
                        }
                    }
                }
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if ((e.KeyValue == 17) || (e.KeyValue == 16))
            {
                this._isControlKey = false;
            }
            base.OnKeyUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            DataGridView.HitTestInfo info = base.HitTest(e.X, e.Y);
            this._selectCells = base.SelectedCells;
            if ((!this._isControlKey && (info.RowIndex >= 0)) && (info.ColumnIndex >= 0))
            {
                this._firstSelectedCell = base[info.ColumnIndex, info.RowIndex];
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (base.CurrentCell is DataGridViewCheckBoxCell)
            {
                base.EndEdit();
            }
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            foreach (DataGridViewCell cell in base.SelectedCells)
            {
                if ((this._firstSelectedCell != null) && (this._firstSelectedCell.ColumnIndex != cell.ColumnIndex))
                {
                    cell.Selected = false;
                }
            }
            base.OnSelectionChanged(e);
        }

        [Category("自定义"), Description("不参与多选功能的列名(DataGridViewColumnName)")]
        public List<string> NotMultiSelectedColumnName
        {
            get
            {
                return this._notMultiSelectedColumnName;
            }
            set
            {
                this._notMultiSelectedColumnName = value;
            }
        }
    }
}

