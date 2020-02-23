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
        /// Initializes a new instance of an 'StrictUpperBoundLimitedList' that extends the <c>System.Collections.Generic.List<T></c>,
        /// where the maximum upper bound limit of the list is controlled by removing a range of items from the beginning of the list if required.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument upperBoundLimit must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public StrictUpperBoundLimitedList(int upperBoundLimit)
        {
            // upperBoundLimit must be larger than 0
            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The argument must be greater than 0.");

            UpperBoundLimit = upperBoundLimit;
        }

        /// <summary>
        /// Appends an item to the end of the <c>System.Collections.Generic.List<T></c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.List<T></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        public new void Add(T item)
        {
            ValidateItemParameter(item);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, item.Yield().Count(), UpperBoundLimit);

            // Add the item to the base class
            base.Add(item);
        }

        /// <summary>
        /// Appends a range of items to the end of the <c>System.Collections.Generic.List<T></c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="range">The collection of objects to append to the <c>System.Collections.Generic.List<T></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')</exception>
        public new void AddRange(IEnumerable<T> range)
        {
            ValidateRangeParameter(range);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, range.Count(), UpperBoundLimit);

            // Add range to the base class
            base.AddRange(range);
        }

        /// <summary>
        /// Inserts an item into the <c>System.Collections.Generic.List<T></c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to be inserted into the <c>System.Collections.Generic.List<T></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        public new void Insert(int index, T item)
        {
            ValidateItemParameter(item);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, item.Yield().Count(), UpperBoundLimit);

            // Insert item to the base class
            base.Insert(index, item);
        }

        /// <summary>
        /// Inserts a range of items into the<c> System.Collections.Generic.List<T></c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit for this collection.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="range">The collection of objects to be inserted into the <c>System.Collections.Generic.List<T></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')</exception>
        public new void InsertRange(int index, IEnumerable<T> range)
        {
            ValidateRangeParameter(range);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, range.Count(), UpperBoundLimit);

            // Insert range to the base class
            base.InsertRange(index, range);
        }

        /// <summary>
        /// Validate the key and upperBoundLimit parameters supplied.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.List<T></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        private void ValidateItemParameter(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "The argument cannot be null.");
        }

        /// <summary>
        /// Validate the key and upperBoundLimit parameters supplied.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.List<T></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')</exception>
        private void ValidateRangeParameter(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException(nameof(range), "The argument cannot be null.");

            if (range.Count() > UpperBoundLimit)
                throw new ArgumentOutOfRangeException(nameof(range), range.Count(), "The range size cannot be greater than the argument 'upperBoundLimit'.");
        }
    }
}