using Autofac;
using StackCafe.CurrencyTicker.Services;

namespace StackCafe.CurrencyTicker.AutofacModules
{
    public class ExchangeMonitorServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ExchangeMonitorService>()
                .AsSelf()
                .SingleInstance()
                .AutoActivate()
                .OnActivated(c => c.Instance.Start());
        }
    }
}