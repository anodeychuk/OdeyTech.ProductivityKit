// --------------------------------------------------------------------------
// <copyright file="CharExtension.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

namespace OdeyTech.ProductivityKit.Extension
{
    /// <summary>
    /// Provides extension methods for the <see cref="char"/> type.
    /// </summary>
    public static class CharExtension
    {
        /// <summary>
        /// Determines whether the specified <see cref="char"/> is a digit.
        /// </summary>
        /// <param name="chr">The character to evaluate.</param>
        /// <returns>
        /// true if <paramref name="chr"/> is a digit; otherwise, false.
        /// </returns>
        public static bool IsDigit(this char chr) => char.IsDigit(chr);

        /// <summary>
        /// Determines whether the specified <see cref="char"/> is a letter.
        /// </summary>
        /// <param name="chr">The character to evaluate.</param>
        /// <returns>
        /// true if <paramref name="chr"/> is a letter; otherwise, false.
        /// </returns>
        public static bool IsLetter(this char chr) => char.IsLetter(chr);
    }
}
