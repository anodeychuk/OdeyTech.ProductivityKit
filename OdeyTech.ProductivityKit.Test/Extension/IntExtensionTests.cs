// --------------------------------------------------------------------------
// <copyright file="IntExtensionTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OdeyTech.ProductivityKit.Extension;

namespace OdeyTech.ProductivityKit.Test.Extension
{
    [TestClass]
    public class IntExtensionTests
    {
        private const int Day = 15;
        private const int Year = 2023;

        [TestMethod]
        public void ShouldReturnCorrectDateForJanuary()
        {
            DateTime date = Day.January(Year);
            Assert.AreEqual(new DateTime(Year, 1, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForFebruary()
        {
            DateTime date = Day.February(Year);
            Assert.AreEqual(new DateTime(Year, 2, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForMarch()
        {
            DateTime date = Day.March(Year);
            Assert.AreEqual(new DateTime(Year, 3, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForApril()
        {
            DateTime date = Day.April(Year);
            Assert.AreEqual(new DateTime(Year, 4, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForMay()
        {
            DateTime date = Day.May(Year);
            Assert.AreEqual(new DateTime(Year, 5, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForJune()
        {
            DateTime date = Day.June(Year);
            Assert.AreEqual(new DateTime(Year, 6, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForJuly()
        {
            DateTime date = Day.July(Year);
            Assert.AreEqual(new DateTime(Year, 7, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForAugust()
        {
            DateTime date = Day.August(Year);
            Assert.AreEqual(new DateTime(Year, 8, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForSeptember()
        {
            DateTime date = Day.September(Year);
            Assert.AreEqual(new DateTime(Year, 9, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForOctober()
        {
            DateTime date = Day.October(Year);
            Assert.AreEqual(new DateTime(Year, 10, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForNovember()
        {
            DateTime date = Day.November(Year);
            Assert.AreEqual(new DateTime(Year, 11, Day), date);
        }

        [TestMethod]
        public void ShouldReturnCorrectDateForDecember()
        {
            DateTime date = Day.December(Year);
            Assert.AreEqual(new DateTime(Year, 12, Day), date);
        }
    }
}
