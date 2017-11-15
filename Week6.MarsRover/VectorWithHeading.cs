namespace Week6.MarsRover
{
    using System;
    public class VectorWithHeading : IEquatable<VectorWithHeading>
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


        public bool Equals(VectorWithHeading otherObject)
        {
            var otherVectorWithHeading = (VectorWithHeading) otherObject;

            if (otherVectorWithHeading == null)
            {
                return false;
            }

            return (_xPosition == otherVectorWithHeading._xPosition &&
                    _yPosition == otherVectorWithHeading._yPosition && 
                            _heading == otherVectorWithHeading._heading);
        }

        public override int GetHashCode()
        {
            return this._xPosition.GetHashCode() ^ this._yPosition.GetHashCode() ^ ((int)this._heading).GetHashCode();
        }
    }
}