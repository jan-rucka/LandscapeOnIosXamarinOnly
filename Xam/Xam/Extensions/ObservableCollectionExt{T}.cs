using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Xam.Extensions
{
    /// <summary>
    /// Extended ObservableCollection
    /// avoids firing CollectionChanged multiple times when replacing all elements or adding/removing a collection of elements    
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableCollectionExt<T> : ObservableCollection<T>
    {
        public ObservableCollectionExt() : base()
        {
        }

        public ObservableCollectionExt(IEnumerable<T> collection) : base(collection)
        {
        }

        public ObservableCollectionExt(List<T> list) : base(list)
        {
        }

        public void AddRange(IEnumerable<T> collection, NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Add)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (!collection.Any())
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                return;
            }
                
            CheckReentrancy();

            if (notificationMode == NotifyCollectionChangedAction.Reset)
            {
                foreach (var item in collection)
                {
                    Items.Add(item);
                }                    

                OnPropertyChanged(new PropertyChangedEventArgs("Count"));
                OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                return;
            }

            int startIndex = Count;
            var changedItems = collection is List<T> ? (List<T>)collection : new List<T>(collection);
            foreach (var item in changedItems)
            {
                Items.Add(item);
            }                

            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startIndex));
        }

        public void Reset(T item)
        {
            Reset(new List<T>() { item });
        }

        public void Reset(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));          

            Items.Clear();
            
            AddRange(collection, NotifyCollectionChangedAction.Reset);
        }

        public void RemoveRange(Predicate<T> remove)
        {
            // iterates backwards so can remove multiple items without invalidating indexes
            for (var i = Items.Count - 1; i > -1; i--)
            {
                if (remove(Items[i]))
                    Items.RemoveAt(i);
            }

            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
        }

        public void RemoveRange(IEnumerable<T> collection, NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Reset)
        {
            if (notificationMode != NotifyCollectionChangedAction.Remove
                && notificationMode != NotifyCollectionChangedAction.Reset)
            {
                throw new ArgumentException("Mode must be either Remove or Reset for RemoveRange.", nameof(notificationMode));
            }
                
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (!collection.Any())
                return;

            CheckReentrancy();

            if (notificationMode == NotifyCollectionChangedAction.Reset)
            {
                for (var i = Items.Count - 1; i > -1; i--)
                {
                    if (collection.Contains(Items[i]))
                        Items.RemoveAt(i);
                }

                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

                return;
            }
            
            var changedItems = collection is List<T> ? (List<T>)collection : new List<T>(collection);
            for (int i = 0; i < changedItems.Count; i++)
            {
                if (!Items.Remove(changedItems[i]))
                {
                    changedItems.RemoveAt(i); 
                    i--;
                }
            }

            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItems, -1));
        }

        public void Replace( T oldValue, T newValue)
        {
            if (newValue == null)
                throw new ArgumentNullException(nameof(newValue));
            if (oldValue == null)
                throw new ArgumentNullException(nameof(oldValue));

            var index = Items.IndexOf(oldValue);
            if (index != -1)
                Items[index] = newValue;
        }
    }
}
