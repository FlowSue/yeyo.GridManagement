using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace yeyo.Infrastructure.Auth
{
    static class AuthDiExtension
    {
        internal static IServiceCollection AddAuthService(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }

        internal static void UseAuthService(this IApplicationBuilder builder)
        {

        }
    }
}
