namespace Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable]
    public class RecentUseMenuCollection : IComparable<RecentUseMenuCollection>, ICollection<RecentUseMenuCollection>, IEnumerable<RecentUseMenuCollection>, IEnumerable
    {
        private string _key;
        private List<RecentUseMenuCollection> _list = new List<RecentUseMenuCollection>();
        private string _menuText;
        private DateTime _tm = DateTime.Now;
        private int _useCount;

        public void Add(RecentUseMenuCollection item)
        {
            this._list.Add(item);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public int CompareTo(RecentUseMenuCollection other)
        {
            if (other._useCount > this._useCount)
            {
                return 1;
            }
            if (other._useCount < this._useCount)
            {
                return -1;
            }
            if (other._tm > this._tm)
            {
                return -1;
            }
            if (other._tm < this._tm)
            {
                return 1;
            }
            return 0;
        }

        public bool Contains(RecentUseMenuCollection item)
        {
            return this._list.Contains(item);
        }

        public void CopyTo(RecentUseMenuCollection[] array, int arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<RecentUseMenuCollection> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        public bool Remove(RecentUseMenuCollection item)
        {
            return (this._list.Contains(item) && this._list.Remove(item));
        }

        public void Sort()
        {
            this._list.Sort();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return this._list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public RecentUseMenuCollection this[string tag]
        {
            get
            {
                return this._list.Find(obj => obj._key.Equals(tag));
            }
        }

        public RecentUseMenuCollection this[int index]
        {
            get
            {
                return this._list[index];
            }
        }

        public List<RecentUseMenuCollection> List
        {
            get
            {
                return this._list;
            }
        }

        public string MenuKey
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }

        public string MenuText
        {
            get
            {
                return this._menuText;
            }
            set
            {
                this._menuText = value;
            }
        }

        public int UseCount
        {
            get
            {
                return this._useCount;
            }
            set
            {
                this._useCount = value;
            }
        }

        public DateTime UseTime
        {
            get
            {
                return this._tm;
            }
            set
            {
                this._tm = value;
            }
        }
    }
}

