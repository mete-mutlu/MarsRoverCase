using MarsRover.Exception;
using MarsRover.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class Rover : IRover
    {
        public Location Location { get; set; }

        private Location preLocation;
        public Direction Direction { get; set; }

        public IPlateu Plateu { get; set; }
      

        private readonly IDictionary<Movement, Action> movementMethodDictionary;
        private readonly IDictionary<Direction, Action> leftMoveDictionary;
        private readonly IDictionary<Direction, Action> rightMoveDictionary;
        private readonly IDictionary<Direction, Action> forwardMoveDictionary;
        private readonly ILocationValidator locationValidator;
        private bool isLanded;

        public Rover(ILocationValidator locationValidator)
        {
            this.locationValidator = locationValidator;
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
                {Direction.North, () => { preLocation = new Location(Location.X, Location.Y + 1); } },
                {Direction.East, () => { preLocation = new Location(Location.X + 1, Location.Y);} },
                {Direction.South, () => { preLocation = new Location(Location.X, Location.Y - 1); } },
                {Direction.West, () => { preLocation = new Location(Location.X - 1, Location.Y); }}
            };
        }




        public void Land(IPlateu plateu, Location location, Direction direction)
        {
            if (locationValidator.Validate(location, plateu))
            {
                this.Location = location;
                this.Plateu = plateu;
                this.Direction = direction;
                this.isLanded = true;
            }
            else
                throw new OutOfBoundaryLandingException();
        }

        public void Move(IEnumerable<Movement> movements)
        {
            foreach (var movement in movements)
            {
                movementMethodDictionary[movement].Invoke();

                if (movement == Movement.Forward)
                    if (locationValidator.Validate(preLocation, this.Plateu))
                        Location = preLocation;
                    else
                        throw new OutOfBoundaryMovementException();

            }
        }

        public bool IsLanded()
        {
            return isLanded;
        }
    }

}
