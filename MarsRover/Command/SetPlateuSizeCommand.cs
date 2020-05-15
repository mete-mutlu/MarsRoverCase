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

        public PlateuBase Plateu  { get; set; }



        public CommandType CommandType => this.CommandType;

        public SetPlateuSizeCommand(Size size)
        {
            this.Size = size;
        }

        public void SetReceiver(PlateuBase plateu)
        {
            this.Plateu = plateu;
        }

        public void Execute()
        {
            Plateu.Size = this.Size;
        }
    }
}
