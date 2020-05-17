using System;

namespace MarsRover.Exception
{
    [Serializable]
    public class InvalidCommandException : System.Exception
    {
        
        public override string Message => "Invalid Command!";
    }
}
