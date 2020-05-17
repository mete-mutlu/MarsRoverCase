using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface IMovementCommand : ICommand
    {
        IList<Movement> Movements { get; }
        void SetReceiver(IRover rover);
    }
}
