using NUnit.Framework;

namespace Week6.MarsRover.Tests
{
    using System;
    using System.Runtime.InteropServices;

    [TestFixture]
    public class MarsRoverShould
    {
        [Test]
        public void RestAtExpectedCoordinates()
        { 
            var initialVectorWithHeading = new VectorWithHeading(1, 2, Heading.North);
            var expectedVectorWithHeading = new VectorWithHeading(1, 2, Heading.North);

            var rover = new MarsRover(initialVectorWithHeading, new Plateau(1, 2));

            var roverPosition = rover.GetVectorWithHeading();
            Assert.That(roverPosition, Is.EqualTo(expectedVectorWithHeading).Using(new VectorWithHeadingComparer()));
        }

        [Test]
        public void ThrowExceptionWhenRoverLandsOutsidePlateuBoundary()
        {
            var initialPosition = new VectorWithHeading(6, 6, Heading.North);
            var plateau = new Plateau(5, 5);

           Assert.Throws<RoverOutsideOfPlateauException>(() => new MarsRover(initialPosition, plateau));
        }
    }
}
