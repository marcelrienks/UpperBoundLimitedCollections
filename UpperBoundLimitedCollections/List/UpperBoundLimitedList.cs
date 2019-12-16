using UpperBoundLimitedCollections.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UpperBoundLimitedCollections.List
{
    public class UpperBoundLimitedList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of an 'UpperBoundLimitedList' that extends the <c>System.Collections.Generic.List</c>,
        /// where the supplied upper bound limit of the list is controlled by removing a range of items from the beginning of the list if required.
        /// </summary>
        public UpperBoundLimitedList()
        {

        }

        /// <summary>
        /// Appends an item to the end of the <c>System.Collections.Generic.ICollection</c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The param 'item' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' cannot be greater than param 'upperBoundLimit'.</exception>
        public void Add(T item, int upperBoundLimit)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "The param 'item' cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, item.Yield().Count(), upperBoundLimit);

            // Add the item to 'this'
            Add(item);
        }

        /// <summary>
        /// Appends a range of items to the end of the <c>System.Collections.Generic.ICollection</c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="collection">The collection of objects to append to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The param 'collection' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' cannot be greater than param 'upperBoundLimit'.</exception>
        public void AddRange(IEnumerable<T> collection, int upperBoundLimit)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), "The param 'collection' cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, collection.Count(), upperBoundLimit);

            // Add range to 'this'
            AddRange(collection, upperBoundLimit);
        }

        /// <summary>
        /// Inserts an item into the <c>System.Collections.Generic.ICollection</c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to be inserted into the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The param 'item' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' cannot be greater than param 'upperBoundLimit'.</exception>
        public void Insert(int index, T item, int upperBoundLimit)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "The param 'item' cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, item.Yield().Count(), upperBoundLimit);

            // Inssert item to 'this'
            Insert(index, item);
        }

        /// <summary>
        /// Inserts a range of items into the<c> System.Collections.Generic.ICollection</c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit for this collection.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="collection">The collection of objects to be inserted into the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The param 'collection' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' cannot be greater than param 'upperBoundLimit'.</exception>
        public void InsertRange(int index, IEnumerable<T> collection, int upperBoundLimit)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), "The param 'collection' cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, collection.Count(), upperBoundLimit);

            // Insert range to 'this'
            InsertRange(index, collection);
        }
    }
}