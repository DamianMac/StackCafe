using System;
using Autofac;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using StackCafe.Catalog.Cli;
using StackCafe.Catalog.Data;
using StackCafe.Catalog.InMemory;
using StackCafe.Catalog.Messaging;
using StackCafe.Catalog.Model;

namespace Activity2
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
                var builder = new ContainerBuilder();

                builder.RegisterType<InMemoryProductRepository>()
                    .As<IProductRepository>()
                    .SingleInstance();

                builder.RegisterType<InMemoryMessageBus>().As<IBus>();

                builder.RegisterType<CommandLineCatalogApi>();

                builder.RegisterAssemblyTypes(typeof(Product).Assembly)
                    .AsClosedTypesOf(typeof(IHandleRequest<,>));

                builder.RegisterAssemblyTypes(typeof(Product).Assembly)
                    .AsClosedTypesOf(typeof(IHandleCommand<>));

                using (var container = builder.Build())
                {
                    var cli = container.Resolve<CommandLineCatalogApi>();
                    cli.Start();
                    return 0;
                }
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
