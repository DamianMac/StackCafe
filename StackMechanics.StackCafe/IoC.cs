using Autofac;

namespace StackMechanics.StackCafe
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC()
        {
            var thisAssembly = typeof(IoC).Assembly;
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(thisAssembly);
            var container = builder.Build();
            return container;
        }
    }
}