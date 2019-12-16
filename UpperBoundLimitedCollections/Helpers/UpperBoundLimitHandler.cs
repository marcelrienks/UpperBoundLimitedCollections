using Helpers.UpperBoundLimitedCollections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpperBoundLimitedCollections.Helpers
{
    public static class UpperBoundLimitHandler
    {
        /// <summary>
        /// Handles the upper bound limit. If this.Count combined with collection count is greater or equal to 'upperBoundlimit',
        /// a range of items from the beginning of the list will be removed in order to maintain the maximum upper bound limit.
        /// </summary>
        /// <param name="collectionCount"></param>
        public static void CheckAndRemoveRange<T>(List<T> list, IEnumerable<T> collection, int upperBoundLimit)
        {
            var collectionCount = collection.Count();

            if (list == null)
                throw new ArgumentNullException(nameof(list), "The param 'list' cannot be null.");

            // upperBoundLimit must be larger than 0
            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The param 'upperBoundLimit' must be greater than 0.");

            // collection cannot be greater than the UpperBoundLimit
            if (collectionCount > upperBoundLimit)
                throw new ArgumentOutOfRangeException(nameof(collection), collectionCount, "The size of param 'collection' cannot be greater than param 'upperBoundLimit'.");

            // Calculate and remove the required range in order to maintain the upperBoundLimit
            list.RemoveRange(0, RangeCalculator.CalculateRangeToBeRemoved(list.Count, upperBoundLimit, collectionCount));
        }
    }
}
