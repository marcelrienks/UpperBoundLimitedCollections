using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.Tests.Factories;

namespace UpperBoundLimitedCollections.Tests
{
    [TestClass]
    public class UpperBoundLimitedListTests
    {
        [TestMethod]
        public void InsertAtUpperBoundLimit()
        {
            var list = DataFactory.GenerateStandardUpperBoundLimitedList();

            list.Insert(1, "4");
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("2", list[0]);
            Assert.AreEqual("4", list[1]);
            Assert.AreEqual("3", list[2]);
        }

        [TestMethod]
        public void InsertAtUpperBoundLimit0Index()
        {
            var list = DataFactory.GenerateStandardUpperBoundLimitedList();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(0, "4"), "Specified argument was out of the range of valid values. (Parameter 'index cannot be 0, UpperBoundLimit of 3 will ensure that item will be removed after being added.')");
        }

        [TestMethod]
        public void AddBelowUpperBoundLimit()
        {
            var list = new StrictUpperBoundLimitedList<string>(3) { "1", "2" };
            list.Add("3");

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("2", list[1]);
        }

        [TestMethod]
        public void AddAtUpperBoundLimit()
        {
            var list = DataFactory.GenerateStandardUpperBoundLimitedList();
            list.Add("4");

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("2", list[0]);
            Assert.AreEqual("3", list[1]);
            Assert.AreEqual("4", list[2]);
        }
    }
}
