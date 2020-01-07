﻿using System;
using System.Collections.Generic;

namespace UpperBoundLimitedCollections.Helpers
{
    public static class UpperBoundLimitHandler
    {
        /// <summary>
        /// Checks the supplied 'upperBoundLimit', and reduces the size of the 'list' collection by removing a range of items from the beginning in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The List collection to reduce the size of to maintain the upper bound limit.</param>
        /// <param name="rangeCount">The size of the new collection to be added </param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The param 'list' cannot be null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'upperBoundLimit' must be greater than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The param 'collection' size cannot be greater than param 'upperBoundLimit'.</exception>
        public static void CheckLimitAndReduceSize<T>(List<T> list, int rangeCount, int upperBoundLimit)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "The argument cannot be null.");

            // Calculate and remove the required range in order to maintain the upperBoundLimit
            list.RemoveRange(0, Calculators.CalculateRangeToBeRemoved(list.Count, upperBoundLimit, rangeCount));
        }
    }
}
