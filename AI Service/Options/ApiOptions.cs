using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AI_Manager_Service.Options
{
    public class ApiOptions
    {
        public const string Api = "Api";

        public long MinFileSize { get; set; }
        public long MaxFileSize { get; set; }
    }
}
