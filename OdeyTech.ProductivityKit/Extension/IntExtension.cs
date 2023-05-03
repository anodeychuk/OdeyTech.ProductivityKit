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
    public static DateTime January(this int day, int year) => new(year, 1, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in February.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in February.</returns>
    public static DateTime February(this int day, int year) => new(year, 2, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in March.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in March.</returns>
    public static DateTime March(this int day, int year) => new(year, 3, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in April.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in April.</returns>
    public static DateTime April(this int day, int year) => new(year, 4, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in May.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in May.</returns>
    public static DateTime May(this int day, int year) => new(year, 5, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in June.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in June.</returns>
    public static DateTime June(this int day, int year) => new(year, 6, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in July.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in July.</returns>
    public static DateTime July(this int day, int year) => new(year, 7, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in August.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in August.</returns>
    public static DateTime August(this int day, int year) => new(year, 8, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in September.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in September.</returns>
    public static DateTime September(this int day, int year) => new(year, 9, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in October.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in October.</returns>
    public static DateTime October(this int day, int year) => new(year, 10, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in November.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in November.</returns>
    public static DateTime November(this int day, int year) => new(year, 11, day);

    /// <summary>
    /// Creates a DateTime object for the specified day in December.
    /// </summary>
    /// <param name="day">The day of the month.</param>
    /// <param name="year">The year.</param>
    /// <returns>A DateTime object representing the specified day in December.</returns>
    public static DateTime December(this int day, int year) => new(year, 12, day);
  }
}