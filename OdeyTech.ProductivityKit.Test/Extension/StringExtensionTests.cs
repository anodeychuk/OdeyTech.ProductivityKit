// --------------------------------------------------------------------------
// <copyright file="StringExtensionTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeyTech.ProductivityKit.Extension;

namespace OdeyTech.ProductivityKit.Test.Extension
{
    [TestClass]
    public class StringExtensionTests
    {
        private const string TestString = "Hello World";

        [TestMethod]
        public void ShouldFormatStringCorrectly()
        {
            var format = "{0}";
            var formattedString = format.Format(TestString);
            Assert.AreEqual(TestString, formattedString);
        }

        [TestMethod]
        public void ShouldReturnTrueIfStringIsNullOrEmpty()
        {
            string nullString = null;
            Assert.IsTrue(nullString.IsNullOrEmpty());
            var emptyString = string.Empty;
            Assert.IsTrue(emptyString.IsNullOrEmpty());
        }

        [TestMethod]
        public void ShouldReturnFalseIfStringIsNotEmpty() => Assert.IsFalse(TestString.IsNullOrEmpty());

        [TestMethod]
        public void ShouldReturnTrueIfStringIsFilled() => Assert.IsTrue(TestString.IsFilled());

        [TestMethod]
        public void ShouldReturnFalseIfStringIsNotFilled()
        {
            string nullString = null;
            Assert.IsFalse(nullString.IsFilled());
            var emptyString = string.Empty;
            Assert.IsFalse(emptyString.IsFilled());
        }
    }
}
