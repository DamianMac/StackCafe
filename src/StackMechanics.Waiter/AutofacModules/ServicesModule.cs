using Autofac;
using StackMechanics.Waiter.Services;

namespace StackMechanics.Waiter.AutofacModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<OrderDeliveryService>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}