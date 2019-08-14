// <copyright file="DateTimeOffsetGranularity.cs" company="Corvus">
// Copyright (c) Corvus. All rights reserved.
// </copyright>

namespace System
{
    /// <summary>
    /// A granularity to use when comparing dates and times.
    /// </summary>
    public enum DateTimeOffsetGranularity
    {
        /// <summary>
        /// Constrain to second
        /// </summary>
        Second,

        /// <summary>
        /// Constrain to minute
        /// </summary>
        Minute,

        /// <summary>
        /// Constrain to hour
        /// </summary>
        Hour,

        /// <summary>
        /// Constrain to day
        /// </summary>
        Day,

        /// <summary>
        /// Constrain to week
        /// </summary>
        Week,

        /// <summary>
        /// Constrain to month
        /// </summary>
        Month,

        /// <summary>
        /// Constrain to year
        /// </summary>
        Year,

        /// <summary>
        /// Constrain to decade
        /// </summary>
        Decade,

        /// <summary>
        /// Constrain to the century
        /// </summary>
        Century,
    }
}