﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.CollectionTypes.Dictionary;

namespace UpperBoundLimitedCollections.Tests.Queue
{
    [TestClass]
    public class StrictUpperBoundLimitedQueueTests
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
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StrictUpperBoundLimitedQueue<string>(upperBoundLimit), "Exception thrown does not match expected type 'ArgumentNullException'.");
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
            var queue = new StrictUpperBoundLimitedQueue<string>(upperBoundLimit);

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Queue with a size less than the UpperBoundLimit
        /// results in the item being appended to the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void AddItemToQueueWithSizeBelowUpperBoundLimit()
        {
            // Expected
            var item = "two";
            var upperBoundLimit = 2;

            // Variables
            var queue = new StrictUpperBoundLimitedQueue<string>(upperBoundLimit);
            queue.Enqueue("one");

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Queue with a size the same as the UpperBoundLimit
        /// results in the the first item in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemToQueueWithSizeAtUpperBoundLimit()
        {
            // Expected
            var item = "four";
            var upperBoundLimit = 3;

            // Variables
            var queue = new StrictUpperBoundLimitedQueue<string>(upperBoundLimit);
            queue.Enqueue("one");
            queue.Enqueue("two");
            queue.Enqueue("three");

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Queue with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemToListWithSizeAboveUpperBoundLimit()
        {
            // Expected
            var item = "five";
            var upperBoundLimit = 3;

            // Variables
            var queue = new StrictUpperBoundLimitedQueue<string>(upperBoundLimit);
            queue.Enqueue("one");
            queue.Enqueue("two");
            queue.Enqueue("three");
            queue.Enqueue("four");

            // Assert
            AddItemAndAssert(item, queue);
        }

        /// <summary>
        /// Adds an item to the Queue supplied, passing in the upperBoundLimit.
        /// Then asserts that Queue size matches upperBoundLimit, and that the last item in the list matches the item suplied.
        /// </summary>
        /// <param name="key">the key to be added to the UpperBoundLimtedList</param>
        /// <param name="value">the value to be added to the UpperBoundLimtedList</param>
        /// <param name="upperBoundLimit">upper bound limit to be enforced</param>
        /// <param name="queue">the UpperBoundLimtedQueue to be added to</param>
        private void AddItemAndAssert(string item, StrictUpperBoundLimitedQueue<string> queue)
        {
            // Add an item to this queue, setting the UpperBoundLimit
            queue.Enqueue(item);

            // Assert
            Assert.AreEqual(queue.UpperBoundLimit, queue.Count);
            Assert.IsTrue(queue.Contains(item));
        }

        #endregion

        //Note: no need to test the 'TryAdd' method, as it uses the same workflow and methods that the above tests prove
    }
}
