// --------------------------------------------------------------------------
// <copyright file="MonadsTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdeyTech.ProductivityKit.Test
{
    [TestClass]
    public class MonadsTests
    {
        private const string TestString = "TestString";
        private const string NullString = null;

        [TestMethod]
        public void ShouldReturnObjectIfConditionIsTrue()
        {
            var result = TestString.If(s => s == TestString);
            Assert.AreEqual(TestString, result);
        }

        [TestMethod]
        public void ShouldReturnNullIfConditionIsFalse()
        {
            var result = TestString.If(s => s != TestString);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ShouldPerformActionIfObjectIsNotNull()
        {
            var actionPerformed = false;
            TestString.Do(s => actionPerformed = true);
            Assert.IsTrue(actionPerformed);
        }

        [TestMethod]
        public void ShouldNotPerformActionIfObjectIsNull()
        {
            var actionPerformed = false;
            NullString.Do(s => actionPerformed = true);
            Assert.IsFalse(actionPerformed);
        }

        [TestMethod]
        public void ShouldPerformActionIfNotNull()
        {
            var actionPerformed = false;
            TestString.DoIfNotNull(s => actionPerformed = true);
            Assert.IsTrue(actionPerformed);
        }

        [TestMethod]
        public void ShouldNotPerformActionIfNull()
        {
            var actionPerformed = false;
            NullString.DoIfNotNull(s => actionPerformed = true);
            Assert.IsFalse(actionPerformed);
        }

        [TestMethod]
        public void ShouldReturnResultIfNotNull()
        {
            var result = TestString.Return(s => s, NullString);
            Assert.AreEqual(TestString, result);
        }

        [TestMethod]
        public void ShouldReturnFailureValueIfNull()
        {
            var result = NullString.Return(s => s, TestString);
            Assert.AreEqual(TestString, result);
        }
    }
}
