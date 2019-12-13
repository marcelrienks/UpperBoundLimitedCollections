using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UpperBoundLimitedCollections.Tests.Factory;

namespace UpperBoundLimitedCollections.Tests
{
    [TestClass]
    public class UpperBoundLimitedListTests
    {
        [TestMethod]
        public void Construct()
        {
            var list = new UpperBoundLimitedList<string>(3);

            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.UpperBoundLimit);
        }

        [TestMethod]
        public void Count()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void IsReadOnly()
        {
            var list = new UpperBoundLimitedList<string>(3);

            Assert.IsFalse(list.IsReadOnly);
        }

        [TestMethod]
        public void Read()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            Assert.AreEqual("2", list[1]);
        }

        [TestMethod]
        public void IndexOf()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            Assert.AreEqual(1, list.IndexOf("2"));
        }

        [TestMethod]
        public void InsertAtUpperBoundLimit()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            list.Insert(1, "4");
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("2", list[0]);
            Assert.AreEqual("4", list[1]);
            Assert.AreEqual("3", list[2]);
        }

        [TestMethod]
        public void InsertAtUpperBoundLimit0Index()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(0, "4"), "Specified argument was out of the range of valid values. (Parameter 'index cannot be 0, UpperBoundLimit of 3 will ensure that item will be removed after being added.')");
        }

        [TestMethod]
        public void RemoveAt()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            list.RemoveAt(1);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("3", list[1]);
        }

        [TestMethod]
        public void AddBelowUpperBoundLimit()
        {
            var list = new UpperBoundLimitedList<string>(3) { "1", "2" };
            list.Add("3");

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("2", list[1]);
        }

        [TestMethod]
        public void AddAtUpperBoundLimit()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();
            list.Add("4");

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("2", list[0]);
            Assert.AreEqual("3", list[1]);
            Assert.AreEqual("4", list[2]);
        }

        [TestMethod]
        public void Clear()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            Assert.AreEqual(3, list.Count);

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Contains()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            Assert.IsTrue(list.Contains("2"));
        }

        [TestMethod]
        public void CopyTo()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            var copiedList = new string[list.Count];
            list.CopyTo(copiedList, 0);

            Assert.AreEqual(list.Count, copiedList.Length);
            Assert.AreEqual("1", copiedList[0]);
            Assert.AreEqual("2", copiedList[1]);
            Assert.AreEqual("3", copiedList[2]);
        }

        [TestMethod]
        public void Remove()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            Assert.IsTrue(list.Remove("2"));
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void GetEnumerator()
        {
            var list = UpperBoundLimitedListFactory.GenerateStandardUpperBoundLimitedList();

            var enumerator = list.GetEnumerator();
            Assert.IsNotNull(enumerator);
            Assert.IsNull(enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("1", enumerator.Current);
        }
    }
}
