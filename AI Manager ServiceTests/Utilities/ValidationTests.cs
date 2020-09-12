using Xunit;
using AI_Manager_Service.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using AI_Manager_ServiceTests.TestUtils;
using System.Diagnostics;
using Ms = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AI_Manager_Service.Utilities.Tests
{
    public class ValidationTests
    {
        [Fact()]
        public void FileSizeTest()
        {
            Assert.Throws<Ms.AssertFailedException>(() => Validation.FileSize(null, 1, 1));
            Assert.Throws<Ms.AssertFailedException>(() => Validation.FileSize(Generator.CreateFormFile(1), 0, 3));
            Assert.Throws<Ms.AssertFailedException>(() => Validation.FileSize(Generator.CreateFormFile(1), 3, 2));

            Assert.True(Validation.FileSize(Generator.CreateFormFile(1), 1, 1));
            Assert.True(Validation.FileSize(Generator.CreateFormFile(2), 1, 3));
            Assert.True(Validation.FileSize(Generator.CreateFormFile(3), 1, 3));

            Assert.False(Validation.FileSize(Generator.CreateFormFile(1), 2, 3));
            Assert.False(Validation.FileSize(Generator.CreateFormFile(4), 2, 3));
        }

        [Fact()]
        public void NotNullTest()
        {
            Assert.True(Validation.NotNull(""));

            Assert.False(Validation.NotNull(null));
        }
    }
}