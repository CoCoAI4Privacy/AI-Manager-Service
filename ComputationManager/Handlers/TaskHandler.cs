using System.Collections.Generic;

namespace ComputationManager.Handlers
{
    class TaskHandler
    {
        private readonly object _lock;
        private readonly Queue<ITask> taskQueue;
        private bool IsOpen { get; set; }

        public TaskHandler()
        {
            _lock = new object();
            taskQueue = new Queue<ITask>();
        }

        public bool TryAddTask(ITask task)
        {
            lock (_lock)
            {
                if (IsOpen)
                {
                    taskQueue.Enqueue(task);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TryGetTask(out ITask result)
        {
            lock (_lock)
            {
                if (IsOpen)
                {
                    bool boolResult = taskQueue.TryDequeue(out ITask taskResult);
                    result = taskResult;
                    return boolResult;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
        }

        public void CloseQueue()
        {
            lock (_lock)
            {
                IsOpen = false;
            }
        }
    }
}
