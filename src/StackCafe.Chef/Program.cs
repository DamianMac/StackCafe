using ConfigInjector.QuickAndDirty;
using StackCafe.Common.Configuration.Configuration;
using Topshelf;

namespace StackCafe.Chef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                var serviceName = DefaultSettingsReader.Get<ApplicationName>();

                x.Service<ChefService>(sc =>
                {
                    sc
                        .ConstructUsing(() => new ChefService())
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
