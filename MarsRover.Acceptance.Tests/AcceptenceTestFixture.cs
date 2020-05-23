using Autofac;
using System.Reflection;

namespace MarsRover.Tests
{
    public class AcceptenceTestFixture
    {
        public IContainer Container { get; private set; }

        public AcceptenceTestFixture()
        {
            var programAssembly = Assembly.GetAssembly(typeof(Program));

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(programAssembly)
                .AsImplementedInterfaces();

            Container = builder.Build();
        }
    }
}
