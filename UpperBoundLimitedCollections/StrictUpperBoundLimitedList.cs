using System;
using System.Collections.Generic;
using System.Linq;

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
            HandleUpperBoundLimitForAdd();

            Add(item);
        }

        /// <summary>
        /// Adds a collection of items to the <c>System.Collections.Generic.ICollection</c>,
        /// removing a range of items from the beginning of the list if list count combined with collection size is already larger or equal to 'upperBoundlimit',
        /// in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <c>System.Collections.Generic.List</c>.
        /// The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public new void AddRange(IEnumerable<T> collection)
        {
            // Handles the upper boud limit. If this.Count combined with collection size is equal to or greater than 'upperBoundlimit',
            // a range of items from the beginning of the list is removed in order to maintain the maximum upper bound limit.
            HandleUpperBountLimitForAddRange(collection.Count());

            AddRange(collection);
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
            HandleUpperBoundLimitForAdd();

            Insert(index, item);
        }

        /// <summary>
        /// Inserts a collection of items to the <c>System.Collections.Generic.ICollection</c> starting at the specified index,
        /// removing a range of items from the beginning of the list if list count combined with collection size is already larger or equal to 'upperBoundlimit',
        /// in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the <c>System.Collections.Generic.List</c>.
        /// The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            // Handles the upper boud limit. If this.Count combined with collection size is equal to or greater than 'upperBoundlimit',
            // a range of items from the beginning of the list is removed in order to maintain the maximum upper bound limit.
            HandleUpperBountLimitForAddRange(collection.Count());

            InsertRange(index, collection);
        }

        /// <summary>
        /// Handles the upper bound limit. If this.Count is equal to 'upperBoundlimit',
        /// the first element in the list is removed in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that the list should maintain.</param>
        private void HandleUpperBoundLimitForAdd()
        {
            // If current count is equal to UpperBoundLimit, remove first item in list
            if (Count == UpperBoundLimit)
                RemoveAt(0);
        }

        /// <summary>
        /// Handles the upper bound limit. If this.Count combined with collection count is greater or equal to 'upperBoundlimit',
        /// a range of items from the beginning of the list will be removed in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="collectionCount"></param>
        private void HandleUpperBountLimitForAddRange(int collectionCount)
        {
            // collection cannot be greater than the UpperBoundLimit
            if (collectionCount > UpperBoundLimit)
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentOutOfRangeException("collection", collectionCount, "The size of param collection cannot be greater than the 'UpperBoundLimit'.");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

            // Determine the range of items to be removed, in order to maintain the upperBoundLimit
            if (Count + collectionCount >= UpperBoundLimit)
                RemoveRange(0, Count + collectionCount - UpperBoundLimit);
        }
    }
}