using System.Collections.Generic;

namespace MarsRover.Domain
{
    public interface IRover
    {
        Location Location { get; set; }
        Direction Direction { get; set; }

        IPlateu Plateu { get; set; }
        void Land(IPlateu plateu, Location location, Direction direction);

        bool IsLanded();
        void Move(IEnumerable<Movement> movements);

      
    }
}
