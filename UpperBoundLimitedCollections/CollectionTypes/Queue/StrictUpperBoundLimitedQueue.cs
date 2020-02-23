using System.Collections.Generic;
using UpperBoundLimitedCollections.Handlers;
using UpperBoundLimitedCollections.Helpers;

namespace UpperBoundLimitedCollections.CollectionTypes.Dictionary
{
    public class StrictUpperBoundLimitedQueue<T> : Queue<T>
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
        public StrictUpperBoundLimitedQueue(int upperBoundLimit)
        {
            Validators.ValidateParameters(upperBoundLimit);

            UpperBoundLimit = upperBoundLimit;
        }

        /// <summary>
        /// Enqueue an item to the <c>System.Collections.Generic.Queue<T></c>,
        /// removing a range of items from the beginning of the dictionary in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.Queue<T></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.Queue<T></c>. This value must be greater than 0.</param>
        public new void Enqueue(T item)
        {
            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, UpperBoundLimit);

            // Enqueue the item
            base.Enqueue(item);
        }
    }
}