using MarsRover.Domain;
using System.Collections.Generic;

namespace MarsRover.Command
{

    public class MovementCommand : IMovementCommand
    {
        public IList<Movement> Movements { get; private set; }
        public CommandType CommandType { get; set; }
        private IRover rover;

        public MovementCommand(IList<Movement> movements)
        {
            Movements = movements;
        }

        public void Execute()
        {
            rover.Move(Movements);
        }

        public void SetReceiver(IRover rover)
        {
            this.rover = rover;
        }
    }
}
