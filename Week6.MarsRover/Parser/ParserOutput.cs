namespace Week6.MarsRover.Parser
{
    using Terrain;

    public class ParserOutput
    {
        private readonly VectorWithHeading _vectorWithHeading;
        private readonly Plateau _plateau;

        public ParserOutput(Plateau plateau, VectorWithHeading vectorWithHeading)
        {
            _vectorWithHeading = vectorWithHeading;
            _plateau = plateau;
        }
        public VectorWithHeading GetInitialPosition()
        {
            return _vectorWithHeading;
        }

        public Plateau GetPlateau()
        {
            return _plateau; 
        }
        
    }
}
