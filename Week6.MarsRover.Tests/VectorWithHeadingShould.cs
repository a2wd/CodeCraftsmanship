using NUnit.Framework;

namespace Week6.MarsRover.Tests
{
    [TestFixture]
    public class VectorWithHeadingShould
    {
        [Test]
        public void BeEqualToAnotherVectorWithHeadingObjectWhenBothAreInstanciatedWithTheSameParameterValues()
        {
            var firstVectorWithHeading = new VectorWithHeading(10,5,Heading.North);
            var secondVectorWithHeading = new VectorWithHeading(10,5,Heading.North);

            Assert.AreEqual(firstVectorWithHeading,secondVectorWithHeading);
        }

        [Test]
        public void NotBeEqualToAnotherVectorWithHeadingObjectWhenBothAreInstanciatedWithDifferentParameterValues()
        {
            var firstVectorWithHeading = new VectorWithHeading(10, 5, Heading.North);
            var secondVectorWithHeading = new VectorWithHeading(13, 1, Heading.South);

            Assert.AreNotEqual(firstVectorWithHeading, secondVectorWithHeading);
        }
    }
}