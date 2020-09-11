using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace AI_Manager_Service.Utilities
{
    public static class Validation
    {
        public static bool NotNull(Object value)
        {
            return value != null;
        }

        /// <summary>
        /// Checks if the size of the provided file is at least minSize megabytes and at most maxSize megabytes.
        /// </summary>
        /// <param name="file">File to be validated</param>
        /// <param name="minSize">Smallest allowed size in megabytes</param>
        /// <param name="maxSize">Largest allowed size in megabytes</param>
        /// <returns>True if the condition holds, false otherwise</returns>
        public static bool FileSize(IFormFile file, long minSize, long maxSize)
        {
            Contract.Requires(file != null);
            Contract.Requires(minSize <= maxSize);
            Contract.Requires(minSize >= 0);

            long minBytes = minSize * 1024 * 1024;
            long maxBytes = maxSize * 1024 * 1024;

            return file.Length >= minBytes && file.Length <= maxBytes;
        }
    }
}
