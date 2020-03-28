using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.CollectionTypes.Stack;

namespace UpperBoundLimitedCollections.Tests.Stack
{
    [TestClass]
    public class UpperBoundLimitedStackTests
    {
        #region Add

        /// <summary>
        /// Asserts that adding an item to the Stack, and setting the upper bound limit to 0 causes an
        /// ArgumentOutOfRangeException with error message 'The argument must be greater than 0.'
        /// </summary>
        [TestMethod]
        public void AddItemWithUpperBoundLimitOfZero()
        {
            // Expected
            var item = "one";
            var upperBoundLimit = 0;

            // Variables
            var queue = new UpperBoundLimitedStack<string>();

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => queue.Enqueue(item, upperBoundLimit), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument must be greater than 0. (Parameter 'upperBoundLimit')\r\nActual value was 0.", exception.Message);
        }

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
            var queue = new UpperBoundLimitedStack<string>();

            // Assert
            AddItemAndAssert(item, upperBoundLimit, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Stack with a size less than the UpperBoundLimit
        /// results in the item being appended to the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void AddItemWithSizeBelowUpperBoundLimit()
        {
            // Expected
            var item = "two";
            var upperBoundLimit = 2;

            // Variables
            var queue = new UpperBoundLimitedStack<string>();
            queue.Push("one");

            // Assert
            AddItemAndAssert(item, upperBoundLimit, queue);
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
            var queue = new UpperBoundLimitedStack<string>();
            queue.Push("one");
            queue.Push("two");
            queue.Push("three");

            // Assert
            AddItemAndAssert(item, upperBoundLimit, queue);
        }

        /// <summary>
        /// Asserts that adding an item to a Stack with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemWithSizeAboveUpperBoundLimit()
        {
            // Expected
            var item = "five";
            var upperBoundLimit = 3;

            // Variables
            var queue = new UpperBoundLimitedStack<string>();
            queue.Push("one");
            queue.Push("two");
            queue.Push("three");
            queue.Push("four");

            // Assert
            AddItemAndAssert(item, upperBoundLimit, queue);
        }

        /// <summary>
        /// Adds an item to the Stack supplied, passing in the upperBoundLimit.
        /// Then asserts that Stack size matches upperBoundLimit, and that the last item in the list matches the item suplied.
        /// </summary>
        /// <param name="item">the item to be added to the UpperBoundLimitedStack</param>
        /// <param name="upperBoundLimit">upper bound limit to be enforced</param>
        /// <param name="queue">the UpperBoundLimtedQueue to be added to</param>
        private void AddItemAndAssert(string item, int upperBoundLimit, UpperBoundLimitedStack<string> queue)
        {
            // Add an item to this list, setting the UpperBoundLimit
            queue.Enqueue(item, upperBoundLimit);

            // Assert
            Assert.AreEqual(upperBoundLimit, queue.Count);
            Assert.IsTrue(queue.Contains(item));
        }

        #endregion
    }
}
