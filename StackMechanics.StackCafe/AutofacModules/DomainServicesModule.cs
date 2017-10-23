using Autofac;
using StackMechanics.StackCafe.Domain.Rules.WhenAnOrderIsReady;
using StackMechanics.StackCafe.Domain.Services;

namespace StackMechanics.StackCafe.AutofacModules
{
    public class DomainServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IDomainService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}