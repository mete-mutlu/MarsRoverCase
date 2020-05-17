using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class OutputGenerator : IOutputGenerator
    {
        private readonly IDictionary<Direction, char> directionDictionary;

        public OutputGenerator()
        {
            directionDictionary = new Dictionary<Direction, char>
            {
                 {Direction.North, 'N'},
                 {Direction.South, 'S'},
                 {Direction.East, 'E'},
                 {Direction.West, 'W'}
            };
        }
        public string GetOutput(IEnumerable<IRover> rovers)
        {
            var output = new StringBuilder();
            foreach (var rover in rovers)
            {
                if (rover.IsLanded())
                {
                    var roverOutput = string.Format("{0} {1} {2}", 
                        rover.Location.X, 
                        rover.Location.Y, 
                        directionDictionary[rover.Direction]).ToString();
                    output.AppendLine(roverOutput);
                }
                else
                    output.AppendLine(string.Format("A Rover Could Not Landed!"));
            }
            return output.ToString().TrimEnd('\n', '\r');
        }
    }
}
