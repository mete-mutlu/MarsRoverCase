using System;

namespace MarsRover.Exception
{
    [Serializable]
    public class OutOfBoundaryMovementException : System.Exception
    {
        public override string Message => "Cannot move out of the pletau!";
    }
}
