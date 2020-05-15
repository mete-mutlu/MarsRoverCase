using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface ILocationValidator
    {
        bool Validate(Location location);
    }
}
