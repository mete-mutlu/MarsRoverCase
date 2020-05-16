using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public class CommandFactory : ICommandFactory
    {

        private readonly ILocationValidator locationValidator;

        public CommandFactory(ILocationValidator locationValidator) 
        {
            this.locationValidator = locationValidator;
        }
        public ILandingCommand CreateLandingCommand(Location location, Direction direction)
        {
            return new LandingCommand(this.locationValidator, location,direction);
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
