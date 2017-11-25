namespace Week6.MarsRover.Tests
{
    using System;
    using Exceptions;
    using Movement;
    using NUnit.Framework;
    using Parser;
    using Terrain;

    [TestFixture]
    public class ParserShould
    {
        [TestCase("5 5\n1 1 N\n", new[] {5, 5})]
        [TestCase("1 2\n1 1 N\n", new[] {1, 2})]
        [TestCase("99 2333\n1 1 N\n", new[] {99, 2333})]
        public void ParseAPlateauSizeIntoAPlateauObject(string input, int[] expectedOutput)
        {
            var expectedPlateau = new Plateau(expectedOutput[0], expectedOutput[1]);

            var result = new Parser().Parse(input);

            Assert.That(result.GetPlateau(), Is.EqualTo(expectedPlateau));
        }

        [TestCase("AAA\n1 1 N\n")]
        [TestCase("AA AA\n1 1 N\n")]
        [TestCase("123 AA\n1 1 N\n")]
        [TestCase("AA 123\n1 1 N\n")]
        [TestCase("123,123\n1 1 N\n")]
        [TestCase("123 123 \n1 1 N\n")]
        public void ThrowAnArgumentExceptionWhenPassedAnInvalidPlateauStringRepresentation(string invalidInput)
        {
            Assert.Throws<ArgumentException>(() => new Parser().Parse(invalidInput));
        }

        [TestCase("5 5\n1 2 N\n", new[] {1, 2}, Heading.North)]
        [TestCase("5 5\n1 2 E\n", new[] {1, 2}, Heading.East)]
        [TestCase("5 5\n1 2 S\n", new[] {1, 2}, Heading.South)]
        [TestCase("5 5\n1 2 W\n", new[] {1, 2}, Heading.West)]
        [TestCase("11 11\n10 10 N\n", new[] {10, 10}, Heading.North)]
        [TestCase("999 999\n321 123 N\n", new[] {321, 123}, Heading.North)]
        [TestCase("0 0\n999 999 N\n", new[] {999, 999}, Heading.North)]
        [TestCase("0 0\n999 999 n\n", new[] {999, 999}, Heading.North)]
        public void CorrectlyParseAVectorWithHeading(string input, int[] expectedPosition, Heading expectedHeading)
        {
            var expectedInitialPosition =
                new VectorWithHeading(expectedPosition[0], expectedPosition[1], expectedHeading);

            var result = new Parser().Parse(input);

            Assert.That(result.GetInitialPosition(), Is.EqualTo(expectedInitialPosition));
        }

        [TestCase("1 1\nA 1 N\n")]
        [TestCase("1 1\n1 A N\n")]
        [TestCase("1 1\n1,1 N\n")]
        [TestCase("1 1\n1 1,N\n")]
        [TestCase("1 1\n1 1 N \n")]
        public void ThrowAnArgumentExceptionWhenPassedAnInvalidStringRepresentationOfAVector(string input)
        {
            Assert.Throws<ArgumentException>(() => new Parser().Parse(input));
        }

        [TestCase("1 1\n1 1 F\n")]
        [TestCase("1 1\n1 1 North\n")]
        public void ThrowAnInvalidHeadingExceptionWhenPassedAnInvalidStringRepresentationOfAHeading(string input)
        {
            Assert.Throws<InvalidHeadingException>(() => new Parser().Parse(input));
        }

        [TestCase("1 1\n1 1 N\n", new Movement[] {})]
        [TestCase("1 1\n1 1 N\nL", new[] {Movement.TurnLeft})]
        [TestCase("1 1\n1 1 N\nR", new[] {Movement.TurnRight})]
        [TestCase("1 1\n1 1 N\nM", new[] {Movement.MoveForward})]
        [TestCase("1 1\n1 1 N\nMMMM", new[]
            {Movement.MoveForward, Movement.MoveForward, Movement.MoveForward, Movement.MoveForward})]
        [TestCase("1 1\n1 1 N\nLMRM", new[]
            {Movement.TurnLeft, Movement.MoveForward, Movement.TurnRight, Movement.MoveForward})]
        public void CorrectlyParseASequenceOfMovements(string input, Movement[] expectedMovementSequence)
        {
            var result = new Parser().Parse(input);

            Assert.That(result.GetMovements(), Is.EquivalentTo(expectedMovementSequence));
        }

        [TestCase("1 1\n1 1 N\nA")]
        [TestCase("1 1\n1 1 N\n1")]
        [TestCase("1 1\n1 1 N\nFOO")]
        [TestCase("1 1\n1 1 N\nL1")]
        [TestCase("1 1\n1 1 N\nL ")]
        [TestCase("1 1\n1 1 N\n L")]
        [TestCase("1 1\n1 1 N\nl")]
        [TestCase("1 1\n1 1 N\nr")]
        [TestCase("1 1\n1 1 N\nm")]
        public void ThrowAnInvalidMovementExceptionWhenPassedAnInvalidRepresentationOfAMovement(string input)
        {
            Assert.Throws<InvalidMovementException>(() => new Parser().Parse(input));
        }
    }
}