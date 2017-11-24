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

            var comparison = firstPlateau.Equals(secondPlateau);

            Assert.That(comparison, Is.True);
        }

        [Test]
        public void NotBeEqualToAnotherPlateauOfDifferentDimensions()
        {
            var firstPlateau = new Plateau(1, 1);
            var secondPlateau = new Plateau(2, 2);

            var comparison = firstPlateau.Equals(secondPlateau);

            Assert.That(comparison, Is.False);
        }

        [Test]
        public void BeEqualToItself()
        {
            var firstPlateau = new Plateau(1, 1);

            var comparison = firstPlateau.Equals(firstPlateau);

            Assert.That(comparison, Is.True);
        }

        [Test]
        public void NotBeEqualToANullInstanceOfPlateau()
        {
            var firstPlateau = new Plateau(1, 1);

            var comparison = firstPlateau.Equals(null);

            Assert.That(comparison, Is.False);
        }
    }
}
