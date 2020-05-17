using MarsRover.Command;
using MarsRover.Domain;
using MarsRover.Validator;
using System.Collections.Generic;

namespace MarsRover.Factory
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
            return new LandingCommand(this.locationValidator, location, direction) { CommandType = CommandType.Land };
        }

        public IMovementCommand CreateMovementCommand(IList<Movement> movements)
        {
            return new MovementCommand(movements) { CommandType = CommandType.Move };
        }

        public ISetPlateuSizeCommand CreateSetPlateuSizeCommand(Size size)
        {
            return new SetPlateuSizeCommand(size) { CommandType = CommandType.SetPlateauSize };
        }
    }
}
