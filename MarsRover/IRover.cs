using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface IRover
    {
        Location Location { get; set; }
        Direction Direction { get; set; }

        void SetPlateuSize(PlateuBase plateu, Location location, Direction direction);
        void Land(PlateuBase plateu, Location location, Direction direction);
        void Move(IEnumerable<Movement> movements);
        bool IsLanded();
    }
}
