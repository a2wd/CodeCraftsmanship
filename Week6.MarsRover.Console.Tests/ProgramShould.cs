namespace Week6.MarsRover.Console.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class ProgramShould
    {
        [TestCase("5 5\n1 2 N\nLMLMLMLMM", "1 3 N")]
        [TestCase("5 5\n1 2 N\n", "1 2 N")]
        [TestCase("5 5\n1 1 N\nMMRMM", "3 3 E")]
        public void ReturnTheExpectedOutputForTheExampleInput(string exampleInput, string expectedOutput)
        {
            Console.SetIn(new StringReader(exampleInput));

            var programOutput = new StringBuilder();
            Console.SetOut(new StringWriter(programOutput));

            Program.Main(new string[] {});

            Assert.That(programOutput.ToString(), Is.EqualTo(expectedOutput));
        }

        [TestCase("")]
        [TestCase("5 5\n\nLMLMLMM")]
        [TestCase("A 5\n1 2 N\nLMLMLMM")]
        [TestCase("5 A\n1 2 N\nLMLMLMM")]
        [TestCase("5 5\nA 2 N\nLMLMLMM")]
        [TestCase("5 5\n2 A N\nLMLMLMM")]
        [TestCase("5 5 \n2 A N\nLMLMLMM")]
        [TestCase("5 5 \n2 A N \nLMLMLMM")]
        [TestCase("5,5 \n2 A N\nLMLMLMM")]
        public void ThrowAnExceptionWhenPassedInvalidInput(string input)
        {
            Console.SetIn(new StringReader(input));

            Assert.That(() => Program.Main(new string[] {}), Throws.ArgumentException);
        }
    }
}
