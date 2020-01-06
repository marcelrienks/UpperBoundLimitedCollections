using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UpperBoundLimitedCollections.List;

namespace UpperBoundLimitedCollections.Tests.List
{
    [TestClass]
    public class StrictUpperBoundLimitedListTests
    {
        //TODO: Once UpperBoundLimitedListTests is complete, make sure that all tests in this class match, including comments

        [TestMethod]
        public void InitializeStrictUpperBoundLimitedListWithZeroLimit()
        {
            // Expected
            var expectedCount = 0;

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StrictUpperBoundLimitedList<string>(expectedCount), "The param upperBoundLimit must be greater than 0.");
        }

        #region Add

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
            var expectedItem = "2";
            var expectedCount = 2;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(expectedCount) { "1" };

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

        #endregion

        #region AddRange

        [TestMethod]
        public void AddNullRange()
        {
            // Expected
            IEnumerable<string> rangeToAdd = null;
            var expectedCount = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(expectedCount);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => list.AddRange(rangeToAdd), "The param 'collection' cannot be null.");
        }

        [TestMethod]
        public void AddCollectionWithCountGreaterThanLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "1", "2" };
            var expectedCount = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(expectedCount);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddRange(rangeToAdd), "The param 'collection' size cannot be greater than param 'upperBoundLimit'.");
        }

        [TestMethod]
        public void AddRangeWithListCountBelowLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "3", "4" };
            var expectedCount = 3;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(expectedCount) { "1", "2" };

            // Assert
            AddRangeItemAndAssert(rangeToAdd, list);
        }

        [TestMethod]
        public void AddRangeWithListCountAtLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "4", "5" };
            var expectedCount = 3;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(expectedCount) { "1", "2", "3" };

            // Assert
            AddRangeItemAndAssert(rangeToAdd, list);
        }

        [TestMethod]
        public void AddRangeWithListCountAboveLimit()
        {
            // Function
            var rangeToAdd = new List<string>() { "5", "6" };
            var expectedCount = 3;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(expectedCount) { "1", "2", "3", "4" };

            // Assert
            AddRangeItemAndAssert(rangeToAdd, list);
        }

        private void AddRangeItemAndAssert(List<string> expectedRange, StrictUpperBoundLimitedList<string> list)
        {
            // Add an item to this list, setting the UpperBoundLimit
            list.AddRange(expectedRange);

            // Assert
            Assert.AreEqual(list.UpperBoundLimit, list.Count);
            Assert.AreEqual(expectedRange[expectedRange.Count - 1], list[list.Count - 1]);
        }

        #endregion

        //TODO: Insert

        //TODO: InsertRange
    }
}
