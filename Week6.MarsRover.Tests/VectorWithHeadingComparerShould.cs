namespace Week6.MarsRover.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class VectorWithHeadingComparerShould
    {
        private VectorWithHeadingComparer _vectorWithHeadingComparer;

        [SetUp]
        public void SetUp()
        {
            _vectorWithHeadingComparer = new VectorWithHeadingComparer();
        }

        [Test]
        public void ReturnPlusOneWhenTheSecondInstanceIsNull()
        {
            var vectorWithHeading = new VectorWithHeading(1, 1, Heading.North);

            int result = _vectorWithHeadingComparer.Compare(vectorWithHeading, null);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void ReturnMinusOneWhenTheFirstInstanceIsNull()
        {
            var vectorWithHeading = new VectorWithHeading(1, 1, Heading.North);

            int result = _vectorWithHeadingComparer.Compare(null, vectorWithHeading);

            Assert.That(result, Is.EqualTo(-1));
        }

        [TestCase(1, 1, Heading.North, 1, 1, Heading.North)]
        [TestCase(2, 3, Heading.South, 2, 3, Heading.South)]
        [TestCase(0, 5, Heading.West, 0, 5, Heading.West)]
        public void ReturnEqualForIdenticalInstances(
            int instanceOneXPosition, int instanceOneYPosition, Heading instanceOneHeading,
            int instanceTwoXPosition, int instanceTwoYPosition, Heading instanceTwoHeading
            )
        {
            var instanceOne = new VectorWithHeading(instanceOneXPosition, instanceOneYPosition, instanceOneHeading);
            var instanceTwo = new VectorWithHeading(instanceTwoXPosition, instanceTwoYPosition, instanceTwoHeading);

            int result = _vectorWithHeadingComparer.Compare(instanceOne, instanceTwo);

            Assert.That(result, Is.Zero);
        }

        [TestCase(1, 1, Heading.North, 2, 1, Heading.North)]
        [TestCase(2, 3, Heading.South, 2, 4, Heading.South)]
        [TestCase(0, 5, Heading.West, 0, 5, Heading.South)]
        public void ReturnsMinusOneWhenInstanceOneIsLessThanInstanceTwo(
            int instanceOneXPosition, int instanceOneYPosition, Heading instanceOneHeading,
            int instanceTwoXPosition, int instanceTwoYPosition, Heading instanceTwoHeading
            )
        {
            var instanceOne = new VectorWithHeading(instanceOneXPosition, instanceOneYPosition, instanceOneHeading);
            var instanceTwo = new VectorWithHeading(instanceTwoXPosition, instanceTwoYPosition, instanceTwoHeading);

            int result = _vectorWithHeadingComparer.Compare(instanceOne, instanceTwo);

            Assert.That(result, Is.EqualTo(-1));
        }

        [TestCase(3, 1, Heading.North, 2, 1, Heading.North)]
        [TestCase(2, 5, Heading.South, 2, 4, Heading.South)]
        [TestCase(0, 5, Heading.East, 0, 5, Heading.South)]
        public void ReturnsPositiveOneWhenInstanceOneIsGreaterThanInstanceTwo(
            int instanceOneXPosition, int instanceOneYPosition, Heading instanceOneHeading,
            int instanceTwoXPosition, int instanceTwoYPosition, Heading instanceTwoHeading
            )
        {
            var instanceOne = new VectorWithHeading(instanceOneXPosition, instanceOneYPosition, instanceOneHeading);
            var instanceTwo = new VectorWithHeading(instanceTwoXPosition, instanceTwoYPosition, instanceTwoHeading);

            int result = _vectorWithHeadingComparer.Compare(instanceOne, instanceTwo);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
