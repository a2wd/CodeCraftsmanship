namespace Week6.MarsRover.Tests
{
    using NUnit.Framework;
    using Terrain;

    [TestFixture]
    public class PlateauShould
    {
        [Test]
        public void BeEqualToAnotherPlateauOfTheSameDimensions()
        {
            var firstPlateau = new Plateau(1, 1);
            var secondPlateau = new Plateau(1, 1);

            Assert.That(firstPlateau, Is.EqualTo(secondPlateau));
        }

        [Test]
        public void NotBeEqualToAnotherPlateauOfDifferentDimensions()
        {
            var firstPlateau = new Plateau(1, 1);
            var secondPlateau = new Plateau(2, 2);

            Assert.That(firstPlateau, Is.Not.EqualTo(secondPlateau));
        }

        [Test]
        public void BeEqualToItself()
        {
            var firstPlateau = new Plateau(1, 1);

            Assert.That(firstPlateau, Is.EqualTo(firstPlateau));
        }

        [Test]
        public void NotBeEqualToANullInstanceOfPlateau()
        {
            var firstPlateau = new Plateau(1, 1);

            Assert.That(firstPlateau, Is.Not.EqualTo(null));
        }
    }
}
