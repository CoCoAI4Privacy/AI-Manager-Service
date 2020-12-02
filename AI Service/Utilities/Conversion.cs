using FluentAssertions;

namespace AI_Manager_Service.Utilities
{
    public static class Conversion
    {
        public static long MegabytesToBytes(long megabytes)
        {
            megabytes.Should().BeGreaterOrEqualTo(0);

            return megabytes * 1024 * 1024;
        }
    }
}
