using System;
using ConfigInjector.QuickAndDirty;
using StackCafe.Common.Configuration.Configuration;
using Topshelf;

namespace StackCafe.Barista
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                HostFactory.Run(x =>
                {
                    var serviceName = DefaultSettingsReader.Get<ApplicationName>();

                    x.Service<BaristaService>(sc =>
                    {
                        sc
                            .ConstructUsing(() => new BaristaService())
                            .WhenStarted(s => s.Start())
                            .WhenStopped(s => s.Stop())
                            ;
                    });

                    x.SetServiceName(serviceName);
                    x.SetDisplayName(serviceName);
                    x.SetDescription(serviceName);
                });
            }
            catch (Exception e)
            {

            }
        }
    }
}