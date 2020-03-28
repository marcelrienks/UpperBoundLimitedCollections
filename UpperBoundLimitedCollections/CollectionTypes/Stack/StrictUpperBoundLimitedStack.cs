using System;
using System.Collections.Generic;
using System.Text;
using UpperBoundLimitedCollections.Handlers;
using UpperBoundLimitedCollections.Helpers;

namespace UpperBoundLimitedCollections.CollectionTypes.Stack
{
    public class StrictUpperBoundLimitedStack<T> : Stack<T>
    {
        /// <summary>
        /// The maximum upper bound limit that should be applied to the stack. This value must be greater than 0.
        /// </summary>
        public int UpperBoundLimit { get; private set; }

        public StrictUpperBoundLimitedStack()
        {
        }

        public StrictUpperBoundLimitedStack(IEnumerable<T> collection) : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of an 'StrictUpperBoundLimitedStack' that extends the <c>System.Collections.Generic.Stack<T></c>,
        /// where the maximum upper bound limit of the list is controlled by removing a range of items from the top of the stack if required.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the list. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument upperBoundLimit must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public StrictUpperBoundLimitedStack(int upperBoundLimit) : base(upperBoundLimit)
        {
            Validators.ValidateParameters(upperBoundLimit);

            UpperBoundLimit = upperBoundLimit;
        }

        /// <summary>
        /// Enqueue an item to the <c>System.Collections.Generic.Stack<T></c>,
        /// removing a range of items from the beginning of the queue in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.Stack<T></c>.</param>
        public new void Push(T item)
        {
            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, UpperBoundLimit);

            // Enqueue the item
            base.Push(item);
        }
    }
}
