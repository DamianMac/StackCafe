using ConfigInjector.QuickAndDirty;
using StackCafe.Common.Configuration.Configuration;
using System;
using System.Linq;
using Topshelf;

namespace StackCafe.Customer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                var serviceName = DefaultSettingsReader.Get<ApplicationName>();

                x.Service<CustomerService>(sc =>
                {
                    sc
                        .ConstructUsing(() => new CustomerService())
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
