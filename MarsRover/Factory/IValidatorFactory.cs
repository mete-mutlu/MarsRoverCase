using MarsRover.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Factory
{
    public interface IValidatorFactory
    {
        ILocationValidator CreateLocationValidator();
    }
}
