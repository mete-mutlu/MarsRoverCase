using MarsRover.Domain;
using System.Collections.Generic;

namespace MarsRover.Command
{
    public interface IMovementCommand : ICommand
    {
        IList<Movement> Movements { get; }
        void SetReceiver(IRover rover);
    }
}
