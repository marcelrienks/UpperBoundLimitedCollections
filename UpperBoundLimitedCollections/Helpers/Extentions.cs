using System.Collections.Generic;

namespace UpperBoundLimitedCollections.Helpers
{
    public static class Extentions
    {
        /// <summary>
        /// Wraps this object instance into an IEnumerable<T> consisting of a single item.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="item">The instance that will be wrapped.</param>
        /// <returns>An IEnumerable<T> consisting of a single item.</returns>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}
