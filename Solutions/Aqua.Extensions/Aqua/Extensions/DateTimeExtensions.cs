// <copyright file="DateTimeExtensions.cs" company="Aqua">
// Copyright (c) Aqua. All rights reserved.
// </copyright>

namespace System
{
    using System.Collections.Generic;
    using Aqua.Extensions;

    /// <summary>
    /// Extensions to the DateTime class.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Create a string representing the approximate difference between two times.
        /// </summary>
        /// <param name="dateTime">The time.</param>
        /// <param name="startTime">The reference time.</param>
        /// <returns>The difference between the start time and the current time, expressed as a localised string.</returns>
        public static string CalculateApproximateTimeDifferenceFrom(this DateTime dateTime, DateTime startTime)
        {
            return RoundTime(startTime.Subtract(dateTime).TotalMinutes);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <param name="suffix">A suffix to append.</param>
        /// <returns>A universal, sortable string representation of the time, with the suffix appended.</returns>
        public static string CreateChronological(this DateTime dateTime, string suffix)
        {
            return FormatKey(GetTicksChronological(dateTime), suffix);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time.</returns>
        public static string CreateChronological(this DateTime dateTime)
        {
            long ticks = GetTicksChronological(dateTime);

            return string.Format("{0:d21}", ticks);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, as a base for appending a suffix.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, with a hyphen appended as a separator for a suffix.</returns>
        /// <remarks>
        /// This is generally used when preparing greater than / less than string comparisons for a sortable string generated using <see cref="CreateChronological(DateTime, string)"/>.
        /// </remarks>
        public static string CreateChronologicalStemForSuffix(this DateTime dateTime)
        {
            return CreateChronological(dateTime, string.Empty);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, with a guid appended as a suffix.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, with a guid appended as a suffix.</returns>
        public static string CreateChronologicalWithUniqueSuffix(this DateTime dateTime)
        {
            return CreateChronological(dateTime, Guid.NewGuid().ToString("N").ToUpper());
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, which will naturally order
        /// latest first.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, which will order latest first.</returns>
        public static string CreateReverseChronological(this DateTime dateTime)
        {
            long ticks = GetTicksDescending(dateTime);

            return string.Format("{0:d21}", ticks);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, which will naturally order
        /// latest first.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <param name="suffix">A suffix to append.</param>
        /// <returns>A universal, sortable string representation of the time, with the suffix appended, which will order latest first.</returns>
        public static string CreateReverseChronological(this DateTime dateTime, string suffix)
        {
            return FormatKey(GetTicksDescending(dateTime), suffix);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, as a base for appending a suffix, which will naturally order
        /// latest first.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, with a hyphen appended as a separator for a suffix, which will order latest first.</returns>
        /// <remarks>
        /// This is generally used when preparing greater than / less than string comparisons for a sortable string generated using <see cref="CreateReverseChronological(DateTime, string)"/>.
        /// </remarks>
        public static string CreateReverseChronologicalStemForSuffix(this DateTime dateTime)
        {
            return CreateReverseChronological(dateTime, string.Empty);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, with a guid appended as a suffix, which will naturally order
        /// latest first.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, with a guid appended as a suffix, which will order latest first.</returns>
        public static string CreateReverseChronologicalWithUniqueSuffix(this DateTime dateTime)
        {
            return CreateReverseChronological(dateTime, Guid.NewGuid().ToString("N").ToUpper());
        }

        /// <summary>
        /// Create an enumerable of date time objects from the start date up to the end date.
        /// </summary>
        /// <param name="from">The start date.</param>
        /// <param name="to">The end date.</param>
        /// <param name="includeEnd">Whether to include the end date in the result set.</param>
        /// <returns>
        /// <para>
        /// An enumerable which includes a date time from each day from the first day to the last day.
        /// </para>
        /// <para>
        /// Note that the time portion will not be preserved.
        /// </para>
        /// </returns>
        public static IEnumerable<DateTime> ForEachDayUntil(this DateTime from, DateTime to, bool includeEnd = true)
        {
            DateTime start = from.Date;
            DateTime end = to.Date;
            int increment = start <= end ? 1 : -1;
            if (includeEnd)
            {
                end = end.AddDays(increment);
            }

            for (DateTime day = start; day != end; day = day.AddDays(increment))
            {
                yield return day;
            }
        }

        /// <summary>
        /// Construct a <see cref="DateTime"/> from a UNIX time.
        /// </summary>
        /// <param name="unixTime">The UNIX time offset in seconds from the UNIX Epoch (1/1/1970).</param>
        /// <returns>A UTC DateTime which represents the UNIX time.</returns>
        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Provide a <see cref="DateTime"/> representing midnight on the last day of the month containing the provided date and time.
        /// </summary>
        /// <param name="dateTime">The date time to search.</param>
        /// <returns>The DateTime representing the last day of the month.</returns>
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        /// <summary>
        /// Provides a string representation of the approximate time using the current culture.
        /// </summary>
        /// <param name="totalMinutes">A time in minutes.</param>
        /// <returns>A string representing an approximate, colloquial representation of the time.</returns>
        public static string RoundTime(this double totalMinutes)
        {
            if (totalMinutes < 1)
            {
                return Strings.RoundTimeLessThanAMinute;
            }

            if (totalMinutes < 1.5)
            {
                return Strings.RoundTimeAboutOneMinute;
            }

            if (totalMinutes < 50)
            {
                return Strings.RoundTimeTotalMinutes.FormatWith(totalMinutes);
            }

            if (totalMinutes < 90)
            {
                return Strings.RoundTimeAboutOneHour;
            }

            if (totalMinutes < 1080)
            {
                return Strings.RoundTimeHours.FormatWith(Math.Round(new decimal(totalMinutes / 60)));
            }

            if (totalMinutes < 2880)
            {
                return Strings.RoundTimeAboutOneDay;
            }

            return Strings.RoundTimeDays.FormatWith(Math.Round(new decimal(totalMinutes / 1440)));
        }

        /// <summary>
        /// Convert a DateTime to the UNIX epoch representation.
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>A long representing the number of seconds since the UNIX epoch (1/1/1970).</returns>
        /// <remarks>Note that this will convert the DateTime to UTC before performing the conversion.</remarks>
        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }

        private static string FormatKey(long ticks, string suffix)
        {
            return string.Format("{0:d21}-{1}", ticks, suffix);
        }

        private static long GetTicksChronological(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().Ticks;
        }

        private static long GetTicksDescending(DateTime dateTime)
        {
            return DateTimeOffset.MaxValue.UtcTicks - dateTime.ToUniversalTime().Ticks;
        }
    }
}