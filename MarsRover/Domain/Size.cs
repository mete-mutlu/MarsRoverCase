using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover.Domain
{
    [ExcludeFromCodeCoverage]
    public class Size 
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public Size( int width , int height)
        {
            Height = height;
            Width = width;
        }
    }
}
