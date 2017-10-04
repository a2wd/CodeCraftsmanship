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
        public void ShouldNotThrowAnExceptionOnPassingTwoIntegers(string input)
        {
            Assert.DoesNotThrow(() => _stringCalculatorLogic.Add(input));
        }
    }
}
