using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface IOutputGenerator
    {
        string GetOutput(IEnumerable<IRover> rovers);
    }
}
