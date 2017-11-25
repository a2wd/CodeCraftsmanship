namespace Week6.MarsRover.Exceptions
{
    using System;

    public class InvalidMovementException : Exception
    {
        public InvalidMovementException(string invalidMovement) : base(FormattedErrorMessage(invalidMovement))
        {
        }

        public static string FormattedErrorMessage(string invalidMovement)
        {
            return $"Expected a valid movement ('L', 'R' or 'M'), but got {invalidMovement}";
        }
    }
}
