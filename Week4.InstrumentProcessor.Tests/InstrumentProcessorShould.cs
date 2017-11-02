namespace Week4.InstrumentProcessor.Tests
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using Interfaces;
    using Moq;
    using NUnit.Framework;
    using Stubs;

    [TestFixture]
    public class InstrumentProcessorShould
    {

        [Test]
        public void RequesTheNextTaskWhenProcessIsCalled()
        {
            Mock<ITaskDispatcher> taskDispatcherMock = new Mock<ITaskDispatcher>();
            Mock<IInstrument> instrumentMock = new Mock<IInstrument>();
            var instrumentProcessor = new InstrumentProcessor(taskDispatcherMock.Object, instrumentMock.Object);
            instrumentProcessor.Process();

            taskDispatcherMock.Verify(x => x.GetTask(), Times.Once());
        }

        [Test]
        public void CallExecuteOnAnInstrumentToProcessATaskWhenProcessMethodIsCalled()
        {
            Mock<ITaskDispatcher> taskDispatcherMock = new Mock<ITaskDispatcher>();
            Mock<IInstrument> instrumentMock = new Mock<IInstrument>();

            taskDispatcherMock.Setup(x => x.GetTask()).Returns("");
            
            var instrumentProcessor = new InstrumentProcessor(taskDispatcherMock.Object, instrumentMock.Object);
            instrumentProcessor.Process();

            instrumentMock.Verify(x => x.Execute(string.Empty), Times.Once());
        }

        [Test]
        public void ThrowAnExceptionOnExecuteMethodToProcessCall()
        {
            Mock<ITaskDispatcher> taskDispatcherMock = new Mock<ITaskDispatcher>();
            Mock<IInstrument> instrumentMock = new Mock<IInstrument>();

            taskDispatcherMock.Setup(x => x.GetTask()).Throws<Exception>();

            var instrumentProcessor = new InstrumentProcessor(taskDispatcherMock.Object, instrumentMock.Object);

            Assert.Throws<Exception>(() => instrumentProcessor.Process());
        }

        [Test]
        public void CallTheInstrumentWithTheCorrectTask()
        {
            var taskDispatcher = new TaskDispatcherStub();

            var instrumentMock = new Mock<IInstrument>();

            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrumentMock.Object);
            instrumentProcessor.Process();

            instrumentMock.Verify(x => x.Execute("stub test"));
        }

        [Test]
        public void CallTheTaskDispatcherFinishedTaskWithTheCorrectTask()
        {
            var testTask = "stub test";
            var taskDispatcherMock = new Mock<ITaskDispatcher>();
            taskDispatcherMock.Setup(x => x.GetTask()).Returns(testTask);

            var instrumentStub = new InstrumentStub();

            var instrumentProcessor = new InstrumentProcessor(taskDispatcherMock.Object, instrumentStub);
            instrumentProcessor.Process();

            taskDispatcherMock.Verify(x => x.FinishedTask(testTask));
        }
    }
}
