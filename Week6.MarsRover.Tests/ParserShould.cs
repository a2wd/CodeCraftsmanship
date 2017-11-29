namespace Week6.MarsRover.Tests
{
    using System;
    using Exceptions;
    using NUnit.Framework;
    using Parser;
    using Movement;
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
        public void ThrowAnArgumentExceptionWhenPassedAnInvalidPlateauStringRepresentation(string invalidInput)
        {
            Assert.Throws<ArgumentException>(() => new Parser().Parse(invalidInput));
        }

        [TestCase("5 5\n1 2 N", new[] {1, 2}, Heading.North)]
        [TestCase("5 5\n1 2 E", new[] {1, 2}, Heading.East)]
        [TestCase("5 5\n1 2 S", new[] {1, 2}, Heading.South)]
        [TestCase("5 5\n1 2 W", new[] {1, 2}, Heading.West)]
        [TestCase("11 11\n10 10 N", new[] {10, 10}, Heading.North)]
        [TestCase("999 999\n321 123 N", new[] {321, 123}, Heading.North)]
        [TestCase("0 0\n999 999 N", new[] {999, 999}, Heading.North)]
        [TestCase("0 0\n999 999 n", new[] {999, 999}, Heading.North)]
        public void CorrectlyParseAVectorWithHeading(string input, int[] expectedPosition, Heading expectedHeading)
        {
            var expectedInitialPosition = new VectorWithHeading(expectedPosition[0], expectedPosition[1], expectedHeading);

            var result = new Parser().Parse(input); 

            Assert.That(result.GetInitialPosition(), Is.EqualTo(expectedInitialPosition));
        }

        [TestCase("1 1\nA 1 N")]
        [TestCase("1 1\n1 A N")]
        [TestCase("1 1\n1,1 N")]
        [TestCase("1 1\n1 1,N")]
        [TestCase("1 1\n1 1 N ")]
        public void ThrowAnArgumentExceptionWhenPassedAnInvalidStringRepresentationOfAVector(string input)
        {
            Assert.Throws<ArgumentException>(() => new Parser().Parse(input));
        }

        [TestCase("1 1\n1 1 F")]
        [TestCase("1 1\n1 1 North")]
        public void ThrowAnInvalidHeadingExceptionWhenPassedAnInvalidStringRepresentationOfAHeading(string input)
        {
            Assert.Throws<InvalidHeadingException>(() => new Parser().Parse(input));
        }
    }
}
