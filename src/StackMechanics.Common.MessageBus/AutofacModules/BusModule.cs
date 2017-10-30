using System;
using Autofac;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Transports.Redis;
using StackMechanics.Common.Configuration.Configuration;
using StackMechanics.Common.MessageBus.Configuration;

namespace StackMechanics.Common.MessageBus.AutofacModules
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var handlerTypesProvider = new AssemblyScanningTypeProvider(AppDomainScanner.AppDomainScanner.MyAssemblies);

            builder.RegisterNimbus(handlerTypesProvider);
            builder.Register(componentContext => new BusBuilder()
                .Configure()
                .WithTransport(new RedisTransportConfiguration()
                    .WithConnectionString(componentContext.Resolve<BusConnectionString>())
                )
                .WithNames(componentContext.Resolve<ApplicationName>(), Environment.MachineName)
                .WithTypesFrom(handlerTypesProvider)
                .WithAutofacDefaults(componentContext)
                .WithSerilogLogger()
                .WithJsonSerializer()
                .WithGlobalPrefix(componentContext.Resolve<BusGlobalPrefix>())
                .Build())
                .As<IBus>()
                .AutoActivate()
                .OnActivated(c => c.Instance.Start())
                .OnRelease(bus =>
                {
                    bus.Stop().Wait();
                    bus.Dispose();
                })
                .SingleInstance();
        }
    }
}