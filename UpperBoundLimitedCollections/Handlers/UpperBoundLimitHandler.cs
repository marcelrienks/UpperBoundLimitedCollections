using System;
using System.Collections.Generic;
using UpperBoundLimitedCollections.Helpers;

namespace UpperBoundLimitedCollections.Handlers
{
    public static class UpperBoundLimitHandler
    {
        /// <summary>
        /// Checks the supplied 'upperBoundLimit', and reduces the size of the 'list' collection by removing a range of items from the beginning in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <typeparam name="T">The type that is stored in this list</typeparam>
        /// <param name="list">The List collection to reduce the size of to maintain the upper bound limit.</param>
        /// <param name="rangeCount">The size of the new collection to be added</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'list')</exception>
        public static void ReduceSize<T>(List<T> list, int rangeCount, int upperBoundLimit)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "The argument cannot be null.");

            // Calculate and remove the required range in order to maintain the upperBoundLimit
            list.RemoveRange(0, Calculators.CalculateRangeToBeRemoved(list.Count, rangeCount, upperBoundLimit));
        }

        /// <summary>
        /// Checks the supplied 'upperBoundLimit', and reduces the size of the 'queue' collection by removing a range of items from the beginning in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <typeparam name="T">The type that is stored in this queue</typeparam>
        /// <param name="list">The List collection to reduce the size of to maintain the upper bound limit.</param>
        /// <param name="rangeCount">The size of the new collection to be added</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the queue. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'queue')</exception>
        public static void ReduceSize<T>(Queue<T> queue, int upperBoundLimit)
        {
            if (queue == null)
                throw new ArgumentNullException(nameof(queue), "The argument cannot be null.");

            // Calculate and remove the required range in order to maintain the upperBoundLimit
            var removeItemCount = Calculators.CalculateRangeToBeRemoved(queue.Count, 1, upperBoundLimit);
            for (int i = 0; i < removeItemCount; i++)
            {
                queue.Dequeue(); 
            }
        }

        /// <summary>
        /// Checks the supplied 'upperBoundLimit', and reduces the size of the 'dictionary' by removing a range of items from the beginning in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <typeparam name="TKey">The key type that is stored in this dictionary.</typeparam>
        /// <typeparam name="TValue">The value type that is stored in this dictionary.</typeparam>
        /// <param name="dictionary">The Dictionary to reduce the size of to maintain the upper bound limit.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the dictionary. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'dictionary')</exception>
        public static void ReduceSize<TKey, TValue>(Dictionary<TKey, TValue> dictionary, int upperBoundLimit)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary), "The argument cannot be null.");

            // Convert keys into an array
            var keys = new TKey[dictionary.Count];
            dictionary.Keys.CopyTo(keys, 0);

            // Calculate and remove the required range in order to maintain the upperBoundLimit
            var removeItemCount = Calculators.CalculateRangeToBeRemoved(dictionary.Count, 1, upperBoundLimit);
            for (int i = 0; i < removeItemCount; i++)
            {
                // Remove the calculated range from the dictionary, using the key array to access the correct key based on index
                dictionary.Remove(keys[i]);
            }
        }
    }
}
