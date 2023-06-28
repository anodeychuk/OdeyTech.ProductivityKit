// --------------------------------------------------------------------------
// <copyright file="ThrowHelperTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdeyTech.ProductivityKit.Test
{
    [TestClass]
    public class ThrowHelperTests
    {
        private const string ArgName = "testArgument";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowIfNull_ShouldThrowException_WhenValueIsNull()
            => ThrowHelper.ThrowIfNull(null, ArgName);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowIfNullOrEmpty_ShouldThrowException_WhenValueIsNull()
            => ThrowHelper.ThrowIfNullOrEmpty(null, ArgName);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowIfNullOrEmpty_ShouldThrowException_WhenValueIsEmpty()
            => ThrowHelper.ThrowIfNullOrEmpty(string.Empty, ArgName);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowIfNullOrEmpty_ShouldThrowException_WhenCollectionIsNull()
            => ThrowHelper.ThrowIfNullOrEmpty<int>(null, ArgName);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowIfNullOrEmpty_ShouldThrowException_WhenCollectionIsEmpty()
            => ThrowHelper.ThrowIfNullOrEmpty(new List<int>(), ArgName);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowIfOutOfRange_ShouldThrowException_WhenValueIsOutOfRange()
            => ThrowHelper.ThrowIfOutOfRange(11, 1, 10, ArgName);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowIfZeroOrNegative_ShouldThrowException_WhenValueIsZero()
            => ThrowHelper.ThrowIfZeroOrNegative(0, ArgName);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowIfZeroOrNegative_ShouldThrowException_WhenValueIsNegative()
            => ThrowHelper.ThrowIfZeroOrNegative(-1, ArgName);
    }
}
