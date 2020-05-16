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

        public LandingCommand(Location location, Direction direction)
        {
            this.Location = location;
            this.Direction = direction;
        }
        public void Execute()
        {
            rover.Land(plateu, Location, Direction);
        }

        public void SetReceivers(IRover rover, PlateuBase plateu)
        {
            this.rover = rover;
            this.plateu = plateu;
        }
    }
}
