namespace Week4.InstrumentProcessor.Tests.Stubs
{
    using System;
    using Interfaces;

    public class InstrumentStub : IInstrument
    {
        public void Execute(string task)
        {
            var eventArgs = new InstrumentEventArgs {Task = task};

            Finished.Invoke(this, eventArgs);
        }

        public event EventHandler Finished;
        public event EventHandler Error;
    }
}
