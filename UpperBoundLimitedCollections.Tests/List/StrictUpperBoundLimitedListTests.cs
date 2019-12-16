using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.List;

namespace UpperBoundLimitedCollections.Tests.List
{
    [TestClass]
    public class StrictUpperBoundLimitedListTests
    {
        [TestMethod]
        public void InitializeStrictUpperBoundLimitedListWithZeroLimit()
        {
            // Expected
            var expectedCount = 0;

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StrictUpperBoundLimitedList<string>(expectedCount), "The param upperBoundLimit must be greater than 0.");
        }

        [TestMethod]
        public void AddItemWithNullItem()
        {
            // Expected
            string expectedItem = null;
            var expectedCount = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(expectedCount);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => list.Add(expectedItem), "The param 'item' cannot be null.");
        }

        /// <summary>
        /// Test adding an item to a list, where the list has a count below that of the upperBoundLimit supplied
        /// </summary>
        [TestMethod]
        public void AddItemWithCountBelowLimit()
        {
            // Expected
            var expectedItem = "3";
            var expectedCount = 2;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(expectedCount) { "1", "2" };

            // Assert
            AddItemAndAssert(expectedItem, expectedCount, list);
        }

        /// <summary>
        /// Test adding an item to a list, where the list has a count at that of the upperBoundLimit supplied
        /// </summary>
        [TestMethod]
        public void AddItemWithCountAtLimit()
        {
            // Expected
            var expectedItem = "4";
            var expectedCount = 3;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(expectedCount) { "1", "2", "3" };

            // Assert
            AddItemAndAssert(expectedItem, expectedCount, list);
        }

        /// <summary>
        /// Test adding an item to a list, where the list has a count above that of the upperBoundLimit supplied
        /// </summary>
        [TestMethod]
        public void AddItemWithCountAboveLimit()
        {
            // Function
            var expectedItem = "5";
            var expectedCount = 3;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(expectedCount) { "1", "2", "3", "4" };

            // Assert
            AddItemAndAssert(expectedItem, expectedCount, list);
        }

        /// <summary>
        /// Generic method to add an item, and assert based on suppllied params.
        /// </summary>
        /// <param name="expectedItem">The expected item to be added to the list.</param>
        /// <param name="upperBoundLimit">The upper bound limit to be appplied to the list.</param>
        /// <param name="list">The list to be added to.</param>
        private void AddItemAndAssert(string expectedItem, int upperBoundLimit, StrictUpperBoundLimitedList<string> list)
        {
            // Add an item to this list, setting the UpperBoundLimit
            list.Add(expectedItem);

            // Assert
            Assert.AreEqual(upperBoundLimit, list.Count);
            Assert.AreEqual(expectedItem, list[list.Count - 1]);
        }

        //TODO: AddRange

        //TODO: Insert

        //TODO: InsertRange

        //public void AddCollectionWithCountGreaterThanLimit()
        //{
        //    // Expected
        //    string expectedItem = "1";
        //    var expectedCount = 0;

        //    // Variables
        //    var list = new UpperBoundLimitedList<string>();

        //    // Assert
        //    Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Add(expectedItem, expectedCount), "The param 'collection' cannot be greater than param 'upperBoundLimit'.");
        //}
    }
}
