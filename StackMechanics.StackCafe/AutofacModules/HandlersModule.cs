using Autofac;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.AutofacModules
{
    public class HandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IHandleCommand<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IHandleEvent<>))
                .InstancePerLifetimeScope();
        }
    }
}