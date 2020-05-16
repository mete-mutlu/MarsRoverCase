using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{
    [ExcludeFromCodeCoverage]
    public class SetPlateuSizeCommand : ISetPlateuSizeCommand
    {
        public Size Size { get; set; }
        private PlateuBase plateu  { get; set; }

        public CommandType CommandType => this.CommandType;

        public SetPlateuSizeCommand(Size size)
        {
            this.Size = size;
        }

        public void SetReceiver(PlateuBase plateu)
        {
            this.plateu = plateu;
        }

        public void Execute()
        {
            plateu.Size = this.Size;
        }
    }
}
