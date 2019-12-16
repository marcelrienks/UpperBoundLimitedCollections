using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.List;

namespace UpperBoundLimitedCollections.Tests.List
{
    [TestClass]
    public class UpperBoundLimitedListTests
    {
        [TestMethod]
        public void AddItemWithNullItem()
        {
            // Expected
            string expectedItem = null;
            var expectedCount = 0;

            // Variables
            var list = new UpperBoundLimitedList<string>();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => list.Add(expectedItem, expectedCount), "The param 'item' cannot be null.");
        }

        [TestMethod]
        public void AddItemWithUpperBoundLimitOfZero()
        {
            // Expected
            string expectedItem = "1";
            var expectedCount = 0;

            // Variables
            var list = new UpperBoundLimitedList<string>();

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Add(expectedItem, expectedCount), "The param 'upperBoundLimit' must be greater than 0.");
        }

        [TestMethod]
        public void AddItemWithCountBelowLimit()
        {
            // Expected
            var expectedItem = "3";
            var expectedCount = 2;

            // Function
            var list = new UpperBoundLimitedList<string>() { "1", "2" };

            // Assert
            AddItemAndAssert(expectedItem, expectedCount, list);
        }

        [TestMethod]
        public void AddItemWithCountAtLimit()
        {
            // Expected
            var expectedItem = "4";
            var expectedCount = 3;

            // Function
            var list = new UpperBoundLimitedList<string>() { "1", "2", "3" };

            // Assert
            AddItemAndAssert(expectedItem, expectedCount, list);
        }

        [TestMethod]
        public void AddItemWithCountAboveLimit()
        {
            // Function
            var expectedItem = "5";
            var expectedCount = 3;

            // Variables
            var list = new UpperBoundLimitedList<string>() { "1", "2", "3", "4" };

            // Assert
            AddItemAndAssert(expectedItem, expectedCount, list);
        }

        private void AddItemAndAssert(string expectedItem, int upperBoundLimit, UpperBoundLimitedList<string> list)
        {
            // Add an item to this list, setting the UpperBoundLimit
            list.Add(expectedItem, upperBoundLimit);

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
