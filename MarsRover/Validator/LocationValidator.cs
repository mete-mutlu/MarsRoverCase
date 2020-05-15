using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class LocationValidator : ILocationValidator
    {
        private readonly PlateuBase plateu;
        public LocationValidator(PlateuBase plateu)
        {
            this.plateu = plateu;
        }
        public bool Validate(Location location)
        {
            var isXValid = location.X >= 0 && location.X < this.plateu.Size.Width;
            var isYValid = location.Y >= 0 && location.Y < this.plateu.Size.Height;
            return isXValid && isYValid;
        }
    }
}
