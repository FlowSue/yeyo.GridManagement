using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace yeyo.Infrastructure.Swagger
{
    internal static class SwaggerDiExtension
    {
        internal static IServiceCollection AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
        {
            #region Swagger
            services.AddSwaggerGen(opt =>
            {
                var contactName = configuration.GetSection("SwaggerDoc:contactName").Value;
                var contactEmail = configuration.GetSection("SwaggerDoc:contactEmail").Value;
                var contactUrl = configuration.GetSection("SwaggerDoc:contactUrl").Value;
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = configuration.GetSection("SwaggerDoc:Version").Value,
                    Title = configuration.GetSection("SwaggerDoc:Title").Value,
                    Description = configuration.GetSection("SwaggerDoc:Description").Value,
                    //TermsOfService = new Uri(contactUrl),
                    Contact = new OpenApiContact { Name = contactName, Email = contactEmail, Url = new Uri(contactUrl) },
                    //License = new OpenApiLicense { Name = contactName, Url = new Uri(contactUrl) }
                });
                // 添加读取注释服务
                //if (FileHelper.FileExists($"{AppContext.BaseDirectory}C.O.S.E.C.API.xml"))
                //{
                //    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, "C.O.S.E.C.API.xml");
                //    opt.IncludeXmlComments(apiXmlPath, true);
                //}
                //if (FileHelper.FileExists($"{AppContext.BaseDirectory}C.O.S.E.C.Entity.xml"))
                //{
                //    var entityXmlPath = Path.Combine(AppContext.BaseDirectory, "C.O.S.E.C.Entity.xml");
                //    opt.IncludeXmlComments(entityXmlPath, true);
                //}
                //opt.DocumentFilter<HiddenApiFilter>();
                //opt.OperationFilter<AddHeaderOperationFilter>("correlationID", "Correlation ID for the request", false);
                //opt.OperationFilter<AddResponseHeadersFilter>();
                //opt.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //opt.OperationFilter<SecurityRequirementsOperationFilter>();
                //给api添加token令牌证书
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #region Obsolete
                //opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    { new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference()
                //            {
                //            Id = "Bearer",
                //            Type = ReferenceType.SecurityScheme
                //            }
                //        }, Array.Empty<string>() }
                //});
                //opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                //    Name = "Authorization",//jwt默认的参数名称
                //    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                //    Type = SecuritySchemeType.ApiKey
                //});
                #endregion
            });
            #endregion
            return services;
        }

        internal static void UseSwaggerService(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ApiHelp V1");
                c.RoutePrefix = configuration.GetSection("SwaggerDoc:Route").Value;
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
        }
    }
}
