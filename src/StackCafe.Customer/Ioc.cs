using Autofac;
using Autofac.Builder;
using StackCafe.Common.AppDomainScanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.Customer
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC(ContainerBuildOptions containerBuildOptions = ContainerBuildOptions.None)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(AppDomainScanner.MyAssemblies);
            return builder.Build(containerBuildOptions);
        }
    }
}
