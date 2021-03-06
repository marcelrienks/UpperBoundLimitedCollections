﻿using System.Collections.Generic;
using UpperBoundLimitedCollections.Handlers;
using UpperBoundLimitedCollections.Helpers;

namespace UpperBoundLimitedCollections.CollectionTypes.Queue
{
    public class StrictUpperBoundLimitedQueue<T> : Queue<T>
    {
        /// <summary>
        /// The maximum upper bound limit that should be applied to the queue. This value must be greater than 0.
        /// </summary>
        public int UpperBoundLimit { get; private set; }

        public StrictUpperBoundLimitedQueue()
        {
        }

        public StrictUpperBoundLimitedQueue(IEnumerable<T> collection) : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of an 'StrictUpperBoundLimitedQueue' that extends the <c>System.Collections.Generic.Queue<T></c>,
        /// where the maximum upper bound limit of the queue is controlled by removing a range of items from the beginning of the queue if required.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument upperBoundLimit must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public StrictUpperBoundLimitedQueue(int upperBoundLimit) : base(upperBoundLimit)
        {
            Validators.ValidateParameters(upperBoundLimit);

            UpperBoundLimit = upperBoundLimit;
        }

        /// <summary>
        /// Enqueue an item to the <c>System.Collections.Generic.Queue<T></c>,
        /// removing a range of items from the beginning of the queue in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.Queue<T></c>.</param>
        public new void Enqueue(T item)
        {
            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, UpperBoundLimit);

            // Enqueue the item
            base.Enqueue(item);
        }
    }
}