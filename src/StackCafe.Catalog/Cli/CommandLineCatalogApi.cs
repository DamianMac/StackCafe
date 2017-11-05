using System;
using Serilog;
using StackCafe.Catalog.Contracts;
using StackCafe.Catalog.Messages;
using StackCafe.Catalog.Messaging;

namespace StackCafe.Catalog.Cli
{
    public class CommandLineCatalogApi
    {
        readonly IBus _bus;

        public CommandLineCatalogApi(IBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            Log.Information("Starting CLI");

            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var items = line.Split();
                Log.Information("Dispatching {CliCommand}", items);

                switch (items[0])
                {
                    case "add":
                    {
                        var data = new ProductData(Guid.NewGuid(), items[1], items[2]);
                        _bus.Send(new AddProductCommand(data));
                        break;
                    }
                    case "lookup":
                    {
                        var response = _bus.Request(new LookupProductRequest(items[1]));
                        if (response.Product.HasValue)
                            Console.WriteLine($"Name: {response.Product.Value.Name}");
                        else
                            Console.WriteLine("Not found");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please enter `add <name> <code>` or `lookup <code>`");
                        break;
                    }
                }
            }

            Log.Information("Stopping CLI");
        }
    }
}
