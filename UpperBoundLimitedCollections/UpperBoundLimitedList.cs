using System;
using System.Collections;
using System.Collections.Generic;

namespace UpperBoundLimitedCollections
{
    public class UpperBoundLimitedList<T> : IList<T>
    {
        private IList<T> _list;

        public int UpperBoundLimit { get; }

        public UpperBoundLimitedList(int upperBoundLimit)
        {
            _list = new List<T>();
            UpperBoundLimit = upperBoundLimit;
        }

        public int Count => _list.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int IndexOf(T item) => _list.IndexOf(item);

        /// <summary>
        /// Inserts an item to the System.Collections.Generic.IList at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the System.Collections.Generic.IList.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index is not a valid index in the System.Collections.Generic.IList.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">index is not a valid index in the System.Collections.Generic.IList.</exception>
        /// <exception cref="System.NotSupportedException">The System.Collections.Generic.IList is read-only.</exception>
        public void Insert(int index, T item)
        {
            if (index == 0 && _list.Count == UpperBoundLimit)
                throw new ArgumentOutOfRangeException($"index cannot be 0, UpperBoundLimit of {UpperBoundLimit} will ensure that item will be removed after being added.");

            if (_list.Count == UpperBoundLimit)
                _list.RemoveAt(0);

            _list.Insert(index, item);
        }

        public void RemoveAt(int index) => _list.RemoveAt(index);

        /// <summary>
        /// Adds an item to the System.Collections.Generic.ICollection, removing the first item from the collection if the count is at the upper bound limit.
        /// </summary>
        /// <param name="item">The object to add to the System.Collections.Generic.ICollection</param>
        /// <exception cref="System.NotSupportedException">The System.Collections.Generic.ICollection is read-only.</exception>
        public void Add(T item) {
            if (_list.Count == UpperBoundLimit)
                _list.RemoveAt(0);

            _list.Add(item);
        }

        public void Clear() => _list.Clear();

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public bool Remove(T item) => _list.Remove(item);

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
