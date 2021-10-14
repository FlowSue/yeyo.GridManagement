using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace yeyo.Infrastructure.Treasury.DiExtension
{
    public static class DiExtension
    {
        /// <summary>
        /// 获取单例注册对象
        /// </summary>
        public static T GetSingletonInstanceOrNull<T>(this IServiceCollection services)
        {
            return (T)services.FirstOrDefault(x => x.ServiceType == typeof(T))?.ImplementationInstance;
        }

        /// <summary>
        /// 暴露类型可空注册
        /// （如果暴露类型为null，则自动以其本身类型注册）
        /// </summary>
        /// <param name="services"></param>
        /// <param name="interfaceType"></param>
        /// <param name="instanceType"></param>
        /// <param name="serviceLifetime"></param>
        private static void AddServiceWithLifeScoped(this IServiceCollection services, Type interfaceType, Type instanceType, ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Scoped:
                    if (interfaceType == null) services.AddScoped(instanceType);
                    else services.AddScoped(interfaceType, instanceType);
                    break;
                case ServiceLifetime.Singleton:
                    if (interfaceType == null) services.AddSingleton(instanceType);
                    else services.AddSingleton(interfaceType, instanceType);
                    break;
                case ServiceLifetime.Transient:
                    if (interfaceType == null) services.AddTransient(instanceType);
                    else services.AddTransient(interfaceType, instanceType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, null);
            }
        }
        /// <summary>
        ///  获取Asp.Net Core项目所有程序集
        /// </summary>
        /// <returns></returns>
        public static List<Assembly> GetAllAssembliesCoreWeb()
        {
            var assemblies = new List<Assembly>();
            var dependencyContext = DependencyContext.Default;
            var libs = dependencyContext.CompileLibraries
                .Where(lib => !lib.Serviceable && lib.Type != "package" && lib.Name.StartsWith("C.O.S.E.C"));
            foreach (var lib in libs)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                assemblies.Add(assembly);
            }

            return assemblies;
        }
    }
}
