using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System;
using System.Collections;

namespace MyDictionary.ObservableSortedList
{
    public class SortedCollection<T> : IEnumerable<T>, IEnumerable
    {
        IComparer<T> comparer;
        List<T> sortedList;
        public int Count { get; private set; }
        public SortedCollection() : this(null) { }
        public SortedCollection(int capacity) : this(capacity, null) { }
        public SortedCollection(IComparer<T> comparer) : this(16, comparer) { }
        public SortedCollection(int capacity, IComparer<T> comparer)
        {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            this.sortedList = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return sortedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return sortedList.GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                return sortedList[index];
            }
            set
            {
                var oldItem = sortedList[index];
                sortedList[index] = value;
            }
        }

        public virtual bool Contains(T v)
        {
            return sortedList.Contains(v);
        }

        public virtual int Add(T v)
        {
            var index = sortedList.BinarySearch(v);
            if (index < 0) index = ~index;
            sortedList.Insert(index, v);
            return index;
        }

        public virtual void Remove(T value)
        {
            sortedList.Remove(value);
        }
    }
}
