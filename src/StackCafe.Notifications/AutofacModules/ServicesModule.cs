using Autofac;
using StackCafe.Notifications.Services;

namespace StackCafe.Notifications.AutofacModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerOrderTracker>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<BurstSmsProvider>().AsImplementedInterfaces();
        }
    }
}