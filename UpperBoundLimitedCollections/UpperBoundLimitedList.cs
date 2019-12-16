using UpperBoundLimitedCollections.Helpers;
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
        /// Appends an item to the end of the <c>System.Collections.Generic.ICollection</c>,
        /// removing a range of items from the beginning of the list if count is already larger or equal to 'upperBoundlimit', in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="item">The object to add to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The param upperBoundLimit must be greater than 0.</exception>
        public void Add(T item, int upperBoundLimit)
        {
            // Handles the upper boud limit. If this.Count is larger than 'upperBoundlimit',
            // a range of items from the beginning of the list will be removed in order to maintain the maximum upper bound limit
            UpperBoundLimitHandler.CheckAndRemoveRange(this, item.Yield(), upperBoundLimit);

            // Add the item to 'this'
            Add(item);
        }

        public void AddRange(IEnumerable<T> collection, int upperBoundLimit)
        {
            // Handles the upper boud limit. If this.Count combined with collection size is equal to or greater than 'upperBoundlimit',
            // a range of items from the beginning of the list is removed in order to maintain the maximum upper bound limit.
            UpperBoundLimitHandler.CheckAndRemoveRange(this, collection, upperBoundLimit);

            // Add range to 'this'
            AddRange(collection, upperBoundLimit);
        }

        /// <summary>
        /// Inserts an item into the <c>System.Collections.Generic.IList</c> at the specified index,
        /// removing a range of items from the beginning of the list if count is already larger or equal to 'upperBoundlimit', in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to add to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The param upperBoundLimit must be greater than 0.</exception>
        public void Insert(int index, T item, int upperBoundLimit)
        {
            // Handles the upper boud limit. If this.Count is larger than 'upperBoundlimit',
            // a range of items from the beginning of the list will be removed in order to maintain the maximum upper bound limit
            UpperBoundLimitHandler.CheckAndRemoveRange(this, item.Yield(), upperBoundLimit);

            // Inssert item to 'this'
            Insert(index, item);
        }

        public void InsertRange(int index, IEnumerable<T> collection, int upperBoundLimit)
        {
            // Handles the upper boud limit. If this.Count combined with collection size is equal to or greater than 'upperBoundlimit',
            // a range of items from the beginning of the list is removed in order to maintain the maximum upper bound limit.
            UpperBoundLimitHandler.CheckAndRemoveRange(this, collection, upperBoundLimit);

            // Insert range to 'this'
            InsertRange(index, collection);
        }
    }
}