// <copyright file="IntegerExtensions.cs" company="Corvus">
// Copyright (c) Corvus. All rights reserved.
// </copyright>

namespace System
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions to <see cref="int"/>.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Convenient replacement for a range 'for' loop. e.g. return an array of int from 10 to 20:
        /// int[] tenToTwenty = 10.To(20).ToArray();.
        /// </summary>
        /// <param name="from">Start number.</param>
        /// <param name="to">End number (inclusive).</param>
        /// <returns>The currently enumerated item.</returns>
        public static IEnumerable<int> To(this int from, int to)
        {
            return Enumerable.Range(from, (to - from) + 1);
        }
    }
}