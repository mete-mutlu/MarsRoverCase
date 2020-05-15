using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface ILandingCommand : ICommand
    {
        Direction Direction { get; set; }
        Location Location { get; set; }
        void SetReceivers(IRover aRover, PlateuBase aLandingSurface);
    }
}
