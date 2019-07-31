// <copyright file="DateTimeWithTimeZone.cs" company="Aqua">
// Copyright (c) Aqua. All rights reserved.
// </copyright>

namespace System
{
    /// <summary>
    /// Represents a date time with its original local time zone information.
    /// </summary>
    public struct DateTimeWithTimeZone : IEquatable<DateTimeWithTimeZone>, IComparable<DateTimeWithTimeZone>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeWithTimeZone"/> struct.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="timeZone">The time zone ID string.</param>
        public DateTimeWithTimeZone(DateTime dateTime, string timeZone)
            : this()
        {
            this.DateTime = dateTime;
            this.TimeZoneId = timeZone;
        }

        /// <summary>
        /// Gets the current date time, using the ambient local time zone.
        /// </summary>
        public static DateTimeWithTimeZone Now
        {
            get
            {
                return new DateTimeWithTimeZone(DateTime.Now, TimeZoneInfo.Local.Id);
            }
        }

        /// <summary>
        /// Gets the date time portion.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// Gets the time zone ID.
        /// </summary>
        public string TimeZoneId { get; }

        /// <summary>
        /// Compares two dates.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <returns>True if the date times match, regardless of time zone.</returns>
        public static bool operator ==(DateTimeWithTimeZone lhs, DateTimeWithTimeZone rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Compares two dates.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <returns>True if the date times do not match, regardless of time zone.</returns>
        public static bool operator !=(DateTimeWithTimeZone lhs, DateTimeWithTimeZone rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Compares two dates.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <returns>True if the first date is later than the second date, regardless of time zone.</returns>
        public static bool operator >(DateTimeWithTimeZone lhs, DateTimeWithTimeZone rhs) => lhs.DateTime > rhs.DateTime;

        /// <summary>
        /// Compares two dates.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <returns>True if the first date is earlier than the second date, regardless of time zone.</returns>
        public static bool operator <(DateTimeWithTimeZone lhs, DateTimeWithTimeZone rhs) => lhs.DateTime < rhs.DateTime;

        /// <summary>
        /// Compares two dates.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <returns>True if the first date is later than or the same as the second date, regardless of time zone.</returns>
        public static bool operator >=(DateTimeWithTimeZone lhs, DateTimeWithTimeZone rhs) => lhs.DateTime >= rhs.DateTime;

        /// <summary>
        /// Compares two dates.
        /// </summary>
        /// <param name="lhs">The first date.</param>
        /// <param name="rhs">The second date.</param>
        /// <returns>True if the first date is earlier than or the same as the second date, regardless of time zone.</returns>
        public static bool operator <=(DateTimeWithTimeZone lhs, DateTimeWithTimeZone rhs) => lhs.DateTime <= rhs.DateTime;

        /// <summary>
        /// Compares this date with another.
        /// </summary>
        /// <param name="obj">The second date.</param>
        /// <returns>True if the object to compare is a DateTimeWithTimeZone, and the date times match, regardless of time zone.</returns>
        public override bool Equals(object obj)
        {
            if (obj is DateTimeWithTimeZone other)
            {
                return this.Equals(other);
            }

            return false;
        }

        /// <summary>
        /// Compares this date with another.
        /// </summary>
        /// <param name="other">The date to compare.</param>
        /// <returns>True if the date times and time zone IDs match.</returns>
        public bool ExactlyMatches(DateTimeWithTimeZone other)
        {
            return this.DateTime == other.DateTime && this.TimeZoneId == other.TimeZoneId;
        }

        /// <summary>
        /// Compares this date with another.
        /// </summary>
        /// <param name="other">The date to compare.</param>
        /// <returns>True if the date times match, regardless of time zone.</returns>
        public bool Equals(DateTimeWithTimeZone other)
        {
            return
                this.DateTime == other.DateTime;
        }

        /// <summary>
        /// Get a hash code for the object, based on the date time, regardless of time zone.
        /// </summary>
        /// <returns>A hash code.</returns>
        public override int GetHashCode()
        {
            return this.DateTime.GetHashCode();
        }

        /// <summary>
        /// Compares this date with another.
        /// </summary>
        /// <param name="other">The date to compare.</param>
        /// <returns>0 if the two are equal, 1 if this is later than the other, and -1 if this is earlier than the other, regardless of time zone.</returns>
        public int CompareTo(DateTimeWithTimeZone other)
        {
            if (this.Equals(other))
            {
                return 0;
            }

            if (this > other)
            {
                return 1;
            }

            return -1;
        }
    }
}
