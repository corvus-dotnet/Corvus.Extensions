// <copyright file="StringExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Convert the provided string to a base 64 representation of its byte representation in a particular encoding.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>The Base 64 encoded string.</returns>
        public static string AsBase64(this string value, Encoding encoding)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            return Convert.ToBase64String(encoding.GetBytes(value));
        }

        /// <summary>
        /// Convert the provided string to a base 64 representation of its byte representation in the UTF8 encoding.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The Base 64 encoded string.</returns>
        public static string AsBase64(this string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return AsBase64(value, Encoding.UTF8);
        }

        /// <summary>
        /// Convert the provided string to a base 64 representation of its byte representation in the UTF8 encoding,
        /// with a URL-safe representation.
        /// </summary>
        /// <param name="input">The value to convert.</param>
        /// <returns>The Base 64 encoded string.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1055:Uri return values should not be strings", Justification = "FxCop's heuristics have misfired - this does not return a URI")]
        public static string Base64UrlEncode(this string input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            byte[] arg = Encoding.UTF8.GetBytes(input);
            string s = Convert.ToBase64String(arg); // Regular base64 encoder
            s = s.Split('=')[0]; // Remove any trailing '='s
            s = s.Replace('+', '-'); // 62nd char of encoding
            return s.Replace('/', '_'); // 63rd char of encoding
        }

        /// <summary>
        /// Convert the provided string from a base 64 representation of its byte representation in the UTF8 encoding
        /// with a URL-safe representation.
        /// </summary>
        /// <param name="arg">The value to convert.</param>
        /// <returns>The original string.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1055:Uri return values should not be strings", Justification = "FxCop's heuristics have misfired - this does not return a URI")]
        public static string Base64UrlDecode(this string arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            string s = arg;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding

            // Pad with trailing '='s
            switch (s.Length % 4)
            {
                case 0: break; // No pad chars in this case
                case 2: s += "=="; break; // Two pad chars
                case 3: s += "="; break; // One pad char
                default:
                    throw new InvalidOperationException($"Illegal base64url string '{arg}'");
            }

            byte[] string64 = Convert.FromBase64String(s); // Standard base64 decoder
            return Encoding.UTF8.GetString(string64);
        }

        /// <summary>
        /// Provide a stream over the string in the UTF8 encoding.
        /// </summary>
        /// <param name="value">The string.</param>
        /// <returns>A stream over the UTF8-encoded representation of the string.</returns>
        public static Stream AsStream(this string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return AsStream(value, Encoding.UTF8);
        }

        /// <summary>
        /// Provide a stream over the string in the specified encoding.
        /// </summary>
        /// <param name="value">The string.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>A stream over the encoded representation of the string.</returns>
        public static Stream AsStream(this string value, Encoding encoding)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            byte[] bytes = encoding.GetBytes(value);
            return new MemoryStream(bytes);
        }

        /// <summary>
        /// Escapes a content type string.
        /// </summary>
        /// <param name="contentType">The content type to escape.</param>
        /// <returns>An escaped version of the content type, suitable for use in a Uri.</returns>
        /// <remarks><seealso cref="UnescapeContentType(string)"/></remarks>
        public static string EscapeContentType(this string contentType)
        {
            if (contentType is null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            return Uri.EscapeDataString(contentType.Replace('/', '`').Replace('.', '|'));
        }

        /// <summary>
        /// Decode a string from a base64-encoded byte array with the specified text encoding.
        /// </summary>
        /// <param name="value">The base-64 encoded byte array.</param>
        /// <param name="encoding">The encoding of the byte array.</param>
        /// <returns>The original string represented by the base-64 encoded byte array.</returns>
        public static string FromBase64(this string value, Encoding encoding)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            byte[] bytes = Convert.FromBase64String(value);

            return encoding.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Decode a string from a base64-encoded JTF8 byte array.
        /// </summary>
        /// <param name="value">The base-64 encoded byte array.</param>
        /// <returns>The original string represented by the base-64 encoded byte array.</returns>
        public static string FromBase64(this string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return FromBase64(value, Encoding.UTF8);
        }

        /// <summary>
        /// Enumerate the grapheme clusters in a string.
        /// </summary>
        /// <param name="s">The string for which to enumerate grapheme clusters.</param>
        /// <returns>An enumerable set of strings representing each grapheme cluster in the string.</returns>
        public static IEnumerable<string> GetGraphemeClusters(this string s)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return Enumerate();

            IEnumerable<string> Enumerate()
            {
                TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(s);
                while (enumerator.MoveNext())
                {
                    yield return (string)enumerator.Current;
                }
            }
        }

        /// <summary>
        /// Reverse the string.
        /// </summary>
        /// <param name="s">The string to reverse.</param>
        /// <returns>The reversed string, respecting grapheme clusters.</returns>
        public static string Reverse(this string s)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return string.Concat(s.GetGraphemeClusters().Reverse().ToArray());
        }

        /// <summary>
        /// Unescapes a content type string.
        /// </summary>
        /// <param name="contentType">The content type to escape.</param>
        /// <returns>The unescaped content type.</returns>
        /// <remarks><seealso cref="EscapeContentType(string)"/></remarks>
        public static string UnescapeContentType(this string contentType)
        {
            if (contentType is null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            return Uri.UnescapeDataString(contentType).Replace('`', '/').Replace('|', '.');
        }

        /// <summary>
        /// Converts a string to camel case from pascal case.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The string with the initial character lowercased.</returns>
        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            if (!char.IsUpper(s[0]))
            {
                return s;
            }

            string camelCase = char.ToLowerInvariant(s[0]).ToString(CultureInfo.InvariantCulture);

            if (s.Length > 1)
            {
                camelCase += s.Substring(1);
            }

            return camelCase;
        }
    }
}