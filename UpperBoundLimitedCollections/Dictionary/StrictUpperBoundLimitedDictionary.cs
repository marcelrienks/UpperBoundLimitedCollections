using UpperBoundLimitedCollections.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpperBoundLimitedCollections.Dictionary
{
    public class StrictUpperBoundLimitedDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// The maximum upper bound limit that should be applied to the dictionary. This value must be greater than 0.
        /// </summary>
        public int UpperBoundLimit { get; private set; }

        /// <summary>
        /// Initializes a new instance of an 'StrictUpperBoundLimitedList' that extends the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>,
        /// where the maximum upper bound limit of the list is controlled by removing a range of items from the beginning of the list if required.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument upperBoundLimit must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public StrictUpperBoundLimitedDictionary(int upperBoundLimit)
        {
            // upperBoundLimit must be larger than 0
            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The argument must be greater than 0.");

            UpperBoundLimit = upperBoundLimit;
        }

        /// <summary>
        /// Adds a dictionary item to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>,
        /// removing a range of items from the beginning of the dictionary in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        public new void Add(TKey key, TValue value)
        {
            ValidateParameters(key);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, UpperBoundLimit);

            // Add the item to the base class
            base.Add(key, value);
        }

        /// <summary>
        /// Adds a dictionary item to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>,
        /// removing a range of items from the beginning of the dictionary in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        public new bool TryAdd(TKey key, TValue value)
        {
            ValidateParameters(key);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, UpperBoundLimit);

            // Add the item to the base class
            return base.TryAdd(key, value);
        }

        /// <summary>
        /// Validate the key and upperBoundLimit parameters supplied.
        /// </summary>
        /// <param name="key">The key of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        private void ValidateParameters(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The argument cannot be null.");
        }
    }
}