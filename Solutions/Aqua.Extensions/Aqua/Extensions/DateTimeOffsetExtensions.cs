// <copyright file="DateTimeOffsetExtensions.cs" company="Aqua">
// Copyright (c) Aqua. All rights reserved.
// </copyright>

namespace System
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Extensions for <see cref="DateTimeOffset"/>.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        private const string Separator = "-";

        /// <summary>
        /// Get the minimum of two dates.
        /// </summary>
        /// <param name="first">The first date.</param>
        /// <param name="second">The second date.</param>
        /// <returns>The earlier of the two dates.</returns>
        public static DateTimeOffset Minimum(DateTimeOffset first, DateTimeOffset second)
        {
            return first <= second ? first : second;
        }

        /// <summary>
        /// Get the maximum of two dates.
        /// </summary>
        /// <param name="first">The first date.</param>
        /// <param name="second">The second date.</param>
        /// <returns>The later of the two dates.</returns>
        public static DateTimeOffset Maximum(DateTimeOffset first, DateTimeOffset second)
        {
            return first >= second ? first : second;
        }

        /// <summary>
        /// Get the minimum of two nullable dates.
        /// </summary>
        /// <param name="first">The first date.</param>
        /// <param name="second">The second date.</param>
        /// <returns>The earlier of the two dates, or null if either is null.</returns>
        public static DateTimeOffset? Minimum(DateTimeOffset? first, DateTimeOffset? second)
        {
            if (!first.HasValue || !second.HasValue)
            {
                return null;
            }

            return first <= second ? first : second;
        }

        /// <summary>
        /// Get the maximum of two dates.
        /// </summary>
        /// <param name="first">The first date.</param>
        /// <param name="second">The second date.</param>
        /// <returns>The later of the two dates, or null if either is null.</returns>
        public static DateTimeOffset? Maximum(DateTimeOffset? first, DateTimeOffset? second)
        {
            if (!first.HasValue || !second.HasValue)
            {
                return null;
            }

            return first >= second ? first : second;
        }

        /// <summary>
        /// Create a string representing the approximate difference between two times.
        /// </summary>
        /// <param name="dateTime">The time.</param>
        /// <param name="startTime">The reference time.</param>
        /// <returns>The difference between the start time and the current time, expressed as a localised string.</returns>
        public static string CalculateApproximateTimeDifferenceFrom(this DateTimeOffset dateTime, DateTimeOffset startTime)
        {
            return startTime.Subtract(dateTime).TotalMinutes.RoundTime();
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <param name="suffix">A suffix to append.</param>
        /// <returns>A universal, sortable string representation of the time, with the suffix appended.</returns>
        public static string CreateChronological(this DateTimeOffset dateTime, string suffix)
        {
            return FormatKey(dateTime.UtcTicks, suffix);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time.</returns>
        public static string CreateChronological(this DateTimeOffset dateTime)
        {
            long ticks = dateTime.UtcTicks;

            return string.Format("{0:d21}", ticks);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, as a base for appending a suffix.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>A universal, sortable string representation of the time, with a hyphen appended as a separator for a suffix.</returns>
        /// <remarks>
        /// This is generally used when preparing greater than / less than string comparisons for a sortable string generated using <see cref="CreateChronological(DateTimeOffset,string)"/>.
        /// </remarks>
        public static string CreateChronologicalStemForSuffix(this DateTimeOffset dateTime)
        {
            return CreateChronological(dateTime, string.Empty);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, with a guid appended as a suffix.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, with a guid appended as a suffix.</returns>
        public static string CreateChronologicalWithUniqueSuffix(this DateTimeOffset dateTime)
        {
            return CreateChronological(dateTime, Guid.NewGuid().ToString("N").ToUpper());
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, which will naturally order
        /// latest first.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, which will order latest first.</returns>
        public static string CreateReverseChronological(this DateTimeOffset dateTime)
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
        public static string CreateReverseChronological(this DateTimeOffset dateTime, string suffix)
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
        /// This is generally used when preparing greater than / less than string comparisons for a sortable string generated using <see cref="CreateReverseChronological(DateTimeOffset, string)"/>.
        /// </remarks>
        public static string CreateReverseChronologicalStemForSuffix(this DateTimeOffset dateTime)
        {
            return CreateReverseChronological(dateTime, string.Empty);
        }

        /// <summary>
        /// Create a value representing the specified time as a universal, sortable string, with a guid appended as a suffix, which will naturally order
        /// latest first.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>A universal, sortable string representation of the time, with a unique suffix, which will order latest first.</returns>
        public static string CreateReverseChronologicalWithUniqueSuffix(this DateTimeOffset dateTime)
        {
            return CreateReverseChronological(dateTime, Guid.NewGuid().ToString("N").ToUpper());
        }

        /// <summary>
        /// Get the last millisecond at the end of the specified day.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>The last millisecond at the end of that day.</returns>
        public static DateTimeOffset EndOfDay(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59, 999, dateTime.Offset);
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
        public static IEnumerable<DateTimeOffset> ForEachDayUntil(this DateTimeOffset from, DateTimeOffset to, bool includeEnd = true)
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
        public static DateTimeOffset FromUnixTime(this long unixTime)
        {
            var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

            return epoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Provide a <see cref="DateTime"/> representing midnight on the last day of the month containing the provided date and time.
        /// </summary>
        /// <param name="dateTime">The date time to search.</param>
        /// <returns>The DateTime representing the last day of the month.</returns>
        public static DateTimeOffset LastDayOfMonth(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 0, 0, 0, dateTime.Offset);
        }

        /// <summary>
        /// Calculates a date based on a reference date, and two-digit year and month strings.
        /// </summary>
        /// <param name="currentDate">The current date.</param>
        /// <param name="month">The two-digit month string.</param>
        /// <param name="year">The two-digit year string.</param>
        /// <returns>A date representing the first day of the year and month specified.</returns>
        public static DateTimeOffset? ToDateTimeOffset(DateTimeOffset currentDate, string month, string year)
        {
            if (month.IsNullOrEmpty() || year.IsNullOrEmpty())
            {
                return null;
            }

            int thisCentury = (currentDate.Year / 100) * 100;
            int todayYear = currentDate.Year;

            int expiryYear = int.Parse(year);
            int expiryMonth = int.Parse(month);

            int up = thisCentury + expiryYear;
            int down = thisCentury - (100 - expiryYear);

            int upDiff = Math.Abs(up - todayYear);
            int downDiff = Math.Abs(down - todayYear);

            // Work out whether the 2 digit expiry year is closer to the the next occurence or previous occurence (e.g. 2047 or 1947)
            // Picks down if the two are equal
            var expiryDate = new DateTimeOffset(upDiff < downDiff ? up : down, expiryMonth, 1, 0, 0, 0, TimeSpan.Zero);
            expiryDate = expiryDate.AddMonths(1);
            return expiryDate.AddDays(-1);
        }

        /// <summary>
        /// Convert a DateTime to the UNIX epoch representation.
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>A long representing the number of seconds since the UNIX epoch (1/1/1970).</returns>
        /// <remarks>Note that this will convert the DateTime to UTC before performing the conversion.</remarks>
        public static long ToUnixTime(this DateTimeOffset date)
        {
            var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        /// <summary>
        /// Gets the week number of the current date, using the ambient culture.
        /// </summary>
        /// <param name="date">The reference date.</param>
        /// <returns>The week number of the date.</returns>
        public static int GetWeekNumber(this DateTimeOffset date)
        {
            return DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(date.Date, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }

        /// <summary>
        /// Determine if one date is the same or before another, at the specified level of granularity.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <param name="granularity">The required granularity.</param>
        /// <returns>True if the the first date is earlier than (or the same as) the second date, at the specified granularity.</returns>
        public static bool IsSameOrBeforeWithGranularity(this DateTimeOffset lhs, DateTimeOffset rhs, DateTimeOffsetGranularity granularity)
        {
            switch (granularity)
            {
                case DateTimeOffsetGranularity.Second:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day < rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour < rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute < rhs.Minute)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Minute) && lhs.Second <= rhs.Second);
                case DateTimeOffsetGranularity.Minute:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day < rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour < rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute <= rhs.Minute);
                case DateTimeOffsetGranularity.Hour:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day < rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour <= rhs.Hour);
                case DateTimeOffsetGranularity.Day:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day <= rhs.Day);
                case DateTimeOffsetGranularity.Week:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.GetWeekNumber() <= rhs.GetWeekNumber());
                case DateTimeOffsetGranularity.Month:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month <= rhs.Month);
                case DateTimeOffsetGranularity.Year:
                    return lhs.Year <= rhs.Year;
                case DateTimeOffsetGranularity.Decade:
                    return (lhs.Year - (lhs.Year % 10)) <= (rhs.Year - (rhs.Year % 10));
                case DateTimeOffsetGranularity.Century:
                    return (lhs.Year - (lhs.Year % 100)) <= (rhs.Year - (rhs.Year % 100));
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determine if one date is the same as another, at the specified level of granularity.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <param name="granularity">The required granularity.</param>
        /// <returns>True if the the first date is earlier than the second date, at the specified granularity.</returns>
        public static bool IsBeforeWithGranularity(this DateTimeOffset lhs, DateTimeOffset rhs, DateTimeOffsetGranularity granularity)
        {
            switch (granularity)
            {
                case DateTimeOffsetGranularity.Second:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day < rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour < rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute < rhs.Minute)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Minute) && lhs.Second < rhs.Second);
                case DateTimeOffsetGranularity.Minute:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day < rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour < rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute < rhs.Minute);
                case DateTimeOffsetGranularity.Hour:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day < rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour < rhs.Hour);
                case DateTimeOffsetGranularity.Day:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day < rhs.Day);
                case DateTimeOffsetGranularity.Week:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.GetWeekNumber() < rhs.GetWeekNumber());
                case DateTimeOffsetGranularity.Month:
                    return lhs.Year < rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month < rhs.Month);
                case DateTimeOffsetGranularity.Year:
                    return lhs.Year < rhs.Year;
                case DateTimeOffsetGranularity.Decade:
                    return (lhs.Year - (lhs.Year % 10)) < (rhs.Year - (rhs.Year % 10));
                case DateTimeOffsetGranularity.Century:
                    return (lhs.Year - (lhs.Year % 100)) < (rhs.Year - (rhs.Year % 100));
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determine if one date is the after another, at the specified level of granularity.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <param name="granularity">The required granularity.</param>
        /// <returns>True if the the first date is later than the second date, at the specified granularity.</returns>
        public static bool IsAfterWithGranularity(this DateTimeOffset lhs, DateTimeOffset rhs, DateTimeOffsetGranularity granularity)
        {
            switch (granularity)
            {
                case DateTimeOffsetGranularity.Second:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day > rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour > rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute > rhs.Minute)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Minute) && lhs.Second > rhs.Second);
                case DateTimeOffsetGranularity.Minute:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day > rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour > rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute > rhs.Minute);
                case DateTimeOffsetGranularity.Hour:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day > rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour > rhs.Hour);
                case DateTimeOffsetGranularity.Day:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day > rhs.Day);
                case DateTimeOffsetGranularity.Week:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.GetWeekNumber() > rhs.GetWeekNumber());
                case DateTimeOffsetGranularity.Month:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month);
                case DateTimeOffsetGranularity.Year:
                    return lhs.Year > rhs.Year;
                case DateTimeOffsetGranularity.Decade:
                    return (lhs.Year - (lhs.Year % 10)) > (rhs.Year - (rhs.Year % 10));
                case DateTimeOffsetGranularity.Century:
                    return (lhs.Year - (lhs.Year % 100)) > (rhs.Year - (rhs.Year % 100));
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determine if one date is the same or after another, at the specified level of granularity.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <param name="granularity">The required granularity.</param>
        /// <returns>True if the the first date is later than (or the same as) the second date, at the specified granularity.</returns>
        public static bool IsSameOrAfterWithGranularity(this DateTimeOffset lhs, DateTimeOffset rhs, DateTimeOffsetGranularity granularity)
        {
            switch (granularity)
            {
                case DateTimeOffsetGranularity.Second:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day > rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour > rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute > rhs.Minute)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Minute) && lhs.Second >= rhs.Second);
                case DateTimeOffsetGranularity.Minute:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day > rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour > rhs.Hour)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Hour) && lhs.Minute >= rhs.Minute);
                case DateTimeOffsetGranularity.Hour:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day > rhs.Day)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Day) && lhs.Hour >= rhs.Hour);
                case DateTimeOffsetGranularity.Day:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.Day >= rhs.Day);
                case DateTimeOffsetGranularity.Week:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month > rhs.Month)
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Month) && lhs.GetWeekNumber() >= rhs.GetWeekNumber());
                case DateTimeOffsetGranularity.Month:
                    return lhs.Year > rhs.Year
                        || (lhs.IsSameWithGranularity(rhs, DateTimeOffsetGranularity.Year) && lhs.Month >= rhs.Month);
                case DateTimeOffsetGranularity.Year:
                    return lhs.Year >= rhs.Year;
                case DateTimeOffsetGranularity.Decade:
                    return (lhs.Year - (lhs.Year % 10)) >= (rhs.Year - (rhs.Year % 10));
                case DateTimeOffsetGranularity.Century:
                    return (lhs.Year - (lhs.Year % 100)) >= (rhs.Year - (rhs.Year % 100));
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determine if one date is the same as another, at the specified level of granularity.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <param name="granularity">The required granularity.</param>
        /// <returns>True if the the first date is the same as the second date, at the specified granularity.</returns>
        public static bool IsSameWithGranularity(this DateTimeOffset lhs, DateTimeOffset rhs, DateTimeOffsetGranularity granularity)
        {
            switch (granularity)
            {
                case DateTimeOffsetGranularity.Second:
                    return lhs.Year == rhs.Year
                        && lhs.Month == rhs.Month
                        && lhs.Day == rhs.Day
                        && lhs.Hour == rhs.Hour
                        && lhs.Minute == rhs.Minute
                        && lhs.Second == rhs.Second;
                case DateTimeOffsetGranularity.Minute:
                    return lhs.Year == rhs.Year
                        && lhs.Month == rhs.Month
                        && lhs.Day == rhs.Day
                        && lhs.Hour == rhs.Hour
                        && lhs.Minute == rhs.Minute;
                case DateTimeOffsetGranularity.Hour:
                    return lhs.Year == rhs.Year
                        && lhs.Month == rhs.Month
                        && lhs.Day == rhs.Day
                        && lhs.Hour == rhs.Hour;
                case DateTimeOffsetGranularity.Day:
                    return lhs.Year == rhs.Year
                        && lhs.Month == rhs.Month
                        && lhs.Day == rhs.Day;
                case DateTimeOffsetGranularity.Week:
                    return lhs.Year == rhs.Year
                        && lhs.Month == rhs.Month
                        && lhs.GetWeekNumber() == rhs.GetWeekNumber();
                case DateTimeOffsetGranularity.Month:
                    return lhs.Year == rhs.Year
                        && lhs.Month == rhs.Month;
                case DateTimeOffsetGranularity.Year:
                    return lhs.Year == rhs.Year;
                case DateTimeOffsetGranularity.Decade:
                    return (lhs.Year - (lhs.Year % 10)) == (rhs.Year - (rhs.Year % 10));
                case DateTimeOffsetGranularity.Century:
                    return (lhs.Year - (lhs.Year % 100)) == (rhs.Year - (rhs.Year % 100));
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines if the two dates are within a specified range of each other.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <param name="timeSpan">The range.</param>
        /// <returns>True if the absolute difference between the two values is less than the specified timespan. The resolution used is the tick.</returns>
        public static bool IsWithinRange(this DateTimeOffset lhs, DateTimeOffset rhs, TimeSpan timeSpan)
        {
            return Math.Abs((lhs - rhs).Ticks) < timeSpan.Ticks;
        }

        private static string FormatKey(long ticks, string suffix)
        {
            return string.Format("{0:d21}{1}{2}", ticks, Separator, suffix);
        }

        private static long GetTicksDescending(DateTimeOffset dateTimeOffset)
        {
            return DateTimeOffset.MaxValue.UtcTicks - dateTimeOffset.UtcTicks;
        }
    }
}