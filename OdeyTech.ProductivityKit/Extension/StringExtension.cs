// --------------------------------------------------------------------------
// <copyright file="StringExtension.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

namespace OdeyTech.ProductivityKit.Extension
{
    /// <summary>
    /// Provides extension methods for string objects.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Replaces the format items in a specified string with the string representations of corresponding objects in a specified array.
        /// </summary>
        /// <param name="str">The format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the format string in which the format items have been replaced by the string representations of the corresponding objects in the specified array.</returns>
        /// <example>
        /// Before:
        ///     var formatted = string.Format("Hello, {0}!", "World");
        /// After:
        ///     var formatted = "Hello, {0}!".Format("World");
        /// </example>
        public static string Format(this string str, params object[] args) => string.Format(str, args);

        /// <summary>
        /// Determines whether the specified string is null or empty.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is null or empty, otherwise false.</returns>
        /// <example>
        /// Before:
        ///     var isEmpty = string.IsNullOrEmpty(someString);
        /// After:
        ///     var isEmpty = someString.IsNullOrEmpty();
        /// </example>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// Determines whether the specified string is not null and contains characters.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is filled, otherwise false.</returns>
        /// <example>
        /// Before:
        ///     var isFilled = !string.IsNullOrEmpty(someString);
        /// After:
        ///     var isFilled = someString.IsFilled();
        /// </example>
        public static bool IsFilled(this string str) => !str.IsNullOrEmpty();
    }
}
