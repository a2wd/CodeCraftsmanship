namespace Week4.InstrumentProcessor
{
    using System;
    using Interfaces;
    using Tests;

    public class InstrumentProcessor : IInstrumentProcessor
    {
        private ITaskDispatcher _taskDispatcher;
        private IInstrument _instrument;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            _taskDispatcher = taskDispatcher;
            _instrument = instrument;

            _instrument.Finished += (sender, eventArgs) => _taskDispatcher.FinishedTask(((InstrumentEventArgs) eventArgs).Task);
        }

        public void Process()
        {
            var task = _taskDispatcher.GetTask();
            _instrument.Execute(task);
        }
    }
}
