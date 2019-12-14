using System;
using System.Collections;
using System.Collections.Generic;

namespace UpperBoundLimitedCollections
{
    public class StrictUpperBoundLimitedList<T> : List<T>
    {
        /// <summary>
        /// The maximum upper bound limit that the list should maintain.
        /// This value must be greater than 0.
        /// </summary>
        public int UpperBoundLimit { get; private set; }

        /// <summary>
        /// Initializes a new instance that extends <c>System.Collections.Generic.List</c> where the maximum upper bound limit of the list is strictly controlled.
        /// If the current count of the list is already at the upper bound limit, the first element is removed from the list when adding or inserting a new item,
        /// in order to strictly maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The param upperBoundLimit must be greater than 0.</exception>
        public StrictUpperBoundLimitedList(int upperBoundLimit)
        {
            // upperBoundLimit must be larger than 0
            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The param upperBoundLimit must be greater than 0.");

            UpperBoundLimit = upperBoundLimit;
        }

        /// <summary>
        /// Adds an item to the <c>System.Collections.Generic.ICollection</c>,
        /// removing the first item from the collection if the count is already at the upper bound limit, in order to strictly maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="item">The object to add to the <c>System.Collections.Generic.ICollection</c>.</param>
        public new void Add(T item)
        {
            // Handles the upper boud limit. If this.Count is equal to 'upperBoundlimit',
            // the first element in the list is removed in order to maintain the maximum upper bound limit.
            HandleUpperBoundLimit();

            Add(item);
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            //TODO: complete
        }

        /// <summary>
        /// Insert an item into the <c>System.Collections.Generic.IList</c> at the specified index.
        /// removing the first item from the collection if the count is already at the upper bound limit, in order to strictly maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the <c>System.Collections.Generic.IList</c>.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index is not a valid index in the System.Collections.Generic.IList.</exception>
        public new void Insert(int index, T item)
        {
            // Handles the upper boud limit. If this.Count is equal to 'upperBoundlimit',
            // the first element in the list is removed in order to maintain the maximum upper bound limit.
            HandleUpperBoundLimit();

            Insert(index, item);
        }

        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            //TODO: complete
        }

        /// <summary>
        /// Handles the upper boud limit. If this.Count is equal to 'upperBoundlimit',
        /// the first element in the list is removed in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain.</param>
        private void HandleUpperBoundLimit()
        {
            // If current count is equal to UpperBoundLimit, remove first item in list
            if (Count == UpperBoundLimit)
                RemoveAt(0);
        }
    }
}