using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{

    public interface ICommand
    {
        CommandType CommandType { get; }
        void Execute();
    }
}
