// --------------------------------------------------------------------------
// <copyright file="AccessorTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdeyTech.ProductivityKit.Test
{
    [TestClass]
    public class AccessorTests
    {
        private class DummyClassForTesting
        {
            public string TestPublicProperty { get; set; }
            private string TestPrivateProperty { get; set; }
            public string testPublicField_DESIGN_VIOLATION;
            private readonly string testPrivateField;

            public DummyClassForTesting()
            {
                TestPublicProperty = PublicPropertyName;
                TestPrivateProperty = PrivatePropertyName;
                this.testPublicField_DESIGN_VIOLATION = PublicFieldName;
                this.testPrivateField = PrivateFieldName;
            }
        }

        private const string TestPublicPropertyName = "TestPublicProperty";
        private const string TestPrivatePropertyName = "TestPrivateProperty";
        private const string TestPublicFieldName = "testPublicField_DESIGN_VIOLATION";
        private const string TestPrivateFieldName = "testPrivateField";

        private const string PublicPropertyName = "PublicProperty";
        private const string PrivatePropertyName = "PrivateProperty";
        private const string PublicFieldName = "PublicField";
        private const string PrivateFieldName = "PrivateField";

        private const string NewValue = "NewValue";

        private DummyClassForTesting testObject;

        [TestInitialize]
        public void InitializeTestObject() => this.testObject = new DummyClassForTesting();

        [TestMethod]
        public void ShouldGetPublicPropertyCorrectly()
        {
            PropertyInfo property = Accessor.GetProperty(this.testObject, TestPublicPropertyName);
            Assert.IsNotNull(property);
            Assert.AreEqual(PublicPropertyName, property.GetValue(this.testObject));
        }

        [TestMethod]
        public void ShouldGetPrivatePropertyCorrectly()
        {
            PropertyInfo property = Accessor.GetProperty(this.testObject, TestPrivatePropertyName);
            Assert.IsNotNull(property);
            Assert.AreEqual(PrivatePropertyName, property.GetValue(this.testObject, null));
        }

        [TestMethod]
        public void ShouldGetPublicFieldCorrectly()
        {
            FieldInfo field = Accessor.GetField(this.testObject, TestPublicFieldName);
            Assert.IsNotNull(field);
            Assert.AreEqual(PublicFieldName, field.GetValue(this.testObject));
        }

        [TestMethod]
        public void ShouldGetPrivateFieldCorrectly()
        {
            FieldInfo field = Accessor.GetField(this.testObject, TestPrivateFieldName);
            Assert.IsNotNull(field);
            Assert.AreEqual(PrivateFieldName, field.GetValue(this.testObject));
        }

        [TestMethod]
        public void ShouldGetPublicPropertyValueCorrectly()
        {
            var value = Accessor.GetPropertyValue(this.testObject, TestPublicPropertyName);
            Assert.AreEqual(PublicPropertyName, value);
        }

        [TestMethod]
        public void ShouldGetPrivatePropertyValueCorrectly()
        {
            var value = Accessor.GetPropertyValue(this.testObject, TestPrivatePropertyName);
            Assert.AreEqual(PrivatePropertyName, value);
        }

        [TestMethod]
        public void ShouldSetPublicFieldValueCorrectly()
        {
            Accessor.SetFieldValue(this.testObject, TestPublicFieldName, NewValue);
            Assert.AreEqual(NewValue, this.testObject.testPublicField_DESIGN_VIOLATION);
        }

        [TestMethod]
        public void ShouldSetPrivateFieldValueCorrectly()
        {
            Accessor.SetFieldValue(this.testObject, TestPrivateFieldName, NewValue);
            FieldInfo field = Accessor.GetField(this.testObject, TestPrivateFieldName);
            Assert.AreEqual(NewValue, field.GetValue(this.testObject));
        }

        [TestMethod]
        public void ShouldGetPublicFieldValueCorrectly()
        {
            var value = Accessor.GetFieldValue(this.testObject, TestPublicFieldName);
            Assert.AreEqual(PublicFieldName, value);
        }

        [TestMethod]
        public void ShouldGetPrivateFieldValueCorrectly()
        {
            var value = Accessor.GetFieldValue(this.testObject, TestPrivateFieldName);
            Assert.AreEqual(PrivateFieldName, value);
        }

        [TestMethod]
        public void ShouldCreateInstanceOfTestClassCorrectly()
        {
            DummyClassForTesting instance = Accessor.CreateInstance<DummyClassForTesting>();
            Assert.IsNotNull(instance);
        }
    }
}
