// --------------------------------------------------------------------------
// <copyright file="IntExtension.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;

namespace OdeyTech.ProductivityKit.Extension
{
  /// <summary>
  /// Provides extension methods for int objects related to DateTime.
  /// </summary>
  public static class IntExtension
  {
    /// <summary>
    /// Creates a DateTime object for the specified day in January.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in January.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(10, 1, 2023);
    /// After:
    ///     var data = 10.January(2023);
    /// </example>
    public static DateTime January(this int day, int year) => new(year, 1, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in February.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in February.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(14, 2, 2023);
    /// After:
    ///     var data = 14.February(2023);
    /// </example>
    public static DateTime February(this int day, int year) => new(year, 2, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in March.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in March.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(8, 3, 2023);
    /// After:
    ///     var data = 8.March(2023);
    /// </example>
    public static DateTime March(this int day, int year) => new(year, 3, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in April.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in April.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(1, 4, 2023);
    /// After:
    ///     var data = 1.April(2023);
    /// </example>
    public static DateTime April(this int day, int year) => new(year, 4, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in May.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in May.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(20, 5, 2023);
    /// After:
    ///     var data = 20.May(2023);
    /// </example>
    public static DateTime May(this int day, int year) => new(year, 5, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in June.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in June.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(3, 6, 2023);
    /// After:
    ///     var data = 3.June(2023);
    /// </example>
    public static DateTime June(this int day, int year) => new(year, 6, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in July.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in July.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(17, 7, 2023);
    /// After:
    ///     var data = 17.July(2023);
    /// </example>
    public static DateTime July(this int day, int year) => new(year, 7, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in August.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in August.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(12, 8, 2023);
    /// After:
    ///     var data = 12.August(2023);
    /// </example>
    public static DateTime August(this int day, int year) => new(year, 8, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in September.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in September.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(22, 9, 2023);
    /// After:
    ///     var data = 22.September(2023);
    /// </example>
    public static DateTime September(this int day, int year) => new(year, 9, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in October.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in October.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(7, 10, 2023);
    /// After:
    ///     var data = 7.October(2023);
    /// </example>
    public static DateTime October(this int day, int year) => new(year, 10, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in November.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in November.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(11, 11, 2023);
    /// After:
    ///     var data = 11.November(2023);
    /// </example>
    public static DateTime November(this int day, int year) => new(year, 11, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in December.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in December.</returns>
    /// <example>
    /// Before:
    ///     var data = new DataTime(25, 12, 2023);
    /// After:
    ///     var data = 25.December(2023);
    /// </example>
    public static DateTime December(this int day, int year) => new(year, 12, day);
  }
}