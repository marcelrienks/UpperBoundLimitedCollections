﻿using UpperBoundLimitedCollections.Helpers;
using System.Collections.Generic;
using System;

namespace UpperBoundLimitedCollections.Dictionary
{
    public class UpperBoundLimitedDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// Adds a dictionary item to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>,
        /// removing a range of items from the beginning of the dictionary in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="key">The key of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="value">The value of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public void Add(TKey key, TValue value, int upperBoundLimit)
        {
            ValidateUpperBoundLimitedDictionary(key, value, upperBoundLimit);

            // Add the key value pair to 'this'
            Add(key, value);
        }

        /// <summary>
        /// Attempts to add a dictionary item to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>,
        /// removing a range of items from the beginning of the dictionary in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="key">The key of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="value">The value of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'item')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public bool TryAdd(TKey key, TValue value, int upperBoundLimit)
        {
            ValidateUpperBoundLimitedDictionary(key, value, upperBoundLimit);

            // Add the key value pair to 'this'
            return TryAdd(key, value);
        }

        /// <summary>
        /// Validate arguments, and check the limit and reduce the size of the dictionary if neccesary.
        /// </summary>
        /// <param name="key">The key of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="value">The value of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>. This value must be greater than 0.</param>
        private void ValidateUpperBoundLimitedDictionary(TKey key, TValue value, int upperBoundLimit)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The argument cannot be null.");

            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The argument must be greater than 0.");

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.CheckLimitAndReduceSize(this, upperBoundLimit);
        }
    }
}