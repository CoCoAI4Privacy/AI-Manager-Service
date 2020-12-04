using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputationManager.Handlers
{
    class FileTask : ITask
    {
        public TaskType Type { get; }
        public string Path { get; }


        public FileTask(string path)
        {
            Type = TaskType.File;
            Path = path;
        }

    }
}
