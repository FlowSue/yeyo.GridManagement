using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using yeyo.Infrastructure.Swagger;

namespace yeyo.Infrastructure.DI
{
    public static class DiExtension
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
            IWebHostEnvironment env, IConfiguration configuration)
        {
            //Swagger
            services.AddSwaggerService(configuration);
            return services;
        }
        public static void UseInfrastructureService(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwaggerService(configuration);

            //app.UseExceptionService();
        }
        /// <summary>
        /// 需要放置在app.UseRouting()和app.UseEndpoints()之间
        /// </summary>
        /// <param name="app"></param>
        public static void UseInfrastructureAuthService(this IApplicationBuilder app)
        {
            app.UseCors();

            //app.UseAuthService();

            app.UseAuthorization();
        }
    }
}
