// <copyright file="FileStreamExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace System.IO
{
    using System.Threading.Tasks;

    /// <summary>
    /// Extensions to the <see cref="FileStream"/>.
    /// </summary>
    public static class FileStreamExtensions
    {
        /// <summary>
        /// Reads a file into a byte array in memory.
        /// </summary>
        /// <param name="fs">The file stream to read.</param>
        /// <returns>A task which completes once the by array is read.</returns>
        /// <remarks>This will read files up to 2GB in size.</remarks>
        public static async Task<byte[]> ReadAllBytesAsync(this FileStream fs)
        {
            long fileLength = fs.Length;

            if (fileLength > int.MaxValue)
            {
                throw new IOException("The file is too long (>2GB).");
            }

            byte[] bytes = new byte[fileLength];

            await fs.ReadAsync(bytes, 0, (int)fileLength).ConfigureAwait(false);

            return bytes;
        }
    }
}
