using System;
using Microsoft.Extensions.Configuration;

namespace MarsRover
{
    public class InvalidCommandException : Exception
    {
        
        public override string Message => "Invalid Command!";
    }
}
