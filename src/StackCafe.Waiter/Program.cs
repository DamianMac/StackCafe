using ConfigInjector.QuickAndDirty;
using StackCafe.Common.Configuration.Configuration;
using Topshelf;

namespace StackCafe.Waiter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                var serviceName = DefaultSettingsReader.Get<ApplicationName>();

                x.Service<WaiterService>(sc =>
                {
                    sc
                        .ConstructUsing(() => new WaiterService())
                        .WhenStarted(s => s.Start())
                        .WhenStopped(s => s.Stop())
                        ;
                });

                x.SetServiceName(serviceName);
                x.SetDisplayName(serviceName);
                x.SetDescription(serviceName);
            });
        }
    }
}