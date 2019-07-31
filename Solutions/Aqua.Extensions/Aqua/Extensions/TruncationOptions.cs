// <copyright file="TruncationOptions.cs" company="Aqua">
// Copyright (c) Aqua. All rights reserved.
// </copyright>

namespace System
{
    /// <summary>
    /// Algorithms for truncating strings.
    /// </summary>
    [Flags]
    public enum TruncationOptions
    {
        /// <summary>
        /// No truncation
        /// </summary>
        None = 0,

        /// <summary>
        /// Add an ellipsis
        /// </summary>
        AddEllipsis = 1,

        /// <summary>
        /// Constrain to whole words
        /// </summary>
        RemovePartialWords = 2,
    }
}