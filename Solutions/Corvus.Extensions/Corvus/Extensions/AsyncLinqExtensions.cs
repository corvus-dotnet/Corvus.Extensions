// <copyright file="AsyncLinqExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace CareerCanvas.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Asynchronous LINQ extensions.
    /// </summary>
    public static class AsyncLinqExtensions
    {
        /// <summary>
        ///  An asynchronous version of the SelectMany operator.
        /// </summary>
        /// <typeparam name="T1">The type of the items in the source list.</typeparam>
        /// <typeparam name="T2">The type of the items in the resulting list.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="mapper">The function used to map from each item in the source list to the result.</param>
        /// <returns>A fanned out list of T2.</returns>
        public static async Task<IEnumerable<T2>> SelectManyAsync<T1, T2>(this IEnumerable<T1> source, Func<T1, Task<IEnumerable<T2>>> mapper)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            var result = new List<T2>();

            return (await Task.WhenAll(source.Select(t => mapper(t))).ConfigureAwait(false)).SelectMany(r => r);
        }

        /// <summary>
        /// An asynchronous version of the Select operator..
        /// </summary>
        /// <typeparam name="T1">The type of items in the source list.</typeparam>
        /// <typeparam name="T2">The type of the items in the result list.</typeparam>
        /// <param name="source">The source list.</param>
        /// <param name="mapper">The function used to map to the results.</param>
        /// <returns>A list of T2.</returns>
        public static async Task<IEnumerable<T2>> SelectAsync<T1, T2>(this IEnumerable<T1> source, Func<T1, Task<T2>> mapper)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            var result = new List<T2>();

            return await Task.WhenAll(source.Select(t => mapper(t))).ConfigureAwait(false);
        }
    }
}
