using Xunit;
using Ms = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputationManager.Utilities.Tests
{
    public class ConversionTests
    {
        [Fact()]
        public void MegabytesToBytesTest()
        {
            Assert.True(Conversion.MegabytesToBytes(5) == 5242880);
            Assert.True(Conversion.MegabytesToBytes(1) == 1048576);
            Assert.True(Conversion.MegabytesToBytes(0) == 0);
            Assert.Throws<Ms.AssertFailedException>(() => Conversion.MegabytesToBytes(-1));
        }
    }
}