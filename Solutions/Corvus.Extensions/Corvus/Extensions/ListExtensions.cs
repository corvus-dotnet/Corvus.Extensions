// <copyright file="ListExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace System.Collections.Generic
{
    /// <summary>
    /// Extensions for <see cref="IList{T}"/>.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        ///  Remove all the items in the list which match a particular predicate.
        /// </summary>
        /// <typeparam name="T">The type of items in the list.</typeparam>
        /// <param name="destination">The list from which to remove items.</param>
        /// <param name="match">The predicate.</param>
        public static void RemoveAll<T>(this IList<T> destination, Predicate<T> match)
        {
            if (destination is List<T> list)
            {
                list.RemoveAll(match);
            }
            else
            {
                new List<T>(destination).ForEachAtIndex((i, j) =>
                {
                    if (match(i))
                    {
                        destination.RemoveAt(j);
                    }
                });
            }
        }
    }
}