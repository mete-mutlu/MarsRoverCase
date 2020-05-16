using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverFactory : IRoverFactory
    {
        public IRover CreateRover()
        {
            return new Rover();
        }
    }
}
