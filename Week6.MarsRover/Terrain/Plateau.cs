namespace Week6.MarsRover.Terrain
{
    using System;
    public class Plateau : IEquatable<Plateau>
    {
        private readonly int _xPosition;
        private readonly int _yPosition;

        public Plateau(int xPosition, int yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }

        public int GetXPosition()
        {
            return _xPosition;
        }

        public int GetYPosition()
        {
            return _yPosition;
        }

        public bool Equals(Plateau other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _xPosition == other._xPosition &&
                   _yPosition == other._yPosition;
        }
    }
}