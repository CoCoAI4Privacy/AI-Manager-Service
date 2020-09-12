using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AI_Manager_Service.Utilities
{
    public static class Conversion
    {
        public static long MegabytesToBytes(long megabytes)
        {
            return megabytes * 1024 * 1024;
        }
    }
}
