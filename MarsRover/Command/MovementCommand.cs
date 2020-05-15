using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{
    [ExcludeFromCodeCoverage]
    public class MovementCommand : IMovementCommand
    {
        public IList<Movement> Movements { get; private set; }
        public CommandType CommandType => this.CommandType;
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
