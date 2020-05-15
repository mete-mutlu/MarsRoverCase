using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{
    [ExcludeFromCodeCoverage]
    public class LandingCommand : ILandingCommand
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }

        public CommandType CommandType => this.CommandType;

        private IRover rover;
        private PlateuBase plateu;
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void SetReceivers(IRover aRover, PlateuBase aLandingSurface)
        {
            throw new NotImplementedException();
        }
    }
}
