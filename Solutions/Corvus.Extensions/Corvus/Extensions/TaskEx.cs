// <copyright file="TaskEx.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Extensions to Task.* methods.
    /// </summary>
    public static class TaskEx
    {
        /// <summary>
        ///  Flattening of the outputs from Task.WhenAll.
        /// </summary>
        /// <typeparam name="T1">The type of the items in the source list.</typeparam>
        /// <typeparam name="T2">The type of the items in the resulting list.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="mapper">The function used to map from each item in the source list to the result.</param>
        /// <returns>A fanned out list of T2.</returns>
        public static async Task<IList<T2>> WhenAllMany<T1, T2>(IEnumerable<T1> source, Func<T1, Task<IEnumerable<T2>>> mapper)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            return (await Task.WhenAll(
                source.Select(sourceItem => mapper(sourceItem))).ConfigureAwait(false))
                .SelectMany(result => result).ToList();
        }
    }
}
