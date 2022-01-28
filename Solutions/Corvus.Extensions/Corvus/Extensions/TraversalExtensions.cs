// <copyright file="TraversalExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class TraversalExtensions
    {
        /// <summary>
        /// Execute an async action for each item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action and its zero-based index.
        /// </param>
        /// <param name="action">
        /// The action to carry out.
        /// </param>
        /// <param name="cancellationToken">A cancellation token which can be used to abort the operation.</param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <returns>A Task which completes when the enumeration is complete.</returns>
        public static async Task ForEachAsync<T>(this IEnumerable<T> items, Func<T, Task> action, CancellationToken cancellationToken = default)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T obj in items)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await action(obj).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Execute an action for each item in the enumerable,
        /// with the index of the item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action.
        /// </param>
        /// <param name="action">
        /// The action to carry out, which is passed the item and its zero-based index.
        /// </param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        public static void ForEachAtIndex<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            int i = 0;

            foreach (T item in items)
            {
                action(item, i++);
            }
        }

        /// <summary>
        /// Execute an async action for each item in the enumerable, in turn,
        /// with the index of the item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action.
        /// </param>
        /// <param name="action">
        /// The action to carry out, which is passed the item and its zero-based index.
        /// </param>
        /// <param name="cancellationToken">A cancellation token to abort the operation.</param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <returns>The task representing the asynchronous action.</returns>
        public static async Task ForEachAtIndexAsync<T>(this IEnumerable<T> items, Func<T, int, Task> action, CancellationToken cancellationToken = default)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            int i = 0;

            foreach (T item in items)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await action(item, i++).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Execute an action for each item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action and its zero-based index.
        /// </param>
        /// <param name="action">
        /// The action to carry out.
        /// </param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <remarks>If any operation fails, then the enumeration is continued to the end when an <see cref="AggregateException"/> is thrown containing the exceptions thrown by any failed operations.</remarks>
        public static void ForEachFailEnd<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var exceptions = new List<Exception>();

            foreach (T item in items)
            {
                try
                {
                    action(item);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception exception)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        /// <summary>
        /// Execute an action for each item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action and its zero-based index.
        /// </param>
        /// <param name="action">
        /// The action to carry out.
        /// </param>
        /// <param name="cancellationToken">A cancellation token which can be used to abort the operation.</param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <returns>A task which completes when the enumeration has completed.</returns>
        /// <remarks>If any operation fails, then the enumeration is continued to the end when an <see cref="AggregateException"/> is thrown containing the exceptions thrown by any failed operations.</remarks>
        public static async Task ForEachFailEndAsync<T>(this IEnumerable<T> items, Func<T, Task> action, CancellationToken cancellationToken = default)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var exceptions = new List<Exception>();

            foreach (T item in items)
            {
                cancellationToken.ThrowIfCancellationRequested();
                try
                {
                    await action(item).ConfigureAwait(false);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception exception)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions).Flatten();
            }
        }

        /// <summary>
        /// Execute an action for each item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action and its zero-based index.
        /// </param>
        /// <param name="action">
        /// The action to carry out.
        /// </param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <returns>False if the enumeration returned early, otherwise true.</returns>
        public static bool ForEachUntilFalse<T>(this IEnumerable<T> items, Func<T, bool> action)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T item in items)
            {
                if (!action(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Execute an action for each item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action and its zero-based index.
        /// </param>
        /// <param name="action">
        /// The action to carry out.
        /// </param>
        /// <param name="cancellationToken">A cancellation token which can be used to abort the operation.</param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <returns>A Task which completes False if the enumeration returned early, otherwise true.</returns>
        public static async Task<bool> ForEachUntilFalseAsync<T>(this IEnumerable<T> items, Func<T, Task<bool>> action, CancellationToken cancellationToken = default)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T obj in items)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (!await action(obj).ConfigureAwait(false))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Execute an action for each item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action and its zero-based index.
        /// </param>
        /// <param name="action">
        /// The action to carry out.
        /// </param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <returns>True if the action terminated early, otherwise false.</returns>
        public static bool ForEachUntilTrue<T>(this IEnumerable<T> items, Func<T, bool> action)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T item in items)
            {
                if (action(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Execute an action for each item in the enumerable.
        /// </summary>
        /// <param name="items">
        /// The items over which to execute the action and its zero-based index.
        /// </param>
        /// <param name="action">
        /// The action to carry out.
        /// </param>
        /// <param name="cancellationToken">A cancellation token which can be used to abort the operation.</param>
        /// <typeparam name="T">
        /// The type of the items in the enumeration.
        /// </typeparam>
        /// <returns>A task which completes True if the action terminated early, otherwise false.</returns>
        public static async Task<bool> ForEachUntilTrueAsync<T>(this IEnumerable<T> items, Func<T, Task<bool>> action, CancellationToken cancellationToken = default)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T obj in items)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (await action(obj).ConfigureAwait(false))
                {
                    return true;
                }
            }

            return false;
        }
    }
}