namespace Week6.MarsRover
{
    using System;
    public class VectorWithHeading : IComparable<VectorWithHeading>
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


        public int CompareTo(VectorWithHeading other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var xPositionComparison = _xPosition.CompareTo(other._xPosition);
            if (xPositionComparison != 0) return xPositionComparison;
            var yPositionComparison = _yPosition.CompareTo(other._yPosition);
            if (yPositionComparison != 0) return yPositionComparison;
            return _heading.CompareTo(other._heading);
        }

    
    }
}