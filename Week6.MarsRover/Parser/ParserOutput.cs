namespace Week6.MarsRover.Parser
{
    using Terrain;
    using Movement;

    public class ParserOutput
    {
        private readonly VectorWithHeading _vectorWithHeading;
        private readonly Plateau _plateau;
        private readonly Movement[] _movements;

        public ParserOutput(Plateau plateau, VectorWithHeading vectorWithHeading, Movement[] movements)
        {
            _vectorWithHeading = vectorWithHeading;
            _plateau = plateau;
            _movements = movements;
        }
        public VectorWithHeading GetInitialPosition()
        {
            return _vectorWithHeading;
        }

        public Plateau GetPlateau()
        {
            return _plateau; 
        }

        public Movement[] GetMovements()
        {
            return _movements;
        }
    }
}
