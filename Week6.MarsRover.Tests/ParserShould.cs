namespace Week6.MarsRover.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using Parser;
    using Terrain;

    [TestFixture]
    public class ParserShould
    {
        [TestCase("5 5\n1 1 N", new[] {5, 5}, TestName = "Parse a plateau size of 5, 5")]
        [TestCase("1 2\n1 1 N", new[] {1, 2}, TestName = "Parse a plateau size of 1, 2")]
        [TestCase("99 2333\n1 1 N", new[] { 99, 2333 }, TestName = "Parse a plateau size of 99, 2333")]
        public void ParseAPlateauSizeIntoAPlateauObject(string input, int[] expectedOutput)
        {
            var expectedPlateau = new Plateau(expectedOutput[0], expectedOutput[1]);

            var result = new Parser().Parse(input);

            Assert.That(result.GetPlateau(), Is.EqualTo(expectedPlateau));
        }

        [TestCase("AAA\n1 1 N")]
        [TestCase("AA AA\n1 1 N")]
        [TestCase("123 AA\n1 1 N")]
        [TestCase("AA 123\n1 1 N")]
        [TestCase("123,123\n1 1 N")]
        [TestCase("123 123 \n1 1 N")]
        public void ThrowArgumentExceptionOnInvalidInput(string invalidInput)
        {
            Assert.Throws<ArgumentException>(() => new Parser().Parse(invalidInput));
        }

        [Test]
        public void CorrectlyParseAVectorWithHeading()
        {
            var expectedInitialPosition = new VectorWithHeading(1, 2, Heading.North);

            var result = new Parser().Parse("5 5\n1 2 N"); 

            Assert.That(result.GetInitialPosition(), Is.EqualTo(expectedInitialPosition));
        }
    }
}
