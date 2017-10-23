using Autofac;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.AutofacModules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();
        }
    }
}