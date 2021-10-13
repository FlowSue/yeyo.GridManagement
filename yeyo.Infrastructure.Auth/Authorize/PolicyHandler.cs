using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using yeyo.Infrastructure.Auth.Models;

namespace yeyo.Infrastructure.Auth.Authorize
{
    internal class PolicyHandler : AuthorizationHandler<PolicyRequirement>
    {
        /// <summary>
        /// 授权方式（cookie, bearer, oauth, openid）
        /// </summary>
        private readonly IAuthenticationSchemeProvider _schemes;
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="schemes"></param>
        public PolicyHandler(IAuthenticationSchemeProvider schemes)
        {
            _schemes = schemes;
        }

        public PolicyHandler(IAuthenticationSchemeProvider schemes, IHttpContextAccessor httpContextAccessor) : this(schemes)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 授权处理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PolicyRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return;

            if (!requirement.IsNeedAuthorized)
            {
                context.Succeed(requirement);
                return;
            }

            //获取授权方式
            var defaultAuthenticate = await _schemes.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate == null)
            {
                context.Fail();
                return;
            }

            //验证token（包括过期时间）
            var result = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);
            if (!result.Succeeded)
            {
                System.Console.WriteLine(result.Failure);
                context.Fail();
                return;
            }

            httpContext.User = result.Principal;

            //判断角色
            var tokenModelJsonStr = httpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimEnum.TokenModel.ToString())?.Value;
            var tm = JsonConvert.DeserializeObject<TokenModel>(tokenModelJsonStr);

            if (!requirement.GetRequireRoles().Contains(tm.Role))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
