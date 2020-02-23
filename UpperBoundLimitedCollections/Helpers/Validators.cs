using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperBoundLimitedCollections.Helpers
{
    public static class Validators
    {
        /// <summary>
        /// Validate the parameters supplied.
        /// </summary>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.List<T></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public static void ValidateParameters(int upperBoundLimit)
        {
            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The argument must be greater than 0.");
        }

        /// <summary>
        /// Validate the parameters supplied.
        /// </summary>
        /// <param name="item">The object to append to the <c>System.Collections.Generic.List<T></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.List<T></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The range size must be greater than 0. (Parameter 'range')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')</exception>
        public static void ValidateParameters<T>(IEnumerable<T> range, int upperBoundLimit)
        {
            if (range == null)
                throw new ArgumentNullException(nameof(range), "The argument cannot be null.");

            if (!range.Any())
                throw new ArgumentOutOfRangeException(nameof(range), upperBoundLimit, "The range size must be greater than 0.");

            ValidateParameters(upperBoundLimit);

            if (range.Count() > upperBoundLimit)
                throw new ArgumentOutOfRangeException(nameof(range), range.Count(), "The range size cannot be greater than the argument 'upperBoundLimit'.");
        }

        /// <summary>
        /// Validate the parameters supplied.
        /// </summary>
        /// <param name="key">The key of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'key')</exception>
        public static void ValidateParameters<TKey>(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The argument cannot be null.");
        }

        /// <summary>
        /// Validate the parameters supplied.
        /// </summary>
        /// <param name="key">The key of the dictionary item to add to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>.</param>
        /// <param name="upperBoundLimit">The maximum upper bound limit that should be applied to the <c>System.Collections.Generic.Dictionary<TKey, TValue></c>. This value must be greater than 0.</param>
        /// <exception cref="System.ArgumentNullException">The argument cannot be null. (Parameter 'key')</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The argument must be greater than 0. (Parameter 'upperBoundLimit')</exception>
        public static void ValidateParameters<TKey>(TKey key, int upperBoundLimit)
        {
            ValidateParameters(key);

            if (upperBoundLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(upperBoundLimit), upperBoundLimit, "The argument must be greater than 0.");
        }
    }
}
