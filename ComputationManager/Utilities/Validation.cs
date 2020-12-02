using Microsoft.AspNetCore.Http;
using System;
using FluentAssertions;
using System.Diagnostics;

namespace AI_Manager_Service.Utilities
{
    public static class Validation
    {
        public static bool IsNull(Object value)
        {
            return value == null;
        }

        /// <summary>
        /// Checks if the size of the provided file is at least minSize bytes and at most maxSize bytes.
        /// </summary>
        /// <param name="file">File to be validated</param>
        /// <param name="minSize">Smallest allowed size in bytes</param>
        /// <param name="maxSize">Largest allowed size in bytes</param>
        /// <returns>True if the condition holds, false otherwise</returns>
        public static bool FileSizeExceedsBounds(IFormFile file, long minSize, long maxSize)
        {
            file.Should().NotBeNull();
            minSize.Should().BeInRange(1, maxSize);

            Debug.WriteLineIf(file.Length < minSize, $"minSize: {minSize}\nFile length: {file.Length}");
            Debug.WriteLineIf(file.Length > maxSize, $"maxSize: {maxSize}\nFile length: {file.Length}");

            return file.Length < minSize || file.Length > maxSize;
        }
    }
}
