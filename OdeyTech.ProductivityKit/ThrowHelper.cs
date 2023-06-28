// --------------------------------------------------------------------------
// <copyright file="ThrowHelper.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using OdeyTech.ProductivityKit.Extension;

namespace OdeyTech.ProductivityKit
{
    /// <summary>
    /// Helper class for throwing exceptions.
    /// </summary>
    public static class ThrowHelper
    {
        /// <summary>
        /// Throws an ArgumentNullException if the value is null, with a default message.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ThrowIfNull(object value, string argumentName) => ThrowIfNull(value, argumentName, $"{argumentName} cannot be null");

        /// <summary>
        /// Throws an ArgumentNullException if the value is null, with a custom message.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The custom message to throw in the exception.</param>
        public static void ThrowIfNull(object value, string argumentName, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the value is null or empty, with a default message.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ThrowIfNullOrEmpty(string value, string argumentName) => ThrowIfNullOrEmpty(value, argumentName, $"{argumentName} cannot be null or empty");

        /// <summary>
        /// Throws an ArgumentException if the value is null or empty, with a custom message.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The custom message to throw in the exception.</param>
        public static void ThrowIfNullOrEmpty(string value, string argumentName, string message)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException(message, argumentName);
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the collection is null or empty, with a default message.
        /// </summary>
        /// <param name="value">The collection to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ThrowIfNullOrEmpty<T>(IEnumerable<T> collection, string argumentName) => ThrowIfNullOrEmpty(collection, argumentName, $"{argumentName} cannot be null or empty");

        /// <summary>
        /// Throws an ArgumentException if the collection is null or empty, with a custom message.
        /// </summary>
        /// <param name="value">The collection to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The custom message to throw in the exception.</param>
        public static void ThrowIfNullOrEmpty<T>(IEnumerable<T> collection, string argumentName, string message)
        {
            if (collection.IsNullOrEmpty())
            {
                throw new ArgumentException(message, argumentName);
            }
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException if the value is not within the specified range.
        /// </summary>
        /// <typeparam name="T">The type of the argument to check. The type must be comparable.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ThrowIfOutOfRange<T>(T value, T min, T max, string argumentName) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} must be between {min} and {max}. Actual value: {value}");
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the value is zero or negative.
        /// </summary>
        /// <typeparam name="T">The type of the argument to check. The type must be a value type and comparable.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ThrowIfZeroOrNegative<T>(T value, string argumentName) where T : struct, IComparable<T>
        {
            if (value.CompareTo(default) <= 0)
            {
                throw new ArgumentException($"{argumentName} must be greater than zero. Actual value: {value}", argumentName);
            }
        }
    }
}
