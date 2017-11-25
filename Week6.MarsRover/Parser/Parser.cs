namespace Week6.MarsRover.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Terrain;
    using Movement;

    public class Parser
    {
        private const char InputSeparator = ' ';
        private const char LineSeparator = '\n';

        private const int PlateauLineIndex = 0;
        private const int InitialVectorWithHeadingLineIndex = 1;
        private const int MovementsLineIndex = 2;

        public ParserOutput Parse(string input)
        {
            var lines = input.Split(LineSeparator);

            Plateau plateau = ParsePlateau(lines[PlateauLineIndex]);
            VectorWithHeading initialVectorWithHeading = ParseVectorWithHeading(lines[InitialVectorWithHeadingLineIndex]);
            Movement[] movements = ParseMovements(lines[MovementsLineIndex]);

            return new ParserOutput(plateau, initialVectorWithHeading, movements);
        }

        private Movement[] ParseMovements(string inputLine)
        {
            return inputLine.Select(ParseMovement).ToArray();
        }

        private Movement ParseMovement(char input)
        {
            switch (input)
            {
                case 'L':
                    return Movement.TurnLeft;
                case 'R':
                    return Movement.TurnRight;
                case 'M':
                    return Movement.MoveForward;
                default:
                    throw new InvalidMovementException(input.ToString());
            }
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