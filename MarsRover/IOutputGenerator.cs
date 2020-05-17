using MarsRover.Domain;
using System.Collections.Generic;

namespace MarsRover
{
    public interface IOutputGenerator
    {
        string GenerateOutput(IEnumerable<IRover> rovers);
    }
}
