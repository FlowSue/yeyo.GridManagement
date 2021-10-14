using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using yeyo.Infrastructure.Auth.DI;
using yeyo.Infrastructure.CustomException;
using yeyo.Infrastructure.Swagger;
using yeyo.Infrastructure.Treasury.AutoConfigModel;

namespace yeyo.Infrastructure.DI
{
    public static class DiExtension
    {
        private static IAllConfigModel _config;
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
            IWebHostEnvironment env, IConfiguration configuration)
        {
            //auto config
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.Development.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            var root = builder.Build();
            services.AddSingleton<IAllConfigModel, AllConfigModel>(_ => new AllConfigModel(root));
            services.AddSingleton<IJwtOptionConfig, JwtOptionConfig>(_ => new JwtOptionConfig(root));
            services.AddSingleton<IConnectionStringsModel, ConnectionStringsModel>(_ => new ConnectionStringsModel(root));
            _config = new AllConfigModel(root);
            //Swagger
            services.AddSwaggerService(_config.SwaggerDoc);

            services.AddAuthService(_config.JwtOptionConfig);

            return services;
        }
        public static void UseInfrastructureService(this IApplicationBuilder app)
        {
            app.UseSwaggerService(_config.SwaggerDoc);

            app.UseExceptionService();
        }
        /// <summary>
        /// 需要放置在app.UseRouting()和app.UseEndpoints()之间
        /// </summary>
        /// <param name="app"></param>
        public static void UseInfrastructureAuthService(this IApplicationBuilder app)
        {
            app.UseCors();

            app.UseAuthService();

        }
    }
}
