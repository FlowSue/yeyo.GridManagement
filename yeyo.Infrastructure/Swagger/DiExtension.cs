using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using yeyo.Infrastructure.Treasury.AutoConfigModel;

namespace yeyo.Infrastructure.Swagger
{
    internal static class DiExtension
    {
        internal static void AddSwaggerService(this IServiceCollection services, SwaggerDoc config)
        {
            #region Swagger
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = config.Version,
                    Title = config.Title,
                    Description = config.Description,
                    //TermsOfService = new Uri(contactUrl),
                    Contact = new OpenApiContact { Name = config.ContactName, Email = config.ContactEmail, Url = config.ContactUrl },
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
        }

        internal static void UseSwaggerService(this IApplicationBuilder app, SwaggerDoc configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{configuration.Version}/swagger.json", configuration.ApiName);
                c.RoutePrefix = configuration.Route;
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
        }
    }
}
