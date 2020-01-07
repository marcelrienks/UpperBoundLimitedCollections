using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UpperBoundLimitedCollections.List;

namespace UpperBoundLimitedCollections.Tests.List
{
    [TestClass]
    public class StrictStrictUpperBoundLimitedListTests
    {
        [TestMethod]
        public void InitializeStrictStrictUpperBoundLimitedListWithZeroLimit()
        {
            // Expected
            var upperBoundLimit = 0;

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StrictUpperBoundLimitedList<string>(upperBoundLimit), "The param upperBoundLimit must be greater than 0.");
        }

        #region Add

        /// <summary>
        /// Asserts that adding a null item to the list causes an
        /// ArgumentNullException with error message of "The argument cannot be null. (Parameter 'item')"
        /// </summary>
        [TestMethod]
        public void AddNullItem()
        {
            // Expected
            string item = null;
            var upperBoundLimit = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => list.Add(item), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument cannot be null. (Parameter 'item')", exception.Message);
        }

        /// <summary>
        /// Asserts that adding an item to a list with a size less than the UpperBoundLimit
        /// results in the item being appended to the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void AddItemToListWithSizeBelowUpperBoundLimit()
        {
            // Expected
            var item = "2";
            var upperBoundLimit = 2;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1" };

            // Assert
            AddItemAndAssert(item, list);
        }

        /// <summary>
        /// Asserts that adding an item to a list with a size the same as the UpperBoundLimit
        /// results in the the first item in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemToListWithSizeAtUpperBoundLimit()
        {
            // Expected
            var item = "4";
            var upperBoundLimit = 3;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3" };

            // Assert
            AddItemAndAssert(item, list);
        }

        /// <summary>
        /// Asserts that adding an item to a list with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new item being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddItemToListWithSizeAboveUpperBoundLimit()
        {
            // Expected
            var item = "5";
            var upperBoundLimit = 3;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3", "4" };

            // Assert
            AddItemAndAssert(item, list);
        }

        /// <summary>
        /// Adds an item to the list supplied, passing in the upperBoundLimit.
        /// Then asserts that list size matches upperBoundLimit, and that the last item in the list matches the item suplied.
        /// </summary>
        /// <param name="item">item to be added to the UpperBoundLimtedList</param>
        /// <param name="upperBoundLimit">upper bound limit to be enforced</param>
        /// <param name="list">the UpperBoundLimtedList to be added to</param>
        private void AddItemAndAssert(string item, StrictUpperBoundLimitedList<string> list)
        {
            // Add an item to this list, setting the UpperBoundLimit
            list.Add(item);

            // Assert
            Assert.AreEqual(list.UpperBoundLimit, list.Count);
            Assert.AreEqual(item, list[list.Count - 1]);
        }

        #endregion

        #region AddRange

        /// <summary>
        /// Asserts that adding a null range to the list causes an
        /// ArgumentNullException with error message "The argument cannot be null. (Parameter 'collection')"
        /// </summary>
        [TestMethod]
        public void AddNullRange()
        {
            // Expected
            IEnumerable<string> rangeToAdd = null;
            var upperBoundLimit = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => list.AddRange(rangeToAdd), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument cannot be null. (Parameter 'range')", exception.Message);
        }

