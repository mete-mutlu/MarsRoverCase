using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Exception
{
    public class LandingException: System.Exception
    {
        public override string Message => "Invalid Command!";
    }
}
