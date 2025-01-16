// <copyright file="DictionaryExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions for <see cref="IDictionary{TKey, TValue}"/>.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds an item if there is no item with that key in the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to which to add the item.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>True if the item as added.</returns>
        public static bool AddIfNotExists<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            ArgumentNullException.ThrowIfNull(dictionary);

            if (dictionary.ContainsKey(key))
            {
                return false;
            }

            dictionary.Add(key, value);
            return true;
        }

        /// <summary>
        /// Merges two dictionaries.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="that">The source dictionary, into which the other is merged.</param>
        /// <param name="dictionary">The dictionary from which values are to be merged.</param>
        /// <returns>The original dictionary, with the merged items added.</returns>
        /// <remarks>If a key is already present in the dictionary, then the original value is preserved.</remarks>
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> that, IDictionary<TKey, TValue> dictionary)
        {
            ArgumentNullException.ThrowIfNull(that);
            ArgumentNullException.ThrowIfNull(dictionary);

            dictionary.Keys.ForEach(key => that.AddIfNotExists(key, dictionary[key]));

            return that;
        }

        /// <summary>
        /// Replaces an item if there is an item with that key in the dictionary, otherwise adds it.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to which to add the item.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>True if the item was replaced, false if it was added.</returns>
        public static bool ReplaceIfExists<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            ArgumentNullException.ThrowIfNull(dictionary);

            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
                return true;
            }
            else
            {
                dictionary.Add(key, value);
                return false;
            }
        }
    }
}