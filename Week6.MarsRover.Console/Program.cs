namespace Week6.MarsRover.Console
{
    using System.Text;
    using System;
    using Movement;
    using Parser;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new StringBuilder();

            string line = Console.ReadLine();

            while (line != null)
            {
                input.Append(line);
                input.Append('\n');

                line = Console.ReadLine();
            }

            var parsedInput = new Parser().Parse(input.ToString());
            
            var marsRover = new MarsRover(parsedInput.GetInitialPosition(), parsedInput.GetPlateau());

            new Driver().Drive(marsRover, parsedInput.GetMovements());

            Console.Write(marsRover.GetVectorWithHeading().ToString());
        }
    }
}