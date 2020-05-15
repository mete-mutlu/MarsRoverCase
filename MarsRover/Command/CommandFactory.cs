using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public class CommandFactory : ICommandFactory
    {
        public ILandingCommand CreateLandingCommand(Location location, Direction direction)
        {
            return new LandingCommand();
        }

        public IMovementCommand CreateMovementCommand(IList<Movement> movements)
        {
            return new MovementCommand(movements);
        }

        public ISetPlateuSizeCommand CreateSetPlateuSizeCommand(Size size)
        {
            return new SetPlateuSizeCommand(size);
        }
    }
}
