using Xunit;
using AI_Manager_Service.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Manager_Service.Utilities.Tests
{
    public class ConversionTests
    {
        [Fact()]
        public void MegabytesToBytesTest()
        {
            Assert.True(Conversion.MegabytesToBytes(5) == 5242880);
            Assert.True(Conversion.MegabytesToBytes(1) == 1048576);
            Assert.True(Conversion.MegabytesToBytes(0) == 0);
        }
    }
}