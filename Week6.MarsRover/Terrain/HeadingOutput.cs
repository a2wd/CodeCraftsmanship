namespace Week6.MarsRover.Terrain
{
    using Exceptions;

    public class HeadingOutput
    {
        public static string HeadingToString(Heading heading)
        {
            switch (heading)
            {
                case Heading.North:
                    return "N";
                case Heading.East:
                    return "E";
                case Heading.South:
                    return "S";
                case Heading.West:
                    return "W";
            }

            throw new InvalidHeadingException();
        }
    }
}
