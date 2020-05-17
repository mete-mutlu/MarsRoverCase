using MarsRover.Command;
using MarsRover.Domain;
using System.Collections.Generic;

namespace MarsRover.Factory
{
    public interface ICommandFactory
    {
        ISetPlateuSizeCommand CreateSetPlateuSizeCommand(Size size);

        ILandingCommand CreateLandingCommand(Location location, Direction direction);

        IMovementCommand CreateMovementCommand(IList<Movement> movements); 

    }
}
