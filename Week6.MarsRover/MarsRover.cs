namespace Week6.MarsRover
{
    using Exceptions;
    using Terrain;

    public class MarsRover
    {
        private VectorWithHeading _currentVectorWithHeading;
        private readonly Plateau _plateau;

        public MarsRover(VectorWithHeading initialVectorWithHeading, Plateau plateu)
        {
            _plateau = plateu;
            _currentVectorWithHeading = initialVectorWithHeading;

            if (IsVectorIsOutsidePlateau(initialVectorWithHeading))
            {
                throw new RoverOutsideOfPlateauException();
            }
        }

        private bool IsVectorIsOutsidePlateau(VectorWithHeading vectorWithHeading)
        {
            if (vectorWithHeading.GetXPosition() < 0 ||
                vectorWithHeading.GetYPosition() < 0 ||
                vectorWithHeading.GetXPosition() > _plateau.GetXPosition() ||
                vectorWithHeading.GetYPosition() > _plateau.GetYPosition())
            {
                return true;
            }

            return false;
        }

        public VectorWithHeading GetVectorWithHeading()
        {
            return _currentVectorWithHeading;
        }

        public void TurnRight()
        {
            var newHeading = Heading.North;

            switch (GetVectorWithHeading().GetHeading())
            {
                case Heading.North:
                    newHeading = Heading.East;
                    break;
                case Heading.East:
                    newHeading = Heading.South;
                    break;
                case Heading.South:
                    newHeading = Heading.West;
                    break;
                case Heading.West:
                    newHeading = Heading.North;
                    break;
            }

            _currentVectorWithHeading = new VectorWithHeading(
                GetVectorWithHeading().GetXPosition(),
                GetVectorWithHeading().GetYPosition(),
                newHeading);
        }

        public void TurnLeft()
        {
            var newHeading = Heading.North;

            switch (GetVectorWithHeading().GetHeading())
            {
                case Heading.North:
                    newHeading = Heading.West;
                    break;
                case Heading.East:
                    newHeading = Heading.North;
                    break;
                case Heading.South:
                    newHeading = Heading.East;
                    break;
                case Heading.West:
                    newHeading = Heading.South;
                    break;
            }

            _currentVectorWithHeading = new VectorWithHeading(
                GetVectorWithHeading().GetXPosition(),
                GetVectorWithHeading().GetYPosition(),
                newHeading);
        }

        public void Move()
        {
            int xPosition = GetVectorWithHeading().GetXPosition();
            int yPosition = GetVectorWithHeading().GetYPosition();

            var heading = GetVectorWithHeading().GetHeading();

            switch (heading)
            {
                case Heading.North:
                    yPosition++;
                    break;
                case Heading.East:
                    xPosition++;
                    break;
                case Heading.South:
                    yPosition--;
                    break;
                case Heading.West:
                    xPosition--;
                    break;
            }
            
            _currentVectorWithHeading = new VectorWithHeading(xPosition, yPosition, heading);

            if (IsVectorIsOutsidePlateau(_currentVectorWithHeading))
            {
                throw new  RoverOutsideOfPlateauException();
            }
        }
    }
}

