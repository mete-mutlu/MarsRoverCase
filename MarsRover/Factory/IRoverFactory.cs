using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Factory
{
    public interface IRoverFactory
    {
        IRover CreateRover();
    }
}
