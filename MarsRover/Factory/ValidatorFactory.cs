using MarsRover.Factory;
using MarsRover.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Factory
{
    public class ValidatorFactory : IValidatorFactory
    {
        public ILocationValidator CreateLocationValidator()
        {
            return new LocationValidator();
        }
    }
}
