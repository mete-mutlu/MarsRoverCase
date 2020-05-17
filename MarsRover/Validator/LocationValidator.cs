using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Validator
{
    public  class LocationValidator : ILocationValidator
    {

        public bool Validate(Location location, IPlateu plateu)
        {
            var isXValid = location.X >= 0 && location.X <= plateu?.Size?.Width;
            var isYValid = location.Y >= 0 && location.Y <= plateu?.Size?.Height;
            return isXValid && isYValid;
        }
    }
}
