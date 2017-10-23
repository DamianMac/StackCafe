using Autofac;
using StackMechanics.StackCafe.Domain.Infrastructure;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.AutofacModules
{
    public class UnitOfWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}