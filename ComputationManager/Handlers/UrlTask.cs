using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputationManager.Handlers
{
    class UrlTask : ITask
    {
        public TaskType Type { get; }
        public Uri Url { get; }

        public UrlTask(Uri url)
        {
            Type = TaskType.URL;
            Url = url;
        }
    }
}
