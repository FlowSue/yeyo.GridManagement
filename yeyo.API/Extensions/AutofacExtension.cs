using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using yeyo.GridManagement.Domain.Interfaces;
using yeyo.Infrastructure.Treasury.AutoConfigModel;

namespace yeyo.API.Extensions
{
    public static class AutofacExtension
    {
        public static void ConfigureAutofac(this ContainerBuilder builder)
        {
            {
                var baseType = typeof(IRepository);
                var assemblyName = Assembly.GetAssembly(baseType)?.GetName().Name;
                var assemblies = Assembly.Load(assemblyName);
                builder.RegisterAssemblyTypes(assemblies)
                    .Where(t => t.Name.EndsWith("Service", StringComparison.CurrentCulture) &&
                                baseType.IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired();
            }

            //var assemblies2 = Assembly.Load("C.O.S.E.C.Infrastructure.Repository");
            //builder.RegisterAssemblyTypes(assemblies2)
            //    .Where(t => t.Name.EndsWith("BLL", StringComparison.CurrentCulture) && baseType.IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract)
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope()
            //    .PropertiesAutowired();
        }

        public static IHostBuilder UseAutofacServiceProviderFactory(this IHostBuilder builder)
        {
            return builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }
    }
}
