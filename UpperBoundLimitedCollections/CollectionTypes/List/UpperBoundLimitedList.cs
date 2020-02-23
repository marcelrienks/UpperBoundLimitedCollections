using System;
using System.Collections.Generic;
using System.Linq;
using UpperBoundLimitedCollections.Handlers;
using UpperBoundLimitedCollections.Helpers;

namespace UpperBoundLimitedCollections.CollectionTypes.List
{
    public class UpperBoundLimitedList<T> : List<T>
    {
        /// <summary>
        /// Appends an item to the end of the <c>System.Collections.Generic.List<T></c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.List<T></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.List<T></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public void Add(T item, int upperBoundLimit)
        {
            Validators.ValidateParameters(upperBoundLimit);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, item.Yield().Count(), upperBoundLimit);

            // Add the item to 'this'
            base.Add(item);
        }

        /// <summary>
        /// Appends a range of items to the end of the <c>System.Collections.Generic.List<T></c>,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="range">The collection of objects to append to the <c>System.Collections.Generic.List<T></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.List<T></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentNullException">The range size must be greater than 0. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentNullException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public void AddRange(IEnumerable<T> range, int upperBoundLimit)
        {
            Validators.ValidateParameters(range, upperBoundLimit);

            if (range.Count() > upperBoundLimit)
                throw new ArgumentOutOfRangeException(nameof(range), range.Count(), "The range size cannot be greater than the argument 'upperBoundLimit'.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, range.Count(), upperBoundLimit);

            // Add range to 'this'
            base.AddRange(range);
        }

        /// <summary>
        /// Inserts an item into the <c>System.Collections.Generic.List<T></c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to be inserted into the <c>System.Collections.Generic.List<T></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.List<T></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public void Insert(int index, T item, int upperBoundLimit)
        {
            Validators.ValidateParameters(upperBoundLimit);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, item.Yield().Count(), upperBoundLimit);

            // Inssert item to 'this'
            base.Insert(index, item);
        }

        /// <summary>
        /// Inserts a range of items into the<c> System.Collections.Generic.List<T></c> at an index point,
        /// removing a range of items from the beginning of the list in order to maintain the supplied upper bound limit for this collection.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="range">The collection of objects to be inserted into the <c>System.Collections.Generic.List<T></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.List<T></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentNullException">The range size must be greater than 0. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentNullException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public void InsertRange(int index, IEnumerable<T> range, int upperBoundLimit)
        {
            Validators.ValidateParameters(range, upperBoundLimit);

            if (range.Count() > upperBoundLimit)
                throw new ArgumentOutOfRangeException(nameof(range), range.Count(), "The range size cannot be greater than the argument 'upperBoundLimit'.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, range.Count(), upperBoundLimit);

            // Insert range to 'this'
            base.InsertRange(index, range);
        }
    }
}