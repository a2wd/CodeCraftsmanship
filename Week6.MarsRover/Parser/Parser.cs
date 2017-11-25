namespace Week6.MarsRover.Parser
{
    using System;
    using Exceptions;
    using Terrain;

    public class Parser
    {
        private const char InputSeparator = ' ';
        private const char LineSeparator = '\n';

        public ParserOutput Parse(string input)
        {
            Plateau plateau;
            VectorWithHeading vectorWithHeading;

            var lines = input.Split(LineSeparator);

            try
            {
                plateau = ParsePlateau(lines);

                vectorWithHeading = ParseVectorWithHeading(lines);
            }
            catch
            {
                throw new ArgumentException();
            }

            return new ParserOutput(plateau, vectorWithHeading);
        }

        private VectorWithHeading ParseVectorWithHeading(string[] lines)
        {
            var vectorWithHeadingInput = lines[1].Split(InputSeparator);

            return new VectorWithHeading(int.Parse(vectorWithHeadingInput[0]),
                int.Parse(vectorWithHeadingInput[1]), ParseHeading(vectorWithHeadingInput[2]));
        }

        private Plateau ParsePlateau(string[] lines)
        {
            var plateauInput = lines[0].Split(InputSeparator);

            if (plateauInput.Length != 2)
            {
                throw new ArgumentException();
            }

            return new Plateau(int.Parse(plateauInput[0]), int.Parse(plateauInput[1]));
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