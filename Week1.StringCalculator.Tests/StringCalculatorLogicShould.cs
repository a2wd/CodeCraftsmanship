namespace Week1.StringCalculator.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class StringCalculatorLogicShould
    {
        private StringCalculatorLogic _stringCalculatorLogic;

        [SetUp]
        public void SetUp()
        {
            _stringCalculatorLogic = new StringCalculatorLogic();
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Return0WhenPassed0Numbers(string input)
        {
            int result = _stringCalculatorLogic.Add(input);

            Assert.That(result, Is.Zero);
        }

        [TestCase("test")]
        [TestCase("1,bob")]
        [TestCase("bob,2")]
        public void ThrowAnInvalidInputExceptionWhenNotPassedIntegers(string input)
        {
            Assert.Throws(typeof(InvalidInputException), () => _stringCalculatorLogic.Add(input));
        }

        [TestCase("1", 1)]
        [TestCase("0", 0)]
        [TestCase("10", 10)]
        [TestCase("99", 99)]
        public void ReturnANumberWhenPassedAnIntegerAsAString(string input, int expectedOutput)
        {
            int result = _stringCalculatorLogic.Add(input);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [TestCase("1,2")]
        [TestCase("15,24")]
        public void NotThrowAnExceptionOnPassingTwoIntegers(string input)
        {
            Assert.DoesNotThrow(() => _stringCalculatorLogic.Add(input));
        }

        [TestCase("1,2", 3)]
        [TestCase("9,5", 14)]
        [TestCase("11,29", 40)]
        [TestCase("230,431", 661)]
        public void CorrectlySumTwoIntegers(string input, int expectedOutput)
        {
            int result = _stringCalculatorLogic.Add(input);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [TestCase("6\n0,32", 92)]
        [TestCase("12,4\n8", 60)]
        [TestCase("3\n12,8\n8\n3", 1195)]
        public void AllowNewLinesWithinInputNumbers(string input, int expectedOutput)
        {
            int result = _stringCalculatorLogic.Add(input);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}
