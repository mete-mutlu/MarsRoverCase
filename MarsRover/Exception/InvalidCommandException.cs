using System;
using Microsoft.Extensions.Configuration;

namespace MarsRover.Exception
{
    [Serializable]
    public class InvalidCommandException : System.Exception
    {
        
        public override string Message => "Invalid Command!";
    }
}
