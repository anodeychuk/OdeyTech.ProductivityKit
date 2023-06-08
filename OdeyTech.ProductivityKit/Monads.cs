// --------------------------------------------------------------------------
// <copyright file="Monads.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;

namespace OdeyTech.ProductivityKit
{
    /// <summary>
    /// Provides utility methods for working with monads and simplifying null checking.
    /// </summary>
    public static class Monads
    {
        /// <summary>
        /// Returns the object if it satisfies the specified evaluator function.
        /// </summary>
        /// <typeparam name="TInput">The type of the input object.</typeparam>
        /// <param name="o">The input object.</param>
        /// <param name="evaluator">The evaluator function to execute.</param>
        /// <returns>The input object if it satisfies the evaluator function, otherwise null.</returns>
        /// <example>
        /// Before:
        ///     var result = obj == null || !obj.IsValid() ? null : obj;
        /// After:
        ///     var result = obj.If(o => o.IsValid());
        /// </example>
        public static TInput If<TInput>(this TInput o, Func<TInput, bool> evaluator)
            where TInput : class
            => o == null ? null : evaluator(o) ? o : null;

        /// <summary>
        /// Returns the object if the specified condition is true.
        /// </summary>
        /// <typeparam name="TInput">The type of the input object.</typeparam>
        /// <param name="o">The input object.</param>
        /// <param name="condition">The condition to check.</param>
        /// <returns>The input object if the condition is true, otherwise null.</returns>
        /// <example>
        /// Before:
        ///     var result = obj == null || !condition ? null : obj;
        /// After:
        ///     var result = obj.If(condition);
        /// </example>
        public static TInput If<TInput>(this TInput o, bool condition)
            where TInput : class
            => o == null ? null : condition ? o : null;

        /// <summary>
        /// Executes the specified action on the object if it is not null.
        /// </summary>
        /// <typeparam name="TInput">The type of the input object.</typeparam>
        /// <param name="o">The input object.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>The input object, or null if the input object is null.</returns>
        /// <example>
        /// Before:
        ///     if (obj != null) { obj.SomeOperation(); }
        /// After:
        ///     obj.Do(o => o.SomeOperation());
        /// </example>
        public static TInput Do<TInput>(this TInput o, Action<TInput> action)
            where TInput : class
        {
            if (o == null)
            {
                return null;
            }

            action(o);
            return o;
        }

        /// <summary>
        /// If the input object is not null, performs the specified action and returns the original object.
        /// Otherwise, does nothing and returns null.
        /// </summary>
        /// <typeparam name="TInput">The type of the input object.</typeparam>
        /// <param name="o">The input object.</param>
        /// <param name="action">The action to perform on the input object.</param>
        /// <returns>The original input object, or null if the input object is null.</returns>
        /// <example>
        /// Before:
        ///     if (obj != null) { obj.SomeAction(); }
        /// After:
        ///     obj.DoIfNotNull(o => o.SomeAction());
        /// </example>
        public static TInput DoIfNotNull<TInput>(this TInput o, Action<TInput> action)
            where TInput : class
        {
            if (o != null)
            {
                action(o);
            }

            return o;
        }

        /// <summary>
        /// Executes the specified evaluator function if the object is not null, otherwise returns the failure value.
        /// </summary>
        /// <typeparam name="TInput">The type of the input object.</typeparam>
        /// <typeparam name="TResult">The type of the result object.</typeparam>
        /// <param name="o">The input object.</param>
        /// <param name="evaluator">The evaluator function to execute.</param>
        /// <param name="failureValue">The value to return if the input object is null.</param>
        /// <returns>The result of the evaluator function, or the failure value if the input object is null.</returns>
        /// <example>
        /// Before:
        ///     var result = obj == null ? defaultValue : obj.SomeOperation();
        /// After:
        ///     var result = obj.Return(o => o.SomeOperation(), defaultValue);
        /// </example>
        public static TResult Return<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator, TResult failureValue)
            where TInput : class
            => o == null ? failureValue : evaluator(o);
    }
}
