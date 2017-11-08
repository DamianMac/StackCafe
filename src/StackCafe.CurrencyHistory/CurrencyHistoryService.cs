using System;
using Autofac;
using Serilog;
using StackCafe.Common.Logging;

namespace StackCafe.CurrencyHistory
{
    internal class CurrencyHistoryService
    {
        private IContainer _container;

        public void Start()
        {
            Log.Logger = DefaultLoggerConfiguration.CreateLogger();

            try
            {
                _container = IoC.LetThereBeIoC();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled exception occurred");
                Log.CloseAndFlush();
                throw;
            }
        }

        public void Stop()
        {
            _container?.Dispose();
            Log.CloseAndFlush();
        }
    }
}