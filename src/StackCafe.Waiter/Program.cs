using System;
using Serilog;
using StackCafe.Common.Logging;

namespace StackCafe.Waiter
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