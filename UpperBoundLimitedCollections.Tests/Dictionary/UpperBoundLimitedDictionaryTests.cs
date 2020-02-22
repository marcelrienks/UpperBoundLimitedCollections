using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.Dictionary;

namespace UpperBoundLimitedCollections.Tests.Dictionary
{
    [TestClass]
    public class UpperBoundLimitedDictionaryTests
    {
        #region Add

        /// <summary>
        /// Asserts that adding a null key to the dictionary causes an
        /// ArgumentNullException with error message of "The argument cannot be null. (Parameter 'item')"
        /// </summary>
        [TestMethod]
        public void AddNullKey()
        {
            // Expected
            string key = null;
            string value = null;
            var upperBoundLimit = 0;

            // Variables
            var dictionary = new UpperBoundLimitedDictionary<string, string>();

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => dictionary.Add(key, value, upperBoundLimit), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument cannot be null. (Parameter 'key')", exception.Message);
        }

        /// <summary>
        /// Asserts that adding an item to the dictionary, and setting the upper bound limit to 0 causes an
        /// ArgumentOutOfRangeException with error message 'The argument must be greater than 0.'
        /// </summary>
        [TestMethod]
        public void AddItemWithUpperBoundLimitOfZero()
        {
            // Expected
            var key = "1";
            var value = "one";
            var upperBoundLimit = 0;

            // Variables
            var dictionary = new UpperBoundLimitedDictionary<string, string>();

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => dictionary.Add(key, value, upperBoundLimit), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument must be greater than 0. (Parameter 'upperBoundLimit')\r\nActual value was 0.", exception.Message);
        }

        /// <summary>
        /// Asserts that adding an item to a dictionary with a size less than the UpperBoundLimit
        /// results in the item being appended to the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void AddItemToDictionaryWithSizeBelowUpperBoundLimit()
        {
            // Expected
            var key = "2";
            var value = "two";
            var upperBoundLimit = 2;

            // Variables
            var dictionary = new UpperBoundLimitedDictionary<string, string>
            {
                { "1", "one" }
            };

            // Assert
            AddItemAndAssert(key, value, upperBoundLimit, dictionary);
        }

        /// <summary>
        /// Asserts that adding an item to a dictionary with a size the same as the UpperBoundLimit
        /// results in the the first item in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemToDictionaryWithSizeAtUpperBoundLimit()
        {
            // Expected
            var key = "4";
            var value = "four";
            var upperBoundLimit = 3;

            // Variables
            var dictionary = new UpperBoundLimitedDictionary<string, string>
            {
                { "1", "one" },
                { "2", "two" },
                { "3", "three" }
            };

            // Assert
            AddItemAndAssert(key, value, upperBoundLimit, dictionary);
        }

        /// <summary>
        /// Asserts that adding an item to a dictionary with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemToListWithSizeAboveUpperBoundLimit()
        {
            // Expected
            var key = "5";
            var value = "five";
            var upperBoundLimit = 3;

            // Variables
            var dictionary = new UpperBoundLimitedDictionary<string, string>
            {
                { "1", "one" },
                { "2", "two" },
                { "3", "three" },
                { "4", "four" }
            };

            // Assert
            AddItemAndAssert(key, value, upperBoundLimit, dictionary);
        }

        /// <summary>
        /// Adds an item to the dictionary supplied, passing in the upperBoundLimit.
        /// Then asserts that dictionary size matches upperBoundLimit, and that the last item in the list matches the item suplied.
        /// </summary>
        /// <param name="key">the key to be added to the UpperBoundLimtedList</param>
        /// <param name="value">the value to be added to the UpperBoundLimtedList</param>
        /// <param name="upperBoundLimit">upper bound limit to be enforced</param>
        /// <param name="dictionary">the UpperBoundLimteddictionary to be added to</param>
        private void AddItemAndAssert(string key, string value, int upperBoundLimit, UpperBoundLimitedDictionary<string, string> dictionary)
        {
            // Add an item to this list, setting the UpperBoundLimit
            dictionary.Add(key, value, upperBoundLimit);

            // Assert
            Assert.AreEqual(upperBoundLimit, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey(key));
            Assert.IsTrue(dictionary.ContainsValue(value));
        }

        #endregion

        //Note: no need to test the 'TryAdd' method, as it uses the same workflow and methods that the above tests prove
    }
}
