using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;

namespace AI_Manager_ServiceTests.TestUtils
{
    static class Generator
    {
        enum Alphabet
        {
            Hex,
            Norwegian,
            Random
        }

        public static IFormFile CreateFormFile(long size, string fileName="Test file")
        {
            byte[] buffer = GenerateBytes(size);

            IFormFile file = new FormFile(new MemoryStream(buffer), 0, size, "Data", fileName);

            Debug.WriteLine($"File: {file}");

            return file;
        }

        public static byte[] GenerateBytes(long length)
        {
            byte[] buffer = new byte[length];
            Random rnd = new Random();
            rnd.NextBytes(buffer);

            return buffer;
        }
    }
}
