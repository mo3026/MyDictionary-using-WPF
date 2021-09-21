using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System;
using System.Collections;

namespace MyDictionary.ObservableSortedList
{
    public class SortedObservableCollection<TValue> : SortedCollection<TValue>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        public SortedObservableCollection() : base() { }
        public SortedObservableCollection(IComparer<TValue> comparer) : base(comparer) { }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, e);
            }
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index)
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index));
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, object oldItem, object newItem, int index)
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, newItem, oldItem, index));
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index, int oldIndex)
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index, oldIndex));
        }

        private void OnCollectionReset()
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public override int Add(TValue value)
        {
            int index= base.Add(value);
            this.OnPropertyChanged("Count");
            this.OnPropertyChanged("Item[]");
            this.OnCollectionChanged(NotifyCollectionChangedAction.Add, value, index);
            return index;
        }

        public override void Remove(TValue value)
        {
            base.Remove(value);
            this.OnPropertyChanged("Item[]");
            this.OnPropertyChanged("Count");
            this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, value, -1);
        }

        public TValue this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                var oldItem = base[index];
                base[index] = value;
                this.OnPropertyChanged("Item[]");
                this.OnCollectionChanged(NotifyCollectionChangedAction.Replace, oldItem, value, index);
            }
        }
    }
}
