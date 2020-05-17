using Autofac;
using MarsRover.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using System.Text;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {

            var programAssembly = Assembly.GetExecutingAssembly();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(programAssembly)
                .AsImplementedInterfaces();

            using (var container = containerBuilder.Build())
            {
                var commandString = GetInputCommand();
                var commandManager = container.Resolve<ICommandManager>();
                commandManager.Execute(commandString);
                var output = commandManager.GetOutput();
                WriteToConsole(commandString, output);
            }
        }
      

        private static void WriteToConsole(string commandString, string roverReports)
        {
            Console.WriteLine("Input:");
            Console.WriteLine(commandString);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Output:");
            Console.WriteLine(roverReports);
            Console.Write(Environment.NewLine);
            Console.Write("Press <enter> to exit...");
            Console.ReadLine();
        }

        private static string GetInputCommand()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }

    }
}
