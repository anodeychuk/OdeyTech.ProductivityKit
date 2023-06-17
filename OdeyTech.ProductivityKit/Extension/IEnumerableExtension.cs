// --------------------------------------------------------------------------
// <copyright file="IEnumerableExtension.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OdeyTech.ProductivityKit.Extension
{
    /// <summary>
    /// Provides extension methods for IEnumerable collections.
    /// </summary>
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Executes the specified action for each item in the collection.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to process. Must not be null or empty.</param>
        /// <param name="action">The action to execute for each item. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the collection or action is null.</exception>
        /// <remarks>
        /// This method provides a more functional way to iterate over a collection and perform an action on each item.
        /// </remarks>
        /// <example>
        /// Before:
        ///     foreach (var item in collection)
        ///     {
        ///       DoSomething(item);
        ///     }
        /// After:
        ///     collection.ForEach(item => DoSomething(item));
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T item in collection)
            {
                action?.Invoke(item);
            }
        }

        /// <summary>
        /// Executes the specified action for each item in the collection.
        /// </summary>
        /// <param name="collection">The collection to process. Must not be null or empty.</param>
        /// <param name="action">The action to execute for each item. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the collection or action is null.</exception>
        /// <remarks>
        /// This method provides a more functional way to iterate over a non-generic collection and perform an action on each item.
        /// </remarks>
        public static void ForEach(this IEnumerable collection, Action<object> action) => collection.Cast<object>().ForEach(action);

        /// <summary>
        /// Determines whether the collection is not null and contains at least one item.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <returns>True if the collection is filled, otherwise false.</returns>
        /// <example>
        /// Before:
        ///     var isFilled = collection != null && collection.Any();
        /// After:
        ///     var isFilled = collection.IsFilled();
        /// </example>
        public static bool IsFilled<T>(this IEnumerable<T> collection) => !collection.IsNullOrEmpty();

        /// <summary>
        /// Determines whether the collection is null or contains no items.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <returns>True if the collection is null or empty, otherwise false.</returns>
        /// <example>
        /// Before:
        ///     var isEmpty = collection == null || !collection.Any();
        /// After:
        ///     var isEmpty = collection.IsNullOrEmpty();
        /// </example>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection == null || !collection.Any();
    }
}
