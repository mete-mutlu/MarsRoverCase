using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{
  
    public class LandingCommand : ILandingCommand
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }
        public CommandType CommandType => this.CommandType;

        private IRover rover;
        private PlateuBase plateu;
        private readonly ILocationValidator locationValidator;

        public LandingCommand(ILocationValidator locationValidator, Location location, Direction direction)
        {
            this.locationValidator = locationValidator;
            this.Location = location;
            this.Direction = direction;
        }
        public void Execute()
        {
            rover.Land(this.locationValidator,plateu, Location, Direction);
        }

        public void SetReceivers(IRover rover, PlateuBase plateu)
        {
            this.rover = rover;
            this.plateu = plateu;
        }
    }
}
