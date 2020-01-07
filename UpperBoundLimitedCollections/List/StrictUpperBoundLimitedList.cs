using UpperBoundLimitedCollections.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpperBoundLimitedCollections.List
{
    public class StrictUpperBoundLimitedList<T> : List<T>
    {
        /// <summary>
        /// The maximum upper bound limit that should be applied to the list. This value must be greater than 0.
        /// </summary>
        public int UpperBoundLimit { get; private set; }

        /// <summary>
        /// Initializes a new instance of an 'StrictUpperBoundLimitedList' that extends the <c>System.Collections.Generic.List</c>,
        /// where the maximum upper bound limit of the list is controlled by removing a range of items from the beginning of the list if required.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The param upperBoundLimit must be greater than 0.</exception>
        public StrictUpperBoundLimitedList(int upperBoundLimit)
        {
            // upperBoundLimit must be larger than 0
            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The param upperBoundLimit must be greater than 0.");

            UpperBoundLimit = upperBoundLimit;
        }

        /// <summary>
        /// Appends an item to the end of the <c>System.Collections.Generic.ICollection</c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <exception cref="System.ArgumentNullException">The param 'item' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' size cannot be greater than param 'upperBoundLimit'.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        public new void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "The argument cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, item.Yield().Count(), UpperBoundLimit);

            // Add the item to the base class
            base.Add(item);
        }

        /// <summary>
        /// Appends a range of items to the end of the <c>System.Collections.Generic.ICollection</c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="collection">The collection of objects to append to the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <exception cref="System.ArgumentNullException">The param 'collection' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' size cannot be greater than param 'upperBoundLimit'.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        public new void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), "The argument cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, collection.Count(), UpperBoundLimit);

            // Add range to the base class
            base.AddRange(collection);
        }

        /// <summary>
        /// Inserts an item into the <c>System.Collections.Generic.ICollection</c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to be inserted into the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <exception cref="System.ArgumentNullException">The param 'item' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' size cannot be greater than param 'upperBoundLimit'.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        public new void Insert(int index, T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "The argument cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, item.Yield().Count(), UpperBoundLimit);

            // Insert item to the base class
            base.Insert(index, item);
        }

        /// <summary>
        /// Inserts a range of items into the<c> System.Collections.Generic.ICollection</c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit for this collection.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="collection">The collection of objects to be inserted into the <c>System.Collections.Generic.ICollection</c>.</param>
        /// <exception cref="System.ArgumentNullException">The param 'collection' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' size cannot be greater than param 'upperBoundLimit'.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), "The argument cannot be null.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, collection.Count(), UpperBoundLimit);

            // Insert range to the base class
            base.InsertRange(index, collection);
        }
    }
}