namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ListBoxEx : ListBox
    {
        private bool _isCheckBox = true;
        private StringFormat Align;
        private IContainer components;
        private bool IsTransparent;
        private Brush TransparentBrush = SystemBrushes.Control;

        public ListBoxEx()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.Align = new StringFormat(StringFormat.GenericDefault);
            this.Align.LineAlignment = StringAlignment.Center;
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

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.Index >= 0) && (e.Index <= (base.Items.Count - 1)))
            {
                Brush grayText;
                int height = e.Font.Height;
                if (this.IsTransparent && (e.State != DrawItemState.Selected))
                {
                    e.Graphics.FillRectangle(this.TransparentBrush, e.Bounds);
                }
                else
                {
                    e.DrawBackground();
                }
                ButtonState normal = ButtonState.Normal;
                if (((e.State & DrawItemState.Disabled) > DrawItemState.None) || ((e.State & DrawItemState.Grayed) > DrawItemState.None))
                {
                    grayText = SystemBrushes.GrayText;
                    normal = ButtonState.Inactive;
                }
                else if (((e.State & DrawItemState.Selected) > DrawItemState.None) && !this.Transparent)
                {
                    grayText = SystemBrushes.HighlightText;
                }
                else
                {
                    grayText = SystemBrushes.FromSystemColor(this.ForeColor);
                }
                if ((e.State & DrawItemState.Selected) > DrawItemState.None)
                {
                    normal |= ButtonState.Checked;
                }
                Rectangle bounds = e.Bounds;
                bounds.Width = height;
                if (!this._isCheckBox)
                {
                    ControlPaint.DrawRadioButton(e.Graphics, bounds, normal);
                }
                else
                {
                    ControlPaint.DrawCheckBox(e.Graphics, bounds, normal);
                }
                bounds = new Rectangle((e.Bounds.X + height) + 2, e.Bounds.Y, (e.Bounds.Width - height) - 2, e.Bounds.Height);
                e.Graphics.DrawString(base.Items[e.Index].ToString(), e.Font, grayText, bounds, this.Align);
                e.DrawFocusRectangle();
            }
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            this.Transparent = this.IsTransparent;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            this.Transparent = this.IsTransparent;
        }

        public bool IsCheckBox
        {
            get
            {
                return this._isCheckBox;
            }
            set
            {
                this._isCheckBox = value;
            }
        }

        [DefaultValue(false)]
        public bool Transparent
        {
            get
            {
                return this.IsTransparent;
            }
            set
            {
                this.IsTransparent = value;
                if (this.IsTransparent)
                {
                    if (base.Parent != null)
                    {
                        this.BackColor = base.Parent.BackColor;
                    }
                    else
                    {
                        this.BackColor = SystemColors.Control;
                    }
                    this.TransparentBrush = new SolidBrush(this.BackColor);
                    base.BorderStyle = BorderStyle.None;
                }
                else
                {
                    this.BackColor = SystemColors.Window;
                    base.BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }
    }
}

