using Autofac;
using Autofac.Builder;

namespace StackMechanics.Barista
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC(ContainerBuildOptions containerBuildOptions = ContainerBuildOptions.None)
        {
            var thisAssembly = typeof(IoC).Assembly;

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(thisAssembly);
            return builder.Build(containerBuildOptions);
        }
    }
}