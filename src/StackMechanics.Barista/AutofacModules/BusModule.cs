using System;
using System.Reflection;
using Autofac;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Transports.Redis;
using StackMechanics.Barista.Configuration;
using Module = Autofac.Module;

namespace StackMechanics.Barista.AutofacModules
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var handlerTypesProvider = new AssemblyScanningTypeProvider(Assembly.GetExecutingAssembly());

            builder.RegisterNimbus(handlerTypesProvider);
            builder.Register(componentContext => new BusBuilder()
                .Configure()
                .WithTransport(new RedisTransportConfiguration()
                    .WithConnectionString(componentContext.Resolve<BusConnectionString>())
                )
                .WithNames(ThisAssembly.FullName, Environment.MachineName)
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