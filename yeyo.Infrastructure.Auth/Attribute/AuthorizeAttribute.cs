using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using yeyo.Infrastructure.Auth.Models;

namespace yeyo.Infrastructure.Auth.Attribute
{
    internal class AuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizeAttribute(AuthPolicyEnum authPolicyEnum = AuthPolicyEnum.RequireRoleOfSystemAdmin, string schemes = JwtBearerDefaults.AuthenticationScheme)
        {
            this.Policy = authPolicyEnum.ToString();
            this.AuthenticationSchemes = schemes;
        }
    }
}
