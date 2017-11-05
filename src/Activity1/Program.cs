using System;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using StackCafe.Catalog.Cli;
using StackCafe.Catalog.Handlers;
using StackCafe.Catalog.InMemory;

namespace Activity1
{
    class Program
    {
        static int Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            try
            {
                var products = new InMemoryProductRepository();
                var cli = new CommandLineCatalogApi(
                    new InMemoryMessageBus(
                        new AddProductCommandHandler(products),
                        new LookupProductRequestHandler(products)));

                cli.Start();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The API terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
