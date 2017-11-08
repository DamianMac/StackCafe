using Autofac;
using StackCafe.CurrencyHistory.Services;

namespace StackCafe.CurrencyHistory.AutofacModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<ExchangeRateRepository>()
               .AsImplementedInterfaces()
               .SingleInstance();

        }
    }
}
