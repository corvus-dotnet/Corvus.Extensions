// <copyright file="CastTo.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Class to cast to a sepcified type.
    /// </summary>
    /// <typeparam name="T">Target type.</typeparam>
    /// <remarks>
    /// The original code was derived from a StackOverlow answer here https://stackoverflow.com/a/23391746.
    /// </remarks>
    public static class CastTo<T>
    {
        /// <summary>
        /// Casts from the source type to the target type.
        /// </summary>
        /// <param name="s">An instance of the source type to be case to the target type.</param>
        /// <typeparam name="TSource">Source type to cast from. Usually a generic type.</typeparam>
        /// <returns>An instance of the target type, cast from the source type.</returns>
        /// <remarks>
        /// This does not cause boxing for value types. It is especially useful in generic methods.
        /// </remarks>
        public static T From<TSource>(TSource s)
        {
            return Cache<TSource>.Caster(s);
        }

        private static class Cache<TSsource>
        {
            public static readonly Func<TSsource, T> Caster = Get();

            private static Func<TSsource, T> Get()
            {
                ParameterExpression p = Expression.Parameter(typeof(TSsource));
                UnaryExpression c = Expression.ConvertChecked(p, typeof(T));
                return Expression.Lambda<Func<TSsource, T>>(c, p).Compile();
            }
        }
    }
}
