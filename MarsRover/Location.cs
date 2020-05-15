using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{
    [ExcludeFromCodeCoverage]
    public class Location
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
