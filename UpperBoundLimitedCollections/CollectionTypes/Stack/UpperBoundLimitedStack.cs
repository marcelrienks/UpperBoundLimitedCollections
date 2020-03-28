using System.Collections.Generic;
using UpperBoundLimitedCollections.Handlers;
using UpperBoundLimitedCollections.Helpers;

namespace UpperBoundLimitedCollections.CollectionTypes.Stack
{
    public class UpperBoundLimitedStack<T> : Stack<T>
    {
        public UpperBoundLimitedStack()
        {
        }

        public UpperBoundLimitedStack(IEnumerable<T> collection) : base(collection)
        {
        }

        public UpperBoundLimitedStack(int capacity) : base(capacity)
        {
        }

        /// <summary>
        /// Push an item to the <c>System.Collections.Generic.Stack<T></c>,
        /// removing a range of items from the top of the stack in order to maintain the supplied upper bound limit.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.Stack<T></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.Stack<T></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public void Enqueue(T item, int upperBoundLimit)
        {
            Validators.ValidateParameters(upperBoundLimit);

            // Checks the limit and reduces the size of the list allow items to be added while maintaining upper bound limit
            UpperBoundLimitHandler.ReduceSize(this, upperBoundLimit);

            // Enqueue the item
            base.Push(item);
        }
    }
}
