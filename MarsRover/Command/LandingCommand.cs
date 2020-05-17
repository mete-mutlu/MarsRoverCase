using MarsRover.Domain;
using MarsRover.Validator;

namespace MarsRover.Command
{
  
    public class LandingCommand : ILandingCommand
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }
        public CommandType CommandType { get; set; }

        private IRover rover;
        private IPlateu plateu;
        private readonly ILocationValidator locationValidator;

        public LandingCommand(ILocationValidator locationValidator, Location location, Direction direction)
        {
            this.locationValidator = locationValidator;
            this.Location = location;
            this.Direction = direction;
        }
        public void Execute()
        {
            rover.Land(plateu, Location, Direction);
        }

        public void SetReceivers(IRover rover, IPlateu plateu)
        {
            this.rover = rover;
            this.plateu = plateu;
        }
    }
}
