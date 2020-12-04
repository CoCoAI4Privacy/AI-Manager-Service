namespace ComputationManager.Handlers
{
    enum TaskType
    {
        URL, File, Training
    }

    interface ITask
    {
        TaskType Type { get; }
    }
}
