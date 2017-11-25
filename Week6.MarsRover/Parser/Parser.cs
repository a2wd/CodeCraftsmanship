namespace Week6.MarsRover.Parser
{
    using System;
    using Exceptions;
    using Terrain;

    public class Parser
    {
        private const char InputSeparator = ' ';
        private const char LineSeparator = '\n';

        private const int PlateauLineIndex = 0;
        private const int InitialVectorWithHeadingLineIndex = 1;

        public ParserOutput Parse(string input)
        {
            Plateau plateau;
            VectorWithHeading initialVectorWithHeading;

            var lines = input.Split(LineSeparator);

            plateau = ParsePlateau(lines[PlateauLineIndex]);

            initialVectorWithHeading = ParseVectorWithHeading(lines[InitialVectorWithHeadingLineIndex]);

            return new ParserOutput(plateau, initialVectorWithHeading);
        }

        private VectorWithHeading ParseVectorWithHeading(string inputLine)
        {
            var vectorWithHeadingInput = inputLine.Split(InputSeparator);

            if (vectorWithHeadingInput.Length != 3)
            {
                throw new ArgumentException();
            }

            int xPosition;
            int yPosition;

            try
            {
                xPosition = int.Parse(vectorWithHeadingInput[0]);
                yPosition = int.Parse(vectorWithHeadingInput[1]);
            }
            catch
            {
                throw new ArgumentException();
            }

            var heading = ParseHeading(vectorWithHeadingInput[2]);

            return new VectorWithHeading(xPosition, yPosition, heading);
        }

        private Plateau ParsePlateau(string inputLine)
        {
            var plateauInput = inputLine.Split(InputSeparator);

            if (plateauInput.Length != 2)
            {
                throw new ArgumentException();
            }

            try
            {
                return new Plateau(int.Parse(plateauInput[0]), int.Parse(plateauInput[1]));
            }
            catch
            {
                throw new ArgumentException();
            }
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