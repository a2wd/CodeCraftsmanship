namespace Week6.MarsRover.Tests
{
    using NUnit.Framework;
    using Terrain;

    [TestFixture]
    public class VectorWithHeadingShould
    {
        [Test]
        public void BeEqualToAnotherVectorWithHeadingObjectWhenBothAreInstanciatedWithTheSameParameterValues()
        {
            var firstVectorWithHeading = new VectorWithHeading(10,5,Heading.North);
            var secondVectorWithHeading = new VectorWithHeading(10,5,Heading.North);

            var equality = firstVectorWithHeading.Equals(secondVectorWithHeading);

            Assert.That(equality, Is.True);
        }

        [Test]
        public void NotBeEqualToAnotherVectorWithHeadingObjectWhenBothAreInstanciatedWithDifferentParameterValues()
        {
            var firstVectorWithHeading = new VectorWithHeading(10, 5, Heading.North);
            var secondVectorWithHeading = new VectorWithHeading(13, 1, Heading.South);

            var equality = firstVectorWithHeading.Equals(secondVectorWithHeading);
            
            Assert.That(equality, Is.False);
        }

        [Test]
        public void NotBeEqualToANullObject()
        {
            var firstVectorWithHeading = new VectorWithHeading(10, 5, Heading.North);

            var equality = firstVectorWithHeading.Equals(null);

            Assert.That(equality, Is.False);
        }
    }
}