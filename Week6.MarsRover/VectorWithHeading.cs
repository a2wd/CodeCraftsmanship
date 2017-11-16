namespace Week6.MarsRover
{
    using System;
    public class VectorWithHeading
    {
        private readonly int _xPosition;
        private readonly int _yPosition;
        private readonly Heading _heading;

        public VectorWithHeading(int xPosition, int yPosition, Heading heading)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _heading = heading;
        }

        public int GetXPosition()
        {
            return _xPosition;
        }

        public int GetYPosition()
        {
            return _yPosition;
        }

        public Heading GetHeading()
        {
            return _heading;
        }
    }
}