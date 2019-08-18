// <copyright file="StringExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace System
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;
    using Corvus.Extensions;

    /// <summary>
    /// Extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Adds a prefix to a string.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <param name="append">The target string.</param>
        /// <returns>The original string with the prefix pre-pended.</returns>
        public static string AddPrefix(this string text, string append)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.IsNullOrEmpty(append) ? string.Empty : append;
            }

            if (string.IsNullOrEmpty(append))
            {
                return text;
            }

            return append + text;
        }

        /// <summary>
        /// Convert the provided string to a base 64 representation of its byte representation in a particular encoding.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>The Base 64 encoded string.</returns>
        public static string AsBase64(this string value, Encoding encoding)
        {
            return Convert.ToBase64String(encoding.GetBytes(value));
        }

        /// <summary>
        /// Convert the provided string to a base 64 representation of its byte representation in the UTF8 encoding.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The Base 64 encoded string.</returns>
        public static string AsBase64(this string value)
        {
            return AsBase64(value, Encoding.UTF8);
        }

        /// <summary>
        /// Convert the provided string to a base 64 representation of its byte representation in the UTF8 encoding,
        /// with a URL-safe representation.
        /// </summary>
        /// <param name="input">The value to convert.</param>
        /// <returns>The Base 64 encoded string.</returns>
        public static string Base64UrlEncode(this string input)
        {
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
        public static string Base64UrlDecode(this string arg)
        {
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
            byte[] bytes = encoding.GetBytes(value);
            return new MemoryStream(bytes);
        }

        /// <summary>
        /// Converts the string into an enumeration value.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="isCaseSensitive">
        /// The is case sensitive.
        /// </param>
        /// <typeparam name="T">
        /// The enumeration type to convert to.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">The input string is null.</exception>
        /// <exception cref="ArgumentException">T is not an enumeration type, the input string is empty or contains only whitespace, or the input is not a named value in the enumeration.</exception>
        /// <returns>The matching enum value.</returns>
        public static T ConvertToEnum<T>(this string input, bool isCaseSensitive = true)
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException(ExceptionMessages.StringExtensions_SpecifiedTypeMustBeAnEnumeration);
            }

            return (T)Enum.Parse(typeof(T), input, !isCaseSensitive);
        }

        /// <summary>
        /// Escapes a content type string.
        /// </summary>
        /// <param name="contentType">The content type to escape.</param>
        /// <returns>An escaped version of the content type, suitable for use in a Uri.</returns>
        /// <remarks><seealso cref="UnescapeContentType(string)"/></remarks>
        public static string EscapeContentType(this string contentType)
        {
            return Uri.EscapeDataString(contentType.Replace('/', '`').Replace('.', '|'));
        }

        /// <summary>
        /// Gets the first n characters of a string, with various truncation options.
        /// </summary>
        /// <param name="theValue">The string to truncate.</param>
        /// <param name="characters">The number of characters to take.</param>
        /// <param name="options">Specify truncation options.</param>
        /// <returns>A string no longer than the specified number of characters.</returns>
        public static string FirstNCharacters(this string theValue, int characters, TruncationOptions options = TruncationOptions.None)
        {
            if (string.IsNullOrEmpty(theValue) || theValue.Length <= characters)
            {
                return theValue;
            }

            bool includeEllipsis = (options & TruncationOptions.AddEllipsis) != 0;
            int requiredLength = includeEllipsis ? characters - 3 : characters;

            if ((options & TruncationOptions.RemovePartialWords) != 0)
            {
                int lastSpace = theValue.LastIndexOf(' ', requiredLength);
                if (lastSpace != -1)
                {
                    requiredLength = lastSpace;
                }
            }

            string result = theValue.Substring(0, requiredLength);

            if (includeEllipsis)
            {
                result += "..";
            }

            return result;
        }

        /// <summary>
        /// Truncate a string to a maximum number of words.
        /// </summary>
        /// <param name="theValue">The string to truncate.</param>
        /// <param name="numberOfWords">The number of words to which to truncate the string.</param>
        /// <param name="options">Specify the truncation options.</param>
        /// <returns>A string containing the specified number of words.</returns>
        /// <remarks>Word delimiters are deemed to be whitespace characters as defined by the values for which <see cref="char.IsWhiteSpace(char)"/> returns <c>true</c>.</remarks>
        public static string FirstNWords(this string theValue, int numberOfWords, TruncationOptions options = TruncationOptions.None)
        {
            if (theValue != null && numberOfWords > 0)
            {
                var words = theValue.Split(null).ToList();
                string firstWords = string.Join(" ", words.Take(numberOfWords).ToArray());

                if ((options & TruncationOptions.AddEllipsis) != 0 && numberOfWords < words.Count)
                {
                    firstWords += "..";
                }

                return firstWords;
            }

            return string.Empty;
        }

        /// <summary>
        /// Formats a string with the specified args.
        /// </summary>
        /// <param name="theValue">
        /// The the string.
        /// </param>
        /// <param name="args">
        /// The format args.
        /// </param>
        /// <returns>
        /// The formatted string.
        /// </returns>
        public static string FormatWith(this string theValue, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, theValue, args);
        }

        /// <summary>
        /// Decode a string from a base64-encoded byte array with the specified text encoding.
        /// </summary>
        /// <param name="value">The base-64 encoded byte array.</param>
        /// <param name="encoding">The encoding of the byte array.</param>
        /// <returns>The original string represented by the base-64 encoded byte array.</returns>
        public static string FromBase64(this string value, Encoding encoding)
        {
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
            return FromBase64(value, Encoding.UTF8);
        }

        /// <summary>
        /// Enumerate the grapheme clusters in a string.
        /// </summary>
        /// <param name="s">The string for which to enumerate grapheme clusters.</param>
        /// <returns>An enumerable set of strings representing each grapheme cluster in the string.</returns>
        public static IEnumerable<string> GetGraphemeClusters(this string s)
        {
            TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(s);
            while (enumerator.MoveNext())
            {
                yield return (string)enumerator.Current;
            }
        }

        /// <summary>
        /// Switches the IsNullOrEmpty to a more readable format.
        /// </summary>
        /// <param name="theValue">
        /// The the string.
        /// </param>
        /// <returns>
        /// True if the string is null or empty.
        /// </returns>
        public static bool IsNullOrEmpty(this string theValue)
        {
            return string.IsNullOrEmpty(theValue);
        }

        /// <summary>
        /// Get the last n characters in the string.
        /// </summary>
        /// <param name="theValue">The string for which to get the last n characters.</param>
        /// <param name="numberOfCharacters">The number of characters to retrieve.</param>
        /// <returns>The last n characters of the string.</returns>
        public static string LastNCharacters(this string theValue, int numberOfCharacters)
        {
            if (string.IsNullOrEmpty(theValue))
            {
                return string.Empty;
            }

            int length = theValue.Length;

            if (numberOfCharacters > length)
            {
                return theValue;
            }

            return theValue.Substring(length - numberOfCharacters, numberOfCharacters);
        }

        /// <summary>
        /// Gets the last <paramref name="numberOfWords"/> in the string.
        /// </summary>
        /// <param name="theValue">The string.</param>
        /// <param name="numberOfWords">The number of words.</param>
        /// <returns>
        /// The last N words from a string, if shorter then the original string is returned.
        /// </returns>
        public static string LastNWords(this string theValue, int numberOfWords)
        {
            if (string.IsNullOrEmpty(theValue) || numberOfWords <= 0)
            {
                return string.Empty;
            }

            IEnumerable<string> words = theValue.Split(' ').ToList().AsEnumerable().Reverse();
            string[] selection = words.Take(numberOfWords).Reverse().ToArray();
            return string.Join(" ", selection);
        }

        /// <summary>
        /// Replaces the input string containing the XML tag <paramref name="tagName"/> with
        /// the given <paramref name="replacement"/> text.
        /// </summary>
        /// <param name="theValue">
        /// The string.
        /// </param>
        /// <param name="tagName">
        /// The name of the tag to replace, or <see cref="string.Empty"/> for all HTML tags.
        /// </param>
        /// <param name="replacement">
        /// The value to replace the matching tags with, or <see cref="string.Empty"/> for a blank replacement.
        /// </param>
        /// <returns>
        /// The original string with the matching XML tags replaced.
        /// </returns>
        public static string ReplaceXmlTags(this string theValue, string tagName, string replacement)
        {
            if (string.IsNullOrEmpty(theValue))
            {
                return string.Empty;
            }

            var element = XElement.Parse(theValue);

            ReplaceXmlTags(element, tagName, replacement);

            return element.ToString(SaveOptions.DisableFormatting);
        }

        /// <summary>
        /// Reverse the string.
        /// </summary>
        /// <param name="s">The string to reverse.</param>
        /// <returns>The reversed string, respecting grapheme clusters.</returns>
        public static string Reverse(this string s)
        {
            return string.Concat(s.GetGraphemeClusters().Reverse().ToArray());
        }

        /// <summary>
        /// Removes a prefix from a string.
        /// </summary>
        /// <param name="text">The string from which to remove the prefix.</param>
        /// <param name="prefix">The prefix to remove.</param>
        /// <returns>The string without the prefix, if it was present.</returns>
        public static string StripPrefix(this string text, string prefix)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            if (string.IsNullOrEmpty(prefix))
            {
                return text;
            }

            if (text.StartsWith(prefix, StringComparison.CurrentCulture))
            {
                return text.Substring(prefix.Length);
            }

            return text;
        }

        /// <summary>
        /// Unescapes a content type string.
        /// </summary>
        /// <param name="contentType">The content type to escape.</param>
        /// <returns>The unescaped content type.</returns>
        /// <remarks><seealso cref="EscapeContentType(string)"/></remarks>
        public static string UnescapeContentType(this string contentType)
        {
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

            string camelCase = char.ToLowerInvariant(s[0]).ToString();

            if (s.Length > 1)
            {
                camelCase += s.Substring(1);
            }

            return camelCase;
        }

        private static void ReplaceXmlTags(XElement element, string tagName, string replacement)
        {
            if (element.Name == tagName)
            {
                element.Name = replacement;
            }

            element.Elements().ForEach(e => ReplaceXmlTags(e, tagName, replacement));
        }
    }
}