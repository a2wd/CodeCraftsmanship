namespace Week4.InstrumentProcessor.Tests.Stubs
{
    using Interfaces;
    public class TaskDispatcherStub : ITaskDispatcher
    {
        public string GetTask()
        {
            return "stub test";
        }

        public void FinishedTask(string task)
        {
            throw new System.NotImplementedException();
        }
    }
}
