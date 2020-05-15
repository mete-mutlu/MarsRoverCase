using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface IMovementCommand : ICommand
    {
        IList<Movement> Movements { get; }
        void SetReceiver(IRover rover);
    }
}
