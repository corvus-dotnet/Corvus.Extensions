// <copyright file="StreamExtension.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace System.IO
{
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Extensions to <see cref="Stream"/>.
    /// </summary>
    public static class StreamExtension
    {
        /// <summary>
        /// Read the stream as a byte array.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The byte array read from the stream.</returns>
        /// <remarks>This rewinds the stream before copying.</remarks>
        public static byte[] AsBytes(this Stream stream)
        {
            byte[] bytes = default;

            using (var memstream = new MemoryStream())
            {
                stream.Rewind();
                stream.CopyTo(memstream);
                bytes = memstream.ToArray();
            }

            return bytes;
        }

        /// <summary>
        /// Read the stream as a string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The string read from the stream.</returns>
        /// <remarks>This assumes that the stream contains UTF8 encoded text.</remarks>
        public static string AsString(this Stream stream)
        {
            return AsString(stream, Encoding.UTF8);
        }

        /// <summary>
        /// Read the stream as a string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding of the text in the stream.</param>
        /// <returns>The string read from the stream.</returns>
        public static string AsString(this Stream stream, Encoding encoding)
        {
            stream.Rewind();

            var streamReader = new StreamReader(stream, encoding);
            return streamReader.ReadToEnd();
        }

        /// <summary>
        /// Read the stream as a string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The string read from the stream.</returns>
        /// <remarks>This assumes that the stream contains UTF8 encoded text, and
        /// that it is already at the correct point to start reading from.
        /// </remarks>
        public static Task<string> AsStringAsync(this Stream stream)
        {
            return AsStringAsync(stream, Encoding.UTF8);
        }

        /// <summary>
        /// Read the stream as a string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding of the text in the stream.</param>
        /// <returns>The string read from the stream.</returns>
        /// <remarks>
        /// This method assumes that the <see cref="Stream"/> being read is already
        /// at the correct point to start reading from.
        /// </remarks>
        public static async Task<string> AsStringAsync(this Stream stream, Encoding encoding)
        {
            var streamReader = new StreamReader(stream, encoding);
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Flushes the stream and seeks to the beginning.
        /// </summary>
        /// <param name="stream">The stream to rewind.</param>
        /// <returns>A Task which completes once the rewind operation is complete.</returns>
        public static async Task RewindAsync(this Stream stream)
        {
            if (stream.CanWrite)
            {
                await stream.FlushAsync().ConfigureAwait(false);
            }

            stream.Seek(0L, SeekOrigin.Begin);
        }

        /// <summary>
        /// Flushes the stream and seeks to the beginning.
        /// </summary>
        /// <param name="stream">The stream to rewind.</param>
        public static void Rewind(this Stream stream)
        {
            if (stream.CanWrite)
            {
                stream.Flush();
            }

            stream.Seek(0L, SeekOrigin.Begin);
        }
    }
}