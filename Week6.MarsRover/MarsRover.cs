namespace Week6.MarsRover
{
    using Exceptions;
    using Terrain;

    public class MarsRover
    {
        private readonly VectorWithHeading _currentVectorWithHeading;
        private readonly Plateau _plateau;

        public MarsRover(VectorWithHeading initialVectorWithHeading, Plateau plateu)
        {
            _plateau = plateu;
            _currentVectorWithHeading = initialVectorWithHeading;

            if (InitialVectorIsOutsidePlateu())
            {
                throw new RoverOutsideOfPlateauException();
            }
        }

        private bool InitialVectorIsOutsidePlateu()
        {
            if (_currentVectorWithHeading.GetXPosition() < 0 ||
                _currentVectorWithHeading.GetYPosition() < 0 ||
                _currentVectorWithHeading.GetXPosition() > _plateau.GetXPosition() ||
                _currentVectorWithHeading.GetYPosition() > _plateau.GetYPosition())
            {
                return true;
            }

            return false;
        }

        public VectorWithHeading GetVectorWithHeading()
        {
            return _currentVectorWithHeading;
        }
    }
}