        /// <summary>
        /// Asserts that adding a range of items with a size greater than the UpperBoundLimit causes an
        /// ArgumentOutOfRangeException with error message "The range size cannot be greater than the argument 'upperBoundLimit'."
        /// </summary>
        [TestMethod]
        public void AddRangeWithSizeGreaterThanUpperBoundLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "1", "2" };
            var upperBoundLimit = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddRange(rangeToAdd), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')\r\nActual value was 2.", exception.Message);
        }

        /// <summary>
        /// Asserts that adding a range of items to a list with a size less than the UpperBoundLimit
        /// results in the items being appended to the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void AddRangeWithSizeBelowLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "3", "4" };
            var upperBoundLimit = 4;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2" };

            // Assert
            AddRangeItemAndAssert(rangeToAdd, list);
        }

        /// <summary>
        /// Asserts that adding a range of items to a list with a size the same as the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new items being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddRangeWithSizeAtLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "4", "5" };
            var upperBoundLimit = 3;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3" };

            // Assert
            AddRangeItemAndAssert(rangeToAdd, list);
        }

        /// <summary>
        /// Asserts that adding a range of items to a list with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new items being appended to the list.
        /// </summary>
        [TestMethod]
        public void AddRangeWithListCountAboveLimit()
        {
            // Function
            var rangeToAdd = new List<string>() { "5", "6" };
            var upperBoundLimit = 3;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3", "4" };

            // Assert
            AddRangeItemAndAssert(rangeToAdd, list);
        }

        /// <summary>
        /// Adds a range of items to the list supplied, passing in the upperBoundLimit.
        /// Then asserts that list size matches upperBoundLimit, and that the last item in the list matches the item suplied.
        /// </summary>
        /// <param name="listToBeAdded">list of items to be added to the UpperBoundLimtedList</param>
        /// <param name="upperBoundLimit">upper bound limit to be enforced</param>
        /// <param name="list">the UpperBoundLimtedList to be added to</param>
        private void AddRangeItemAndAssert(List<string> listToBeAdded, StrictUpperBoundLimitedList<string> list)
        {
            // Add an item to this list, setting the UpperBoundLimit
            list.AddRange(listToBeAdded);

            // Assert
            Assert.AreEqual(list.UpperBoundLimit, list.Count);
            Assert.AreEqual(listToBeAdded[listToBeAdded.Count - 1], list[list.Count - 1]);
        }

        #endregion

        #region Insert

        /// <summary>
        /// Asserts that inserting a null item to the list causes an
        /// ArgumentNullException with error message of "The argument cannot be null. (Parameter 'item')"
        /// </summary>
        [TestMethod]
        public void InsertNullItem()
        {
            // Expected
            string item = null;
            var upperBoundLimit = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => list.Insert(0, item), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument cannot be null. (Parameter 'item')", exception.Message);
        }

        /// <summary>
        /// Asserts that inserting an item into a list with a size less than the UpperBoundLimit
        /// results in the item being inserted into the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void InsertItemIntoListWithSizeBelowUpperBoundLimit()
        {
            // Expected
            var item = "2";
            var upperBoundLimit = 2;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1" };

            // Assert
            InsertItemAndAssert(1, item, list);
        }

        /// <summary>
        /// Asserts that inserting an item into a list with a size the same as the UpperBoundLimit
        /// results in the the first item in the list being removed, and the new item being inserted to the list.
        /// </summary>
        [TestMethod]
        public void InsertItemIntoListWithSizeAtUpperBoundLimit()
        {
            // Expected
            var item = "4";
            var upperBoundLimit = 3;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3" };

            // Assert
            InsertItemAndAssert(1, item, list);
        }

        /// <summary>
        /// Asserts that inserting an item into a list with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new item being inserted to the list.
        /// </summary>
        [TestMethod]
        public void InsertItemIntoListWithSizeAboveUpperBoundLimit()
        {
            // Function
            var item = "5";
            var upperBoundLimit = 3;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3", "4" };

            // Assert
            InsertItemAndAssert(1, item, list);
        }

        /// <summary>
        /// Tries to insert an item into the list supplied, passing in the upperBoundLimit.
        /// Then asserts that list size matches upperBoundLimit, and that the item at index in the list matches the item suplied.
        /// </summary>
        /// <param name="index">index at which to insert the item</param>
        /// <param name="item">item to be inserted into the UpperBoundLimtedList</param>
        /// <param name="upperBoundLimit">upper bound limit to be enforced</param>
        /// <param name="list">the UpperBoundLimtedList to be added to</param>
        private void InsertItemAndAssert(int index, string item, StrictUpperBoundLimitedList<string> list)
        {
            // Add an item to this list, setting the UpperBoundLimit
            list.Insert(index, item);

            // Assert
            Assert.AreEqual(list.UpperBoundLimit, list.Count);
            Assert.AreEqual(item, list[index]);
        }

        #endregion

        #region InsertRange

        /// <summary>
        /// Asserts that inserting a null range to the list causes an
        /// ArgumentNullException with error message "The argument cannot be null. (Parameter 'collection')"
        /// </summary>
        [TestMethod]
        public void InsertNullRange()
        {
            // Expected
            IEnumerable<string> rangeToAdd = null;
            var upperBoundLimit = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => list.InsertRange(0, rangeToAdd), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The argument cannot be null. (Parameter 'range')", exception.Message);
        }

        /// <summary>
        /// Asserts that inserting a range of items with a size greater than the UpperBoundLimit causes an
        /// ArgumentOutOfRangeException with error message "The range size cannot be greater than the argument 'upperBoundLimit'."
        /// </summary>
        [TestMethod]
        public void InsertRangeWithSizeGreaterThanUpperBoundLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "1", "2" };
            var upperBoundLimit = 1;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.InsertRange(1, rangeToAdd), "Exception thrown does not match expected type 'ArgumentNullException'.");
            Assert.AreEqual("The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')\r\nActual value was 2.", exception.Message);
        }

        /// <summary>
        /// Asserts that adding a range of items to a list with a size less than the UpperBoundLimit
        /// results in the items being appended to the list with nothing being removed.
        /// </summary>
        [TestMethod]
        public void InsertRangeWithSizeBelowLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "3", "4" };
            var upperBoundLimit = 4;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2" };

            // Assert
            InsertRangeOfItemsAndAssert(1, rangeToAdd, list);
        }

        /// <summary>
        /// Asserts that adding a range of items to a list with a size the same as the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new items being appended to the list.
        /// </summary>
        [TestMethod]
        public void InsertRangeWithSizeAtLimit()
        {
            // Expected
            var rangeToAdd = new List<string>() { "4", "5" };
            var upperBoundLimit = 3;

            // Function
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3" };

            // Assert
            InsertRangeOfItemsAndAssert(1, rangeToAdd, list);
        }

        /// <summary>
        /// Asserts that adding a range of items to a list with a size greater than the UpperBoundLimit
        /// results in the the first few items in the list being removed, and the new items being appended to the list.
        /// </summary>
        [TestMethod]
        public void InsertRangeWithListCountAboveLimit()
        {
            // Function
            var rangeToAdd = new List<string>() { "5", "6" };
            var upperBoundLimit = 3;

            // Variables
            var list = new StrictUpperBoundLimitedList<string>(upperBoundLimit) { "1", "2", "3", "4" };

            // Assert
            InsertRangeOfItemsAndAssert(1, rangeToAdd, list);
        }

        /// <summary>
        /// Inserts a range of items to the list supplied, passing in the upperBoundLimit.
        /// Then asserts that list size matches upperBoundLimit, and that the last item in the list matches the item suplied.
        /// </summary>
        /// <param name="listToBeAdded">list of items to be added to the UpperBoundLimtedList</param>
        /// <param name="upperBoundLimit">upper bound limit to be enforced</param>
        /// <param name="list">the UpperBoundLimtedList to be added to</param>
        private void InsertRangeOfItemsAndAssert(int index, List<string> listToBeAdded, StrictUpperBoundLimitedList<string> list)
        {
            // Add an item to this list, setting the UpperBoundLimit
            list.InsertRange(index, listToBeAdded);

            // Assert
            Assert.AreEqual(list.UpperBoundLimit, list.Count);
            Assert.AreEqual(listToBeAdded[0], list[index]);
        }

        #endregion
    }
}
