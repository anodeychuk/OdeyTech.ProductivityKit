// --------------------------------------------------------------------------
// <copyright file="Accessor.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Reflection;

namespace OdeyTech.ProductivityKit
{
    /// <summary>
    /// Provides utility methods for accessing and manipulating objects' properties and fields.
    /// </summary>
    public static class Accessor
    {
        /// <summary>
        /// Retrieves a PropertyInfo object for a specified property.
        /// </summary>
        /// <param name="obj">The object whose property to retrieve.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>A PropertyInfo object for the specified property.</returns>
        public static PropertyInfo GetProperty(object obj, string propertyName)
            => obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        /// <summary>
        /// Retrieves a FieldInfo object for a specified field.
        /// </summary>
        /// <param name="obj">The object whose field to retrieve.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>A FieldInfo object for the specified field.</returns>
        public static FieldInfo GetField(object obj, string fieldName)
            => obj.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        /// <summary>
        /// Retrieves the value of a specified property.
        /// </summary>
        /// <param name="obj">The object whose property value to retrieve.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the specified property.</returns>
        public static object GetPropertyValue(object obj, string propertyName)
            => GetProperty(obj, propertyName).GetValue(obj, null);

        /// <summary>
        /// Sets the value of a specified field.
        /// </summary>
        /// <param name="obj">The object whose field value to set.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="value">The value to set.</param>
        public static void SetFieldValue(object obj, string fieldName, object value)
             => GetField(obj, fieldName).SetValue(obj, value);

        /// <summary>
        /// Retrieves the value of a specified field.
        /// </summary>
        /// <param name="obj">The object whose field value to retrieve.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The value of the specified field.</returns>
        public static object GetFieldValue(object obj, string fieldName)
            => GetField(obj, fieldName).GetValue(obj);

        /// <summary>
        /// Creates an instance of the specified type using the constructor that best matches the specified parameters.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="parameters">An array of arguments that match in number, order, and type the parameters of the constructor to invoke.</param>
        /// <returns>A reference to the newly created object.</returns>
        public static T CreateInstance<T>(params object[] parameters) => (T)Activator.CreateInstance(typeof(T), parameters);
    }
}
