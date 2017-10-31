namespace Week4.InstrumentProcessor.Interfaces
{
    public interface ITaskDispatcher
    {
        string GetTask();

        void FinishedTask(string task);
    }
}