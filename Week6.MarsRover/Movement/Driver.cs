namespace Week6.MarsRover.Movement
{
    using System.Linq;

    public class Driver
    {
        public void Drive(MarsRover marsRover, Movement[] movements)
        {
            movements.ToList().ForEach(movement => MakeMovement(marsRover, movement));
        }

        public void MakeMovement(MarsRover marsRover, Movement movement)
        {
            switch (movement)
            {
                case Movement.MoveForward:
                    marsRover.Move();
                    break;
                case Movement.TurnLeft:
                    marsRover.TurnLeft();
                    break;
                case Movement.TurnRight:
                    marsRover.TurnRight();
                    break;
            }
        }
    }
}
