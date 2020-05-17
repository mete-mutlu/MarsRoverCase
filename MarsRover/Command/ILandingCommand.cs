using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface ILandingCommand : ICommand
    {
        Direction Direction { get; set; }
        Location Location { get; set; }
        void SetReceivers(IRover rover, IPlateu plateu);
    }
}
