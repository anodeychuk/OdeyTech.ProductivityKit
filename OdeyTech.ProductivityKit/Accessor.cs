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
        /// Retrieves the value of a specified property.
        /// </summary>
        /// <param name="obj">The object whose property value to retrieve.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the specified property.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the object or property name is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the property doesn't exist in the object's type.</exception>
        /// <exception cref="AmbiguousMatchException">Thrown when more than one property is found with the specified name and matching the specified binding constraints.</exception>
        public static PropertyInfo GetProperty(object obj, string propertyName)
            => obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        /// <summary>
        /// Retrieves the value of a specified property.
        /// </summary>
        /// <param name="obj">The object whose property value to retrieve.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the specified property.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the object, property name, or the property itself is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the property doesn't exist in the object's type.</exception>
        /// <exception cref="AmbiguousMatchException">Thrown when more than one property is found with the specified name and matching the specified binding constraints.</exception>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            var prop = GetProperty(obj, propertyName);
            ThrowHelper.ThrowIfNull(prop, propertyName, $"{propertyName} doesn't exist in {obj.GetType()}");
            return prop.GetValue(obj);
        }

        /// <summary>
        /// Sets the value of a specified property.
        /// </summary>
        /// <param name="obj">The object whose property value to set.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="ArgumentNullException">Thrown when the object, property name, or the property itself is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the property doesn't exist in the object's type or its setter is not accessible.</exception>
        /// <exception cref="AmbiguousMatchException">Thrown when more than one property is found with the specified name and matching the specified binding constraints.</exception>
        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            var prop = GetProperty(obj, propertyName);
            ThrowHelper.ThrowIfNull(prop, propertyName, $"{propertyName} doesn't exist in {obj.GetType()}");

            // Get the private setter
            var setter = prop.GetSetMethod(true);
            ThrowHelper.ThrowIfNull(setter, $"set_{propertyName}", $"Setter of the {propertyName} doesn't exist in {obj.GetType()}");

            // Call the private setter
            setter.Invoke(obj, new object[] { value });

            prop.SetValue(obj, value);
        }

        /// <summary>
        /// Retrieves a FieldInfo object for a specified field.
        /// </summary>
        /// <param name="obj">The object whose field to retrieve.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>A FieldInfo object for the specified field.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the object or field name is null.</exception>
        public static FieldInfo GetField(object obj, string fieldName)
            => obj.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        /// <summary>
        /// Retrieves the value of a specified field.
        /// </summary>
        /// <param name="obj">The object whose field value to retrieve.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The value of the specified field.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the object, field name, or the field itself is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the field doesn't exist in the object's type.</exception>
        public static object GetFieldValue(object obj, string fieldName)
        {
            var field = GetField(obj, fieldName);
            ThrowHelper.ThrowIfNull(field, fieldName, $"{fieldName} doesn't exist in {obj.GetType()}");
            return field.GetValue(obj);
        }

        /// <summary>
        /// Sets the value of a specified field.
        /// </summary>
        /// <param name="obj">The object whose field value to set.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="ArgumentNullException">Thrown when the object, field name, or the field itself is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the field doesn't exist in the object's type.</exception>
        public static void SetFieldValue(object obj, string fieldName, object value)
        {
            var field = GetField(obj, fieldName);
            ThrowHelper.ThrowIfNull(field, fieldName, $"{fieldName} doesn't exist in {obj.GetType()}");
            field.SetValue(obj, value);
        }

        /// <summary>
        /// Creates an instance of the specified type using the constructor that best matches the specified parameters.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="parameters">An array of arguments that match in number, order, and type the parameters of the constructor to invoke.</param>
        /// <returns>A reference to the newly created object.</returns>
        public static T CreateInstance<T>(params object[] parameters) => (T)Activator.CreateInstance(typeof(T), parameters);
    }
}
