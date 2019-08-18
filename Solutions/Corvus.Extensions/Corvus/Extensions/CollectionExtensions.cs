// <copyright file="CollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace System.Collections.Generic
{
    using System.Linq;

    /// <summary>
    /// Extensions for <see cref="ICollection{T}"/>.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Add a range of items to the collection.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="destination">The collection to which items will be added.</param>
        /// <param name="items">The items to add.</param>
        public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> items)
        {
            items.ForEach(t => destination.Add(t));
        }
    }
}