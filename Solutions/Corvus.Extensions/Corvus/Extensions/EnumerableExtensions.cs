// <copyright file="EnumerableExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Gets the distinct values from the collection, preserving ordering.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="list">The enumerable of items.</param>
        /// <returns>An enumerable of the distinct items in the enumerable.</returns>
        public static IEnumerable<T> DistinctPreserveOrder<T>(this IEnumerable<T> list)
        {
            var hashSet = new HashSet<T>();
            foreach (T item in list)
            {
                if (hashSet.Contains(item))
                {
                    continue;
                }

                hashSet.Add(item);
                yield return item;
            }
        }

        /// <summary>
        /// Concatenates a set of enumerables.
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable.</typeparam>
        /// <param name="first">The first enumerable.</param>
        /// <param name="lists">Second and subsequent items.</param>
        /// <returns>An enumerable which concatenates the prvovided lists.</returns>
        public static IEnumerable<T> Concatenate<T>(this IEnumerable<T> first, params IEnumerable<T>[] lists)
        {
            foreach (T item in first)
            {
                yield return item;
            }

            foreach (IEnumerable<T> list in lists)
            {
                foreach (T item in list)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Determine if an enumerable has at least a specified number of items.
        /// </summary>
        /// <typeparam name="T">The type of item in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to test.</param>
        /// <param name="count">The minumum number of items.</param>
        /// <returns>True if the enumerable contains at least this number of items.</returns>
        public static bool HasMinimumCount<T>(this IEnumerable<T> enumerable, int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.EnumerableExtensions_HasMinimumCount_CountMustBeGreaterThanZero);
            }

            if (enumerable is ICollection<T> collection)
            {
                return collection.Count >= count;
            }

            return enumerable.Skip(count - 1).Any();
        }

        /// <summary>
        /// Determine if an enumerable is non-empty and all elements meet a particular criterion.
        /// </summary>
        /// <typeparam name="T">The type of item in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to test.</param>
        /// <param name="predicate">The test to apply.</param>
        /// <returns>
        /// True if the enumerable has at least one item, and the predicate returned true for all
        /// of them. False if the enumerable was empty, or if it contains at least one item for
        /// which the predicate returns false.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The standard LINQ <c>All</c> operator has the sometimes-undesirable characteristic of
        /// reporting what logicians call a 'vacuous truth', i.e., that it returns true if you pass
        /// it empty input. This is in keeping with the standard definition of the universal
        /// quantifier in formal logic, but it's not always what you want.
        /// </para>
        /// </remarks>
        public static bool AllAndAtLeastOne<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            // Logically, this is:
            //  enumerable.Any() && enumerable.All(predicate)
            // However that's inefficient because it will start to enumerate twice. (The Any and
            // All operators will each create their own enumerators. Admittedly, Any does not
            // proceed to the end, but some enumerables do work at the start of each enumeration,
            // and we'd like to avoid that, since it's unnecessary.)
            // This enumerates through the items just once, and will (like All) bail out early if
            // it detects an item that fails the test.
            bool atLeastOne = false;
            foreach (T item in enumerable)
            {
                if (!predicate(item))
                {
                    return false;
                }

                atLeastOne = true;
            }

            return atLeastOne;
        }

        /// <summary>
        /// Distinct operator enabling lambda-based criteria.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TIdentity">The type on which uniqueness is based.</typeparam>
        /// <param name="source">The source elements.</param>
        /// <param name="identitySelector">
        /// A callback that returns the value to use to determine whether elements are distinct.
        /// E.g. this might pull out an 'id' property.
        /// </param>
        /// <returns>The distinct elements.</returns>
        public static IEnumerable<T> DistinctBy<T, TIdentity>(this IEnumerable<T> source, Func<T, TIdentity> identitySelector)
        {
            return source.Distinct(new DelegateEqualityComparer<T, TIdentity>(identitySelector));
        }

        private class DelegateEqualityComparer<T, TIdentity> : IEqualityComparer<T>
        {
            private readonly Func<T, TIdentity> identitySelector;

            public DelegateEqualityComparer(Func<T, TIdentity> identitySelector)
            {
                this.identitySelector = identitySelector;
            }

            public bool Equals(T x, T y) => Equals(this.identitySelector(x), this.identitySelector(y));

            public int GetHashCode(T obj) => this.identitySelector(obj).GetHashCode();
        }
    }
}