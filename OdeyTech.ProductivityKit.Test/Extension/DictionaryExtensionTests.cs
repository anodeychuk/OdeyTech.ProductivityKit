// --------------------------------------------------------------------------
// <copyright file="DictionaryExtensionTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeyTech.ProductivityKit.Extension;

namespace OdeyTech.ProductivityKit.Test.Extension
{
    [TestClass]
    public class DictionaryExtensionTests
    {
        private Dictionary<int, string> testDictionary;

        [TestInitialize]
        public void InitializeTestDictionary()
            => this.testDictionary = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
                { 5, "Five" }
            };

        [TestMethod]
        public void ShouldRemoveItemsThatSatisfyCondition()
        {
            this.testDictionary.RemoveWhere(item => item.Key > 3);
            Assert.AreEqual(3, this.testDictionary.Count);
            Assert.IsFalse(this.testDictionary.ContainsKey(4));
            Assert.IsFalse(this.testDictionary.ContainsKey(5));
        }

        [TestMethod]
        public void ShouldNotRemoveItemsThatDoNotSatisfyCondition()
        {
            this.testDictionary.RemoveWhere(item => item.Key > 5);
            Assert.AreEqual(5, this.testDictionary.Count);
        }

        [TestMethod]
        public void ShouldThrowExceptionIfCollectionIsNull()
        {
            Dictionary<int, string> nullDictionary = null;
            Assert.ThrowsException<ArgumentNullException>(() => nullDictionary.RemoveWhere(item => item.Key > 3));
        }

        [TestMethod]
        public void ShouldThrowExceptionIfConditionIsNull()
            => Assert.ThrowsException<ArgumentNullException>(() => this.testDictionary.RemoveWhere(null));
    }
}
