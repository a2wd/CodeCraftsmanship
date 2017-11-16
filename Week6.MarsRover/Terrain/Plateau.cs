namespace Week6.MarsRover.Terrain
{
    public class Plateau
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
    }
}