namespace Week4.InstrumentProcessor
{
    using Interfaces;
    public class InstrumentProcessor : IInstrumentProcessor
    {
        private ITaskDispatcher _taskDispatcher;
        private IInstrument _instrument;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            _taskDispatcher = taskDispatcher;
            _instrument = instrument;
        }

        public void Process()
        {
            var task = _taskDispatcher.GetTask();
            _instrument.Execute(task);
        }
    }
}
