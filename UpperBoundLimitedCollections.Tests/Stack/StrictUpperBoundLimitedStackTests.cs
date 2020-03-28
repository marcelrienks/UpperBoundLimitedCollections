using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.CollectionTypes.Stack;

namespace UpperBoundLimitedCollections.Tests.Stack
{
    [TestClass]
    public class StrictUpperBoundLimitedStackTests
    {
        /// <summary>
        /// Asserts that initialising a StrictStrictUpperBoundLimitedList object fails if the limit is 0
        /// </summary>
        [TestMethod]
        public void InitializeStrictStrictUpperBoundLimitedListWithZeroLimit()
        {
            // Expected
            var upperBoundLimit = 0;

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StrictUpperBoundLimitedStack<string>(upperBoundLimit), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument must be greater than 0. (Parameter 'upperBoundLimit')\r\nActual value was 0.", exception.Message);
        }

        #region Add

        /// <summary>
        /// Asserts that adding a null item is allowed
        /// </summary>
        [TestMethod]
        public void AddNullItem()
        {
            // Expected
            string item = null;
            var upperBoundLimit = 1;

            // Variables
            var queue = new StrictUpperBoundLimitedStack<string>(upperBoundLimit);

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Queue with a size less than the UpperBoundLimit
        /// results in the item being appended to the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void AddItemWithSizeBelowUpperBoundLimit()
        {
            // Expected
            var item = "two";
            var upperBoundLimit = 2;

            // Variables
            var queue = new StrictUpperBoundLimitedStack<string>(upperBoundLimit);
            queue.Push("one");

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Stack with a size the same as the UpperBoundLimit
        /// results in the the first item in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemWithSizeAtUpperBoundLimit()
        {
            // Expected
            var item = "four";
            var upperBoundLimit = 3;

            // Variables
            var queue = new StrictUpperBoundLimitedStack<string>(upperBoundLimit);
            queue.Push("one");
            queue.Push("two");
            queue.Push("three");

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Stack with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemToListWithSizeAboveUpperBoundLimit()
        {
            // Expected
            var item = "five";
            var upperBoundLimit = 3;

            // Variables
            var queue = new StrictUpperBoundLimitedStack<string>(upperBoundLimit);
            queue.Push("one");
            queue.Push("two");
            queue.Push("three");
            queue.Push("four");

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Adds an item to the Stack supplied, passing in the upperBoundLimit.
        /// Then asserts that Stack size matches upperBoundLimit, and that the last item in the list matches the item suplied.
        /// </summary>
        /// <param name="item">the item to be added to the StrictUpperBoundLimitedStack</param>
        /// <param name="queue">the UpperBoundLimtedQueue to be added to</param>
        private void AddItemAndAssert(string item, StrictUpperBoundLimitedStack<string> queue)
        {
            // Add an item to this queue, setting the UpperBoundLimit
            queue.Push(item);

            // Assert
            Assert.AreEqual(queue.UpperBoundLimit, queue.Count);
            Assert.IsTrue(queue.Contains(item));
        }

        #endregion
    }
}
