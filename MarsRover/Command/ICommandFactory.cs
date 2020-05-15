using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface ICommandFactory
    {
        ISetPlateuSizeCommand CreateSetPlateuSizeCommand(Size size);

        ILandingCommand CreateLandingCommand(Location location, Direction direction);

        IMovementCommand CreateMovementCommand(IList<Movement> movements); 

    }
}
