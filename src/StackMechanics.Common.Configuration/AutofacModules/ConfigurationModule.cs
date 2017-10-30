﻿using Autofac;
using ConfigInjector.Configuration;

namespace StackMechanics.Common.Configuration.AutofacModules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            ConfigurationConfigurator.RegisterConfigurationSettings()
                .FromAssemblies(AppDomainScanner.AppDomainScanner.MyAssemblies)
                .RegisterWithContainer(configSetting => builder.RegisterInstance(configSetting)
                    .AsSelf()
                    .SingleInstance())
                .DoYourThing();
        }
    }
}