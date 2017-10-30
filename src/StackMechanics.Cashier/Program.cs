﻿using System;
using Serilog;
using StackMechanics.Common.Logging;

namespace StackMechanics.Cashier
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