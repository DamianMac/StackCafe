using Autofac;
using AutofacSerilogIntegration;

namespace StackMechanics.Barista.AutofacModules
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterLogger();
        }
    }
}