using Autofac;
using Autofac.Builder;

namespace StackCafe.Common.Configuration
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC(ContainerBuildOptions containerBuildOptions = ContainerBuildOptions.None)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(AppDomainScanner.AppDomainScanner.MyAssemblies);
            return builder.Build(containerBuildOptions);
        }
    }
}