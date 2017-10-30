using Autofac;
using StackMechanics.Cashier.Services;

namespace StackMechanics.Cashier.AutofacModules
{
    public class PretendCustomerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CustomerOrderGenerator>()
                .AsSelf()
                .SingleInstance()
                .AutoActivate()
                .OnActivated(c => c.Instance.Start());
        }
    }
}