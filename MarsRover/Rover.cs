using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover : IRover
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }


        private readonly IDictionary<Movement, Action> movementMethodDictionary;
        private readonly IDictionary<Direction, Action> leftMoveDictionary;
        private readonly IDictionary<Direction, Action> rightMoveDictionary;
        private readonly IDictionary<Direction, Action> forwardMoveDictionary;
        private bool isLanded;

        public Rover()
        {

            movementMethodDictionary = new Dictionary<Movement, Action>
            {
                {Movement.Left, () => leftMoveDictionary[Direction].Invoke()},
                {Movement.Right, () => rightMoveDictionary[Direction].Invoke()},
                {Movement.Forward, () => forwardMoveDictionary[Direction].Invoke()}
            };

            leftMoveDictionary = new Dictionary<Direction, Action>
            {
                {Direction.North, () => Direction = Direction.West},
                {Direction.East, () => Direction = Direction.North},
                {Direction.South, () => Direction = Direction.East},
                {Direction.West, () => Direction = Direction.South}
            };

            rightMoveDictionary = new Dictionary<Direction, Action>
            {
                {Direction.North, () => Direction = Direction.East},
                {Direction.East, () => Direction = Direction.South},
                {Direction.South, () => Direction = Direction.West},
                {Direction.West, () => Direction = Direction.North}
            };

            forwardMoveDictionary = new Dictionary<Direction, Action>
            {
                {Direction.North, () => {Location = new Location(Location.X, Location.Y + 1);}},
                {Direction.East, () => {Location = new Location(Location.X + 1, Location.Y);}},
                {Direction.South, () => {Location = new Location(Location.X, Location.Y - 1);}},
                {Direction.West, () => {Location = new Location(Location.X - 1, Location.Y);}}
            };
        }


        public void SetPlateuSize(PlateuBase plateu, Location location, Direction direction)
        {

        }

        public void Land(ILocationValidator locationValidator, PlateuBase plateu, Location location, Direction direction)
        {
            if (locationValidator.Validate(location))
            {
                this.Location = location;
                this.Direction = direction;
                isLanded = true;
            }

        }

        public void Move(IEnumerable<Movement> movements)
        {
            throw new NotImplementedException();
        }
    }

}
