// --------------------------------------------------------------------------
// <copyright file="IEnumerableExtensionTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeyTech.ProductivityKit.Extension;

namespace OdeyTech.ProductivityKit.Test.Extension
{
    [TestClass]
    public class IEnumerableExtensionTests
    {
        private int[] testArray;

        [TestInitialize]
        public void InitializeTestArray() => this.testArray = new int[] { 1, 2, 3, 4, 5 };

        [TestMethod]
        public void ShouldPerformActionForEachItem()
        {
            var sum = 0;
            this.testArray.ForEach(item => sum += item);
            Assert.AreEqual(this.testArray.Sum(), sum);
        }

        [TestMethod]
        public void ShouldPerformActionForEachItemInGenericCollection()
        {
            var sum = 0;
            this.testArray.ForEach(item => sum += item);
            Assert.AreEqual(this.testArray.Sum(), sum);
        }

        [TestMethod]
        public void ShouldPerformActionForEachItemInNonGenericCollection()
        {
            var sum = 0;
            ((IEnumerable)this.testArray).ForEach(item => sum += (int)item);
            Assert.AreEqual(this.testArray.Sum(), sum);
        }

        [TestMethod]
        public void ShouldThrowExceptionIfGenericCollectionIsNull()
        {
            int[] nullArray = null;
            Assert.ThrowsException<ArgumentNullException>(() => nullArray.ForEach(item => { }));
        }

        [TestMethod]
        public void ShouldThrowExceptionIfNonGenericCollectionIsNull()
        {
            IEnumerable nullCollection = null;
            Assert.ThrowsException<ArgumentNullException>(() => nullCollection.ForEach(item => { }));
        }

        [TestMethod]
        public void ShouldThrowExceptionIfActionIsNullInGenericCollection()
            => Assert.ThrowsException<ArgumentNullException>(() => this.testArray.ForEach(null));

        [TestMethod]
        public void ShouldThrowExceptionIfActionIsNullInNonGenericCollection()
            => Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable)this.testArray).ForEach(null));


        [TestMethod]
        public void ShouldReturnTrueIfCollectionIsFilled()
            => Assert.IsTrue(this.testArray.IsFilled());

        [TestMethod]
        public void ShouldReturnFalseIfCollectionIsEmpty()
        {
            this.testArray = new int[0];
            Assert.IsFalse(this.testArray.IsFilled());
        }

        [TestMethod]
        public void ShouldReturnFalseIfCollectionIsNull()
        {
            int[] nullArray = null;
            Assert.IsFalse(nullArray.IsFilled());
        }

        [TestMethod]
        public void ShouldReturnFalseIfCollectionIsNotEmpty()
            => Assert.IsFalse(this.testArray.IsNullOrEmpty());

        [TestMethod]
        public void ShouldReturnTrueIfCollectionIsEmpty()
        {
            this.testArray = new int[0];
            Assert.IsTrue(this.testArray.IsNullOrEmpty());
        }

        [TestMethod]
        public void ShouldReturnTrueIfCollectionIsNull()
        {
            int[] nullArray = null;
            Assert.IsTrue(nullArray.IsNullOrEmpty());
        }
    }
}
