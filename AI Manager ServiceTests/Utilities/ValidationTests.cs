using Xunit;
using AI_Manager_ServiceTests.TestUtils;
using Ms = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AI_Manager_Service.Utilities.Tests
{
    public class ValidationTests
    {
        [Fact()]
        public void FileSizeTest()
        {
            Assert.Throws<Ms.AssertFailedException>(() => Validation.FileSizeExceedsBounds(null, 1, 1));
            Assert.Throws<Ms.AssertFailedException>(() => Validation.FileSizeExceedsBounds(Generator.CreateFormFile(1), 0, 3));
            Assert.Throws<Ms.AssertFailedException>(() => Validation.FileSizeExceedsBounds(Generator.CreateFormFile(1), 3, 2));

            Assert.False(Validation.FileSizeExceedsBounds(Generator.CreateFormFile(1), 1, 1));
            Assert.False(Validation.FileSizeExceedsBounds(Generator.CreateFormFile(2), 1, 3));
            Assert.False(Validation.FileSizeExceedsBounds(Generator.CreateFormFile(3), 1, 3));

            Assert.True(Validation.FileSizeExceedsBounds(Generator.CreateFormFile(1), 2, 3));
            Assert.True(Validation.FileSizeExceedsBounds(Generator.CreateFormFile(4), 2, 3));
        }

        [Fact()]
        public void NotNullTest()
        {
            Assert.False(Validation.IsNull(""));

            Assert.True(Validation.IsNull(null));
        }
    }
}