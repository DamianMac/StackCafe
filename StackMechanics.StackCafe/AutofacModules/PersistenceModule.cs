using Autofac;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.AutofacModules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(MemoryRepository<>))
                .As(typeof(MemoryRepository<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(TrackingRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<EntityChangeTracker>()
                .As<IEntityChangeTracker>()
                .InstancePerLifetimeScope();
        }
    }
}