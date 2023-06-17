// --------------------------------------------------------------------------
// <copyright file="DictionaryExtension.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeyTech.ProductivityKit.Extension
{
    /// <summary>
    /// Provides extension methods for Dictionary collections.
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Removes all items from a dictionary that satisfy the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of the dictionary's keys.</typeparam>
        /// <typeparam name="V">The type of the dictionary's values.</typeparam>
        /// <param name="collection">The dictionary to process.</param>
        /// <param name="condition">The condition to evaluate each item against.</param>
        /// <remarks>
        /// This method modifies the original dictionary. It does not return a new dictionary.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the collection or condition is null.</exception>
        /// <example>
        /// Before:
        ///     var keysToRemove = dictionary.Where(item => item.Value.Age > 30).Select(item => item.Key).ToList();
        ///     foreach (var key in keysToRemove)
        ///     {
        ///       dictionary.Remove(key);
        ///     }
        /// After:
        ///     dictionary.RemoveWhere(item => item.Value.Age > 30);
        /// </example>
        public static void RemoveWhere<T, V>(this Dictionary<T, V> collection, Func<KeyValuePair<T, V>, bool> condition)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            var keysToRemove = collection.Where(item => condition.Invoke(item)).Select(item => item.Key).ToList();
            foreach (T key in keysToRemove)
            {
                collection.Remove(key);
            }
        }
    }
}
