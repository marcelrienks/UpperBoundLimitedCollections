namespace UpperBoundLimitedCollections.Helpers
{
    public static class Calculators
    {
        /// <summary>
        /// Calculate the range of items to be removed in order to maintain the upper bound limit.
        /// </summary>
        /// <param name="currentCount">The size of the current <c>System.Collections.Generic.ICollection</c></param>
        /// <param name="collectionCount">The size of the collection to be added to the current <c>System.Collections.Generic.ICollection</c></param>
        /// <param name="upperBoundLimit">The upper bound limit to be enforced</param>
        /// <returns>The size of the range to be removed from the <c>System.Collections.Generic.ICollection</c></returns>
        public static int CalculateRangeToBeRemoved(int currentCount, int collectionCount, int upperBoundLimit)
        {
            // Determine the range of items to be removed, in order to maintain the upperBoundLimit
            if (currentCount + collectionCount >= upperBoundLimit)
                return currentCount - upperBoundLimit + collectionCount;

            return 0;
        }
    }
}
