using Microsoft.Extensions.Configuration;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.ReadLine();
        }
    }
}
