using System;
using Serilog;

namespace StackMechanics.Barista
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LogBootstrapper.Bootstrap();

            using (var container = IoC.LetThereBeIoC())
            {
                Console.ReadKey();
            }

            Log.CloseAndFlush();
        }
    }
}