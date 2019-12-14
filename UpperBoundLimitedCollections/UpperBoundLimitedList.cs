using System;
using System.Collections;
using System.Collections.Generic;

namespace UpperBoundLimitedCollections
{
    public class UpperBoundLimitedList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance that extends the <c>System.Collections.Generic.List</c> where the maximum upper bound limit of the list is controlled.
        /// If the current count of the list is already at the upper bound limit or above, a range from the beginning of the list will be removed from the list when adding or inserting a new item,
        /// in order to maintain the maximum upper bound limit.
        /// </summary>
        public UpperBoundLimitedList()
        {

        }

        /// <summary>
        /// Inserts an item into the <c>System.Collections.Generic.IList</c> at the specified index,
        /// removing a range from the beginning of the list if count is already larger or equal to 'upperBoundlimit', in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to add to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The param upperBoundLimit must be larger than 0.</exception>
        public void Insert(int index, T item, int upperBoundLimit)
        {
            // Handles the upper boud limit. If this.Count is larger than 'upperBoundlimit',
            // a range from the beginning of the list will be removed in order to maintain the maximum upper bound limit
            HandleUpperBoundLimit(upperBoundLimit);

            Insert(index, item);
        }

        /// <summary>
        /// Appends an item to the end of the  <c>System.Collections.Generic.ICollection</c>,
        /// removing a range from the beginning of the list if count is already larger or equal to 'upperBoundlimit', in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="item">The object to add to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The param upperBoundLimit must be larger than 0.</exception>
        public void Add(T item, int upperBoundLimit)
        {
            // Handles the upper boud limit. If this.Count is larger than 'upperBoundlimit',
            // a range from the beginning of the list will be removed in order to maintain the maximum upper bound limit
            HandleUpperBoundLimit(upperBoundLimit);

            Add(item);
        }

        /// <summary>
        /// Handles the upper boud limit. If this.Count is larger than 'upperBoundlimit',
        /// a range from the beginning of the list will be removed in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain.</param>
        private void HandleUpperBoundLimit(int upperBoundLimit)
        {
            // upperBoundLimit must be larger than 0
            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The param upperBoundLimit must be larger than 0.");

            // Determine the range of items to be removed, in order to maintain the upperBoundLimit
            if (Count >= upperBoundLimit)
                RemoveRange(0, Count - upperBoundLimit);
        }
    }
}