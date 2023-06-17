// --------------------------------------------------------------------------
// <copyright file="CharExtensionTests.cs" author="Andrii Odeychuk">
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
    public class CharExtensionTests
    {
        [TestMethod]
        public void ShouldReturnTrueIfCharIsDigit()
        {
            var digitChar = '5';
            Assert.IsTrue(digitChar.IsDigit());
        }

        [TestMethod]
        public void ShouldReturnFalseIfCharIsNotDigit()
        {
            var nonDigitChar = 'a';
            Assert.IsFalse(nonDigitChar.IsDigit());
        }

        [TestMethod]
        public void ShouldReturnTrueIfCharIsLetter()
        {
            var letterChar = 'a';
            Assert.IsTrue(letterChar.IsLetter());
        }

        [TestMethod]
        public void ShouldReturnFalseIfCharIsNotLetter()
        {
            var nonLetterChar = '5';
            Assert.IsFalse(nonLetterChar.IsLetter());
        }
    }
}
