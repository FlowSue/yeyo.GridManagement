using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using yeyo.Infrastructure.Auth.Authorize;
using yeyo.Infrastructure.Auth.JWT;
using yeyo.Infrastructure.Auth.Models;
using yeyo.Infrastructure.Auth.Operate;
using yeyo.Infrastructure.Treasury.AutoConfigModel;

namespace yeyo.Infrastructure.Auth.DI
{
    public static class DiExtension
    {
        public static void AddAuthService(this IServiceCollection services, IJwtOptionConfig jwtOption)
        {
            services.AddSingleton<JwtSecurityTokenHandler>();
            services.AddSingleton<IJwtService, JwtService>();
            #region 注册【认证】服务
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {

                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role,
                    ValidIssuer = "C.O.S.E.C",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOption.SecurityKey)),
                    /***********************************TokenValidationParameters的参数默认值***********************************/
                    //RequireSignedTokens = true,
                    //RequireExpirationTime = true,
                    // SaveSigninToken = false,
                    // ValidateActor = false,
                    ValidateAudience = false,
                    //ValidateIssuer = true,
                    //ValidateIssuerSigningKey = true,
                    //ClockSkew = TimeSpan.FromSeconds(5),// 允许的服务器时间偏移量
                };
                o.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        //Token expired
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            #endregion

            #region 注册【授权】服务
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthPolicyEnum.Free.ToString(), policy => policy.AddRequirements(new PolicyRequirement(false)));
                //options.AddPolicy(AuthPolicyEnum.RequireRoleOfClient.ToString(), policy => policy.AddRequirements(new PolicyRequirement("SystemAdmin,Client")));
                //options.AddPolicy(AuthPolicyEnum.RequireRoleOfAdmin.ToString(), policy => policy.AddRequirements(new PolicyRequirement("SystemAdmin,Admin")));
                //options.AddPolicy(AuthPolicyEnum.RequireRoleOfAdminOrClient.ToString(), policy => policy.AddRequirements(new PolicyRequirement("SystemAdmin,Admin,Client")));
                options.AddPolicy(AuthPolicyEnum.RequireRoleOfSystemAdmin.ToString(), policy => policy.AddRequirements(new PolicyRequirement("SystemAdmin")));
            });
            #endregion

            services.AddSingleton<IAuthorizationHandler, PolicyHandler>();

            //注册IOperateInfo
            services.AddScoped<IOperatorInfo, OperatorInfo>();
            services.AddScoped<IEntityBaseAutoSetter, OperatorSetter>();
        }

        public static void UseAuthService(this IApplicationBuilder app)
        {
            //认证
            app.UseAuthentication();

            //授权
            app.UseAuthorization();

        }
    }
}
