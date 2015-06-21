namespace WinFormsUI.Controls
{
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    internal class NotifyCollection<T> : Collection<T>
    {
        public event EventHandler CollectionChanged;

        protected override void ClearItems()
        {
            base.ClearItems();
            this.OnCollectionChanged(EventArgs.Empty);
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            this.OnCollectionChanged(EventArgs.Empty);
        }

        protected virtual void OnCollectionChanged(EventArgs e)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, e);
            }
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            this.OnCollectionChanged(EventArgs.Empty);
        }

        protected override void SetItem(int index, T item)
        {
            base.SetItem(index, item);
            this.OnCollectionChanged(EventArgs.Empty);
        }
    }
}

