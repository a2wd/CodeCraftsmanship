namespace Week1.FizzBuzz.Tests
{
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class FizzBuzzLogicShould
    {
        private FizzBuzzLogic _fizzBuzzLogic;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzzLogic = new FizzBuzzLogic();
        }

        [Test]
        public void Return100Items()
        {
           string[] results;

           results = _fizzBuzzLogic.GetFizzBuzz();

           Assert.That(results.Length == 100);
        }

        [Test]
        public void Return100StringItems()
        {
            string[] results;

            results = _fizzBuzzLogic.GetFizzBuzz();

            Assert.That(results.All(result => result.GetType() == typeof(string)), Is.True);
        }

        [Test]
        public void Returns100NonEmptyItems()
        {
            string[] results;

            results = _fizzBuzzLogic.GetFizzBuzz();

            Assert.That(results.All(string.IsNullOrWhiteSpace), Is.False);
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(9, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(11, "11")]
        [TestCase(12, "Fizz")]
        [TestCase(13, "13")]
        [TestCase(14, "14")]
        [TestCase(15, "FizzBuzz")]
        public void ReturnTheCorrectValueAtCorrespondingIndices(int indice, string value)
        {
            string[] results;
            int arrayIndex = indice - 1;

            results = _fizzBuzzLogic.GetFizzBuzz();

            Assert.That(results[arrayIndex], Is.EqualTo(value));
        }
    }
}
