namespace Week6.MarsRover.Tests
{
    using Exceptions;
    using NUnit.Framework;
    using Terrain;

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
            Assert.That(roverPosition, Is.EqualTo(expectedVectorWithHeading));
        }

        [Test]
        public void ThrowExceptionWhenRoverLandsOutsidePlateauBoundary()
        {
            var initialPosition = new VectorWithHeading(6, 6, Heading.North);
            var plateau = new Plateau(5, 5);

           Assert.Throws<RoverOutsideOfPlateauException>(() => new MarsRover(initialPosition, plateau));
        }

        [Test]
        public void BeOrientedToTheSouthWhenAfterTurningTwiceFromAStartingOrientationOfNorth()
        {
            var initialPosition = new VectorWithHeading(2, 2, Heading.North);
            var plateau = new Plateau(5, 5);

            var marsRover = new MarsRover(initialPosition, plateau);

            marsRover.TurnRight();
            marsRover.TurnRight();

            var result = marsRover.GetVectorWithHeading();

            Assert.That(result, Is.EqualTo(new VectorWithHeading(2, 2, Heading.South)));
        }

        [Test]
        public void BeOrientedToTheWestWhenAfterTurningOnceFromAStartingOrientationOfNorth()
        {
            var initialPosition = new VectorWithHeading(2, 2, Heading.North);
            var plateau = new Plateau(5, 5);

            var marsRover = new MarsRover(initialPosition, plateau);

            marsRover.TurnLeft();

            var result = marsRover.GetVectorWithHeading();

            Assert.That(result, Is.EqualTo(new VectorWithHeading(2, 2, Heading.West)));
        }

        [Test]
        public void MovePositionByOneFromInitialPositionWhenMoveCommandCalled()
        {
            var initialPosition = new VectorWithHeading(2, 2, Heading.North);
            var plateau = new Plateau(5, 5);

            var marsRover = new MarsRover(initialPosition, plateau);

            marsRover.Move();

            var result = marsRover.GetVectorWithHeading();

            Assert.That(result, Is.EqualTo(new VectorWithHeading(2, 3, Heading.North)));
        }

        [Test]
        public void ThrowARoverOutsideOfPlateauExceptionWhenMovedOutsideOfThePlateauBounds()
        {
            var initialPosition = new VectorWithHeading(2, 2, Heading.North);
            var plateau = new Plateau(2, 2);

            var marsRover = new MarsRover(initialPosition, plateau);

            Assert.Throws<RoverOutsideOfPlateauException>(() => marsRover.Move());
        }

        [Test]
        public void ReturnExpectedOutputOnSetSequenceofMovementCommands()
        {
            var initialPosition = new VectorWithHeading(1, 2, Heading.North);
            var expectedPosition = new VectorWithHeading(1, 3, Heading.North);

            var plateau = new Plateau(5, 5);
            
            var marsRover = new MarsRover(initialPosition, plateau);

            marsRover.TurnLeft();
            marsRover.Move();
            marsRover.TurnLeft();
            marsRover.Move();
            marsRover.TurnLeft();
            marsRover.Move();
            marsRover.TurnLeft();
            marsRover.Move();
            marsRover.Move();

            var result = marsRover.GetVectorWithHeading();

            Assert.That(result, Is.EqualTo(expectedPosition));
        }
    }
}
