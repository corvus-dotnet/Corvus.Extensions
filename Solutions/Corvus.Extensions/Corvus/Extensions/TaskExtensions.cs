// <copyright file="TaskExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace System.Threading.Tasks
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Extension methods for <see cref="Task"/>s.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Checks to see if a Task actually has a result and converts to a task of the relevant type.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="task">The task to await.</param>
        /// <returns>A <see cref="Task{TResult}"/> for the relevant type.</returns>
        /// <exception cref="InvalidCastException">Thrown if you cannot cast between the result type of the task, and the desired type.</exception>
        /// <remarks>
        /// Note that this async method will wait for the task to complete before returning a
        /// task of the relevant type.
        /// </remarks>
        public static async Task<T> CastWithConversion<T>(this Task task)
        {
            await task.ConfigureAwait(false);

            PropertyInfo resultPropertyInfo = task.GetType().GetProperty("Result");

            if (resultPropertyInfo == null)
            {
                throw new InvalidCastException();
            }

            return CastTo<T>.From(resultPropertyInfo.GetValue(task));
        }

        /// <summary>
        /// Casts from a <see cref="Task"/> to a <see cref="Task{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="task">The task two await.</param>
        /// <returns>A <see cref="Task{T}"/> for the relevant type.</returns>
        /// <exception cref="InvalidCastException">The task was not a task of the given type.</exception>
        public static Task<T> Cast<T>(this Task task)
        {
            if (task is Task<T> result)
            {
                return result;
            }

            throw new InvalidCastException();
        }
    }
}
