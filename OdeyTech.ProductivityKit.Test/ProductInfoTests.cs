// --------------------------------------------------------------------------
// <copyright file="ProductInfoTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdeyTech.ProductivityKit.Test
{
    [TestClass]
    public class ProductInfoTests
    {
        private Assembly testAssembly;
        private ProductInfo productInfo;

        [TestInitialize]
        public void InitializeTestObjects()
        {
            this.testAssembly = Assembly.GetExecutingAssembly();
            this.productInfo = new ProductInfo(this.testAssembly);
        }

        [TestMethod]
        public void ShouldGetCorrectCopyright()
        {
            var copyright = this.productInfo.Copyright;
            Assert.AreEqual(GetCopyright(), copyright);
        }

        [TestMethod]
        public void ShouldGetCorrectApplicationName()
        {
            var applicationName = this.productInfo.ApplicationName;
            Assert.AreEqual(GetProduct(), applicationName);
        }

        [TestMethod]
        public void ShouldGetCorrectApplicationDescription()
        {
            var applicationDescription = this.productInfo.ApplicationDescription;
            Assert.AreEqual(GetDescription(), applicationDescription);
        }

        [TestMethod]
        public void ShouldGetCorrectVersion()
        {
            var version = this.productInfo.Version;
            Assert.AreEqual(GetVersion(), version);
        }

        [TestMethod]
        public void ShouldThrowExceptionIfAssemblyIsNull() => Assert.ThrowsException<ArgumentNullException>(() => new ProductInfo(null));

        private string GetDescription() => GetAttributeValue<AssemblyDescriptionAttribute, string>(attr => attr.Description, string.Empty);

        private string GetCopyright() => GetAttributeValue<AssemblyCopyrightAttribute, string>(attr => attr.Copyright, string.Empty);

        private string GetProduct() => GetAttributeValue<AssemblyProductAttribute, string>(attr => attr.Product, string.Empty);

        private TResult GetAttributeValue<TAttribute, TResult>(Func<TAttribute, TResult> selector, TResult defaultValue)
            where TAttribute : Attribute
        {
            var attributes = this.testAssembly.GetCustomAttributes(typeof(TAttribute), true);
            return attributes.Length > 0 ? selector((TAttribute)attributes[0]) : defaultValue;
        }

        private string GetVersion() => this.testAssembly.GetName().Version?.ToString();
    }
}
