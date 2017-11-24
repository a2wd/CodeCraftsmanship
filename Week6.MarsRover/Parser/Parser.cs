namespace Week6.MarsRover.Parser
{
    using System;
    using Exceptions;
    using Terrain;

    public class Parser
    {
        private const char InputSeparator = ' ';

        public ParserOutput Parse(string input)
        {
            Plateau plateau;
            VectorWithHeading vectorWithHeading;

            var lines = input.Split('\n');

            var plateauInput = lines[0].Split(InputSeparator);

            if (plateauInput.Length != 2)
            {
                throw new ArgumentException();
            }

            try
            {
                plateau = new Plateau(int.Parse(plateauInput[0]), int.Parse(plateauInput[1]));
            }
            catch 
            {
                throw new ArgumentException();
            }

            var vectorWithHeadingInput = lines[1].Split(InputSeparator);

            try
            {
                vectorWithHeading = new VectorWithHeading(int.Parse(vectorWithHeadingInput[0]), int.Parse(vectorWithHeadingInput[1]), ParseHeading(vectorWithHeadingInput[2]));
            }
            catch
            {
                throw new ArgumentException();
            }

            return new ParserOutput(plateau, vectorWithHeading);
        }

        private Heading ParseHeading(string headingInput)
        {
            switch (headingInput.ToUpper())
            {
                case "N":
                    return Heading.North;
                case "E":
                    return Heading.East;
                case "S":
                    return Heading.South;
                case "W":
                    return Heading.West;
                default:
                    throw new InvalidHeadingException();
            }
        }
    }
}