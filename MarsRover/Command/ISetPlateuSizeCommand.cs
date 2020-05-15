using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface ISetPlateuSizeCommand : ICommand
    {
        Size Size { get; }
        void SetReceiver(PlateuBase plateu);
    }

}
