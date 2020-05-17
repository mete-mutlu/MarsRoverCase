using MarsRover.Domain;

namespace MarsRover.Factory
{
    public class RoverFactory : IRoverFactory
    {
        private readonly IValidatorFactory validatorFactory;

        public RoverFactory(IValidatorFactory validatorFactory) 
        {
            this.validatorFactory = validatorFactory;
        }
        public IRover CreateRover()
        {
            return new Rover(validatorFactory.CreateLocationValidator());
        }
    }
}
