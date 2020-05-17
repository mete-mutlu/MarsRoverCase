using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Exception
{
    [Serializable]
    public class OutOfBoundaryLandingException: System.Exception
    {
        public override string Message => "Cannot land out of plateu!";
    }
}
